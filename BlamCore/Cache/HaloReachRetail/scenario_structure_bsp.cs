﻿using System.IO;
using BlamCore.Common;
using BlamCore.IO;
using sbsp = BlamCore.Cache.scenario_structure_bsp;

namespace BlamCore.Cache.ReachRetail
{
    public class scenario_structure_bsp : ReachBeta.scenario_structure_bsp
    {
        protected scenario_structure_bsp() { }

        public scenario_structure_bsp(Base.CacheFile Cache, int Address)
        {
            cache = Cache;
            EndianReader Reader = Cache.Reader;
            Reader.SeekTo(Address);

            #region sldt/lbsp ID
            //lbsp's sections address will be used instead of the one in sbsp
            int sectionAddress = 0;
            int sectionCount = 0;
            foreach (var item in Cache.IndexItems)
            {
                if (item.ClassCode == "scnr")
                {
                    Reader.SeekTo(item.Offset + 76);
                    int cnt = Reader.ReadInt32();
                    int ptr = Reader.ReadInt32() - Cache.Magic;

                    int bspIndex = 0;

                    for (int i = 0; i < cnt; i++)
                    {
                        Reader.SeekTo(ptr + 172 * i + 12);
                        if (Cache.IndexItems.GetItemByID(Reader.ReadInt32()).Offset == Address)
                        {
                            bspIndex = i;
                            break;
                        }
                    }

                    Reader.SeekTo(item.Offset + 1844 + 12);
                    int sldtID = Reader.ReadInt32();
                    int sldtAddress = Cache.IndexItems.GetItemByID(sldtID).Offset;

                    Reader.SeekTo(sldtAddress + 4);
                    cnt = Reader.ReadInt32();
                    ptr = Reader.ReadInt32() - Cache.Magic;

                    Reader.SeekTo(ptr + 32 * bspIndex + 12);
                    int lbspID = Reader.ReadInt32();
                    int lbspAddress = Cache.IndexItems.GetItemByID(lbspID).Offset;

                    Reader.SeekTo(lbspAddress + 124);
                    sectionCount = Reader.ReadInt32();
                    sectionAddress = Reader.ReadInt32() - Cache.Magic;

                    Reader.SeekTo(lbspAddress + 268);
                    geomRawID = Reader.ReadInt32();
                    break;
                }
            }
            #endregion

            Reader.SeekTo(Address + 236);
            XBounds = new Bounds<float>(Reader.ReadSingle(), Reader.ReadSingle());
            YBounds = new Bounds<float>(Reader.ReadSingle(), Reader.ReadSingle());
            ZBounds = new Bounds<float>(Reader.ReadSingle(), Reader.ReadSingle());

            #region Clusters Block
            Reader.SeekTo(Address + 308);
            int iCount = Reader.ReadInt32();
            int iOffset = Reader.ReadInt32() - Cache.Magic;
            for (int i = 0; i < iCount; i++)
                Clusters.Add(new Cluster(Cache, iOffset + 140 * i));
            #endregion

            #region Shaders Block
            Reader.SeekTo(Address + 320);
            iCount = Reader.ReadInt32();
            iOffset = Reader.ReadInt32() - Cache.Magic;
            for (int i = 0; i < iCount; i++)
                Shaders.Add(new ReachRetail.render_model.Shader(Cache, iOffset + 44 * i));
            #endregion

            #region GeometryInstances Block
            Reader.SeekTo(Address + 608);
            iCount = Reader.ReadInt32();
            iOffset = Reader.ReadInt32() - Cache.Magic;
            for (int i = 0; i < iCount; i++)
                GeomInstances.Add(new InstancedGeometry(Cache, iOffset + 4 * i));

            #region Load Fixup Data
            Reader.SeekTo(Address + 1298);
            int id = Reader.ReadUInt16();
            var entry = Cache.zone.RawEntries[id];
            var er = new EndianReader(new MemoryStream(Cache.zone.FixupData), EndianFormat.BigEndian);
            int addr = entry.Fixups[entry.Fixups.Count - 10].Offset;

            for (int i = 0; i < GeomInstances.Count; i++)
            {
                er.SeekTo(entry.FixupOffset + addr + 156 * i);
                var geom = GeomInstances[i];

                geom.TransformScale = er.ReadSingle();

                geom.TransformMatrix.m11 = er.ReadSingle();
                geom.TransformMatrix.m12 = er.ReadSingle();
                geom.TransformMatrix.m13 = er.ReadSingle();

                geom.TransformMatrix.m21 = er.ReadSingle();
                geom.TransformMatrix.m22 = er.ReadSingle();
                geom.TransformMatrix.m23 = er.ReadSingle();

                geom.TransformMatrix.m31 = er.ReadSingle();
                geom.TransformMatrix.m32 = er.ReadSingle();
                geom.TransformMatrix.m33 = er.ReadSingle();

                geom.TransformMatrix.m41 = er.ReadSingle();
                geom.TransformMatrix.m42 = er.ReadSingle();
                geom.TransformMatrix.m43 = er.ReadSingle();

                er.ReadUInt16();
                er.ReadUInt16();
                er.ReadUInt16();
                geom.SectionIndex = er.ReadUInt16();
            }
            er.Close();
            er.Dispose(); 
            #endregion
            #endregion

            Reader.SeekTo(Address + 796);
            RawID1 = Reader.ReadInt32();

            Reader.SeekTo(Address + 976);
            RawID2 = Reader.ReadInt32();

            #region ModelParts Block
            Reader.SeekTo(Address + 1100);
            iCount = Reader.ReadInt32();
            iOffset = Reader.ReadInt32() - Cache.Magic;
            if (sectionAddress == -Cache.Magic) sectionAddress = iOffset; //null address in lbsp
            for (int i = 0; i < iCount; i++)
                ModelSections.Add(new ReachRetail.render_model.ModelSection(Cache, sectionAddress + 92 * i));
            #endregion

            #region Bounding Boxes Block
            Reader.SeekTo(Address + 1112);
            iCount = Reader.ReadInt32();
            iOffset = Reader.ReadInt32() - Cache.Magic;
            for (int i = 0; i < iCount; i++)
                BoundingBoxes.Add(new ReachRetail.render_model.BoundingBox(Cache, iOffset + 52 * i));
            #endregion

            Reader.SeekTo(Address + 1244);
            RawID3 = Reader.ReadInt32();
        }

        new public class Cluster : sbsp.Cluster
        {
            public Cluster(Base.CacheFile Cache, int Address)
            {
                EndianReader Reader = Cache.Reader;
                Reader.SeekTo(Address);

                XBounds = new Bounds<float>(Reader.ReadSingle(), Reader.ReadSingle());
                YBounds = new Bounds<float>(Reader.ReadSingle(), Reader.ReadSingle());
                ZBounds = new Bounds<float>(Reader.ReadSingle(), Reader.ReadSingle());

                Reader.SeekTo(Address + 64);
                SectionIndex = Reader.ReadInt16();
            }
        }

        new public class InstancedGeometry : sbsp.InstancedGeometry
        {
            public InstancedGeometry(Base.CacheFile Cache, int Address)
            {
                EndianReader Reader = Cache.Reader;
                Reader.SeekTo(Address);

                Name = Cache.Strings.GetItemByID(Reader.ReadInt32());
            }
        }
    }
}

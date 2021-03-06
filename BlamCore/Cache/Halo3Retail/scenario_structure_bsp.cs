﻿

using sbsp = BlamCore.Cache.scenario_structure_bsp;
using BlamCore.Common;
using BlamCore.IO;

namespace BlamCore.Cache.Halo3Retail
{
    public class scenario_structure_bsp : Halo3Beta.scenario_structure_bsp
    {
        protected scenario_structure_bsp() { }

        public scenario_structure_bsp(Base.CacheFile Cache, int Address)
        {
            cache = Cache;
            EndianReader Reader = Cache.Reader;
            Reader.SeekTo(Address);

            #region sldt ID
            //sldt's sections address will be used instead of the one in sbsp
            int sectionAddress = 0;
            foreach (var item in Cache.IndexItems)
            {
                if (item.ClassCode == "scnr")
                {
                    Reader.SeekTo(item.Offset + 20);
                    int cnt = Reader.ReadInt32();
                    int ptr = Reader.ReadInt32() - Cache.Magic;

                    int bspIndex = 0;

                    for (int i = 0; i < cnt; i++)
                    {
                        Reader.SeekTo(ptr + 108 * i + 12);
                        if (Cache.IndexItems.GetItemByID(Reader.ReadInt32()).Offset == Address)
                        {
                            bspIndex = i;
                            break;
                        }
                    }

                    Reader.SeekTo(item.Offset + 1776 + 12);
                    int sldtID = Reader.ReadInt32();
                    int sldtAddress = Cache.IndexItems.GetItemByID(sldtID).Offset;

                    Reader.SeekTo(sldtAddress + 4);
                    cnt = Reader.ReadInt32();
                    ptr = Reader.ReadInt32() - Cache.Magic;

                    for (int i = 0; i < cnt; i++)
                    {
                        Reader.SeekTo(ptr + 436 * i + 2);

                        if (Reader.ReadInt16() != bspIndex) continue;

                        Reader.SeekTo(ptr + 436 * i + 312);
                        sectionAddress = Reader.ReadInt32() - Cache.Magic;

                        Reader.SeekTo(ptr + 436 * i + 428);
                        geomRawID = Reader.ReadInt32();
                    }

                    break;
                }
            }
            #endregion

            Reader.SeekTo(Address + 60);
            XBounds = new Bounds<float>(Reader.ReadSingle(), Reader.ReadSingle());
            YBounds = new Bounds<float>(Reader.ReadSingle(), Reader.ReadSingle());
            ZBounds = new Bounds<float>(Reader.ReadSingle(), Reader.ReadSingle());

            #region Clusters Block
            Reader.SeekTo(Address + 180);
            int iCount = Reader.ReadInt32();
            int iOffset = Reader.ReadInt32() - Cache.Magic;
            for (int i = 0; i < iCount; i++)
                Clusters.Add(new Cluster(Cache, iOffset + 220 * i));
            #endregion

            #region Shaders Block
            Reader.SeekTo(Address + 192);
            iCount = Reader.ReadInt32();
            iOffset = Reader.ReadInt32() - Cache.Magic;
            for (int i = 0; i < iCount; i++)
                Shaders.Add(new Halo3Beta.render_model.Shader(Cache, iOffset + 36 * i));
            #endregion

            #region GeometryInstances Block
            Reader.SeekTo(Address + 432);
            iCount = Reader.ReadInt32();
            iOffset = Reader.ReadInt32() - Cache.Magic;
            for (int i = 0; i < iCount; i++)
                GeomInstances.Add(new InstancedGeometry(Cache, iOffset + 120 * i));
            #endregion

            Reader.SeekTo(Address + 580);
            RawID1 = Reader.ReadInt32();

            #region ModelSections Block
            Reader.SeekTo(Address + 740);
            iCount = Reader.ReadInt32();
            iOffset = Reader.ReadInt32() - Cache.Magic;
            for (int i = 0; i < iCount; i++)
                ModelSections.Add(new Halo3Beta.render_model.ModelSection(Cache, sectionAddress + 76 * i));
            #endregion

            #region Bounding Boxes Block
            Reader.SeekTo(Address + 752);
            iCount = Reader.ReadInt32();
            iOffset = Reader.ReadInt32() - Cache.Magic;
            for (int i = 0; i < iCount; i++)
                BoundingBoxes.Add(new Halo3Beta.render_model.BoundingBox(Cache, iOffset + 44 * i));
            #endregion

            Reader.SeekTo(Address + 860);
            RawID2 = Reader.ReadInt32();

            Reader.SeekTo(Address + 892);
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

                Reader.SeekTo(Address + 156);
                SectionIndex = Reader.ReadInt16();
            }
        }
    }
}

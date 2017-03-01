﻿using BlamCore.Common;
using BlamCore.IO;

namespace BlamCore.Cache.ReachRetail
{
    public class render_model : ReachBeta.render_model
    {
        protected render_model() { }

        public render_model(Base.CacheFile Cache, int Address)
        {
            cache = Cache;
            EndianReader Reader = Cache.Reader;
            Reader.SeekTo(Address);

            Name = Cache.Strings.GetItemByID(Reader.ReadInt32());
            Flags = new Bitmask(Reader.ReadInt32());

            #region Regions Block
            Reader.SeekTo(Address + 12);
            int iCount = Reader.ReadInt32();
            int iOffset = Reader.ReadInt32() - Cache.Magic;
            for (int i = 0; i < iCount; i++)
                Regions.Add(new Region(Cache, iOffset + 16 * i));
            #endregion

            Reader.SeekTo(Address + 28);
            InstancedGeometryIndex = Reader.ReadInt32();

            #region Instanced Geometry Block
            Reader.SeekTo(Address + 32);
            iCount = Reader.ReadInt32();
            iOffset = Reader.ReadInt32() - Cache.Magic;
            for (int i = 0; i < iCount; i++)
                GeomInstances.Add(new InstancedGeometry(Cache, iOffset + 60 * i));
            #endregion

            #region Nodes Block
            Reader.SeekTo(Address + 48);
            iCount = Reader.ReadInt32();
            iOffset = Reader.ReadInt32() - Cache.Magic;
            for (int i = 0; i < iCount; i++)
                Nodes.Add(new Node(Cache, iOffset + 96 * i));
            #endregion

            #region MarkerGroups Block
            Reader.SeekTo(Address + 60);
            iCount = Reader.ReadInt32();
            iOffset = Reader.ReadInt32() - Cache.Magic;
            for (int i = 0; i < iCount; i++)
                MarkerGroups.Add(new MarkerGroup(Cache, iOffset + 16 * i));
            #endregion

            #region Shaders Block
            Reader.SeekTo(Address + 72);
            iCount = Reader.ReadInt32();
            iOffset = Reader.ReadInt32() - Cache.Magic;
            for (int i = 0; i < iCount; i++)
                Shaders.Add(new Shader(Cache, iOffset + 44 * i));
            #endregion

            #region ModelSections Block
            Reader.SeekTo(Address + 104);
            iCount = Reader.ReadInt32();
            iOffset = Reader.ReadInt32() - Cache.Magic;
            for (int i = 0; i < iCount; i++)
                ModelSections.Add(new ModelSection(Cache, iOffset + 92 * i));
            #endregion

            #region BoundingBox Block
            Reader.SeekTo(Address + 116);
            iCount = Reader.ReadInt32();
            iOffset = Reader.ReadInt32() - Cache.Magic;
            for (int i = 0; i < iCount; i++)
                BoundingBoxes.Add(new BoundingBox(Cache, iOffset + 52 * i));
            #endregion

            #region NodeMapGroup Block
            Reader.SeekTo(Address + 176);
            iCount = Reader.ReadInt32();
            iOffset = Reader.ReadInt32() - Cache.Magic;
            for (int i = 0; i < iCount; i++) 
                NodeIndexGroups.Add(new NodeIndexGroup(Cache, iOffset + 12 * i));
            #endregion

            Reader.SeekTo(Address + 248);
            RawID = Reader.ReadInt32();
        }
    }
}

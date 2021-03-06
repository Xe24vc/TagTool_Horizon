﻿using BlamCore.Common;
using BlamCore.IO;
using mode = BlamCore.Cache.render_model;

namespace BlamCore.Cache.Halo4Beta
{
    public class render_model : ReachRetail.render_model
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
                Nodes.Add(new Node(Cache, iOffset + 112 * i));
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
            Reader.SeekTo(Address + 312);
            iCount = Reader.ReadInt32();
            iOffset = Reader.ReadInt32() - Cache.Magic;
            for (int i = 0; i < iCount; i++)
                ModelSections.Add(new ModelSection(Cache, iOffset + 112 * i));
            #endregion

            #region BoundingBox Block
            Reader.SeekTo(Address + 336);
            iCount = Reader.ReadInt32();
            iOffset = Reader.ReadInt32() - Cache.Magic;
            for (int i = 0; i < iCount; i++)
                BoundingBoxes.Add(new BoundingBox(Cache, iOffset + 52 * i));
            #endregion

            #region NodeMapGroup Block
            Reader.SeekTo(Address + 396);
            iCount = Reader.ReadInt32();
            iOffset = Reader.ReadInt32() - Cache.Magic;
            for (int i = 0; i < iCount; i++)
                NodeIndexGroups.Add(new NodeIndexGroup(Cache, iOffset + 12 * i));
            #endregion

            Reader.SeekTo(Address + 444);
            RawID = Reader.ReadInt32();
        }

        new public class Region : mode.Region
        {
            public Region(Base.CacheFile Cache, int Address)
            {
                EndianReader Reader = Cache.Reader;
                Reader.SeekTo(Address);

                Name = Cache.Strings.GetItemByID(Reader.ReadInt32());

                int iCount = Reader.ReadInt32();
                int iOffset = Reader.ReadInt32() - Cache.Magic;
                for (int i = 0; i < iCount; i++)
                    Permutations.Add(new Permutation(Cache, iOffset + 28 * i));
            }

            new public class Permutation : mode.Region.Permutation
            {
                public Permutation(Base.CacheFile Cache, int Address)
                {
                    EndianReader Reader = Cache.Reader;
                    Reader.SeekTo(Address);

                    Name = Cache.Strings.GetItemByID(Reader.ReadInt32());
                    PieceIndex = Reader.ReadInt16();
                    PieceCount = Reader.ReadInt16();
                }
            }
        }

        new public class Node : mode.Node
        {
            public Node(Base.CacheFile Cache, int Address)
            {
                EndianReader Reader = Cache.Reader;
                Reader.SeekTo(Address);

                Name = Cache.Strings.GetItemByID(Reader.ReadInt32());
                ParentIndex = Reader.ReadInt16();
                FirstChildIndex = Reader.ReadInt16();
                NextSiblingIndex = Reader.ReadInt16();
                Reader.ReadInt16();
                Position = new RealQuaternion(
                    Reader.ReadSingle(),
                    Reader.ReadSingle(),
                    Reader.ReadSingle());
                Rotation = new RealQuaternion(
                    Reader.ReadSingle(),
                    Reader.ReadSingle(),
                    Reader.ReadSingle(),
                    Reader.ReadSingle());

                TransformScale = Reader.ReadSingle();

                TransformMatrix = new RealMatrix4x3();

                TransformMatrix.m11 = Reader.ReadSingle();
                TransformMatrix.m12 = Reader.ReadSingle();
                TransformMatrix.m13 = Reader.ReadSingle();

                TransformMatrix.m21 = Reader.ReadSingle();
                TransformMatrix.m22 = Reader.ReadSingle();
                TransformMatrix.m23 = Reader.ReadSingle();

                TransformMatrix.m31 = Reader.ReadSingle();
                TransformMatrix.m32 = Reader.ReadSingle();
                TransformMatrix.m33 = Reader.ReadSingle();

                TransformMatrix.m41 = Reader.ReadSingle();
                TransformMatrix.m42 = Reader.ReadSingle();
                TransformMatrix.m43 = Reader.ReadSingle();

                DistanceFromParent = Reader.ReadSingle();
            }
        }

        new public class ModelSection : mode.ModelSection
        {
            public ModelSection(Base.CacheFile Cache, int Address)
            {
                EndianReader Reader = Cache.Reader;
                Reader.SeekTo(Address);

                #region Submesh Block
                int iCount = Reader.ReadInt32();
                int iOffset = Reader.ReadInt32() - Cache.Magic;
                for (int i = 0; i < iCount; i++)
                    Submeshes.Add(new Submesh(Cache, iOffset + 24 * i));
                #endregion

                #region Subset Block
                Reader.SeekTo(Address + 12);
                iCount = Reader.ReadInt32();
                iOffset = Reader.ReadInt32() - Cache.Magic;
                for (int i = 0; i < iCount; i++)
                    Subsets.Add(new Subset(Cache));
                #endregion

                #region Other
                Reader.SeekTo(Address + 24);
                VertsIndex = Reader.ReadInt16();

                Reader.SeekTo(Address + 42);
                FacesIndex = Reader.ReadInt16();

                Reader.SeekTo(Address + 47);
                TransparentNodesPerVertex = Reader.ReadByte();
                NodeIndex = Reader.ReadByte();
                VertexFormat = Reader.ReadByte();
                OpaqueNodesPerVertex = Reader.ReadByte();
                #endregion
            }

            new public class Submesh : mode.ModelSection.Submesh
            {
                public Submesh(Base.CacheFile Cache, int Address)
                {
                    EndianReader Reader = Cache.Reader;
                    Reader.SeekTo(Address);

                    ShaderIndex = Reader.ReadInt16();
                    Reader.ReadInt16();
                    FaceIndex = Reader.ReadInt32();
                    FaceCount = Reader.ReadInt32();
                    SubsetIndex = Reader.ReadUInt16();
                    SubsetCount = Reader.ReadUInt16();
                    Reader.ReadInt16();
                    Reader.ReadInt16();
                    VertexCount = Reader.ReadUInt16();
                    Reader.ReadInt16();
                }
            }

            new public class Subset : mode.ModelSection.Subset
            {
                public Subset(Base.CacheFile Cache)
                {
                    EndianReader Reader = Cache.Reader;

                    FaceIndex = Reader.ReadInt32();
                    FaceCount = Reader.ReadInt32();
                    SubmeshIndex = Reader.ReadUInt16();
                    VertexCount = Reader.ReadUInt16();
                    Reader.ReadSingle();
                }
            }
        }
    }
}

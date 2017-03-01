using System.Collections.Generic;
using BlamCore.Common;
using BlamCore.Geometry;
using BlamCore.Serialization;
using BlamCore.Cache.HaloOnline;

namespace BlamCore.TagResources
{
    [TagStructure(Name = "structure_bsp_tag_resources", Size = 0x30)]
    public class StructureBspTagResources
    {
        public List<CollisionBSPGeometry> CollisionBsps;
        [MinVersion(Cache.CacheVersion.Halo3ODST)]
        public List<CollisionBSPGeometry> LargeCollisionBsps;
        public List<Compression> Compressions;
        [MinVersion(Cache.CacheVersion.Halo3ODST)]
        public List<HavokDatum> HavokData;

        [TagStructure(Size = 0xC8)]
        public class Compression
        {
            public float X;
            public float Y;
            public float Z;
            public float W;
            public float R;
            public ResourceBlockReference<CollisionBSPGeometry.Bsp3dNode> Bsp3dNodes;
            public ResourceBlockReference<CollisionBSPGeometry.Plane> Planes;
            public ResourceBlockReference<CollisionBSPGeometry.Leaf> Leaves;
            public ResourceBlockReference<CollisionBSPGeometry.Bsp2dReference> Bsp2dReferences;
            public ResourceBlockReference<CollisionBSPGeometry.Bsp2dNode> Bsp2dNodes;
            public ResourceBlockReference<CollisionBSPGeometry.Surface> Surfaces;
            public ResourceBlockReference<CollisionBSPGeometry.Edge> Edges;
            public ResourceBlockReference<CollisionBSPGeometry.Vertex> Vertices;
            public List<CollisionBSPGeometry> CollisionBsps;
            public List<CollisionMoppCode2> CollisionMoppCodes;
            public ResourceBlockReference<Unknown1Block> Unknown1;
            public ResourceBlockReference<Unknown2Block> Unknown2;
            public ResourceBlockReference<Unknown3Block> Unknown3;
            public short Index01;
            public short Index02;
            [MinVersion(Cache.CacheVersion.Halo3ODST)]
            public float Unknown4; // assuming float because I see the value 0x3f800000 for this a lot which is 1.0f
            [MinVersion(Cache.CacheVersion.Halo3ODST)]
            public ResourceBlockReference<Unknown4Block> Unknown5;

            [TagStructure]
            public class Unknown1Block
            {
                public uint Unknown;
            }

            [TagStructure]
            public class Unknown2Block
            {
                public uint Unknown;
                public uint Unknown2;
            }

            [TagStructure]
            public class Unknown3Block
            {
                public uint Unknown;
            }

            [TagStructure]
            public class Unknown4Block
            {
                public uint Unknown;
            }
        }

        [TagStructure]
        public class HavokDatum
        {
            public int PrefabIndex;
            public List<HavokGeometry> HavokGeometries;
            public List<HavokGeometry> HavokInvertedGeometries;
            public RealPoint3d ShapesBoundsMinimum;
            public RealPoint3d ShapesBoundsMaximum;

            [TagStructure]
            public class HavokGeometry
            {
                [TagField(Padding = true, Length = 4)]
                public byte[] Unused;
                public int CollisionType;
                public int ShapeCount;
                public byte[] Data;
            }
        }

        // This is dumb and shouldn't be necessary but the ResourceBlockReferences makes any tag that relies on this block unserializable
        [TagStructure(Size = 0x40)]
        public class CollisionMoppCode2
        {
            public int Unused1;
            public short Size;
            public short Count;
            public int Address;
            public int Unused2;
            public RealVector4d Offset;
            public int Unused3;
            public int DataSize;
            public int DataCapacityAndFlags;
            public sbyte DataBuildType;
            public sbyte Unused4;
            public short Unused5;
            public ResourceBlockReference<byte> Data;
            public sbyte MoppBuildType;
            public byte Unused6;
            public short Unused7;
        }
    }
}
using System;
using System.Collections.Generic;
using BlamCore.Cache.HaloOnline;
using BlamCore.Common;
using BlamCore.Serialization;

namespace BlamCore.Geometry
{
    [Flags]
    public enum RenderGeometryRuntimeFlags : int
    {
        None = 0,
        Processed = 1 << 0,
        Available = 1 << 1,
        HasValidBudgets = 1 << 2,
        ManualResourceCalibration = 1 << 3,
        KeepRawGeometry = 1 << 4,
        DoNotUseCompressedVertexPositions = 1 << 5,
        PcaAnimationTableSorted = 1 << 6,
        HasDualQuat = 1 << 7
    }

    [TagStructure(Name = "render_geometry", Size = 0x84)]
    public class RenderGeometry
    {
        /// <summary>
        /// The runtime flags of the render geometry.
        /// </summary>
        public RenderGeometryRuntimeFlags RuntimeFlags;

        /// <summary>
        /// The meshes of the render geometry.
        /// </summary>
        public List<Mesh> Meshes;

        /// <summary>
        /// The compression information of the render geometry.
        /// </summary>
        public List<GeometryCompressionInfo> Compression;

        public List<BoundingSphere> BoundingSpheres;
        public List<UnknownBlock> Unknown2;
        public uint Unknown3;
        public uint Unknown4;
        public uint Unknown5;
        public List<UnknownSection> UnknownSections;
        public List<NodeMap> NodeMaps;
        public List<UnknownBlock2> Unknown6;
        public uint Unknown7;
        public uint Unknown8;
        public uint Unknown9;
        public List<UnknownYoBlock> UnknownYo;

        /// <summary>
        /// The resource containing the raw geometry data.
        /// </summary>
        [MinVersion(Cache.CacheVersion.HaloOnline106708)]
        public ResourceReference Resource;
        [MaxVersion(Cache.CacheVersion.Halo3ODST)]
        public ushort ZoneAssetSalt;
        [MaxVersion(Cache.CacheVersion.Halo3ODST)]
        public ushort ZoneAssetIndex;

        public int Padding;

        [TagStructure(Size = 0x30)]
        public class BoundingSphere
        {
            public RealPlane3d Plane;
            public RealPoint3d Position;
            public float Radius;
            [TagField(Count = 4)]
            public sbyte[] NodeIndices;
            [TagField(Count = 3)]
            public float[] NodeWeights;
        }

        [TagStructure(Size = 0x18)]
        public class UnknownBlock
        {
            public short Unknown;
            public short Unknown2;
            public byte[] Unknown3;
        }

        [TagStructure(Size = 0x20)]
        public class UnknownSection
        {
            [TagField(DataAlign = 0x10)] public byte[] Unknown;
            public List<short> Unknown2;
        }

        [TagStructure(Size = 0xC)]
        public class NodeMap
        {
            public List<byte> Nodes;
        }

        [TagStructure(Size = 0xC)]
        public class UnknownBlock2
        {
            public List<UnknownBlock> Unknown;

            [TagStructure(Size = 0x30)]
            public class UnknownBlock
            {
                public uint Unknown;
                public uint Unknown2;
                public uint Unknown3;
                public uint Unknown4;
                public uint Unknown5;
                public uint Unknown6;
                public uint Unknown7;
                public uint Unknown8;
                public uint Unknown9;
                public uint Unknown10;
                public uint Unknown11;
                public uint Unknown12;
            }
        }

        [TagStructure(Size = 0x10)]
        public class UnknownYoBlock
        {
            public uint Unknown;
            public uint Unknown2;
            public uint Unknown3;
            public short UnknownIndex;
            public short Unknown4;
        }
    }

    [Flags]
    public enum GeometryCompressionFlags : ushort
    {
        None = 0,
        CompressedPosition = 1 << 0,
        CompressedTexcoord = 1 << 1,
        CompressionOptimized = 1 << 2
    }

    /// <summary>
    /// Contains information about how geometry is compressed.
    /// </summary>
    [TagStructure(Size = 0x2C)]
    public class GeometryCompressionInfo
    {
        /// <summary>
        /// The flags of the geometry compression.
        /// </summary>
        public GeometryCompressionFlags Flags;

        [TagField(Padding = true, Length = 0x2)]
        public byte[] Padding;

        /// <summary>
        /// The minimum X value in the uncompressed geometry.
        /// </summary>
        public Bounds<float> X;

        /// <summary>
        /// The minimum Y value in the uncompressed geometry.
        /// </summary>
        public Bounds<float> Y;

        /// <summary>
        /// The minimum Z value in the uncompressed geometry.
        /// </summary>
        public Bounds<float> Z;

        /// <summary>
        /// The minimum U value in the uncompressed geometry.
        /// </summary>
        public Bounds<float> U;

        /// <summary>
        /// The minimum V value in the uncompressed geometry.
        /// </summary>
        public Bounds<float> V;
    }
}

using System;
using BlamCore.Cache;
using BlamCore.Common;
using BlamCore.Serialization;
using BlamCore.Cache.HaloOnline;

namespace BlamCore.Geometry
{
    // TODO: figure out a good way to merge this into CollisionGeometry
    // this is exclusively for collision BSP resource
    [TagStructure(Size = 0x5C)]
    public class CollisionBSPGeometry
    {
        public ResourceBlockReference<Bsp3dNode> Bsp3dNodes;
        public ResourceBlockReference<Plane> Planes;
        public ResourceBlockReference<Leaf> Leaves;
        public ResourceBlockReference<Bsp2dReference> Bsp2dReferences;
        public ResourceBlockReference<Bsp2dNode> Bsp2dNodes;
        public ResourceBlockReference<Surface> Surfaces;
        public ResourceBlockReference<Edge> Edges;
        public ResourceBlockReference<Vertex> Vertices;

        [TagStructure(Size = 0x8)]
        public class Bsp3dNode
        {
            [MinVersion(CacheVersion.HaloOnline106708)]
            public short Plane;
            [MinVersion(CacheVersion.HaloOnline106708)]
            public byte FrontChildLower;
            [MinVersion(CacheVersion.HaloOnline106708)]
            public byte FrontChildMid;
            [MinVersion(CacheVersion.HaloOnline106708)]
            public byte FrontChildUpper;
            [MinVersion(CacheVersion.HaloOnline106708)]
            public byte BackChildLower;
            [MinVersion(CacheVersion.HaloOnline106708)]
            public byte BackChildMid;
            [MinVersion(CacheVersion.HaloOnline106708)]
            public byte BackChildUpper;

            [MaxVersion(CacheVersion.Halo3ODST)]
            public byte BackChildUpper_H3;
            [MaxVersion(CacheVersion.Halo3ODST)]
            public byte BackChildMid_H3;
            [MaxVersion(CacheVersion.Halo3ODST)]
            public byte BackChildLower_H3;
            [MaxVersion(CacheVersion.Halo3ODST)]
            public byte FrontChildUpper_H3;
            [MaxVersion(CacheVersion.Halo3ODST)]
            public byte FrontChildMid_H3;
            [MaxVersion(CacheVersion.Halo3ODST)]
            public byte FrontChildLower_H3;
            [MaxVersion(CacheVersion.Halo3ODST)]
            public short Plane_H3;
        }

        [TagStructure(Size = 0x10)]
        public class Plane
        {
            public float PlaneI;
            public float PlaneJ;
            public float PlaneK;
            public float PlaneD;
        }

        [Flags]
        public enum LeafFlags : ushort
        {
            None = 0,
            ContainsDoubleSidedSurfaces = 1 << 0
        }

        [TagStructure(Size = 0x8)]
        public class Leaf
        {
            public LeafFlags Flags;
            public short Bsp2dReferenceCount;
            public int FirstBsp2dReference;
        }

        [TagStructure(Size = 0x4)]
        public class Bsp2dReference
        {
            public short PlaneIndex;
            public short Bsp2dNodeIndex;
        }

        [TagStructure(Size = 0x10)]
        public class Bsp2dNode
        {
            public float PlaneI;
            public float PlaneJ;
            public float PlaneD;
            public short LeftChild;
            public short RightChild;
        }

        [Flags]
        public enum SurfaceFlags : byte
        {
            None = 0,
            TwoSided = 1 << 0,
            Invisible = 1 << 1,
            Climbable = 1 << 2,
            Invalid = 1 << 3,
            Conveyor = 1 << 4,
            Slip = 1 << 5,
            PlaneNegated = 1 << 6
        }

        [TagStructure(Size = 0xC)]
        public class Surface
        {
            public short Plane;
            public short FirstEdge;
            public short Material;
            public short Unknown;
            public short BreakableSurface;
            public SurfaceFlags Flags;
            public byte BestPlaneCalculationVertex;
        }

        [TagStructure(Size = 0xC)]
        public class Edge
        {
            public short StartVertex;
            public short EndVertex;
            public short ForwardEdge;
            public short ReverseEdge;
            public short LeftSurface;
            public short RightSurface;
        }

        [TagStructure(Size = 0x10)]
        public class Vertex
        {
            public RealPoint3d Point;
            public short FirstEdge;
            public short Sink;
        }
    }
}

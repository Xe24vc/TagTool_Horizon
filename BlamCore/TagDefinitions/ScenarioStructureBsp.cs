using System.Collections.Generic;
using BlamCore.Common;
using BlamCore.Cache.HaloOnline;
using BlamCore.Geometry;
using BlamCore.Serialization;
using System;
using BlamCore.Cache;

namespace BlamCore.TagDefinitions
{
    [TagStructure(Name = "scenario_structure_bsp", Class = "sbsp", Size = 0x388, MaxVersion = CacheVersion.Halo3Retail)]
    [TagStructure(Name = "scenario_structure_bsp", Class = "sbsp", Size = 0x3AC, MaxVersion = CacheVersion.HaloOnline106708)]
    [TagStructure(Name = "scenario_structure_bsp", Class = "sbsp", Size = 0x3A8, MaxVersion = CacheVersion.HaloOnline235640)]
    [TagStructure(Name = "scenario_structure_bsp", Class = "sbsp", Size = 0x3AC, MaxVersion = CacheVersion.HaloOnline449175)]
    [TagStructure(Name = "scenario_structure_bsp", Class = "sbsp", Size = 0x3B8, MinVersion = CacheVersion.HaloOnline498295)]
    public class ScenarioStructureBsp
    {
        public int BspChecksum;
        public int Unknown1;
        public uint Unknown2;

        [MinVersion(CacheVersion.Halo3ODST)]
        public uint Unknown3;

        [MaxVersion(CacheVersion.Halo3ODST)]
        public List<StructureSeam> StructureSeams;
        [MinVersion(CacheVersion.HaloOnline106708)]
        [TagField(Padding = true, Length = 0xC)]
        public byte[] StructureSeamsUnused;

        [MaxVersion(CacheVersion.Halo3Retail)]
        public List<UnknownRaw7th> UnknownRaw7ths;
        [MinVersion(CacheVersion.Halo3ODST)]
        [TagField(Padding = true, Length = 0xC)]
        public byte[] UnknownRaw7thsUnused;

        public List<CollisionMaterial> CollisionMaterials;

        public List<byte> UnknownRaw3rd;

        public Bounds<float> WorldBoundsX;
        public Bounds<float> WorldBoundsY;
        public Bounds<float> WorldBoundsZ;

        [MaxVersion(CacheVersion.Halo3Retail)]
        public List<UnknownRaw6th> UnknownRaw6ths;
        [MinVersion(CacheVersion.Halo3ODST)]
        [TagField(Padding = true, Length = 0xC)]
        public byte[] UnknownRaw6thsUnused;

        [MaxVersion(CacheVersion.Halo3Retail)]
        public List<UnknownRaw1st> UnknownRaw1sts;
        [MinVersion(CacheVersion.Halo3ODST)]
        [TagField(Padding = true, Length = 0xC)]
        public byte[] UnknownRaw1stsUnused;

        [MinVersion(CacheVersion.HaloOnline106708)]
        [TagField(Padding = true, Length = 0xC)]
        public byte[] UnknownUnused;

        public List<ClusterPortal> ClusterPortals;
        public List<UnknownBlock> Unknown19;
        public List<FogBlock> Fog;
        public List<CameraEffect> CameraEffects;
        public uint Unknown20;
        public uint Unknown21;
        public uint Unknown22;
        public List<DetailObject> DetailObjects;
        public List<Cluster2> Clusters;
        public List<RenderMaterial> Materials;
        public List<short> SkyOwnerCluster;
        [MaxVersion(CacheVersion.Halo3Retail)]
        public List<ConveyorSurface> ConveyorSurfaces;
        [MaxVersion(CacheVersion.Halo3Retail)]
        public List<BreakableSurfaces> BreakableSurface;
        [MaxVersion(CacheVersion.Halo3Retail)]
        public List<PathfindingData> pathfindingdata;
        public uint Unknown23;
        public uint Unknown24;
        public uint Unknown25;
        [MinVersion(CacheVersion.HaloOnline106708)]
        public uint Unknown26;
        [MinVersion(CacheVersion.HaloOnline106708)]
        public uint Unknown27;
        [MinVersion(CacheVersion.HaloOnline106708)]
        public uint Unknown28;
        [MinVersion(CacheVersion.HaloOnline106708)]
        public uint Unknown29;
        [MinVersion(CacheVersion.HaloOnline106708)]
        public uint Unknown30;
        [MinVersion(CacheVersion.HaloOnline106708)]
        public uint Unknown31;
        [MinVersion(CacheVersion.HaloOnline106708)]
        public uint Unknown32;
        [MinVersion(CacheVersion.HaloOnline106708)]
        public uint Unknown33;
        [MinVersion(CacheVersion.HaloOnline106708)]
        public uint Unknown34;
        public List<BackgroundSoundEnvironmentPaletteBlock> BackgroundSoundEnvironmentPalette;
        public uint Unknown35;
        public uint Unknown36;
        public uint Unknown37;
        public uint Unknown38;
        public uint Unknown39;
        public uint Unknown40;
        public uint Unknown41;
        public uint Unknown42;
        public uint Unknown43;
        public uint Unknown44;
        public uint Unknown45;
        public List<Marker> Markers;
        public List<Light> Lights;
        public List<UnknownBlock2> Unknown46;
        public List<RuntimeDecal> RuntimeDecals;
        public List<EnvironmentObjectPaletteBlock> EnvironmentObjectPalette;
        public List<EnvironmentObject> EnvironmentObjects;
        public uint Unknown47;
        public uint Unknown48;
        public uint Unknown49;
        public uint Unknown50;
        public uint Unknown51;
        public uint Unknown52;
        public uint Unknown53;
        public uint Unknown54;
        public uint Unknown55;
        public uint Unknown56;
        public List<InstancedGeometryInstance> InstancedGeometryInstances;
        public List<Decorator> Decorators;
        public RenderGeometry Geometry;
        public List<UnknownSoundClusterBlock> UnknownSoundClustersA;
        public List<UnknownSoundClusterBlock> UnknownSoundClustersB;
        public List<UnknownSoundClusterBlock> UnknownSoundClustersC;
        public List<TransparentPlane> TransparentPlanes;
        public uint Unknown66;
        public uint Unknown67;
        public uint Unknown68;
        public List<CollisionMoppCode> CollisionMoppCodes;
        public uint Unknown69;
        public Bounds<float> CollisionWorldBoundsX;
        public Bounds<float> CollisionWorldBoundsY;
        public Bounds<float> CollisionWorldBoundsZ;
        public List<BreakableSurfaceMoppCode> BreakableSurfaceMoppCodes;
        public List<BreakableSurfaceKeyTableBlock> BreakableSurfaceKeyTable;
        public uint Unknown70;
        public uint Unknown71;
        public uint Unknown72;
        public uint Unknown73;
        public uint Unknown74;
        public uint Unknown75;
        public RenderGeometry Geometry2;
        public List<LeafSystem> LeafSystems;
        public uint Unknown88;
        public uint Unknown89;
        public uint Unknown90;
        [MinVersion(CacheVersion.HaloOnline106708)]
        public ResourceReference CollisionBspResource;
        [MaxVersion(CacheVersion.Halo3Retail)]
        public ushort ZoneAssetSalt3;
        [MaxVersion(CacheVersion.Halo3Retail)]
        public ushort ZoneAssetIndex3;
        public int UselessPadding3;
        [MinVersion(CacheVersion.HaloOnline106708)]
        public ResourceReference Resource4;
        public int Unknown91;
        [MinVersion(CacheVersion.HaloOnline106708)]
        public uint Unknown92;
        [MinVersion(CacheVersion.HaloOnline106708)]
        public uint Unknown93;
        [MinVersion(CacheVersion.HaloOnline106708)]
        [MaxVersion(CacheVersion.HaloOnline106708)]
        public uint Unknown94;
        [MinVersion(CacheVersion.HaloOnline301003)]
        [MaxVersion(CacheVersion.HaloOnline700123)]
        public uint Unknown98;

        [TagStructure(Size = 0x28)]
        public class StructureSeam
        {
            [TagField(Count = 4)]
            public int[] SeamIdentifiers;

            public List<EdgeMapping> EdgeMappings;
            public List<ClusterMapping> ClusterMappings;

            [TagStructure(Size = 0x4)]
            public class EdgeMapping
            {
                public int StructureEdgeIndex;
            }

            [TagStructure(Size = 0x10)]
            public class ClusterMapping
            {
                public int ClusterIndex;
                public RealPoint3d ClusterCenter;
            }
        }

        [Flags]
        public enum CollisionMaterialFlags : ushort
        {
            None,
            IsSeam = 1 << 0
        }

        [TagStructure(Size = 0x18)]
        public class CollisionMaterial
        {
            public CachedTagInstance RenderMethod;
            public short RuntimeGlobalMaterialIndex;
            public short ConveyorSurfaceIndex;
            public short SeamMappingIndex;
            public CollisionMaterialFlags Flags;
        }

        [Flags]
        public enum ClusterPortalFlags : int
        {
            None = 0,
            AiCantHearThroughThisShit = 1 << 0,
            OneWay = 1 << 1,
            Door = 1 << 2,
            NoWay = 1 << 3,
            OneWayReversed = 1 << 4,
            NoOneCanHearThroughThis = 1 << 5
        }

        [TagStructure(Size = 0x28)]
        public class ClusterPortal
        {
            public short BackCluster;
            public short FrontCluster;
            public int PlaneIndex;
            public RealPoint3d Centroid;
            public float BoundingRadius;
            public ClusterPortalFlags Flags;
            public List<RealPoint3d> Vertices;
        }

        [TagStructure(Size = 0x78)]
        public class UnknownBlock
        {
            public uint Unknown1;
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
            public uint Unknown13;
            public uint Unknown14;
            public uint Unknown15;
            public uint Unknown16;
            public uint Unknown17;
            public uint Unknown18;
            public uint Unknown19;
            public uint Unknown20;
            public uint Unknown21;
            public uint Unknown22;
            public uint Unknown23;
            public uint Unknown24;
            public uint Unknown25;
            public uint Unknown26;
            public uint Unknown27;
            public uint Unknown28;
            public uint Unknown29;
            public uint Unknown30;
        }

        [TagStructure(Size = 0x8)]
        public class FogBlock
        {
            public StringId Name;
            public short Unknown;
            public short Unknown2;
        }

        [TagStructure(Size = 0x20)]
        public class UnknownMesh
        {
            public byte[] dataref;
            public List<short> unk;
        }

        [TagStructure(Size = 0x4)]
        public class UnknownRaw6th
        {
            public short Unknown1StartIndex;
            public short Unknown1EntryCount;
        }

        [TagStructure(Size = 0x18)]
        public class ConveyorSurface
        {
            public uint ui;
            public uint uj;
            public uint uk;
            public uint vi;
            public uint vj;
            public uint vk;
        }

        [TagStructure(Size = 0xc)]
        public class NodeMap
        {
            public List<byte> NodeIndex;
        }

        [TagStructure(Size = 0x10)]
        public class UnknownYo
        {
            public uint unk1;
            public uint unk2;
            public uint unk3;
            public short unk4;
            public short unk5;
        }

        [TagStructure(Size = 0xc)]
        public class Unknown0xC
        {
            public List<Unknown> UnknownBlock;

            [TagStructure(Size = 0x30)]
            public class Unknown
            {
                public uint unk1;
                public uint unk2;
                public uint unk3;
                public uint unk4;
                public uint unk5;
                public uint unk6;
                public uint unk7;
                public uint unk8;
                public uint unk9;
                public uint unk10;
                public uint unk11;
                public uint unk12;

            }
        }


        [TagStructure(Size = 0x30)]
        public class UnknownNodey
        {
            public float unk1;
            public float unk2;
            public float unk3;
            public float unk4;
            public float unk5;
            public float unk6;
            public float unk7;
            public float unk8;
            public byte NodeIndex1;
            public byte NodeIndex2;
            public byte NodeIndex3;
            public byte NodeIndex4;
            public float unk9;
            public float unk10;
            public float unk11;
        }

        [TagStructure(Size = 0x18)]
        public class Unknown0x18
        {
            public short unk1;
            public short unk2;
            public byte[] dataref;
        }

        [TagStructure(Size = 0x20)]
        public class BreakableSurfaces
        {
            public uint unk1;
            public uint unk2;
            public uint unk3;
            public uint unk4;
            public uint unk5;
            public uint unk6;
            public uint unk7;
            public uint unk8;
        }

        [TagStructure(Size = 0xA0)]
        public class PathfindingData
        {
			// todo: update dis
            public byte[] placeholder;
        }

        [TagStructure(Size = 0x4)]
        public class UnknownRaw1st
        {
            public ushort Unknown;
            public short Unknown2;
        }

        [TagStructure(Size = 0x30)]
        public class CameraEffect
        {
            public StringId Name;
            public CachedTagInstance Effect;
            public sbyte Unknown;
            public sbyte Unknown2;
            public sbyte Unknown3;
            public sbyte Unknown4;
            public uint Unknown5;
            public uint Unknown6;
            public uint Unknown7;
            public uint Unknown8;
            public uint Unknown9;
            public uint Unknown10;
        }

        [TagStructure(Size = 0x34)]
        public class DetailObject
        {
            public uint Unknown;
            public uint Unknown2;
            public uint Unknown3;
            public uint Unknown4;
            public uint Unknown5;
            public uint Unknown6;
            public uint Unknown7;
            [MinVersion(CacheVersion.HaloOnline106708)] public List<UnknownBlock> Unknown8;
            public uint Unknown9;
            public uint Unknown10;
            public uint Unknown11;

            [TagStructure(Size = 0x20)]
            public class UnknownBlock
            {
                public List<UnknownBlock2> Unknown1;
                public byte[] Unknown2;

                [TagStructure(Size = 0x10)]
                public class UnknownBlock2
                {
                    public uint Unknown;
                    public uint Unknown2;
                    public uint Unknown3;
                    public uint Unknown4;
                }
            }
        }

        [TagStructure(Size = 0xDC, MaxVersion = CacheVersion.HaloOnline449175)]
        [TagStructure(Size = 0xE0, MinVersion = CacheVersion.HaloOnline498295)]
        public class Cluster2
        {
            public Bounds<float> BoundsX;
            public Bounds<float> BoundsY;
            public Bounds<float> BoundsZ;
            public sbyte Unknown;
            public sbyte ScenarioSkyIndex;
            public sbyte CameraEffectIndex;
            public sbyte Unknown2;
            public short BackgroundSoundEnvironmentIndex;
            public short SoundClustersAIndex;
            public short Unknown3;
            public short Unknown4;
            public short Unknown5;
            public short Unknown6;
            public short Unknown7;
            [MinVersion(CacheVersion.HaloOnline498295)] public short Unknown26;
            [MinVersion(CacheVersion.HaloOnline498295)] public short Unknown27;
            public short RuntimeDecalStartIndex;
            public short RuntimeDecalEntryCount;
            public short Flags;
            public uint Unknown8;
            public uint Unknown9;
            public uint Unknown10;
            public List<short> Portals;
            public int Unknown11;
            public short Size;
            public short Count;
            public int Address;
            public int Unknown12;
            public uint Unknown13;
            public uint Unknown14;
            public CachedTagInstance Bsp;
            public int ClusterIndex;
            public int Unknown15;
            public short Size2;
            public short Count2;
            public int Address2;
            public int Unknown16;
            public uint Unknown17;
            public uint Unknown18;
            public uint Unknown19;
            public List<CollisionMoppCode> CollisionMoppCodes;
            public short MeshIndex;
            public short Unknown20;
            public List<byte> Seams;
            public List<DecoratorGrid> DecoratorGrids;
            public uint Unknown21;
            public uint Unknown22;
            public uint Unknown23;
            public List<UnknownBlock> Unknown24;
            public List<UnknownBlock2> Unknown25;
            
            [TagStructure(Size = 0x34)]
            public class DecoratorGrid
            {
                public short Amount;
                public sbyte DecoratorIndex;
                public sbyte DecoratorIndexScattering;
                public int Unknown;
                public RealPoint3d Position;
                public float Radius;
                public RealPoint3d GridSize;
                public RealPoint3d BoundingSphereOffset;
                public uint Unknown2;
            }
            
            [TagStructure(Size = 0x4)]
            public class UnknownBlock
            {
                public short Unknown;
                public short Unknown2;
            }

            [TagStructure(Size = 0x10, Align = 0x10)]
            public class UnknownBlock2
            {
                public uint Unknown;
                public uint Unknown2;
                public uint Unknown3;
                public short Unknown4;
                public short Unknown5;
            }
        }

        [TagStructure(Size = 0x58, MaxVersion = CacheVersion.HaloOnline106708)]
        [TagStructure(Size = 0x54, MaxVersion = CacheVersion.Halo3Retail)]
        public class BackgroundSoundEnvironmentPaletteBlock
        {
            public StringId Name;
            public CachedTagInstance SoundEnvironment;
            [MinVersion(CacheVersion.HaloOnline106708)]
            public uint Unknown;
            public float CutoffDistance;
            public float InterpolationSpeed;
            public CachedTagInstance BackgroundSound;
            public CachedTagInstance InsideClusterSound;
            public float CutoffDistance2;
            public uint ScaleFlags;
            public float InteriorScale;
            public float PortalScale;
            public float ExteriorScale;
            public float InterpolationSpeed2;
        }

        [TagStructure(Size = 0x4)]
        public class UnknownRaw7th
        {
            public short unk1;
            public short unk2;
        }

        [TagStructure(Size = 0x3C)]
        public class Marker
        {
            [TagField(Length = 32)] public string Name;
            public RealQuaternion Rotation;
            public RealPoint3d Position;
        }

        [TagStructure(Size = 0x10)]
        public class Light
        {
            public CachedTagInstance Reference;
        }

        [TagStructure(Size = 0x2)]
        public class UnknownBlock2
        {
            public short Unknown;
        }

        [TagStructure(Size = 0x24)]
        public class RuntimeDecal
        {
            public short PaletteIndex;
            public sbyte Yaw;
            public sbyte Pitch;
            public RealQuaternion Rotation;
            public RealPoint3d Position;
            public float Scale;
        }

        [TagStructure(Size = 0x24)]
        public class EnvironmentObjectPaletteBlock
        {
            public CachedTagInstance Definition;
            public CachedTagInstance Model;
            public uint ObjectType;
        }

        [TagStructure(Size = 0x6C)]
        public class EnvironmentObject
        {
            [TagField(Length = 32)] public string Name;
            public RealQuaternion Rotation;
            public RealPoint3d Position;
            public float Scale;
            public short PaletteIndex;
            public short Unknown;
            public int UniqueId;
            [TagField(Length = 32)] public string ScenarioObjectName;
            public uint Unknown2;
        }

        [TagStructure(Size = 0x74, MinVersion = CacheVersion.HaloOnline106708)]
        [TagStructure(Size = 0x78, MaxVersion = CacheVersion.Halo3Retail)]
        public class InstancedGeometryInstance
        {
            public float Scale;
            public RealMatrix4x3 Matrix;
            public short MeshIndex;
            public ushort Flags;
            public short UnknownYoIndex;
            public short Unknown;
            public uint Unknown2;
            public RealPoint3d BoundingSphereOffset;
            public float BoundingSphereRadius1;
            public float BoundingSphereRadius2;
            public StringId Name;
            public short PathfindingPolicy;
            public short LightmappingPolicy;
            public uint Unknown3;
            public List<CollisionDefinition> CollisionDefinitions;
            public short Unknown4;
            public short Unknown5;
            public short Unknown6;
            public short Unknown7;
            [MaxVersion(CacheVersion.Halo3Retail)]
            public uint unknown8;

            [TagStructure(Size = 0x80, MinVersion = CacheVersion.HaloOnline106708)]
            [TagStructure(Size = 0x70, MaxVersion = CacheVersion.Halo3Retail)]
            public class CollisionDefinition
            {
                public int Unknown;
                public short Size;
                public short Count;
                public int Address;
                public int Unknown2;
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
                public uint Unknown13;
                public uint Unknown14;
                public int Unknown15;
                public uint Unknown16;
                [MinVersion(CacheVersion.HaloOnline106708)]
                public uint UnknownPossiblyNewValue;
                public sbyte BspIndex;
                public sbyte Unknown17;
                public short InstancedGeometryIndex;
                public uint Unknown18;
                [MinVersion(CacheVersion.HaloOnline106708)]
                public uint Unknown19;
                [MinVersion(CacheVersion.HaloOnline106708)]
                public uint Unknown20;
                [MinVersion(CacheVersion.HaloOnline106708)]
                public uint Unknown21;
                public uint Unknown22;
                public short Size2;
                public short Count2;
                public int Address2;
                public int Unknown23;
                public uint Unknown24;
                public uint Unknown25;
                public uint Unknown26;
                public uint Unknown27;
            }
        }

        [TagStructure(Size = 0x10)]
        public class Decorator
        {
            public CachedTagInstance Reference;
        }

        [TagStructure(Size = 0x1C)]
        public class UnknownSoundClusterBlock
        {
            public short BackgroundSoundEnvironmentIndex;
            public short Unknown;
            public List<short> PortalDesignators;
            public List<short> InteriorClusterIndices;
        }
        
        [TagStructure(Size = 0x14)]
        public class TransparentPlane
        {
            public short MeshIndex;
            public short PartIndex;
            public RealVector4d Plane;
        }

        [TagStructure(Size = 0x40, Align = 0x10)]
        public class CollisionMoppCode
        {
            public int Unknown;
            public short Size;
            public short Count;
            public int Address;
            public uint Unknown2;
            public RealPoint3d Offset;
            public float OffsetScale;
            public uint Unknown3;
            public int DataSize;
            public uint DataCapacity;
            public sbyte Unknown4;
            public sbyte Unknown5;
            public sbyte Unknown6;
            public sbyte Unknown7;
            public List<byte> Data;
            public uint Unknown8;
        }

        [TagStructure(Size = 0x40, Align = 0x10)]
        public class BreakableSurfaceMoppCode
        {
            public int Unknown;
            public short Size;
            public short Count;
            public int Address;
            public uint Unknown2;
            public RealPoint3d Offset;
            public float OffsetScale;
            public uint Unknown3;
            public int DataSize;
            public uint DataCapacity;
            public sbyte Unknown4;
            public sbyte Unknown5;
            public sbyte Unknown6;
            public sbyte Unknown7;
            public List<byte> Data;
            public uint Unknown8;
        }

        [TagStructure(Size = 0x20)]
        public class BreakableSurfaceKeyTableBlock
        {
            public short InstancedGeometryIndex;
            public sbyte BreakableSurfaceIndex;
            public byte BreakableSurfaceSubIndex;
            public int SeedSurfaceIndex;
            public Bounds<float> X;
            public Bounds<float> Y;
            public Bounds<float> Z;
        }

        [TagStructure(Size = 0x20)]
        public class LeafSystem
        {
            public short Unknown;
            public short Unknown2;
            public CachedTagInstance Reference;
            public uint Unknown3;
            public uint Unknown4;
            public uint Unknown5;
        }
    }
}

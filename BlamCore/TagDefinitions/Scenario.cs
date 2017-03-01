using System.Collections.Generic;
using BlamCore.Common;
using BlamCore.Cache.HaloOnline;
using BlamCore.Serialization;
using BlamCore.Cache;
using BlamCore.Scripting;
using System;

namespace BlamCore.TagDefinitions
{
    [TagStructure(Name = "scenario", Class = "scnr", Size = 0x824, MaxVersion = CacheVersion.HaloOnline449175)]
    [TagStructure(Name = "scenario", Class = "scnr", Size = 0x834, MinVersion = CacheVersion.HaloOnline498295)]
    public class Scenario
    {
        public ScenarioMapType MapType;
        public ScenarioFlags Flags;
        public int CampaignId;
        public int MapId;
        public Angle LocalNorth;
        public float SandboxBudget;
        public List<StructureBsp> StructureBsps;
        public CachedTagInstance Unknown2;
        public List<SkyReference> SkyReferences;
        public List<ZoneSetPotentiallyVisibleSet> ZoneSetPotentiallyVisibleSets;
        public List<ZoneSetAudibilityBlock> ZoneSetAudibility;
        public List<ZoneSet> ZoneSets;
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
        public List<ObjectName> ObjectNames;
        public List<SceneryBlock> Scenery;
        public List<SceneryPaletteBlock> SceneryPalette;
        public List<Biped> Bipeds;
        public List<BipedPaletteBlock> BipedPalette;
        public List<Vehicle> Vehicles;
        public List<VehiclePaletteBlock> VehiclePalette;
        public List<EquipmentBlock> Equipment;
        public List<EquipmentPaletteBlock> EquipmentPalette;
        public List<Weapon> Weapons;
        public List<WeaponPaletteBlock> WeaponPalette;
        public List<DeviceGroup> DeviceGroups;
        public List<Machine> Machines;
        public List<MachinePaletteBlock> MachinePalette;
        public List<Terminal> Terminals;
        public List<TerminalPaletteBlock> TerminalPalette;
        public List<AlternateRealityDevice> AlternateRealityDevices;
        public List<AlternateRealityDevicePaletteBlock> AlternateRealityDevicePalette;
        public List<Control> Controls;
        public List<ControlPaletteBlock> ControlPalette;
        public List<SoundSceneryBlock> SoundScenery;
        public List<SoundSceneryPaletteBlock> SoundSceneryPalette;
        public List<Giant> Giants;
        public List<GiantPaletteBlock> GiantPalette;
        public List<EffectSceneryBlock> EffectScenery;
        public List<EffectSceneryBlock2> EffectSceneryPalette;
        public List<LightVolume> LightVolumes;
        public List<LightVolumesPaletteBlock> LightVolumesPalette;
        public List<SandboxObject> SandboxVehicles;
        public List<SandboxObject> SandboxWeapons;
        public List<SandboxObject> SandboxEquipment;
        public List<SandboxObject> SandboxScenery;
        public List<SandboxObject> SandboxTeleporters;
        public List<SandboxObject> SandboxGoalObjects;
        public List<SandboxObject> SandboxSpawning;
        public List<SoftCeiling> SoftCeilings;
        public List<PlayerStartingProfileBlock> PlayerStartingProfile;
        public List<PlayerStartingLocation> PlayerStartingLocations;
        public List<TriggerVolume> TriggerVolumes;
        public uint Unknown26;
        public uint Unknown27;
        public uint Unknown28;
        public uint Unknown29;
        public uint Unknown30;
        public uint Unknown31;
        public List<UnknownBlock> Unknown32;
        public uint Unknown35;
        public uint Unknown36;
        public uint Unknown37;
        public uint Unknown38;
        public uint Unknown39;
        public uint Unknown40;
        public uint Unknown41;
        public uint Unknown42;
        public uint Unknown43;
        public List<UnknownBlock> Unknown44;
        public uint Unknown45;
        public uint Unknown46;
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
        public uint Unknown57;
        public uint Unknown58;
        public uint Unknown59;
        public uint Unknown60;
        public uint Unknown61;
        public uint Unknown62;
        public uint Unknown63;
        public uint Unknown64;
        public uint Unknown65;
        public uint Unknown66;
        public uint Unknown67;
        public uint Unknown68;
        public uint Unknown69;
        public uint Unknown70;
        public uint Unknown71;
        public uint Unknown72;
        public uint Unknown73;
        public uint Unknown74;
        public uint Unknown75;
        public uint Unknown76;
        public uint Unknown77;
        public uint Unknown78;
        public uint Unknown79;
        public uint Unknown80;
        public List<Decal> Decals;
        public List<DecalPaletteBlock> DecalPalette;
        public uint Unknown81;
        public uint Unknown82;
        public uint Unknown83;
        public List<StylePaletteBlock> StylePalette;
        public List<SquadGroup> SquadGroups;
        public List<Squad> Squads;
        public List<Zone> Zones;
        public List<UnknownBlock2> Unknown84;
        public uint Unknown85;
        public uint Unknown86;
        public uint Unknown87;
        public List<CharacterPaletteBlock> CharacterPalette;
        public uint Unknown88;
        public uint Unknown89;
        public uint Unknown90;
        public List<AiPathfindingDatum> AiPathfindingData;
        public uint Unknown91;
        public uint Unknown92;
        public uint Unknown93;
        public byte[] ScriptStrings;
        public List<Script> Scripts;
        public List<ScriptGlobal> Globals;
        public List<CachedTagInstance> ScriptReferences;
        public uint Unknown94;
        public uint Unknown95;
        public uint Unknown96;
        public List<ScriptingDatum> ScriptingData;
        public List<CutsceneFlag> CutsceneFlags;
        public List<CutsceneCameraPoint> CutsceneCameraPoints;
        public List<CutsceneTitle> CutsceneTitles;
        public CachedTagInstance CustomObjectNameStrings;
        public CachedTagInstance ChapterTitleStrings;
        [MinVersion(CacheVersion.HaloOnline498295)]
        public CachedTagInstance Unknown156;
        public List<ScenarioResource> ScenarioResources;
        public List<UnitSeatsMappingBlock> UnitSeatsMapping;
        public List<ScenarioKillTrigger> ScenarioKillTriggers;
        public List<ScenarioSafeTrigger> ScenarioSafeTriggers;
        public List<ScriptExpression> ScriptExpressions;
        public uint Unknown97;
        public uint Unknown98;
        public uint Unknown99;
        public uint Unknown100;
        public uint Unknown101;
        public uint Unknown102;
        public List<BackgroundSoundEnvironmentPaletteBlock> BackgroundSoundEnvironmentPalette;
        public uint Unknown103;
        public uint Unknown104;
        public uint Unknown105;
        public uint Unknown106;
        public uint Unknown107;
        public uint Unknown108;
        public List<UnknownBlock3> Unknown109;
        public List<FogBlock> Fog;
        public List<CameraFxBlock> CameraFx;
        public uint Unknown110;
        public uint Unknown111;
        public uint Unknown112;
        public uint Unknown113;
        public uint Unknown114;
        public uint Unknown115;
        public uint Unknown116;
        public uint Unknown117;
        public uint Unknown118;
        public List<ScenarioClusterDatum> ScenarioClusterData;
        public uint Unknown119;
        public uint Unknown120;
        public uint Unknown121;
        public int ObjectSalts1;
        public int ObjectSalts2;
        public int ObjectSalts3;
        public int ObjectSalts4;
        public int ObjectSalts5;
        public int ObjectSalts6;
        public int ObjectSalts7;
        public int ObjectSalts8;
        public int ObjectSalts9;
        public int ObjectSalts10;
        public int ObjectSalts11;
        public int ObjectSalts12;
        public int ObjectSalts13;
        public int ObjectSalts14;
        public int ObjectSalts15;
        public int ObjectSalts16;
        public int ObjectSalts17;
        public int ObjectSalts18;
        public int ObjectSalts19;
        public int ObjectSalts20;
        public int ObjectSalts21;
        public int ObjectSalts22;
        public int ObjectSalts23;
        public int ObjectSalts24;
        public int ObjectSalts25;
        public int ObjectSalts26;
        public int ObjectSalts27;
        public int ObjectSalts28;
        public int ObjectSalts29;
        public int ObjectSalts30;
        public int ObjectSalts31;
        public int ObjectSalts32;
        public List<SpawnDatum> SpawnData;
        public CachedTagInstance SoundEffectsCollection;
        public List<Crate> Crates;
        public List<CratePaletteBlock> CratePalette;
        public List<CachedTagInstance> FlockPalette;
        public List<Flock> Flocks;
        public CachedTagInstance SubtitleStrings;
        public uint Unknown122;
        public uint Unknown123;
        public uint Unknown124;
        public List<CreaturePaletteBlock> CreaturePalette;
        public List<EditorFolder> EditorFolders;
        public CachedTagInstance TerritoryLocationNameStrings;
        public uint Unknown125;
        public uint Unknown126;
        public List<CachedTagInstance> MissionDialogue;
        public CachedTagInstance ObjectiveStrings;
        public List<Interpolator> Interpolators;
        public uint Unknown127;
        public uint Unknown128;
        public uint Unknown129;
        public uint Unknown130;
        public uint Unknown131;
        public uint Unknown132;
        public List<SimulationDefinitionTableBlock> SimulationDefinitionTable;
        public CachedTagInstance DefaultCameraFx;
        public CachedTagInstance DefaultScreenFx;
        public CachedTagInstance Unknown133;
        public CachedTagInstance SkyParameters;
        public CachedTagInstance GlobalLighing;
        public CachedTagInstance Lightmap;
        public CachedTagInstance PerformanceThrottles;
        public List<UnknownBlock4> Unknown134;
        public List<AiObjective> AiObjectives;
        public List<DesignerZoneset> DesignerZonesets;
        public List<UnknownBlock5> Unknown135;
        public uint Unknown136;
        public uint Unknown137;
        public uint Unknown138;
        public List<CachedTagInstance> Cinematics;
        public List<CinematicLightingBlock> CinematicLighting;
        public uint Unknown139;
        public uint Unknown140;
        public uint Unknown141;
        public List<ScenarioMetagameBlock> ScenarioMetagame;
        public List<UnknownBlock6> Unknown142;
        public List<UnknownBlock7> Unknown143;
        public uint Unknown144;
        public uint Unknown145;
        public uint Unknown146;
        public uint Unknown147;
        public uint Unknown148;
        public uint Unknown149;
        public uint Unknown150;
        public uint Unknown151;
        public uint Unknown152;
        public CachedTagInstance Unknown153;
        public CachedTagInstance Unknown154;
        public List<CachedTagInstance> Unknown155;

        [TagStructure(Size = 0x6C)]
        public class StructureBsp
        {
            public CachedTagInstance StructureBsp2;
            public CachedTagInstance Design;
            public CachedTagInstance Lighting;
            public int Unknown;
            public uint Unknown2;
            public uint Unknown3;
            public uint Unknown4;
            public short Unknown5;
            public short Unknown6;
            public short Unknown7;
            public short Unknown8;
            public CachedTagInstance Cubemap;
            public CachedTagInstance Wind;
            public int Unknown9;
        }

        [TagStructure(Size = 0x14)]
        public class SkyReference
        {
            public CachedTagInstance SkyObject;
            public short NameIndex;
            public ushort ActiveBsps;
        }

        public enum ZoneSetPotentiallyVisibleSetFlags : ushort
        {
            None = 0,
            EmptyDebugPotentiallyVisibleSet = 1 << 0
        }

        [TagStructure(Size = 0x2C)]
        public class ZoneSetPotentiallyVisibleSet
        {
            public uint StructureBspMask;
            public short Version;
            public ZoneSetPotentiallyVisibleSetFlags Flags;
            public List<BspChecksum> BspChecksums;
            public List<StructureBspPotentiallyVisibleSet> StructureBspPotentiallyVisibleSets;
            public List<PortalToDeviceMapping> PortalToDeviceMappings;

            [TagStructure(Size = 0x4)]
            public class BspChecksum
            {
                public uint Checksum;
            }

            [TagStructure(Size = 0x54)]
            public class StructureBspPotentiallyVisibleSet
            {
                public List<Cluster> Clusters;
                public List<Cluster> ClustersDoorsClosed;
                public List<Sky> ClusterSkies;
                public List<Sky> ClusterVisibleSkies;
                public List<UnknownBlock> Unknown;
                public List<UnknownBlock> Unknown2;
                public List<Cluster2> Clusters2;

                [TagStructure(Size = 0xC)]
                public class Cluster
                {
                    public List<BitVector> BitVectors;

                    [TagStructure(Size = 0xC)]
                    public class BitVector
                    {
                        public List<Bit> Bits;

                        [TagStructure(Size = 0x4)]
                        public class Bit
                        {
                            public uint Allow;
                        }
                    }
                }
                
                [TagStructure(Size = 0x1)]
                public class Sky
                {
                    public sbyte SkyIndex;
                }
                
                [TagStructure(Size = 0x4)]
                public class UnknownBlock
                {
                    public uint Unknown;
                }
                
                [TagStructure(Size = 0xC)]
                public class Cluster2
                {
                    public List<UnknownBlock> Unknown;

                    [TagStructure(Size = 0x1)]
                    public class UnknownBlock
                    {
                        public sbyte Unknown;
                    }
                }
            }

            [TagStructure(Size = 0x18)]
            public class PortalToDeviceMapping
            {
                public List<DevicePortalAssociation> DevicePortalAssociations;
                public List<GamePortalToPortalMapping> GamePortalToPortalMappings;
                
                [TagStructure(Size = 0xC)]
                public class DevicePortalAssociation
                {
                    public int UniqueId;
                    public short OriginBspIndex;
                    [MaxVersion(CacheVersion.HaloOnline449175)]
                    public GameObjectTypeOld TypeOld;
                    [MinVersion(CacheVersion.HaloOnline498295)]
                    public GameObjectTypeNew TypeNew;
                    public ObjectSource Source;
                    public short FirstGamePortalIndex;
                    public ushort GamePortalCount;
                }

                [TagStructure(Size = 0x2)]
                public class GamePortalToPortalMapping
                {
                    public short PortalIndex;
                }
            }
        }

        public enum ObjectSource : sbyte
        {
            Structure,
            Editor,
            Dynamic,
            Legacy,
            Sky,
            Parent
        }

        [TagStructure(Size = 0x64)]
        public class ZoneSetAudibilityBlock
        {
            public int DoorPortalCount;
            public int UniqueClusterCount;
            public Bounds<float> ClusterDistanceBounds;
            public List<EncodedDoorPa> EncodedDoorPas;
            public List<RoomDoorPortalEncodedPa> ClusterDoorPortalEncodedPas;
            public List<AiDeafeningPa> AiDeafeningPas;
            public List<RoomDistance> RoomDistances;
            public List<GamePortalToDoorOccluderMapping> GamePortalToDoorOccluderMappings;
            public List<BspClusterToRoomBoundsMapping> BspClusterToRoomBoundsMappings;
            public List<BspClusterToRoomIndex> BspClusterToRoomIndices;

            [TagStructure(Size = 0x4)]
            public class EncodedDoorPa
            {
                public int EncodedData;
            }

            [TagStructure(Size = 0x4)]
            public class RoomDoorPortalEncodedPa
            {
                public int EncodedData;
            }

            [TagStructure(Size = 0x4)]
            public class AiDeafeningPa
            {
                public int EncodedData;
            }

            [TagStructure(Size = 0x1)]
            public class RoomDistance
            {
                public sbyte EncodedData;
            }

            [TagStructure(Size = 0x8)]
            public class GamePortalToDoorOccluderMapping
            {
                public int FirstDoorOccluderIndex;
                public int DoorOccluderCount;
            }

            [TagStructure(Size = 0x8)]
            public class BspClusterToRoomBoundsMapping
            {
                public int FirstRoomIndex;
                public int RoomIndexCount;
            }

            [TagStructure(Size = 0x2)]
            public class BspClusterToRoomIndex
            {
                public short RoomIndex;
            }
        }

        [TagStructure(Size = 0x24)]
        public class ZoneSet
        {
            public StringId Name;
            public int PotentiallyVisibleSetIndex;
            public int ImportLoadedBsps;
            public uint LoadedBsps;
            public uint LoadedDesignerZonesets;
            public uint UnloadedDesignerZonesets;
            public uint LoadedCinematicZonesets;
            public int BspAtlasIndex;
            public int ScenarioBspAudibilityIndex;
        }

        [TagStructure(Size = 0x24)]
        public class ObjectName
        {
            [TagField(Length = 32)]
            public string Name;
            [MaxVersion(CacheVersion.HaloOnline449175)]
            public GameObjectTypeOld ObjectTypeOld;
            [MinVersion(CacheVersion.HaloOnline498295)]
            public GameObjectTypeNew ObjectTypeNew;
            [TagField(Padding = true, Length = 1)]
            public byte[] Unused;
            public short PlacementIndex;
        }

        [Flags]
        public enum ObjectPlacementFlags : int
        {
            None = 0,
            NotAutomatically = 1 << 0,
            NotOnEasy = 1 << 1,
            NotOnNormal = 1 << 2,
            NotOnHard = 1 << 3,
            LockTypeToEnvObject = 1 << 4,
            LockTransformToEnvObject = 1 << 5,
            NeverPlaced = 1 << 6,
            LockNameToEnvObject = 1 << 7,
            CreateAtRest = 1 << 8,
            StoreOrientations = 1 << 9,
            Startup = 1 << 10,
            AttachPhysically = 1 << 11,
            AttachWithScale = 1 << 12,
            NoParentLighting = 1 << 13
        }

        [TagStructure(Size = 0x1C)]
        public class ObjectNodeOrientation
        {
            public short NodeCount;
            [TagField(Padding = true, Length = 2)]
            public byte[] Unused;
            public List<BitVector> BitVectors;
            public List<Orientation> Orientations;

            [TagStructure(Size = 0x1)]
            public class BitVector
            {
                public byte Data;
            }

            [TagStructure(Size = 0x2)]
            public class Orientation
            {
                public short Number;
            }
        }

        [TagStructure(Size = 0xB8)]
        public class SceneryBlock
        {
            public short PaletteIndex;
            public short NameIndex;
            public ObjectPlacementFlags PlacementFlags;
            public RealPoint3d Position;
            public RealEulerAngles3d Rotation;
            public float Scale;
            public List<ObjectNodeOrientation> NodeOrientations;
            public short Unknown2;
            public ushort OldManualBspFlagsNowZonesets;
            public StringId UniqueName;
            public ushort UniqueIdSalt;
            public ushort UniqueIdIndex;
            public short OriginBspIndex;
            [MaxVersion(CacheVersion.HaloOnline449175)]
            public GameObjectTypeOld ObjectTypeOld;
            [MinVersion(CacheVersion.HaloOnline498295)]
            public GameObjectTypeNew ObjectTypeNew;
            public SourceValue Source;
            public BspPolicyValue BspPolicy;
            public sbyte Unknown3;
            public short EditorFolderIndex;
            public short Unknown4;
            public short ParentNameIndex;
            public StringId ChildName;
            public StringId Unknown5;
            public ushort AllowedZonesets;
            public short Unknown6;
            public StringId Variant;
            public byte ActiveChangeColors;
            public sbyte Unknown7;
            public sbyte Unknown8;
            public sbyte Unknown9;
            public byte PrimaryColorA;
            public byte PrimaryColorR;
            public byte PrimaryColorG;
            public byte PrimaryColorB;
            public byte SecondaryColorA;
            public byte SecondaryColorR;
            public byte SecondaryColorG;
            public byte SecondaryColorB;
            public byte TertiaryColorA;
            public byte TertiaryColorR;
            public byte TertiaryColorG;
            public byte TertiaryColorB;
            public byte QuaternaryColorA;
            public byte QuaternaryColorR;
            public byte QuaternaryColorG;
            public byte QuaternaryColorB;
            public uint Unknown10;
            public PathfindingPolicyValue PathfindingPolicy;
            public LightmappingPolicyValue LightmappingPolicy;
            public List<PathfindingReference> PathfindingReferences;
            public short Unknown11;
            public short Unknown12;
            public SymmetryValue Symmetry;
            public ushort EngineFlags;
            public TeamValue Team;
            public sbyte SpawnSequence;
            public sbyte RuntimeMinimum;
            public sbyte RuntimeMaximum;
            public byte MultiplayerFlags;
            public short SpawnTime;
            public short UnknownSpawnTime;
            public sbyte Unknown13;
            public ShapeValue Shape;
            public sbyte TeleporterChannel;
            public sbyte Unknown14;
            public short Unknown15;
            public short AttachedNameIndex;
            public uint Unknown16;
            public uint Unknown17;
            public float WidthRadius;
            public float Depth;
            public float Top;
            public float Bottom;
            public uint Unknown18;

            public enum SourceValue : sbyte
            {
                Structure,
                Editor,
                Dynamic,
                Legacy,
            }

            public enum BspPolicyValue : sbyte
            {
                Default,
                AlwaysPlaced,
                ManualBspIndex,
            }

            public enum PathfindingPolicyValue : short
            {
                TagDefault,
                Dynamic,
                CutOut,
                Standard,
                None,
            }

            public enum LightmappingPolicyValue : short
            {
                TagDefault,
                Dynamic,
                PerVertex,
            }

            [TagStructure(Size = 0x4)]
            public class PathfindingReference
            {
                public short BspIndex;
                public short PathfindingObjectIndex;
            }

            public enum SymmetryValue : int
            {
                Both,
                Symmetric,
                Asymmetric,
            }

            public enum TeamValue : short
            {
                Red,
                Blue,
                Green,
                Orange,
                Purple,
                Yellow,
                Brown,
                Pink,
                Neutral,
            }

            public enum ShapeValue : sbyte
            {
                None,
                Sphere,
                Cylinder,
                Box,
            }
        }

        [TagStructure(Size = 0x30)]
        public class SceneryPaletteBlock
        {
            public CachedTagInstance Scenery;
            public uint Unknown;
            public uint Unknown2;
            public uint Unknown3;
            public uint Unknown4;
            public uint Unknown5;
            public uint Unknown6;
            public uint Unknown7;
            public uint Unknown8;
        }

        [TagStructure(Size = 0x78)]
        public class Biped
        {
            public short PaletteIndex;
            public short NameIndex;
            public uint PlacementFlags;
            public float PositionX;
            public float PositionY;
            public float PositionZ;
            public Angle RotationI;
            public Angle RotationJ;
            public Angle RotationK;
            public float Scale;
            public List<UnknownBlock> Unknown;
            public short Unknown2;
            public ushort OldManualBspFlagsNowZonesets;
            public StringId UniqueName;
            public ushort UniqueIdSalt;
            public ushort UniqueIdIndex;
            public short OriginBspIndex;
            [MaxVersion(CacheVersion.HaloOnline449175)]
            public GameObjectTypeOld ObjectTypeOld;
            [MinVersion(CacheVersion.HaloOnline498295)]
            public GameObjectTypeNew ObjectTypeNew;
            public SourceValue Source;
            public BspPolicyValue BspPolicy;
            public sbyte Unknown3;
            public short EditorFolderIndex;
            public short Unknown4;
            public short ParentNameIndex;
            public StringId ChildName;
            public StringId Unknown5;
            public ushort AllowedZonesets;
            public short Unknown6;
            public StringId Variant;
            public byte ActiveChangeColors;
            public sbyte Unknown7;
            public sbyte Unknown8;
            public sbyte Unknown9;
            public byte PrimaryColorA;
            public byte PrimaryColorR;
            public byte PrimaryColorG;
            public byte PrimaryColorB;
            public byte SecondaryColorA;
            public byte SecondaryColorR;
            public byte SecondaryColorG;
            public byte SecondaryColorB;
            public byte TertiaryColorA;
            public byte TertiaryColorR;
            public byte TertiaryColorG;
            public byte TertiaryColorB;
            public byte QuaternaryColorA;
            public byte QuaternaryColorR;
            public byte QuaternaryColorG;
            public byte QuaternaryColorB;
            public uint Unknown10;
            public float BodyVitalityPercentage;
            public uint Flags;

            [TagStructure(Size = 0x1C)]
            public class UnknownBlock
            {
                public short NodeCount;
                public short Unknown;
                public List<UnknownBlock2> Unknown2;
                public List<UnknownBlock3> Unknown3;

                [TagStructure(Size = 0x1)]
                public class UnknownBlock2
                {
                    public byte Unknown;
                }

                [TagStructure(Size = 0x2)]
                public class UnknownBlock3
                {
                    public short Unknown;
                }
            }

            public enum SourceValue : sbyte
            {
                Structure,
                Editor,
                Dynamic,
                Legacy,
            }

            public enum BspPolicyValue : sbyte
            {
                Default,
                AlwaysPlaced,
                ManualBspIndex,
            }
        }

        [TagStructure(Size = 0x30)]
        public class BipedPaletteBlock
        {
            public CachedTagInstance Biped;
            public uint Unknown;
            public uint Unknown2;
            public uint Unknown3;
            public uint Unknown4;
            public uint Unknown5;
            public uint Unknown6;
            public uint Unknown7;
            public uint Unknown8;
        }

        [TagStructure(Size = 0xAC)]
        public class Vehicle
        {
            public short PaletteIndex;
            public short NameIndex;
            public uint PlacementFlags;
            public float PositionX;
            public float PositionY;
            public float PositionZ;
            public Angle RotationI;
            public Angle RotationJ;
            public Angle RotationK;
            public float Scale;
            public List<UnknownBlock> Unknown;
            public short Unknown2;
            public ushort OldManualBspFlagsNowZonesets;
            public StringId UniqueName;
            public ushort UniqueIdSalt;
            public ushort UniqueIdIndex;
            public short OriginBspIndex;
            [MaxVersion(CacheVersion.HaloOnline449175)]
            public GameObjectTypeOld ObjectTypeOld;
            [MinVersion(CacheVersion.HaloOnline498295)]
            public GameObjectTypeNew ObjectTypeNew;
            public SourceValue Source;
            public BspPolicyValue BspPolicy;
            public sbyte Unknown3;
            public short EditorFolderIndex;
            public short Unknown4;
            public short ParentNameIndex;
            public StringId ChildName;
            public StringId Unknown5;
            public ushort AllowedZonesets;
            public short Unknown6;
            public StringId Variant;
            public byte ActiveChangeColors;
            public sbyte Unknown7;
            public sbyte Unknown8;
            public sbyte Unknown9;
            public byte PrimaryColorA;
            public byte PrimaryColorR;
            public byte PrimaryColorG;
            public byte PrimaryColorB;
            public byte SecondaryColorA;
            public byte SecondaryColorR;
            public byte SecondaryColorG;
            public byte SecondaryColorB;
            public byte TertiaryColorA;
            public byte TertiaryColorR;
            public byte TertiaryColorG;
            public byte TertiaryColorB;
            public byte QuaternaryColorA;
            public byte QuaternaryColorR;
            public byte QuaternaryColorG;
            public byte QuaternaryColorB;
            public uint Unknown10;
            public float BodyVitalityPercentage;
            public uint Flags;
            public SymmetryValue Symmetry;
            public ushort EngineFlags;
            public TeamValue Team;
            public sbyte SpawnSequence;
            public sbyte RuntimeMinimum;
            public sbyte RuntimeMaximum;
            public byte MultiplayerFlags;
            public short SpawnTime;
            public short UnknownSpawnTime;
            public sbyte Unknown11;
            public ShapeValue Shape;
            public sbyte TeleporterChannel;
            public sbyte Unknown12;
            public short Unknown13;
            public short AttachedNameIndex;
            public uint Unknown14;
            public uint Unknown15;
            public float WidthRadius;
            public float Depth;
            public float Top;
            public float Bottom;
            public uint Unknown16;

            [TagStructure(Size = 0x1C)]
            public class UnknownBlock
            {
                public short NodeCount;
                public short Unknown;
                public List<UnknownBlock2> Unknown2;
                public List<UnknownBlock3> Unknown3;

                [TagStructure(Size = 0x1)]
                public class UnknownBlock2
                {
                    public byte Unknown;
                }

                [TagStructure(Size = 0x2)]
                public class UnknownBlock3
                {
                    public short Unknown;
                }
            }

            public enum SourceValue : sbyte
            {
                Structure,
                Editor,
                Dynamic,
                Legacy,
            }

            public enum BspPolicyValue : sbyte
            {
                Default,
                AlwaysPlaced,
                ManualBspIndex,
            }

            public enum SymmetryValue : int
            {
                Both,
                Symmetric,
                Asymmetric,
            }

            public enum TeamValue : short
            {
                Red,
                Blue,
                Green,
                Orange,
                Purple,
                Yellow,
                Brown,
                Pink,
                Neutral,
            }

            public enum ShapeValue : sbyte
            {
                None,
                Sphere,
                Cylinder,
                Box,
            }
        }

        [TagStructure(Size = 0x30)]
        public class VehiclePaletteBlock
        {
            public CachedTagInstance Vehicle;
            public uint Unknown;
            public uint Unknown2;
            public uint Unknown3;
            public uint Unknown4;
            public uint Unknown5;
            public uint Unknown6;
            public uint Unknown7;
            public uint Unknown8;
        }

        [TagStructure(Size = 0x8C)]
        public class EquipmentBlock
        {
            public short PaletteIndex;
            public short NameIndex;
            public uint PlacementFlags;
            public float PositionX;
            public float PositionY;
            public float PositionZ;
            public Angle RotationI;
            public Angle RotationJ;
            public Angle RotationK;
            public float Scale;
            public List<UnknownBlock> Unknown;
            public short Unknown2;
            public ushort OldManualBspFlagsNowZonesets;
            public StringId UniqueName;
            public ushort UniqueIdSalt;
            public ushort UniqueIdIndex;
            public short OriginBspIndex;
            [MaxVersion(CacheVersion.HaloOnline449175)]
            public GameObjectTypeOld ObjectTypeOld;
            [MinVersion(CacheVersion.HaloOnline498295)]
            public GameObjectTypeNew ObjectTypeNew;
            public SourceValue Source;
            public BspPolicyValue BspPolicy;
            public sbyte Unknown3;
            public short EditorFolderIndex;
            public short Unknown4;
            public short ParentNameIndex;
            public StringId ChildName;
            public StringId Unknown5;
            public ushort AllowedZonesets;
            public short Unknown6;
            public uint EquipmentFlags;
            public SymmetryValue Symmetry;
            public ushort EngineFlags;
            public TeamValue Team;
            public sbyte SpawnSequence;
            public sbyte RuntimeMinimum;
            public sbyte RuntimeMaximum;
            public byte MultiplayerFlags;
            public short SpawnTime;
            public short UnknownSpawnTime;
            public sbyte Unknown7;
            public ShapeValue Shape;
            public sbyte TeleporterChannel;
            public sbyte Unknown8;
            public short Unknown9;
            public short AttachedNameIndex;
            public uint Unknown10;
            public uint Unknown11;
            public float WidthRadius;
            public float Depth;
            public float Top;
            public float Bottom;
            public uint Unknown12;

            [TagStructure(Size = 0x1C)]
            public class UnknownBlock
            {
                public short NodeCount;
                public short Unknown;
                public List<UnknownBlock2> Unknown2;
                public List<UnknownBlock3> Unknown3;

                [TagStructure(Size = 0x1)]
                public class UnknownBlock2
                {
                    public byte Unknown;
                }

                [TagStructure(Size = 0x2)]
                public class UnknownBlock3
                {
                    public short Unknown;
                }
            }

            public enum SourceValue : sbyte
            {
                Structure,
                Editor,
                Dynamic,
                Legacy,
            }

            public enum BspPolicyValue : sbyte
            {
                Default,
                AlwaysPlaced,
                ManualBspIndex,
            }

            public enum SymmetryValue : int
            {
                Both,
                Symmetric,
                Asymmetric,
            }

            public enum TeamValue : short
            {
                Red,
                Blue,
                Green,
                Orange,
                Purple,
                Yellow,
                Brown,
                Pink,
                Neutral,
            }

            public enum ShapeValue : sbyte
            {
                None,
                Sphere,
                Cylinder,
                Box,
            }
        }

        [TagStructure(Size = 0x30)]
        public class EquipmentPaletteBlock
        {
            public CachedTagInstance Equipment;
            public uint Unknown;
            public uint Unknown2;
            public uint Unknown3;
            public uint Unknown4;
            public uint Unknown5;
            public uint Unknown6;
            public uint Unknown7;
            public uint Unknown8;
        }

        [TagStructure(Size = 0xAC)]
        public class Weapon
        {
            public short PaletteIndex;
            public short NameIndex;
            public uint PlacementFlags;
            public float PositionX;
            public float PositionY;
            public float PositionZ;
            public Angle RotationI;
            public Angle RotationJ;
            public Angle RotationK;
            public float Scale;
            public List<UnknownBlock> Unknown;
            public short Unknown2;
            public ushort OldManualBspFlagsNowZonesets;
            public StringId UniqueName;
            public ushort UniqueIdSalt;
            public ushort UniqueIdIndex;
            public short OriginBspIndex;
            [MaxVersion(CacheVersion.HaloOnline449175)]
            public GameObjectTypeOld ObjectTypeOld;
            [MinVersion(CacheVersion.HaloOnline498295)]
            public GameObjectTypeNew ObjectTypeNew;
            public SourceValue Source;
            public BspPolicyValue BspPolicy;
            public sbyte Unknown3;
            public short EditorFolderIndex;
            public short Unknown4;
            public short ParentNameIndex;
            public StringId ChildName;
            public StringId Unknown5;
            public ushort AllowedZonesets;
            public short Unknown6;
            public StringId Variant;
            public byte ActiveChangeColors;
            public sbyte Unknown7;
            public sbyte Unknown8;
            public sbyte Unknown9;
            public byte PrimaryColorA;
            public byte PrimaryColorR;
            public byte PrimaryColorG;
            public byte PrimaryColorB;
            public byte SecondaryColorA;
            public byte SecondaryColorR;
            public byte SecondaryColorG;
            public byte SecondaryColorB;
            public byte TertiaryColorA;
            public byte TertiaryColorR;
            public byte TertiaryColorG;
            public byte TertiaryColorB;
            public byte QuaternaryColorA;
            public byte QuaternaryColorR;
            public byte QuaternaryColorG;
            public byte QuaternaryColorB;
            public uint Unknown10;
            public short RoundsLeft;
            public short RoundsLoaded;
            public uint WeaponFlags;
            public SymmetryValue Symmetry;
            public ushort EngineFlags;
            public TeamValue Team;
            public sbyte SpawnSequence;
            public sbyte RuntimeMinimum;
            public sbyte RuntimeMaximum;
            public byte MultiplayerFlags;
            public short SpawnTime;
            public short UnknownSpawnTime;
            public sbyte Unknown11;
            public ShapeValue Shape;
            public sbyte TeleporterChannel;
            public sbyte Unknown12;
            public short Unknown13;
            public short AttachedNameIndex;
            public uint Unknown14;
            public uint Unknown15;
            public float WidthRadius;
            public float Depth;
            public float Top;
            public float Bottom;
            public uint Unknown16;

            [TagStructure(Size = 0x1C)]
            public class UnknownBlock
            {
                public short NodeCount;
                public short Unknown;
                public List<UnknownBlock2> Unknown2;
                public List<UnknownBlock3> Unknown3;

                [TagStructure(Size = 0x1)]
                public class UnknownBlock2
                {
                    public byte Unknown;
                }

                [TagStructure(Size = 0x2)]
                public class UnknownBlock3
                {
                    public short Unknown;
                }
            }

            public enum SourceValue : sbyte
            {
                Structure,
                Editor,
                Dynamic,
                Legacy,
            }

            public enum BspPolicyValue : sbyte
            {
                Default,
                AlwaysPlaced,
                ManualBspIndex,
            }

            public enum SymmetryValue : int
            {
                Both,
                Symmetric,
                Asymmetric,
            }

            public enum TeamValue : short
            {
                Red,
                Blue,
                Green,
                Orange,
                Purple,
                Yellow,
                Brown,
                Pink,
                Neutral,
            }

            public enum ShapeValue : sbyte
            {
                None,
                Sphere,
                Cylinder,
                Box,
            }
        }

        [TagStructure(Size = 0x30)]
        public class WeaponPaletteBlock
        {
            public CachedTagInstance Weapon;
            public uint Unknown;
            public uint Unknown2;
            public uint Unknown3;
            public uint Unknown4;
            public uint Unknown5;
            public uint Unknown6;
            public uint Unknown7;
            public uint Unknown8;
        }

        [TagStructure(Size = 0x2C)]
        public class DeviceGroup
        {
            [TagField(Length = 32)]
            public string Name;
            public float InitialValue;
            public uint Flags;
            public short EditorFolderIndex;
            public short Unknown;
        }

        [TagStructure(Size = 0x8C)]
        public class Machine
        {
            public short PaletteIndex;
            public short NameIndex;
            public uint PlacementFlags;
            public float PositionX;
            public float PositionY;
            public float PositionZ;
            public Angle RotationI;
            public Angle RotationJ;
            public Angle RotationK;
            public float Scale;
            public List<UnknownBlock> Unknown;
            public short Unknown2;
            public ushort OldManualBspFlagsNowZonesets;
            public StringId UniqueName;
            public ushort UniqueIdSalt;
            public ushort UniqueIdIndex;
            public short OriginBspIndex;
            [MaxVersion(CacheVersion.HaloOnline449175)]
            public GameObjectTypeOld ObjectTypeOld;
            [MinVersion(CacheVersion.HaloOnline498295)]
            public GameObjectTypeNew ObjectTypeNew;
            public SourceValue Source;
            public BspPolicyValue BspPolicy;
            public sbyte Unknown3;
            public short EditorFolderIndex;
            public short Unknown4;
            public short ParentNameIndex;
            public StringId ChildName;
            public StringId Unknown5;
            public ushort AllowedZonesets;
            public short Unknown6;
            public StringId Variant;
            public byte ActiveChangeColors;
            public sbyte Unknown7;
            public sbyte Unknown8;
            public sbyte Unknown9;
            public byte PrimaryColorA;
            public byte PrimaryColorR;
            public byte PrimaryColorG;
            public byte PrimaryColorB;
            public byte SecondaryColorA;
            public byte SecondaryColorR;
            public byte SecondaryColorG;
            public byte SecondaryColorB;
            public byte TertiaryColorA;
            public byte TertiaryColorR;
            public byte TertiaryColorG;
            public byte TertiaryColorB;
            public byte QuaternaryColorA;
            public byte QuaternaryColorR;
            public byte QuaternaryColorG;
            public byte QuaternaryColorB;
            public uint Unknown10;
            public short PowerGroup;
            public short PositionGroup;
            public uint DeviceFlags;
            public uint MachineFlags;
            public List<PathfindingReference> PathfindingReferences;
            public PathfindingPolicyValue PathfindingPolicy;
            public short Unknown11;

            [TagStructure(Size = 0x1C)]
            public class UnknownBlock
            {
                public short NodeCount;
                public short Unknown;
                public List<UnknownBlock2> Unknown2;
                public List<UnknownBlock3> Unknown3;

                [TagStructure(Size = 0x1)]
                public class UnknownBlock2
                {
                    public byte Unknown;
                }

                [TagStructure(Size = 0x2)]
                public class UnknownBlock3
                {
                    public short Unknown;
                }
            }

            public enum SourceValue : sbyte
            {
                Structure,
                Editor,
                Dynamic,
                Legacy,
            }

            public enum BspPolicyValue : sbyte
            {
                Default,
                AlwaysPlaced,
                ManualBspIndex,
            }

            [TagStructure(Size = 0x4)]
            public class PathfindingReference
            {
                public short BspIndex;
                public short PathfindingObjectIndex;
            }

            public enum PathfindingPolicyValue : short
            {
                TagDefault,
                CutOut,
                Sectors,
                Discs,
                None,
            }
        }

        [TagStructure(Size = 0x30)]
        public class MachinePaletteBlock
        {
            public CachedTagInstance Machine;
            public uint Unknown;
            public uint Unknown2;
            public uint Unknown3;
            public uint Unknown4;
            public uint Unknown5;
            public uint Unknown6;
            public uint Unknown7;
            public uint Unknown8;
        }

        [TagStructure(Size = 0x7C)]
        public class Terminal
        {
            public short PaletteIndex;
            public short NameIndex;
            public uint PlacementFlags;
            public float PositionX;
            public float PositionY;
            public float PositionZ;
            public Angle RotationI;
            public Angle RotationJ;
            public Angle RotationK;
            public float Scale;
            public List<UnknownBlock> Unknown;
            public short Unknown2;
            public ushort OldManualBspFlagsNowZonesets;
            public StringId UniqueName;
            public ushort UniqueIdSalt;
            public ushort UniqueIdIndex;
            public short OriginBspIndex;
            [MaxVersion(CacheVersion.HaloOnline449175)]
            public GameObjectTypeOld ObjectTypeOld;
            [MinVersion(CacheVersion.HaloOnline498295)]
            public GameObjectTypeNew ObjectTypeNew;
            public SourceValue Source;
            public BspPolicyValue BspPolicy;
            public sbyte Unknown3;
            public short EditorFolderIndex;
            public short Unknown4;
            public short ParentNameIndex;
            public StringId ChildName;
            public StringId Unknown5;
            public ushort AllowedZonesets;
            public short Unknown6;
            public StringId Variant;
            public byte ActiveChangeColors;
            public sbyte Unknown7;
            public sbyte Unknown8;
            public sbyte Unknown9;
            public byte PrimaryColorA;
            public byte PrimaryColorR;
            public byte PrimaryColorG;
            public byte PrimaryColorB;
            public byte SecondaryColorA;
            public byte SecondaryColorR;
            public byte SecondaryColorG;
            public byte SecondaryColorB;
            public byte TertiaryColorA;
            public byte TertiaryColorR;
            public byte TertiaryColorG;
            public byte TertiaryColorB;
            public byte QuaternaryColorA;
            public byte QuaternaryColorR;
            public byte QuaternaryColorG;
            public byte QuaternaryColorB;
            public uint Unknown10;
            public short PowerGroup;
            public short PositionGroup;
            public uint DeviceFlags;
            public uint Unknown11;

            [TagStructure(Size = 0x1C)]
            public class UnknownBlock
            {
                public short NodeCount;
                public short Unknown;
                public List<UnknownBlock2> Unknown2;
                public List<UnknownBlock3> Unknown3;

                [TagStructure(Size = 0x1)]
                public class UnknownBlock2
                {
                    public byte Unknown;
                }

                [TagStructure(Size = 0x2)]
                public class UnknownBlock3
                {
                    public short Unknown;
                }
            }

            public enum SourceValue : sbyte
            {
                Structure,
                Editor,
                Dynamic,
                Legacy,
            }

            public enum BspPolicyValue : sbyte
            {
                Default,
                AlwaysPlaced,
                ManualBspIndex,
            }
        }

        [TagStructure(Size = 0x30)]
        public class TerminalPaletteBlock
        {
            public CachedTagInstance Terminal;
            public uint Unknown;
            public uint Unknown2;
            public uint Unknown3;
            public uint Unknown4;
            public uint Unknown5;
            public uint Unknown6;
            public uint Unknown7;
            public uint Unknown8;
        }

        [TagStructure(Size = 0xBC)]
        public class AlternateRealityDevice
        {
            public short PaletteIndex;
            public short NameIndex;
            public uint PlacementFlags;
            public float PositionX;
            public float PositionY;
            public float PositionZ;
            public Angle RotationI;
            public Angle RotationJ;
            public Angle RotationK;
            public float Scale;
            public List<UnknownBlock> Unknown;
            public short Unknown2;
            public ushort OldManualBspFlagsNowZonesets;
            public StringId UniqueName;
            public ushort UniqueIdSalt;
            public ushort UniqueIdIndex;
            public short OriginBspIndex;
            [MaxVersion(CacheVersion.HaloOnline449175)]
            public GameObjectTypeOld ObjectTypeOld;
            [MinVersion(CacheVersion.HaloOnline498295)]
            public GameObjectTypeNew ObjectTypeNew;
            public SourceValue Source;
            public BspPolicyValue BspPolicy;
            public sbyte Unknown3;
            public short EditorFolderIndex;
            public short Unknown4;
            public short ParentNameIndex;
            public StringId ChildName;
            public StringId Unknown5;
            public ushort AllowedZonesets;
            public short Unknown6;
            public StringId Variant;
            public byte ActiveChangeColors;
            public sbyte Unknown7;
            public sbyte Unknown8;
            public sbyte Unknown9;
            public byte PrimaryColorA;
            public byte PrimaryColorR;
            public byte PrimaryColorG;
            public byte PrimaryColorB;
            public byte SecondaryColorA;
            public byte SecondaryColorR;
            public byte SecondaryColorG;
            public byte SecondaryColorB;
            public byte TertiaryColorA;
            public byte TertiaryColorR;
            public byte TertiaryColorG;
            public byte TertiaryColorB;
            public byte QuaternaryColorA;
            public byte QuaternaryColorR;
            public byte QuaternaryColorG;
            public byte QuaternaryColorB;
            public uint Unknown10;
            public short PowerGroup;
            public short PositionGroup;
            public uint DeviceFlags;
            [TagField(Length = 32)]
            public string TapScriptName;
            [TagField(Length = 32)]
            public string HoldScriptName;
            public short TapScriptIndex;
            public short HoldScriptIndex;

            [TagStructure(Size = 0x1C)]
            public class UnknownBlock
            {
                public short NodeCount;
                public short Unknown;
                public List<UnknownBlock2> Unknown2;
                public List<UnknownBlock3> Unknown3;

                [TagStructure(Size = 0x1)]
                public class UnknownBlock2
                {
                    public byte Unknown;
                }

                [TagStructure(Size = 0x2)]
                public class UnknownBlock3
                {
                    public short Unknown;
                }
            }

            public enum SourceValue : sbyte
            {
                Structure,
                Editor,
                Dynamic,
                Legacy,
            }

            public enum BspPolicyValue : sbyte
            {
                Default,
                AlwaysPlaced,
                ManualBspIndex,
            }
        }

        [TagStructure(Size = 0x30)]
        public class AlternateRealityDevicePaletteBlock
        {
            public CachedTagInstance ArgDevice;
            public uint Unknown;
            public uint Unknown2;
            public uint Unknown3;
            public uint Unknown4;
            public uint Unknown5;
            public uint Unknown6;
            public uint Unknown7;
            public uint Unknown8;
        }

        [TagStructure(Size = 0x80)]
        public class Control
        {
            public short PaletteIndex;
            public short NameIndex;
            public uint PlacementFlags;
            public float PositionX;
            public float PositionY;
            public float PositionZ;
            public Angle RotationI;
            public Angle RotationJ;
            public Angle RotationK;
            public float Scale;
            public List<UnknownBlock> Unknown;
            public short Unknown2;
            public ushort OldManualBspFlagsNowZonesets;
            public StringId UniqueName;
            public ushort UniqueIdSalt;
            public ushort UniqueIdIndex;
            public short OriginBspIndex;
            [MaxVersion(CacheVersion.HaloOnline449175)]
            public GameObjectTypeOld ObjectTypeOld;
            [MinVersion(CacheVersion.HaloOnline498295)]
            public GameObjectTypeNew ObjectTypeNew;
            public SourceValue Source;
            public BspPolicyValue BspPolicy;
            public sbyte Unknown3;
            public short EditorFolderIndex;
            public short Unknown4;
            public short ParentNameIndex;
            public StringId ChildName;
            public StringId Unknown5;
            public ushort AllowedZonesets;
            public short Unknown6;
            public StringId Variant;
            public byte ActiveChangeColors;
            public sbyte Unknown7;
            public sbyte Unknown8;
            public sbyte Unknown9;
            public byte PrimaryColorA;
            public byte PrimaryColorR;
            public byte PrimaryColorG;
            public byte PrimaryColorB;
            public byte SecondaryColorA;
            public byte SecondaryColorR;
            public byte SecondaryColorG;
            public byte SecondaryColorB;
            public byte TertiaryColorA;
            public byte TertiaryColorR;
            public byte TertiaryColorG;
            public byte TertiaryColorB;
            public byte QuaternaryColorA;
            public byte QuaternaryColorR;
            public byte QuaternaryColorG;
            public byte QuaternaryColorB;
            public uint Unknown10;
            public short PowerGroup;
            public short PositionGroup;
            public uint DeviceFlags;
            public uint ControlFlags;
            public short Unknown11;
            public short Unknown12;

            [TagStructure(Size = 0x1C)]
            public class UnknownBlock
            {
                public short NodeCount;
                public short Unknown;
                public List<UnknownBlock2> Unknown2;
                public List<UnknownBlock3> Unknown3;

                [TagStructure(Size = 0x1)]
                public class UnknownBlock2
                {
                    public byte Unknown;
                }

                [TagStructure(Size = 0x2)]
                public class UnknownBlock3
                {
                    public short Unknown;
                }
            }

            public enum SourceValue : sbyte
            {
                Structure,
                Editor,
                Dynamic,
                Legacy,
            }

            public enum BspPolicyValue : sbyte
            {
                Default,
                AlwaysPlaced,
                ManualBspIndex,
            }
        }

        [TagStructure(Size = 0x30)]
        public class ControlPaletteBlock
        {
            public CachedTagInstance Control;
            public uint Unknown;
            public uint Unknown2;
            public uint Unknown3;
            public uint Unknown4;
            public uint Unknown5;
            public uint Unknown6;
            public uint Unknown7;
            public uint Unknown8;
        }

        [TagStructure(Size = 0x70)]
        public class SoundSceneryBlock
        {
            public short PaletteIndex;
            public short NameIndex;
            public uint PlacementFlags;
            public float PositionX;
            public float PositionY;
            public float PositionZ;
            public Angle RotationI;
            public Angle RotationJ;
            public Angle RotationK;
            public float Scale;
            public List<UnknownBlock> Unknown;
            public short Unknown2;
            public ushort OldManualBspFlagsNowZonesets;
            public StringId UniqueName;
            public ushort UniqueIdSalt;
            public ushort UniqueIdIndex;
            public short OriginBspIndex;
            [MaxVersion(CacheVersion.HaloOnline449175)]
            public GameObjectTypeOld ObjectTypeOld;
            [MinVersion(CacheVersion.HaloOnline498295)]
            public GameObjectTypeNew ObjectTypeNew;
            public SourceValue Source;
            public BspPolicyValue BspPolicy;
            public sbyte Unknown3;
            public short EditorFolderIndex;
            public short Unknown4;
            public short ParentNameIndex;
            public StringId ChildName;
            public StringId Unknown5;
            public ushort AllowedZonesets;
            public short Unknown6;
            public int VolumeType;
            public float Height;
            public float OverrideDistanceMin;
            public float OverrideDistanceMax;
            public Angle OverrideConeAngleMin;
            public Angle OverrideConeAngleMax;
            public float OverrideOuterConeGain;

            [TagStructure(Size = 0x1C)]
            public class UnknownBlock
            {
                public short NodeCount;
                public short Unknown;
                public List<UnknownBlock2> Unknown2;
                public List<UnknownBlock3> Unknown3;

                [TagStructure(Size = 0x1)]
                public class UnknownBlock2
                {
                    public byte Unknown;
                }

                [TagStructure(Size = 0x2)]
                public class UnknownBlock3
                {
                    public short Unknown;
                }
            }

            public enum SourceValue : sbyte
            {
                Structure,
                Editor,
                Dynamic,
                Legacy,
            }

            public enum BspPolicyValue : sbyte
            {
                Default,
                AlwaysPlaced,
                ManualBspIndex,
            }
        }

        [TagStructure(Size = 0x30)]
        public class SoundSceneryPaletteBlock
        {
            public CachedTagInstance SoundScenery;
            public uint Unknown;
            public uint Unknown2;
            public uint Unknown3;
            public uint Unknown4;
            public uint Unknown5;
            public uint Unknown6;
            public uint Unknown7;
            public uint Unknown8;
        }

        [TagStructure(Size = 0x88)]
        public class Giant
        {
            public short PaletteIndex;
            public short NameIndex;
            public uint PlacementFlags;
            public float PositionX;
            public float PositionY;
            public float PositionZ;
            public Angle RotationI;
            public Angle RotationJ;
            public Angle RotationK;
            public float Scale;
            public List<UnknownBlock> Unknown;
            public short Unknown2;
            public ushort OldManualBspFlagsNowZonesets;
            public StringId UniqueName;
            public ushort UniqueIdSalt;
            public ushort UniqueIdIndex;
            public short OriginBspIndex;
            [MaxVersion(CacheVersion.HaloOnline449175)]
            public GameObjectTypeOld ObjectTypeOld;
            [MinVersion(CacheVersion.HaloOnline498295)]
            public GameObjectTypeNew ObjectTypeNew;
            public SourceValue Source;
            public BspPolicyValue BspPolicy;
            public sbyte Unknown3;
            public short EditorFolderIndex;
            public short Unknown4;
            public short ParentNameIndex;
            public StringId ChildName;
            public StringId Unknown5;
            public ushort AllowedZonesets;
            public short Unknown6;
            public StringId Variant;
            public byte ActiveChangeColors;
            public sbyte Unknown7;
            public sbyte Unknown8;
            public sbyte Unknown9;
            public byte PrimaryColorA;
            public byte PrimaryColorR;
            public byte PrimaryColorG;
            public byte PrimaryColorB;
            public byte SecondaryColorA;
            public byte SecondaryColorR;
            public byte SecondaryColorG;
            public byte SecondaryColorB;
            public byte TertiaryColorA;
            public byte TertiaryColorR;
            public byte TertiaryColorG;
            public byte TertiaryColorB;
            public byte QuaternaryColorA;
            public byte QuaternaryColorR;
            public byte QuaternaryColorG;
            public byte QuaternaryColorB;
            public uint Unknown10;
            public float BodyVitalityPercentage;
            public uint Flags;
            public short Unknown11;
            public short Unknown12;
            public List<PathfindingReference> PathfindingReferences;

            [TagStructure(Size = 0x1C)]
            public class UnknownBlock
            {
                public short NodeCount;
                public short Unknown;
                public List<UnknownBlock2> Unknown2;
                public List<UnknownBlock3> Unknown3;

                [TagStructure(Size = 0x1)]
                public class UnknownBlock2
                {
                    public byte Unknown;
                }

                [TagStructure(Size = 0x2)]
                public class UnknownBlock3
                {
                    public short Unknown;
                }
            }

            public enum SourceValue : sbyte
            {
                Structure,
                Editor,
                Dynamic,
                Legacy,
            }

            public enum BspPolicyValue : sbyte
            {
                Default,
                AlwaysPlaced,
                ManualBspIndex,
            }

            [TagStructure(Size = 0x4)]
            public class PathfindingReference
            {
                public short BspIndex;
                public short PathfindingObjectIndex;
            }
        }

        [TagStructure(Size = 0x30)]
        public class GiantPaletteBlock
        {
            public CachedTagInstance Giant;
            public uint Unknown;
            public uint Unknown2;
            public uint Unknown3;
            public uint Unknown4;
            public uint Unknown5;
            public uint Unknown6;
            public uint Unknown7;
            public uint Unknown8;
        }

        [TagStructure(Size = 0x54)]
        public class EffectSceneryBlock
        {
            public short PaletteIndex;
            public short NameIndex;
            public uint PlacementFlags;
            public float PositionX;
            public float PositionY;
            public float PositionZ;
            public Angle RotationI;
            public Angle RotationJ;
            public Angle RotationK;
            public float Scale;
            public List<UnknownBlock> Unknown;
            public short Unknown2;
            public ushort OldManualBspFlagsNowZonesets;
            public StringId UniqueName;
            public ushort UniqueIdSalt;
            public ushort UniqueIdIndex;
            public short OriginBspIndex;
            [MaxVersion(CacheVersion.HaloOnline449175)]
            public GameObjectTypeOld ObjectTypeOld;
            [MinVersion(CacheVersion.HaloOnline498295)]
            public GameObjectTypeNew ObjectTypeNew;
            public SourceValue Source;
            public BspPolicyValue BspPolicy;
            public sbyte Unknown3;
            public short EditorFolderIndex;
            public short Unknown4;
            public short ParentNameIndex;
            public StringId ChildName;
            public StringId Unknown5;
            public ushort AllowedZonesets;
            public short Unknown6;

            [TagStructure(Size = 0x1C)]
            public class UnknownBlock
            {
                public short NodeCount;
                public short Unknown;
                public List<UnknownBlock2> Unknown2;
                public List<UnknownBlock3> Unknown3;

                [TagStructure(Size = 0x1)]
                public class UnknownBlock2
                {
                    public byte Unknown;
                }

                [TagStructure(Size = 0x2)]
                public class UnknownBlock3
                {
                    public short Unknown;
                }
            }

            public enum SourceValue : sbyte
            {
                Structure,
                Editor,
                Dynamic,
                Legacy,
            }

            public enum BspPolicyValue : sbyte
            {
                Default,
                AlwaysPlaced,
                ManualBspIndex,
            }
        }

        [TagStructure(Size = 0x30)]
        public class EffectSceneryBlock2
        {
            public CachedTagInstance EffectScenery;
            public uint Unknown;
            public uint Unknown2;
            public uint Unknown3;
            public uint Unknown4;
            public uint Unknown5;
            public uint Unknown6;
            public uint Unknown7;
            public uint Unknown8;
        }

        [TagStructure(Size = 0x8C)]
        public class LightVolume
        {
            public short PaletteIndex;
            public short NameIndex;
            public uint PlacementFlags;
            public float PositionX;
            public float PositionY;
            public float PositionZ;
            public Angle RotationI;
            public Angle RotationJ;
            public Angle RotationK;
            public float Scale;
            public List<UnknownBlock> Unknown;
            public short Unknown2;
            public ushort OldManualBspFlagsNowZonesets;
            public StringId UniqueName;
            public ushort UniqueIdSalt;
            public ushort UniqueIdIndex;
            public short OriginBspIndex;
            [MaxVersion(CacheVersion.HaloOnline449175)]
            public GameObjectTypeOld ObjectTypeOld;
            [MinVersion(CacheVersion.HaloOnline498295)]
            public GameObjectTypeNew ObjectTypeNew;
            public SourceValue Source;
            public BspPolicyValue BspPolicy;
            public sbyte Unknown3;
            public short EditorFolderIndex;
            public short Unknown4;
            public short ParentNameIndex;
            public StringId ChildName;
            public StringId Unknown5;
            public ushort AllowedZonesets;
            public short Unknown6;
            public short PowerGroup;
            public short PositionGroup;
            public uint DeviceFlags;
            public TypeValue2 Type2;
            public ushort Flags;
            public LightmapTypeValue LightmapType;
            public ushort LightmapFlags;
            public float LightmapHalfLife;
            public float LightmapLightScale;
            public float X;
            public float Y;
            public float Z;
            public float Width;
            public float HeightScale;
            public Angle FieldOfView;
            public float FalloffDistance;
            public float CutoffDistance;

            [TagStructure(Size = 0x1C)]
            public class UnknownBlock
            {
                public short NodeCount;
                public short Unknown;
                public List<UnknownBlock2> Unknown2;
                public List<UnknownBlock3> Unknown3;

                [TagStructure(Size = 0x1)]
                public class UnknownBlock2
                {
                    public byte Unknown;
                }

                [TagStructure(Size = 0x2)]
                public class UnknownBlock3
                {
                    public short Unknown;
                }
            }

            public enum SourceValue : sbyte
            {
                Structure,
                Editor,
                Dynamic,
                Legacy,
            }

            public enum BspPolicyValue : sbyte
            {
                Default,
                AlwaysPlaced,
                ManualBspIndex,
            }

            public enum TypeValue2 : short
            {
                Sphere,
                Projective,
            }

            public enum LightmapTypeValue : short
            {
                UseLightTagSetting,
                DynamicOnly,
                DynamicWithLightmaps,
                LightmapsOnly,
            }
        }

        [TagStructure(Size = 0x30)]
        public class LightVolumesPaletteBlock
        {
            public CachedTagInstance LightVolume;
            public uint Unknown;
            public uint Unknown2;
            public uint Unknown3;
            public uint Unknown4;
            public uint Unknown5;
            public uint Unknown6;
            public uint Unknown7;
            public uint Unknown8;
        }

        [TagStructure(Size = 0x30)]
        public class SandboxObject
        {
            public CachedTagInstance Object;
            public StringId Name;
            public int MaxAllowed;
            public float Cost;
            public uint Unknown;
            public uint Unknown2;
            public uint Unknown3;
            public uint Unknown4;
            public uint Unknown5;
        }

        [Flags]
        public enum SoftCeilingFlags : ushort
        {
            None = 0,
            IgnoreBipeds = 1 << 0,
            IgnoreVehicles = 1 << 1,
            IgnoreCamera = 1 << 2,
            IgnoreHugeVehicles = 1 << 3
        }

        public enum SoftCeilingType : short
        {
            Acceleration,
            SoftKill,
            SlipSurface
        }

        [TagStructure(Size = 0xC)]
        public class SoftCeiling
        {
            public SoftCeilingFlags Flags;
            public SoftCeilingFlags RuntimeFlags;
            public StringId Name;
            public SoftCeilingType Type;
            [TagField(Padding = true, Length = 2)]
            public byte[] Unused;
        }

        [TagStructure(Size = 0x60)]
        public class PlayerStartingProfileBlock
        {
            [TagField(Length = 32)]
            public string Name;
            public float StartingHealthDamage;
            public float StartingShieldDamage;
            public CachedTagInstance PrimaryWeapon;
            public short PrimaryRoundsLoaded;
            public short PrimaryRoundsTotal;
            public CachedTagInstance SecondaryWeapon;
            public short SecondaryRoundsLoaded;
            public short SecondaryRoundsTotal;
            public uint Unknown;
            public uint Unknown2;
            public byte StartingFragGrenadeCount;
            public byte StartingPlasmaGrenadeCount;
            public byte StartingSpikeGrenadeCount;
            public byte StartingFirebombGrenadeCount;
            public short Unknown3;
            public short Unknown4;
        }

        [Flags]
        public enum PlayerStartingLocationFlags : ushort
        {
            None = 0,
            SurvivalMode = 1 << 0,
            SurvivalModeElite = 1 << 1
        }

        [TagStructure(Size = 0x1C)]
        public class PlayerStartingLocation
        {
            public RealPoint3d Position;
            public Angle Facing;
            public Angle Pitch;
            public short InsertionPointIndex;
            public PlayerStartingLocationFlags Flags;
            public short EditorFolderIndex;
            [TagField(Padding = true, Length = 2)]
            public byte[] Unused;
        }

        public enum TriggerVolumeType : short
        {
            BoundingBox,
            Sector
        }

        [TagStructure(Size = 0x7C)]
        public class TriggerVolume
        {
            public StringId Name;
            public short ObjectName;
            public short RuntimeNodeIndex;
            public StringId NodeName;
            public TriggerVolumeType Type;
            [TagField(Padding = true, Length = 2)]
            public byte[] Unused;
            public RealVector3d Forward;
            public RealVector3d Up;
            public RealPoint3d Position;
            public RealPoint3d Extents;
            public float ZSink;
            public List<SectorPoint> SectorPoints;
            public List<RuntimeTriangle> RuntimeTriangles;
            public Bounds<float> RuntimeSectorXBounds;
            public Bounds<float> RuntimeSectorYBounds;
            public Bounds<float> RuntimeSectorZBounds;
            public float C;
            public short KillVolume;
            public short EditorFolderIndex;

            [TagStructure(Size = 0x14)]
            public class SectorPoint
            {
                public RealPoint3d Position;
                public RealEulerAngles2d Normal;
            }

            [TagStructure(Size = 0x50)]
            public class RuntimeTriangle
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
            }
        }

        [TagStructure(Size = 0x14)]
        public class UnknownBlock
        {
            public uint Unknown;
            public uint Unknown2;
            public uint Unknown3;
            public uint Unknown4;
            public uint Unknown5;
        }

        [TagStructure(Size = 0x24)]
        public class Decal
        {
            public short DecalPaletteIndex;
            public sbyte Yaw;
            public sbyte Pitch;
            public RealQuaternion Rotation;
            public RealPoint3d Position;
            public float Scale;
        }

        [TagStructure(Size = 0x10)]
        public class DecalPaletteBlock
        {
            public CachedTagInstance Decal;
        }

        [TagStructure(Size = 0x10)]
        public class StylePaletteBlock
        {
            public CachedTagInstance Style;
        }

        [TagStructure(Size = 0x28)]
        public class SquadGroup
        {
            [TagField(Length = 32)]
            public string Name;
            public short ParentIndex;
            public short InitialObjective;
            [TagField(Padding = true, Length = 2)]
            public byte[] Unused;
            public short EditorFolderIndex;
        }

        [Flags]
        public enum SquadFlags : int
        {
            None = 0,
            Bit0 = 1 << 0,
            Blind = 1 << 1,
            Deaf = 1 << 2,
            Braindead = 1 << 3,
            InitiallyPlaced = 1 << 4,
            UnitsNotEnterableByPlayer = 1 << 5,
            FireteamAbsorber = 1 << 6,
            SquadIsRuntime = 1 << 7,
            NoWaveSpawn = 1 << 8,
            SquadIsMusketeer = 1 << 9
        }

        public enum SquadTeam : short
        {
            Default,
            Player,
            Human,
            Covenant,
            Flood,
            Sentinel,
            Heretic,
            Prophet,
            Guilty,
            Unused9,
            Unused10,
            Unused11,
            Unused12,
            Unused13,
            Unused14,
            Unused15,
        }

        [Flags]
        public enum SquadDifficultyFlags : ushort
        {
            None = 0,
            Easy = 1 << 0,
            Normal = 1 << 1,
            Heroic = 1 << 2,
            Legendary = 1 << 3
        }

        public enum SquadMovementMode : short
        {
            Default,
            Climbing,
            Flying
        }

        public enum SquadPatrolMode : short
        {
            PingPong,
            Loop,
            Random
        }

        public enum SquadActivity : short
        {
            None,
            Patrol,
            Stand,
            Crouch,
            StandDrawn,
            CrouchDrawn,
            Combat,
            Backup,
            Guard,
            GuardCrouch,
            GuardWall,
            Typing,
            Kneel,
            Gaze,
            Poke,
            Sniff,
            Track,
            Watch,
            Examine,
            Sleep,
            AtEase,
            Cower,
            TaiChi,
            Pee,
            Doze,
            Eat,
            Medic,
            Work,
            Cheering,
            Injured,
            Captured
        }

        [Flags]
        public enum SquadPointFlags : ushort
        {
            None = 0,
            SingleUse = 1 << 0
        }

        [TagStructure(Size = 0x38)]
        public class SquadPoint
        {
            public short PointIndex;
            public SquadPointFlags Flags;
            public float Delay;
            public float AngleDegrees;
            public StringId ActivityName;
            public SquadActivity Activity;
            public short ActivityVariant;
            [TagField(Length = 32)]
            public string CommandScriptName;
            public short CommandScriptIndex;
            [TagField(Padding = true, Length = 2)]
            public byte[] Unused;
        }

        public enum SquadSeatType : short
        {
            Default,
            Passenger,
            Gunner,
            Driver,
            OutOfVehicle,
            VehicleOnly = 6,
            Passenger2
        }

        public enum SquadGrenadeType : short
        {
            None,
            Frag,
            Plasma,
            Spike,
            Fire
        }

        [TagStructure(Size = 0x68)]
        public class Squad
        {
            [TagField(Length = 32)]
            public string Name;
            public SquadFlags Flags;
            public SquadTeam Team;
            public short ParentSquadGroupIndex;
            public short InitialZoneIndex;
            public short InitialObjectiveIndex;
            public short InitialTaskIndex;
            public short EditorFolderIndex;
            public List<SpawnFormation> SpawnFormations;
            public List<SpawnPoint> SpawnPoints;
            public StringId ModuleId;
            [TagField(Flags = TagFieldFlags.Short)]
            public CachedTagInstance SquadTemplate;
            public List<Cell> DesignerCells;
            public List<Cell> TemplatedCells;

            [TagStructure(Size = 0x6C)]
            public class SpawnFormation
            {
                public SquadDifficultyFlags DifficultyFlags;
                [TagField(Padding = true, Length = 2)]
                public byte[] Unused;
                public uint Unknown3;
                public uint Unknown4;
                public StringId Name;
                public RealPoint3d Position;
                public short ReferenceFrameIndex;
                public short ReferenceNavMeshIndex;
                public RealEulerAngles3d Facing;
                public StringId FormationType;
                public uint InitialMovementDistance;
                public SquadMovementMode InitialMovementMode;
                public short PlacementScriptIndex;
                [TagField(Length = 32)]
                public string PlacementScriptName;
                public StringId InitialState;
                public short PointSetIndex;
                public SquadPatrolMode PatrolMode;
                public List<SquadPoint> Points;
            }

            public enum SpawnPointFlags : ushort
            {
                None = 0,
                InfectionFormExplode = 1 << 0,
                Nothing = 1 << 2,
                AlwaysPlace = 1 << 3,
                InitiallyHidden = 1 << 4,
                VehicleDestroyedWhenNoDriver = 1 << 5,
                VehicleOpen = 1 << 6,
                ActorSurfaceEmerge = 1 << 7,
                ActorSurfaceEmergeAuto = 1 << 8,
                ActorSurfaceEmergeUpwards = 1 << 9
            }

            [TagStructure(Size = 0x90)]
            public class SpawnPoint
            {
                public SquadDifficultyFlags DifficultyFlags;
                [TagField(Padding = true, Length = 2)]
                public byte[] Unused1;
                public uint Unknown3;
                public uint Unknown4;
                public StringId Name;
                public short CellIndex;
                [TagField(Padding = true, Length = 2)]
                public byte[] Unused2;
                public RealPlane3d Position;
                public short ReferenceFrameIndex;
                public short ReferenceNavMeshIndex;
                public RealEulerAngles3d Facing;
                public SpawnPointFlags Flags;
                public short CharacterTypeIndex;
                public short InitialPrimaryWeaponIndex;
                public short InitialSecondaryWeaponIndex;
                public short InitialEquipmentIndex;
                public short VehicleTypeIndex;
                public SquadSeatType SeatType;
                public SquadGrenadeType InitialGrenades;
                public short SwamCount;
                [TagField(Padding = true, Length = 2)]
                public byte[] Unused3;
                public StringId ActorVariantName;
                public StringId VehicleVariantName;
                public float InitialMovementDistance;
                public SquadMovementMode InitialMovementMode;
                public short EmitterVehicleIndex;
                public short EmitterGiantIndex;
                public short EmitterBipedIndex;
                [TagField(Length = 32)]
                public string CommandScriptName;
                public short CommandScriptIndex;
                [TagField(Padding = true, Length = 2)]
                public byte[] Unused4;
                public StringId ActivityName;
                public short PointSetIndex;
                public SquadPatrolMode PatrolMode;
                public List<SquadPoint> Points;
            }

            [TagStructure(Size = 0x84)]
            public class Cell
            {
                public StringId Name;
                public SquadDifficultyFlags DifficultyFlags;
                [TagField(Padding = true, Length = 2)]
                public byte[] Unused;
                public short MinimumRound;
                public short MaximumRound;
                public short Unknown2;
                public short Unknown3;
                public short Count;
                public short Unknown4;
                public List<CharacterTypeBlock> CharacterType;
                public List<Weapon> InitialWeapon;
                public List<SecondaryWeapon> InitialSecondaryWeapon;
                public List<EquipmentBlock> InitialEquipment;
                public SquadGrenadeType GrenadeType;
                public short VehicleTypeIndex;
                public StringId VehicleVariant;
                public uint Unknown6;
                public uint Unknown7;
                public uint Unknown8;
                public uint Unknown9;
                public uint Unknown10;
                public uint Unknown11;
                public uint Unknown12;
                public uint Unknown13;
                public short Unknown14;
                public short Unknown15;
                public uint Unknown16;
                public short Unknown17;
                public short Unknown18;
                public uint Unknown19;
                public uint Unknown20;
                public uint Unknown21;

                [TagStructure(Size = 0x10)]
                public class CharacterTypeBlock
                {
                    public SquadDifficultyFlags DifficultyFlags;
                    [TagField(Padding = true, Length = 2)]
                    public byte[] Unused;
                    public short MinimumRound;
                    public short MaximumRound;
                    public uint Unknown3;
                    public short CharacterTypeIndex;
                    public short Chance;
                }

                [TagStructure(Size = 0x10)]
                public class Weapon
                {
                    public short Unknown;
                    public short Unknown2;
                    public short MinimumRound;
                    public short MaximumRound;
                    public uint Unknown3;
                    public short Weapon2;
                    public short Probability;
                }

                [TagStructure(Size = 0x10)]
                public class SecondaryWeapon
                {
                    public short Unknown;
                    public short Unknown2;
                    public short MinimumRound;
                    public short MaximumRound;
                    public uint Unknown3;
                    public short Weapon;
                    public short Probability;
                }

                [TagStructure(Size = 0x10)]
                public class EquipmentBlock
                {
                    public short Unknown;
                    public short Unknown2;
                    public short MinimumRound;
                    public short MaximumRound;
                    public uint Unknown3;
                    public short Equipment;
                    public short Probability;
                }
            }
        }

        [TagStructure(Size = 0x3C)]
        public class Zone
        {
            [TagField(Length = 32)]
            public string Name;
            public int Unknown;
            public List<FiringPosition> FiringPositions;
            public List<Area> Areas;

            [TagStructure(Size = 0x28)]
            public class FiringPosition
            {
                public float PositionX;
                public float PositionY;
                public float PositionZ;
                public short ReferenceFrame;
                public short Unknown;
                public ushort Flags;
                public short Unknown2;
                public short AreaIndex;
                public short ClusterIndex;
                public short Unknown3;
                public short Unknown4;
                public Angle NormalY;
                public Angle NormalP;
                public uint Unknown5;
            }

            [TagStructure(Size = 0xA8)]
            public class Area
            {
                [TagField(Length = 32)]
                public string Name;
                public uint AreaFlags;
                public float PositionX;
                public float PositionY;
                public float PositionZ;
                public int Unknown;
                public uint Unknown2;
                public short FiringPositionStartIndex;
                public short FiringPositionCount;
                public short Unknown3;
                public short Unknown4;
                public int Unknown5;
                public uint Unknown6;
                public uint Unknown7;
                public uint Unknown8;
                public uint Unknown9;
                public uint Unknown10;
                public uint Unknown11;
                public short ManualReferenceFrame;
                public short Unknown12;
                public List<FlightHint> FlightHints;
                public List<UnknownBlock> Unknown13;
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

                [TagStructure(Size = 0x8)]
                public class FlightHint
                {
                    public short FlightHintIndex;
                    public short PoitIndex;
                    public uint Unknown;
                }

                [TagStructure(Size = 0x18)]
                public class UnknownBlock
                {
                    public float PositionX;
                    public float PositionY;
                    public float PositionZ;
                    public short Unknown;
                    public short Unknown2;
                    public Angle FacingY;
                    public Angle FacingP;
                }
            }
        }

        [TagStructure(Size = 0x2C)]
        public class UnknownBlock2
        {
            public StringId Unknown;
            public List<UnknownBlock> Unknown2;
            public List<UnknownBlock2_2> Unknown3;
            public List<UnknownBlock3> Unknown4;
            public uint Unknown5;

            [TagStructure(Size = 0x4)]
            public class UnknownBlock
            {
                public uint Unknown;
            }

            [TagStructure(Size = 0x14)]
            public class UnknownBlock2_2
            {
                public uint Unknown;
                public uint Unknown2;
                public uint Unknown3;
                public uint Unknown4;
                public uint Unknown5;
            }

            [TagStructure(Size = 0x10)]
            public class UnknownBlock3
            {
                public uint Unknown;
                public List<UnknownBlock> Unknown2;

                [TagStructure(Size = 0x14)]
                public class UnknownBlock
                {
                    public uint Unknown;
                    public uint Unknown2;
                    public uint Unknown3;
                    public uint Unknown4;
                    public uint Unknown5;
                }
            }
        }

        [TagStructure(Size = 0x10)]
        public class CharacterPaletteBlock
        {
            public CachedTagInstance Character;
        }

        [TagStructure(Size = 0x6C)]
        public class AiPathfindingDatum
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
            public uint Unknown13;
            public uint Unknown14;
            public uint Unknown15;
            public uint Unknown16;
            public uint Unknown17;
            public uint Unknown18;
            public uint Unknown19;
            public uint Unknown20;
            public uint Unknown21;
            public List<UnknownBlock> Unknown22;
            public List<UnknownBlock2> Unknown23;

            [TagStructure(Size = 0x18)]
            public class UnknownBlock
            {
                public uint Unknown;
                public uint Unknown2;
                public uint Unknown3;
                public uint Unknown4;
                public uint Unknown5;
                public uint Unknown6;
            }

            [TagStructure(Size = 0xC)]
            public class UnknownBlock2
            {
                public uint Unknown;
                public uint Unknown2;
                public uint Unknown3;
            }
        }

        [TagStructure(Size = 0x84)]
        public class ScriptingDatum
        {
            public List<PointSet> PointSets;
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

            [TagStructure(Size = 0x38)]
            public class PointSet
            {
                [TagField(Length = 32)]
                public string Name;
                public List<Point> Points;
                public short BspIndex;
                public short ManualReferenceFrame;
                public uint Flags;
                public short EditorFolderIndex;
                public short Unknown;

                [TagStructure(Size = 0x3C)]
                public class Point
                {
                    [TagField(Length = 32)]
                    public string Name;
                    public RealPoint3d Position;
                    public short ReferenceFrame;
                    public short Unknown;
                    public int SurfaceIndex;
                    public RealEulerAngles2d FacingDirection;
                }
            }
        }

        [TagStructure(Size = 0x20)]
        public class CutsceneFlag
        {
            public uint Unknown;
            public StringId Name;
            public RealPoint3d Position;
            public RealEulerAngles2d Facing;
            public short EditorFolderIndex;
            public short Unknown2;
        }

        public enum CutsceneCameraPointType : short
        {
            Normal,
            IgnoreTargetOrientation,
            Dolly,
            IgnoreTargetUpdates
        }

        [Flags]
        public enum CutsceneCameraPointFlags : ushort
        {
            None = 0,
            Bit0 = 1 << 0,
            PrematchCameraHack = 1 << 1,
            PodiumCameraHack = 1 << 2,
            Bit3 = 1 << 3,
            Bit4 = 1 << 4,
            Bit5 = 1 << 5,
            Bit6 = 1 << 6,
            Bit7 = 1 << 7,
            Bit8 = 1 << 8,
            Bit9 = 1 << 9,
            Bit10 = 1 << 10,
            Bit11 = 1 << 11,
            Bit12 = 1 << 12,
            Bit13 = 1 << 13,
            Bit14 = 1 << 14,
            Bit15 = 1 << 15
        }

        [TagStructure(Size = 0x40)]
        public class CutsceneCameraPoint
        {
            public CutsceneCameraPointFlags Flags;
            public CutsceneCameraPointType Type;
            [TagField(Length = 32)]
            public string Name;
            public int Unknown;
            public RealPoint3d Position;
            public RealEulerAngles3d Orientation;
        }

        public enum CutsceneTitleHorizontalJustification : short
        {
            Left,
            Right,
            Center
        }

        public enum CutsceneTitleVerticalJustification : short
        {
            Bottom,
            Top,
            Middle,
            Bottom2,
            Top2
        }

        [TagStructure(Size = 0x28)]
        public class CutsceneTitle
        {
            public StringId Name;
            public short TextBoundsTop;
            public short TextBoundsLeft;
            public short TextBoundsBottom;
            public short TextBoundsRight;
            public CutsceneTitleHorizontalJustification HorizontalJustification;
            public CutsceneTitleVerticalJustification VerticalJustification;
            public short Font;
            public short Unknown;
            public byte TextColorA;
            public byte TextColorR;
            public byte TextColorG;
            public byte TextColorB;
            public byte ShadowColorA;
            public byte ShadowColorR;
            public byte ShadowColorG;
            public byte ShadowColorB;
            public float FadeInTime;
            public float Uptime;
            public float FadeOutTime;
        }

        [TagStructure(Size = 0x28)]
        public class ScenarioResource
        {
            public int Unknown;
            public List<CachedTagInstance> ScriptSource;
            public List<CachedTagInstance> AiResources;
            public List<Reference> References;
            
            [TagStructure(Size = 0x16C)]
            public class Reference
            {
                public CachedTagInstance SceneryResource;
                public List<CachedTagInstance> OtherScenery;
                public CachedTagInstance BipedsResource;
                public List<CachedTagInstance> OtherBipeds;
                public CachedTagInstance VehiclesResource;
                public CachedTagInstance EquipmentResource;
                public CachedTagInstance WeaponsResource;
                public CachedTagInstance SoundSceneryResource;
                public CachedTagInstance LightsResource;
                public CachedTagInstance DevicesResource;
                public List<CachedTagInstance> OtherDevices;
                public CachedTagInstance EffectSceneryResource;
                public CachedTagInstance DecalsResource;
                public List<CachedTagInstance> OtherDecals;
                public CachedTagInstance CinematicsResource;
                public CachedTagInstance TriggerVolumesResource;
                public CachedTagInstance ClusterDataResource;
                public CachedTagInstance CommentsResource;
                public CachedTagInstance CreatureResource;
                public CachedTagInstance StructureLightingResource;
                public CachedTagInstance DecoratorsResource;
                public List<CachedTagInstance> OtherDecorators;
                public CachedTagInstance SkyReferencesResource;
                public CachedTagInstance CubemapResource;
            }
        }

        [TagStructure(Size = 0xC)]
        public class UnitSeatsMappingBlock
        {
            [TagField(Flags = TagFieldFlags.Short)]
            public CachedTagInstance Unit;
            public uint Seats;
            public uint Seats2;
        }

        [TagStructure(Size = 0x2)]
        public class ScenarioKillTrigger
        {
            public short TriggerVolume;
        }

        [TagStructure(Size = 0x2)]
        public class ScenarioSafeTrigger
        {
            public short TriggerVolume;
        }

        [TagStructure(Size = 0x58)]
        public class BackgroundSoundEnvironmentPaletteBlock
        {
            public StringId Name;
            public CachedTagInstance SoundEnvironment;
            public int Unknown;
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

        [TagStructure(Size = 0x78)]
        public class UnknownBlock3
        {
            [TagField(Length = 32)]
            public string Name;
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
        }

        [TagStructure(Size = 0x8)]
        public class FogBlock
        {
            public StringId Name;
            public short Unknown;
            public short Unknown2;
        }

        [TagStructure(Size = 0x30)]
        public class CameraFxBlock
        {
            public StringId Name;
            public CachedTagInstance CameraFx;
            public uint Unknown;
            public uint Unknown2;
            public uint Unknown3;
            public uint Unknown4;
            public uint Unknown5;
            public uint Unknown6;
            public uint Unknown7;
        }

        [TagStructure(Size = 0x68, MaxVersion = CacheVersion.HaloOnline449175)]
        [TagStructure(Size = 0x74, MinVersion = CacheVersion.HaloOnline498295)]
        public class ScenarioClusterDatum
        {
            public CachedTagInstance Bsp;
            public List<BackgroundSoundEnvironment> BackgroundSoundEnvironments;
            public List<UnknownBlock> Unknown;
            public List<UnknownBlock2> Unknown2;
            public int BspChecksum;
            public List<ClusterCentroid> ClusterCentroids;
            public List<UnknownBlock3> Unknown3;
            public List<FogBlock> Fog;
            public List<CameraEffect> CameraEffects;
            [MinVersion(CacheVersion.HaloOnline498295)]
            public List<UnknownBlock4> Unknown4;

            [TagStructure(Size = 0x4)]
            public class BackgroundSoundEnvironment
            {
                public short BackgroundSoundEnvironmentIndex;
                public short Unknown;
            }

            [TagStructure(Size = 0x4)]
            public class UnknownBlock
            {
                public short Unknown;
                public short Unknown2;
            }

            [TagStructure(Size = 0x4)]
            public class UnknownBlock2
            {
                public short Unknown;
                public short Unknown2;
            }

            [TagStructure(Size = 0xC)]
            public class ClusterCentroid
            {
                public RealPoint3d Centroid;
            }

            [TagStructure(Size = 0x4)]
            public class UnknownBlock3
            {
                public short Unknown;
                public short Unknown2;
            }

            [TagStructure(Size = 0x4)]
            public class FogBlock
            {
                public short FogIndex;
                public short Unknown;
            }

            [TagStructure(Size = 0x4)]
            public class CameraEffect
            {
                public short CameraEffectIndex;
                public short Unknown;
            }

            [TagStructure(Size = 0x4)]
            public class UnknownBlock4
            {
                public short Unknown;
                public short Unknown2;
            }
        }

        [TagStructure(Size = 0x6C)]
        public class SpawnDatum
        {
            public Bounds<float> DynamicSpawnHeightBounds;
            public float GameObjectResetHeight;
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
            public uint Unknown13;
            public uint Unknown14;
            public uint Unknown15;
            public List<DynamicSpawnOverload> DynamicSpawnOverloads;
            public List<StaticRespawnZone> StaticRespawnZones;
            public List<StaticInitialSpawnZone> StaticInitialSpawnZones;

            [TagStructure(Size = 0x10)]
            public class DynamicSpawnOverload
            {
                public short OverloadType;
                public short Unknown;
                public float InnerRadius;
                public float OuterRadius;
                public float Weight;
            }

            [Flags]
            public enum RelevantTeamFlags : int
            {
                None = 0,
                Red = 1 << 0,
                Blue = 1 << 1,
                Green = 1 << 2,
                Orange = 1 << 3,
                Purple = 1 << 4,
                Yellow = 1 << 5,
                Brown = 1 << 6,
                Pink = 1 << 7,
                Neutral = 1 << 8
            }

            [TagStructure(Size = 0x30)]
            public class StaticRespawnZone
            {
                public StringId Name;
                public RelevantTeamFlags RelevantTeams;
                public uint RelevantGames;
                public uint Flags;
                public RealPoint3d Position;
                public Bounds<float> HeightBounds;
                public Bounds<float> RadiusBounds;
                public float Weight;
            }

            [TagStructure(Size = 0x30)]
            public class StaticInitialSpawnZone
            {
                public StringId Name;
                public RelevantTeamFlags RelevantTeams;
                public uint RelevantGames;
                public uint Flags;
                public RealPoint3d Position;
                public Bounds<float> HeightBounds;
                public Bounds<float> RadiusBounds;
                public float Weight;
            }
        }

        [TagStructure(Size = 0xB4)]
        public class Crate
        {
            public short PaletteIndex;
            public short NameIndex;
            public uint PlacementFlags;
            public RealPoint3d Position;
            public RealEulerAngles3d Rotation;
            public float Scale;
            public List<UnknownBlock> Unknown;
            public short Unknown2;
            public ushort OldManualBspFlagsNowZonesets;
            public StringId UniqueName;
            public ushort UniqueIdSalt;
            public ushort UniqueIdIndex;
            public short OriginBspIndex;
            [MaxVersion(CacheVersion.HaloOnline449175)]
            public GameObjectTypeOld ObjectTypeOld;
            [MinVersion(CacheVersion.HaloOnline498295)]
            public GameObjectTypeNew ObjectTypeNew;
            public SourceValue Source;
            public BspPolicyValue BspPolicy;
            public sbyte Unknown3;
            public short EditorFolderIndex;
            public short Unknown4;
            public short ParentNameIndex;
            public StringId ChildName;
            public StringId Unknown5;
            public ushort AllowedZonesets;
            public short Unknown6;
            public StringId Variant;
            public byte ActiveChangeColors;
            public sbyte Unknown7;
            public sbyte Unknown8;
            public sbyte Unknown9;
            public byte PrimaryColorA;
            public byte PrimaryColorR;
            public byte PrimaryColorG;
            public byte PrimaryColorB;
            public byte SecondaryColorA;
            public byte SecondaryColorR;
            public byte SecondaryColorG;
            public byte SecondaryColorB;
            public byte TertiaryColorA;
            public byte TertiaryColorR;
            public byte TertiaryColorG;
            public byte TertiaryColorB;
            public byte QuaternaryColorA;
            public byte QuaternaryColorR;
            public byte QuaternaryColorG;
            public byte QuaternaryColorB;
            public uint Unknown10;
            public uint Unknown11;
            public List<UnknownBlock2> Unknown12;
            public SymmetryValue Symmetry;
            public ushort EngineFlags;
            public TeamValue Team;
            public sbyte SpawnSequence;
            public sbyte RuntimeMinimum;
            public sbyte RuntimeMaximum;
            public byte MultiplayerFlags;
            public short SpawnTime;
            public short UnknownSpawnTime;
            public sbyte Unknown13;
            public ShapeValue Shape;
            public sbyte TeleporterChannel;
            public sbyte Unknown14;
            public short Unknown15;
            public short AttachedNameIndex;
            public uint Unknown16;
            public uint Unknown17;
            public float WidthRadius;
            public float Depth;
            public float Top;
            public float Bottom;
            public uint Unknown18;

            [TagStructure(Size = 0x1C)]
            public class UnknownBlock
            {
                public short NodeCount;
                public short Unknown;
                public List<UnknownBlock2> Unknown2;
                public List<UnknownBlock3> Unknown3;

                [TagStructure(Size = 0x1)]
                public class UnknownBlock2
                {
                    public byte Unknown;
                }

                [TagStructure(Size = 0x2)]
                public class UnknownBlock3
                {
                    public short Unknown;
                }
            }

            public enum SourceValue : sbyte
            {
                Structure,
                Editor,
                Dynamic,
                Legacy
            }

            public enum BspPolicyValue : sbyte
            {
                Default,
                AlwaysPlaced,
                ManualBspIndex
            }

            [TagStructure(Size = 0x4)]
            public class UnknownBlock2
            {
                public uint Unknown;
            }

            public enum SymmetryValue : int
            {
                Both,
                Symmetric,
                Asymmetric
            }

            public enum TeamValue : short
            {
                Red,
                Blue,
                Green,
                Orange,
                Purple,
                Yellow,
                Brown,
                Pink,
                Neutral
            }

            public enum ShapeValue : sbyte
            {
                None,
                Sphere,
                Cylinder,
                Box
            }
        }

        [TagStructure(Size = 0x30)]
        public class CratePaletteBlock
        {
            public CachedTagInstance Crate;
            public uint Unknown;
            public uint Unknown2;
            public uint Unknown3;
            public uint Unknown4;
            public uint Unknown5;
            public uint Unknown6;
            public uint Unknown7;
            public uint Unknown8;
        }
        
        [TagStructure(Size = 0x48)]
        public class Flock
        {
            public StringId Name;
            public short FlockPaletteIndex;
            public short BspIndex;
            public short BoundingTriggerVolume;
            public ushort Flags;
            public float EcologyMargin;
            public List<Source> Sources;
            public List<Sink> Sinks;
            public Bounds<float> ProductionFrequencyBounds;
            public Bounds<float> ScaleBounds;
            public uint Unknown;
            public uint Unknown2;
            public short CreaturePaletteIndex;
            public Bounds<short> BoidCountBounds;
            public short Unknown3;

            [TagStructure(Size = 0x24)]
            public class Source
            {
                public int Unknown;
                public RealPoint3d Position;
                public RealEulerAngles2d Starting;
                public float Radius;
                public float Weight;
                public sbyte Unknown2;
                public sbyte Unknown3;
                public sbyte Unknown4;
                public sbyte Unknown5;
            }

            [TagStructure(Size = 0x10)]
            public class Sink
            {
                public RealPoint3d Position;
                public float Radius;
            }
        }

        [TagStructure(Size = 0x30)]
        public class CreaturePaletteBlock
        {
            public CachedTagInstance Creature;
            public uint Unknown;
            public uint Unknown2;
            public uint Unknown3;
            public uint Unknown4;
            public uint Unknown5;
            public uint Unknown6;
            public uint Unknown7;
            public uint Unknown8;
        }

        [TagStructure(Size = 0x104)]
        public class EditorFolder
        {
            public int ParentFolder;
            [TagField(Length = 256)]
            public string Name;
        }
        
        [TagStructure(Size = 0x24)]
        public class Interpolator
        {
            public StringId Name;
            public StringId AcceleratorName;
            public StringId MultiplierName;
            public byte[] Function;
            public short Unknown;
            public short Unknown2;
        }

        [TagStructure(Size = 0x4)]
        public class SimulationDefinitionTableBlock
        {
            [TagField(Flags = TagFieldFlags.Short)]
            public CachedTagInstance Tag;
        }

        [TagStructure(Size = 0x10)]
        public class UnknownBlock4
        {
            public short Unknown;
            public short Unknown2;
            public short Unknown3;
            public short Unknown4;
            public short Unknown5;
            public short Unknown6;
            public short Unknown7;
            public short Unknown8;
        }

        [TagStructure(Size = 0x14)]
        public class AiObjective
        {
            public StringId Name;
            public short Zone;
            public short Unknown;
            public List<Role> Roles;

            [TagStructure(Size = 0xCC)]
            public class Role
            {
                public short Unknown;
                public short Unknown2;
                public short Unknown3;
                public short Unknown4;
                public short Unknown5;
                public short Unknown6;
                public uint Unknown7;
                [TagField(Length = 32)]
                public string CommandScriptName1;
                [TagField(Length = 32)]
                public string CommandScriptName2;
                [TagField(Length = 32)]
                public string CommandScriptName3;
                public short CommandScriptIndex1;
                public short CommandScriptIndex2;
                public short CommandScriptIndex3;
                public short Unknown8;
                public short Unknown9;
                public short Unknown10;
                public List<Unknown84Block> Unknown84;
                public StringId Task;
                public short HierarchyLevelFrom100;
                public short PreviousRole;
                public short NextRole;
                public short ParentRole;
                public List<Condition> Conditions;
                public short ScriptIndex;
                public short Unknown11;
                public short Unknown12;
                public FilterValue Filter;
                public short Min;
                public short Max;
                public short Bodies;
                public short Unknown13;
                public uint Unknown14;
                public List<UnknownBlock> Unknown15;
                public List<PointGeometryBlock> PointGeometry;

                [TagStructure(Size = 0x8)]
                public class Unknown84Block
                {
                    public uint Unknown;
                    public uint Unknown2;
                }

                [TagStructure(Size = 0x124)]
                public class Condition
                {
                    [TagField(Length = 32)]
                    public string Name;
                    [TagField(Length = 256)]
                    public string Condition2;
                    public short Unknown;
                    public short Unknown2;
                }

                public enum FilterValue : short
                {
                    None,
                    Leader,
                    Arbiter = 3,
                    Player,
                    Infantry = 7,
                    Flood = 16,
                    Sentinel,
                    Jackal = 21,
                    Grunt,
                    Marine = 24,
                    FloodCombat,
                    FloodCarrier,
                    Brute = 28,
                    Drone = 30,
                    FloodPureform,
                    Warthog = 34,
                    Wraith = 39,
                    Phantom,
                    BruteChopper = 44,
                }

                [TagStructure(Size = 0xA)]
                public class UnknownBlock
                {
                    public short Unknown;
                    public short Unknown2;
                    public short Unknown3;
                    public short Unknown4;
                    public short Unknown5;
                }

                [TagStructure(Size = 0x20)]
                public class PointGeometryBlock
                {
                    public RealPoint3d Point0;
                    public short ReferenceFrame;
                    public short Unknown;
                    public RealPoint3d Point1;
                    public short ReferenceFrame2;
                    public short Unknown2;
                }
            }
        }

        [TagStructure(Size = 0xBC)]
        public class DesignerZoneset
        {
            public StringId Name;
            public uint Unknown;
            public List<short> Bipeds;
            public List<short> Vehicles;
            public List<short> Weapons;
            public List<short> Equipment;
            public List<short> Scenery;
            public List<short> Machines;
            public List<short> Terminals;
            public List<short> Controls;
            public List<short> Unknown2;
            public List<short> Crates;
            public List<short> Creatures;
            public List<short> Giants;
            public List<short> Unknown3;
            public List<short> Characters;
            public uint Unknown4;
            public uint Unknown5;
            public uint Unknown6;
        }

        [TagStructure(Size = 0x4)]
        public class UnknownBlock5
        {
            public short Unknown;
            public short Unknown2;
        }
        
        [TagStructure(Size = 0x14)]
        public class CinematicLightingBlock
        {
            public StringId Name;
            public CachedTagInstance CinematicLight;
        }

        [TagStructure(Size = 0x1C)]
        public class ScenarioMetagameBlock
        {
            public List<TimeMultiplier> TimeMultipliers;
            public float ParScore;
            public List<SurvivalBlock> Survival;

            [TagStructure(Size = 0x8)]
            public class TimeMultiplier
            {
                public float Time;
                public float Multiplier;
            }

            [TagStructure(Size = 0x8)]
            public class SurvivalBlock
            {
                public short InsertionIndex;
                public short Unknown;
                public float ParScore;
            }
        }

        [TagStructure(Size = 0x18)]
        public class UnknownBlock6
        {
            public uint Unknown;
            public uint Unknown2;
            public uint Unknown3;
            public uint Unknown4;
            public uint Unknown5;
            public uint Unknown6;
        }

        [TagStructure(Size = 0x10)]
        public class UnknownBlock7
        {
            public uint Unknown;
            public uint Unknown2;
            public uint Unknown3;
            public short Unknown4;
            public short Unknown5;
        }
    }

    public enum ScenarioMapType : short
    {
        SinglePlayer,
        Multiplayer,
        MainMenu
    }

    [Flags]
    public enum ScenarioFlags : ushort
    {
        None = 0,
        Bit0 = 1 << 0,
        Bit1 = 1 << 1,
        Bit2 = 1 << 2,
        Bit3 = 1 << 3,
        Bit4 = 1 << 4,
        CharactersUsePreviousMissionWeapons = 1 << 5,
    }
}

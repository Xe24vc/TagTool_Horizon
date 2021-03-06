﻿using System;
using System.Collections.Generic;
using BlamCore.Common;
using BlamCore.Cache.HaloOnline;
using BlamCore.Serialization;
using BlamCore.Cache;

namespace BlamCore.TagDefinitions
{
    [TagStructure(Class = "obje", Size = 0x120)]
    public abstract class GameObject
    {
        [MaxVersion(CacheVersion.HaloOnline449175)]
        public GameObjectTypeOld ObjectTypeOld;

        [MinVersion(CacheVersion.HaloOnline498295)]
        public GameObjectTypeNew ObjectTypeNew;

        [TagField(Padding = true, Length = 1)]
        public byte[] Unused1;

        public GameObjectFlags ObjectFlags;

        public float BoundingRadius;
        public RealPoint3d BoundingOffset;
        public float AccelerationScale;

        public LightmapShadowModeSizeValue LightmapShadowModeSize;
        public SweetenerSizeValue SweetenerSize;
        public WaterDensityValue WaterDensity;

        [TagField(Padding = true, Length = 4)]
        public byte[] Unused2;

        public float DynamicLightSphereRadius;
        public RealPoint3d DynamicLightSphereOffset;

        public StringId DefaultModelVariant;
        public CachedTagInstance Model;

        [MaxVersion(CacheVersion.HaloOnline449175)]
        public CachedTagInstance CrateObject;

        public CachedTagInstance CollisionDamage;

        public List<EarlyMoverProperty> EarlyMoverProperties;

        public CachedTagInstance CreationEffect;
        public CachedTagInstance MaterialEffects;
        public CachedTagInstance ArmorSounds;
        public CachedTagInstance MeleeImpact;

        public List<AiProperty> AiProperties;
        public List<Function> Functions;

        public short HudTextMessageIndex;

        [TagField(Padding = true, Length = 2)]
        public byte[] Unused3;

        public List<Attachment> Attachments;
        public List<Widget> Widgets;
        public List<ChangeColor> ChangeColors;
        public List<NodeMap> NodeMaps;
        public List<MultiplayerObjectProperty> MultiplayerObjectProperties;

        [MinVersion(CacheVersion.HaloOnline498295)]
        public CachedTagInstance SimulationInterpolation;

        [TagField(Padding = true, Length = 12)]
        public byte[] Unused4;

        public List<ModelObjectDatum> ModelObjectData;

        public enum LightmapShadowModeSizeValue : short
        {
            Default,
            Never,
            Always,
            Unknown
        }

        public enum SweetenerSizeValue : sbyte
        {
            Small,
            Medium,
            Large
        }

        public enum WaterDensityValue : sbyte
        {
            Default,
            Least,
            Some,
            Equal,
            More,
            MoreStill,
            LotsMore
        }

        [TagStructure(Size = 0x28)]
        public class EarlyMoverProperty
        {
            public StringId Name;
            public uint Unknown;
            public uint Unknown2;
            public uint Unknown3;
            public uint Unknown4;
            public uint Unknown5;
            public uint Unknown6;
            public uint Unknown7;
            public uint Unknown8;
            public uint Unknown9;
        }

        [TagStructure(Size = 0xC)]
        public class AiProperty
        {
            public uint Flags;
            public StringId AiTypeName;
            public ObjectSizeValue Size;
            public AiDistanceValue LeapJumpSpeed;
        }

        public enum ObjectSizeValue : short
        {
            Default,
            Tiny,
            Small,
            Medium,
            Large,
            Huge,
            Immobile
        }

        public enum AiDistanceValue : short
        {
            None,
            Down,
            Step,
            Crouch,
            Stand,
            Storey,
            Tower,
            Infinite
        }

        [TagStructure(Size = 0x2C)]
        public class Function
        {
            public uint Flags;
            public StringId ImportName;
            public StringId ExportName;
            public StringId TurnOffWith;
            public float MinimumValue;
            public byte[] DefaultFunction;
            public StringId ScaleBy;
        }

        [TagStructure(Size = 0x24)]
        public class Attachment
        {
            public uint AtlasFlags;
            public CachedTagInstance Attachment2;
            public StringId Marker;
            public ChangeColorValue ChangeColor;
            public short Unknown;
            public StringId PrimaryScale;
            public StringId SecondaryScale;

            public enum ChangeColorValue : short
            {
                None,
                Primary,
                Secondary,
                Tertiary,
                Quaternary
            }
        }

        [TagStructure(Size = 0x10)]
        public class Widget
        {
            public CachedTagInstance Type;
        }

        [TagStructure(Size = 0x18)]
        public class ChangeColor
        {
            public List<InitialPermutation> InitialPermutations;
            public List<Function> Functions;

            [TagStructure(Size = 0x20)]
            public class InitialPermutation
            {
                public float Weight;
                public float ColorLowerBoundR;
                public float ColorLowerBoundG;
                public float ColorLowerBoundB;
                public float ColorUpperBoundR;
                public float ColorUpperBoundG;
                public float ColorUpperBoundB;
                public StringId VariantName;
            }

            [TagStructure(Size = 0x20)]
            public class Function
            {
                public uint ScaleFlags;
                public float ColorLowerBoundR;
                public float ColorLowerBoundG;
                public float ColorLowerBoundB;
                public float ColorUpperBoundR;
                public float ColorUpperBoundG;
                public float ColorUpperBoundB;
                public StringId DarkenBy;
                public StringId ScaleBy;
            }
        }

        [TagStructure(Size = 0x1)]
        public class NodeMap
        {
            public sbyte TargetNode;
        }

        [TagStructure(Size = 0xC4)]
        public class MultiplayerObjectProperty
        {
            public ushort EngineFlags;
            public ObjectTypeValue ObjectType;
            public byte TeleporterFlags;
            public sbyte Unknown;
            public byte Flags;
            public ObjectShapeValue Shape;
            public SpawnTimerModeValue SpawnTimerMode;
            public short SpawnTime;
            public short UnknownSpawnTime;
            public float RadiusWidth;
            public float Length;
            public float Top;
            public float Bottom;
            public uint Unknown2;
            public uint Unknown3;
            public uint Unknown4;
            public int Unknown5;
            public int Unknown6;
            public CachedTagInstance ChildObject;
            public int Unknown7;
            public CachedTagInstance ShapeShader;
            public CachedTagInstance UnknownShader;
            public CachedTagInstance Unknown8;
            public CachedTagInstance Unknown9;
            public CachedTagInstance Unknown10;
            public CachedTagInstance Unknown11;
            public CachedTagInstance Unknown12;
            public CachedTagInstance Unknown13;
        }

        public enum ObjectTypeValue : sbyte
        {
            Ordinary,
            Weapon,
            Grenade,
            Projectile,
            Powerup,
            Equipment,
            LightLandVehicle,
            HeavyLandVehicle,
            FlyingVehicle,
            Teleporter2way,
            TeleporterSender,
            TeleporterReceiver,
            PlayerSpawnLocation,
            PlayerRespawnZone,
            HoldSpawnObjective,
            CaptureSpawnObjective,
            HoldDestinationObjective,
            CaptureDestinationObjective,
            HillObjective,
            InfectionHavenObjective,
            TerritoryObjective,
            VipBoundaryObjective,
            VipDestinationObjective,
            JuggernautDestinationObjective,
        }

        public enum SpawnTimerModeValue : sbyte
        {
            DefaultOne,
            Multiple,
        }
        public enum ObjectShapeValue : sbyte
        {
            None,
            Sphere,
            Cylinder,
            Box,
        }

        [TagStructure(Size = 0x14)]
        public class ModelObjectDatum
        {
            public TypeValue Type;
            public short Unknown;
            public float OffsetX;
            public float OffsetY;
            public float OffsetZ;
            public float Radius;

            public enum TypeValue : short
            {
                NotSet,
                UserDefined,
                AutoGenerated,
            }
        }
    }

    public enum GameObjectTypeOld : sbyte
    {
        None = -1,
        Biped,
        Vehicle,
        Weapon,
        Equipment,
        AlternateRealityDevice,
        Terminal,
        Projectile,
        Scenery,
        Machine,
        Control,
        SoundScenery,
        Crate,
        Creature,
        Giant,
        EffectScenery
    }

    public enum GameObjectTypeNew : sbyte
    {
        None = -1,
        Biped,
        Vehicle,
        Weapon,
        Armor, // Why couldn't they have just put Armor at the end...? :(
        Equipment,
        AlternateRealityDevice,
        Terminal,
        Projectile,
        Scenery,
        Machine,
        Control,
        SoundScenery,
        Crate,
        Creature,
        Giant,
        EffectScenery
    }

    [Flags]
    public enum GameObjectFlags : ushort
    {
        None = 0,
        DoesNotCastShadow = 1 << 0,
        SearchCardinalDirectionMaps = 1 << 1,
        Bit2 = 1 << 2,
        NotAPathfindingObstacle = 1 << 3,
        ExtensionOfParent = 1 << 4,
        DoesNotCauseCollisionDamage = 1 << 5,
        EarlyMover = 1 << 6,
        EarlyMoverLocalizedPhysics = 1 << 7,
        UseStaticMassiveLightmapSample = 1 << 8,
        ObjectScalesAttachments = 1 << 9,
        InheritsPlayersAppearance = 1 << 10,
        DeadBipedsCantLocalize = 1 << 11,
        AttachToClustersByDynamicSphere = 1 << 12,
        EffectsDoNotSpawnObjectsInMultiplayer = 1 << 13,
        Bit14 = 1 << 14,
        Bit15 = 1 << 15
    }
}

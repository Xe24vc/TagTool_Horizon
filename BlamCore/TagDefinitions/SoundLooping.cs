using System.Collections.Generic;
using BlamCore.Cache.HaloOnline;
using BlamCore.Common;
using BlamCore.Serialization;

namespace BlamCore.TagDefinitions
{
    [TagStructure(Name = "sound_looping", Class = "lsnd", Size = 0x40)]
    public class SoundLooping
    {
        public uint Flags;
        public float MartySMusicTime;
        public uint Unknown;
        public uint Unknown2;
        public uint Unknown3;
        public CachedTagInstance Unused;
        public SoundClassValue SoundClass;
        public short Unknown4;
        public List<Track> Tracks;
        public List<DetailSound> DetailSounds;

        public enum SoundClassValue : short
        {
            ProjectileImpact,
            ProjectileDetonation,
            ProjectileFlyby,
            ProjectileDetonationLod,
            WeaponFire,
            WeaponReady,
            WeaponReload,
            WeaponEmpty,
            WeaponCharge,
            WeaponOverheat,
            WeaponIdle,
            WeaponMelee,
            WeaponAnimation,
            ObjectImpacts,
            ParticleImpacts,
            WeaponFireLod,
            WeaponFireLodFar,
            Unused2Impacts,
            UnitFootsteps,
            UnitDialog,
            UnitAnimation,
            UnitUnused,
            VehicleCollision,
            VehicleEngine,
            VehicleAnimation,
            VehicleEngineLod,
            DeviceDoor,
            DeviceUnused0,
            DeviceMachinery,
            DeviceStationary,
            DeviceUnused1,
            DeviceUnused2,
            Music,
            AmbientNature,
            AmbientMachinery,
            AmbientStationary,
            HugeAss,
            ObjectLooping,
            CinematicMusic,
            PlayerArmor,
            UnknownUnused1,
            AmbientFlock,
            NoPad,
            NoPadStationary,
            Arg,
            CortanaMission,
            CortanaGravemindChannel,
            MissionDialog,
            CinematicDialog,
            ScriptedCinematicFoley,
            Hud,
            GameEvent,
            Ui,
            Test,
            MultilingualTest,
            AmbientNatureDetails,
            AmbientMachineryDetails,
            InsideSurroundTail,
            OutsideSurroundTail,
            VehicleDetonation,
            AmbientDetonation,
            FirstPersonInside,
            FirstPersonOutside,
            FirstPersonAnywhere,
            UiPda,
        }

        [TagStructure(Size = 0xA0)]
        public class Track
        {
            public StringId Name;
            public uint Flags;
            public float Gain;
            public float FadeInDuration;
            public uint Unknown;
            public float FadeOutDuration;
            public short Unknown2;
            public short Unknown3;
            public CachedTagInstance In;
            public CachedTagInstance Loop;
            public CachedTagInstance Out;
            public CachedTagInstance AlternateLoop;
            public CachedTagInstance AlternateOut;
            public OutputEffectValue OutputEffect;
            public short Unknown4;
            public CachedTagInstance AlternateTransitionIn;
            public CachedTagInstance AlternateTransitionOut;
            public float AlternateCrossfadeDuration;
            public uint Unknown5;
            public float AlternateFadeOutDuration;
            public uint Unknown6;

            public enum OutputEffectValue : short
            {
                None,
                OutputFrontSpeakers,
                OutputRearSpeakers,
                OutputCenterSpeakers,
            }
        }

        [TagStructure(Size = 0x3C)]
        public class DetailSound
        {
            public StringId Name;
            public CachedTagInstance Sound;
            public float RandomPeriodBoundsMin;
            public float RandomPeriodBoundsMax;
            public uint Unknown;
            public uint Flags;
            public Angle YawBoundsMin;
            public Angle YawBoundsMax;
            public Angle PitchBoundsMin;
            public Angle PitchBoundsMax;
            public float DistanceBoundsMin;
            public float DistanceBoundsMax;
        }
    }
}

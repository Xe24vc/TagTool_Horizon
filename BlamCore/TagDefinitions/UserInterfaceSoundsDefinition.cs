using System.Collections.Generic;
using BlamCore.Cache.HaloOnline;
using BlamCore.Common;
using BlamCore.Serialization;

namespace BlamCore.TagDefinitions
{
    [TagStructure(Name = "user_interface_sounds_definition", Class = "uise", Size = 0x150)]
    public class UserInterfaceSoundsDefinition
    {
        public CachedTagInstance Error;
        public CachedTagInstance VerticalNavigation;
        public CachedTagInstance HorizontalNavigation;
        public CachedTagInstance AButton;
        public CachedTagInstance BButton;
        public CachedTagInstance XButton;
        public CachedTagInstance YButton;
        public CachedTagInstance StartButton;
        public CachedTagInstance BackButton;
        public CachedTagInstance LeftBumper;
        public CachedTagInstance RightBumper;
        public CachedTagInstance LeftTrigger;
        public CachedTagInstance RightTrigger;
        public CachedTagInstance TimerSound;
        public CachedTagInstance TimerSoundZero;
        public CachedTagInstance AltTimerSound;
        public CachedTagInstance SecondAltTimerSound;
        public CachedTagInstance MatchmakingAdvanceSound;
        public CachedTagInstance RankUp;
        public CachedTagInstance MatchmakingPartyUpSound;
        public List<AtlasSound> AtlasSounds;
        public uint Unknown;

        [TagStructure(Size = 0x14)]
        public class AtlasSound
        {
            public StringId Name;
            public CachedTagInstance Sound;
        }
    }
}

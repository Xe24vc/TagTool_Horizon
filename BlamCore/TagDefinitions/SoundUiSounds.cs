using System.Collections.Generic;
using BlamCore.Cache.HaloOnline;
using BlamCore.Serialization;

namespace BlamCore.TagDefinitions
{
    [TagStructure(Name = "sound_ui_sounds", Class = "sus!", Size = 0x10)]
    public class SoundUiSounds
    {
        public List<UiSound> UiSounds;
        public uint Unknown;

        [TagStructure(Size = 0x10)]
        public class UiSound
        {
            public CachedTagInstance Sound;
        }
    }
}

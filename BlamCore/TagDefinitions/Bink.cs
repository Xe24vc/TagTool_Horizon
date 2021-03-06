using BlamCore.Cache;
using BlamCore.Cache.HaloOnline;
using BlamCore.Serialization;

namespace BlamCore.TagDefinitions
{
    [TagStructure(Name = "bink", Class = "bink", Size = 0x18, MaxVersion = CacheVersion.HaloOnline571627)]
    [TagStructure(Name = "bink", Class = "bink", Size = 0x14, MinVersion = CacheVersion.HaloOnline700123)]
    public class Bink
    {
        public int FrameCount;
        public ResourceReference Resource;
        public int UselessPadding;
        public uint Unknown;
        public uint Unknown2;

        [MaxVersion(CacheVersion.HaloOnline106708)]
        public uint Unknown3;
    }
}

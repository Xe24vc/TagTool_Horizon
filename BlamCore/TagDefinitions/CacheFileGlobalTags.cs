using System.Collections.Generic;
using BlamCore.Cache.HaloOnline;
using BlamCore.Serialization;

namespace BlamCore.TagDefinitions
{
    [TagStructure(Name = "cache_file_global_tags", Class = "cfgt", Size = 0x10)]
    public class CacheFileGlobalTags
    {
        public List<GlobalTag> GlobalTags;
        public uint Unknown;

        [TagStructure(Size = 0x10)]
        public class GlobalTag
        {
            public CachedTagInstance Tag;
        }
    }
}

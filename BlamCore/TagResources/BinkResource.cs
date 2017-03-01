using BlamCore.Cache.HaloOnline;
using BlamCore.Serialization;

namespace BlamCore.TagResources
{
    [TagStructure(Name = "bink_resource", Size = 0x14)]
    public class BinkResource
    {
        public ResourceDataReference Data;
    }
}

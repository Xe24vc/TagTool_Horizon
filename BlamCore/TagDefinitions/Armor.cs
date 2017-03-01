using BlamCore.Cache;
using BlamCore.Cache.HaloOnline;
using BlamCore.Serialization;

namespace BlamCore.TagDefinitions
{
    [TagStructure(Name = "armor", Class = "armr", Size = 0x28, MinVersion = CacheVersion.HaloOnline430475)]
    public class Armor : GameObject
    {
        public CachedTagInstance ParentModel;
        public CachedTagInstance FirstPersonModel;
        public CachedTagInstance ThirdPersonModel;

        [TagField(Padding = true, Length = 4)]
        public byte[] Unused;
    }
}

using BlamCore.Cache.HaloOnline;
using BlamCore.Serialization;

namespace BlamCore.TagDefinitions
{
    [TagStructure(Name = "wind", Class = "wind", Size = 0x7C)]
    public class Wind
    {
        public byte[] Function;
        public byte[] Function2;
        public byte[] Function3;
        public byte[] Function4;
        public byte[] Function5;
        public uint Unknown;
        public CachedTagInstance WarpBitmap;
        public uint Unknown2;
    }
}

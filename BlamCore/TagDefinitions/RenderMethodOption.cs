using System.Collections.Generic;
using BlamCore.Cache.HaloOnline;
using BlamCore.Common;
using BlamCore.Serialization;

namespace BlamCore.TagDefinitions
{
    [TagStructure(Name = "render_method_option", Class = "rmop", Size = 0x10)]
    public class RenderMethodOption
    {
        public List<UnknownBlock> Unknown;
        public uint Unknown2;

        [TagStructure(Size = 0x48)]
        public class UnknownBlock
        {
            public StringId Type;
            public uint Unknown;
            public uint Unknown2;
            public CachedTagInstance Unknown3;
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
        }
    }
}

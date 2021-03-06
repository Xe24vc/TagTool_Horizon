using System.Collections.Generic;
using BlamCore.Common;
using BlamCore.Serialization;

namespace BlamCore.TagDefinitions
{
    [TagStructure(Name = "achievements", Class = "achi", Size = 0x18)]
    public class Achievements
    {
        public List<AchievementInformationBlock> AchievementInformation;
        public uint Unknown;
        public uint Unknown2;
        public uint Unknown3;

        [TagStructure(Size = 0x18)]
        public class AchievementInformationBlock
        {
            public int Unknown;
            public int Unknown2;
            public StringId LevelName;
            public int Unknown3;
            public int Unknown4;
            public int Unknown5;
        }
    }
}

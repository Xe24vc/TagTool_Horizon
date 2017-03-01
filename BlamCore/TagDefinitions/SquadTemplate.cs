using System.Collections.Generic;
using BlamCore.Cache.HaloOnline;
using BlamCore.Common;
using BlamCore.Serialization;

namespace BlamCore.TagDefinitions
{
    [TagStructure(Name = "squad_template", Class = "sqtm", Size = 0x10)]
    public class SquadTemplate
    {
        public StringId Name;
        public List<CellTemplate> CellTemplates;
        
        [TagStructure(Size = 0x60)]
        public class CellTemplate
        {
            public StringId Name;

            public Scenario.SquadDifficultyFlags DifficultyFlags;

            [TagField(Padding = true, Length = 2)]
            public byte[] Padding1;

            public short MinimumRound;
            public short MaximumRound;
            public short Unknown2;

            public short Unknown3;
            public short Count;
            public short Unknown4;

            public List<CharacterBlock> Characters;
            public List<WeaponBlock> InitialWeapons;
            public List<WeaponBlock> InitialSecondaryWeapons;
            public List<EquipmentBlock> InitialEquipment;

            public Character.GrenadeTypeValue GrenadeType;

            [TagField(Padding = true, Length = 2)]
            public byte[] Padding2;

            public CachedTagInstance Vehicle;
            public StringId VehicleVariant;

            public StringId ActivityName;

            [TagStructure(Size = 0x20)]
            public class CharacterBlock
            {
                public Scenario.SquadDifficultyFlags DifficultyFlags;

                [TagField(Padding = true, Length = 2)]
                public byte[] Padding1;

                public short MinimumRound;
                public short MaximumRound;
                public uint Unknown3;

                public CachedTagInstance Character;
                public short Chance;

                [TagField(Padding = true, Length = 2)]
                public byte[] Padding2;
            }

            [TagStructure(Size = 0x20)]
            public class WeaponBlock
            {
                public Scenario.SquadDifficultyFlags DifficultyFlags;

                [TagField(Padding = true, Length = 2)]
                public byte[] Padding1;

                public short MinimumRound;
                public short MaximumRound;
                public uint Unknown3;

                public CachedTagInstance Weapon;
                public short Probability;

                [TagField(Padding = true, Length = 2)]
                public byte[] Padding2;
            }
            
            [TagStructure(Size = 0x20)]
            public class EquipmentBlock
            {
                public Scenario.SquadDifficultyFlags DifficultyFlags;

                [TagField(Padding = true, Length = 2)]
                public byte[] Padding1;

                public short MinimumRound;
                public short MaximumRound;
                public uint Unknown3;

                public CachedTagInstance Equipment;
                public short Probability;

                [TagField(Padding = true, Length = 2)]
                public byte[] Padding2;
            }
        }
    }
}
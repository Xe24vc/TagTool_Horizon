using BlamCore.Cache.HaloOnline;
using BlamCore.Common;
using BlamCore.Serialization;
using System.Collections.Generic;

namespace HaloOnlineTagTool.TagStructures
{
    [TagStructure(Class = "zone", Size = 0x214)]
    public class CacheFileResourceGestalt
    {
        public MapTypeValue MapType;
        public short Flags;
        public List<ResourceType> ResourceTypes;
        public List<ResourceStructureType> ResourceStructureTypes;
        public List<CompressionCodec> CompressionCodecs;
        public List<ExternalCacheReference> ExternalCacheReferences;
        public List<RawPage> RawPages;
        public List<Size> Sizes;
        public List<Segment> Segments;
        public List<TagResource> TagResources;
        public List<DesignerZoneset> DesignerZonesets;
        public List<GlobalZonesetBlock> GlobalZoneset;
        public uint Unknown;
        public uint Unknown2;
        public uint Unknown3;
        public List<UnattachedZonesetBlock> UnattachedZoneset;
        public List<DiscForbiddenZonesetBlock> DiscForbiddenZoneset;
        public List<DiscAlwaysStreamingZonesetBlock> DiscAlwaysStreamingZoneset;
        public List<BspZoneset> BspZonesets;
        public List<BspZonesets2Block> BspZonesets2;
        public List<BspZonesets3Block> BspZonesets3;
        public List<CinematicZoneset> CinematicZonesets;
        public List<ScenarioZoneset> ScenarioZonesets;
        public uint Unknown4;
        public uint Unknown5;
        public uint Unknown6;
        public uint Unknown7;
        public uint Unknown8;
        public uint Unknown9;
        public List<ScenarioZonesetGroup> ScenarioZonesetGroups;
        public List<ScenarioBsp> ScenarioBsps;
        public uint Unknown10;
        public uint Unknown11;
        public uint Unknown12;
        public uint Unknown13;
        public uint Unknown14;
        public uint Unknown15;
        public uint Unknown16;
        public uint Unknown17;
        public uint Unknown18;
        public byte[] FixupInformation;
        public uint Unknown19;
        public uint Unknown20;
        public uint Unknown21;
        public uint Unknown22;
        public uint Unknown23;
        public List<UnknownBlock> Unknown24;
        public uint Unknown25;
        public uint Unknown26;
        public uint Unknown27;
        public uint Unknown28;
        public uint Unknown29;
        public uint Unknown30;
        public uint Unknown31;
        public uint Unknown32;
        public uint Unknown33;
        public uint Unknown34;
        public uint Unknown35;
        public uint Unknown36;
        public uint Unknown37;
        public uint Unknown38;
        public uint Unknown39;
        public uint Unknown40;
        public uint Unknown41;
        public uint Unknown42;
        public uint Unknown43;
        public uint Unknown44;
        public uint Unknown45;
        public uint Unknown46;
        public uint Unknown47;
        public uint Unknown48;
        public List<PredictionABlock> PredictionA;
        public List<PredictionBBlock> PredictionB;
        public List<PredictionCBlock> PredictionC;
        public List<PredictionDTag> PredictionDTags;
        public List<PredictionD2Tag> PredictionD2Tags;
        public int CampaignId;
        public int MapId;

        public enum MapTypeValue : short
        {
            SinglePlayer,
            Multiplayer,
            MainMenu,
        }

        [TagStructure(Size = 0x1C)]
        public class ResourceType
        {
            [TagField(Count = 16)] public byte[] Guid;
            public short Unknown;
            public short Unknown2;
            public short Unknown3;
            public short Unknown4;
            public StringId Name;
        }

        [TagStructure(Size = 0x14)]
        public class ResourceStructureType
        {
            [TagField(Count = 16)] public byte[] Guid;
            public StringId Name;
        }

        [TagStructure(Size = 0x10)]
        public class CompressionCodec
        {
            [TagField(Count = 16)] public byte[] Guid;
        }

        [TagStructure(Size = 0x108)]
        public class ExternalCacheReference
        {
            [TagField(Length = 256)] public string MapPath;
            public short Unknown;
            public short Unknown2;
            public uint Unknown3;
        }

        [TagStructure(Size = 0x58)]
        public class RawPage
        {
            public short Salt;
            public sbyte Flags;
            public sbyte CompressionCodecIndex;
            public short SharedCacheIndex;
            public short Unknown;
            public int BlockOffset;
            public int CompressedBlockSize;
            public int UncompressedBlockSize;
            public int CrcChecksum;
            [TagField(Count = 20)] public byte[] EntireBufferHash;
            [TagField(Count = 20)] public byte[] FirstChunkHash;
            [TagField(Count = 20)] public byte[] LastChunkHash;
            public short BlockAssetCount;
            public short Unknown2;
        }

        [TagStructure(Size = 0x10)]
        public class Size
        {
            public int OverallSize;
            public List<Part> Parts;

            [TagStructure(Size = 0x8)]
            public class Part
            {
                public int Unknown;
                public int Size;
            }
        }

        [TagStructure(Size = 0x10)]
        public class Segment
        {
            public short PrimaryPageIndex;
            public short SecondaryPageIndex;
            public int PrimarySegmentOffset;
            public int SecondarySegmentOffset;
            public short PrimarySizeIndex;
            public short SecondarySizeIndex;
        }

        [TagStructure(Size = 0x40)]
        public class TagResource
        {
            public CachedTagInstance ParentTag;
            public ushort Salt;
            public byte ResourceTypeIndex;
            public byte Flags;
            public int FixupInformationOffset;
            public int FixupInformationLength;
            public int SecondaryFixupInformationOffset;
            public short Unknown;
            public short PlaySegmentIndex;
            public RootDefinitionAddressLocationHighBitsValue RootDefinitionAddressLocationHighBits;
            public byte RootDefinitionAddressUpperBits;
            public ushort RootDefinitionAddress;
            public List<ResourceFixup> ResourceFixups;
            public List<ResourceDefinitionFixup> ResourceDefinitionFixups;

            public enum RootDefinitionAddressLocationHighBitsValue : byte
            {
                None,
                Bit0,
                Bit1,
                Bit2 = 4,
                Bit3 = 8,
                Bit4 = 16,
                Fixup = 32,
                RawPage = 64,
                Bit7 = 128,
            }

            [TagStructure(Size = 0x8)]
            public class ResourceFixup
            {
                public int BlockOffset;
                public AddressLocationHighBitsValue AddressLocationHighBits;
                public byte AddressUpperBits;
                public ushort Address;

                public enum AddressLocationHighBitsValue : byte
                {
                    None,
                    Bit0,
                    Bit1,
                    Bit2 = 4,
                    Bit3 = 8,
                    Bit4 = 16,
                    Fixup = 32,
                    RawPage = 64,
                    Bit7 = 128,
                }
            }

            [TagStructure(Size = 0x8)]
            public class ResourceDefinitionFixup
            {
                public OffsetLocationHighBitsValue OffsetLocationHighBits;
                public byte OffsetUpperBits;
                public ushort Offset;
                public int ResourceStructureTypeIndex;

                public enum OffsetLocationHighBitsValue : byte
                {
                    None,
                    Bit0,
                    Bit1,
                    Bit2 = 4,
                    Bit3 = 8,
                    Bit4 = 16,
                    Fixup = 32,
                    RawPage = 64,
                    Bit7 = 128,
                }
            }
        }

        [TagStructure(Size = 0x78)]
        public class DesignerZoneset
        {
            public List<RequiredRawPoolBlock> RequiredRawPool;
            public uint Unknown;
            public uint Unknown2;
            public uint Unknown3;
            public List<OptionalRawPoolBlock> OptionalRawPool;
            public List<OptionalRawPool2Block> OptionalRawPool2;
            public uint Unknown4;
            public uint Unknown5;
            public uint Unknown6;
            public uint Unknown7;
            public uint Unknown8;
            public StringId SetName;
            public List<ResourceType> ResourceTypes;
            public List<RequiredTagPoolBlock> RequiredTagPool;
            public List<OptionalTagPoolBlock> OptionalTagPool;
            public uint Unknown9;
            public uint Unknown10;
            public uint Unknown11;

            [TagStructure(Size = 0x4)]
            public class RequiredRawPoolBlock
            {
                public ActiveMembersValue ActiveMembers;

                public enum ActiveMembersValue : int
                {
                    None,
                    _0,
                    _1,
                    _2 = 4,
                    _3 = 8,
                    _4 = 16,
                    _5 = 32,
                    _6 = 64,
                    _7 = 128,
                    _8 = 256,
                    _9 = 512,
                    _10 = 1024,
                    _11 = 2048,
                    _12 = 4096,
                    _13 = 8192,
                    _14 = 16384,
                    _15 = 32768,
                    _16 = 65536,
                    _17 = 131072,
                    _18 = 262144,
                    _19 = 524288,
                    _20 = 1048576,
                    _21 = 2097152,
                    _22 = 4194304,
                    _23 = 8388608,
                    _24 = 16777216,
                    _25 = 33554432,
                    _26 = 67108864,
                    _27 = 134217728,
                    _28 = 268435456,
                    _29 = 536870912,
                    _30 = 1073741824,
                    _31 = -2147483648,
                }
            }

            [TagStructure(Size = 0x4)]
            public class OptionalRawPoolBlock
            {
                public ActiveMembersValue ActiveMembers;

                public enum ActiveMembersValue : int
                {
                    None,
                    _0,
                    _1,
                    _2 = 4,
                    _3 = 8,
                    _4 = 16,
                    _5 = 32,
                    _6 = 64,
                    _7 = 128,
                    _8 = 256,
                    _9 = 512,
                    _10 = 1024,
                    _11 = 2048,
                    _12 = 4096,
                    _13 = 8192,
                    _14 = 16384,
                    _15 = 32768,
                    _16 = 65536,
                    _17 = 131072,
                    _18 = 262144,
                    _19 = 524288,
                    _20 = 1048576,
                    _21 = 2097152,
                    _22 = 4194304,
                    _23 = 8388608,
                    _24 = 16777216,
                    _25 = 33554432,
                    _26 = 67108864,
                    _27 = 134217728,
                    _28 = 268435456,
                    _29 = 536870912,
                    _30 = 1073741824,
                    _31 = -2147483648,
                }
            }

            [TagStructure(Size = 0x4)]
            public class OptionalRawPool2Block
            {
                public ActiveMembersValue ActiveMembers;

                public enum ActiveMembersValue : int
                {
                    None,
                    _0,
                    _1,
                    _2 = 4,
                    _3 = 8,
                    _4 = 16,
                    _5 = 32,
                    _6 = 64,
                    _7 = 128,
                    _8 = 256,
                    _9 = 512,
                    _10 = 1024,
                    _11 = 2048,
                    _12 = 4096,
                    _13 = 8192,
                    _14 = 16384,
                    _15 = 32768,
                    _16 = 65536,
                    _17 = 131072,
                    _18 = 262144,
                    _19 = 524288,
                    _20 = 1048576,
                    _21 = 2097152,
                    _22 = 4194304,
                    _23 = 8388608,
                    _24 = 16777216,
                    _25 = 33554432,
                    _26 = 67108864,
                    _27 = 134217728,
                    _28 = 268435456,
                    _29 = 536870912,
                    _30 = 1073741824,
                    _31 = -2147483648,
                }
            }

            [TagStructure(Size = 0x14)]
            public class ResourceType
            {
                public uint Unknown;
                public uint Unknown2;
                public uint Unknown3;
                public uint Unknown4;
                public uint Unknown5;
            }

            [TagStructure(Size = 0x4)]
            public class RequiredTagPoolBlock
            {
                public ActiveMembersValue ActiveMembers;

                public enum ActiveMembersValue : int
                {
                    None,
                    _0,
                    _1,
                    _2 = 4,
                    _3 = 8,
                    _4 = 16,
                    _5 = 32,
                    _6 = 64,
                    _7 = 128,
                    _8 = 256,
                    _9 = 512,
                    _10 = 1024,
                    _11 = 2048,
                    _12 = 4096,
                    _13 = 8192,
                    _14 = 16384,
                    _15 = 32768,
                    _16 = 65536,
                    _17 = 131072,
                    _18 = 262144,
                    _19 = 524288,
                    _20 = 1048576,
                    _21 = 2097152,
                    _22 = 4194304,
                    _23 = 8388608,
                    _24 = 16777216,
                    _25 = 33554432,
                    _26 = 67108864,
                    _27 = 134217728,
                    _28 = 268435456,
                    _29 = 536870912,
                    _30 = 1073741824,
                    _31 = -2147483648,
                }
            }

            [TagStructure(Size = 0x4)]
            public class OptionalTagPoolBlock
            {
                public ActiveMembersValue ActiveMembers;

                public enum ActiveMembersValue : int
                {
                    None,
                    _0,
                    _1,
                    _2 = 4,
                    _3 = 8,
                    _4 = 16,
                    _5 = 32,
                    _6 = 64,
                    _7 = 128,
                    _8 = 256,
                    _9 = 512,
                    _10 = 1024,
                    _11 = 2048,
                    _12 = 4096,
                    _13 = 8192,
                    _14 = 16384,
                    _15 = 32768,
                    _16 = 65536,
                    _17 = 131072,
                    _18 = 262144,
                    _19 = 524288,
                    _20 = 1048576,
                    _21 = 2097152,
                    _22 = 4194304,
                    _23 = 8388608,
                    _24 = 16777216,
                    _25 = 33554432,
                    _26 = 67108864,
                    _27 = 134217728,
                    _28 = 268435456,
                    _29 = 536870912,
                    _30 = 1073741824,
                    _31 = -2147483648,
                }
            }
        }

        [TagStructure(Size = 0x78)]
        public class GlobalZonesetBlock
        {
            public List<RequiredRawPoolBlock> RequiredRawPool;
            public uint Unknown;
            public uint Unknown2;
            public uint Unknown3;
            public List<OptionalRawPoolBlock> OptionalRawPool;
            public List<OptionalRawPool2Block> OptionalRawPool2;
            public uint Unknown4;
            public uint Unknown5;
            public uint Unknown6;
            public uint Unknown7;
            public uint Unknown8;
            public StringId SetName;
            public List<ResourceType> ResourceTypes;
            public List<RequiredTagPoolBlock> RequiredTagPool;
            public List<OptionalTagPoolBlock> OptionalTagPool;
            public uint Unknown9;
            public uint Unknown10;
            public uint Unknown11;

            [TagStructure(Size = 0x4)]
            public class RequiredRawPoolBlock
            {
                public ActiveMembersValue ActiveMembers;

                public enum ActiveMembersValue : int
                {
                    None,
                    _0,
                    _1,
                    _2 = 4,
                    _3 = 8,
                    _4 = 16,
                    _5 = 32,
                    _6 = 64,
                    _7 = 128,
                    _8 = 256,
                    _9 = 512,
                    _10 = 1024,
                    _11 = 2048,
                    _12 = 4096,
                    _13 = 8192,
                    _14 = 16384,
                    _15 = 32768,
                    _16 = 65536,
                    _17 = 131072,
                    _18 = 262144,
                    _19 = 524288,
                    _20 = 1048576,
                    _21 = 2097152,
                    _22 = 4194304,
                    _23 = 8388608,
                    _24 = 16777216,
                    _25 = 33554432,
                    _26 = 67108864,
                    _27 = 134217728,
                    _28 = 268435456,
                    _29 = 536870912,
                    _30 = 1073741824,
                    _31 = -2147483648,
                }
            }

            [TagStructure(Size = 0x4)]
            public class OptionalRawPoolBlock
            {
                public ActiveMembersValue ActiveMembers;

                public enum ActiveMembersValue : int
                {
                    None,
                    _0,
                    _1,
                    _2 = 4,
                    _3 = 8,
                    _4 = 16,
                    _5 = 32,
                    _6 = 64,
                    _7 = 128,
                    _8 = 256,
                    _9 = 512,
                    _10 = 1024,
                    _11 = 2048,
                    _12 = 4096,
                    _13 = 8192,
                    _14 = 16384,
                    _15 = 32768,
                    _16 = 65536,
                    _17 = 131072,
                    _18 = 262144,
                    _19 = 524288,
                    _20 = 1048576,
                    _21 = 2097152,
                    _22 = 4194304,
                    _23 = 8388608,
                    _24 = 16777216,
                    _25 = 33554432,
                    _26 = 67108864,
                    _27 = 134217728,
                    _28 = 268435456,
                    _29 = 536870912,
                    _30 = 1073741824,
                    _31 = -2147483648,
                }
            }

            [TagStructure(Size = 0x4)]
            public class OptionalRawPool2Block
            {
                public ActiveMembersValue ActiveMembers;

                public enum ActiveMembersValue : int
                {
                    None,
                    _0,
                    _1,
                    _2 = 4,
                    _3 = 8,
                    _4 = 16,
                    _5 = 32,
                    _6 = 64,
                    _7 = 128,
                    _8 = 256,
                    _9 = 512,
                    _10 = 1024,
                    _11 = 2048,
                    _12 = 4096,
                    _13 = 8192,
                    _14 = 16384,
                    _15 = 32768,
                    _16 = 65536,
                    _17 = 131072,
                    _18 = 262144,
                    _19 = 524288,
                    _20 = 1048576,
                    _21 = 2097152,
                    _22 = 4194304,
                    _23 = 8388608,
                    _24 = 16777216,
                    _25 = 33554432,
                    _26 = 67108864,
                    _27 = 134217728,
                    _28 = 268435456,
                    _29 = 536870912,
                    _30 = 1073741824,
                    _31 = -2147483648,
                }
            }

            [TagStructure(Size = 0x14)]
            public class ResourceType
            {
                public uint Unknown;
                public uint Unknown2;
                public uint Unknown3;
                public uint Unknown4;
                public uint Unknown5;
            }

            [TagStructure(Size = 0x4)]
            public class RequiredTagPoolBlock
            {
                public ActiveMembersValue ActiveMembers;

                public enum ActiveMembersValue : int
                {
                    None,
                    _0,
                    _1,
                    _2 = 4,
                    _3 = 8,
                    _4 = 16,
                    _5 = 32,
                    _6 = 64,
                    _7 = 128,
                    _8 = 256,
                    _9 = 512,
                    _10 = 1024,
                    _11 = 2048,
                    _12 = 4096,
                    _13 = 8192,
                    _14 = 16384,
                    _15 = 32768,
                    _16 = 65536,
                    _17 = 131072,
                    _18 = 262144,
                    _19 = 524288,
                    _20 = 1048576,
                    _21 = 2097152,
                    _22 = 4194304,
                    _23 = 8388608,
                    _24 = 16777216,
                    _25 = 33554432,
                    _26 = 67108864,
                    _27 = 134217728,
                    _28 = 268435456,
                    _29 = 536870912,
                    _30 = 1073741824,
                    _31 = -2147483648,
                }
            }

            [TagStructure(Size = 0x4)]
            public class OptionalTagPoolBlock
            {
                public ActiveMembersValue ActiveMembers;

                public enum ActiveMembersValue : int
                {
                    None,
                    _0,
                    _1,
                    _2 = 4,
                    _3 = 8,
                    _4 = 16,
                    _5 = 32,
                    _6 = 64,
                    _7 = 128,
                    _8 = 256,
                    _9 = 512,
                    _10 = 1024,
                    _11 = 2048,
                    _12 = 4096,
                    _13 = 8192,
                    _14 = 16384,
                    _15 = 32768,
                    _16 = 65536,
                    _17 = 131072,
                    _18 = 262144,
                    _19 = 524288,
                    _20 = 1048576,
                    _21 = 2097152,
                    _22 = 4194304,
                    _23 = 8388608,
                    _24 = 16777216,
                    _25 = 33554432,
                    _26 = 67108864,
                    _27 = 134217728,
                    _28 = 268435456,
                    _29 = 536870912,
                    _30 = 1073741824,
                    _31 = -2147483648,
                }
            }
        }

        [TagStructure(Size = 0x78)]
        public class UnattachedZonesetBlock
        {
            public List<RequiredRawPoolBlock> RequiredRawPool;
            public uint Unknown;
            public uint Unknown2;
            public uint Unknown3;
            public List<OptionalRawPoolBlock> OptionalRawPool;
            public List<OptionalRawPool2Block> OptionalRawPool2;
            public uint Unknown4;
            public uint Unknown5;
            public uint Unknown6;
            public uint Unknown7;
            public uint Unknown8;
            public StringId SetName;
            public List<ResourceType> ResourceTypes;
            public List<RequiredTagPoolBlock> RequiredTagPool;
            public List<OptionalTagPoolBlock> OptionalTagPool;
            public uint Unknown9;
            public uint Unknown10;
            public uint Unknown11;

            [TagStructure(Size = 0x4)]
            public class RequiredRawPoolBlock
            {
                public ActiveMembersValue ActiveMembers;

                public enum ActiveMembersValue : int
                {
                    None,
                    _0,
                    _1,
                    _2 = 4,
                    _3 = 8,
                    _4 = 16,
                    _5 = 32,
                    _6 = 64,
                    _7 = 128,
                    _8 = 256,
                    _9 = 512,
                    _10 = 1024,
                    _11 = 2048,
                    _12 = 4096,
                    _13 = 8192,
                    _14 = 16384,
                    _15 = 32768,
                    _16 = 65536,
                    _17 = 131072,
                    _18 = 262144,
                    _19 = 524288,
                    _20 = 1048576,
                    _21 = 2097152,
                    _22 = 4194304,
                    _23 = 8388608,
                    _24 = 16777216,
                    _25 = 33554432,
                    _26 = 67108864,
                    _27 = 134217728,
                    _28 = 268435456,
                    _29 = 536870912,
                    _30 = 1073741824,
                    _31 = -2147483648,
                }
            }

            [TagStructure(Size = 0x4)]
            public class OptionalRawPoolBlock
            {
                public ActiveMembersValue ActiveMembers;

                public enum ActiveMembersValue : int
                {
                    None,
                    _0,
                    _1,
                    _2 = 4,
                    _3 = 8,
                    _4 = 16,
                    _5 = 32,
                    _6 = 64,
                    _7 = 128,
                    _8 = 256,
                    _9 = 512,
                    _10 = 1024,
                    _11 = 2048,
                    _12 = 4096,
                    _13 = 8192,
                    _14 = 16384,
                    _15 = 32768,
                    _16 = 65536,
                    _17 = 131072,
                    _18 = 262144,
                    _19 = 524288,
                    _20 = 1048576,
                    _21 = 2097152,
                    _22 = 4194304,
                    _23 = 8388608,
                    _24 = 16777216,
                    _25 = 33554432,
                    _26 = 67108864,
                    _27 = 134217728,
                    _28 = 268435456,
                    _29 = 536870912,
                    _30 = 1073741824,
                    _31 = -2147483648,
                }
            }

            [TagStructure(Size = 0x4)]
            public class OptionalRawPool2Block
            {
                public ActiveMembersValue ActiveMembers;

                public enum ActiveMembersValue : int
                {
                    None,
                    _0,
                    _1,
                    _2 = 4,
                    _3 = 8,
                    _4 = 16,
                    _5 = 32,
                    _6 = 64,
                    _7 = 128,
                    _8 = 256,
                    _9 = 512,
                    _10 = 1024,
                    _11 = 2048,
                    _12 = 4096,
                    _13 = 8192,
                    _14 = 16384,
                    _15 = 32768,
                    _16 = 65536,
                    _17 = 131072,
                    _18 = 262144,
                    _19 = 524288,
                    _20 = 1048576,
                    _21 = 2097152,
                    _22 = 4194304,
                    _23 = 8388608,
                    _24 = 16777216,
                    _25 = 33554432,
                    _26 = 67108864,
                    _27 = 134217728,
                    _28 = 268435456,
                    _29 = 536870912,
                    _30 = 1073741824,
                    _31 = -2147483648,
                }
            }

            [TagStructure(Size = 0x14)]
            public class ResourceType
            {
                public uint Unknown;
                public uint Unknown2;
                public uint Unknown3;
                public uint Unknown4;
                public uint Unknown5;
            }

            [TagStructure(Size = 0x4)]
            public class RequiredTagPoolBlock
            {
                public ActiveMembersValue ActiveMembers;

                public enum ActiveMembersValue : int
                {
                    None,
                    _0,
                    _1,
                    _2 = 4,
                    _3 = 8,
                    _4 = 16,
                    _5 = 32,
                    _6 = 64,
                    _7 = 128,
                    _8 = 256,
                    _9 = 512,
                    _10 = 1024,
                    _11 = 2048,
                    _12 = 4096,
                    _13 = 8192,
                    _14 = 16384,
                    _15 = 32768,
                    _16 = 65536,
                    _17 = 131072,
                    _18 = 262144,
                    _19 = 524288,
                    _20 = 1048576,
                    _21 = 2097152,
                    _22 = 4194304,
                    _23 = 8388608,
                    _24 = 16777216,
                    _25 = 33554432,
                    _26 = 67108864,
                    _27 = 134217728,
                    _28 = 268435456,
                    _29 = 536870912,
                    _30 = 1073741824,
                    _31 = -2147483648,
                }
            }

            [TagStructure(Size = 0x4)]
            public class OptionalTagPoolBlock
            {
                public ActiveMembersValue ActiveMembers;

                public enum ActiveMembersValue : int
                {
                    None,
                    _0,
                    _1,
                    _2 = 4,
                    _3 = 8,
                    _4 = 16,
                    _5 = 32,
                    _6 = 64,
                    _7 = 128,
                    _8 = 256,
                    _9 = 512,
                    _10 = 1024,
                    _11 = 2048,
                    _12 = 4096,
                    _13 = 8192,
                    _14 = 16384,
                    _15 = 32768,
                    _16 = 65536,
                    _17 = 131072,
                    _18 = 262144,
                    _19 = 524288,
                    _20 = 1048576,
                    _21 = 2097152,
                    _22 = 4194304,
                    _23 = 8388608,
                    _24 = 16777216,
                    _25 = 33554432,
                    _26 = 67108864,
                    _27 = 134217728,
                    _28 = 268435456,
                    _29 = 536870912,
                    _30 = 1073741824,
                    _31 = -2147483648,
                }
            }
        }

        [TagStructure(Size = 0x78)]
        public class DiscForbiddenZonesetBlock
        {
            public List<RequiredRawPoolBlock> RequiredRawPool;
            public uint Unknown;
            public uint Unknown2;
            public uint Unknown3;
            public List<OptionalRawPoolBlock> OptionalRawPool;
            public List<OptionalRawPool2Block> OptionalRawPool2;
            public uint Unknown4;
            public uint Unknown5;
            public uint Unknown6;
            public uint Unknown7;
            public uint Unknown8;
            public StringId SetName;
            public List<ResourceType> ResourceTypes;
            public List<RequiredTagPoolBlock> RequiredTagPool;
            public List<OptionalTagPoolBlock> OptionalTagPool;
            public uint Unknown9;
            public uint Unknown10;
            public uint Unknown11;

            [TagStructure(Size = 0x4)]
            public class RequiredRawPoolBlock
            {
                public ActiveMembersValue ActiveMembers;

                public enum ActiveMembersValue : int
                {
                    None,
                    _0,
                    _1,
                    _2 = 4,
                    _3 = 8,
                    _4 = 16,
                    _5 = 32,
                    _6 = 64,
                    _7 = 128,
                    _8 = 256,
                    _9 = 512,
                    _10 = 1024,
                    _11 = 2048,
                    _12 = 4096,
                    _13 = 8192,
                    _14 = 16384,
                    _15 = 32768,
                    _16 = 65536,
                    _17 = 131072,
                    _18 = 262144,
                    _19 = 524288,
                    _20 = 1048576,
                    _21 = 2097152,
                    _22 = 4194304,
                    _23 = 8388608,
                    _24 = 16777216,
                    _25 = 33554432,
                    _26 = 67108864,
                    _27 = 134217728,
                    _28 = 268435456,
                    _29 = 536870912,
                    _30 = 1073741824,
                    _31 = -2147483648,
                }
            }

            [TagStructure(Size = 0x4)]
            public class OptionalRawPoolBlock
            {
                public ActiveMembersValue ActiveMembers;

                public enum ActiveMembersValue : int
                {
                    None,
                    _0,
                    _1,
                    _2 = 4,
                    _3 = 8,
                    _4 = 16,
                    _5 = 32,
                    _6 = 64,
                    _7 = 128,
                    _8 = 256,
                    _9 = 512,
                    _10 = 1024,
                    _11 = 2048,
                    _12 = 4096,
                    _13 = 8192,
                    _14 = 16384,
                    _15 = 32768,
                    _16 = 65536,
                    _17 = 131072,
                    _18 = 262144,
                    _19 = 524288,
                    _20 = 1048576,
                    _21 = 2097152,
                    _22 = 4194304,
                    _23 = 8388608,
                    _24 = 16777216,
                    _25 = 33554432,
                    _26 = 67108864,
                    _27 = 134217728,
                    _28 = 268435456,
                    _29 = 536870912,
                    _30 = 1073741824,
                    _31 = -2147483648,
                }
            }

            [TagStructure(Size = 0x4)]
            public class OptionalRawPool2Block
            {
                public ActiveMembersValue ActiveMembers;

                public enum ActiveMembersValue : int
                {
                    None,
                    _0,
                    _1,
                    _2 = 4,
                    _3 = 8,
                    _4 = 16,
                    _5 = 32,
                    _6 = 64,
                    _7 = 128,
                    _8 = 256,
                    _9 = 512,
                    _10 = 1024,
                    _11 = 2048,
                    _12 = 4096,
                    _13 = 8192,
                    _14 = 16384,
                    _15 = 32768,
                    _16 = 65536,
                    _17 = 131072,
                    _18 = 262144,
                    _19 = 524288,
                    _20 = 1048576,
                    _21 = 2097152,
                    _22 = 4194304,
                    _23 = 8388608,
                    _24 = 16777216,
                    _25 = 33554432,
                    _26 = 67108864,
                    _27 = 134217728,
                    _28 = 268435456,
                    _29 = 536870912,
                    _30 = 1073741824,
                    _31 = -2147483648,
                }
            }

            [TagStructure(Size = 0x14)]
            public class ResourceType
            {
                public uint Unknown;
                public uint Unknown2;
                public uint Unknown3;
                public uint Unknown4;
                public uint Unknown5;
            }

            [TagStructure(Size = 0x4)]
            public class RequiredTagPoolBlock
            {
                public ActiveMembersValue ActiveMembers;

                public enum ActiveMembersValue : int
                {
                    None,
                    _0,
                    _1,
                    _2 = 4,
                    _3 = 8,
                    _4 = 16,
                    _5 = 32,
                    _6 = 64,
                    _7 = 128,
                    _8 = 256,
                    _9 = 512,
                    _10 = 1024,
                    _11 = 2048,
                    _12 = 4096,
                    _13 = 8192,
                    _14 = 16384,
                    _15 = 32768,
                    _16 = 65536,
                    _17 = 131072,
                    _18 = 262144,
                    _19 = 524288,
                    _20 = 1048576,
                    _21 = 2097152,
                    _22 = 4194304,
                    _23 = 8388608,
                    _24 = 16777216,
                    _25 = 33554432,
                    _26 = 67108864,
                    _27 = 134217728,
                    _28 = 268435456,
                    _29 = 536870912,
                    _30 = 1073741824,
                    _31 = -2147483648,
                }
            }

            [TagStructure(Size = 0x4)]
            public class OptionalTagPoolBlock
            {
                public ActiveMembersValue ActiveMembers;

                public enum ActiveMembersValue : int
                {
                    None,
                    _0,
                    _1,
                    _2 = 4,
                    _3 = 8,
                    _4 = 16,
                    _5 = 32,
                    _6 = 64,
                    _7 = 128,
                    _8 = 256,
                    _9 = 512,
                    _10 = 1024,
                    _11 = 2048,
                    _12 = 4096,
                    _13 = 8192,
                    _14 = 16384,
                    _15 = 32768,
                    _16 = 65536,
                    _17 = 131072,
                    _18 = 262144,
                    _19 = 524288,
                    _20 = 1048576,
                    _21 = 2097152,
                    _22 = 4194304,
                    _23 = 8388608,
                    _24 = 16777216,
                    _25 = 33554432,
                    _26 = 67108864,
                    _27 = 134217728,
                    _28 = 268435456,
                    _29 = 536870912,
                    _30 = 1073741824,
                    _31 = -2147483648,
                }
            }
        }

        [TagStructure(Size = 0x78)]
        public class DiscAlwaysStreamingZonesetBlock
        {
            public List<RequiredRawPoolBlock> RequiredRawPool;
            public uint Unknown;
            public uint Unknown2;
            public uint Unknown3;
            public List<OptionalRawPoolBlock> OptionalRawPool;
            public List<OptionalRawPool2Block> OptionalRawPool2;
            public uint Unknown4;
            public uint Unknown5;
            public uint Unknown6;
            public uint Unknown7;
            public uint Unknown8;
            public StringId SetName;
            public List<ResourceType> ResourceTypes;
            public List<RequiredTagPoolBlock> RequiredTagPool;
            public List<OptionalTagPoolBlock> OptionalTagPool;
            public uint Unknown9;
            public uint Unknown10;
            public uint Unknown11;

            [TagStructure(Size = 0x4)]
            public class RequiredRawPoolBlock
            {
                public ActiveMembersValue ActiveMembers;

                public enum ActiveMembersValue : int
                {
                    None,
                    _0,
                    _1,
                    _2 = 4,
                    _3 = 8,
                    _4 = 16,
                    _5 = 32,
                    _6 = 64,
                    _7 = 128,
                    _8 = 256,
                    _9 = 512,
                    _10 = 1024,
                    _11 = 2048,
                    _12 = 4096,
                    _13 = 8192,
                    _14 = 16384,
                    _15 = 32768,
                    _16 = 65536,
                    _17 = 131072,
                    _18 = 262144,
                    _19 = 524288,
                    _20 = 1048576,
                    _21 = 2097152,
                    _22 = 4194304,
                    _23 = 8388608,
                    _24 = 16777216,
                    _25 = 33554432,
                    _26 = 67108864,
                    _27 = 134217728,
                    _28 = 268435456,
                    _29 = 536870912,
                    _30 = 1073741824,
                    _31 = -2147483648,
                }
            }

            [TagStructure(Size = 0x4)]
            public class OptionalRawPoolBlock
            {
                public ActiveMembersValue ActiveMembers;

                public enum ActiveMembersValue : int
                {
                    None,
                    _0,
                    _1,
                    _2 = 4,
                    _3 = 8,
                    _4 = 16,
                    _5 = 32,
                    _6 = 64,
                    _7 = 128,
                    _8 = 256,
                    _9 = 512,
                    _10 = 1024,
                    _11 = 2048,
                    _12 = 4096,
                    _13 = 8192,
                    _14 = 16384,
                    _15 = 32768,
                    _16 = 65536,
                    _17 = 131072,
                    _18 = 262144,
                    _19 = 524288,
                    _20 = 1048576,
                    _21 = 2097152,
                    _22 = 4194304,
                    _23 = 8388608,
                    _24 = 16777216,
                    _25 = 33554432,
                    _26 = 67108864,
                    _27 = 134217728,
                    _28 = 268435456,
                    _29 = 536870912,
                    _30 = 1073741824,
                    _31 = -2147483648,
                }
            }

            [TagStructure(Size = 0x4)]
            public class OptionalRawPool2Block
            {
                public ActiveMembersValue ActiveMembers;

                public enum ActiveMembersValue : int
                {
                    None,
                    _0,
                    _1,
                    _2 = 4,
                    _3 = 8,
                    _4 = 16,
                    _5 = 32,
                    _6 = 64,
                    _7 = 128,
                    _8 = 256,
                    _9 = 512,
                    _10 = 1024,
                    _11 = 2048,
                    _12 = 4096,
                    _13 = 8192,
                    _14 = 16384,
                    _15 = 32768,
                    _16 = 65536,
                    _17 = 131072,
                    _18 = 262144,
                    _19 = 524288,
                    _20 = 1048576,
                    _21 = 2097152,
                    _22 = 4194304,
                    _23 = 8388608,
                    _24 = 16777216,
                    _25 = 33554432,
                    _26 = 67108864,
                    _27 = 134217728,
                    _28 = 268435456,
                    _29 = 536870912,
                    _30 = 1073741824,
                    _31 = -2147483648,
                }
            }

            [TagStructure(Size = 0x14)]
            public class ResourceType
            {
                public uint Unknown;
                public uint Unknown2;
                public uint Unknown3;
                public uint Unknown4;
                public uint Unknown5;
            }

            [TagStructure(Size = 0x4)]
            public class RequiredTagPoolBlock
            {
                public ActiveMembersValue ActiveMembers;

                public enum ActiveMembersValue : int
                {
                    None,
                    _0,
                    _1,
                    _2 = 4,
                    _3 = 8,
                    _4 = 16,
                    _5 = 32,
                    _6 = 64,
                    _7 = 128,
                    _8 = 256,
                    _9 = 512,
                    _10 = 1024,
                    _11 = 2048,
                    _12 = 4096,
                    _13 = 8192,
                    _14 = 16384,
                    _15 = 32768,
                    _16 = 65536,
                    _17 = 131072,
                    _18 = 262144,
                    _19 = 524288,
                    _20 = 1048576,
                    _21 = 2097152,
                    _22 = 4194304,
                    _23 = 8388608,
                    _24 = 16777216,
                    _25 = 33554432,
                    _26 = 67108864,
                    _27 = 134217728,
                    _28 = 268435456,
                    _29 = 536870912,
                    _30 = 1073741824,
                    _31 = -2147483648,
                }
            }

            [TagStructure(Size = 0x4)]
            public class OptionalTagPoolBlock
            {
                public ActiveMembersValue ActiveMembers;

                public enum ActiveMembersValue : int
                {
                    None,
                    _0,
                    _1,
                    _2 = 4,
                    _3 = 8,
                    _4 = 16,
                    _5 = 32,
                    _6 = 64,
                    _7 = 128,
                    _8 = 256,
                    _9 = 512,
                    _10 = 1024,
                    _11 = 2048,
                    _12 = 4096,
                    _13 = 8192,
                    _14 = 16384,
                    _15 = 32768,
                    _16 = 65536,
                    _17 = 131072,
                    _18 = 262144,
                    _19 = 524288,
                    _20 = 1048576,
                    _21 = 2097152,
                    _22 = 4194304,
                    _23 = 8388608,
                    _24 = 16777216,
                    _25 = 33554432,
                    _26 = 67108864,
                    _27 = 134217728,
                    _28 = 268435456,
                    _29 = 536870912,
                    _30 = 1073741824,
                    _31 = -2147483648,
                }
            }
        }

        [TagStructure(Size = 0x78)]
        public class BspZoneset
        {
            public List<RequiredRawPoolBlock> RequiredRawPool;
            public uint Unknown;
            public uint Unknown2;
            public uint Unknown3;
            public List<OptionalRawPoolBlock> OptionalRawPool;
            public List<OptionalRawPool2Block> OptionalRawPool2;
            public uint Unknown4;
            public uint Unknown5;
            public uint Unknown6;
            public uint Unknown7;
            public uint Unknown8;
            public StringId SetName;
            public List<ResourceType> ResourceTypes;
            public List<RequiredTagPoolBlock> RequiredTagPool;
            public List<OptionalTagPoolBlock> OptionalTagPool;
            public uint Unknown9;
            public uint Unknown10;
            public uint Unknown11;

            [TagStructure(Size = 0x4)]
            public class RequiredRawPoolBlock
            {
                public ActiveMembersValue ActiveMembers;

                public enum ActiveMembersValue : int
                {
                    None,
                    _0,
                    _1,
                    _2 = 4,
                    _3 = 8,
                    _4 = 16,
                    _5 = 32,
                    _6 = 64,
                    _7 = 128,
                    _8 = 256,
                    _9 = 512,
                    _10 = 1024,
                    _11 = 2048,
                    _12 = 4096,
                    _13 = 8192,
                    _14 = 16384,
                    _15 = 32768,
                    _16 = 65536,
                    _17 = 131072,
                    _18 = 262144,
                    _19 = 524288,
                    _20 = 1048576,
                    _21 = 2097152,
                    _22 = 4194304,
                    _23 = 8388608,
                    _24 = 16777216,
                    _25 = 33554432,
                    _26 = 67108864,
                    _27 = 134217728,
                    _28 = 268435456,
                    _29 = 536870912,
                    _30 = 1073741824,
                    _31 = -2147483648,
                }
            }

            [TagStructure(Size = 0x4)]
            public class OptionalRawPoolBlock
            {
                public ActiveMembersValue ActiveMembers;

                public enum ActiveMembersValue : int
                {
                    None,
                    _0,
                    _1,
                    _2 = 4,
                    _3 = 8,
                    _4 = 16,
                    _5 = 32,
                    _6 = 64,
                    _7 = 128,
                    _8 = 256,
                    _9 = 512,
                    _10 = 1024,
                    _11 = 2048,
                    _12 = 4096,
                    _13 = 8192,
                    _14 = 16384,
                    _15 = 32768,
                    _16 = 65536,
                    _17 = 131072,
                    _18 = 262144,
                    _19 = 524288,
                    _20 = 1048576,
                    _21 = 2097152,
                    _22 = 4194304,
                    _23 = 8388608,
                    _24 = 16777216,
                    _25 = 33554432,
                    _26 = 67108864,
                    _27 = 134217728,
                    _28 = 268435456,
                    _29 = 536870912,
                    _30 = 1073741824,
                    _31 = -2147483648,
                }
            }

            [TagStructure(Size = 0x4)]
            public class OptionalRawPool2Block
            {
                public ActiveMembersValue ActiveMembers;

                public enum ActiveMembersValue : int
                {
                    None,
                    _0,
                    _1,
                    _2 = 4,
                    _3 = 8,
                    _4 = 16,
                    _5 = 32,
                    _6 = 64,
                    _7 = 128,
                    _8 = 256,
                    _9 = 512,
                    _10 = 1024,
                    _11 = 2048,
                    _12 = 4096,
                    _13 = 8192,
                    _14 = 16384,
                    _15 = 32768,
                    _16 = 65536,
                    _17 = 131072,
                    _18 = 262144,
                    _19 = 524288,
                    _20 = 1048576,
                    _21 = 2097152,
                    _22 = 4194304,
                    _23 = 8388608,
                    _24 = 16777216,
                    _25 = 33554432,
                    _26 = 67108864,
                    _27 = 134217728,
                    _28 = 268435456,
                    _29 = 536870912,
                    _30 = 1073741824,
                    _31 = -2147483648,
                }
            }

            [TagStructure(Size = 0x14)]
            public class ResourceType
            {
                public uint Unknown;
                public uint Unknown2;
                public uint Unknown3;
                public uint Unknown4;
                public uint Unknown5;
            }

            [TagStructure(Size = 0x4)]
            public class RequiredTagPoolBlock
            {
                public ActiveMembersValue ActiveMembers;

                public enum ActiveMembersValue : int
                {
                    None,
                    _0,
                    _1,
                    _2 = 4,
                    _3 = 8,
                    _4 = 16,
                    _5 = 32,
                    _6 = 64,
                    _7 = 128,
                    _8 = 256,
                    _9 = 512,
                    _10 = 1024,
                    _11 = 2048,
                    _12 = 4096,
                    _13 = 8192,
                    _14 = 16384,
                    _15 = 32768,
                    _16 = 65536,
                    _17 = 131072,
                    _18 = 262144,
                    _19 = 524288,
                    _20 = 1048576,
                    _21 = 2097152,
                    _22 = 4194304,
                    _23 = 8388608,
                    _24 = 16777216,
                    _25 = 33554432,
                    _26 = 67108864,
                    _27 = 134217728,
                    _28 = 268435456,
                    _29 = 536870912,
                    _30 = 1073741824,
                    _31 = -2147483648,
                }
            }

            [TagStructure(Size = 0x4)]
            public class OptionalTagPoolBlock
            {
                public ActiveMembersValue ActiveMembers;

                public enum ActiveMembersValue : int
                {
                    None,
                    _0,
                    _1,
                    _2 = 4,
                    _3 = 8,
                    _4 = 16,
                    _5 = 32,
                    _6 = 64,
                    _7 = 128,
                    _8 = 256,
                    _9 = 512,
                    _10 = 1024,
                    _11 = 2048,
                    _12 = 4096,
                    _13 = 8192,
                    _14 = 16384,
                    _15 = 32768,
                    _16 = 65536,
                    _17 = 131072,
                    _18 = 262144,
                    _19 = 524288,
                    _20 = 1048576,
                    _21 = 2097152,
                    _22 = 4194304,
                    _23 = 8388608,
                    _24 = 16777216,
                    _25 = 33554432,
                    _26 = 67108864,
                    _27 = 134217728,
                    _28 = 268435456,
                    _29 = 536870912,
                    _30 = 1073741824,
                    _31 = -2147483648,
                }
            }
        }

        [TagStructure(Size = 0x78)]
        public class BspZonesets2Block
        {
            public List<RequiredRawPoolBlock> RequiredRawPool;
            public uint Unknown;
            public uint Unknown2;
            public uint Unknown3;
            public List<OptionalRawPoolBlock> OptionalRawPool;
            public List<OptionalRawPool2Block> OptionalRawPool2;
            public uint Unknown4;
            public uint Unknown5;
            public uint Unknown6;
            public uint Unknown7;
            public uint Unknown8;
            public StringId SetName;
            public List<ResourceType> ResourceTypes;
            public List<RequiredTagPoolBlock> RequiredTagPool;
            public List<OptionalTagPoolBlock> OptionalTagPool;
            public uint Unknown9;
            public uint Unknown10;
            public uint Unknown11;

            [TagStructure(Size = 0x4)]
            public class RequiredRawPoolBlock
            {
                public ActiveMembersValue ActiveMembers;

                public enum ActiveMembersValue : int
                {
                    None,
                    _0,
                    _1,
                    _2 = 4,
                    _3 = 8,
                    _4 = 16,
                    _5 = 32,
                    _6 = 64,
                    _7 = 128,
                    _8 = 256,
                    _9 = 512,
                    _10 = 1024,
                    _11 = 2048,
                    _12 = 4096,
                    _13 = 8192,
                    _14 = 16384,
                    _15 = 32768,
                    _16 = 65536,
                    _17 = 131072,
                    _18 = 262144,
                    _19 = 524288,
                    _20 = 1048576,
                    _21 = 2097152,
                    _22 = 4194304,
                    _23 = 8388608,
                    _24 = 16777216,
                    _25 = 33554432,
                    _26 = 67108864,
                    _27 = 134217728,
                    _28 = 268435456,
                    _29 = 536870912,
                    _30 = 1073741824,
                    _31 = -2147483648,
                }
            }

            [TagStructure(Size = 0x4)]
            public class OptionalRawPoolBlock
            {
                public ActiveMembersValue ActiveMembers;

                public enum ActiveMembersValue : int
                {
                    None,
                    _0,
                    _1,
                    _2 = 4,
                    _3 = 8,
                    _4 = 16,
                    _5 = 32,
                    _6 = 64,
                    _7 = 128,
                    _8 = 256,
                    _9 = 512,
                    _10 = 1024,
                    _11 = 2048,
                    _12 = 4096,
                    _13 = 8192,
                    _14 = 16384,
                    _15 = 32768,
                    _16 = 65536,
                    _17 = 131072,
                    _18 = 262144,
                    _19 = 524288,
                    _20 = 1048576,
                    _21 = 2097152,
                    _22 = 4194304,
                    _23 = 8388608,
                    _24 = 16777216,
                    _25 = 33554432,
                    _26 = 67108864,
                    _27 = 134217728,
                    _28 = 268435456,
                    _29 = 536870912,
                    _30 = 1073741824,
                    _31 = -2147483648,
                }
            }

            [TagStructure(Size = 0x4)]
            public class OptionalRawPool2Block
            {
                public ActiveMembersValue ActiveMembers;

                public enum ActiveMembersValue : int
                {
                    None,
                    _0,
                    _1,
                    _2 = 4,
                    _3 = 8,
                    _4 = 16,
                    _5 = 32,
                    _6 = 64,
                    _7 = 128,
                    _8 = 256,
                    _9 = 512,
                    _10 = 1024,
                    _11 = 2048,
                    _12 = 4096,
                    _13 = 8192,
                    _14 = 16384,
                    _15 = 32768,
                    _16 = 65536,
                    _17 = 131072,
                    _18 = 262144,
                    _19 = 524288,
                    _20 = 1048576,
                    _21 = 2097152,
                    _22 = 4194304,
                    _23 = 8388608,
                    _24 = 16777216,
                    _25 = 33554432,
                    _26 = 67108864,
                    _27 = 134217728,
                    _28 = 268435456,
                    _29 = 536870912,
                    _30 = 1073741824,
                    _31 = -2147483648,
                }
            }

            [TagStructure(Size = 0x14)]
            public class ResourceType
            {
                public uint Unknown;
                public uint Unknown2;
                public uint Unknown3;
                public uint Unknown4;
                public uint Unknown5;
            }

            [TagStructure(Size = 0x4)]
            public class RequiredTagPoolBlock
            {
                public ActiveMembersValue ActiveMembers;

                public enum ActiveMembersValue : int
                {
                    None,
                    _0,
                    _1,
                    _2 = 4,
                    _3 = 8,
                    _4 = 16,
                    _5 = 32,
                    _6 = 64,
                    _7 = 128,
                    _8 = 256,
                    _9 = 512,
                    _10 = 1024,
                    _11 = 2048,
                    _12 = 4096,
                    _13 = 8192,
                    _14 = 16384,
                    _15 = 32768,
                    _16 = 65536,
                    _17 = 131072,
                    _18 = 262144,
                    _19 = 524288,
                    _20 = 1048576,
                    _21 = 2097152,
                    _22 = 4194304,
                    _23 = 8388608,
                    _24 = 16777216,
                    _25 = 33554432,
                    _26 = 67108864,
                    _27 = 134217728,
                    _28 = 268435456,
                    _29 = 536870912,
                    _30 = 1073741824,
                    _31 = -2147483648,
                }
            }

            [TagStructure(Size = 0x4)]
            public class OptionalTagPoolBlock
            {
                public ActiveMembersValue ActiveMembers;

                public enum ActiveMembersValue : int
                {
                    None,
                    _0,
                    _1,
                    _2 = 4,
                    _3 = 8,
                    _4 = 16,
                    _5 = 32,
                    _6 = 64,
                    _7 = 128,
                    _8 = 256,
                    _9 = 512,
                    _10 = 1024,
                    _11 = 2048,
                    _12 = 4096,
                    _13 = 8192,
                    _14 = 16384,
                    _15 = 32768,
                    _16 = 65536,
                    _17 = 131072,
                    _18 = 262144,
                    _19 = 524288,
                    _20 = 1048576,
                    _21 = 2097152,
                    _22 = 4194304,
                    _23 = 8388608,
                    _24 = 16777216,
                    _25 = 33554432,
                    _26 = 67108864,
                    _27 = 134217728,
                    _28 = 268435456,
                    _29 = 536870912,
                    _30 = 1073741824,
                    _31 = -2147483648,
                }
            }
        }

        [TagStructure(Size = 0x78)]
        public class BspZonesets3Block
        {
            public List<RequiredRawPoolBlock> RequiredRawPool;
            public uint Unknown;
            public uint Unknown2;
            public uint Unknown3;
            public List<OptionalRawPoolBlock> OptionalRawPool;
            public List<OptionalRawPool2Block> OptionalRawPool2;
            public uint Unknown4;
            public uint Unknown5;
            public uint Unknown6;
            public uint Unknown7;
            public uint Unknown8;
            public StringId SetName;
            public List<ResourceType> ResourceTypes;
            public List<RequiredTagPoolBlock> RequiredTagPool;
            public List<OptionalTagPoolBlock> OptionalTagPool;
            public uint Unknown9;
            public uint Unknown10;
            public uint Unknown11;

            [TagStructure(Size = 0x4)]
            public class RequiredRawPoolBlock
            {
                public ActiveMembersValue ActiveMembers;

                public enum ActiveMembersValue : int
                {
                    None,
                    _0,
                    _1,
                    _2 = 4,
                    _3 = 8,
                    _4 = 16,
                    _5 = 32,
                    _6 = 64,
                    _7 = 128,
                    _8 = 256,
                    _9 = 512,
                    _10 = 1024,
                    _11 = 2048,
                    _12 = 4096,
                    _13 = 8192,
                    _14 = 16384,
                    _15 = 32768,
                    _16 = 65536,
                    _17 = 131072,
                    _18 = 262144,
                    _19 = 524288,
                    _20 = 1048576,
                    _21 = 2097152,
                    _22 = 4194304,
                    _23 = 8388608,
                    _24 = 16777216,
                    _25 = 33554432,
                    _26 = 67108864,
                    _27 = 134217728,
                    _28 = 268435456,
                    _29 = 536870912,
                    _30 = 1073741824,
                    _31 = -2147483648,
                }
            }

            [TagStructure(Size = 0x4)]
            public class OptionalRawPoolBlock
            {
                public ActiveMembersValue ActiveMembers;

                public enum ActiveMembersValue : int
                {
                    None,
                    _0,
                    _1,
                    _2 = 4,
                    _3 = 8,
                    _4 = 16,
                    _5 = 32,
                    _6 = 64,
                    _7 = 128,
                    _8 = 256,
                    _9 = 512,
                    _10 = 1024,
                    _11 = 2048,
                    _12 = 4096,
                    _13 = 8192,
                    _14 = 16384,
                    _15 = 32768,
                    _16 = 65536,
                    _17 = 131072,
                    _18 = 262144,
                    _19 = 524288,
                    _20 = 1048576,
                    _21 = 2097152,
                    _22 = 4194304,
                    _23 = 8388608,
                    _24 = 16777216,
                    _25 = 33554432,
                    _26 = 67108864,
                    _27 = 134217728,
                    _28 = 268435456,
                    _29 = 536870912,
                    _30 = 1073741824,
                    _31 = -2147483648,
                }
            }

            [TagStructure(Size = 0x4)]
            public class OptionalRawPool2Block
            {
                public ActiveMembersValue ActiveMembers;

                public enum ActiveMembersValue : int
                {
                    None,
                    _0,
                    _1,
                    _2 = 4,
                    _3 = 8,
                    _4 = 16,
                    _5 = 32,
                    _6 = 64,
                    _7 = 128,
                    _8 = 256,
                    _9 = 512,
                    _10 = 1024,
                    _11 = 2048,
                    _12 = 4096,
                    _13 = 8192,
                    _14 = 16384,
                    _15 = 32768,
                    _16 = 65536,
                    _17 = 131072,
                    _18 = 262144,
                    _19 = 524288,
                    _20 = 1048576,
                    _21 = 2097152,
                    _22 = 4194304,
                    _23 = 8388608,
                    _24 = 16777216,
                    _25 = 33554432,
                    _26 = 67108864,
                    _27 = 134217728,
                    _28 = 268435456,
                    _29 = 536870912,
                    _30 = 1073741824,
                    _31 = -2147483648,
                }
            }

            [TagStructure(Size = 0x14)]
            public class ResourceType
            {
                public uint Unknown;
                public uint Unknown2;
                public uint Unknown3;
                public uint Unknown4;
                public uint Unknown5;
            }

            [TagStructure(Size = 0x4)]
            public class RequiredTagPoolBlock
            {
                public ActiveMembersValue ActiveMembers;

                public enum ActiveMembersValue : int
                {
                    None,
                    _0,
                    _1,
                    _2 = 4,
                    _3 = 8,
                    _4 = 16,
                    _5 = 32,
                    _6 = 64,
                    _7 = 128,
                    _8 = 256,
                    _9 = 512,
                    _10 = 1024,
                    _11 = 2048,
                    _12 = 4096,
                    _13 = 8192,
                    _14 = 16384,
                    _15 = 32768,
                    _16 = 65536,
                    _17 = 131072,
                    _18 = 262144,
                    _19 = 524288,
                    _20 = 1048576,
                    _21 = 2097152,
                    _22 = 4194304,
                    _23 = 8388608,
                    _24 = 16777216,
                    _25 = 33554432,
                    _26 = 67108864,
                    _27 = 134217728,
                    _28 = 268435456,
                    _29 = 536870912,
                    _30 = 1073741824,
                    _31 = -2147483648,
                }
            }

            [TagStructure(Size = 0x4)]
            public class OptionalTagPoolBlock
            {
                public ActiveMembersValue ActiveMembers;

                public enum ActiveMembersValue : int
                {
                    None,
                    _0,
                    _1,
                    _2 = 4,
                    _3 = 8,
                    _4 = 16,
                    _5 = 32,
                    _6 = 64,
                    _7 = 128,
                    _8 = 256,
                    _9 = 512,
                    _10 = 1024,
                    _11 = 2048,
                    _12 = 4096,
                    _13 = 8192,
                    _14 = 16384,
                    _15 = 32768,
                    _16 = 65536,
                    _17 = 131072,
                    _18 = 262144,
                    _19 = 524288,
                    _20 = 1048576,
                    _21 = 2097152,
                    _22 = 4194304,
                    _23 = 8388608,
                    _24 = 16777216,
                    _25 = 33554432,
                    _26 = 67108864,
                    _27 = 134217728,
                    _28 = 268435456,
                    _29 = 536870912,
                    _30 = 1073741824,
                    _31 = -2147483648,
                }
            }
        }

        [TagStructure(Size = 0x78)]
        public class CinematicZoneset
        {
            public List<RequiredRawPoolBlock> RequiredRawPool;
            public uint Unknown;
            public uint Unknown2;
            public uint Unknown3;
            public List<OptionalRawPoolBlock> OptionalRawPool;
            public List<OptionalRawPool2Block> OptionalRawPool2;
            public uint Unknown4;
            public uint Unknown5;
            public uint Unknown6;
            public uint Unknown7;
            public uint Unknown8;
            public StringId SetName;
            public List<ResourceType> ResourceTypes;
            public List<RequiredTagPoolBlock> RequiredTagPool;
            public List<OptionalTagPoolBlock> OptionalTagPool;
            public uint Unknown9;
            public uint Unknown10;
            public uint Unknown11;

            [TagStructure(Size = 0x4)]
            public class RequiredRawPoolBlock
            {
                public ActiveMembersValue ActiveMembers;

                public enum ActiveMembersValue : int
                {
                    None,
                    _0,
                    _1,
                    _2 = 4,
                    _3 = 8,
                    _4 = 16,
                    _5 = 32,
                    _6 = 64,
                    _7 = 128,
                    _8 = 256,
                    _9 = 512,
                    _10 = 1024,
                    _11 = 2048,
                    _12 = 4096,
                    _13 = 8192,
                    _14 = 16384,
                    _15 = 32768,
                    _16 = 65536,
                    _17 = 131072,
                    _18 = 262144,
                    _19 = 524288,
                    _20 = 1048576,
                    _21 = 2097152,
                    _22 = 4194304,
                    _23 = 8388608,
                    _24 = 16777216,
                    _25 = 33554432,
                    _26 = 67108864,
                    _27 = 134217728,
                    _28 = 268435456,
                    _29 = 536870912,
                    _30 = 1073741824,
                    _31 = -2147483648,
                }
            }

            [TagStructure(Size = 0x4)]
            public class OptionalRawPoolBlock
            {
                public ActiveMembersValue ActiveMembers;

                public enum ActiveMembersValue : int
                {
                    None,
                    _0,
                    _1,
                    _2 = 4,
                    _3 = 8,
                    _4 = 16,
                    _5 = 32,
                    _6 = 64,
                    _7 = 128,
                    _8 = 256,
                    _9 = 512,
                    _10 = 1024,
                    _11 = 2048,
                    _12 = 4096,
                    _13 = 8192,
                    _14 = 16384,
                    _15 = 32768,
                    _16 = 65536,
                    _17 = 131072,
                    _18 = 262144,
                    _19 = 524288,
                    _20 = 1048576,
                    _21 = 2097152,
                    _22 = 4194304,
                    _23 = 8388608,
                    _24 = 16777216,
                    _25 = 33554432,
                    _26 = 67108864,
                    _27 = 134217728,
                    _28 = 268435456,
                    _29 = 536870912,
                    _30 = 1073741824,
                    _31 = -2147483648,
                }
            }

            [TagStructure(Size = 0x4)]
            public class OptionalRawPool2Block
            {
                public ActiveMembersValue ActiveMembers;

                public enum ActiveMembersValue : int
                {
                    None,
                    _0,
                    _1,
                    _2 = 4,
                    _3 = 8,
                    _4 = 16,
                    _5 = 32,
                    _6 = 64,
                    _7 = 128,
                    _8 = 256,
                    _9 = 512,
                    _10 = 1024,
                    _11 = 2048,
                    _12 = 4096,
                    _13 = 8192,
                    _14 = 16384,
                    _15 = 32768,
                    _16 = 65536,
                    _17 = 131072,
                    _18 = 262144,
                    _19 = 524288,
                    _20 = 1048576,
                    _21 = 2097152,
                    _22 = 4194304,
                    _23 = 8388608,
                    _24 = 16777216,
                    _25 = 33554432,
                    _26 = 67108864,
                    _27 = 134217728,
                    _28 = 268435456,
                    _29 = 536870912,
                    _30 = 1073741824,
                    _31 = -2147483648,
                }
            }

            [TagStructure(Size = 0x14)]
            public class ResourceType
            {
                public uint Unknown;
                public uint Unknown2;
                public uint Unknown3;
                public uint Unknown4;
                public uint Unknown5;
            }

            [TagStructure(Size = 0x4)]
            public class RequiredTagPoolBlock
            {
                public ActiveMembersValue ActiveMembers;

                public enum ActiveMembersValue : int
                {
                    None,
                    _0,
                    _1,
                    _2 = 4,
                    _3 = 8,
                    _4 = 16,
                    _5 = 32,
                    _6 = 64,
                    _7 = 128,
                    _8 = 256,
                    _9 = 512,
                    _10 = 1024,
                    _11 = 2048,
                    _12 = 4096,
                    _13 = 8192,
                    _14 = 16384,
                    _15 = 32768,
                    _16 = 65536,
                    _17 = 131072,
                    _18 = 262144,
                    _19 = 524288,
                    _20 = 1048576,
                    _21 = 2097152,
                    _22 = 4194304,
                    _23 = 8388608,
                    _24 = 16777216,
                    _25 = 33554432,
                    _26 = 67108864,
                    _27 = 134217728,
                    _28 = 268435456,
                    _29 = 536870912,
                    _30 = 1073741824,
                    _31 = -2147483648,
                }
            }

            [TagStructure(Size = 0x4)]
            public class OptionalTagPoolBlock
            {
                public ActiveMembersValue ActiveMembers;

                public enum ActiveMembersValue : int
                {
                    None,
                    _0,
                    _1,
                    _2 = 4,
                    _3 = 8,
                    _4 = 16,
                    _5 = 32,
                    _6 = 64,
                    _7 = 128,
                    _8 = 256,
                    _9 = 512,
                    _10 = 1024,
                    _11 = 2048,
                    _12 = 4096,
                    _13 = 8192,
                    _14 = 16384,
                    _15 = 32768,
                    _16 = 65536,
                    _17 = 131072,
                    _18 = 262144,
                    _19 = 524288,
                    _20 = 1048576,
                    _21 = 2097152,
                    _22 = 4194304,
                    _23 = 8388608,
                    _24 = 16777216,
                    _25 = 33554432,
                    _26 = 67108864,
                    _27 = 134217728,
                    _28 = 268435456,
                    _29 = 536870912,
                    _30 = 1073741824,
                    _31 = -2147483648,
                }
            }
        }

        [TagStructure(Size = 0x78)]
        public class ScenarioZoneset
        {
            public List<RequiredRawPoolBlock> RequiredRawPool;
            public uint Unknown;
            public uint Unknown2;
            public uint Unknown3;
            public List<OptionalRawPoolBlock> OptionalRawPool;
            public List<OptionalRawPool2Block> OptionalRawPool2;
            public uint Unknown4;
            public uint Unknown5;
            public uint Unknown6;
            public uint Unknown7;
            public uint Unknown8;
            public StringId SetName;
            public List<ResourceType> ResourceTypes;
            public List<RequiredTagPoolBlock> RequiredTagPool;
            public List<OptionalTagPoolBlock> OptionalTagPool;
            public uint Unknown9;
            public uint Unknown10;
            public uint Unknown11;

            [TagStructure(Size = 0x4)]
            public class RequiredRawPoolBlock
            {
                public ActiveMembersValue ActiveMembers;

                public enum ActiveMembersValue : int
                {
                    None,
                    _0,
                    _1,
                    _2 = 4,
                    _3 = 8,
                    _4 = 16,
                    _5 = 32,
                    _6 = 64,
                    _7 = 128,
                    _8 = 256,
                    _9 = 512,
                    _10 = 1024,
                    _11 = 2048,
                    _12 = 4096,
                    _13 = 8192,
                    _14 = 16384,
                    _15 = 32768,
                    _16 = 65536,
                    _17 = 131072,
                    _18 = 262144,
                    _19 = 524288,
                    _20 = 1048576,
                    _21 = 2097152,
                    _22 = 4194304,
                    _23 = 8388608,
                    _24 = 16777216,
                    _25 = 33554432,
                    _26 = 67108864,
                    _27 = 134217728,
                    _28 = 268435456,
                    _29 = 536870912,
                    _30 = 1073741824,
                    _31 = -2147483648,
                }
            }

            [TagStructure(Size = 0x4)]
            public class OptionalRawPoolBlock
            {
                public ActiveMembersValue ActiveMembers;

                public enum ActiveMembersValue : int
                {
                    None,
                    _0,
                    _1,
                    _2 = 4,
                    _3 = 8,
                    _4 = 16,
                    _5 = 32,
                    _6 = 64,
                    _7 = 128,
                    _8 = 256,
                    _9 = 512,
                    _10 = 1024,
                    _11 = 2048,
                    _12 = 4096,
                    _13 = 8192,
                    _14 = 16384,
                    _15 = 32768,
                    _16 = 65536,
                    _17 = 131072,
                    _18 = 262144,
                    _19 = 524288,
                    _20 = 1048576,
                    _21 = 2097152,
                    _22 = 4194304,
                    _23 = 8388608,
                    _24 = 16777216,
                    _25 = 33554432,
                    _26 = 67108864,
                    _27 = 134217728,
                    _28 = 268435456,
                    _29 = 536870912,
                    _30 = 1073741824,
                    _31 = -2147483648,
                }
            }

            [TagStructure(Size = 0x4)]
            public class OptionalRawPool2Block
            {
                public ActiveMembersValue ActiveMembers;

                public enum ActiveMembersValue : int
                {
                    None,
                    _0,
                    _1,
                    _2 = 4,
                    _3 = 8,
                    _4 = 16,
                    _5 = 32,
                    _6 = 64,
                    _7 = 128,
                    _8 = 256,
                    _9 = 512,
                    _10 = 1024,
                    _11 = 2048,
                    _12 = 4096,
                    _13 = 8192,
                    _14 = 16384,
                    _15 = 32768,
                    _16 = 65536,
                    _17 = 131072,
                    _18 = 262144,
                    _19 = 524288,
                    _20 = 1048576,
                    _21 = 2097152,
                    _22 = 4194304,
                    _23 = 8388608,
                    _24 = 16777216,
                    _25 = 33554432,
                    _26 = 67108864,
                    _27 = 134217728,
                    _28 = 268435456,
                    _29 = 536870912,
                    _30 = 1073741824,
                    _31 = -2147483648,
                }
            }

            [TagStructure(Size = 0x14)]
            public class ResourceType
            {
                public uint Unknown;
                public uint Unknown2;
                public uint Unknown3;
                public uint Unknown4;
                public uint Unknown5;
            }

            [TagStructure(Size = 0x4)]
            public class RequiredTagPoolBlock
            {
                public ActiveMembersValue ActiveMembers;

                public enum ActiveMembersValue : int
                {
                    None,
                    _0,
                    _1,
                    _2 = 4,
                    _3 = 8,
                    _4 = 16,
                    _5 = 32,
                    _6 = 64,
                    _7 = 128,
                    _8 = 256,
                    _9 = 512,
                    _10 = 1024,
                    _11 = 2048,
                    _12 = 4096,
                    _13 = 8192,
                    _14 = 16384,
                    _15 = 32768,
                    _16 = 65536,
                    _17 = 131072,
                    _18 = 262144,
                    _19 = 524288,
                    _20 = 1048576,
                    _21 = 2097152,
                    _22 = 4194304,
                    _23 = 8388608,
                    _24 = 16777216,
                    _25 = 33554432,
                    _26 = 67108864,
                    _27 = 134217728,
                    _28 = 268435456,
                    _29 = 536870912,
                    _30 = 1073741824,
                    _31 = -2147483648,
                }
            }

            [TagStructure(Size = 0x4)]
            public class OptionalTagPoolBlock
            {
                public ActiveMembersValue ActiveMembers;

                public enum ActiveMembersValue : int
                {
                    None,
                    _0,
                    _1,
                    _2 = 4,
                    _3 = 8,
                    _4 = 16,
                    _5 = 32,
                    _6 = 64,
                    _7 = 128,
                    _8 = 256,
                    _9 = 512,
                    _10 = 1024,
                    _11 = 2048,
                    _12 = 4096,
                    _13 = 8192,
                    _14 = 16384,
                    _15 = 32768,
                    _16 = 65536,
                    _17 = 131072,
                    _18 = 262144,
                    _19 = 524288,
                    _20 = 1048576,
                    _21 = 2097152,
                    _22 = 4194304,
                    _23 = 8388608,
                    _24 = 16777216,
                    _25 = 33554432,
                    _26 = 67108864,
                    _27 = 134217728,
                    _28 = 268435456,
                    _29 = 536870912,
                    _30 = 1073741824,
                    _31 = -2147483648,
                }
            }
        }

        [TagStructure(Size = 0x24)]
        public class ScenarioZonesetGroup
        {
            public StringId Name;
            public int BspGroupIndex;
            public ImportLoadedBspsValue ImportLoadedBsps;
            public LoadedBspsValue LoadedBsps;
            public LoadedDesignerZonesetsValue LoadedDesignerZonesets;
            public UnknownLoadedDesignerZonesetsValue UnknownLoadedDesignerZonesets;
            public UnloadedDesignerZonesetsValue UnloadedDesignerZonesets;
            public LoadedCinematicZonesetsValue LoadedCinematicZonesets;
            public int BspAtlasIndex;

            public enum ImportLoadedBspsValue : int
            {
                None,
                Bsp0,
                Bsp1,
                Bsp2 = 4,
                Bsp3 = 8,
                Bsp4 = 16,
                Bsp5 = 32,
                Bsp6 = 64,
                Bsp7 = 128,
                Bsp8 = 256,
                Bsp9 = 512,
                Bsp10 = 1024,
                Bsp11 = 2048,
                Bsp12 = 4096,
                Bsp13 = 8192,
                Bsp14 = 16384,
                Bsp15 = 32768,
                Bsp16 = 65536,
                Bsp17 = 131072,
                Bsp18 = 262144,
                Bsp19 = 524288,
                Bsp20 = 1048576,
                Bsp21 = 2097152,
                Bsp22 = 4194304,
                Bsp23 = 8388608,
                Bsp24 = 16777216,
                Bsp25 = 33554432,
                Bsp26 = 67108864,
                Bsp27 = 134217728,
                Bsp28 = 268435456,
                Bsp29 = 536870912,
                Bsp30 = 1073741824,
                Bsp31 = -2147483648,
            }

            public enum LoadedBspsValue : int
            {
                None,
                Bsp0,
                Bsp1,
                Bsp2 = 4,
                Bsp3 = 8,
                Bsp4 = 16,
                Bsp5 = 32,
                Bsp6 = 64,
                Bsp7 = 128,
                Bsp8 = 256,
                Bsp9 = 512,
                Bsp10 = 1024,
                Bsp11 = 2048,
                Bsp12 = 4096,
                Bsp13 = 8192,
                Bsp14 = 16384,
                Bsp15 = 32768,
                Bsp16 = 65536,
                Bsp17 = 131072,
                Bsp18 = 262144,
                Bsp19 = 524288,
                Bsp20 = 1048576,
                Bsp21 = 2097152,
                Bsp22 = 4194304,
                Bsp23 = 8388608,
                Bsp24 = 16777216,
                Bsp25 = 33554432,
                Bsp26 = 67108864,
                Bsp27 = 134217728,
                Bsp28 = 268435456,
                Bsp29 = 536870912,
                Bsp30 = 1073741824,
                Bsp31 = -2147483648,
            }

            public enum LoadedDesignerZonesetsValue : int
            {
                None,
                Set0,
                Set1,
                Set2 = 4,
                Set3 = 8,
                Set4 = 16,
                Set5 = 32,
                Set6 = 64,
                Set7 = 128,
                Set8 = 256,
                Set9 = 512,
                Set10 = 1024,
                Set11 = 2048,
                Set12 = 4096,
                Set13 = 8192,
                Set14 = 16384,
                Set15 = 32768,
                Set16 = 65536,
                Set17 = 131072,
                Set18 = 262144,
                Set19 = 524288,
                Set20 = 1048576,
                Set21 = 2097152,
                Set22 = 4194304,
                Set23 = 8388608,
                Set24 = 16777216,
                Set25 = 33554432,
                Set26 = 67108864,
                Set27 = 134217728,
                Set28 = 268435456,
                Set29 = 536870912,
                Set30 = 1073741824,
                Set31 = -2147483648,
            }

            public enum UnknownLoadedDesignerZonesetsValue : int
            {
                None,
                Set0,
                Set1,
                Set2 = 4,
                Set3 = 8,
                Set4 = 16,
                Set5 = 32,
                Set6 = 64,
                Set7 = 128,
                Set8 = 256,
                Set9 = 512,
                Set10 = 1024,
                Set11 = 2048,
                Set12 = 4096,
                Set13 = 8192,
                Set14 = 16384,
                Set15 = 32768,
                Set16 = 65536,
                Set17 = 131072,
                Set18 = 262144,
                Set19 = 524288,
                Set20 = 1048576,
                Set21 = 2097152,
                Set22 = 4194304,
                Set23 = 8388608,
                Set24 = 16777216,
                Set25 = 33554432,
                Set26 = 67108864,
                Set27 = 134217728,
                Set28 = 268435456,
                Set29 = 536870912,
                Set30 = 1073741824,
                Set31 = -2147483648,
            }

            public enum UnloadedDesignerZonesetsValue : int
            {
                None,
                Set0,
                Set1,
                Set2 = 4,
                Set3 = 8,
                Set4 = 16,
                Set5 = 32,
                Set6 = 64,
                Set7 = 128,
                Set8 = 256,
                Set9 = 512,
                Set10 = 1024,
                Set11 = 2048,
                Set12 = 4096,
                Set13 = 8192,
                Set14 = 16384,
                Set15 = 32768,
                Set16 = 65536,
                Set17 = 131072,
                Set18 = 262144,
                Set19 = 524288,
                Set20 = 1048576,
                Set21 = 2097152,
                Set22 = 4194304,
                Set23 = 8388608,
                Set24 = 16777216,
                Set25 = 33554432,
                Set26 = 67108864,
                Set27 = 134217728,
                Set28 = 268435456,
                Set29 = 536870912,
                Set30 = 1073741824,
                Set31 = -2147483648,
            }

            public enum LoadedCinematicZonesetsValue : int
            {
                None,
                Set0,
                Set1,
                Set2 = 4,
                Set3 = 8,
                Set4 = 16,
                Set5 = 32,
                Set6 = 64,
                Set7 = 128,
                Set8 = 256,
                Set9 = 512,
                Set10 = 1024,
                Set11 = 2048,
                Set12 = 4096,
                Set13 = 8192,
                Set14 = 16384,
                Set15 = 32768,
                Set16 = 65536,
                Set17 = 131072,
                Set18 = 262144,
                Set19 = 524288,
                Set20 = 1048576,
                Set21 = 2097152,
                Set22 = 4194304,
                Set23 = 8388608,
                Set24 = 16777216,
                Set25 = 33554432,
                Set26 = 67108864,
                Set27 = 134217728,
                Set28 = 268435456,
                Set29 = 536870912,
                Set30 = 1073741824,
                Set31 = -2147483648,
            }
        }

        [TagStructure(Size = 0x10)]
        public class ScenarioBsp
        {
            public CachedTagInstance Bsp;
        }

        [TagStructure(Size = 0x14)]
        public class UnknownBlock
        {
            public uint Unknown;
            public uint Unknown2;
            public uint Unknown3;
            public uint Unknown4;
            public uint Unknown5;
        }

        [TagStructure(Size = 0x4)]
        public class PredictionABlock
        {
            public uint Key;
        }

        [TagStructure(Size = 0x8)]
        public class PredictionBBlock
        {
            public short OverallIndex;
            public short ACount;
            public int AIndex;
        }

        [TagStructure(Size = 0x4)]
        public class PredictionCBlock
        {
            public short OverallIndex;
            public short BIndex;
        }

        [TagStructure(Size = 0x8)]
        public class PredictionDTag
        {
            public short CCount;
            public short CIndex;
            public short ACount;
            public short AIndex;
        }

        [TagStructure(Size = 0xC)]
        public class PredictionD2Tag
        {
            public CachedTagInstance Tag;
            public int FirstValue;
            public int SecondValue;
        }
    }
}

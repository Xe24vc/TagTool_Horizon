using System;
using System.Collections.Generic;
using BlamCore.Cache.HaloOnline;
using BlamCore.Common;
using BlamCore.Serialization;
using BlamCore.Cache;

namespace BlamCore.TagResources
{
    [TagStructure(Name = "model_animation_tag_resource", Size = 0xC)]
    public class ModelAnimationTagResource
    {
        public List<GroupMember> GroupMembers;

        public enum GroupMemberMovementDataType : sbyte
        {
            None,
            dx_dy,
            dx_dy_dyaw,
            dx_dy_dz_dyaw,
            dx_dy_dz_dangleaxis,
            x_y_z_absolute,
            Auto
        }

        public enum GroupMemberHeaderType : sbyte
        {
            Overlay = 0,
            [MinVersion(CacheVersion.HaloOnline106708)]
            BaseH3 = 0x18,
            [MaxVersion(CacheVersion.Halo3ODST)]
            BaseHO = 0x0C
        }

        public enum GroupMemberAnimationType : sbyte
        {
            None,       // 0x00
            Type1,      // 0x01 base
            Unused0,    // 0x02 unused
            Type3,      // 0x03 overlay
            Type4,      // 0x04 overlay
            Unused1,    // 0x05 unused
            Type6,      // 0x06 overlay
            Type7,      // 0x07 overlay
            Type8       // 0x08 overlay
        }

        [Flags]
        public enum PrimaryNodeFlags : int
        {
            None = 0,
            Node0 = 1 << 0,
            Node1 = 1 << 1,
            Node2 = 1 << 2,
            Node3 = 1 << 3,
            Node4 = 1 << 4,
            Node5 = 1 << 5,
            Node6 = 1 << 6,
            Node7 = 1 << 7,
            Node8 = 1 << 8,
            Node9 = 1 << 9,
            Node10 = 1 << 10,
            Node11 = 1 << 11,
            Node12 = 1 << 12,
            Node13 = 1 << 13,
            Node14 = 1 << 14,
            Node15 = 1 << 15,
            Node16 = 1 << 16,
            Node17 = 1 << 17,
            Node18 = 1 << 18,
            Node19 = 1 << 19,
            Node20 = 1 << 20,
            Node21 = 1 << 21,
            Node22 = 1 << 22,
            Node23 = 1 << 23,
            Node24 = 1 << 24,
            Node25 = 1 << 25,
            Node26 = 1 << 26,
            Node27 = 1 << 27,
            Node28 = 1 << 28,
            Node29 = 1 << 29,
            Node30 = 1 << 30,
            Node31 = 1 << 31
        }

        [Flags]
        public enum SecondaryNodeFlags : int
        {
            None = 0,
            Node32 = 1 << 32,
            Node33 = 1 << 33,
            Node34 = 1 << 34,
            Node35 = 1 << 35,
            Node36 = 1 << 36,
            Node37 = 1 << 37,
            Node38 = 1 << 38,
            Node39 = 1 << 39,
            Node40 = 1 << 40,
            Node41 = 1 << 41,
            Node42 = 1 << 42,
            Node43 = 1 << 43,
            Node44 = 1 << 44,
            Node45 = 1 << 45,
            Node46 = 1 << 46,
            Node47 = 1 << 47,
            Node48 = 1 << 48,
            Node49 = 1 << 49,
            Node50 = 1 << 50,
            Node51 = 1 << 51,
            Node52 = 1 << 52,
            Node53 = 1 << 53,
            Node54 = 1 << 54,
            Node55 = 1 << 55,
            Node56 = 1 << 56,
            Node57 = 1 << 57,
            Node58 = 1 << 58,
            Node59 = 1 << 59,
            Node60 = 1 << 60,
            Node61 = 1 << 61,
            Node62 = 1 << 62,
            Node63 = 1 << 63
        }

        [TagStructure]
        public class GroupMember
        {
            public StringId Name;
            public uint Checksum;
            public short FrameCount;
            public sbyte NodeCount;
            public GroupMemberMovementDataType MovementDataType;
            public GroupMemberHeaderType BaseHeader; // 0x0 means no base header
            public GroupMemberHeaderType OverlayHeader; // 0x0 means no overlay header (there's always one
            public short Unknown1;
            public short Unknown2;
            public short OverlayOffset;
            public short Unknown3;
            public short Unknown4;
            public uint FlagsOffset;

            public ResourceDataReference AnimationData; // this will point to an Animation object

            [TagStructure]
            public class AnimationHeaderGlobal
            {
                public GroupMemberAnimationType HeaderStructType_; // base/overlay
                public sbyte RotationNodeCount; // number of nodes with rotation frames (XYZW short per frame)
                public sbyte PositionNodeCount; // number of nodes with position frames (XYZ float per frame)
                public sbyte SpecularNodeCount; // number of nodes with position frames (X float per frame); something that affects node render draw distance or lightning
            }

            [TagStructure(Size = 0x20)]
            public class AnimationHeaderType1 // Type1
            {
                public GroupMemberAnimationType HeaderStructType_;
                public sbyte RotationNodeCount;
                public sbyte PositionNodeCount;
                public sbyte SpecularNodeCount;
                public uint Unknown0; // 0x0
                public uint Unknown1; // 0x0
                public uint PositionFramesOffset;
                public uint SpecularFramesOffset;
                public uint RotationFramesSize;
                public uint PositionFramesSize;
                public uint SpecularFramesSize;

                // public uint RotationFramesOffset; // hidden, always 0x20
            }

            [TagStructure(Size = 0x20)]
            public class AnimationHeaderType3 // Type1
            {
                public GroupMemberAnimationType HeaderStructType_;
                public sbyte RotationNodeCount;
                public sbyte PositionNodeCount;
                public sbyte SpecularNodeCount;
                public uint Unknown0; // 0x0
                public uint Unknown1; // 0x0
                public uint PositionFramesOffset;
                public uint SpecularFramesOffset;
                public uint RotationFramesSize;
                public uint PositionFramesSize;
                public uint SpecularFramesSize;

                // public uint RotationFramesOffset; // hidden, always 0x20
            }

            [TagStructure(Size = 0x30)]
            public class AnimationHeaderOverlay // Type4,Type6,Type7
            {
                public GroupMemberAnimationType HeaderStructType_;
                public sbyte RotationNodeCount;
                public sbyte PositionNodeCount;
                public sbyte SpecularNodeCount;
                public uint Unknown0;
                public uint Unknown1;
                public uint PositionFramesCountPerNodeOffset;
                public uint RealFrameMarkerOffset;
                public uint RealFrameMarkerOffset1;
                public uint RotationsRealFrameMarkersEndOffset;
                public uint PositionsRealFrameMarkersEndOffset;
                public uint RotationFramesOffset;
                public uint PositionFramesOffset;
                public uint SpecularFramesOffset;
                public uint UselessPadding;
            }

            [TagStructure(Size = 0x20)]
            public class AnimationHeaderType8 // Type8; OverlayRotations are 4x uint32) per frame
            {
                public GroupMemberAnimationType HeaderStructType_;
                public sbyte RotationNodeCount;
                public sbyte PositionNodeCount;
                public sbyte SpecularNodeCount;
                public uint Unknown0; // always 0x0
                public uint Unknown1; // always 0x3F800000
                public uint PositionFramesOffset;
                public uint SpecularFramesOffset;
                public uint FrameCountPerNode;  // spooky sbyte; FrameCount = FrameCountPerNode / 10
                public uint Unknown2;
                public uint Unknown3; // Unknown3 = Unknown2 / 3
            }

            [TagStructure]
            public class Node
            {
                public List<RotationNode> rotationNodes;
                public List<PositionNode> positionNodes;
                public List<SpecularNode> specularNodes;
            }

            [TagStructure]
            public class RotationNode
            {
                public List<RotationFrame> rotationFrame;
            }

            [TagStructure]
            public class PositionNode
            {
                public List<PositionFrame> positionFrame;
            }

            [TagStructure]
            public class SpecularNode
            {
                public List<SpecularFrame> specularFrame;
            }

            [TagStructure]
            public class FrameInfoNode
            {
                public List<FrameInfoDxDy> frameInfoDxDy;
                public List<FrameInfoDxDyDyaw> frameInfoDxDyDyaw;
            }

            [TagStructure]
            public class RotationFrame
            {
                public short X;
                public short Y;
                public short Z;
                public short W;
            }

            [TagStructure]
            public class SpecularFrame
            {
                public uint X;
            }

            [TagStructure]
            public class PositionFramesCountPerNode
            {
                public uint X;
            }

            [TagStructure]
            public class RealFrameMarker
            {
                public sbyte X;
                public sbyte Y;
                public sbyte Z;
                public sbyte W;
            }

            [TagStructure]
            public class RotationFrameFloat
            {
                public uint X;
                public uint Y;
                public uint Z;
                public uint W;
            }

            [TagStructure]
            public class PositionFrame
            {
                public uint X;
                public uint Y;
                public uint Z;
            }

            [TagStructure]
            public class DepthFrame
            {
                public uint W;
            }

            [TagStructure]
            public class FrameInfoDxDy
            {
                public uint X;
                public uint Y;
            }

            [TagStructure]
            public class FrameInfoDxDyDyaw
            {
                public uint X;
                public uint Y;
                public uint Z;
            }

            [TagStructure]
            public class Footer
            {
                public List<Footer32> Footer32;
                public List<Footer64> Footer64;
            }

            [TagStructure]
            public class Footer32
            {
                public PrimaryNodeFlags primaryFlags;
            }

            [TagStructure]
            public class Footer64
            {
                public PrimaryNodeFlags primaryFlags;
                public SecondaryNodeFlags secondaryFlags;
            }

            [TagStructure]
            public class Padding
            {
                public uint pad;
            }
        }
    }
}
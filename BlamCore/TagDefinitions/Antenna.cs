using System.Collections.Generic;
using BlamCore.Cache.HaloOnline;
using BlamCore.Common;
using BlamCore.Serialization;

namespace BlamCore.TagDefinitions
{
    [TagStructure(Name = "antenna", Class = "ant!", Size = 0x50)]
    public class Antenna
    {
        public StringId AttachmentMarkerName;
        public CachedTagInstance Bitmaps;
        public CachedTagInstance Physics;
        public uint Unknown;
        public uint Unknown2;
        public uint Unknown3;
        public uint Unknown4;
        public uint Unknown5;
        public uint Unknown6;
        public uint Unknown7;
        public List<Vertex> Vertices;
        public uint Unknown8;

        [TagStructure(Size = 0x40)]
        public class Vertex
        {
            public Angle AngleY;
            public Angle AngleP;
            public float Length;
            public short SequenceIndex;
            public short Unknown;
            public float ColorA;
            public float ColorR;
            public float ColorG;
            public float ColorB;
            public float LodColorA;
            public float LodColorR;
            public float LodColorG;
            public float LodColorB;
            public float Width;
            public uint Unknown2;
            public uint Unknown3;
            public uint Unknown4;
        }
    }
}

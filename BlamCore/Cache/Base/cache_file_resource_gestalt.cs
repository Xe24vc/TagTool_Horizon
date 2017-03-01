using System.Collections.Generic;


namespace BlamCore.Cache
{
    public abstract class cache_file_resource_gestalt
    {
        public List<RawEntry> RawEntries;

        public cache_file_resource_gestalt()
        {
            RawEntries = new List<RawEntry>();
        }

        public abstract class RawEntry
        {
            public int TagID;
            public int RawID;
            public int FixupOffset;
            public int FixupSize;
            public int LocationType;
            public int SegmentIndex;

            public List<ResourceFixup> Fixups;
            public List<ResourceDefinitionFixup> DefinitionFixups;

            public RawEntry()
            {
                Fixups = new List<ResourceFixup>();
                DefinitionFixups = new List<ResourceDefinitionFixup>();
            }

            public abstract class ResourceFixup
            {
                public int BlockOffset;
                public int FixupType;
                public int Offset;
                public int RawFixup;
            }

            public abstract class ResourceDefinitionFixup
            {
                public int Offset;
                public int Type;
            }
        }

        public byte[] FixupData;
    }
}

﻿using BlamCore.IO;

namespace BlamCore.Cache.Halo4Retail
{
    public class cache_file_resource_gestalt : Halo4Beta.cache_file_resource_gestalt
    {
        protected cache_file_resource_gestalt() { }

        public cache_file_resource_gestalt(Base.CacheFile Cache, int Address)
        {
            EndianReader Reader = Cache.Reader;
            Reader.SeekTo(Address);

            #region Raw Entries
            Reader.SeekTo(Address + 88);
            int iCount = Reader.ReadInt32();
            int iOffset = Reader.ReadInt32() - Cache.Magic;
            for (int i = 0; i < iCount; i++)
                RawEntries.Add(new RawEntry(Cache, iOffset + 68 * i));
            #endregion

            #region Fixup Data
            Reader.SeekTo(Address + 340);
            iCount = Reader.ReadInt32();
            Reader.ReadInt32();
            Reader.ReadInt32();
            iOffset = Reader.ReadInt32() - Cache.Magic;
            Reader.SeekTo(iOffset);
            FixupData = Reader.ReadBytes(iCount);
            #endregion
        }
    }
}
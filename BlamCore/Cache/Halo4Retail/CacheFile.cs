using Composer;
using System.Collections.Generic;


namespace BlamCore.Cache.Halo4Retail
{
    public class CacheFile : Halo3Retail.CacheFile
    {
        public List<SoundPackInfo> SoundPacks;
        public Dictionary<uint, List<SoundFileInfo>> SoundFiles;

        public CacheFile(string Filename, string Build)
            : base(Filename, Build)
        {
            Version = CacheVersion.Halo4Retail;
        }
    }
}

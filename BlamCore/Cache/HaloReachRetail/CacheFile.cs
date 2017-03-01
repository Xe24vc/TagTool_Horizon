namespace BlamCore.Cache.HaloReachRetail
{
    public class CacheFile : Halo3Retail.CacheFile
    {
        public CacheFile(string Filename, string Build)
            : base(Filename, Build)
        {
            Version = CacheVersion.HaloReachRetail;
        }
    }
}

namespace BlamCore.Cache.Halo4Beta
{
    public class CacheFile : Halo3Retail.CacheFile
    {
        public CacheFile(string Filename, string Build)
            : base(Filename, Build)
        {
            Version = CacheVersion.Halo4Beta;
        }
    }
}

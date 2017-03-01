namespace BlamCore.Cache.Halo1CE
{
    public class CacheFile : Halo1PC.CacheFile
    {
        public CacheFile(string Filename, string Build)
            : base(Filename, Build)
        {
            Version = CacheVersion.Halo1CE;
        }
    }
}

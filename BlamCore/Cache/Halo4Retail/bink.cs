using BlamCore.IO;
using bik = BlamCore.Cache.bink;

namespace BlamCore.Cache.Halo4Retail
{
    public class bink : bik
    {
        public bink(Base.CacheFile Cache, int Address)
        {
            EndianReader Reader = Cache.Reader;
            Reader.SeekTo(Address);

            Reader.Skip(4);
            RawID = Reader.ReadInt32();
        }
    }
}

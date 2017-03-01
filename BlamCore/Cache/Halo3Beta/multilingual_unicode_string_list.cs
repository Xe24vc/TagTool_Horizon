
using unic = BlamCore.Cache.multilingual_unicode_string_list;
using BlamCore.IO;

namespace BlamCore.Cache.Halo3Beta
{
    public class multilingual_unicode_string_list : unic
    {
        public multilingual_unicode_string_list(Base.CacheFile Cache, int Address)
        {
            EndianReader Reader = Cache.Reader;
            Reader.SeekTo(Address);

            Reader.SeekTo(Address + 32);
            for (int i = 0; i < 12; i++)
            {
                Indices.Add(Reader.ReadUInt16());
                Lengths.Add(Reader.ReadUInt16());
            }
        }
    }
}

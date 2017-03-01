using BlamCore.IO;
using snd_ = BlamCore.Cache.sound;

namespace BlamCore.Cache.Halo4Retail
{
    public class sound : snd_
    {
        public uint SoundAddress1;
        public uint SoundAddress2;
        public int SoundBankTagID;

        public sound(Base.CacheFile Cache, int Address)
        {
            EndianReader Reader = Cache.Reader;
            Reader.SeekTo(Address);

            Reader.SeekTo(Address + 12);
            SoundAddress1 = Reader.ReadUInt32();
            SoundAddress2 = Reader.ReadUInt32();

            Reader.SeekTo(Address + 52);
            SoundBankTagID = Reader.ReadInt32();
        }
    }
}

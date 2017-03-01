using BlamCore.Common;
using BlamCore.IO;
using snd_ = BlamCore.Cache.sound;

namespace BlamCore.Cache.ReachBeta
{
    public class sound : snd_
    {
        public sound(Base.CacheFile Cache, int Address)
        {
            EndianReader Reader = Cache.Reader;
            Reader.SeekTo(Address);

            Flags = new Bitmask(Reader.ReadInt16());
            SoundClass = Reader.ReadByte();
            SampleRate = (SampleRate)Reader.ReadByte();
            Encoding = Reader.ReadByte();
            CodecIndex = Reader.ReadByte();
            PlaybackIndex = Reader.ReadInt16();
            DialogueUnknown = Reader.ReadInt16();

            Reader.SeekTo(Address + 28);
            RawID = Reader.ReadInt32();
        }
    }
}

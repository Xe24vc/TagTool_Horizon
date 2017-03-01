using Composer.Wwise;
using BlamCore.IO;

namespace Composer
{
    public class SoundPackInfo
    {
        public string Name;
        public EndianReader Reader;
        public SoundPack Pack;

        public override string ToString()
        {
            return Name;
        }
    }

    public class SoundFileInfo
    {
        public EndianReader Reader;
        public int Offset;
        public int Size;
        public uint ID;
        public SoundFormat Format;
    }
}

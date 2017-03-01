namespace BlamCore.Cache
{
    public enum SampleRate
    {
        _22050Hz = 0,
        _44100Hz = 1
    }

    public enum SoundType
    {
        Mono = 0,
        Stereo = 1,
        Unknown2 = 2, //2 and 3 probably surround stereo
        Unknown3 = 3
    }
}

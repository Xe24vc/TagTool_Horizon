using BlamCore.Serialization;

namespace BlamCore.Scripting
{
    [TagStructure(Size = 0x28)]
    public class ScriptGlobal
    {
        [TagField(Length = 32)]
        public string Name;
        public ScriptValueType Type;
        public short Unknown;
        public ushort InitializationExpressionSalt;
        public ushort InitializationExpressionIndex;
    }
}

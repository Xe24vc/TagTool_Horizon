using BlamCore.Serialization;

namespace BlamCore.Scripting
{
    [TagStructure(Size = 0x18)]
    public class ScriptExpression
    {
        public ushort Salt;
        public ushort Opcode;
        public ScriptValueType ValueType;
        public short ExpressionType;
        public ushort NextExpressionSalt;
        public ushort NextExpressionIndex;
        public uint StringAddress;
        public sbyte Value03Msb;
        public sbyte Value02Byte;
        public sbyte Value01Byte;
        public sbyte Value00Lsb;
        public short LineNumber;
        public short Unknown;
    }
}

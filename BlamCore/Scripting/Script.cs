using System.Collections.Generic;
using BlamCore.Serialization;

namespace BlamCore.Scripting
{
    [TagStructure(Size = 0x34)]
    public class Script
    {
        [TagField(Length = 32)]
        public string ScriptName;
        public ScriptType Type;
        public ScriptValueType ReturnType;
        public ushort RootExpressionSalt;
        public ushort RootExpressionIndex;
        public List<ScriptParameter> Parameters;
    }
}

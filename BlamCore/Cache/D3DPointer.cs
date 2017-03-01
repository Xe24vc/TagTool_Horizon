using BlamCore.Serialization;

namespace BlamCore.Cache
{
    /// <summary>
    /// Points to a D3D-related object.
    /// </summary>
    [TagStructure(Size = 0xC)]
    public class D3DPointer<TDefinition>
    {
        /// <summary>
        /// The definition data for the object.
        /// </summary>
        [TagField(Flags = TagFieldFlags.Indirect)] public TDefinition Definition;

        /// <summary>
        /// The address of the object in memory.
        /// This should be set to 0 because it will be filled in by the game.
        /// </summary>
        public uint Address;

        public int UnusedC;
    }
}

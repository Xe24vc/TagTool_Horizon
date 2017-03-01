using System;
using BlamCore.Cache.HaloOnline;
using BlamCore.IO;

namespace BlamCore.Serialization
{
    public class DataSerializationContext : ISerializationContext
    {
        public EndianReader Reader { get; }
        public EndianWriter Writer { get; }

        public DataSerializationContext(EndianReader reader, EndianWriter writer)
        {
            Reader = reader;
            Writer = writer;
        }

        public uint AddressToOffset(uint currentOffset, uint address)
        {
            return (uint)new ResourceAddress(address).Offset;
        }

        public EndianReader BeginDeserialize(TagStructureInfo info)
        {
            return Reader;
        }

        public void BeginSerialize(TagStructureInfo info)
        {
        }

        public IDataBlock CreateBlock()
        {
            throw new NotImplementedException();
        }

        public void EndDeserialize(TagStructureInfo info, object obj)
        {
        }

        public void EndSerialize(TagStructureInfo info, byte[] data, uint mainStructOffset)
        {
        }

        public CachedTagInstance GetTagByIndex(int index)
        {
            throw new NotImplementedException();
        }
    }
}

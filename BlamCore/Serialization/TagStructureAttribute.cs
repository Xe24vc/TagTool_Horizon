using System;
using BlamCore.Cache;

namespace BlamCore.Serialization
{
    /// <summary>
    /// Attribute for a serializable structure in a tag.
    /// If a structure has more than one of these attributes, then all attributes with version restrictions will be checked first.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class TagStructureAttribute : Attribute
    {
        public TagStructureAttribute()
        {
            MinVersion = CacheVersion.Unknown;
            MaxVersion = CacheVersion.Unknown;
        }

        /// <summary>
        /// The internal name of the structure.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The name of the tag class that the structure applies to.
        /// </summary>
        public string Class { get; set; }

        /// <summary>
        /// The size of the structure in bytes, NOT including parent structures.
        /// </summary>
        public uint Size { get; set; }

        /// <summary>
        /// The minimum engine version which the structure applies to.
        /// Can be <see cref="CacheVersion.Unknown"/> (default) if unbounded.
        /// </summary>
        public CacheVersion MinVersion { get; set; }

        /// <summary>
        /// The maximum engine version which the structure applies to.
        /// Can be <see cref="CacheVersion.Unknown"/> (default) if unbounded.
        /// </summary>
        public CacheVersion MaxVersion { get; set; }

        /// <summary>
        /// The power of two to align the block to.
        /// Can be 0 if not set.
        /// </summary>
        /// <remarks>
        /// Note that this value is only a guide for the serializer, and a
        /// different alignment may actually be used if necessary.
        /// </remarks>
        public uint Align { get; set; }
    }
}

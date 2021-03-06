﻿using System;
using BlamCore.Cache;

namespace BlamCore.Serialization
{
    /// <summary>
    /// Attribute indicating the last engine version in which a tag element is present.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class MaxVersionAttribute : Attribute
    {
        public MaxVersionAttribute(CacheVersion version)
        {
            Version = version;
        }

        public CacheVersion Version { get; set; }
    }
}

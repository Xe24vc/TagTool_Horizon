using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BlamCore.Cache;
using BlamCore.Cache.Base;
using BlamCore.Cache.HaloOnline;
using BlamCore.Common;
using BlamCore.Geometry;
using BlamCore.Serialization;
using BlamCore.TagDefinitions;

namespace TagTool.Commands.Porting
{
    class ReadTagCommand : Command
    {
        public GameCacheContext CacheContext { get; }
        public CacheFile BlamCache { get; }

        public ReadTagCommand(GameCacheContext cacheContext, CacheFile blamCache)
            : base(CommandFlags.None,

                  "a",
                  "",

                  "a",

                  "")
        {
            CacheContext = cacheContext;
            BlamCache = blamCache;
        }

        public override bool Execute(List<string> args)
        {

            Console.WriteLine("");
            foreach (var tag in BlamCache.IndexItems)
            {
                if (tag.ClassCode == "rmsh")
                {
                    var blamDeserializer = new TagDeserializer(BlamCache.Version);
                    var blamContext = new CacheSerializationContext(CacheContext, BlamCache, tag);
                    var blamShader = blamDeserializer.Deserialize<Shader>(blamContext);
            
                    Console.Write("{0:X4},", tag.Filename);
                    for (int i = 0; i < blamShader.Unknown.Count; i++)
                    {
                        string unknown = "";
                        unknown = unknown + "_" + blamShader.Unknown[i].Unknown.ToString();
                        Console.Write(unknown);
                    }
                    Console.WriteLine("");
                }
            }

            return true;
        }
    }
}
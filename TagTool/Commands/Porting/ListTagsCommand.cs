using System;
using System.Collections.Generic;
using System.IO;
using BlamCore.Cache.Base;
using BlamCore.Cache.HaloOnline;
using BlamCore.IO;
using BlamCore.Serialization;

namespace TagTool.Commands.Porting
{
    class ListTagsCommand : Command
    {
        public GameCacheContext CacheContext { get; }
        public CacheFile BlamCache { get; }

        public ListTagsCommand(GameCacheContext cacheContext, CacheFile blamCache)
            : base(CommandFlags.Inherit,

                  "ListTags",
                  "List all tags in the current blam cache.",

                  "ListTags <tagClass>",
                  "List all tags in the current blam cache.")
        {
            CacheContext = cacheContext;
            BlamCache = blamCache;
        }

        public override bool Execute(List<string> args)
        {
            List <string> tagsList = new List<string>();
            if (args.Count == 1)
            {
                foreach (var tag in BlamCache.IndexItems)
                {
                    if (tag.ClassCode == args[0])
                    {
                        tagsList.Add("[" + tag.ClassCode.ToString() + "] " + tag.Filename.ToString() ); // BlamCache.Header.scenarioName
                    }
                }
            }
            else
            {
                foreach (var tag in BlamCache.IndexItems)
                {
                    tagsList.Add("[" + tag.ClassCode.ToString() + "] " + tag.Filename.ToString());
                }
            }

            tagsList.Sort();
            foreach (var tagName in tagsList)
            {
                Console.WriteLine(tagName);
            }
            
            return true;
        }
    }
}

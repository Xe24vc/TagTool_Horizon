using BlamCore.Cache;
using System;
using System.Collections.Generic;
using BlamCore.Cache.HaloOnline;
using BlamCore.Cache.Base;

namespace TagTool.Commands.Porting
{
    class ListBitmapsCommand : Command
    {
        private GameCacheContext CacheContext { get; }
        private CacheFile BlamCache { get; }

        public ListBitmapsCommand(GameCacheContext cacheContext, CacheFile blamCache)
            : base(CommandFlags.None,

                  "ListBitmaps",
                  "",

                  "ListBitmaps <Blam Tag>",
                  "")
        {
            CacheContext = cacheContext;
            BlamCache = blamCache;
        }

        public override bool Execute(List<string> args)
        {
            if (args.Count != 1)
                return false;

            CacheFile.IndexItem item = null;

            Console.WriteLine("Verifying blam shader tag...");

            var shaderName = args[0];

            foreach (var tag in BlamCache.IndexItems)
            {
                if ((tag.ParentClass == "rm") && tag.Filename == shaderName)
                {
                    item = tag;
                    break;
                }
            }

            if (item == null)
            {
                Console.WriteLine("Blam shader tag does not exist: " + shaderName);
                return false;
            }

            var renderMethod = DefinitionsManager.rmsh(BlamCache, item);

            var templateItem = BlamCache.IndexItems.Find(i =>
                i.ID == renderMethod.Properties[0].TemplateTagID);

            var template = DefinitionsManager.rmt2(BlamCache, templateItem);

            for (var i = 0; i < template.UsageBlocks.Count; i++)
            {
                var bitmItem = BlamCache.IndexItems.Find(j =>
                j.ID == renderMethod.Properties[0].ShaderMaps[i].BitmapTagID);
                Console.WriteLine(bitmItem);
            }

            return true;
        }
    }
}

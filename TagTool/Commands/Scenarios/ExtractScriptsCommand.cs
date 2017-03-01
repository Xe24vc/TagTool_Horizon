using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlamCore.Cache.HaloOnline;
using BlamCore.TagDefinitions;

namespace TagTool.Commands.Scenarios
{
    class ExtractScriptsCommand : Command
    {
        private GameCacheContext CacheContext { get; }
        private CachedTagInstance Tag { get; }
        private Scenario Definition { get; }

        public ExtractScriptsCommand(GameCacheContext cacheContext, CachedTagInstance tag, Scenario definition)
            : base(CommandFlags.Inherit,
                  
                  "ExtractScripts",
                  "Extracts all scripts in the current scenario tag to a file.",
                  
                  "ExtractScripts <Output File>",
                  
                  "Extracts all scripts in the current scenario tag to a file.")
        {
            CacheContext = cacheContext;
            Tag = tag;
            Definition = definition;
        }

        public override bool Execute(List<string> args)
        {
            if (args.Count != 1)
                return false;

            var scriptFile = new FileInfo(args[0]);
            
            return true;
        }
    }
}

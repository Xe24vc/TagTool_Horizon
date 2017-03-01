using BlamCore.Cache;
using System;
using System.Collections.Generic;
using System.IO;
using BlamCore.Cache.HaloOnline;

namespace TagTool.Commands.Porting
{
    class OpenCacheFileCommand : Command
    {
        private CommandContextStack ContextStack { get; }
        private GameCacheContext CacheContext { get; }

        public OpenCacheFileCommand(CommandContextStack contextStack, GameCacheContext cacheContext)
            : base(CommandFlags.None,

                  "OpenCacheFile",
                  "Opens a porting context on a cache file from H1X/H1PC/H1CE/H2X/H3B/H3/ODST.",

                  "OpenCacheFile <Cache File>",
                  "Opens a porting context on a cache file from H1X/H1PC/H1CE/H2X/H3B/H3/ODST.")
        {
            ContextStack = contextStack;
            CacheContext = cacheContext;
        }

        public override bool Execute(List<string> args)
        {
            if (args.Count != 1)
                return false;

            var blamCacheFile = new FileInfo(args[0]);

            if (!blamCacheFile.Exists)
                throw new FileNotFoundException(blamCacheFile.FullName);

            Console.Write("Loading blam cache file...");

            var blamCache = CacheManager.GetCache(blamCacheFile.FullName);

            Console.WriteLine("done.");

            ContextStack.Push(PortingContextFactory.Create(ContextStack, CacheContext, blamCache));
            
            return true;
        }
    }
}
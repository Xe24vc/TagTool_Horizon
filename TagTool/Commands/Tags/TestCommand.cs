using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using BlamCore.Cache.HaloOnline;
using BlamCore.Cache;
using BlamCore.TagDefinitions;

namespace TagTool.Commands.Tags
{
    class TestCommand : Command
    {
        private GameCacheContext CacheContext;

        public TestCommand(GameCacheContext cacheContext) : base(
            CommandFlags.None,

            "Test",
            "",

            "Test",

            "")
        {
            CacheContext = cacheContext;
        }

        public override bool Execute(List<string> args)
        {
            using (var writer = new StreamWriter(File.OpenWrite(@"D:\UNSORTED\test.txt")))
            {
                var a = Directory.EnumerateFiles(@"D:\Halo\Map Packs\H3MAPS\");
                foreach (var b in a)
                {
                //string b = @"D:\Halo\Map Packs\H3MAPS\005_intro.map";
                    try
                    {
                        var blamCacheFile = new FileInfo(b);
                        if (!blamCacheFile.Exists)
                            throw new FileNotFoundException(blamCacheFile.FullName);
                        Console.WriteLine("Loading blam cache file...");

                        var blamCache = CacheManager.GetCache(blamCacheFile.FullName);

                        Console.WriteLine(blamCache.Filename);

                        foreach (var tag in blamCache.IndexItems)
                        {
                            if (tag.ClassCode == "rmsh")
                            {
                                var blamDeserializer = new TagDeserializer(blamCache.Version);
                                var blamContext = new CacheSerializationContext(CacheContext, blamCache, tag);
                                var blamShader = blamDeserializer.Deserialize<Shader>(blamContext);

                                string unknown = "";
                                for (int i = 0; i < blamShader.Unknown.Count; i++)
                                {
                                    unknown = unknown + "_" + blamShader.Unknown[i].Unknown.ToString();
                                }
                                writer.WriteLine(tag.Filename + "," + unknown);
                            }
                        }
                    }
                    catch (Exception) { }
                 // break;
                }
            }

            return true;
        }
    }
}

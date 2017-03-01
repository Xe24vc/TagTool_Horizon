using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using BlamCore.Cache.HaloOnline;
using BlamCore.TagDefinitions;
using System.Linq;

namespace TagTool.Commands.Tags
{
    class ReadTagCommand : Command
    {
        private GameCacheContext CacheContext { get; }
        private CachedTagInstance Tag { get; }

        public ReadTagCommand(GameCacheContext cacheContext) : base(
            CommandFlags.None,

            "a",
            "",

            "a",

            "")
        {
            CacheContext = cacheContext;
        }

        public override bool Execute(List<string> args)
        {
            CachedTagInstance tag;
            
            tag = ArgumentParser.ParseTagSpecifier(CacheContext, args[0]);

            Shader rmsh;
            using (var cacheStream = CacheContext.TagCacheFile.Open(FileMode.Open, FileAccess.ReadWrite))
            {
                var edContext = new TagSerializationContext(cacheStream, CacheContext, tag);
                rmsh = CacheContext.Deserializer.Deserialize<Shader>(edContext);
            }

            bool has = false;

            for (int i = 0; i < rmsh.Unknown.Count; i++)
            {
                Console.Write("_{0}", rmsh.Unknown[i].Unknown);
                has = true;
            }
            if (has == false) Console.WriteLine("none");

            Console.WriteLine("");

            return true;
        }
    }
}
/*
// get dependent tag
            CachedTagInstance tag;

            tag = ArgumentParser.ParseTagSpecifier(CacheContext, args[0]);

            // var searchClasses = ArgumentParser.ParseGroupTags(CacheContext.StringIdCache, args);

            // tags = CacheContext.TagCache.Index.FindAllInGroups(searchClasses).ToArray();

            Model hlmt;

            using (var cacheStream = CacheContext.TagCacheFile.Open(FileMode.Open, FileAccess.ReadWrite))
            {
                var edContext = new TagSerializationContext(cacheStream, CacheContext, tag);
                hlmt = CacheContext.Deserializer.Deserialize<Model>(edContext);
            }

            var a = hlmt.Animation;

            ModelAnimationGraph animation;

            using (var cacheStream = CacheContext.TagCacheFile.Open(FileMode.Open, FileAccess.ReadWrite))
            {
                var edContext = new TagSerializationContext(cacheStream, CacheContext, a);
                animation = CacheContext.Deserializer.Deserialize<ModelAnimationGraph>(edContext);
            }

    */
/*
// read every mode's string id and console write it along each shader
            List<string> args2 = new List<string>();
            args2.Add("mode");

            var searchClasses = ArgumentParser.ParseGroupTags(CacheContext.StringIdCache, args2);

            CachedTagInstance[] tags;

            tags = CacheContext.TagCache.Index.FindAllInGroups(searchClasses).ToArray();

            RenderModel mode;

            foreach (var tag in tags)
            {
                using (var cacheStream = CacheContext.TagCacheFile.Open(FileMode.Open, FileAccess.ReadWrite))
                {
                    var edContext = new TagSerializationContext(cacheStream, CacheContext, tag);
                    mode = CacheContext.Deserializer.Deserialize<RenderModel>(edContext);
                }

                for (int i = 0; i < mode.Materials.Count; i++)
                {
                    Console.WriteLine("{0}_{2},{1:X4},", CacheContext.StringIdCache.GetString(mode.Name), mode.Materials[i].RenderMethod.Index, i);
                }
            }

    */
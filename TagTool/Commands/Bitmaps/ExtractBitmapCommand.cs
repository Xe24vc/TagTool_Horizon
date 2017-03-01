﻿using System;
using System.Collections.Generic;
using System.IO;
using BlamCore.Bitmaps;
using BlamCore.Cache.HaloOnline;
using BlamCore.Serialization;
using BlamCore.TagDefinitions;

namespace TagTool.Commands.Bitmaps
{
    class ExtractBitmapCommand : Command
    {
        private GameCacheContext CacheContext { get; }
        private CachedTagInstance Tag { get; }
        private Bitmap Bitmap { get; }

        public ExtractBitmapCommand(GameCacheContext cacheContext, CachedTagInstance tag, Bitmap bitmap)
            : base(CommandFlags.None,

                  "ExtractBitmap",
                  "Extracts a bitmap to a file.",

                  "ExtractBitmap <output directory>",

                  "Extracts a bitmap to a file.")
        {
            CacheContext = cacheContext;
        }

        public override bool Execute(List<string> args)
        {
            if (args.Count != 1)
                return false;
            
            if (Tag == null)
                return false;

            var directory = args[1];

            if (!Directory.Exists(directory))
            {
                Console.Write("Destination directory does not exist. Create it? [y/n] ");
                var answer = Console.ReadLine().ToLower();

                if (answer.Length == 0 || !(answer.StartsWith("y") || answer.StartsWith("n")))
                    return false;

                if (answer.StartsWith("y"))
                    Directory.CreateDirectory(directory);
                else
                    return false;
            }

            var extractor = new BitmapDdsExtractor(CacheContext);

            using (var tagsStream = CacheContext.OpenTagCacheRead())
            {
                try
                {
                    var tagContext = new TagSerializationContext(tagsStream, CacheContext, Tag);
                    var bitmap = CacheContext.Deserializer.Deserialize<Bitmap>(tagContext);
                    var ddsOutDir = directory;

                    if (bitmap.Images.Count > 1)
                    {
                        ddsOutDir = Path.Combine(directory, Tag.Index.ToString("X8"));
                        Directory.CreateDirectory(ddsOutDir);
                    }

                    for (var i = 0; i < bitmap.Images.Count; i++)
                    {
                        var outPath = Path.Combine(ddsOutDir, ((bitmap.Images.Count > 1) ? i.ToString() : Tag.Index.ToString("X8")) + ".dds");

                        using (var outStream = File.Open(outPath, FileMode.Create, FileAccess.Write))
                        {
                            extractor.ExtractDds(CacheContext.Deserializer, bitmap, i, outStream);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR: Failed to extract bitmap: " + ex.Message);
                }
            }

            Console.WriteLine("Done!");

            return true;
        }
    }
}

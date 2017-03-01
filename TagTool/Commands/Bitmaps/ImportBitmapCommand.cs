using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using BlamCore.Bitmaps;
using BlamCore.Serialization;
using BlamCore.TagDefinitions;
using BlamCore.Cache.HaloOnline;

namespace TagTool.Commands.Bitmaps
{
    class ImportBitmapCommand : Command
    {
        private GameCacheContext CacheContext { get; }
        private CachedTagInstance Tag { get; }
        private Bitmap Bitmap { get; }

        public ImportBitmapCommand(GameCacheContext cacheContext, CachedTagInstance tag, Bitmap bitmap)
            : base(CommandFlags.None,

                  "ImportBitmap",
                  "Imports an image from a DDS file.",

                  "ImportBitmap <image index> <dds file>",

                  "The image index must be in hexadecimal.\n" +
                  "No conversion will be done on the data in the DDS file.\n" +
                  "The pixel format must be supported by the game.")
        {
            CacheContext = cacheContext;
            Tag = tag;
            Bitmap = bitmap;
        }

        public override bool Execute(List<string> args)
        {
            if (args.Count != 2)
                return false;

            int imageIndex;
            if (!int.TryParse(args[0], NumberStyles.HexNumber, null, out imageIndex))
                return false;


            if (Bitmap.Images.Count == 0)
            {
                Bitmap.Flags = Bitmap.RuntimeFlags.UseResource;
                Bitmap.Images.Add(new Bitmap.Image());
                Bitmap.Resources.Add(new Bitmap.BitmapResource());
            }

            if (imageIndex < 0)
            {
                Console.Error.WriteLine("Invalid image index.");
                return true;
            }

            if (imageIndex >= Bitmap.Images.Count) // To Test: adding new resources to a bitm with more than 1 permutation
            {
                Bitmap.Flags = Bitmap.RuntimeFlags.UseResource;
                Bitmap.Images.Add(new Bitmap.Image());
                Bitmap.Resources.Add(new Bitmap.BitmapResource());
            }

            var imagePath = args[1];
            
            Console.WriteLine("Importing image data...");

            try
            {
                using (var imageStream = File.OpenRead(imagePath))
                {
                    var injector = new BitmapDdsInjector(CacheContext);
                    injector.InjectDds(CacheContext.Serializer, CacheContext.Deserializer, Bitmap, imageIndex, imageStream);
                }

                using (var tagsStream = CacheContext.OpenTagCacheReadWrite())
                {
                    var tagContext = new TagSerializationContext(tagsStream, CacheContext, Tag);
                    CacheContext.Serializer.Serialize(tagContext, Bitmap);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Importing image data failed: " + ex.Message);
                return true;
            }

            Console.WriteLine("Done!");

            return true;
        }
    }
}

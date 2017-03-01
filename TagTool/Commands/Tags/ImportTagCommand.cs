using System;
using System.Collections.Generic;
using System.IO;
using BlamCore.Cache.HaloOnline;
using BlamCore.TagDefinitions;

namespace TagTool.Commands.Tags
{
    class ImportTagCommand : Command
    {
        private GameCacheContext CacheContext { get; }

        public ImportTagCommand(GameCacheContext cacheContext)
            : base(CommandFlags.None,

                  "ImportTag",
                  "",

                  "ImportTag <tag index> <path> <resources path>",

                  "Import a tag over an existing tag." +
                  "If the resources path is specified, all resources will be imported as new resources.")
        {
            CacheContext = cacheContext;
        }

        public override bool Execute(List<string> args)
        {
            if (args.Count < 2)
                return false;

            var tag = ArgumentParser.ParseTagSpecifier(CacheContext, args[0]);
            var filePath = args[1];

            if (tag == null)
                return false;

            byte[] data;

            using (var inStream = File.OpenRead(filePath))
            {
                data = new byte[inStream.Length];
                inStream.Read(data, 0, data.Length);
            }

            using (var stream = CacheContext.OpenTagCacheReadWrite())
                CacheContext.TagCache.SetTagDataRaw(stream, tag, data);

            Console.WriteLine($"Imported 0x{data.Length:X} bytes.");

            if (args.Count == 3)
            {
                string resourcesPath = args[2];

                if (tag.IsInGroup("jmad"))
                {
                    ModelAnimationGraphResources(tag, CacheContext, resourcesPath);
                }
                else if (tag.IsInGroup("mode"))
                {
                    RenderModelResources(tag, CacheContext, resourcesPath);
                }
                else if (tag.IsInGroup("snd!"))
                {
                    AudioResources(tag, CacheContext, resourcesPath);
                }
                else if (tag.IsInGroup("bitm"))
                {
                    TextureResources(tag, CacheContext, resourcesPath);
                }
                else
                    return false;
            }

            return true;
        }

        public void ModelAnimationGraphResources(CachedTagInstance instance, GameCacheContext cacheContext, string resourcesPath)
        {
            ModelAnimationGraph tag;

            using (var cacheStream = CacheContext.TagCacheFile.Open(FileMode.Open, FileAccess.ReadWrite))
            {
                var context = new TagSerializationContext(cacheStream, CacheContext, instance);
                tag = CacheContext.Deserializer.Deserialize<ModelAnimationGraph>(context);
            }

            uint compressedSize;

            var resourcesList = Directory.EnumerateFiles(resourcesPath);

            using (var stream = File.Open(CacheContext.TagCacheFile.DirectoryName + "\\" + "resources.dat", FileMode.Open, FileAccess.ReadWrite))
            {
                int i = 0;
                foreach (string resource in resourcesList)
                {
                    var data = File.ReadAllBytes(resource);
                    var cache = new ResourceCache(stream);
                    tag.ResourceGroups[i].Resource.Index = cache.Add(stream, data, out compressedSize);
                    tag.ResourceGroups[i].Resource.CompressedSize = compressedSize;
                    tag.ResourceGroups[i].Resource.OldLocationFlags = (OldResourceLocationFlags)2;

                    Console.WriteLine("Imported 0x{0:X} bytes.", data.Length);
                    Console.WriteLine("Compressed size = 0x{0:X}", compressedSize);
                    Console.WriteLine("New resource index: {0:X8}", tag.ResourceGroups[i].Resource.Index);
                    i++;
                }
            }
            
            using (var resourceStream = new MemoryStream())
            {
                using (var stream = CacheContext.TagCacheFile.Open(FileMode.Open, FileAccess.ReadWrite))
                {
                    var context = new TagSerializationContext(stream, CacheContext, instance);
                    CacheContext.Serializer.Serialize(context, tag);
                }
            }
        }

        public void RenderModelResources(CachedTagInstance instance, GameCacheContext cacheContext, string resourcesPath)
        {
            RenderModel tag;

            using (var cacheStream = CacheContext.TagCacheFile.Open(FileMode.Open, FileAccess.ReadWrite))
            {
                var context = new TagSerializationContext(cacheStream, CacheContext, instance);
                tag = CacheContext.Deserializer.Deserialize<RenderModel>(context);
            }

            uint compressedSize;

            var resourcesList = Directory.EnumerateFiles(resourcesPath);

            using (var stream = File.Open(CacheContext.TagCacheFile.DirectoryName + "\\" + "resources.dat", FileMode.Open, FileAccess.ReadWrite))
            { 
                foreach (string resource in resourcesList)
                {
                    var data = File.ReadAllBytes(resource);
                    var cache = new ResourceCache(stream);
                    tag.Geometry.Resource.Index = cache.Add(stream, data, out compressedSize);
                    tag.Geometry.Resource.CompressedSize = compressedSize;
                    tag.Geometry.Resource.OldLocationFlags = (OldResourceLocationFlags)2;

                    Console.WriteLine("Imported 0x{0:X} bytes.", data.Length);
                    Console.WriteLine("Compressed size = 0x{0:X}", compressedSize);
                    Console.WriteLine("New resource index: {0:X8}", tag.Geometry.Resource.Index);
                }
            }

            using (var resourceStream = new MemoryStream())
            {
                using (var stream = CacheContext.TagCacheFile.Open(FileMode.Open, FileAccess.ReadWrite))
                {
                    var context = new TagSerializationContext(stream, CacheContext, instance);
                    CacheContext.Serializer.Serialize(context, tag);
                }
            }
        }

        public void TextureResources(CachedTagInstance instance, GameCacheContext cacheContext, string resourcesPath)
        {
            Bitmap tag;

            using (var cacheStream = CacheContext.TagCacheFile.Open(FileMode.Open, FileAccess.ReadWrite))
            {
                var context = new TagSerializationContext(cacheStream, CacheContext, instance);
                tag = CacheContext.Deserializer.Deserialize<Bitmap>(context);
            }

            uint compressedSize;

            var resourcesList = Directory.EnumerateFiles(resourcesPath);

            using (var stream = File.Open(CacheContext.TagCacheFile.DirectoryName + "\\" + "resources.dat", FileMode.Open, FileAccess.ReadWrite))
            {
                int i = 0;
                foreach (string resource in resourcesList)
                {
                    var data = File.ReadAllBytes(resource);
                    var cache = new ResourceCache(stream);
                    tag.Resources[i].Resource.Index = cache.Add(stream, data, out compressedSize);
                    tag.Resources[i].Resource.CompressedSize = compressedSize;
                    tag.Resources[i].Resource.OldLocationFlags = (OldResourceLocationFlags)2;

                    Console.WriteLine("Imported 0x{0:X} bytes.", data.Length);
                    Console.WriteLine("Compressed size = 0x{0:X}", compressedSize);
                    Console.WriteLine("New resource index: {0:X8}", tag.Resources[i].Resource.Index);
                    i++;
                }
            }

            using (var resourceStream = new MemoryStream())
            {
                using (var stream = CacheContext.TagCacheFile.Open(FileMode.Open, FileAccess.ReadWrite))
                {
                    var context = new TagSerializationContext(stream, CacheContext, instance);
                    CacheContext.Serializer.Serialize(context, tag);
                }
            }
        }

        public void AudioResources(CachedTagInstance instance, GameCacheContext cacheContext, string resourcesPath)
        {
            Sound tag;

            using (var cacheStream = CacheContext.TagCacheFile.Open(FileMode.Open, FileAccess.ReadWrite))
            {
                var context = new TagSerializationContext(cacheStream, CacheContext, instance);
                tag = CacheContext.Deserializer.Deserialize<Sound>(context);
            }

            uint compressedSize;

            var resourcesList = Directory.EnumerateFiles(resourcesPath);

            using (var stream = File.Open(CacheContext.TagCacheFile.DirectoryName + "\\" + "resources.dat", FileMode.Open, FileAccess.ReadWrite))
            {
                int i = 0;
                foreach (string resource in resourcesList)
                {
                    var data = File.ReadAllBytes(resource);
                    var cache = new ResourceCache(stream);
                    tag.Resource.Index = cache.Add(stream, data, out compressedSize);
                    tag.Resource.CompressedSize = compressedSize;
                    tag.Resource.OldLocationFlags = (OldResourceLocationFlags)2;

                    Console.WriteLine("Imported 0x{0:X} bytes.", data.Length);
                    Console.WriteLine("Compressed size = 0x{0:X}", compressedSize);
                    Console.WriteLine("New resource index: {0:X8}", tag.Resource.Index);
                    i++;
                }
            }

            using (var resourceStream = new MemoryStream())
            {
                using (var stream = CacheContext.TagCacheFile.Open(FileMode.Open, FileAccess.ReadWrite))
                {
                    var context = new TagSerializationContext(stream, CacheContext, instance);
                    CacheContext.Serializer.Serialize(context, tag);
                }
            }
        }
    }
}

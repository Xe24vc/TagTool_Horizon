using System;
using System.Collections.Generic;
using System.IO;
using BlamCore.Cache.HaloOnline;
using BlamCore.TagDefinitions;

namespace TagTool.Commands.Tags
{
    class ExtractTagCommand : Command
    {
        private GameCacheContext CacheContext { get; }

        public ExtractTagCommand(GameCacheContext cacheContext)
            : base(CommandFlags.Inherit,

                  "ExtractTag",
                  "Extract tag and all its resources to a folder.",

                  "ExtractTag <tag index> <path> <resources path>",

                  "Extracts tag. If resources path is specified, all resources referenced will be extracted." +
                  "Example: ExtractTag 0x0CBD mp_masterchief.mode resources")
        {
            CacheContext = cacheContext;
        }

        public override bool Execute(List<string> args)
        {
            if (args.Count < 1)
                return false;

            var tag = ArgumentParser.ParseTagSpecifier(CacheContext, args[0]);

            if (tag == null)
                return false;

            string tagPath = args[1];

            byte[] data;

            using (var stream = CacheContext.OpenTagCacheRead())
                data = CacheContext.TagCache.ExtractTagRaw(stream, tag);

            using (var outStream = File.Open(tagPath, FileMode.Create, FileAccess.Write))
            {
                outStream.Write(data, 0, data.Length);
                Console.WriteLine("Wrote 0x{0:X} bytes to {1}.", outStream.Position, tagPath);
                Console.WriteLine("The tag's main struct will be at offset 0x{0:X}.", tag.MainStructOffset);
            }

            if (args.Count == 3)
            {
                string resourcesPath = args[2];

                if (!Directory.Exists(resourcesPath)) Directory.CreateDirectory(resourcesPath);

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

            using (var stream = File.OpenRead(CacheContext.TagCacheFile.DirectoryName + "\\" + "resources.dat"))
            {
                for (int i = 0; i < tag.ResourceGroups.Count; i++)
                {
                    int resourceIndex = tag.ResourceGroups[i].Resource.Index;
                    uint compressedSize = tag.ResourceGroups[i].Resource.CompressedSize;
                    var fileOutput = resourcesPath + "\\" + i + ".raw";

                    var cache = new ResourceCache(stream);
                    using (var outStream = File.Open(fileOutput, FileMode.Create, FileAccess.Write))
                    {
                        cache.Decompress(stream, (int)resourceIndex, compressedSize, outStream);
                        Console.WriteLine("Wrote 0x{0:X} bytes to {1}.", outStream.Position, fileOutput);
                    }
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
        
            using (var stream = File.OpenRead(CacheContext.TagCacheFile.DirectoryName + "\\" + "resources.dat"))
            {
                int resourceIndex = tag.Geometry.Resource.Index;
                uint compressedSize = tag.Geometry.Resource.CompressedSize;
                var fileOutput = resourcesPath + "\\" + 0 + ".raw";

                var cache = new ResourceCache(stream);
                using (var outStream = File.Open(fileOutput, FileMode.Create, FileAccess.Write))
                {
                    cache.Decompress(stream, (int)resourceIndex, compressedSize, outStream);
                    Console.WriteLine("Wrote 0x{0:X} bytes to {1}.", outStream.Position, fileOutput);
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
        
            using (var stream = File.OpenRead(CacheContext.TagCacheFile.DirectoryName + "\\" + "textures.dat"))
            {
                for (int i = 0; i < tag.Resources.Count; i++)
                {
                    int resourceIndex = tag.Resources[i].Resource.Index;
                    uint compressedSize = tag.Resources[i].Resource.CompressedSize;
                    var fileOutput = resourcesPath + "\\" + i + ".raw";

                    var cache = new ResourceCache(stream);
                    using (var outStream = File.Open(fileOutput, FileMode.Create, FileAccess.Write))
                    {
                        cache.Decompress(stream, resourceIndex, compressedSize, outStream); // (int)resourceIndex,
                        Console.WriteLine("Wrote 0x{0:X} bytes to {1}.", outStream.Position, fileOutput);
                    }
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
        
            using (var stream = File.OpenRead(CacheContext.TagCacheFile.DirectoryName + "\\" + "audio.dat"))
            {
        
                int resourceIndex = tag.Resource.Index;
                uint compressedSize = tag.Resource.CompressedSize;
                var fileOutput = resourcesPath + "\\" + 0 + ".raw";

                var cache = new ResourceCache(stream);
                using (var outStream = File.Open(fileOutput, FileMode.Create, FileAccess.Write))
                {
                    cache.Decompress(stream, (int)resourceIndex, compressedSize, outStream);
                    Console.WriteLine("Wrote 0x{0:X} bytes to {1}.", outStream.Position, fileOutput);
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using BlamCore.Cache.HaloOnline;
using BlamCore.TagDefinitions;
using BlamCore.Serialization;
using BlamCore.TagResources;
using System.Xml;
using System.Linq;
using BlamCore.Common;
using BlamCore.Geometry;
using BlamCore.IO;

namespace TagTool.Commands.Tags
{
    class ResourceDataCommand : Command
    {
        private GameCacheContext CacheContext { get; }
        private CachedTagInstance Tag { get; }

        public ResourceDataCommand(GameCacheContext cacheContext) : base(
            CommandFlags.None,

            "ResourceData",
            "Import and update a tag's resource as a new resource. Only for mode, jmad, bitm. WIP.",

            "ResourceData",

            "ResourceData extract/import resources.dat <tag index> <filename> [resourceIndex]")
        {
            CacheContext = cacheContext;
        }

        public override bool Execute(List<string> args)
        {
            if (args.Count < 4)
                return false;

            var command = args[0]; // extract/import
            var cachePath = args[1]; // resources.dat

            CachedTagInstance tag;
            if (args[2] == "*")
            {
                tag = CacheContext.TagCache.Index.Last();
            }
            else
            {
                tag = ArgumentParser.ParseTagSpecifier(CacheContext, args[2]); // tagIndex
            }

            var filePath = args[3]; // filename

            int groupIndex = 0; // resourceIndex
            if (args.Count == 5)
            {
                groupIndex = Convert.ToInt32(args[4]); // 0
            }

            if (tag.IsInGroup("jmad") & cachePath.Contains("resources.dat"))
            {
                JmadResource(command, cachePath, tag, filePath, groupIndex);
            }
            else if (tag.IsInGroup("mode") & cachePath.Contains("resources.dat"))
            {
                ModeResource(command, cachePath, tag, filePath, groupIndex);
            }
            else if (tag.IsInGroup("bitm") & (cachePath.Contains("textures.dat") || cachePath.Contains("textures_b.dat")))
            {
                BitmResource(command, cachePath, tag, filePath, groupIndex);
            }
            else if (tag.IsInGroup("sbsp") & cachePath.Contains("resources.dat"))
            {
                SbspResource(command, cachePath, tag, filePath, groupIndex);
            }
            else
            {
                throw new NotImplementedException();
            }
            return true;
        }
        public void JmadResource(string command, string cachePath, CachedTagInstance tag, string filePath, int groupIndex)
        {
            ModelAnimationGraph edJmad;

            // deserialize to get resource index
            using (var cacheStream = CacheContext.TagCacheFile.Open(FileMode.Open, FileAccess.ReadWrite))
            {
                var edContext = new TagSerializationContext(cacheStream, CacheContext, tag);
                edJmad = CacheContext.Deserializer.Deserialize<ModelAnimationGraph>(edContext);
            }

            // Get info.
            int resourceIndex = edJmad.ResourceGroups[groupIndex].Resource.Index;
            uint compressedSize = edJmad.ResourceGroups[groupIndex].Resource.CompressedSize;

            switch (command.ToLower())
            {
                #region extract
                case "extract":
                    try
                    {
                        // using (var stream = File.OpenRead(cachePath))
                        using (var stream = File.OpenRead(CacheContext.TagCacheFile.DirectoryName + "\\" + cachePath))
                        {
                            var cache = new ResourceCache(stream);
                            using (var outStream = File.Open(filePath, FileMode.Create, FileAccess.Write))
                            {
                                cache.Decompress(stream, (int)resourceIndex, compressedSize, outStream);
                                Console.WriteLine("Wrote 0x{0:X} bytes to {1}.", outStream.Position, filePath);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Failed to extract resource: {0}", ex.Message);
                    }
                    break;
                #endregion
                #region import
                case "import":
                    try
                    {
                        //using (var stream = File.Open(cachePath, FileMode.Open, FileAccess.ReadWrite))
                        var data = File.ReadAllBytes(filePath);
                        using (var stream = File.Open(CacheContext.TagCacheFile.DirectoryName + "\\" + cachePath, FileMode.Open, FileAccess.ReadWrite))
                        {
                            var cache = new ResourceCache(stream);
                            edJmad.ResourceGroups[groupIndex].Resource.Index = cache.Add(stream, data, out compressedSize);
                            edJmad.ResourceGroups[groupIndex].Resource.CompressedSize = compressedSize;
                            edJmad.ResourceGroups[groupIndex].Resource.OldLocationFlags = (OldResourceLocationFlags)2;

                            Console.WriteLine("Imported 0x{0:X} bytes.", data.Length);
                            Console.WriteLine("Compressed size = 0x{0:X}", compressedSize);
                            Console.WriteLine("New resource index: {0:X8}", edJmad.ResourceGroups[groupIndex].Resource.Index);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Failed to import resource: {0}", ex.Message);
                    }

                    // Serialize tag.
                    using (var resourceStream = new MemoryStream())
                    {
                        using (var stream = CacheContext.TagCacheFile.Open(FileMode.Open, FileAccess.ReadWrite))
                        {
                            var context = new TagSerializationContext(stream, CacheContext, tag);
                            CacheContext.Serializer.Serialize(context, edJmad);
                        }
                    }
                    break;
                    #endregion
            }
        }

        public void ModeResource(string command, string cachePath, CachedTagInstance tag, string filePath, int groupIndex)
        {
            RenderModel edMode  = new RenderModel();

            using (var cacheStream = CacheContext.TagCacheFile.Open(FileMode.Open, FileAccess.ReadWrite))
            {
                var edContext = new TagSerializationContext(cacheStream, CacheContext, tag);
                edMode = CacheContext.Deserializer.Deserialize<RenderModel>(edContext);
            }

            // Get info.
            int resourceIndex = edMode.Geometry.Resource.Index;
            uint compressedSize = edMode.Geometry.Resource.CompressedSize;

            switch (command.ToLower())
            {
                #region extract
                case "extract":
                    try
                    {
                        using (var stream = File.OpenRead(CacheContext.TagCacheFile.DirectoryName + "\\" + cachePath))
                        {
                            var cache = new ResourceCache(stream);
                            using (var outStream = File.Open(filePath, FileMode.Create, FileAccess.Write))
                            {
                                cache.Decompress(stream, (int)resourceIndex, compressedSize, outStream);
                                Console.WriteLine("Wrote 0x{0:X} bytes to {1}.", outStream.Position, filePath);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Failed to extract resource: {0}", ex.Message);
                    }
                    break;
                #endregion
                #region import
                case "import":
                    try
                    {
                        // using (var stream = File.Open(cachePath, FileMode.Open, FileAccess.ReadWrite))
                        using (var stream = File.Open(CacheContext.TagCacheFile.DirectoryName + "\\" + cachePath, FileMode.Open, FileAccess.ReadWrite))
                        {
                            var cache = new ResourceCache(stream);
                            var data = File.ReadAllBytes(filePath);

                            // new resource
                            edMode.Geometry.Resource.Index = cache.Add(stream, data, out compressedSize);
                            edMode.Geometry.Resource.CompressedSize = compressedSize;

                            // replace resource
                            // edMode.Geometry.Resource.CompressedSize = cache.Compress(stream, resourceIndex, data);

                            Console.WriteLine("Imported 0x{0:X} bytes.", data.Length);
                            Console.WriteLine("Compressed size = 0x{0:X}", compressedSize);
                            Console.WriteLine("New resource index: 0x{0:X8}", edMode.Geometry.Resource.Index);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Failed to import resource: {0}", ex.Message);
                    }

                    // Serialize tag.
                    using (var resourceStream = new MemoryStream())
                    {
                        using (var stream = CacheContext.TagCacheFile.Open(FileMode.Open, FileAccess.ReadWrite))
                        {
                            var context = new TagSerializationContext(stream, CacheContext, tag);
                            CacheContext.Serializer.Serialize(context, edMode);
                        }
                    }
                    break;
                    #endregion
            }
        }

        public void BitmResource(string command, string cachePath, CachedTagInstance tag, string filePath, int groupIndex)
        {
            Bitmap bitmap;

            // deserialize to get resource index
            using (var cacheStream = CacheContext.TagCacheFile.Open(FileMode.Open, FileAccess.ReadWrite))
            {
                var edContext = new TagSerializationContext(cacheStream, CacheContext, tag);
                bitmap = CacheContext.Deserializer.Deserialize<Bitmap>(edContext);
            }

            // Get info.
            int resourceIndex = bitmap.Resources[groupIndex].Resource.Index;
            uint compressedSize = bitmap.Resources[groupIndex].Resource.CompressedSize;

            switch (command.ToLower())
            {
                #region extract
                case "extract":
                    try
                    {
                        using (var stream = File.OpenRead(CacheContext.TagCacheFile.DirectoryName + "\\" + cachePath))
                        {
                            var cache = new ResourceCache(stream);
                            using (var outStream = File.Open(filePath, FileMode.Create, FileAccess.Write))
                            {
                                cache.Decompress(stream, (int)resourceIndex, compressedSize, outStream);
                                Console.WriteLine("Wrote 0x{0:X} bytes to {1}.", outStream.Position, filePath);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Failed to extract resource: {0}", ex.Message);
                    }
                    break;
                #endregion
                #region import
                case "import":
                    try
                    {
                        var data = File.ReadAllBytes(filePath);
                        using (var stream = File.Open(CacheContext.TagCacheFile.DirectoryName + "\\" + cachePath, FileMode.Open, FileAccess.ReadWrite))
                        {
                            var cache = new ResourceCache(stream);
                            bitmap.Resources[groupIndex].Resource.Index = cache.Add(stream, data, out compressedSize);
                            bitmap.Resources[groupIndex].Resource.CompressedSize = compressedSize;
                            bitmap.Resources[groupIndex].Resource.OldLocationFlags = (OldResourceLocationFlags)2;

                            Console.WriteLine("Imported 0x{0:X} bytes.", data.Length);
                            Console.WriteLine("Compressed size = 0x{0:X}", compressedSize);
                            Console.WriteLine("New resource index: {0:X8}", bitmap.Resources[groupIndex].Resource.Index);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Failed to import resource: {0}", ex.Message);
                    }

                    // Serialize tag.
                    using (var resourceStream = new MemoryStream())
                    {
                        using (var stream = CacheContext.TagCacheFile.Open(FileMode.Open, FileAccess.ReadWrite))
                        {
                            var context = new TagSerializationContext(stream, CacheContext, tag);
                            CacheContext.Serializer.Serialize(context, bitmap);
                        }
                    }
                    break;
                    #endregion
            }
        }

        public void SbspResource(string command, string cachePath, CachedTagInstance tag, string filePath, int groupIndex)
        {
            ScenarioStructureBsp Tag = new ScenarioStructureBsp();

            using (var cacheStream = CacheContext.TagCacheFile.Open(FileMode.Open, FileAccess.ReadWrite))
            {
                var edContext = new TagSerializationContext(cacheStream, CacheContext, tag);
                Tag = CacheContext.Deserializer.Deserialize<ScenarioStructureBsp>(edContext);
            }

            // Get info.
            var r1 = Tag.CollisionBspResource.Index;
            var r2 = Tag.Resource4.Index;
            var r3 = Tag.Geometry.Resource.Index;
            var r4 = Tag.Geometry2.Resource.Index;

            uint compressedSize = 0;

            switch (command.ToLower())
            {
                #region extract
                case "extract":
                    try
                    {
                        using (var stream = File.OpenRead(CacheContext.TagCacheFile.DirectoryName + "\\" + cachePath))
                        {
                            var cache = new ResourceCache(stream);

                            if (groupIndex == 0)
                            {
                                using (var outStream = File.Open(filePath, FileMode.Create, FileAccess.Write))
                                {
                                    cache.Decompress(stream, r1, compressedSize, outStream);
                                    Console.WriteLine("Wrote 0x{0:X} bytes to {1}.", outStream.Position, filePath);
                                }
                            }

                            else if (groupIndex == 1)
                            {
                                using (var outStream = File.Open(filePath, FileMode.Create, FileAccess.Write))
                                {
                                    cache.Decompress(stream, r2, compressedSize, outStream);
                                    Console.WriteLine("Wrote 0x{0:X} bytes to {1}.", outStream.Position, filePath);
                                }
                            }
                            else if (groupIndex == 2)
                            {
                                using (var outStream = File.Open(filePath + "_2", FileMode.Create, FileAccess.Write))
                                {
                                    cache.Decompress(stream, r3, compressedSize, outStream);
                                    Console.WriteLine("Wrote 0x{0:X} bytes to {1}.", outStream.Position, filePath);
                                }
                            }
                            else if (groupIndex == 3)
                            { 
                            using (var outStream = File.Open(filePath + "_3", FileMode.Create, FileAccess.Write))
                            {
                                cache.Decompress(stream, r4, compressedSize, outStream);
                                Console.WriteLine("Wrote 0x{0:X} bytes to {1}.", outStream.Position, filePath);
                            }
                        }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Failed to extract resource: {0}", ex.Message);
                    }
                    break;
                #endregion
                #region import
                case "import":
                    try
                    {
                        // using (var stream = File.Open(cachePath, FileMode.Open, FileAccess.ReadWrite))
                        using (var stream = File.Open(CacheContext.TagCacheFile.DirectoryName + "\\" + cachePath, FileMode.Open, FileAccess.ReadWrite))
                        {
                            var cache = new ResourceCache(stream);
                            var data = File.ReadAllBytes(filePath);

                            // new resource
                            if (groupIndex == 0)
                            {
                                Tag.CollisionBspResource.Index = cache.Add(stream, data, out compressedSize);
                                Tag.CollisionBspResource.CompressedSize = compressedSize;
                            }
                            else if (groupIndex == 1)
                            {
                                Tag.Resource4.Index = cache.Add(stream, data, out compressedSize);
                                Tag.Resource4.CompressedSize = compressedSize;
                            }
                            else if (groupIndex == 2)
                            {
                                Tag.Geometry.Resource.Index = cache.Add(stream, data, out compressedSize);
                                Tag.Geometry.Resource.CompressedSize = compressedSize;
                            }
                            else if (groupIndex == 3)
                            {
                                Tag.Geometry2.Resource.Index = cache.Add(stream, data, out compressedSize);
                                Tag.Geometry2.Resource.CompressedSize = compressedSize;
                            }

                            // replace resource
                            // edMode.Geometry.Resource.CompressedSize = cache.Compress(stream, resourceIndex, data);

                            Console.WriteLine("Imported 0x{0:X} bytes.", data.Length);
                            Console.WriteLine("Compressed size = 0x{0:X}", compressedSize);
                            Console.WriteLine("New resource index: 0x{0:X8}", Tag.Geometry.Resource.Index);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Failed to import resource: {0}", ex.Message);
                    }

                    // Serialize tag.
                    using (var resourceStream = new MemoryStream())
                    {
                        using (var stream = CacheContext.TagCacheFile.Open(FileMode.Open, FileAccess.ReadWrite))
                        {
                            var context = new TagSerializationContext(stream, CacheContext, tag);
                            CacheContext.Serializer.Serialize(context, Tag);
                        }
                    }
                    break;
                    #endregion
            }
        }

    }
}
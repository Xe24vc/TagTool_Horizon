using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using BlamCore.Common;

namespace BlamCore.Cache.HaloOnline
{
    /// <summary>
    /// Manages game cache file interop.
    /// </summary>
    public class GameCacheContext
    {
        /// <summary>
        /// Gets the directory of the current cache context.
        /// </summary>
        public DirectoryInfo Directory { get; }

        /// <summary>
        /// Gets the engine version of the cache files.
        /// </summary>
        public CacheVersion Version { get; }

        /// <summary>
        /// The tag serializer to use.
        /// </summary>
        public TagSerializer Serializer { get; set; }

        /// <summary>
        /// The tag deserializer to use.
        /// </summary>
        public TagDeserializer Deserializer { get; set; }

        public GameCacheContext(DirectoryInfo directory)
        {
            Directory = directory;

            using (var stream = OpenTagCacheRead())
                TagCache = new TagCache(stream);
            
            CacheVersion closestVersion;
            if (CacheVersion.Unknown == (Version = CacheVersionDetection.DetectFromTagCache(TagCache, out closestVersion)))
                Version = closestVersion;

            Deserializer = new TagDeserializer(Version == CacheVersion.Unknown ? closestVersion : Version);
            Serializer = new TagSerializer(Version == CacheVersion.Unknown ? closestVersion : Version);

            StringIdResolver stringIdResolver = null;

            if (CacheVersionDetection.Compare(Version, CacheVersion.HaloOnline700123) >= 0)
                stringIdResolver = new StringIdResolverMS30();
            else if (CacheVersionDetection.Compare(Version, CacheVersion.HaloOnline498295) >= 0)
                stringIdResolver = new StringIdResolverMS28();
            else
                stringIdResolver = new StringIdResolverMS23();

            using (var stream = OpenStringIdCacheRead())
                StringIdCache = new StringIdCache(stream, stringIdResolver);

            LoadTagNames();

            LoadResourcesCachesFromDirectory(Directory.FullName);
        }

        #region Tag Cache Functionality
        /// <summary>
        /// Gets the tag cache file information.
        /// </summary>
        public FileInfo TagCacheFile => Directory.GetFiles("tags.dat")?[0];

        /// <summary>
        /// A dictionary of tag names.
        /// </summary>
        public Dictionary<int, string> TagNames { get; set; } = new Dictionary<int, string>();

        /// <summary>
        /// The tag cache.
        /// </summary>
        public TagCache TagCache { get; set; }

        /// <summary>
        /// Opens the tag cache file for reading.
        /// </summary>
        /// <returns>The stream that was opened.</returns>
        public Stream OpenTagCacheRead() => TagCacheFile.OpenRead();

        /// <summary>
        /// Opens the tag cache file for writing.
        /// </summary>
        /// <returns>The stream that was opened.</returns>
        public FileStream OpenTagCacheWrite() => TagCacheFile.Open(FileMode.Open, FileAccess.Write);

        /// <summary>
        /// Opens the tag cache file for reading and writing.
        /// </summary>
        /// <returns>The stream that was opened.</returns>
        public FileStream OpenTagCacheReadWrite() => TagCacheFile.Open(FileMode.Open, FileAccess.ReadWrite);

        /// <summary>
        /// Gets a tag from the tag cache.
        /// </summary>
        /// <param name="index">The index of the tag.</param>
        /// <returns></returns>
        public CachedTagInstance GetTag(int index) => TagCache.Index[index];

        /// <summary>
        /// Loads tag file names from the appropriate tagnames.csv file.
        /// </summary>
        public void LoadTagNames()
        {
            var tagNamesPath = Path.Combine(Directory.FullName, "tag_list.csv");

            if (File.Exists(tagNamesPath))
            {
                using (var tagNamesStream = File.Open(tagNamesPath, FileMode.Open, FileAccess.Read))
                {
                    var reader = new StreamReader(tagNamesStream);

                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var separatorIndex = line.IndexOf(',');
                        var indexString = line.Substring(2, separatorIndex - 2);

                        int tagIndex;
                        if (!int.TryParse(indexString, NumberStyles.HexNumber, null, out tagIndex))
                            tagIndex = -1;

                        if (tagIndex < 0 || tagIndex >= TagCache.Index.Count)
                            continue;

                        var nameString = line.Substring(separatorIndex + 1);

                        if (nameString.Contains(" "))
                        {
                            var lastSpaceIndex = nameString.LastIndexOf(' ');
                            nameString = nameString.Substring(lastSpaceIndex + 1, nameString.Length - lastSpaceIndex - 1);
                        }

                        TagNames[tagIndex] = nameString;
                    }

                    reader.Close();
                }
            }

            foreach (var tag in TagCache.Index)
                if (tag != null && !TagNames.ContainsKey(tag.Index))
                    TagNames[tag.Index] = $"0x{tag.Index:X4}";
        }
        #endregion

        #region StringId Cache Functionality
        /// <summary>
        /// Gets the string_id cache file information.
        /// </summary>
        public FileInfo StringIdCacheFile => Directory.GetFiles("string_ids.dat")?[0];

        /// <summary>
        /// The stringID cache.
        /// Can be <c>null</c>.
        /// </summary>
        public StringIdCache StringIdCache { get; set; }

        /// <summary>
        /// Opens the string_id cache file for reading.
        /// </summary>
        /// <returns>The stream that was opened.</returns>
        public FileStream OpenStringIdCacheRead() => StringIdCacheFile.OpenRead();

        /// <summary>
        /// Opens the string_id cache file for writing.
        /// </summary>
        /// <returns>The stream that was opened.</returns>
        public FileStream OpenStringIdCacheWrite() => StringIdCacheFile.Open(FileMode.Open, FileAccess.Write);

        /// <summary>
        /// Opens the string_id cache file for reading and writing.
        /// </summary>
        /// <returns>The stream that was opened.</returns>
        public FileStream OpenStringIdCacheReadWrite() => StringIdCacheFile.Open(FileMode.Open, FileAccess.ReadWrite);

        /// <summary>
        /// Gets a string from the string_id cache.
        /// </summary>
        /// <param name="id">The id of the string.</param>
        /// <returns></returns>
        public string GetString(StringId id) => StringIdCache.GetString(id);

        /// <summary>
        /// Gets the string_id associated with the specified value from the string_id cache.
        /// </summary>
        /// <param name="value">The value to search for.</param>
        /// <returns></returns>
        public StringId GetStringId(string value) => StringIdCache.GetStringId(value);

        /// <summary>
        /// Gets the string_id associated with the specified index from the string_id cache.
        /// </summary>
        /// <param name="index">The index of the string.</param>
        /// <returns></returns>
        public StringId GetStringId(int index) => StringIdCache.GetStringId(index);
        #endregion

        #region Resource Cache Functionality
        /// <summary>
        /// The file names associated to each <see cref="ResourceLocation"/>.
        /// </summary>
        private Dictionary<ResourceLocation, string> ResourceCacheNames { get; } = new Dictionary<ResourceLocation, string>()
        {
            { ResourceLocation.Resources, "resources.dat" },
            { ResourceLocation.Textures, "textures.dat" },
            { ResourceLocation.TexturesB, "textures_b.dat" },
            { ResourceLocation.Audio, "audio.dat" },
            { ResourceLocation.Video, "video.dat" },
            { ResourceLocation.RenderModels, "render_models.dat" },
            { ResourceLocation.Lightmaps, "lightmaps.dat" },
        };

        /// <summary>
        /// The loaded <see cref="ResourceCache"/> for each <see cref="ResourceLocation"/>.
        /// </summary>
        private Dictionary<ResourceLocation, LoadedResourceCache> LoadedResourceCaches { get; } = new Dictionary<ResourceLocation, LoadedResourceCache>();

        /// <summary>
        /// Gets a resource cache file descriptor for the specified <see cref="ResourceLocation"/>.
        /// </summary>
        /// <param name="location">The location of the resource file.</param>
        /// <returns></returns>
        public ResourceCache GetResourceCache(ResourceLocation location) => LoadedResourceCaches[location].Cache;

        /// <summary>
        /// Opens a resource cache file for reading.
        /// </summary>
        /// <param name="location">The location of the resource file.</param>
        /// <returns></returns>
        public FileStream OpenResourceCacheRead(ResourceLocation location) => LoadedResourceCaches[location].File.OpenRead();

        /// <summary>
        /// Opens a resource cache file for writing.
        /// </summary>
        /// <param name="location">The location of the resource file.</param>
        /// <returns></returns>
        public FileStream OpenResourceCacheWrite(ResourceLocation location) => LoadedResourceCaches[location].File.OpenWrite();

        /// <summary>
        /// Opens a resource cache file for reading and writing.
        /// </summary>
        /// <param name="location">The location of the resource file.</param>
        /// <returns></returns>
        public FileStream OpenResourceCacheReadWrite(ResourceLocation location) => LoadedResourceCaches[location].File.Open(FileMode.Open, FileAccess.ReadWrite);

        /// <summary>
        /// Loads a resource cache from a file.
        /// </summary>
        /// <param name="location">The resource cache type.</param>
        /// <param name="path">The path to the .dat file to read.</param>
        /// <exception cref="System.InvalidOperationException">Thrown if the cache is already loaded.</exception>
        public void LoadResourceCache(ResourceLocation location, string path)
        {
            if (LoadedResourceCaches.ContainsKey(location))
                throw new InvalidOperationException("A resource cache for the " + location + " location has already been loaded.");

            var file = new FileInfo(path);
            using (var stream = file.OpenRead())
            {
                LoadedResourceCaches[location] = new LoadedResourceCache
                {
                    Cache = new ResourceCache(stream),
                    File = file
                };
            }
        }

        /// <summary>
        /// Loads a resource cache from a directory using its default name.
        /// </summary>
        /// <param name="directory">The directory to find the cache in.</param>
        /// <param name="cache">The type of cache to load.</param>
        public void LoadResourceCacheFromDirectory(string directory, ResourceLocation cache)
        {
            var path = Path.Combine(directory, ResourceCacheNames[cache]);
            LoadResourceCache(cache, path);
        }

        /// <summary>
        /// Loads resource caches from a directory using their default filenames.
        /// </summary>
        /// <param name="directory">The directory to find files in.</param>
        public void LoadResourcesCachesFromDirectory(string directory)
        {
            foreach (var cache in ResourceCacheNames)
            {
                var path = Path.Combine(directory, cache.Value);
                if (File.Exists(path))
                    LoadResourceCache(cache.Key, path);
            }
        }

        /// <summary>
        /// Adds a new resource to a cache.
        /// </summary>
        /// <param name="resource">The resource reference to initialize.</param>
        /// <param name="location">The location where the resource should be stored.</param>
        /// <param name="dataStream">The stream to read the resource data from.</param>
        /// <exception cref="System.ArgumentNullException">resource</exception>
        /// <exception cref="System.ArgumentException">The input stream is not open for reading;dataStream</exception>
        public void AddResource(ResourceReference resource, ResourceLocation location, Stream dataStream)
        {
            if (resource == null)
                throw new ArgumentNullException("resource");
            if (!dataStream.CanRead)
                throw new ArgumentException("The input stream is not open for reading", "dataStream");

            resource.ChangeLocation(location);
            var cache = GetResourceCache(resource);
            using (var stream = cache.File.Open(FileMode.Open, FileAccess.ReadWrite))
            {
                var dataSize = (int)(dataStream.Length - dataStream.Position);
                var data = new byte[dataSize];
                dataStream.Read(data, 0, dataSize);
                uint compressedSize;
                resource.Index = cache.Cache.Add(stream, data, out compressedSize);
                resource.CompressedSize = compressedSize;
                resource.DecompressedSize = (uint)dataSize;
                resource.DisableChecksum();
            }
        }

        /// <summary>
        /// Adds raw, pre-compressed resource data to a cache.
        /// </summary>
        /// <param name="resource">The resource reference to initialize.</param>
        /// <param name="location">The location where the resource should be stored.</param>
        /// <param name="data">The pre-compressed data to store.</param>
        public void AddRawResource(ResourceReference resource, ResourceLocation location, byte[] data)
        {
            if (resource == null)
                throw new ArgumentNullException("resource");

            resource.ChangeLocation(location);
            resource.DisableChecksum();
            var cache = GetResourceCache(resource);
            using (var stream = cache.File.Open(FileMode.Open, FileAccess.ReadWrite))
                resource.Index = cache.Cache.AddRaw(stream, data);
        }

        /// <summary>
        /// Extracts and decompresses the data for a resource.
        /// </summary>
        /// <param name="resource">The resource.</param>
        /// <param name="outStream">The stream to write the extracted data to.</param>
        /// <exception cref="System.ArgumentException">Thrown if the output stream is not open for writing.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown if the file containing the resource has not been loaded.</exception>
        public void ExtractResource(ResourceReference resource, Stream outStream)
        {
            if (resource == null)
                throw new ArgumentNullException("resource");
            if (!outStream.CanWrite)
                throw new ArgumentException("The output stream is not open for writing", "outStream");

            var cache = GetResourceCache(resource);
            using (var stream = cache.File.OpenRead())
                cache.Cache.Decompress(stream, resource.Index, resource.CompressedSize, outStream);
        }

        /// <summary>
        /// Extracts raw, compressed resource data.
        /// </summary>
        /// <param name="resource">The resource.</param>
        /// <returns>The raw, compressed resource data.</returns>
        public byte[] ExtractRawResource(ResourceReference resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource");

            var cache = GetResourceCache(resource);
            using (var stream = cache.File.OpenRead())
                return cache.Cache.ExtractRaw(stream, resource.Index, resource.CompressedSize);
        }

        /// <summary>
        /// Compresses and replaces the data for a resource.
        /// </summary>
        /// <param name="resource">The resource whose data should be replaced. On success, the reference will be adjusted to account for the new data.</param>
        /// <param name="dataStream">The stream to read the new data from.</param>
        /// <exception cref="System.ArgumentException">Thrown if the input stream is not open for reading.</exception>
        public void ReplaceResource(ResourceReference resource, Stream dataStream)
        {
            if (resource == null)
                throw new ArgumentNullException("resource");
            if (!dataStream.CanRead)
                throw new ArgumentException("The input stream is not open for reading", "dataStream");

            var cache = GetResourceCache(resource);
            using (var stream = cache.File.Open(FileMode.Open, FileAccess.ReadWrite))
            {
                var dataSize = (int)(dataStream.Length - dataStream.Position);
                var data = new byte[dataSize];
                dataStream.Read(data, 0, dataSize);
                var compressedSize = cache.Cache.Compress(stream, resource.Index, data);
                resource.CompressedSize = compressedSize;
                resource.DecompressedSize = (uint)dataSize;
                resource.DisableChecksum();
            }
        }

        /// <summary>
        /// Replaces a resource with raw, pre-compressed data.
        /// </summary>
        /// <param name="resource">The resource whose data should be replaced. On success, the reference will be adjusted to account for the new data.</param>
        /// <param name="data">The raw, pre-compressed data to use.</param>
        public void ReplaceRawResource(ResourceReference resource, byte[] data)
        {
            if (resource == null)
                throw new ArgumentNullException("resource");

            resource.DisableChecksum();
            var cache = GetResourceCache(resource);
            using (var stream = cache.File.Open(FileMode.Open, FileAccess.ReadWrite))
                cache.Cache.ImportRaw(stream, resource.Index, data);
        }

        private LoadedResourceCache GetResourceCache(ResourceReference resource)
        {
            LoadedResourceCache cache;
            if (!LoadedResourceCaches.TryGetValue(resource.GetLocation(), out cache))
                throw new InvalidOperationException("The requested resource is located in " + resource.GetLocation() + ", but the corresponding cache file has not been loaded.");
            return cache;
        }

        private class LoadedResourceCache
        {
            public ResourceCache Cache { get; set; }

            public FileInfo File { get; set; }
        }
        #endregion
    }
}
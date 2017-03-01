﻿using System;
using System.Collections.Generic;
using BlamCore.Serialization;
using BlamCore.TagDefinitions;
using BlamCore.Cache.HaloOnline;
using System.Globalization;
using BlamCore.Common;

namespace TagTool.Commands.Tags
{
    class CreateTagCommand : Command
    {
        public GameCacheContext CacheContext { get; }

        public CreateTagCommand(GameCacheContext cacheContext)
            : base(CommandFlags.Inherit,

                  "CreateTag",
                  "Creates a new tag of the specified tag group in the current tag cache.",

                  "CreateTag <group tag> [index = *]",

                  "Creates a new tag of the specified tag group in the current tag cache.")
        {
            CacheContext = cacheContext;
        }

        public override bool Execute(List<string> args)
        {
            if (args.Count < 1 || args.Count > 2)
                return false;

        begin:
            var groupTag = ArgumentParser.ParseGroupTag(CacheContext.StringIdCache, args[0]);

            if (groupTag == null || !TagGroup.Instances.ContainsKey(groupTag))
            {
                Console.WriteLine($"ERROR: No tag group definition for group tag '{groupTag}'!");
                Console.Write($"(BE CAREFUL WITH THIS!!!) Define '{groupTag}' tag group? [y/n]: ");

                var answer = Console.ReadLine().ToLower();

                if (answer != "y" && answer != "yes")
                    return false;

                Console.WriteLine("Enter the tag group specification in the following format");
                Console.WriteLine("<group tag> [parent group tag] [grandparent group tag] <group name>:");
                Console.WriteLine();
                Console.Write($"{groupTag} specification> ");

                answer = Console.ReadLine();

                string redirect;
                var groupArgs = ArgumentParser.ParseCommand(answer, out redirect);

                switch (groupArgs.Count)
                {
                    case 2: new TagGroup(new Tag(groupArgs[0]), Tag.Null, Tag.Null, CacheContext.GetStringId(groupArgs[1])); break;
                    case 3: new TagGroup(new Tag(groupArgs[0]), new Tag(groupArgs[1]), Tag.Null, CacheContext.GetStringId(groupArgs[2])); break;
                    case 4: new TagGroup(new Tag(groupArgs[0]), new Tag(groupArgs[1]), new Tag(groupArgs[2]), CacheContext.GetStringId(groupArgs[3])); break;
                    default: return false;
                }

                goto begin;
            }

            CachedTagInstance instance = null;

            using (var stream = CacheContext.OpenTagCacheReadWrite())
            {
                if (args.Count == 2)
                {
                    int tagIndex;
                    if (!int.TryParse(args[1].Replace("0x", ""), NumberStyles.HexNumber, null, out tagIndex))
                        return false;

                    if (tagIndex > CacheContext.TagCache.Index.Count)
                        return false;

                    if (tagIndex < CacheContext.TagCache.Index.Count)
                    {
                        if (CacheContext.TagCache.Index[tagIndex] != null)
                        {
                            var oldInstance = CacheContext.TagCache.Index[tagIndex];
                            CacheContext.TagCache.Index[tagIndex] = null;
                            CacheContext.TagCache.SetTagDataRaw(stream, oldInstance, new byte[] { });
                        }

                        instance = new CachedTagInstance(tagIndex, TagGroup.Instances[groupTag]);
                        CacheContext.TagCache.Index[tagIndex] = instance;
                    }
                }

                if (instance == null)
                    instance = CacheContext.TagCache.AllocateTag(TagGroup.Instances[groupTag]);

                var context = new TagSerializationContext(stream, CacheContext, instance);
                var data = Activator.CreateInstance(TagStructureTypes.FindByGroupTag(groupTag));
                CacheContext.Serializer.Serialize(context, data);
            }

            var tagName = CacheContext.TagNames.ContainsKey(instance.Index) ?
                CacheContext.TagNames[instance.Index] :
                $"0x{instance.Index:X4}";

            Console.WriteLine($"[Index: 0x{instance.Index:X4}, Offset: 0x{instance.HeaderOffset:X8}, Size: 0x{instance.TotalSize:X4}] {tagName}.{CacheContext.GetString(instance.Group.Name)}");

            return true;
        }
    }
}

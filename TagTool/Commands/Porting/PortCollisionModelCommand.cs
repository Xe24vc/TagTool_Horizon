using System;
using System.Collections.Generic;
using System.IO;
using BlamCore.Cache.HaloOnline;
using BlamCore.Serialization;
using BlamCore.TagDefinitions;
using BlamCore.Cache.Base;

namespace TagTool.Commands.Porting
{
    class PortCollisionModelCommand : Command
    {
        public GameCacheContext CacheContext { get; }
        public CacheFile BlamCache { get; }

        public PortCollisionModelCommand(GameCacheContext cacheContext, CacheFile blamCache)
            : base(CommandFlags.Inherit,

                  "PortCollisionModel",
                  "",

                  "PortCollisionModel [New] <Blam Tag> <ElDorado Tag>",
                  "")
        {
            CacheContext = cacheContext;
            BlamCache = blamCache;
        }

        public override bool Execute(List<string> args)
        {
            if (args.Count < 2 || args.Count > 3)
                return false;

            bool isNew = false;
            if (args.Count == 3)
            {
                if (args[0].ToLower() != "new")
                    return false;
                isNew = true;
                args.RemoveAt(0);
            }

            var initialStringIDCount = CacheContext.StringIdCache.Strings.Count;

            //
            // Verify the Blam collision_model tag
            //

            var blamTagName = args[0];

            CacheFile.IndexItem blamTag = null;

            Console.WriteLine("Verifying Blam collision_model tag...");

            foreach (var tag in BlamCache.IndexItems)
            {
                if (tag.ClassCode == "coll" && tag.Filename == blamTagName)
                {
                    blamTag = tag;
                    break;
                }
            }

            if (blamTag == null)
            {
                Console.WriteLine("Blam tag does not exist: " + args[0]);
                return false;
            }

            //
            // Verify the ED collision_model tag
            //

            Console.WriteLine("Verifying ElDorado collision_model tag index...");

            var edTag = ArgumentParser.ParseTagSpecifier(CacheContext, args[1]);

            if (edTag.Group.Name != CacheContext.GetStringId("collision_model"))
            {
                Console.WriteLine("Specified tag index is not a collision_model: " + args[1]);
                return false;
            }

            //
            // Load the Blam collision_model tag
            //

            var blamDeserializer = new TagDeserializer(BlamCache.Version);
            var blamContext = new CacheSerializationContext(CacheContext, BlamCache, blamTag);
            var blamColl = blamDeserializer.Deserialize<CollisionModel>(blamContext);

            //
            // Update the Blam collision_model tag definition
            //

            foreach (var material in blamColl.Materials)
            {
                var materialName = BlamCache.Strings.GetItemByID((int)material.Name.Value);
                if (materialName == "<blank>") materialName = "";
                material.Name = CacheContext.StringIdCache.Contains(materialName) ?
                    CacheContext.StringIdCache.GetStringId(materialName) :
                    CacheContext.StringIdCache.AddString(materialName);
            }

            foreach (var region in blamColl.Regions)
            {
                var regionName = BlamCache.Strings.GetItemByID((int)region.Name.Value);
                if (regionName == "<blank>") regionName = "";
                region.Name = CacheContext.StringIdCache.Contains(regionName) ?
                    CacheContext.StringIdCache.GetStringId(regionName) :
                    CacheContext.StringIdCache.AddString(regionName);

                foreach (var permutation in region.Permutations)
                {
                    var permutationName = BlamCache.Strings.GetItemByID((int)permutation.Name.Value);
                    if (permutationName == "<blank>") permutationName = "";
                    permutation.Name = CacheContext.StringIdCache.Contains(permutationName) ?
                        CacheContext.StringIdCache.GetStringId(permutationName) :
                        CacheContext.StringIdCache.AddString(permutationName);

                    foreach (var bsp in permutation.Bsps)
                    {
                        foreach (var bsp3dNode in bsp.Geometry.Bsp3dNodes)
                        {
                            bsp3dNode.Plane = bsp3dNode.Plane_H3;
                            bsp3dNode.FrontChildLower = bsp3dNode.FrontChildLower_H3;
                            bsp3dNode.FrontChildMid = bsp3dNode.FrontChildMid_H3;
                            bsp3dNode.FrontChildUpper = bsp3dNode.FrontChildUpper_H3;
                            bsp3dNode.BackChildLower = bsp3dNode.BackChildLower_H3;
                            bsp3dNode.BackChildMid = bsp3dNode.BackChildMid_H3;
                            bsp3dNode.BackChildUpper = bsp3dNode.BackChildUpper_H3;
                        }
                    }
                }
            }

            foreach (var node in blamColl.Nodes)
            {
                var nodeName = BlamCache.Strings.GetItemByID((int)node.Name.Value);
                if (nodeName == "<blank>") nodeName = "";
                node.Name = CacheContext.StringIdCache.Contains(nodeName) ?
                    CacheContext.StringIdCache.GetStringId(nodeName) :
                    CacheContext.StringIdCache.AddString(nodeName);
            }

            //
            // Serialize the collision_model tag definition
            //

            using (var stream = CacheContext.OpenTagCacheReadWrite())
            {
                var tag = isNew ? CacheContext.TagCache.AllocateTag(edTag.Group) : edTag;

                var tagContext = new TagSerializationContext(stream, CacheContext, tag);
                CacheContext.Serializer.Serialize(tagContext, blamColl);
            }

            //
            // Save new string_ids
            //

            if (CacheContext.StringIdCache.Strings.Count != initialStringIDCount)
            {
                Console.Write("Saving string_ids...");

                using (var stringIdStream = CacheContext.StringIdCacheFile.Open(FileMode.Open, FileAccess.ReadWrite))
                    CacheContext.StringIdCache.Save(stringIdStream);

                Console.WriteLine("done.");
            }

            //
            // Done!
            //

            Console.WriteLine("Ported collision_model \"" + blamTagName + "\" successfully!");

            return true;
        }
    }
}

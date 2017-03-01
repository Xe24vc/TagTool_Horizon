using System;
using System.Collections.Generic;
using System.IO;
using BlamCore.Cache.HaloOnline;
using BlamCore.Serialization;
using BlamCore.TagDefinitions;
using BlamCore.Cache.Base;

namespace TagTool.Commands.Porting
{
    class PortPhysicsModelCommand : Command
    {
        public GameCacheContext CacheContext { get; }
        public CacheFile BlamCache { get; }

        public PortPhysicsModelCommand(GameCacheContext cacheContext, CacheFile blamCache)
            : base(CommandFlags.Inherit,

                  "PortPhysicsModel",
                  "",

                  "PortPhysicsModel [New] <Blam Tag> <ElDorado Tag>",
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
            // Verify the Blam physics_model tag
            //

            var blamTagName = args[0];

            CacheFile.IndexItem blamTag = null;

            Console.WriteLine("Verifying Blam physics_model tag...");

            foreach (var tag in BlamCache.IndexItems)
            {
                if (tag.ClassCode == "phmo" && tag.Filename == blamTagName)
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
            // Verify the ED physics_model tag
            //

            Console.WriteLine("Verifying ElDorado physics_model tag index...");

            var edTag = ArgumentParser.ParseTagSpecifier(CacheContext, args[1]);

            if (edTag.Group.Name != CacheContext.GetStringId("physics_model"))
            {
                Console.WriteLine("Specified tag index is not a physics_model: " + args[1]);
                return false;
            }

            //
            // Load the Blam physics_model tag
            //

            var blamDeserializer = new TagDeserializer(BlamCache.Version);
            var blamContext = new CacheSerializationContext(CacheContext, BlamCache, blamTag);
            var blamPhmo = blamDeserializer.Deserialize<PhysicsModel>(blamContext);

            //
            // Update the Blam physics_model tag definition
            //

            foreach (var motor in blamPhmo.DampedSpringMotors)
            {
                var motorName = BlamCache.Strings.GetItemByID((int)motor.Name.Value);
                if (motorName == "<blank>") motorName = "";
                motor.Name = CacheContext.StringIdCache.Contains(motorName) ?
                    CacheContext.StringIdCache.GetStringId(motorName) :
                    CacheContext.StringIdCache.AddString(motorName);
            }

            foreach (var motor in blamPhmo.PositionMotors)
            {
                var motorName = BlamCache.Strings.GetItemByID((int)motor.Name.Value);
                if (motorName == "<blank>") motorName = "";
                motor.Name = CacheContext.StringIdCache.Contains(motorName) ?
                    CacheContext.StringIdCache.GetStringId(motorName) :
                    CacheContext.StringIdCache.AddString(motorName);
            }

            foreach (var type in blamPhmo.PhantomTypes)
            {
                var typeMarkerName = BlamCache.Strings.GetItemByID((int)type.MarkerName.Value);
                if (typeMarkerName == "<blank>") typeMarkerName = "";
                type.MarkerName = CacheContext.StringIdCache.Contains(typeMarkerName) ?
                    CacheContext.StringIdCache.GetStringId(typeMarkerName) :
                    CacheContext.StringIdCache.AddString(typeMarkerName);

                var typeAlignmentMarkerName = BlamCache.Strings.GetItemByID((int)type.AlignmentMarkerName.Value);
                if (typeAlignmentMarkerName == "<blank>") typeAlignmentMarkerName = "";
                type.AlignmentMarkerName = CacheContext.StringIdCache.Contains(typeAlignmentMarkerName) ?
                    CacheContext.StringIdCache.GetStringId(typeAlignmentMarkerName) :
                    CacheContext.StringIdCache.AddString(typeAlignmentMarkerName);
            }

            foreach (var edge in blamPhmo.NodeEdges)
            {
                var nodeAMaterialName = BlamCache.Strings.GetItemByID((int)edge.NodeAMaterial.Value);
                if (nodeAMaterialName == "<blank>") nodeAMaterialName = "";
                edge.NodeAMaterial = CacheContext.StringIdCache.Contains(nodeAMaterialName) ?
                    CacheContext.StringIdCache.GetStringId(nodeAMaterialName) :
                    CacheContext.StringIdCache.AddString(nodeAMaterialName);

                var nodeBMaterialName = BlamCache.Strings.GetItemByID((int)edge.NodeBMaterial.Value);
                if (nodeBMaterialName == "<blank>") nodeBMaterialName = "";
                edge.NodeBMaterial = CacheContext.StringIdCache.Contains(nodeBMaterialName) ?
                    CacheContext.StringIdCache.GetStringId(nodeBMaterialName) :
                    CacheContext.StringIdCache.AddString(nodeBMaterialName);
            }

            foreach (var material in blamPhmo.Materials)
            {
                var name = BlamCache.Strings.GetItemByID((int)material.Name.Value);
                if (name == "<blank>") name = "";
                material.Name = CacheContext.StringIdCache.Contains(name) ?
                    CacheContext.StringIdCache.GetStringId(name) :
                    CacheContext.StringIdCache.AddString(name);

                var materialName = BlamCache.Strings.GetItemByID((int)material.MaterialName.Value);
                if (materialName == "<blank>") materialName = "";
                material.MaterialName = CacheContext.StringIdCache.Contains(materialName) ?
                    CacheContext.StringIdCache.GetStringId(materialName) :
                    CacheContext.StringIdCache.AddString(materialName);
            }

            foreach (var sphere in blamPhmo.Spheres)
            {
                var name = BlamCache.Strings.GetItemByID((int)sphere.Name.Value);
                if (name == "<blank>") name = "";
                sphere.Name = CacheContext.StringIdCache.Contains(name) ?
                    CacheContext.StringIdCache.GetStringId(name) :
                    CacheContext.StringIdCache.AddString(name);
            }

            foreach (var pill in blamPhmo.Pills)
            {
                var name = BlamCache.Strings.GetItemByID((int)pill.Name.Value);
                if (name == "<blank>") name = "";
                pill.Name = CacheContext.StringIdCache.Contains(name) ?
                    CacheContext.StringIdCache.GetStringId(name) :
                    CacheContext.StringIdCache.AddString(name);
            }

            foreach (var box in blamPhmo.Boxes)
            {
                var name = BlamCache.Strings.GetItemByID((int)box.Name.Value);
                if (name == "<blank>") name = "";
                box.Name = CacheContext.StringIdCache.Contains(name) ?
                    CacheContext.StringIdCache.GetStringId(name) :
                    CacheContext.StringIdCache.AddString(name);
            }

            foreach (var triangle in blamPhmo.Triangles)
            {
                var name = BlamCache.Strings.GetItemByID((int)triangle.Name.Value);
                if (name == "<blank>") name = "";
                triangle.Name = CacheContext.StringIdCache.Contains(name) ?
                    CacheContext.StringIdCache.GetStringId(name) :
                    CacheContext.StringIdCache.AddString(name);
            }

            foreach (var polyhedron in blamPhmo.Polyhedra)
            {
                var name = BlamCache.Strings.GetItemByID((int)polyhedron.Name.Value);
                if (name == "<blank>") name = "";
                polyhedron.Name = CacheContext.StringIdCache.Contains(name) ?
                    CacheContext.StringIdCache.GetStringId(name) :
                    CacheContext.StringIdCache.AddString(name);
            }

            foreach (var constraint in blamPhmo.HingeConstraints)
            {
                var name = BlamCache.Strings.GetItemByID((int)constraint.Name.Value);
                if (name == "<blank>") name = "";
                constraint.Name = CacheContext.StringIdCache.Contains(name) ?
                    CacheContext.StringIdCache.GetStringId(name) :
                    CacheContext.StringIdCache.AddString(name);
            }

            foreach (var constraint in blamPhmo.RagdollConstraints)
            {
                var name = BlamCache.Strings.GetItemByID((int)constraint.Name.Value);
                if (name == "<blank>") name = "";
                constraint.Name = CacheContext.StringIdCache.Contains(name) ?
                    CacheContext.StringIdCache.GetStringId(name) :
                    CacheContext.StringIdCache.AddString(name);
            }

            foreach (var region in blamPhmo.Regions)
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
                }
            }

            foreach (var node in blamPhmo.Nodes)
            {
                var nodeName = BlamCache.Strings.GetItemByID((int)node.Name.Value);
                if (nodeName == "<blank>") nodeName = "";
                node.Name = CacheContext.StringIdCache.Contains(nodeName) ?
                    CacheContext.StringIdCache.GetStringId(nodeName) :
                    CacheContext.StringIdCache.AddString(nodeName);
            }

            foreach (var constraint in blamPhmo.LimitedHingeConstraints)
            {
                var name = BlamCache.Strings.GetItemByID((int)constraint.Name.Value);
                if (name == "<blank>") name = "";
                constraint.Name = CacheContext.StringIdCache.Contains(name) ?
                    CacheContext.StringIdCache.GetStringId(name) :
                    CacheContext.StringIdCache.AddString(name);
            }

            //
            // Serialize the physics_model tag definition
            //

            using (var stream = CacheContext.OpenTagCacheReadWrite())
            {
                var tag = isNew ? CacheContext.TagCache.AllocateTag(edTag.Group) : edTag;

                var tagContext = new TagSerializationContext(stream, CacheContext, tag);
                CacheContext.Serializer.Serialize(tagContext, blamPhmo);
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

            Console.WriteLine("Ported physics_model \"" + blamTagName + "\" successfully!");

            return true;
        }
    }
}

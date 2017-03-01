using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BlamCore.Cache;
using BlamCore.Cache.Base;
using BlamCore.Cache.HaloOnline;
using BlamCore.Common;
using BlamCore.Geometry;
using BlamCore.Serialization;
using BlamCore.TagDefinitions;

namespace TagTool.Commands.Porting
{
    class PortModelCommand : Command
    {
        public GameCacheContext CacheContext { get; }
        public CacheFile BlamCache { get; }

        public PortModelCommand(GameCacheContext cacheContext, CacheFile blamCache)
            : base(CommandFlags.None,

                  "PortModel",
                  "Ports a blam model tag to the current cache.",

                  "PortModel <Blam Tag> <ElDorado Tag>",

                  "Ports a blam model tag to the current cache.")
        {
            CacheContext = cacheContext;
            BlamCache = blamCache;
        }

        public override bool Execute(List<string> args)
        {
            if (args.Count != 2)
                return false;

            var initialStringIDCount = CacheContext.StringIdCache.Strings.Count;

            var blamTagName = args[0];

            CacheFile.IndexItem blamTag = null;

            foreach (var tag in BlamCache.IndexItems)
            {
                if (tag.ClassCode == "hlmt" && tag.Filename == blamTagName)
                {
                    blamTag = tag;
                    break;
                }
            }

            if (blamTag == null)
            {
                Console.WriteLine("Blam model tag does not exist: " + args[0]);
                return false;
            }

            var blamDeserializer = new TagDeserializer(BlamCache.Version);
            var blamContext = new CacheSerializationContext(CacheContext, BlamCache, blamTag);
            var blamHlmt = blamDeserializer.Deserialize<Model>(blamContext);

            var newHlmtTag = ArgumentParser.ParseTagSpecifier(CacheContext, args[1]);

            if (newHlmtTag.Group.Name != CacheContext.GetStringId("model"))
            {
                Console.WriteLine("Specified tag index is not a model: " + args[1]);
                return false;
            }

            blamHlmt.RenderModel = null;
            blamHlmt.CollisionModel = null;
            blamHlmt.Animation = null;
            blamHlmt.PhysicsModel = null;
            blamHlmt.LodModel = null;

            foreach (var variant in blamHlmt.Variants)
            {
                var variantName = BlamCache.Strings.GetItemByID((int)variant.Name.Value);
                if (variantName == "<blank>") variantName = "";
                variant.Name = CacheContext.StringIdCache.Contains(variantName) ?
                    CacheContext.StringIdCache.GetStringId(variantName) :
                    CacheContext.StringIdCache.AddString(variantName);

                foreach (var region in variant.Regions)
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

                        foreach (var state in permutation.States)
                        {
                            var stateName = BlamCache.Strings.GetItemByID((int)state.Name.Value);
                            if (stateName == "<blank>") stateName = "";
                            state.Name = CacheContext.StringIdCache.Contains(stateName) ?
                                CacheContext.StringIdCache.GetStringId(stateName) :
                                CacheContext.StringIdCache.AddString(stateName);

                            state.LoopingEffect = null;

                            var stateLoopingEffectMarkerName = BlamCache.Strings.GetItemByID((int)state.LoopingEffectMarkerName.Value);
                            if (stateLoopingEffectMarkerName == "<blank>") stateLoopingEffectMarkerName = "";
                            state.LoopingEffectMarkerName = CacheContext.StringIdCache.Contains(stateLoopingEffectMarkerName) ?
                                CacheContext.StringIdCache.GetStringId(stateLoopingEffectMarkerName) :
                                CacheContext.StringIdCache.AddString(stateLoopingEffectMarkerName);
                        }
                    }
                }

                foreach (var obj in variant.Objects)
                {
                    var objParentMarker = BlamCache.Strings.GetItemByID((int)obj.ParentMarker.Value);
                    if (objParentMarker == "<blank>") objParentMarker = "";
                    obj.ParentMarker = CacheContext.StringIdCache.Contains(objParentMarker) ?
                        CacheContext.StringIdCache.GetStringId(objParentMarker) :
                        CacheContext.StringIdCache.AddString(objParentMarker);

                    var objChildMarker = BlamCache.Strings.GetItemByID((int)obj.ChildMarker.Value);
                    if (objChildMarker == "<blank>") objChildMarker = "";
                    obj.ChildMarker = CacheContext.StringIdCache.Contains(objChildMarker) ?
                        CacheContext.StringIdCache.GetStringId(objChildMarker) :
                        CacheContext.StringIdCache.AddString(objChildMarker);

                    var objChildVariant = BlamCache.Strings.GetItemByID((int)obj.ChildVariant.Value);
                    if (objChildVariant == "<blank>") objChildVariant = "";
                    obj.ChildVariant = CacheContext.StringIdCache.Contains(objChildVariant) ?
                        CacheContext.StringIdCache.GetStringId(objChildVariant) :
                        CacheContext.StringIdCache.AddString(objChildVariant);

                    obj.ChildObject = null;
                }
            }

            foreach (var instanceGroup in blamHlmt.InstanceGroups)
            {
                var instanceGroupName = BlamCache.Strings.GetItemByID((int)instanceGroup.Name.Value);
                if (instanceGroupName == "<blank>") instanceGroupName = "";
                instanceGroup.Name = CacheContext.StringIdCache.Contains(instanceGroupName) ?
                    CacheContext.StringIdCache.GetStringId(instanceGroupName) :
                    CacheContext.StringIdCache.AddString(instanceGroupName);

                foreach (var instanceMember in instanceGroup.InstanceMembers)
                {
                    var instanceMemberName = BlamCache.Strings.GetItemByID((int)instanceMember.InstanceName.Value);
                    if (instanceMemberName == "<blank>") instanceMemberName = "";
                    instanceMember.InstanceName = CacheContext.StringIdCache.Contains(instanceMemberName) ?
                        CacheContext.StringIdCache.GetStringId(instanceMemberName) :
                        CacheContext.StringIdCache.AddString(instanceMemberName);
                }
            }

            foreach (var material in blamHlmt.Materials)
            {
                var materialName = BlamCache.Strings.GetItemByID((int)material.Name.Value);
                if (materialName == "<blank>") materialName = "";
                material.Name = CacheContext.StringIdCache.Contains(materialName) ?
                    CacheContext.StringIdCache.GetStringId(materialName) :
                    CacheContext.StringIdCache.AddString(materialName);

                var materialMaterialName = BlamCache.Strings.GetItemByID((int)material.MaterialName.Value);
                if (materialMaterialName == "<blank>") materialMaterialName = "";
                material.MaterialName = CacheContext.StringIdCache.Contains(materialMaterialName) ?
                    CacheContext.StringIdCache.GetStringId(materialMaterialName) :
                    CacheContext.StringIdCache.AddString(materialMaterialName);
            }

            foreach (var newDamageInfo in blamHlmt.NewDamageInfo)
            {
                var newDamageInfoGlobalIndirectMaterialName = BlamCache.Strings.GetItemByID((int)newDamageInfo.GlobalIndirectMaterialName.Value);
                if (newDamageInfoGlobalIndirectMaterialName == "<blank>") newDamageInfoGlobalIndirectMaterialName = "";
                newDamageInfo.GlobalIndirectMaterialName = CacheContext.StringIdCache.Contains(newDamageInfoGlobalIndirectMaterialName) ?
                    CacheContext.StringIdCache.GetStringId(newDamageInfoGlobalIndirectMaterialName) :
                    CacheContext.StringIdCache.AddString(newDamageInfoGlobalIndirectMaterialName);

                var newDamageInfoGlobalShieldMaterialName = BlamCache.Strings.GetItemByID((int)newDamageInfo.GlobalShieldMaterialName.Value);
                if (newDamageInfoGlobalShieldMaterialName == "<blank>") newDamageInfoGlobalShieldMaterialName = "";
                newDamageInfo.GlobalShieldMaterialName = CacheContext.StringIdCache.Contains(newDamageInfoGlobalShieldMaterialName) ?
                    CacheContext.StringIdCache.GetStringId(newDamageInfoGlobalShieldMaterialName) :
                    CacheContext.StringIdCache.AddString(newDamageInfoGlobalShieldMaterialName);

                newDamageInfo.ShieldDamagedEffect = null;
                newDamageInfo.ShieldDepletedEffect = null;
                newDamageInfo.ShieldRechargingEffect = null;

                foreach (var damageSection in newDamageInfo.DamageSections)
                {
                    var damageSectionName = BlamCache.Strings.GetItemByID((int)damageSection.Name.Value);
                    if (damageSectionName == "<blank>") damageSectionName = "";
                    damageSection.Name = CacheContext.StringIdCache.Contains(damageSectionName) ?
                        CacheContext.StringIdCache.GetStringId(damageSectionName) :
                        CacheContext.StringIdCache.AddString(damageSectionName);

                    foreach (var instantResponse in damageSection.InstantResponses)
                    {
                        var instantResponseTrigger = BlamCache.Strings.GetItemByID((int)instantResponse.Trigger.Value);
                        if (instantResponseTrigger == "<blank>") instantResponseTrigger = "";
                        instantResponse.Trigger = CacheContext.StringIdCache.Contains(instantResponseTrigger) ?
                            CacheContext.StringIdCache.GetStringId(instantResponseTrigger) :
                            CacheContext.StringIdCache.AddString(instantResponseTrigger);

                        instantResponse.PrimaryTransitionEffect = null;
                        instantResponse.SecondaryTransitionEffect = null;
                        instantResponse.TransitionDamageEffect = null;

                        var instantResponseRegion = BlamCache.Strings.GetItemByID((int)instantResponse.Region.Value);
                        if (instantResponseRegion == "<blank>") instantResponseRegion = "";
                        instantResponse.Region = CacheContext.StringIdCache.Contains(instantResponseRegion) ?
                            CacheContext.StringIdCache.GetStringId(instantResponseRegion) :
                            CacheContext.StringIdCache.AddString(instantResponseRegion);

                        var instantResponseSecondaryRegion = BlamCache.Strings.GetItemByID((int)instantResponse.SecondaryRegion.Value);
                        if (instantResponseSecondaryRegion == "<blank>") instantResponseSecondaryRegion = "";
                        instantResponse.SecondaryRegion = CacheContext.StringIdCache.Contains(instantResponseSecondaryRegion) ?
                            CacheContext.StringIdCache.GetStringId(instantResponseSecondaryRegion) :
                            CacheContext.StringIdCache.AddString(instantResponseSecondaryRegion);

                        var instantResponseSpecialDamageCase = BlamCache.Strings.GetItemByID((int)instantResponse.SpecialDamageCase.Value);
                        if (instantResponseSpecialDamageCase == "<blank>") instantResponseSpecialDamageCase = "";
                        instantResponse.SpecialDamageCase = CacheContext.StringIdCache.Contains(instantResponseSpecialDamageCase) ?
                            CacheContext.StringIdCache.GetStringId(instantResponseSpecialDamageCase) :
                            CacheContext.StringIdCache.AddString(instantResponseSpecialDamageCase);

                        var instantResponseEffectMarkerName = BlamCache.Strings.GetItemByID((int)instantResponse.EffectMarkerName.Value);
                        if (instantResponseEffectMarkerName == "<blank>") instantResponseEffectMarkerName = "";
                        instantResponse.EffectMarkerName = CacheContext.StringIdCache.Contains(instantResponseEffectMarkerName) ?
                            CacheContext.StringIdCache.GetStringId(instantResponseEffectMarkerName) :
                            CacheContext.StringIdCache.AddString(instantResponseEffectMarkerName);

                        var instantResponseDamageEffectMarkerName = BlamCache.Strings.GetItemByID((int)instantResponse.DamageEffectMarkerName.Value);
                        if (instantResponseDamageEffectMarkerName == "<blank>") instantResponseDamageEffectMarkerName = "";
                        instantResponse.DamageEffectMarkerName = CacheContext.StringIdCache.Contains(instantResponseDamageEffectMarkerName) ?
                            CacheContext.StringIdCache.GetStringId(instantResponseDamageEffectMarkerName) :
                            CacheContext.StringIdCache.AddString(instantResponseDamageEffectMarkerName);

                        instantResponse.DelayEffect = null;

                        var instantResponseDelayEffectMarkerName = BlamCache.Strings.GetItemByID((int)instantResponse.DelayEffectMarkerName.Value);
                        if (instantResponseDelayEffectMarkerName == "<blank>") instantResponseDelayEffectMarkerName = "";
                        instantResponse.DelayEffectMarkerName = CacheContext.StringIdCache.Contains(instantResponseDelayEffectMarkerName) ?
                            CacheContext.StringIdCache.GetStringId(instantResponseDelayEffectMarkerName) :
                            CacheContext.StringIdCache.AddString(instantResponseDelayEffectMarkerName);

                        var instantResponseEjectingSeatLabel = BlamCache.Strings.GetItemByID((int)instantResponse.EjectingSeatLabel.Value);
                        if (instantResponseEjectingSeatLabel == "<blank>") instantResponseEjectingSeatLabel = "";
                        instantResponse.EjectingSeatLabel = CacheContext.StringIdCache.Contains(instantResponseEjectingSeatLabel) ?
                            CacheContext.StringIdCache.GetStringId(instantResponseEjectingSeatLabel) :
                            CacheContext.StringIdCache.AddString(instantResponseEjectingSeatLabel);

                        var instantResponseDestroyedChildObjectMarkerName = BlamCache.Strings.GetItemByID((int)instantResponse.DestroyedChildObjectMarkerName.Value);
                        if (instantResponseDestroyedChildObjectMarkerName == "<blank>") instantResponseDestroyedChildObjectMarkerName = "";
                        instantResponse.DestroyedChildObjectMarkerName = CacheContext.StringIdCache.Contains(instantResponseDestroyedChildObjectMarkerName) ?
                            CacheContext.StringIdCache.GetStringId(instantResponseDestroyedChildObjectMarkerName) :
                            CacheContext.StringIdCache.AddString(instantResponseDestroyedChildObjectMarkerName);

                    }

                    var damageSectionResurrectionRegionName = BlamCache.Strings.GetItemByID((int)damageSection.ResurrectionRegionName.Value);
                    if (damageSectionResurrectionRegionName == "<blank>") damageSectionResurrectionRegionName = "";
                    damageSection.ResurrectionRegionName = CacheContext.StringIdCache.Contains(damageSectionResurrectionRegionName) ?
                        CacheContext.StringIdCache.GetStringId(damageSectionResurrectionRegionName) :
                        CacheContext.StringIdCache.AddString(damageSectionResurrectionRegionName);
                }

                foreach (var damageSeat in newDamageInfo.DamageSeats)
                {
                    var damageSeatSeatLabel = BlamCache.Strings.GetItemByID((int)damageSeat.SeatLabel.Value);
                    if (damageSeatSeatLabel == "<blank>") damageSeatSeatLabel = "";
                    damageSeat.SeatLabel = CacheContext.StringIdCache.Contains(damageSeatSeatLabel) ?
                        CacheContext.StringIdCache.GetStringId(damageSeatSeatLabel) :
                        CacheContext.StringIdCache.AddString(damageSeatSeatLabel);

                    foreach (var unknown in damageSeat.Unknown)
                    {
                        var unknownNode = BlamCache.Strings.GetItemByID((int)unknown.Node.Value);
                        if (unknownNode == "<blank>") unknownNode = "";
                        unknown.Node = CacheContext.StringIdCache.Contains(unknownNode) ?
                            CacheContext.StringIdCache.GetStringId(unknownNode) :
                            CacheContext.StringIdCache.AddString(unknownNode);
                    }
                }

                foreach (var damageConstraint in newDamageInfo.DamageConstraints)
                {
                    var damageConstraintPhysicsModelConstraintName = BlamCache.Strings.GetItemByID((int)damageConstraint.PhysicsModelConstraintName.Value);
                    if (damageConstraintPhysicsModelConstraintName == "<blank>") damageConstraintPhysicsModelConstraintName = "";
                    damageConstraint.PhysicsModelConstraintName = CacheContext.StringIdCache.Contains(damageConstraintPhysicsModelConstraintName) ?
                        CacheContext.StringIdCache.GetStringId(damageConstraintPhysicsModelConstraintName) :
                        CacheContext.StringIdCache.AddString(damageConstraintPhysicsModelConstraintName);

                    var damageConstraintDamageConstraintName = BlamCache.Strings.GetItemByID((int)damageConstraint.DamageConstraintName.Value);
                    if (damageConstraintDamageConstraintName == "<blank>") damageConstraintDamageConstraintName = "";
                    damageConstraint.DamageConstraintName = CacheContext.StringIdCache.Contains(damageConstraintDamageConstraintName) ?
                        CacheContext.StringIdCache.GetStringId(damageConstraintDamageConstraintName) :
                        CacheContext.StringIdCache.AddString(damageConstraintDamageConstraintName);

                    var damageConstraintDamageConstraintGroupName = BlamCache.Strings.GetItemByID((int)damageConstraint.DamageConstraintGroupName.Value);
                    if (damageConstraintDamageConstraintGroupName == "<blank>") damageConstraintDamageConstraintGroupName = "";
                    damageConstraint.DamageConstraintGroupName = CacheContext.StringIdCache.Contains(damageConstraintDamageConstraintGroupName) ?
                        CacheContext.StringIdCache.GetStringId(damageConstraintDamageConstraintGroupName) :
                        CacheContext.StringIdCache.AddString(damageConstraintDamageConstraintGroupName);

                }
            }

            foreach (var target in blamHlmt.Targets)
            {
                var targetMarkerName = BlamCache.Strings.GetItemByID((int)target.MarkerName.Value);
                if (targetMarkerName == "<blank>") targetMarkerName = "";
                target.MarkerName = CacheContext.StringIdCache.Contains(targetMarkerName) ?
                    CacheContext.StringIdCache.GetStringId(targetMarkerName) :
                    CacheContext.StringIdCache.AddString(targetMarkerName);
            }

            foreach (var collisionRegion in blamHlmt.CollisionRegions)
            {
                var collisionRegionName = BlamCache.Strings.GetItemByID((int)collisionRegion.Name.Value);
                if (collisionRegionName == "<blank>") collisionRegionName = "";
                collisionRegion.Name = CacheContext.StringIdCache.Contains(collisionRegionName) ?
                    CacheContext.StringIdCache.GetStringId(collisionRegionName) :
                    CacheContext.StringIdCache.AddString(collisionRegionName);

                foreach (var permutation in collisionRegion.Permutations)
                {
                    var permutationName = BlamCache.Strings.GetItemByID((int)permutation.Name.Value);
                    if (permutationName == "<blank>") permutationName = "";
                    permutation.Name = CacheContext.StringIdCache.Contains(permutationName) ?
                        CacheContext.StringIdCache.GetStringId(permutationName) :
                        CacheContext.StringIdCache.AddString(permutationName);
                }
            }

            foreach (var node in blamHlmt.Nodes)
            {
                var nodeName = BlamCache.Strings.GetItemByID((int)node.Name.Value);
                if (nodeName == "<blank>") nodeName = "";
                node.Name = CacheContext.StringIdCache.Contains(nodeName) ?
                    CacheContext.StringIdCache.GetStringId(nodeName) :
                    CacheContext.StringIdCache.AddString(nodeName);
            }

            blamHlmt.PrimaryDialogue = null;
            blamHlmt.SecondaryDialogue = null;

            var blamHlmtDefaultDialogueEffect = BlamCache.Strings.GetItemByID((int)blamHlmt.DefaultDialogueEffect.Value);
            if (blamHlmtDefaultDialogueEffect == "<blank>") blamHlmtDefaultDialogueEffect = "";
            blamHlmt.DefaultDialogueEffect = CacheContext.StringIdCache.Contains(blamHlmtDefaultDialogueEffect) ?
                CacheContext.StringIdCache.GetStringId(blamHlmtDefaultDialogueEffect) :
                CacheContext.StringIdCache.AddString(blamHlmtDefaultDialogueEffect);

            foreach (var unknown2 in blamHlmt.Unknown6)
            {
                var unknown2Region = BlamCache.Strings.GetItemByID((int)unknown2.Region.Value);
                if (blamHlmtDefaultDialogueEffect == "<blank>") blamHlmtDefaultDialogueEffect = "";
                unknown2.Region = CacheContext.StringIdCache.Contains(unknown2Region) ?
                    CacheContext.StringIdCache.GetStringId(unknown2Region) :
                    CacheContext.StringIdCache.AddString(unknown2Region);

                var unknown2Permutation = BlamCache.Strings.GetItemByID((int)unknown2.Permutation.Value);
                if (blamHlmtDefaultDialogueEffect == "<blank>") blamHlmtDefaultDialogueEffect = "";
                unknown2.Permutation = CacheContext.StringIdCache.Contains(unknown2Permutation) ?
                    CacheContext.StringIdCache.GetStringId(unknown2Permutation) :
                    CacheContext.StringIdCache.AddString(unknown2Permutation);
            }

            foreach (var unknown3 in blamHlmt.Unknown7)
            {
                var unknown3Unknown = BlamCache.Strings.GetItemByID((int)unknown3.Unknown.Value);
                if (blamHlmtDefaultDialogueEffect == "<blank>") blamHlmtDefaultDialogueEffect = "";
                unknown3.Unknown = CacheContext.StringIdCache.Contains(unknown3Unknown) ?
                    CacheContext.StringIdCache.GetStringId(unknown3Unknown) :
                    CacheContext.StringIdCache.AddString(unknown3Unknown);
            }

            foreach (var unknown4 in blamHlmt.Unknown8)
            {
                var unknown4Marker = BlamCache.Strings.GetItemByID((int)unknown4.Marker.Value);
                if (blamHlmtDefaultDialogueEffect == "<blank>") blamHlmtDefaultDialogueEffect = "";
                unknown4.Marker = CacheContext.StringIdCache.Contains(unknown4Marker) ?
                    CacheContext.StringIdCache.GetStringId(unknown4Marker) :
                    CacheContext.StringIdCache.AddString(unknown4Marker);

                var unknown4Marker2 = BlamCache.Strings.GetItemByID((int)unknown4.Marker2.Value);
                if (blamHlmtDefaultDialogueEffect == "<blank>") blamHlmtDefaultDialogueEffect = "";
                unknown4.Marker2 = CacheContext.StringIdCache.Contains(unknown4Marker2) ?
                    CacheContext.StringIdCache.GetStringId(unknown4Marker2) :
                    CacheContext.StringIdCache.AddString(unknown4Marker2);
            }

            blamHlmt.ShieldImpactThirdPerson = null;
            blamHlmt.ShieldImpactFirstPerson = null;

            using (var resourceStream = new MemoryStream())
            {
                using (var cacheStream = CacheContext.TagCacheFile.Open(FileMode.Open, FileAccess.ReadWrite))
                {
                    Console.WriteLine("Writing tag data...");

                    var context = new TagSerializationContext(cacheStream, CacheContext, newHlmtTag);
                    CacheContext.Serializer.Serialize(context, blamHlmt);
                }
            }
            return true;
        }
    }
}
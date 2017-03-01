using System;
using System.Collections.Generic;
using System.IO;
using BlamCore.Cache.Base;
using BlamCore.Cache.HaloOnline;
using BlamCore.IO;
using BlamCore.Serialization;
using BlamCore.TagDefinitions;
using BlamCore.TagResources;

namespace TagTool.Commands.Porting
{
    class PortModelAnimationGraphCommand : Command
    {
        public GameCacheContext CacheContext { get; }
        public CacheFile BlamCache { get; }

        public PortModelAnimationGraphCommand(GameCacheContext cacheContext, CacheFile blamCache)
            : base(CommandFlags.Inherit,

                  "PortModelAnimationGraph",
                  "Read blam jmad, convert for Halo Online, and write to file. WIP.",

                  "PortModelAnimationGraph [New] <Blam Tag> <ElDorado Tag>",
                  "Read blam jmad, convert for Halo Online, and write to file. WIP.")
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

            #region Load Tags
            var jmadName = args[0];

            CacheFile.IndexItem blamTag = null;

            Console.WriteLine("Verifying Blam model_animation_graph tag...");

            foreach (var tag in BlamCache.IndexItems)
            {
                if (tag.ClassCode == "jmad" && tag.Filename == jmadName)
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

            Console.WriteLine("Verifying ElDorado model_animation_graph tag index...");

            var edTag = ArgumentParser.ParseTagSpecifier(CacheContext, args[1]);

            if (edTag.Group.Name != CacheContext.GetStringId("model_animation_graph"))
            {
                Console.WriteLine("Specified tag index is not a model_animation_graph: " + args[1]);
                return false;
            }

            Console.WriteLine("Loading ElDorado model_animation_graph tag...");

            ModelAnimationGraph edJmad;

            using (var cacheStream = CacheContext.TagCacheFile.Open(FileMode.Open, FileAccess.ReadWrite))
            {
                try
                {
                    var edContext = new TagSerializationContext(cacheStream, CacheContext, edTag);
                    edJmad = CacheContext.Deserializer.Deserialize<ModelAnimationGraph>(edContext);
                }
                catch
                {
                    Console.WriteLine("Failed to deserialize selected model_animation_graph tag: 0x" + edTag.Index.ToString("X4"));
                    return true;
                }
            }

            var blamDeserializer = new TagDeserializer(BlamCache.Version);
            var blamContext = new CacheSerializationContext(CacheContext, BlamCache, blamTag);
            var blamJmad = blamDeserializer.Deserialize<ModelAnimationGraph>(blamContext);
            #endregion

            #region Null tag references for now.
            blamJmad.ParentAnimationGraph = null;

            foreach (var reference in blamJmad.SoundReferences)
                reference.Reference = null;

            foreach (var reference in blamJmad.EffectReferences)
                reference.Reference = null;

            foreach (var mode in blamJmad.Modes)
                if (mode.WeaponClass != null)
                    foreach (var weaponClass in mode.WeaponClass)
                        if (weaponClass.SyncActionGroups != null)
                            foreach (var syncActionGroup in weaponClass.SyncActionGroups)
                                if (syncActionGroup.SyncActions != null)
                                    foreach (var syncAction in syncActionGroup.SyncActions)
                                        if (syncAction.OtherParticipants != null)
                                            foreach (var otherParticipant in syncAction.OtherParticipants)
                                                otherParticipant.ObjectType = null;

            foreach (var inheritance in blamJmad.InheritanceList)
                inheritance.InheritedGraph = null;
            #endregion

            #region StringId
            string stringId;
            string stringId2;
            string stringId3;
            foreach (var skeletonNode in blamJmad.SkeletonNodes)
            {
                stringId = BlamCache.Strings.GetItemByID((int)skeletonNode.Name.Value);

                skeletonNode.Name = CacheContext.StringIdCache.Contains(stringId) ?
                    CacheContext.StringIdCache.GetStringId(stringId) :
                    CacheContext.StringIdCache.AddString(stringId);
            }

            foreach (var blendScreen in blamJmad.BlendScreens)
            {
                stringId = BlamCache.Strings.GetItemByID((int)blendScreen.Label.Value);

                blendScreen.Label = CacheContext.StringIdCache.Contains(stringId) ?
                    CacheContext.StringIdCache.GetStringId(stringId) :
                    CacheContext.StringIdCache.AddString(stringId);
            }

            foreach (var leg in blamJmad.Legs)
            {
                stringId = BlamCache.Strings.GetItemByID((int)leg.FootMarker.Value);

                leg.FootMarker = CacheContext.StringIdCache.Contains(stringId) ?
                    CacheContext.StringIdCache.GetStringId(stringId) :
                    CacheContext.StringIdCache.AddString(stringId);

                stringId2 = BlamCache.Strings.GetItemByID((int)leg.AnkleMarker.Value);

                leg.AnkleMarker = CacheContext.StringIdCache.Contains(stringId2) ?
                    CacheContext.StringIdCache.GetStringId(stringId2) :
                    CacheContext.StringIdCache.AddString(stringId2);
            }

            foreach (var animation in blamJmad.Animations)
            {
                stringId = BlamCache.Strings.GetItemByID((int)animation.Name.Value);

                animation.Name = CacheContext.StringIdCache.Contains(stringId) ?
                    CacheContext.StringIdCache.GetStringId(stringId) :
                    CacheContext.StringIdCache.AddString(stringId);
            }

            foreach (var mode in blamJmad.Modes)
            {
                stringId = BlamCache.Strings.GetItemByID((int)mode.Label.Value);

                mode.Label = CacheContext.StringIdCache.Contains(stringId) ?
                    CacheContext.StringIdCache.GetStringId(stringId) :
                    CacheContext.StringIdCache.AddString(stringId);

                foreach (var weaponClass in mode.WeaponClass)
                {
                    stringId = BlamCache.Strings.GetItemByID((int)weaponClass.Label.Value);

                    weaponClass.Label = CacheContext.StringIdCache.Contains(stringId) ?
                        CacheContext.StringIdCache.GetStringId(stringId) :
                        CacheContext.StringIdCache.AddString(stringId);

                    foreach (var weaponType in weaponClass.WeaponType)
                    {
                        stringId = BlamCache.Strings.GetItemByID((int)weaponType.Label.Value);

                        weaponType.Label = CacheContext.StringIdCache.Contains(stringId) ?
                            CacheContext.StringIdCache.GetStringId(stringId) :
                            CacheContext.StringIdCache.AddString(stringId);

                        foreach (var action in weaponType.Actions)
                        {
                            stringId = BlamCache.Strings.GetItemByID((int)action.Label.Value);

                            action.Label = CacheContext.StringIdCache.Contains(stringId) ?
                                CacheContext.StringIdCache.GetStringId(stringId) :
                                CacheContext.StringIdCache.AddString(stringId);
                        }

                        foreach (var overlay in weaponType.Overlays)
                        {
                            stringId = BlamCache.Strings.GetItemByID((int)overlay.Label.Value);

                            overlay.Label = CacheContext.StringIdCache.Contains(stringId) ?
                                CacheContext.StringIdCache.GetStringId(stringId) :
                                CacheContext.StringIdCache.AddString(stringId);
                        }
                    }
                    foreach (var weaponIk in weaponClass.WeaponIk)
                    {
                        stringId = BlamCache.Strings.GetItemByID((int)weaponIk.Marker.Value);

                        weaponIk.Marker = CacheContext.StringIdCache.Contains(stringId) ?
                            CacheContext.StringIdCache.GetStringId(stringId) :
                            CacheContext.StringIdCache.AddString(stringId);

                        stringId2 = BlamCache.Strings.GetItemByID((int)weaponIk.AttachToMarker.Value);

                        weaponIk.Marker = CacheContext.StringIdCache.Contains(stringId2) ?
                            CacheContext.StringIdCache.GetStringId(stringId2) :
                            CacheContext.StringIdCache.AddString(stringId2);
                    }
                }
            }

            foreach (var vehicleSuspension in blamJmad.VehicleSuspension)
            {
                stringId = BlamCache.Strings.GetItemByID((int)vehicleSuspension.Label.Value);

                vehicleSuspension.Label = CacheContext.StringIdCache.Contains(stringId) ?
                    CacheContext.StringIdCache.GetStringId(stringId) :
                    CacheContext.StringIdCache.AddString(stringId);

                stringId2 = BlamCache.Strings.GetItemByID((int)vehicleSuspension.MarkerName.Value);

                vehicleSuspension.MarkerName = CacheContext.StringIdCache.Contains(stringId2) ?
                    CacheContext.StringIdCache.GetStringId(stringId2) :
                    CacheContext.StringIdCache.AddString(stringId2);

                stringId3 = BlamCache.Strings.GetItemByID((int)vehicleSuspension.RegionName.Value);

                vehicleSuspension.RegionName = CacheContext.StringIdCache.Contains(stringId3) ?
                    CacheContext.StringIdCache.GetStringId(stringId3) :
                    CacheContext.StringIdCache.AddString(stringId3);
            }

            foreach (var objectOverlay in blamJmad.ObjectOverlays)
            {
                stringId = BlamCache.Strings.GetItemByID((int)objectOverlay.Label.Value);

                objectOverlay.Label = CacheContext.StringIdCache.Contains(stringId) ?
                    CacheContext.StringIdCache.GetStringId(stringId) :
                    CacheContext.StringIdCache.AddString(stringId);

                stringId2 = BlamCache.Strings.GetItemByID((int)objectOverlay.Function.Value);

                objectOverlay.Function = CacheContext.StringIdCache.Contains(stringId2) ?
                    CacheContext.StringIdCache.GetStringId(stringId2) :
                    CacheContext.StringIdCache.AddString(stringId2);
            }

            foreach (var weaponList in blamJmad.WeaponList)
            {
                stringId = BlamCache.Strings.GetItemByID((int)weaponList.WeaponName.Value);

                weaponList.WeaponName = CacheContext.StringIdCache.Contains(stringId) ?
                    CacheContext.StringIdCache.GetStringId(stringId) :
                    CacheContext.StringIdCache.AddString(stringId);

                stringId2 = BlamCache.Strings.GetItemByID((int)weaponList.WeaponClass.Value);

                weaponList.WeaponClass = CacheContext.StringIdCache.Contains(stringId2) ?
                    CacheContext.StringIdCache.GetStringId(stringId2) :
                    CacheContext.StringIdCache.AddString(stringId2);
            }
            #endregion

            #region Resource fixups // H3
            var deserializer = new TagDeserializer(BlamCache.Version);

            var resourceGroups = new List<ModelAnimationTagResource>(); // has list of all groups and list of members, for members framecount

            var resourcesFixups = new List<BlamCore.Cache.cache_file_resource_gestalt.RawEntry>(); // has list of all groups and list of members, for members offsets

            for (int i = 0; i < blamJmad.ResourceGroups.Count; i++)
            {
                var RawID = blamJmad.ResourceGroups[i].ZoneAssetDatumIndex;
                var Entry = BlamCache.zone.RawEntries[RawID & ushort.MaxValue];
                resourcesFixups.Add(Entry);
                resourceGroups.Add(new ModelAnimationTagResource());
                resourceGroups[i].GroupMembers = new List<ModelAnimationTagResource.GroupMember>();

                using (var reader = new EndianReader(new MemoryStream(BlamCache.zone.FixupData), EndianFormat.BigEndian))
                {
                    reader.SeekTo(Entry.FixupOffset);
                    var dataContext = new DataSerializationContext(reader, null);

                    for (int memberIndex = 0; memberIndex < blamJmad.ResourceGroups[i].MemberCount; memberIndex++)
                    {
                        var member = deserializer.Deserialize<ModelAnimationTagResource.GroupMember>(dataContext);

                        resourceGroups[i].GroupMembers.Add(new ModelAnimationTagResource.GroupMember());
                        resourceGroups[i].GroupMembers[memberIndex] = member;
                    }
                }
            }
            #endregion

            EndianFormat endianFormat = EndianFormat.BigEndian; // DEBUG: BigEndian for HO format. LittleEndian to extract and compare to H3 raw.

            Console.WriteLine("");
            Console.Write("Converting animations...");

            for (int resourceGroupIndex = 0; resourceGroupIndex < blamJmad.ResourceGroups.Count; resourceGroupIndex++)
            {
                using (MemoryStream newStream = new MemoryStream())
                using (BinaryWriter newResourceGroupStream = new BinaryWriter(newStream))
                using (MemoryStream resourceDataStream = new MemoryStream(BlamCache.GetRawFromID(blamJmad.ResourceGroups[resourceGroupIndex].ZoneAssetDatumIndex)))
                using (EndianReader reader = new EndianReader(resourceDataStream, endianFormat))
                {
                    var dataContext = new DataSerializationContext(reader, null);

                    ModelAnimationTagResource.GroupMember.AnimationHeaderType1 Type1;

                    // foreach (var member in resourceGroups[resourceGroupIndex].GroupMembers)
                    for (int memberIndex = 0; memberIndex < resourceGroups[resourceGroupIndex].GroupMembers.Count; memberIndex++)
                    {
                        ModelAnimationTagResource.GroupMember rawMember = new ModelAnimationTagResource.GroupMember();

                        #region Main; Get Member Info
                        int frameCount = resourceGroups[resourceGroupIndex].GroupMembers[memberIndex].FrameCount;
                        int memberOffset = resourcesFixups[resourceGroupIndex].Fixups[memberIndex].Offset;
                        short overlayOffset = resourceGroups[resourceGroupIndex].GroupMembers[memberIndex].OverlayOffset;
                        uint footerOffset = resourceGroups[resourceGroupIndex].GroupMembers[memberIndex].FlagsOffset;
                        long footerOffsetActual = memberOffset + overlayOffset + footerOffset;
                        long overlayOffsetActual = memberOffset + overlayOffset;

                        reader.BaseStream.Position = memberOffset;

                        ModelAnimationTagResource.GroupMember.AnimationHeaderGlobal headerOverlayGlobal = new ModelAnimationTagResource.GroupMember.AnimationHeaderGlobal();

                        long headerBasePosition = reader.BaseStream.Position;

                        var headerGlobal = CacheContext.Deserializer.Deserialize<ModelAnimationTagResource.GroupMember.AnimationHeaderGlobal>(dataContext); // read simple header to know its type
                        reader.BaseStream.Position -= 0x4; // there must be a better non cheap cheesy way; peek?
                        #endregion

                        #region Type 1
                        Type1 = new ModelAnimationTagResource.GroupMember.AnimationHeaderType1();
                        if (headerGlobal.HeaderStructType_ == ModelAnimationTagResource.GroupMemberAnimationType.Type1)
                        {
                            dataContext = new DataSerializationContext(reader, null);

                            Type1 = CacheContext.Deserializer.Deserialize<ModelAnimationTagResource.GroupMember.AnimationHeaderType1>(dataContext);

                            newResourceGroupStream.Write((sbyte)Type1.HeaderStructType_);
                            newResourceGroupStream.Write((sbyte)Type1.RotationNodeCount);
                            newResourceGroupStream.Write((sbyte)Type1.PositionNodeCount);
                            newResourceGroupStream.Write((sbyte)Type1.SpecularNodeCount);
                            newResourceGroupStream.Write(0x796E6144); // signature, doesn't seem to affect the file.
                            newResourceGroupStream.Write(0x39333635); // signature
                            // newResourceGroupStream.Write((uint)Type1.Unknown0); // default
                            // newResourceGroupStream.Write((uint)Type1.Unknown1); // default
                            newResourceGroupStream.Write((uint)Type1.PositionFramesOffset);
                            newResourceGroupStream.Write((uint)Type1.SpecularFramesOffset);
                            newResourceGroupStream.Write((uint)Type1.RotationFramesSize);
                            newResourceGroupStream.Write((uint)Type1.PositionFramesSize);
                            newResourceGroupStream.Write((uint)Type1.SpecularFramesSize);

                            #region Type1 Static Frames
                            List<ModelAnimationTagResource.GroupMember.RotationFrame> StaticRotations = new List<ModelAnimationTagResource.GroupMember.RotationFrame>();
                            List<ModelAnimationTagResource.GroupMember.PositionFrame> StaticPositions = new List<ModelAnimationTagResource.GroupMember.PositionFrame>();
                            List<ModelAnimationTagResource.GroupMember.SpecularFrame> StaticSpeculars = new List<ModelAnimationTagResource.GroupMember.SpecularFrame>();

                            int staticFrameCount = 1;
                            for (int nodeIndex = 0; nodeIndex < Type1.RotationNodeCount; nodeIndex++)
                            {
                                for (int frameIndex = 0; frameIndex < staticFrameCount; frameIndex++)
                                {
                                    StaticRotations.Add(CacheContext.Deserializer.Deserialize<ModelAnimationTagResource.GroupMember.RotationFrame>(dataContext));
                                    newResourceGroupStream.Write(StaticRotations[StaticRotations.Count - 1].X);
                                    newResourceGroupStream.Write(StaticRotations[StaticRotations.Count - 1].Y);
                                    newResourceGroupStream.Write(StaticRotations[StaticRotations.Count - 1].Z);
                                    newResourceGroupStream.Write(StaticRotations[StaticRotations.Count - 1].W);
                                }
                            }

                            for (int nodeIndex = 0; nodeIndex < Type1.PositionNodeCount; nodeIndex++)
                            {
                                for (int frameIndex = 0; frameIndex < staticFrameCount; frameIndex++)
                                {
                                    StaticPositions.Add(CacheContext.Deserializer.Deserialize<ModelAnimationTagResource.GroupMember.PositionFrame>(dataContext));
                                    newResourceGroupStream.Write(StaticPositions[StaticPositions.Count - 1].X);
                                    newResourceGroupStream.Write(StaticPositions[StaticPositions.Count - 1].Y);
                                    newResourceGroupStream.Write(StaticPositions[StaticPositions.Count - 1].Z);
                                }
                            }

                            for (int nodeIndex = 0; nodeIndex < Type1.SpecularNodeCount; nodeIndex++)
                            {
                                for (int frameIndex = 0; frameIndex < staticFrameCount; frameIndex++)
                                {
                                    StaticSpeculars.Add(CacheContext.Deserializer.Deserialize<ModelAnimationTagResource.GroupMember.SpecularFrame>(dataContext));
                                    newResourceGroupStream.Write(StaticSpeculars[StaticSpeculars.Count - 1].X);
                                }
                            }
                            #endregion
                        }
                        #endregion

                        #region Read header 2 overlay type
                        reader.BaseStream.Position = memberOffset + overlayOffset;
                        dataContext = new DataSerializationContext(reader, null);
                        headerGlobal = CacheContext.Deserializer.Deserialize<ModelAnimationTagResource.GroupMember.AnimationHeaderGlobal>(dataContext);
                        reader.BaseStream.Position -= 0x4; // there must be a better non cheap cheesy way
                        #endregion

                        switch (headerGlobal.HeaderStructType_)
                        {
                            #region Type 3
                            case ModelAnimationTagResource.GroupMemberAnimationType.Type3:
                                var Type3 = CacheContext.Deserializer.Deserialize<ModelAnimationTagResource.GroupMember.AnimationHeaderType1>(dataContext);

                                newResourceGroupStream.Write((sbyte)Type3.HeaderStructType_);
                                newResourceGroupStream.Write((sbyte)Type3.RotationNodeCount);
                                newResourceGroupStream.Write((sbyte)Type3.PositionNodeCount);
                                newResourceGroupStream.Write((sbyte)Type3.SpecularNodeCount);
                                newResourceGroupStream.Write((uint)Type3.Unknown0);
                                newResourceGroupStream.Write((uint)Type3.Unknown1);
                                newResourceGroupStream.Write((uint)Type3.PositionFramesOffset);
                                newResourceGroupStream.Write((uint)Type3.SpecularFramesOffset);
                                newResourceGroupStream.Write((uint)Type3.RotationFramesSize);
                                newResourceGroupStream.Write((uint)Type3.PositionFramesSize);
                                newResourceGroupStream.Write((uint)Type3.SpecularFramesSize);

                                #region Type3 Animated Frames
                                List<ModelAnimationTagResource.GroupMember.RotationFrame> OverlayRotations = new List<ModelAnimationTagResource.GroupMember.RotationFrame>();
                                List<ModelAnimationTagResource.GroupMember.PositionFrame> OverlayPositions = new List<ModelAnimationTagResource.GroupMember.PositionFrame>();
                                List<ModelAnimationTagResource.GroupMember.SpecularFrame> OverlaySpeculars = new List<ModelAnimationTagResource.GroupMember.SpecularFrame>();

                                for (int nodeIndex = 0; nodeIndex < Type3.RotationNodeCount; nodeIndex++)
                                {
                                    var rotationFrames = new List<ModelAnimationTagResource.GroupMember.RotationFrame>();
                                    for (int frameIndex = 0; frameIndex < frameCount; frameIndex++)
                                    {
                                        OverlayRotations.Add(CacheContext.Deserializer.Deserialize<ModelAnimationTagResource.GroupMember.RotationFrame>(dataContext));
                                        newResourceGroupStream.Write(OverlayRotations[OverlayRotations.Count - 1].X);
                                        newResourceGroupStream.Write(OverlayRotations[OverlayRotations.Count - 1].Y);
                                        newResourceGroupStream.Write(OverlayRotations[OverlayRotations.Count - 1].Z);
                                        newResourceGroupStream.Write(OverlayRotations[OverlayRotations.Count - 1].W);
                                    }
                                }

                                for (int nodeIndex = 0; nodeIndex < Type3.PositionNodeCount; nodeIndex++)
                                {
                                    var positionFrames = new List<ModelAnimationTagResource.GroupMember.PositionFrame>();
                                    for (int frameIndex = 0; frameIndex < frameCount; frameIndex++)
                                    {
                                        OverlayPositions.Add(CacheContext.Deserializer.Deserialize<ModelAnimationTagResource.GroupMember.PositionFrame>(dataContext));
                                        newResourceGroupStream.Write(OverlayPositions[OverlayPositions.Count - 1].X);
                                        newResourceGroupStream.Write(OverlayPositions[OverlayPositions.Count - 1].Y);
                                        newResourceGroupStream.Write(OverlayPositions[OverlayPositions.Count - 1].Z);
                                    }
                                }

                                for (int nodeIndex = 0; nodeIndex < Type3.SpecularNodeCount; nodeIndex++)
                                {
                                    var specularFrames = new List<ModelAnimationTagResource.GroupMember.SpecularFrame>();
                                    for (int frameIndex = 0; frameIndex < frameCount; frameIndex++)
                                    {
                                        OverlaySpeculars.Add(CacheContext.Deserializer.Deserialize<ModelAnimationTagResource.GroupMember.SpecularFrame>(dataContext));
                                        newResourceGroupStream.Write(OverlaySpeculars[OverlaySpeculars.Count - 1].X);
                                    }
                                }
                                #endregion
                                break;
                            #endregion
                            #region Type 4
                            case ModelAnimationTagResource.GroupMemberAnimationType.Type4:
                                var Type4 = CacheContext.Deserializer.Deserialize<ModelAnimationTagResource.GroupMember.AnimationHeaderOverlay>(dataContext);

                                newResourceGroupStream.Write((sbyte)Type4.HeaderStructType_);
                                newResourceGroupStream.Write((sbyte)Type4.RotationNodeCount);
                                newResourceGroupStream.Write((sbyte)Type4.PositionNodeCount);
                                newResourceGroupStream.Write((sbyte)Type4.SpecularNodeCount);
                                newResourceGroupStream.Write((uint)Type4.Unknown0);
                                newResourceGroupStream.Write((uint)Type4.Unknown1);
                                newResourceGroupStream.Write((uint)Type4.PositionFramesCountPerNodeOffset);
                                newResourceGroupStream.Write((uint)Type4.RealFrameMarkerOffset);
                                newResourceGroupStream.Write((uint)Type4.RealFrameMarkerOffset1);
                                newResourceGroupStream.Write((uint)Type4.RotationsRealFrameMarkersEndOffset);
                                newResourceGroupStream.Write((uint)Type4.PositionsRealFrameMarkersEndOffset);
                                newResourceGroupStream.Write((uint)Type4.RotationFramesOffset);
                                newResourceGroupStream.Write((uint)Type4.PositionFramesOffset);
                                newResourceGroupStream.Write((uint)Type4.SpecularFramesOffset);
                                newResourceGroupStream.Write((uint)Type4.UselessPadding);

                                #region Overlay Frame Parameters and Frames REALLY CHEAP
                                // Since there's an inconsistent frame count per node, calculations need to be done to know which node has how many frames, 

                                var PositionFramesCountPerNode = new List<ModelAnimationTagResource.GroupMember.PositionFramesCountPerNode>();
                                var RealFrameMarker = new List<ModelAnimationTagResource.GroupMember.RealFrameMarker>();
                                OverlayRotations = new List<ModelAnimationTagResource.GroupMember.RotationFrame>();
                                OverlayPositions = new List<ModelAnimationTagResource.GroupMember.PositionFrame>();
                                OverlaySpeculars = new List<ModelAnimationTagResource.GroupMember.SpecularFrame>();

                                while (reader.BaseStream.Position < memberOffset + overlayOffset + Type4.RealFrameMarkerOffset) // until the next block of whatever
                                {
                                    PositionFramesCountPerNode.Add(CacheContext.Deserializer.Deserialize<ModelAnimationTagResource.GroupMember.PositionFramesCountPerNode>(dataContext));
                                    newResourceGroupStream.Write(PositionFramesCountPerNode[PositionFramesCountPerNode.Count - 1].X);
                                }

                                while (reader.BaseStream.Position < memberOffset + overlayOffset + Type4.RotationFramesOffset)
                                {
                                    RealFrameMarker.Add(CacheContext.Deserializer.Deserialize<ModelAnimationTagResource.GroupMember.RealFrameMarker>(dataContext));
                                    newResourceGroupStream.Write(RealFrameMarker[RealFrameMarker.Count - 1].X);
                                    newResourceGroupStream.Write(RealFrameMarker[RealFrameMarker.Count - 1].Y);
                                    newResourceGroupStream.Write(RealFrameMarker[RealFrameMarker.Count - 1].Z);
                                    newResourceGroupStream.Write(RealFrameMarker[RealFrameMarker.Count - 1].W);
                                }

                                while (reader.BaseStream.Position < memberOffset + overlayOffset + Type4.PositionFramesOffset)
                                {
                                    OverlayRotations.Add(CacheContext.Deserializer.Deserialize<ModelAnimationTagResource.GroupMember.RotationFrame>(dataContext));
                                    newResourceGroupStream.Write(OverlayRotations[OverlayRotations.Count - 1].X);
                                    newResourceGroupStream.Write(OverlayRotations[OverlayRotations.Count - 1].Y);
                                    newResourceGroupStream.Write(OverlayRotations[OverlayRotations.Count - 1].Z);
                                    newResourceGroupStream.Write(OverlayRotations[OverlayRotations.Count - 1].W);
                                }

                                while (reader.BaseStream.Position < memberOffset + overlayOffset + Type4.SpecularFramesOffset)
                                {
                                    OverlayPositions.Add(CacheContext.Deserializer.Deserialize<ModelAnimationTagResource.GroupMember.PositionFrame>(dataContext));
                                    newResourceGroupStream.Write(OverlayPositions[OverlayPositions.Count - 1].X);
                                    newResourceGroupStream.Write(OverlayPositions[OverlayPositions.Count - 1].Y);
                                    newResourceGroupStream.Write(OverlayPositions[OverlayPositions.Count - 1].Z);
                                }

                                while (reader.BaseStream.Position < footerOffset)
                                {
                                    OverlaySpeculars.Add(CacheContext.Deserializer.Deserialize<ModelAnimationTagResource.GroupMember.SpecularFrame>(dataContext));
                                    newResourceGroupStream.Write(OverlaySpeculars[OverlaySpeculars.Count - 1].X);
                                }
                                #endregion
                                break;
                            #endregion
                            #region Type 6
                            case ModelAnimationTagResource.GroupMemberAnimationType.Type6:
                                var Type6 = CacheContext.Deserializer.Deserialize<ModelAnimationTagResource.GroupMember.AnimationHeaderOverlay>(dataContext);

                                newResourceGroupStream.Write((sbyte)Type6.HeaderStructType_);
                                newResourceGroupStream.Write((sbyte)Type6.RotationNodeCount);
                                newResourceGroupStream.Write((sbyte)Type6.PositionNodeCount);
                                newResourceGroupStream.Write((sbyte)Type6.SpecularNodeCount);
                                newResourceGroupStream.Write((uint)Type6.Unknown0);
                                newResourceGroupStream.Write((uint)Type6.Unknown1);
                                newResourceGroupStream.Write((uint)Type6.PositionFramesCountPerNodeOffset);
                                newResourceGroupStream.Write((uint)Type6.RealFrameMarkerOffset);
                                newResourceGroupStream.Write((uint)Type6.RealFrameMarkerOffset1);
                                newResourceGroupStream.Write((uint)Type6.RotationsRealFrameMarkersEndOffset);
                                newResourceGroupStream.Write((uint)Type6.PositionsRealFrameMarkersEndOffset);
                                newResourceGroupStream.Write((uint)Type6.RotationFramesOffset);
                                newResourceGroupStream.Write((uint)Type6.PositionFramesOffset);
                                newResourceGroupStream.Write((uint)Type6.SpecularFramesOffset);
                                newResourceGroupStream.Write((uint)Type6.UselessPadding);

                                #region Overlay Frame Parameters and Frames REALLY CHEAP
                                // Since there's an inconsistent frame count per node, calculations need to be done to know which node has how many frames, 

                                PositionFramesCountPerNode = new List<ModelAnimationTagResource.GroupMember.PositionFramesCountPerNode>();
                                RealFrameMarker = new List<ModelAnimationTagResource.GroupMember.RealFrameMarker>();
                                OverlayRotations = new List<ModelAnimationTagResource.GroupMember.RotationFrame>();
                                OverlayPositions = new List<ModelAnimationTagResource.GroupMember.PositionFrame>();
                                OverlaySpeculars = new List<ModelAnimationTagResource.GroupMember.SpecularFrame>();

                                while (reader.BaseStream.Position < memberOffset + overlayOffset + Type6.RealFrameMarkerOffset) // until the next block of whatever
                                {
                                    PositionFramesCountPerNode.Add(CacheContext.Deserializer.Deserialize<ModelAnimationTagResource.GroupMember.PositionFramesCountPerNode>(dataContext));
                                    newResourceGroupStream.Write(PositionFramesCountPerNode[PositionFramesCountPerNode.Count - 1].X);
                                }

                                while (reader.BaseStream.Position < memberOffset + overlayOffset + Type6.RotationFramesOffset)
                                {
                                    RealFrameMarker.Add(CacheContext.Deserializer.Deserialize<ModelAnimationTagResource.GroupMember.RealFrameMarker>(dataContext));
                                    newResourceGroupStream.Write(RealFrameMarker[RealFrameMarker.Count - 1].X);
                                    newResourceGroupStream.Write(RealFrameMarker[RealFrameMarker.Count - 1].Y);
                                    newResourceGroupStream.Write(RealFrameMarker[RealFrameMarker.Count - 1].Z);
                                    newResourceGroupStream.Write(RealFrameMarker[RealFrameMarker.Count - 1].W);
                                }

                                while (reader.BaseStream.Position < memberOffset + overlayOffset + Type6.PositionFramesOffset)
                                {
                                    OverlayRotations.Add(CacheContext.Deserializer.Deserialize<ModelAnimationTagResource.GroupMember.RotationFrame>(dataContext));
                                    newResourceGroupStream.Write(OverlayRotations[OverlayRotations.Count - 1].X);
                                    newResourceGroupStream.Write(OverlayRotations[OverlayRotations.Count - 1].Y);
                                    newResourceGroupStream.Write(OverlayRotations[OverlayRotations.Count - 1].Z);
                                    newResourceGroupStream.Write(OverlayRotations[OverlayRotations.Count - 1].W);
                                }

                                while (reader.BaseStream.Position < memberOffset + overlayOffset + Type6.SpecularFramesOffset)
                                {
                                    OverlayPositions.Add(CacheContext.Deserializer.Deserialize<ModelAnimationTagResource.GroupMember.PositionFrame>(dataContext));
                                    newResourceGroupStream.Write(OverlayPositions[OverlayPositions.Count - 1].X);
                                    newResourceGroupStream.Write(OverlayPositions[OverlayPositions.Count - 1].Y);
                                    newResourceGroupStream.Write(OverlayPositions[OverlayPositions.Count - 1].Z);
                                }

                                while (reader.BaseStream.Position < footerOffset)
                                {
                                    OverlaySpeculars.Add(CacheContext.Deserializer.Deserialize<ModelAnimationTagResource.GroupMember.SpecularFrame>(dataContext));
                                    newResourceGroupStream.Write(OverlaySpeculars[OverlaySpeculars.Count - 1].X);
                                }
                                #endregion
                                break;
                            #endregion
                            #region Type 7
                            case ModelAnimationTagResource.GroupMemberAnimationType.Type7:
                                var Type7 = CacheContext.Deserializer.Deserialize<ModelAnimationTagResource.GroupMember.AnimationHeaderOverlay>(dataContext);

                                newResourceGroupStream.Write((sbyte)Type7.HeaderStructType_);
                                newResourceGroupStream.Write((sbyte)Type7.RotationNodeCount);
                                newResourceGroupStream.Write((sbyte)Type7.PositionNodeCount);
                                newResourceGroupStream.Write((sbyte)Type7.SpecularNodeCount);
                                newResourceGroupStream.Write((uint)Type7.Unknown0);
                                newResourceGroupStream.Write((uint)Type7.Unknown1);
                                newResourceGroupStream.Write((uint)Type7.PositionFramesCountPerNodeOffset);
                                newResourceGroupStream.Write((uint)Type7.RealFrameMarkerOffset);
                                newResourceGroupStream.Write((uint)Type7.RealFrameMarkerOffset1);
                                newResourceGroupStream.Write((uint)Type7.RotationsRealFrameMarkersEndOffset);
                                newResourceGroupStream.Write((uint)Type7.PositionsRealFrameMarkersEndOffset);
                                newResourceGroupStream.Write((uint)Type7.RotationFramesOffset);
                                newResourceGroupStream.Write((uint)Type7.PositionFramesOffset);
                                newResourceGroupStream.Write((uint)Type7.SpecularFramesOffset);
                                newResourceGroupStream.Write((uint)Type7.UselessPadding);

                                #region Overlay Frame Parameters and Frames REALLY CHEAP
                                // Since there's an inconsistent frame count per node, calculations need to be done to know which node has how many frames, 

                                PositionFramesCountPerNode = new List<ModelAnimationTagResource.GroupMember.PositionFramesCountPerNode>();
                                RealFrameMarker = new List<ModelAnimationTagResource.GroupMember.RealFrameMarker>();
                                OverlayRotations = new List<ModelAnimationTagResource.GroupMember.RotationFrame>();
                                OverlayPositions = new List<ModelAnimationTagResource.GroupMember.PositionFrame>();
                                OverlaySpeculars = new List<ModelAnimationTagResource.GroupMember.SpecularFrame>();

                                while (reader.BaseStream.Position < memberOffset + overlayOffset + Type7.RealFrameMarkerOffset) // until the next block of whatever
                                {
                                    PositionFramesCountPerNode.Add(CacheContext.Deserializer.Deserialize<ModelAnimationTagResource.GroupMember.PositionFramesCountPerNode>(dataContext));
                                    newResourceGroupStream.Write(PositionFramesCountPerNode[PositionFramesCountPerNode.Count - 1].X);
                                }

                                while (reader.BaseStream.Position < memberOffset + overlayOffset + Type7.RotationFramesOffset)
                                {
                                    RealFrameMarker.Add(CacheContext.Deserializer.Deserialize<ModelAnimationTagResource.GroupMember.RealFrameMarker>(dataContext));
                                    newResourceGroupStream.Write(RealFrameMarker[RealFrameMarker.Count - 1].X);
                                    newResourceGroupStream.Write(RealFrameMarker[RealFrameMarker.Count - 1].Y);
                                    newResourceGroupStream.Write(RealFrameMarker[RealFrameMarker.Count - 1].Z);
                                    newResourceGroupStream.Write(RealFrameMarker[RealFrameMarker.Count - 1].W);
                                }

                                while (reader.BaseStream.Position < memberOffset + overlayOffset + Type7.PositionFramesOffset)
                                {
                                    OverlayRotations.Add(CacheContext.Deserializer.Deserialize<ModelAnimationTagResource.GroupMember.RotationFrame>(dataContext));
                                    newResourceGroupStream.Write(OverlayRotations[OverlayRotations.Count - 1].X);
                                    newResourceGroupStream.Write(OverlayRotations[OverlayRotations.Count - 1].Y);
                                    newResourceGroupStream.Write(OverlayRotations[OverlayRotations.Count - 1].Z);
                                    newResourceGroupStream.Write(OverlayRotations[OverlayRotations.Count - 1].W);
                                }

                                while (reader.BaseStream.Position < memberOffset + overlayOffset + Type7.SpecularFramesOffset)
                                {
                                    OverlayPositions.Add(CacheContext.Deserializer.Deserialize<ModelAnimationTagResource.GroupMember.PositionFrame>(dataContext));
                                    newResourceGroupStream.Write(OverlayPositions[OverlayPositions.Count - 1].X);
                                    newResourceGroupStream.Write(OverlayPositions[OverlayPositions.Count - 1].Y);
                                    newResourceGroupStream.Write(OverlayPositions[OverlayPositions.Count - 1].Z);
                                }

                                while (reader.BaseStream.Position < footerOffset)
                                {
                                    OverlaySpeculars.Add(CacheContext.Deserializer.Deserialize<ModelAnimationTagResource.GroupMember.SpecularFrame>(dataContext));
                                    newResourceGroupStream.Write(OverlaySpeculars[OverlaySpeculars.Count - 1].X);
                                }
                                #endregion
                                break;
                            #endregion
                            #region Type 8
                            case ModelAnimationTagResource.GroupMemberAnimationType.Type8:
                                var Type8 = CacheContext.Deserializer.Deserialize<ModelAnimationTagResource.GroupMember.AnimationHeaderType8>(dataContext);

                                newResourceGroupStream.Write((sbyte)Type8.HeaderStructType_);
                                newResourceGroupStream.Write((sbyte)Type8.RotationNodeCount);
                                newResourceGroupStream.Write((sbyte)Type8.PositionNodeCount);
                                newResourceGroupStream.Write((sbyte)Type8.SpecularNodeCount);
                                newResourceGroupStream.Write((uint)Type8.Unknown0);
                                newResourceGroupStream.Write((uint)Type8.Unknown1);
                                newResourceGroupStream.Write((uint)Type8.PositionFramesOffset);
                                newResourceGroupStream.Write((uint)Type8.SpecularFramesOffset);
                                newResourceGroupStream.Write((uint)Type8.FrameCountPerNode);
                                newResourceGroupStream.Write((uint)Type8.Unknown2);
                                newResourceGroupStream.Write((uint)Type8.Unknown3);

                                #region Type8 Animated Frames
                                List<ModelAnimationTagResource.GroupMember.RotationFrameFloat> OverlayRotationsFloat = new List<ModelAnimationTagResource.GroupMember.RotationFrameFloat>();
                                OverlayPositions = new List<ModelAnimationTagResource.GroupMember.PositionFrame>();
                                OverlaySpeculars = new List<ModelAnimationTagResource.GroupMember.SpecularFrame>();

                                for (int nodeIndex = 0; nodeIndex < Type8.RotationNodeCount; nodeIndex++)
                                {
                                    var rotationFrames = new List<ModelAnimationTagResource.GroupMember.RotationFrame>();
                                    for (int frameIndex = 0; frameIndex < frameCount; frameIndex++)
                                    {
                                        OverlayRotationsFloat.Add(CacheContext.Deserializer.Deserialize<ModelAnimationTagResource.GroupMember.RotationFrameFloat>(dataContext));
                                        newResourceGroupStream.Write(OverlayRotationsFloat[OverlayRotationsFloat.Count - 1].X);
                                        newResourceGroupStream.Write(OverlayRotationsFloat[OverlayRotationsFloat.Count - 1].Y);
                                        newResourceGroupStream.Write(OverlayRotationsFloat[OverlayRotationsFloat.Count - 1].Z);
                                        newResourceGroupStream.Write(OverlayRotationsFloat[OverlayRotationsFloat.Count - 1].W);
                                    }
                                }

                                for (int nodeIndex = 0; nodeIndex < Type8.PositionNodeCount; nodeIndex++)
                                {
                                    var positionFrames = new List<ModelAnimationTagResource.GroupMember.PositionFrame>();
                                    for (int frameIndex = 0; frameIndex < frameCount; frameIndex++)
                                    {
                                        OverlayPositions.Add(CacheContext.Deserializer.Deserialize<ModelAnimationTagResource.GroupMember.PositionFrame>(dataContext));
                                        newResourceGroupStream.Write(OverlayPositions[OverlayPositions.Count - 1].X);
                                        newResourceGroupStream.Write(OverlayPositions[OverlayPositions.Count - 1].Y);
                                        newResourceGroupStream.Write(OverlayPositions[OverlayPositions.Count - 1].Z);
                                    }
                                }

                                for (int nodeIndex = 0; nodeIndex < Type8.SpecularNodeCount; nodeIndex++)
                                {
                                    var specularFrames = new List<ModelAnimationTagResource.GroupMember.SpecularFrame>();
                                    for (int frameIndex = 0; frameIndex < frameCount; frameIndex++)
                                    {
                                        OverlaySpeculars.Add(CacheContext.Deserializer.Deserialize<ModelAnimationTagResource.GroupMember.SpecularFrame>(dataContext));
                                        newResourceGroupStream.Write(OverlaySpeculars[OverlaySpeculars.Count - 1].X);
                                    }
                                }
                                #endregion
                                break;
                                #endregion
                        }

                        #region Footer main

                        var animation = blamJmad.Animations.Find(x =>
                        x.ResourceGroupIndex == resourceGroupIndex &
                        x.ResourceGroupMemberIndex == memberIndex);

                        reader.BaseStream.Position = memberOffset + overlayOffset + footerOffset;

                        try
                        {
                            // CHEAP
                            List<ModelAnimationTagResource.GroupMember.SpecularFrame> footer = new List<ModelAnimationTagResource.GroupMember.SpecularFrame>();

                            if (animation.Type == ModelAnimationGraph.FrameType.Base)
                            {
                                if (resourceGroups[resourceGroupIndex].GroupMembers[memberIndex].NodeCount > 31)
                                {
                                    footer.Add(CacheContext.Deserializer.Deserialize<ModelAnimationTagResource.GroupMember.SpecularFrame>(dataContext)); // static rot
                                    footer.Add(CacheContext.Deserializer.Deserialize<ModelAnimationTagResource.GroupMember.SpecularFrame>(dataContext)); // static rot

                                    footer.Add(CacheContext.Deserializer.Deserialize<ModelAnimationTagResource.GroupMember.SpecularFrame>(dataContext)); // static pos
                                    footer.Add(CacheContext.Deserializer.Deserialize<ModelAnimationTagResource.GroupMember.SpecularFrame>(dataContext)); // static pos

                                    footer.Add(CacheContext.Deserializer.Deserialize<ModelAnimationTagResource.GroupMember.SpecularFrame>(dataContext)); // static spec
                                    footer.Add(CacheContext.Deserializer.Deserialize<ModelAnimationTagResource.GroupMember.SpecularFrame>(dataContext)); // static spec

                                    footer.Add(CacheContext.Deserializer.Deserialize<ModelAnimationTagResource.GroupMember.SpecularFrame>(dataContext)); // anim rot
                                    footer.Add(CacheContext.Deserializer.Deserialize<ModelAnimationTagResource.GroupMember.SpecularFrame>(dataContext)); // anim rot

                                    footer.Add(CacheContext.Deserializer.Deserialize<ModelAnimationTagResource.GroupMember.SpecularFrame>(dataContext)); // anim pos
                                    footer.Add(CacheContext.Deserializer.Deserialize<ModelAnimationTagResource.GroupMember.SpecularFrame>(dataContext)); // anim pos

                                    footer.Add(CacheContext.Deserializer.Deserialize<ModelAnimationTagResource.GroupMember.SpecularFrame>(dataContext)); // anim spec
                                    footer.Add(CacheContext.Deserializer.Deserialize<ModelAnimationTagResource.GroupMember.SpecularFrame>(dataContext)); // anim spec
                                }
                                else
                                {
                                    footer.Add(CacheContext.Deserializer.Deserialize<ModelAnimationTagResource.GroupMember.SpecularFrame>(dataContext)); // static rot
                                    footer.Add(CacheContext.Deserializer.Deserialize<ModelAnimationTagResource.GroupMember.SpecularFrame>(dataContext)); // static pos
                                    footer.Add(CacheContext.Deserializer.Deserialize<ModelAnimationTagResource.GroupMember.SpecularFrame>(dataContext)); // static spec

                                    footer.Add(CacheContext.Deserializer.Deserialize<ModelAnimationTagResource.GroupMember.SpecularFrame>(dataContext)); // anim rot
                                    footer.Add(CacheContext.Deserializer.Deserialize<ModelAnimationTagResource.GroupMember.SpecularFrame>(dataContext)); // anim pos
                                    footer.Add(CacheContext.Deserializer.Deserialize<ModelAnimationTagResource.GroupMember.SpecularFrame>(dataContext)); // anim spec
                                }
                            }
                            else // Overlay animation, non Base.
                            {
                                if (resourceGroups[resourceGroupIndex].GroupMembers[memberIndex].NodeCount > 31)
                                {
                                    footer.Add(CacheContext.Deserializer.Deserialize<ModelAnimationTagResource.GroupMember.SpecularFrame>(dataContext)); // anim rot
                                    footer.Add(CacheContext.Deserializer.Deserialize<ModelAnimationTagResource.GroupMember.SpecularFrame>(dataContext)); // anim rot

                                    footer.Add(CacheContext.Deserializer.Deserialize<ModelAnimationTagResource.GroupMember.SpecularFrame>(dataContext)); // anim pos
                                    footer.Add(CacheContext.Deserializer.Deserialize<ModelAnimationTagResource.GroupMember.SpecularFrame>(dataContext)); // anim pos

                                    footer.Add(CacheContext.Deserializer.Deserialize<ModelAnimationTagResource.GroupMember.SpecularFrame>(dataContext)); // anim spec
                                    footer.Add(CacheContext.Deserializer.Deserialize<ModelAnimationTagResource.GroupMember.SpecularFrame>(dataContext)); // anim spec
                                }
                                else
                                {
                                    footer.Add(CacheContext.Deserializer.Deserialize<ModelAnimationTagResource.GroupMember.SpecularFrame>(dataContext)); // anim rot
                                    footer.Add(CacheContext.Deserializer.Deserialize<ModelAnimationTagResource.GroupMember.SpecularFrame>(dataContext)); // anim pos
                                    footer.Add(CacheContext.Deserializer.Deserialize<ModelAnimationTagResource.GroupMember.SpecularFrame>(dataContext)); // anim spec
                                }
                            }
                            foreach (var a in footer)
                            {
                                newResourceGroupStream.Write(a.X);
                            }
                            #endregion
                        }
                        catch (Exception e) { Console.WriteLine(e.Message); }

                        #region FrameInfoType DxDy or DxDyDyaw frames
                        List<ModelAnimationTagResource.GroupMember.FrameInfoDxDy> frameInfoDxDyFrames = new List<ModelAnimationTagResource.GroupMember.FrameInfoDxDy>();
                        List<ModelAnimationTagResource.GroupMember.FrameInfoDxDyDyaw> frameInfoDxDyDyawFrames = new List<ModelAnimationTagResource.GroupMember.FrameInfoDxDyDyaw>();

                        if (animation.FrameInfoType == ModelAnimationGraph.FrameMovementDataType.DxDy)
                        {
                            for (int frameIndex = 0; frameIndex < frameCount; frameIndex++)
                            {
                                frameInfoDxDyFrames.Add(CacheContext.Deserializer.Deserialize<ModelAnimationTagResource.GroupMember.FrameInfoDxDy>(dataContext));
                            }

                            if (headerGlobal.PositionNodeCount > 1)
                            {
                                for (int frameIndex = 0; frameIndex < frameCount; frameIndex++)
                                {
                                    frameInfoDxDyDyawFrames.Add(CacheContext.Deserializer.Deserialize<ModelAnimationTagResource.GroupMember.FrameInfoDxDyDyaw>(dataContext));
                                }
                            }
                        }
                        else if (animation.FrameInfoType == ModelAnimationGraph.FrameMovementDataType.DxDyDyaw)
                        {
                            frameInfoDxDyDyawFrames = new List<ModelAnimationTagResource.GroupMember.FrameInfoDxDyDyaw>();

                            for (int frameIndex = 0; frameIndex < frameCount; frameIndex++)
                            {
                                frameInfoDxDyDyawFrames.Add(CacheContext.Deserializer.Deserialize<ModelAnimationTagResource.GroupMember.FrameInfoDxDyDyaw>(dataContext));
                            }
                        }
                        foreach (var a in frameInfoDxDyFrames)
                        {
                            newResourceGroupStream.Write(a.X);
                            newResourceGroupStream.Write(a.Y);
                        }
                        foreach (var a in frameInfoDxDyDyawFrames)
                        {
                            newResourceGroupStream.Write(a.X);
                            newResourceGroupStream.Write(a.Y);
                            newResourceGroupStream.Write(a.Z);
                        }
                        #endregion

                        #region Padding
                        try
                        {
                            while (reader.BaseStream.Position % 0x10 != 0x0)
                            {
                                reader.ReadUInt32();
                                newResourceGroupStream.Write(0x00000000);
                            }
                        }
                        catch (Exception) { }
                        #endregion
                    }

                    // import new 
                    newResourceGroupStream.BaseStream.Position = 0;
                    using (newResourceGroupStream)
                    {
                        InjectAnimation(
                            CacheContext.Serializer, CacheContext.Deserializer,
                            blamJmad, resourceGroupIndex,
                            newStream,
                            resourceGroups[resourceGroupIndex],
                            resourcesFixups);
                    }
                    Console.Write("."); // Loading bar.
                }

                // There's an extra 0x4 bytes at the end for some reason which need to be removed
                var def = new byte[blamJmad.ResourceGroups[resourceGroupIndex].Resource.DefinitionData.Length - 0x4];
                int j = 0;
                foreach (byte b in def)
                {
                    def[j] = blamJmad.ResourceGroups[resourceGroupIndex].Resource.DefinitionData[j];
                    j++;
                }

                blamJmad.ResourceGroups[resourceGroupIndex].Resource.DefinitionData = def;
            }

            #region Serialize and add resource
            Console.WriteLine("");
            Console.WriteLine("Serializing...");
            // serialize changes in tagfields and tagblocks
            using (var cacheStream = CacheContext.OpenTagCacheReadWrite())
            {
                var context = new TagSerializationContext(cacheStream, CacheContext, edTag);
                CacheContext.Serializer.Serialize(context, blamJmad);
            }

            if (CacheContext.StringIdCache.Strings.Count != initialStringIDCount)
            {
                Console.Write("Saving string_ids...");

                using (var stringIdStream = CacheContext.StringIdCacheFile.Open(FileMode.Open, FileAccess.ReadWrite))
                    CacheContext.StringIdCache.Save(stringIdStream);

                Console.WriteLine("Done.");
            }

            Console.WriteLine("Done.");
            #endregion

            return true;
        }

        public void InjectAnimation(TagSerializer serializer, TagDeserializer deserializer, ModelAnimationGraph animation, int groupIndex, Stream animationStream, ModelAnimationTagResource resourceGroups, List<BlamCore.Cache.cache_file_resource_gestalt.RawEntry> resourcesFixups)
        {
            ResourceSerializationContext resourceContext;
            ModelAnimationTagResource definition;

            var resource = new ResourceReference
            {
                DefinitionFixups = new List<ResourceDefinitionFixup>(),
                D3DObjectFixups = new List<D3DObjectFixup>(),
                Type = 4,
                Unknown68 = 1,
                OldLocationFlags = OldResourceLocationFlags.InResources
            };

            definition = new ModelAnimationTagResource();

            definition.GroupMembers = new List<ModelAnimationTagResource.GroupMember>();

            // foreach (var a in resourceGroups.GroupMembers)
            for (int i = 0; i < resourceGroups.GroupMembers.Count; i++)
            {
                // int i = resourceGroups.GroupMembers.IndexOf(a);
                definition.GroupMembers.Add(new ModelAnimationTagResource.GroupMember());
                var dataSize = (int)(animationStream.Length - animationStream.Position);

                definition.GroupMembers[i].AnimationData = new ResourceDataReference(dataSize, new ResourceAddress(ResourceAddressType.Resource, 0));
                definition.GroupMembers[i].AnimationData.Size = resourceGroups.GroupMembers[i].AnimationData.Size;
                definition.GroupMembers[i].Checksum = resourceGroups.GroupMembers[i].Checksum;
                definition.GroupMembers[i].FrameCount = resourceGroups.GroupMembers[i].FrameCount;
                definition.GroupMembers[i].NodeCount = resourceGroups.GroupMembers[i].NodeCount;
                definition.GroupMembers[i].MovementDataType = (ModelAnimationTagResource.GroupMemberMovementDataType)resourceGroups.GroupMembers[i].MovementDataType; // weird that sbyte doesn't work
                definition.GroupMembers[i].BaseHeader = (ModelAnimationTagResource.GroupMemberHeaderType)resourceGroups.GroupMembers[i].BaseHeader;
                definition.GroupMembers[i].OverlayHeader = (ModelAnimationTagResource.GroupMemberHeaderType)resourceGroups.GroupMembers[i].OverlayHeader;

                definition.GroupMembers[i].Unknown1 = resourceGroups.GroupMembers[i].Unknown1;
                definition.GroupMembers[i].Unknown2 = resourceGroups.GroupMembers[i].Unknown2;
                definition.GroupMembers[i].OverlayOffset = resourceGroups.GroupMembers[i].OverlayOffset;
                definition.GroupMembers[i].Unknown3 = resourceGroups.GroupMembers[i].Unknown3;
                definition.GroupMembers[i].Unknown4 = resourceGroups.GroupMembers[i].Unknown4;
                definition.GroupMembers[i].FlagsOffset = resourceGroups.GroupMembers[i].FlagsOffset;

                definition.GroupMembers[i].AnimationData.Address = new ResourceAddress(ResourceAddressType.Resource, (int)resourcesFixups[groupIndex].Fixups[i].Offset);
            }

            CacheContext.AddResource(resource, ResourceLocation.Resources, animationStream);

            animation.ResourceGroups[groupIndex].Resource = resource;

            resourceContext = new ResourceSerializationContext(resource);

            serializer.Serialize(resourceContext, definition);
        }
    }
}
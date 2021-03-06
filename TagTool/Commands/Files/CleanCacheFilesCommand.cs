﻿using System;
using System.Collections.Generic;
using System.IO;
using BlamCore.Cache.HaloOnline;
using BlamCore.Common;
using BlamCore.Serialization;
using BlamCore.TagDefinitions;

namespace TagTool.Commands.Files
{
    class CleanCacheFilesCommand : Command
    {
        public GameCacheContext CacheContext { get; }

        private HashSet<int> AudioResourceIndices { get; } = new HashSet<int>();
        private HashSet<int> TexturesResourceIndices { get; } = new HashSet<int>();
        private HashSet<int> TexturesBResourceIndices { get; } = new HashSet<int>();
        private HashSet<int> VideoResourceIndices { get; } = new HashSet<int>();

        private HashSet<int> ResourcesResourceIndices { get; } = new HashSet<int>
        {
            0x169, 0x16A, 0x16B, 0x170, 0x171,
            0x2AF, 0x2B0, 0x38E, 0x540, 0x541,
            0x542, 0x543, 0x544, 0x546, 0x549,
            0x54D, 0x54F, 0x550, 0x55B, 0x56A,
            0x580, 0x587, 0x6B9, 0x6ED, 0x6EE
        };

        public CleanCacheFilesCommand(GameCacheContext cacheContext)
            : base(CommandFlags.None,

                  "CleanCacheFiles",
                  "Nulls and removes unused tags and resources from cache.",

                  "CleanCacheFiles",

                  "Nulls and removes unused tags and resources from cache.")
        {
            CacheContext = cacheContext;
        }

        private void LoadTagDependencies(int index, ref HashSet<int> tags)
        {
            var queue = new List<int> { index };

            while (queue.Count != 0)
            {
                var nextQueue = new List<int>();

                foreach (var entry in queue)
                {
                    if (!tags.Contains(entry))
                    {
                        if (CacheContext.TagCache.Index[entry] == null)
                            continue;

                        tags.Add(entry);

                        foreach (var dependency in CacheContext.TagCache.Index[entry].Dependencies)
                            if (!nextQueue.Contains(dependency))
                                nextQueue.Add(dependency);
                    }
                }

                queue = nextQueue;
            }
        }

        private void AddResource(ResourceReference resourceReference)
        {
            var index = resourceReference.Index;

            switch (resourceReference.GetLocation())
            {
                case ResourceLocation.Audio:
                    AudioResourceIndices.Add(index);
                    break;

                case ResourceLocation.Resources:
                    ResourcesResourceIndices.Add(index);
                    break;

                case ResourceLocation.Textures:
                    TexturesResourceIndices.Add(index);
                    break;

                case ResourceLocation.TexturesB:
                    TexturesBResourceIndices.Add(index);
                    break;

                case ResourceLocation.Video:
                    VideoResourceIndices.Add(index);
                    break;

                default:
                    break;
            }
        }

        private void CleanGlobals(Stream stream)
        {
            var matgTag = CacheContext.TagCache.Index.FindFirstInGroup("matg");
            var matgContext = new TagSerializationContext(stream, CacheContext, matgTag);
            var matgDefinition = CacheContext.Deserializer.Deserialize<Globals>(matgContext);

            var playerControl = matgDefinition.PlayerControl[0];

            playerControl.MagnetismFriction = 0.6f;
            playerControl.MagnetismAdhesion = 0.6f;
            playerControl.InconsequentialTargetScale = 0.35f;

            playerControl.SecondsToStart = 4;
            playerControl.SecondsToFullSpeed = 0.8f;
            playerControl.DecayRate = 2;
            playerControl.FullSpeedMultiplier = 1.0f;
            playerControl.PeggedMagnitude = 0.9f;
            playerControl.PeggedAngularThreshold = 10;
            playerControl.Unknown = 1083179008;
            playerControl.Unknown2 = 1051931443;

            var playerInformation = matgDefinition.PlayerInformation[0];

            playerInformation.RunForward = 2.25f;
            playerInformation.RunBackward = 2;
            playerInformation.RunSideways = 2;

            CacheContext.Serializer.Serialize(matgContext, matgDefinition);
        }

        private void CleanMultiplayerGlobals(Stream stream)
        {
            var mulgTag = CacheContext.TagCache.Index.FindFirstInGroup("mulg");
            var mulgContext = new TagSerializationContext(stream, CacheContext, mulgTag);
            var mulgDefinition = CacheContext.Deserializer.Deserialize<MultiplayerGlobals>(mulgContext);

            #region Universal SpartanArmorCustomization
            mulgDefinition.Universal[0].SpartanArmorCustomization = new List<MultiplayerGlobals.UniversalBlock.SpartanArmorCustomizationBlock>
            {
                new MultiplayerGlobals.UniversalBlock.SpartanArmorCustomizationBlock
                {
                    ArmorObjectRegion = CacheContext.GetStringId("helmet"),
                    BipedRegion = CacheContext.GetStringId("helmet"),
                    Permutations = new List<MultiplayerGlobals.UniversalBlock.SpartanArmorCustomizationBlock.Permutation>
                    {
                        new MultiplayerGlobals.UniversalBlock.SpartanArmorCustomizationBlock.Permutation
                        {
                            Name = CacheContext.GetStringId("air_assault"),
                            ThirdPersonArmorObject = CacheContext.GetTag(0x1530),
                            FirstPersonArmorModel = null,
                            Unknown = -1,
                            Unknown2 = 0,
                            ParentAttachMarker = StringId.Null,
                            ChildAttachMarker = StringId.Null
                        },
                    }
                },
                new MultiplayerGlobals.UniversalBlock.SpartanArmorCustomizationBlock
                {
                    ArmorObjectRegion = CacheContext.GetStringId("chest"),
                    BipedRegion = CacheContext.GetStringId("chest"),
                    Permutations = new List<MultiplayerGlobals.UniversalBlock.SpartanArmorCustomizationBlock.Permutation>
                    {
                        new MultiplayerGlobals.UniversalBlock.SpartanArmorCustomizationBlock.Permutation
                        {
                            Name = CacheContext.GetStringId("air_assault"),
                            ThirdPersonArmorObject = CacheContext.GetTag(0x1530),
                            FirstPersonArmorModel = null,
                            Unknown = -1,
                            Unknown2 = 0,
                            ParentAttachMarker = StringId.Null,
                            ChildAttachMarker = StringId.Null
                        },
                    }
                },
                new MultiplayerGlobals.UniversalBlock.SpartanArmorCustomizationBlock
                {
                    ArmorObjectRegion = CacheContext.GetStringId("shoulders"),
                    BipedRegion = CacheContext.GetStringId("shoulders"),
                    Permutations = new List<MultiplayerGlobals.UniversalBlock.SpartanArmorCustomizationBlock.Permutation>
                    {
                        new MultiplayerGlobals.UniversalBlock.SpartanArmorCustomizationBlock.Permutation
                        {
                            Name = CacheContext.GetStringId("air_assault"),
                            ThirdPersonArmorObject = CacheContext.GetTag(0x1530),
                            FirstPersonArmorModel = null,
                            Unknown = -1,
                            Unknown2 = 0,
                            ParentAttachMarker = StringId.Null,
                            ChildAttachMarker = StringId.Null
                        },
                    }
                },
                new MultiplayerGlobals.UniversalBlock.SpartanArmorCustomizationBlock
                {
                    ArmorObjectRegion = CacheContext.GetStringId("arms"),
                    BipedRegion = CacheContext.GetStringId("arms"),
                    Permutations = new List<MultiplayerGlobals.UniversalBlock.SpartanArmorCustomizationBlock.Permutation>
                    {
                        new MultiplayerGlobals.UniversalBlock.SpartanArmorCustomizationBlock.Permutation
                        {
                            Name = CacheContext.GetStringId("air_assault"),
                            ThirdPersonArmorObject = CacheContext.GetTag(0x1530),
                            FirstPersonArmorModel = CacheContext.GetTag(0x155D),
                            Unknown = -1,
                            Unknown2 = 0,
                            ParentAttachMarker = StringId.Null,
                            ChildAttachMarker = StringId.Null
                        },
                    }
                },
                new MultiplayerGlobals.UniversalBlock.SpartanArmorCustomizationBlock
                {
                    ArmorObjectRegion = CacheContext.GetStringId("legs"),
                    BipedRegion = CacheContext.GetStringId("legs"),
                    Permutations = new List<MultiplayerGlobals.UniversalBlock.SpartanArmorCustomizationBlock.Permutation>
                    {
                        new MultiplayerGlobals.UniversalBlock.SpartanArmorCustomizationBlock.Permutation
                        {
                            Name = CacheContext.GetStringId("air_assault"),
                            ThirdPersonArmorObject = CacheContext.GetTag(0x1530),
                            FirstPersonArmorModel = null,
                            Unknown = -1,
                            Unknown2 = 0,
                            ParentAttachMarker = StringId.Null,
                            ChildAttachMarker = StringId.Null
                        },
                    }
                },
                new MultiplayerGlobals.UniversalBlock.SpartanArmorCustomizationBlock
                {
                    ArmorObjectRegion = CacheContext.GetStringId("acc"),
                    BipedRegion = CacheContext.GetStringId("acc"),
                    Permutations = new List<MultiplayerGlobals.UniversalBlock.SpartanArmorCustomizationBlock.Permutation>
                    {
                        new MultiplayerGlobals.UniversalBlock.SpartanArmorCustomizationBlock.Permutation
                        {
                            Name = StringId.Null,
                            ThirdPersonArmorObject = null,
                            FirstPersonArmorModel = null,
                            Unknown = -1,
                            Unknown2 = 0,
                            ParentAttachMarker = StringId.Null,
                            ChildAttachMarker = StringId.Null
                        },
                    }
                },
                new MultiplayerGlobals.UniversalBlock.SpartanArmorCustomizationBlock
                {
                    ArmorObjectRegion = CacheContext.GetStringId("pelvis"),
                    BipedRegion = CacheContext.GetStringId("pelvis"),
                    Permutations = new List<MultiplayerGlobals.UniversalBlock.SpartanArmorCustomizationBlock.Permutation>
                    {
                        new MultiplayerGlobals.UniversalBlock.SpartanArmorCustomizationBlock.Permutation
                        {
                            Name = CacheContext.GetStringId("base"),
                            ThirdPersonArmorObject = CacheContext.GetTag(0x155F),
                            FirstPersonArmorModel = null,
                            Unknown = -1,
                            Unknown2 = 0,
                            ParentAttachMarker = StringId.Null,
                            ChildAttachMarker = StringId.Null
                        },
                    }
                },
            };
            #endregion

            #region Universal GameVariantWeapons
            mulgDefinition.Universal[0].GameVariantWeapons = new List<MultiplayerGlobals.UniversalBlock.GameVariantWeapon>
            {
                new MultiplayerGlobals.UniversalBlock.GameVariantWeapon
                {
                    Name = CacheContext.GetStringId("battle_rifle"),
                    RandomChance = 0.1f,
                    Weapon = CacheContext.TagCache.Index[0x157C]
                },
                new MultiplayerGlobals.UniversalBlock.GameVariantWeapon
                {
                    Name = CacheContext.GetStringId("assault_rifle"),
                    RandomChance = 0.1f,
                    Weapon = CacheContext.TagCache.Index[0x151E]
                },
                new MultiplayerGlobals.UniversalBlock.GameVariantWeapon
                {
                    Name = CacheContext.GetStringId("plasma_pistol"),
                    RandomChance = 0.1f,
                    Weapon = CacheContext.TagCache.Index[0x14F7]
                },
                new MultiplayerGlobals.UniversalBlock.GameVariantWeapon
                {
                    Name = CacheContext.GetStringId("spike_rifle"),
                    RandomChance = 0.1f,
                    Weapon = CacheContext.TagCache.Index[0x1500]
                },
                new MultiplayerGlobals.UniversalBlock.GameVariantWeapon
                {
                    Name = CacheContext.GetStringId("smg"),
                    RandomChance = 0.1f,
                    Weapon = CacheContext.TagCache.Index[0x157D]
                },
                new MultiplayerGlobals.UniversalBlock.GameVariantWeapon
                {
                    Name = CacheContext.GetStringId("carbine"),
                    RandomChance = 0.1f,
                    Weapon = CacheContext.TagCache.Index[0x14FE]
                },
                new MultiplayerGlobals.UniversalBlock.GameVariantWeapon
                {
                    Name = CacheContext.GetStringId("energy_sword"),
                    RandomChance = 0.1f,
                    Weapon = CacheContext.TagCache.Index[0x159E]
                },
                new MultiplayerGlobals.UniversalBlock.GameVariantWeapon
                {
                    Name = CacheContext.GetStringId("magnum"),
                    RandomChance = 0.1f,
                    Weapon = CacheContext.TagCache.Index[0x157E]
                },
                new MultiplayerGlobals.UniversalBlock.GameVariantWeapon
                {
                    Name = CacheContext.GetStringId("needler"),
                    RandomChance = 0.1f,
                    Weapon = CacheContext.TagCache.Index[0x14F8]
                },
                new MultiplayerGlobals.UniversalBlock.GameVariantWeapon
                {
                    Name = CacheContext.GetStringId("plasma_rifle"),
                    RandomChance = 0.1f,
                    Weapon = CacheContext.TagCache.Index[0x1525]
                },
                new MultiplayerGlobals.UniversalBlock.GameVariantWeapon
                {
                    Name = CacheContext.GetStringId("rocket_launcher"),
                    RandomChance = 0.1f,
                    Weapon = CacheContext.TagCache.Index[0x15B3]
                },
                new MultiplayerGlobals.UniversalBlock.GameVariantWeapon
                {
                    Name = CacheContext.GetStringId("shotgun"),
                    RandomChance = 0.1f,
                    Weapon = CacheContext.TagCache.Index[0x1A45]
                },
                new MultiplayerGlobals.UniversalBlock.GameVariantWeapon
                {
                    Name = CacheContext.GetStringId("sniper_rifle"),
                    RandomChance = 0.1f,
                    Weapon = CacheContext.TagCache.Index[0x15B1]
                },
                new MultiplayerGlobals.UniversalBlock.GameVariantWeapon
                {
                    Name = CacheContext.GetStringId("brute_shot"),
                    RandomChance = 0.1f,
                    Weapon = CacheContext.TagCache.Index[0x14FF]
                },
                new MultiplayerGlobals.UniversalBlock.GameVariantWeapon
                {
                    Name = CacheContext.GetStringId("unarmed"),
                    RandomChance = 0,
                    Weapon = CacheContext.TagCache.Index[0x157F]
                },
                new MultiplayerGlobals.UniversalBlock.GameVariantWeapon
                {
                    Name = CacheContext.GetStringId("beam_rifle"),
                    RandomChance = 0.1f,
                    Weapon = CacheContext.TagCache.Index[0x1509]
                },
                new MultiplayerGlobals.UniversalBlock.GameVariantWeapon
                {
                    Name = CacheContext.GetStringId("spartan_laser"),
                    RandomChance = 0.1f,
                    Weapon = CacheContext.TagCache.Index[0x15B2]
                },
                new MultiplayerGlobals.UniversalBlock.GameVariantWeapon
                {
                    Name = CacheContext.GetStringId("none"),
                    RandomChance = 0,
                    Weapon = null
                },
                new MultiplayerGlobals.UniversalBlock.GameVariantWeapon
                {
                    Name = CacheContext.GetStringId("gravity_hammer"),
                    RandomChance = 0.1f,
                    Weapon = CacheContext.TagCache.Index[0x150C]
                },
                new MultiplayerGlobals.UniversalBlock.GameVariantWeapon
                {
                    Name = CacheContext.GetStringId("excavator"),
                    RandomChance = 0.1f,
                    Weapon = CacheContext.TagCache.Index[0x1504]
                },
                new MultiplayerGlobals.UniversalBlock.GameVariantWeapon
                {
                    Name = CacheContext.GetStringId("flamethrower"),
                    RandomChance = 0,
                    Weapon = CacheContext.TagCache.Index[0x1A55]
                },
                new MultiplayerGlobals.UniversalBlock.GameVariantWeapon
                {
                    Name = CacheContext.GetStringId("missile_pod"),
                    RandomChance = 0.1f,
                    Weapon = CacheContext.TagCache.Index[0x1A54]
                }
            };
            #endregion
            
            #region Runtime Weapons
            mulgDefinition.Runtime[0].MultiplayerConstants[0].Weapons = new List<MultiplayerGlobals.RuntimeBlock.MultiplayerConstant.Weapon>
            {
                new MultiplayerGlobals.RuntimeBlock.MultiplayerConstant.Weapon
                {
                    // battle_rifle
                    Weapon2 = CacheContext.TagCache.Index[0x157C],
                    Unknown1 = 5.0f,
                    Unknown2 = 15.0f,
                    Unknown3 = 5.0f,
                    Unknown4 = -10.0f
                },
                new MultiplayerGlobals.RuntimeBlock.MultiplayerConstant.Weapon
                {
                    // carbine
                    Weapon2 = CacheContext.TagCache.Index[0x14FE],
                    Unknown1 = 5.0f,
                    Unknown2 = 15.0f,
                    Unknown3 = 5.0f,
                    Unknown4 = -10.0f
                },
                new MultiplayerGlobals.RuntimeBlock.MultiplayerConstant.Weapon
                {
                    // sniper_rifle
                    Weapon2 = CacheContext.TagCache.Index[0x15B1],
                    Unknown1 = 5.0f,
                    Unknown2 = 15.0f,
                    Unknown3 = 5.0f,
                    Unknown4 = -10.0f
                },
                new MultiplayerGlobals.RuntimeBlock.MultiplayerConstant.Weapon
                {
                    // beam_rifle
                    Weapon2 = CacheContext.TagCache.Index[0x1509],
                    Unknown1 = 5.0f,
                    Unknown2 = 15.0f,
                    Unknown3 = 5.0f,
                    Unknown4 = -10.0f
                },
                new MultiplayerGlobals.RuntimeBlock.MultiplayerConstant.Weapon
                {
                    // spartan_laster
                    Weapon2 = CacheContext.TagCache.Index[0x15B2],
                    Unknown1 = 5.0f,
                    Unknown2 = 15.0f,
                    Unknown3 = 5.0f,
                    Unknown4 = -10.0f
                },
                new MultiplayerGlobals.RuntimeBlock.MultiplayerConstant.Weapon
                {
                    // rocket_launcher
                    Weapon2 = CacheContext.TagCache.Index[0x15B3],
                    Unknown1 = 5.0f,
                    Unknown2 = 15.0f,
                    Unknown3 = 5.0f,
                    Unknown4 = -10.0f
                },
                new MultiplayerGlobals.RuntimeBlock.MultiplayerConstant.Weapon
                {
                    // chaingun_turret
                    Weapon2 = CacheContext.TagCache.Index[0x15B4],
                    Unknown1 = 5.0f,
                    Unknown2 = 15.0f,
                    Unknown3 = 5.0f,
                    Unknown4 = -10.0f
                },
                new MultiplayerGlobals.RuntimeBlock.MultiplayerConstant.Weapon
                {
                    // machinegun_turret
                    Weapon2 = CacheContext.TagCache.Index[0x15B5],
                    Unknown1 = 5.0f,
                    Unknown2 = 15.0f,
                    Unknown3 = 5.0f,
                    Unknown4 = -10.0f
                },
                new MultiplayerGlobals.RuntimeBlock.MultiplayerConstant.Weapon
                {
                    // machinegun_turret_integrated
                    Weapon2 = CacheContext.TagCache.Index[0x15B6],
                    Unknown1 = 5.0f,
                    Unknown2 = 15.0f,
                    Unknown3 = 5.0f,
                    Unknown4 = -10.0f
                },
                new MultiplayerGlobals.RuntimeBlock.MultiplayerConstant.Weapon
                {
                    // plasma_cannon
                    Weapon2 = CacheContext.TagCache.Index[0x150E],
                    Unknown1 = 5.0f,
                    Unknown2 = 15.0f,
                    Unknown3 = 5.0f,
                    Unknown4 = -10.0f
                },
                new MultiplayerGlobals.RuntimeBlock.MultiplayerConstant.Weapon
                {
                    // plasma_cannon_integrated
                    Weapon2 = CacheContext.TagCache.Index[0x15B7],
                    Unknown1 = 5.0f,
                    Unknown2 = 15.0f,
                    Unknown3 = 5.0f,
                    Unknown4 = -10.0f
                },
                new MultiplayerGlobals.RuntimeBlock.MultiplayerConstant.Weapon
                {
                    // needler
                    Weapon2 = CacheContext.TagCache.Index[0x14F8],
                    Unknown1 = 5.0f,
                    Unknown2 = 15.0f,
                    Unknown3 = 5.0f,
                    Unknown4 = -10.0f
                },
                new MultiplayerGlobals.RuntimeBlock.MultiplayerConstant.Weapon
                {
                    // flak_cannon
                    Weapon2 = CacheContext.TagCache.Index[0x14F9],
                    Unknown1 = 5.0f,
                    Unknown2 = 15.0f,
                    Unknown3 = 5.0f,
                    Unknown4 = -10.0f
                },
                new MultiplayerGlobals.RuntimeBlock.MultiplayerConstant.Weapon
                {
                    // gauss_turret
                    Weapon2 = CacheContext.TagCache.Index[0x15B8],
                    Unknown1 = 5.0f,
                    Unknown2 = 15.0f,
                    Unknown3 = 5.0f,
                    Unknown4 = -10.0f
                },
                new MultiplayerGlobals.RuntimeBlock.MultiplayerConstant.Weapon
                {
                    // anti_infantry
                    Weapon2 = CacheContext.TagCache.Index[0x15B9],
                    Unknown1 = 5.0f,
                    Unknown2 = 15.0f,
                    Unknown3 = 5.0f,
                    Unknown4 = -10.0f
                },
                new MultiplayerGlobals.RuntimeBlock.MultiplayerConstant.Weapon
                {
                    // behemoth_chaingun_turret
                    Weapon2 = CacheContext.TagCache.Index[0x15BA],
                    Unknown1 = 5.0f,
                    Unknown2 = 15.0f,
                    Unknown3 = 5.0f,
                    Unknown4 = -10.0f
                }
            };
            #endregion

            #region Universal Equipment
            mulgDefinition.Universal[0].Equipment = new List<MultiplayerGlobals.UniversalBlock.EquipmentBlock>
            {
                new MultiplayerGlobals.UniversalBlock.EquipmentBlock
                {
                    Name = CacheContext.GetStringId("empty"),
                    Equipment = null,
                    Unknown = 0,
                    Unknown2 = 0
                }
            };
            #endregion

            #region Runtime Equipment
            mulgDefinition.Runtime[0].MultiplayerConstants[0].Equipment = null;
            #endregion

            #region Universal GameVariantVehicles
            mulgDefinition.Universal[0].GameVariantVehicles = new List<MultiplayerGlobals.UniversalBlock.GameVariantVehicle>
            {
                new MultiplayerGlobals.UniversalBlock.GameVariantVehicle
                {
                    Name = CacheContext.GetStringId("warthog"),
                    Vehicle = CacheContext.TagCache.Index[0x151F]
                },
                new MultiplayerGlobals.UniversalBlock.GameVariantVehicle
                {
                    Name = CacheContext.GetStringId("ghost"),
                    Vehicle = CacheContext.TagCache.Index[0x1517]
                },
                new MultiplayerGlobals.UniversalBlock.GameVariantVehicle
                {
                    Name = CacheContext.GetStringId("scorpion"),
                    Vehicle = CacheContext.TagCache.Index[0x1520]
                },
                new MultiplayerGlobals.UniversalBlock.GameVariantVehicle
                {
                    Name = CacheContext.GetStringId("wraith"),
                    Vehicle = CacheContext.TagCache.Index[0x1519]
                },
                new MultiplayerGlobals.UniversalBlock.GameVariantVehicle
                {
                    Name = CacheContext.GetStringId("banshee"),
                    Vehicle = CacheContext.TagCache.Index[0x151A]
                },
                new MultiplayerGlobals.UniversalBlock.GameVariantVehicle
                {
                    Name = CacheContext.GetStringId("mongoose"),
                    Vehicle = CacheContext.TagCache.Index[0x1596]
                },
                new MultiplayerGlobals.UniversalBlock.GameVariantVehicle
                {
                    Name = CacheContext.GetStringId("chopper"),
                    Vehicle = CacheContext.TagCache.Index[0x1518]
                },
                new MultiplayerGlobals.UniversalBlock.GameVariantVehicle
                {
                    Name = CacheContext.GetStringId("mauler"),
                    Vehicle = null
                },
                new MultiplayerGlobals.UniversalBlock.GameVariantVehicle
                {
                    Name = CacheContext.GetStringId("hornet"),
                    Vehicle = CacheContext.TagCache.Index[0x1598]
                }
            };
            #endregion

            #region Universal VehicleSets
            mulgDefinition.Universal[0].VehicleSets = new List<MultiplayerGlobals.UniversalBlock.VehicleSet>
            {
                new MultiplayerGlobals.UniversalBlock.VehicleSet
                {
                    Name = CacheContext.GetStringId("default"),
                    Substitutions = new List<MultiplayerGlobals.UniversalBlock.VehicleSet.Substitution>()
                },
                new MultiplayerGlobals.UniversalBlock.VehicleSet
                {
                    Name = CacheContext.GetStringId("no_vehicles"),
                    #region Substitutions
                    Substitutions = new List<MultiplayerGlobals.UniversalBlock.VehicleSet.Substitution>
                    {
                        new MultiplayerGlobals.UniversalBlock.VehicleSet.Substitution
                        {
                            OriginalVehicle = CacheContext.GetStringId("warthog"),
                            SubstitutedVehicle = StringId.Null
                        },
                        new MultiplayerGlobals.UniversalBlock.VehicleSet.Substitution
                        {
                            OriginalVehicle = CacheContext.GetStringId("ghost"),
                            SubstitutedVehicle = StringId.Null
                        },
                        new MultiplayerGlobals.UniversalBlock.VehicleSet.Substitution
                        {
                            OriginalVehicle = CacheContext.GetStringId("scorpion"),
                            SubstitutedVehicle = StringId.Null
                        },
                        new MultiplayerGlobals.UniversalBlock.VehicleSet.Substitution
                        {
                            OriginalVehicle = CacheContext.GetStringId("wraith"),
                            SubstitutedVehicle = StringId.Null
                        },
                        new MultiplayerGlobals.UniversalBlock.VehicleSet.Substitution
                        {
                            OriginalVehicle = CacheContext.GetStringId("mongoose"),
                            SubstitutedVehicle = StringId.Null
                        },
                        new MultiplayerGlobals.UniversalBlock.VehicleSet.Substitution
                        {
                            OriginalVehicle = CacheContext.GetStringId("banshee"),
                            SubstitutedVehicle = StringId.Null
                        },
                        new MultiplayerGlobals.UniversalBlock.VehicleSet.Substitution
                        {
                            OriginalVehicle = CacheContext.GetStringId("chopper"),
                            SubstitutedVehicle = StringId.Null
                        },
                        new MultiplayerGlobals.UniversalBlock.VehicleSet.Substitution
                        {
                            OriginalVehicle = CacheContext.GetStringId("mauler"),
                            SubstitutedVehicle = StringId.Null
                        },
                        new MultiplayerGlobals.UniversalBlock.VehicleSet.Substitution
                        {
                            OriginalVehicle = CacheContext.GetStringId("hornet"),
                            SubstitutedVehicle = StringId.Null
                        }
                    }
                    #endregion
                },
                new MultiplayerGlobals.UniversalBlock.VehicleSet
                {
                    Name = CacheContext.GetStringId("mongooses_only"),
                    #region Substitutions
                    Substitutions = new List<MultiplayerGlobals.UniversalBlock.VehicleSet.Substitution>
                    {
                        new MultiplayerGlobals.UniversalBlock.VehicleSet.Substitution
                        {
                            OriginalVehicle = CacheContext.GetStringId("warthog"),
                            SubstitutedVehicle = StringId.Null
                        },
                        new MultiplayerGlobals.UniversalBlock.VehicleSet.Substitution
                        {
                            OriginalVehicle = CacheContext.GetStringId("ghost"),
                            SubstitutedVehicle = CacheContext.GetStringId("mongoose")
                        },
                        new MultiplayerGlobals.UniversalBlock.VehicleSet.Substitution
                        {
                            OriginalVehicle = CacheContext.GetStringId("scorpion"),
                            SubstitutedVehicle = StringId.Null
                        },
                        new MultiplayerGlobals.UniversalBlock.VehicleSet.Substitution
                        {
                            OriginalVehicle = CacheContext.GetStringId("wraith"),
                            SubstitutedVehicle = StringId.Null
                        },
                        new MultiplayerGlobals.UniversalBlock.VehicleSet.Substitution
                        {
                            OriginalVehicle = CacheContext.GetStringId("banshee"),
                            SubstitutedVehicle = StringId.Null
                        },
                        new MultiplayerGlobals.UniversalBlock.VehicleSet.Substitution
                        {
                            OriginalVehicle = CacheContext.GetStringId("chopper"),
                            SubstitutedVehicle = StringId.Null
                        },
                        new MultiplayerGlobals.UniversalBlock.VehicleSet.Substitution
                        {
                            OriginalVehicle = CacheContext.GetStringId("mauler"),
                            SubstitutedVehicle = StringId.Null
                        },
                        new MultiplayerGlobals.UniversalBlock.VehicleSet.Substitution
                        {
                            OriginalVehicle = CacheContext.GetStringId("hornet"),
                            SubstitutedVehicle = StringId.Null
                        }
                    }
                    #endregion
                },
                new MultiplayerGlobals.UniversalBlock.VehicleSet
                {
                    Name = CacheContext.GetStringId("light_ground_only"),
                    #region Substitutions
                    Substitutions = new List<MultiplayerGlobals.UniversalBlock.VehicleSet.Substitution>
                    {
                        new MultiplayerGlobals.UniversalBlock.VehicleSet.Substitution
                        {
                            OriginalVehicle = CacheContext.GetStringId("scorpion"),
                            SubstitutedVehicle = StringId.Null
                        },
                        new MultiplayerGlobals.UniversalBlock.VehicleSet.Substitution
                        {
                            OriginalVehicle = CacheContext.GetStringId("wraith"),
                            SubstitutedVehicle = StringId.Null
                        },
                        new MultiplayerGlobals.UniversalBlock.VehicleSet.Substitution
                        {
                            OriginalVehicle = CacheContext.GetStringId("banshee"),
                            SubstitutedVehicle = StringId.Null
                        },
                        new MultiplayerGlobals.UniversalBlock.VehicleSet.Substitution
                        {
                            OriginalVehicle = CacheContext.GetStringId("hornet"),
                            SubstitutedVehicle = StringId.Null
                        }
                    }
                    #endregion
                },
                new MultiplayerGlobals.UniversalBlock.VehicleSet
                {
                    Name = CacheContext.GetStringId("tanks_only"),
                    #region Substitutions
                    Substitutions = new List<MultiplayerGlobals.UniversalBlock.VehicleSet.Substitution>
                    {
                        new MultiplayerGlobals.UniversalBlock.VehicleSet.Substitution
                        {
                            OriginalVehicle = CacheContext.GetStringId("warthog"),
                            SubstitutedVehicle = StringId.Null
                        },
                        new MultiplayerGlobals.UniversalBlock.VehicleSet.Substitution
                        {
                            OriginalVehicle = CacheContext.GetStringId("ghost"),
                            SubstitutedVehicle = StringId.Null
                        },
                        new MultiplayerGlobals.UniversalBlock.VehicleSet.Substitution
                        {
                            OriginalVehicle = CacheContext.GetStringId("mongoose"),
                            SubstitutedVehicle = StringId.Null
                        },
                        new MultiplayerGlobals.UniversalBlock.VehicleSet.Substitution
                        {
                            OriginalVehicle = CacheContext.GetStringId("banshee"),
                            SubstitutedVehicle = StringId.Null
                        },
                        new MultiplayerGlobals.UniversalBlock.VehicleSet.Substitution
                        {
                            OriginalVehicle = CacheContext.GetStringId("chopper"),
                            SubstitutedVehicle = StringId.Null
                        },
                        new MultiplayerGlobals.UniversalBlock.VehicleSet.Substitution
                        {
                            OriginalVehicle = CacheContext.GetStringId("mauler"),
                            SubstitutedVehicle = StringId.Null
                        },
                        new MultiplayerGlobals.UniversalBlock.VehicleSet.Substitution
                        {
                            OriginalVehicle = CacheContext.GetStringId("hornet"),
                            SubstitutedVehicle = StringId.Null
                        }
                    }
                    #endregion
                },
                new MultiplayerGlobals.UniversalBlock.VehicleSet
                {
                    Name = CacheContext.GetStringId("aircraft_only"),
                    #region Substitutions
                    Substitutions = new List<MultiplayerGlobals.UniversalBlock.VehicleSet.Substitution>
                    {
                        new MultiplayerGlobals.UniversalBlock.VehicleSet.Substitution
                        {
                            OriginalVehicle = CacheContext.GetStringId("warthog"),
                            SubstitutedVehicle = StringId.Null
                        },
                        new MultiplayerGlobals.UniversalBlock.VehicleSet.Substitution
                        {
                            OriginalVehicle = CacheContext.GetStringId("ghost"),
                            SubstitutedVehicle = StringId.Null
                        },
                        new MultiplayerGlobals.UniversalBlock.VehicleSet.Substitution
                        {
                            OriginalVehicle = CacheContext.GetStringId("scorpion"),
                            SubstitutedVehicle = StringId.Null
                        },
                        new MultiplayerGlobals.UniversalBlock.VehicleSet.Substitution
                        {
                            OriginalVehicle = CacheContext.GetStringId("wraith"),
                            SubstitutedVehicle = StringId.Null
                        },
                        new MultiplayerGlobals.UniversalBlock.VehicleSet.Substitution
                        {
                            OriginalVehicle = CacheContext.GetStringId("mongoose"),
                            SubstitutedVehicle = StringId.Null
                        },
                        new MultiplayerGlobals.UniversalBlock.VehicleSet.Substitution
                        {
                            OriginalVehicle = CacheContext.GetStringId("chopper"),
                            SubstitutedVehicle = StringId.Null
                        },
                        new MultiplayerGlobals.UniversalBlock.VehicleSet.Substitution
                        {
                            OriginalVehicle = CacheContext.GetStringId("mauler"),
                            SubstitutedVehicle = StringId.Null
                        }
                    }
                    #endregion
                },
                new MultiplayerGlobals.UniversalBlock.VehicleSet
                {
                    Name = CacheContext.GetStringId("no_light_ground"),
                    #region Substitutions
                    Substitutions = new List<MultiplayerGlobals.UniversalBlock.VehicleSet.Substitution>
                    {
                        new MultiplayerGlobals.UniversalBlock.VehicleSet.Substitution
                        {
                            OriginalVehicle = CacheContext.GetStringId("warthog"),
                            SubstitutedVehicle = StringId.Null
                        },
                        new MultiplayerGlobals.UniversalBlock.VehicleSet.Substitution
                        {
                            OriginalVehicle = CacheContext.GetStringId("ghost"),
                            SubstitutedVehicle = StringId.Null
                        },
                        new MultiplayerGlobals.UniversalBlock.VehicleSet.Substitution
                        {
                            OriginalVehicle = CacheContext.GetStringId("mongoose"),
                            SubstitutedVehicle = StringId.Null
                        },
                        new MultiplayerGlobals.UniversalBlock.VehicleSet.Substitution
                        {
                            OriginalVehicle = CacheContext.GetStringId("chopper"),
                            SubstitutedVehicle = StringId.Null
                        },
                        new MultiplayerGlobals.UniversalBlock.VehicleSet.Substitution
                        {
                            OriginalVehicle = CacheContext.GetStringId("mauler"),
                            SubstitutedVehicle = StringId.Null
                        }
                    }
                    #endregion
                },
                new MultiplayerGlobals.UniversalBlock.VehicleSet
                {
                    Name = CacheContext.GetStringId("no_tanks"),
                    #region Substitutions
                    Substitutions = new List<MultiplayerGlobals.UniversalBlock.VehicleSet.Substitution>
                    {
                        new MultiplayerGlobals.UniversalBlock.VehicleSet.Substitution
                        {
                            OriginalVehicle = CacheContext.GetStringId("scorpion"),
                            SubstitutedVehicle = StringId.Null
                        },
                        new MultiplayerGlobals.UniversalBlock.VehicleSet.Substitution
                        {
                            OriginalVehicle = CacheContext.GetStringId("wraith"),
                            SubstitutedVehicle = StringId.Null
                        }
                    }
                    #endregion
                },
                new MultiplayerGlobals.UniversalBlock.VehicleSet
                {
                    Name = CacheContext.GetStringId("no_aircraft"),
                    #region Substitutions
                    Substitutions = new List<MultiplayerGlobals.UniversalBlock.VehicleSet.Substitution>
                    {
                        new MultiplayerGlobals.UniversalBlock.VehicleSet.Substitution
                        {
                            OriginalVehicle = CacheContext.GetStringId("banshee"),
                            SubstitutedVehicle = StringId.Null
                        },
                        new MultiplayerGlobals.UniversalBlock.VehicleSet.Substitution
                        {
                            OriginalVehicle = CacheContext.GetStringId("hornet"),
                            SubstitutedVehicle = StringId.Null
                        }
                    }
                    #endregion
                },
                new MultiplayerGlobals.UniversalBlock.VehicleSet
                {
                    Name = CacheContext.GetStringId("all_vehicles"),
                    Substitutions = new List<MultiplayerGlobals.UniversalBlock.VehicleSet.Substitution>()
                }
            };
            #endregion

            #region Runtime Vehicles
            mulgDefinition.Runtime[0].MultiplayerConstants[0].Vehicles = new List<MultiplayerGlobals.RuntimeBlock.MultiplayerConstant.Vehicle>
            {
                new MultiplayerGlobals.RuntimeBlock.MultiplayerConstant.Vehicle
                {
                    Vehicle2 = CacheContext.TagCache.Index[0x1517],
                    Unknown1 = 2.0f,
                    Unknown2 = 1.5f,
                    Unknown3 = 0.5f,
                    Unknown4 = -1000.0f
                },
                new MultiplayerGlobals.RuntimeBlock.MultiplayerConstant.Vehicle
                {
                    Vehicle2 = CacheContext.TagCache.Index[0x151F],
                    Unknown1 = 2.0f,
                    Unknown2 = 1.5f,
                    Unknown3 = 0.5f,
                    Unknown4 = -1000.0f
                },
                new MultiplayerGlobals.RuntimeBlock.MultiplayerConstant.Vehicle
                {
                    Vehicle2 = CacheContext.TagCache.Index[0x151A],
                    Unknown1 = 2.0f,
                    Unknown2 = 1.5f,
                    Unknown3 = 0.5f,
                    Unknown4 = -1000.0f
                },
                new MultiplayerGlobals.RuntimeBlock.MultiplayerConstant.Vehicle
                {
                    Vehicle2 = CacheContext.TagCache.Index[0x1596],
                    Unknown1 = 1.5f,
                    Unknown2 = 1.5f,
                    Unknown3 = 0.5f,
                    Unknown4 = -1000.0f
                },
                new MultiplayerGlobals.RuntimeBlock.MultiplayerConstant.Vehicle
                {
                    Vehicle2 = CacheContext.TagCache.Index[0x1518],
                    Unknown1 = 3.0f,
                    Unknown2 = 1.5f,
                    Unknown3 = 0.25f,
                    Unknown4 = -1000.0f
                },
                new MultiplayerGlobals.RuntimeBlock.MultiplayerConstant.Vehicle
                {
                    Vehicle2 = CacheContext.TagCache.Index[0x1598],
                    Unknown1 = 2.0f,
                    Unknown2 = 1.5f,
                    Unknown3 = 0.5f,
                    Unknown4 = -1000.0f
                },
                new MultiplayerGlobals.RuntimeBlock.MultiplayerConstant.Vehicle
                {
                    Vehicle2 = CacheContext.TagCache.Index[0x1520],
                    Unknown1 = 3.0f,
                    Unknown2 = 1.5f,
                    Unknown3 = 0.5f,
                    Unknown4 = -1000.0f
                },
                new MultiplayerGlobals.RuntimeBlock.MultiplayerConstant.Vehicle
                {
                    Vehicle2 = CacheContext.TagCache.Index[0x1519],
                    Unknown1 = 3.0f,
                    Unknown2 = 1.5f,
                    Unknown3 = 0.5f,
                    Unknown4 = -1000.0f
                },
            };
            #endregion

            CacheContext.Serializer.Serialize(mulgContext, mulgDefinition);
        }

        private void CleanScenario(Stream stream, CachedTagInstance tag)
        {
            var context = new TagSerializationContext(stream, CacheContext, tag);
            var scenario = CacheContext.Deserializer.Deserialize<Scenario>(context);

            var keepIndices = new HashSet<int>
            {
                0x01AC,
                0x01AF,
                0x01B2,
                0x01B5,
                0x1B8E,
                0x1B8F,
                0x2EAA,
                0x2EAB,
                0x2EAC
            };

            foreach (var eqip in scenario.EquipmentPalette)
            {
                if (eqip.Equipment != null && !keepIndices.Contains(eqip.Equipment.Index))
                    eqip.Equipment = null;
            }

            var newSandboxEquip = new List<Scenario.SandboxObject>();

            foreach (var eqip in scenario.SandboxEquipment)
            {
                if (eqip.Object != null && keepIndices.Contains(eqip.Object.Index))
                    newSandboxEquip.Add(eqip);
            }

            scenario.SandboxEquipment = newSandboxEquip;

            CacheContext.Serializer.Serialize(context, scenario);
        }

        private void NullTags(Stream stream, ref HashSet<int> retainedTags)
        {
            for (var i = 0; i < CacheContext.TagCache.Index.Count; i++)
            {
                var tag = CacheContext.TagCache.Index[i];

                if (tag == null)
                    continue;

                if (retainedTags.Contains(i))
                {
                    var context = new TagSerializationContext(stream, CacheContext, tag);

                    if (tag.IsInGroup("bink"))
                    {
                        Console.Write($"Loading {CacheContext.TagNames[tag.Index]}.{CacheContext.GetString(tag.Group.Name)}...");
                        var tagDefinition = CacheContext.Deserializer.Deserialize(context, TagStructureTypes.FindByGroupTag(tag.Group.Tag));
                        Console.Write($"preparing video resource for recache...");
                        AddResource(((Bink)tagDefinition).Resource);
                    }
                    else if (tag.IsInGroup("bitm"))
                    {
                        Console.Write($"Loading {CacheContext.TagNames[tag.Index]}.{CacheContext.GetString(tag.Group.Name)}...");
                        var tagDefinition = CacheContext.Deserializer.Deserialize(context, TagStructureTypes.FindByGroupTag(tag.Group.Tag));
                        Console.Write($"preparing bitmap resources for recache...");

                        foreach (var resource in ((Bitmap)tagDefinition).Resources)
                            AddResource(resource.Resource);
                    }
                    else if (tag.IsInGroup("jmad"))
                    {
                        Console.Write($"Loading {CacheContext.TagNames[tag.Index]}.{CacheContext.GetString(tag.Group.Name)}...");
                        var tagDefinition = CacheContext.Deserializer.Deserialize(context, TagStructureTypes.FindByGroupTag(tag.Group.Tag));
                        Console.Write($"preparing animation resources for recache...");

                        foreach (var resourceGroup in ((ModelAnimationGraph)tagDefinition).ResourceGroups)
                            AddResource(resourceGroup.Resource);
                    }
                    else if (tag.IsInGroup("Lbsp"))
                    {
                        Console.Write($"Loading {CacheContext.TagNames[tag.Index]}.{CacheContext.GetString(tag.Group.Name)}...");
                        var tagDefinition = CacheContext.Deserializer.Deserialize(context, TagStructureTypes.FindByGroupTag(tag.Group.Tag));
                        Console.Write($"preparing geometry resource for recache...");
                        AddResource(((ScenarioLightmapBspData)tagDefinition).Geometry.Resource);
                    }
                    else if (tag.IsInGroup("mode"))
                    {
                        Console.Write($"Loading {CacheContext.TagNames[tag.Index]}.{CacheContext.GetString(tag.Group.Name)}...");
                        var tagDefinition = CacheContext.Deserializer.Deserialize(context, TagStructureTypes.FindByGroupTag(tag.Group.Tag));
                        Console.Write($"preparing geometry resource for recache...");
                        AddResource(((RenderModel)tagDefinition).Geometry.Resource);
                    }
                    else if (tag.IsInGroup("sbsp"))
                    {
                        Console.Write($"Loading {CacheContext.TagNames[tag.Index]}.{CacheContext.GetString(tag.Group.Name)}...");
                        var tagDefinition = CacheContext.Deserializer.Deserialize(context, TagStructureTypes.FindByGroupTag(tag.Group.Tag));

                        try
                        {
                            Console.WriteLine($"preparing small geometry resource for recache...");
                            AddResource(((ScenarioStructureBsp)tagDefinition).Geometry.Resource);
                        }
                        catch { }

                        try
                        {
                            Console.Write($"preparing large geometry resource for recache...");
                            AddResource(((ScenarioStructureBsp)tagDefinition).Geometry2.Resource);
                        }
                        catch { }

                        try
                        {
                            Console.Write($"preparing collision resource for recache...");
                            AddResource(((ScenarioStructureBsp)tagDefinition).CollisionBspResource);
                        }
                        catch { }

                        try
                        {
                            Console.Write($"preparing unknown resource for recache...");
                            AddResource(((ScenarioStructureBsp)tagDefinition).Resource4);
                        }
                        catch { }
                    }
                    else if (tag.IsInGroup("snd!"))
                    {
                        Console.Write($"Loading {CacheContext.TagNames[tag.Index]}.{CacheContext.GetString(tag.Group.Name)}...");
                        var tagDefinition = CacheContext.Deserializer.Deserialize(context, TagStructureTypes.FindByGroupTag(tag.Group.Tag));
                        Console.Write($"preparing sound resource for recache...");
                        AddResource(((Sound)tagDefinition).Resource);
                    }
                }
                else
                {
                    Console.Write($"Nulling {CacheContext.TagNames[tag.Index]}.{CacheContext.GetString(tag.Group.Name)}...");
                    CacheContext.TagCache.Index[tag.Index] = null;
                    CacheContext.TagCache.SetTagDataRaw(stream, tag, new byte[] { });
                }

                Console.WriteLine("done.");
            }
        }

        private void NullResources()
        {
            //
            // Audio Resources
            //

            Console.WriteLine("Deserializing audio.dat");
            var resourceFile = new ResourceFile(new FileInfo(Path.Combine(CacheContext.TagCacheFile.DirectoryName, "audio.dat")));

            foreach (var resource in resourceFile.Resources)
            {
                if (!AudioResourceIndices.Contains(resource.Index))
                {
                    Console.WriteLine("nulling audio resource at index: " + resource.Index);
                    resourceFile.NullResource(resource.Index);
                }
            }

            Console.WriteLine($"Serializing to {CacheContext.TagCacheFile.Directory}/audio.dat");
            resourceFile.Serialize(new FileInfo(Path.Combine(CacheContext.TagCacheFile.DirectoryName, "audio.dat")));

            //
            // Main Resources
            //

            Console.WriteLine("Deserializing resources.dat");
            resourceFile = new ResourceFile(new FileInfo(Path.Combine(CacheContext.TagCacheFile.DirectoryName, "resources.dat")));

            foreach (var resource in resourceFile.Resources)
            {
                if (!ResourcesResourceIndices.Contains(resource.Index))
                {
                    Console.WriteLine("nulling resources resource at index: " + resource.Index);
                    resourceFile.NullResource(resource.Index);
                }
            }

            Console.WriteLine($"Serializing to {CacheContext.TagCacheFile.Directory}/resources.dat");
            resourceFile.Serialize(new FileInfo(Path.Combine(CacheContext.TagCacheFile.DirectoryName, "resources.dat")));

            //
            // Textures Resources
            //

            Console.WriteLine("Deserializing textures.dat");
            resourceFile = new ResourceFile(new FileInfo(Path.Combine(CacheContext.TagCacheFile.DirectoryName, "textures.dat")));

            foreach (var resource in resourceFile.Resources)
            {
                if (!TexturesResourceIndices.Contains(resource.Index))
                {
                    Console.WriteLine("nulling textures resource at index: " + resource.Index);
                    resourceFile.NullResource(resource.Index);
                }
            }

            Console.WriteLine($"Serializing to {CacheContext.TagCacheFile.Directory}/textures.dat");
            resourceFile.Serialize(new FileInfo(Path.Combine(CacheContext.TagCacheFile.DirectoryName, "textures.dat")));

            //
            // TexturesB Resources
            //

            Console.WriteLine("Deserializing textures_b.dat");
            resourceFile = new ResourceFile(new FileInfo(Path.Combine(CacheContext.TagCacheFile.DirectoryName, "textures_b.dat")));

            foreach (var resource in resourceFile.Resources)
            {
                if (!TexturesBResourceIndices.Contains(resource.Index))
                {
                    Console.WriteLine("nulling textures_b resource at index: " + resource.Index);
                    resourceFile.NullResource(resource.Index);
                }
            }

            Console.WriteLine($"Serializing to {CacheContext.TagCacheFile.Directory}/textures_b.dat");
            resourceFile.Serialize(new FileInfo(Path.Combine(CacheContext.TagCacheFile.DirectoryName, "textures_b.dat")));

            //
            // Video Resources
            //

            Console.WriteLine("Deserializing video.dat");
            resourceFile = new ResourceFile(new FileInfo(Path.Combine(CacheContext.TagCacheFile.DirectoryName, "video.dat")));

            foreach (var resource in resourceFile.Resources)
            {
                if (!VideoResourceIndices.Contains(resource.Index))
                {
                    Console.WriteLine("nulling video resource at index: " + resource.Index);
                    resourceFile.NullResource(resource.Index);
                }
            }

            Console.WriteLine($"Serializing to {CacheContext.TagCacheFile.Directory}/video.dat");
            resourceFile.Serialize(new FileInfo(Path.Combine(CacheContext.TagCacheFile.DirectoryName, "video.dat")));
        }

        public override bool Execute(List<string> args)
        {
            if (args.Count != 0)
                return false;

            using (var stream = CacheContext.OpenTagCacheReadWrite())
            {
                CleanGlobals(stream);
                CleanMultiplayerGlobals(stream);

                var retainedTags = new HashSet<int>();
                LoadTagDependencies(CacheContext.TagCache.Index.FindFirstInGroup("cfgt").Index, ref retainedTags);

                foreach (var scnr in CacheContext.TagCache.Index.FindAllInGroup("scnr"))
                {
                    var scnrContext = new TagSerializationContext(stream, CacheContext, scnr);
                    var definition = CacheContext.Deserializer.Deserialize<Scenario>(scnrContext);
                    var scnrName = CacheContext.GetString(definition.ZoneSets[0].Name);

                    switch (scnrName)
                    {
                        case "levels\\multi\\s3d_avalanche\\s3d_avalanche":
                        case "levels\\multi\\s3d_edge\\s3d_edge":
                        case "levels\\multi\\s3d_reactor\\s3d_reactor":
                        case "levels\\multi\\s3d_turf\\s3d_turf":
                            break;

                        default:
                            CleanScenario(stream, scnr);
                            LoadTagDependencies(scnr.Index, ref retainedTags);
                            break;
                    }
                }
                
                NullTags(stream, ref retainedTags);
                NullResources();
            }

            return true;
        }
    }
}

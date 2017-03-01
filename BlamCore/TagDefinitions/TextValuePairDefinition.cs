using System.Collections.Generic;
using BlamCore.Common;
using BlamCore.Serialization;

namespace BlamCore.TagDefinitions
{
    [TagStructure(Name = "text_value_pair_definition", Class = "sily", Size = 0x18)]
    public class TextValuePairDefinition
    {
        public ParameterValue Parameter;
        public StringId Name;
        public StringId Description;
        public List<TextValuePair> TextValuePairs;

        public enum ParameterValue : int
        {
            IntGlobalTeams,
            IntGlobalNewUnknown,
            IntGlobalRoundsReset,
            IntGlobalRoundTimeLimit,
            IntGlobalRoundCount,
            IntGlobalEarlyVictoryWinCount,
            IntGlobalRespawnInheritance,
            IntGlobalRespawnWithTeam,
            IntGlobalRespawnAtLocation,
            IntGlobalRespawnOnKill,
            IntGlobalLivesPerRound,
            IntGlobalTeamLivesPerRound,
            IntGlobalRespawnTime,
            IntGlobalSuicidePenalty,
            IntGlobalBetrayalPenalty,
            IntGlobalRespawnGrowth,
            IntGlobalRespawnTraitsDuration,
            IntGlobalRespawnTraitsDamageResistance,
            IntGlobalRespawnTraitsShieldMultiplier,
            IntGlobalRespawnTraitsShieldRecharge,
            IntGlobalRespawnTraitsHeadshotImmunity,
            IntGlobalRespawnTraitsVampirism,
            IntGlobalRespawnTraitsDamageModifier,
            SidGlobalRespawnTraitsPrimaryWeapon,
            SidGlobalRespawnTraitsSecondaryWeapon,
            IntGlobalRespawnTraitsGrenadeCount,
            IntGlobalRespawnTraitsGrenadeRecharge,
            IntGlobalRespawnTraitsInfiniteAmmo,
            IntGlobalRespawnTraitsWeaponPickup,
            IntGlobalRespawnTraitsSpeed,
            IntGlobalRespawnTraitsGravity,
            IntGlobalRespawnTraitsVehicleUse,
            IntGlobalRespawnTraitsSensor,
            IntGlobalRespawnTraitsSensorRange,
            IntGlobalRespawnTraitsWaypoint,
            IntGlobalRespawnTraitsActiveCamo,
            IntGlobalRespawnTraitsVisualAura,
            IntGlobalRespawnTraitsForcedColor,
            IntGlobalObservers,
            IntGlobalTeamChanging,
            IntGlobalFriendlyFire,
            IntGlobalBetrayalBooting,
            IntGlobalEnemyVoice,
            IntGlobalOpenChannelVoice,
            IntGlobalDeadPlayerVoice,
            IntGlobalGrenadesOnMap,
            IntGlobalIndestructibleVehicles,
            IntGlobalBaseTraitsDamageResistance,
            IntGlobalBaseTraitsShieldMultiplier,
            IntGlobalBaseTraitsShieldRecharge,
            IntGlobalBaseTraitsHeadshotImmunity,
            IntGlobalBaseTraitsVampirism,
            IntGlobalBaseTraitsDamageModifier,
            SidGlobalBaseTraitsPrimaryWeapon,
            SidGlobalBaseTraitsSecondaryWeapon,
            IntGlobalBaseTraitsGrenadeCount,
            IntGlobalBaseTraitsGrenadeRecharge,
            IntGlobalBaseTraitsInfiniteAmmo,
            IntGlobalBaseTraitsWeaponPickup,
            IntGlobalBaseTraitsSpeed,
            IntGlobalBaseTraitsGravity,
            IntGlobalBaseTraitsVehicleUse,
            IntGlobalBaseTraitsSensor,
            IntGlobalBaseTraitsSensorRange,
            IntGlobalBaseTraitsWaypoint,
            IntGlobalBaseTraitsActiveCamo,
            IntGlobalBaseTraitsVisualAura,
            IntGlobalBaseTraitsForcedColor,
            SidGlobalMapWeaponSet,
            SidGlobalMapVehicleSet,
            IntGlobalRedTraitsDamageResistance,
            IntGlobalRedTraitsShieldMultiplier,
            IntGlobalRedTraitsShieldRecharge,
            IntGlobalRedTraitsHeadshotImmunity,
            IntGlobalRedTraitsVampirism,
            IntGlobalRedTraitsDamageModifier,
            SidGlobalRedTraitsPrimaryWeapon,
            SidGlobalRedTraitsSecondaryWeapon,
            IntGlobalRedTraitsGrenadeCount,
            IntGlobalRedTraitsGrenadeRecharge,
            IntGlobalRedTraitsInfiniteAmmo,
            IntGlobalRedTraitsWeaponPickup,
            IntGlobalRedTraitsSpeed,
            IntGlobalRedTraitsGravity,
            IntGlobalRedTraitsVehicleUse,
            IntGlobalRedTraitsSensor,
            IntGlobalRedTraitsSensorRange,
            IntGlobalRedTraitsWaypoint,
            IntGlobalRedTraitsActiveCamo,
            IntGlobalRedTraitsVisualAura,
            IntGlobalRedTraitsForcedColor,
            IntGlobalBlueTraitsDamageResistance,
            IntGlobalBlueTraitsShieldMultiplier,
            IntGlobalBlueTraitsShieldRecharge,
            IntGlobalBlueTraitsHeadshotImmunity,
            IntGlobalBlueTraitsVampirism,
            IntGlobalBlueTraitsDamageModifier,
            SidGlobalBlueTraitsPrimaryWeapon,
            SidGlobalBlueTraitsSecondaryWeapon,
            IntGlobalBlueTraitsGrenadeCount,
            IntGlobalBlueTraitsGrenadeRecharge,
            IntGlobalBlueTraitsInfiniteAmmo,
            IntGlobalBlueTraitsWeaponPickup,
            IntGlobalBlueTraitsSpeed,
            IntGlobalBlueTraitsGravity,
            IntGlobalBlueTraitsVehicleUse,
            IntGlobalBlueTraitsSensor,
            IntGlobalBlueTraitsSensorRange,
            IntGlobalBlueTraitsWaypoint,
            IntGlobalBlueTraitsActiveCamo,
            IntGlobalBlueTraitsVisualAura,
            IntGlobalBlueTraitsForcedColor,
            IntGlobalYellowTraitsDamageResistance,
            IntGlobalYellowTraitsShieldMultiplier,
            IntGlobalYellowTraitsShieldRecharge,
            IntGlobalYellowTraitsHeadshotImmunity,
            IntGlobalYellowTraitsVampirism,
            IntGlobalYellowTraitsDamageModifier,
            SidGlobalYellowTraitsPrimaryWeapon,
            SidGlobalYellowTraitsSecondaryWeapon,
            IntGlobalYellowTraitsGrenadeCount,
            IntGlobalYellowTraitsGrenadeRecharge,
            IntGlobalYellowTraitsInfiniteAmmo,
            IntGlobalYellowTraitsWeaponPickup,
            IntGlobalYellowTraitsSpeed,
            IntGlobalYellowTraitsGravity,
            IntGlobalYellowTraitsVehicleUse,
            IntGlobalYellowTraitsSensor,
            IntGlobalYellowTraitsSensorRange,
            IntGlobalYellowTraitsWaypoint,
            IntGlobalYellowTraitsActiveCamo,
            IntGlobalYellowTraitsVisualAura,
            IntGlobalYellowTraitsForcedColor,
            IntGlobalRedTraitsDuration,
            IntGlobalBlueTraitsDuration,
            IntGlobalYellowTraitsDuration,
            IntSlayerTeamScoring,
            IntSlayerScoreToWin,
            IntSlayerKillPoints,
            IntSlayerAssistPoints,
            IntSlayerDeathPoints,
            IntSlayerSuicidePoints,
            IntSlayerBetrayalPoints,
            IntSlayerLeaderPoints,
            IntSlayerEliminationPoints,
            IntSlayerAssassinationPoints,
            IntSlayerHeadshotPoints,
            IntSlayerMeleePoints,
            IntSlayerStickyPoints,
            IntSlayerSplatterPoints,
            IntSlayerSpreePoints,
            IntSlayerLeaderTraitsDamageResistance,
            IntSlayerLeaderTraitsShieldMultiplier,
            IntSlayerLeaderTraitsShieldRecharge,
            IntSlayerLeaderTraitsHeadshotImmunity,
            IntSlayerLeaderTraitsVampirism,
            IntSlayerLeaderTraitsDamageModifier,
            SidSlayerLeaderTraitsPrimaryWeapon,
            SidSlayerLeaderTraitsSecondaryWeapon,
            IntSlayerLeaderTraitsGrenadeCount,
            IntSlayerLeaderTraitsGrenadeRecharge,
            IntSlayerLeaderTraitsInfiniteAmmo,
            IntSlayerLeaderTraitsWeaponPickup,
            IntSlayerLeaderTraitsSpeed,
            IntSlayerLeaderTraitsGravity,
            IntSlayerLeaderTraitsVehicleUse,
            IntSlayerLeaderTraitsSensor,
            IntSlayerLeaderTraitsSensorRange,
            IntSlayerLeaderTraitsWaypoint,
            IntSlayerLeaderTraitsActiveCamo,
            IntSlayerLeaderTraitsVisualAura,
            IntSlayerLeaderTraitsForcedColor,
            IntOddballAutoPickup,
            IntOddballBallEffect,
            IntOddballTeamScoring,
            IntOddballUnknown,
            IntOddballScoreToWin,
            IntOddballCarrierPoints,
            IntOddballKillPoints,
            IntOddballBallKillPoints,
            IntOddballCarrierKillPoints,
            IntOddballBallCount,
            IntOddballSpawnDelay,
            IntOddballRespawnDelay,
            IntOddballCarrierTraitsDamageResistance,
            IntOddballCarrierTraitsShieldMultiplier,
            IntOddballCarrierTraitsShieldRecharge,
            IntOddballCarrierTraitsHeadshotImmunity,
            IntOddballCarrierTraitsVampirism,
            IntOddballCarrierTraitsDamageModifier,
            SidOddballCarrierTraitsPrimaryWeapon,
            SidOddballCarrierTraitsSecondaryWeapon,
            IntOddballCarrierTraitsGrenadeCount,
            IntOddballCarrierTraitsGrenadeRecharge,
            IntOddballCarrierTraitsInfiniteAmmo,
            IntOddballCarrierTraitsWeaponPickup,
            IntOddballCarrierTraitsSpeed,
            IntOddballCarrierTraitsGravity,
            IntOddballCarrierTraitsVehicleUse,
            IntOddballCarrierTraitsSensor,
            IntOddballCarrierTraitsSensorRange,
            IntOddballCarrierTraitsWaypoint,
            IntOddballCarrierTraitsActiveCamo,
            IntOddballCarrierTraitsVisualAura,
            IntOddballCarrierTraitsForcedColor,
            IntCtfTouchReturnTime,
            IntCtfFlagAtHome,
            IntCtfHomeWaypoint,
            IntCtfUnknown,
            IntCtfUnknown2,
            IntCtfGameMode,
            IntCtfRespawnDelay,
            IntCtfScoreToWin,
            IntCtfSuddenDeath,
            IntCtfIdleReturn,
            IntCtfUnknown3,
            IntCtfUnknown4,
            IntCtfCarrierTraitsDamageResistance,
            IntCtfCarrierTraitsShieldMultiplier,
            IntCtfCarrierTraitsShieldRecharge,
            IntCtfCarrierTraitsHeadshotImmunity,
            IntCtfCarrierTraitsVampirism,
            IntCtfCarrierTraitsDamageModifier,
            SidCtfCarrierTraitsPrimaryWeapon,
            SidCtfCarrierTraitsSecondaryWeapon,
            IntCtfCarrierTraitsGrenadeCount,
            IntCtfCarrierTraitsGrenadeRecharge,
            IntCtfCarrierTraitsInfiniteAmmo,
            IntCtfCarrierTraitsWeaponPickup,
            IntCtfCarrierTraitsSpeed,
            IntCtfCarrierTraitsGravity,
            IntCtfCarrierTraitsVehicleUse,
            IntCtfCarrierTraitsSensor,
            IntCtfCarrierTraitsSensorRange,
            IntCtfCarrierTraitsWaypoint,
            IntCtfCarrierTraitsActiveCamo,
            IntCtfCarrierTraitsVisualAura,
            IntCtfCarrierTraitsForcedColor,
            IntInfectionRespawnOnHavenMove,
            IntInfectionHavenMovement,
            IntInfectionNextZombie,
            IntInfectionInitialCount,
            IntInfectionHavenMovementTime,
            IntInfectionKillPoints,
            IntInfectionInfectPoints,
            IntInfectionHavenArrivalPoints,
            IntInfectionSuicidePoints,
            IntInfectionBetrayalPoints,
            IntInfectionLastManStandingPoints,
            IntInfectionZombieTraitsDamageResistance,
            IntInfectionZombieTraitsShieldMultiplier,
            IntInfectionZombieTraitsShieldRecharge,
            IntInfectionZombieTraitsHeadshotImmunity,
            IntInfectionZombieTraitsVampirism,
            IntInfectionZombieTraitsDamageModifier,
            SidInfectionZombieTraitsPrimaryWeapon,
            SidInfectionZombieTraitsSecondaryWeapon,
            IntInfectionZombieTraitsGrenadeCount,
            IntInfectionZombieTraitsGrenadeRecharge,
            IntInfectionZombieTraitsInfiniteAmmo,
            IntInfectionZombieTraitsWeaponPickup,
            IntInfectionZombieTraitsSpeed,
            IntInfectionZombieTraitsGravity,
            IntInfectionZombieTraitsVehicleUse,
            IntInfectionZombieTraitsSensor,
            IntInfectionZombieTraitsSensorRange,
            IntInfectionZombieTraitsWaypoint,
            IntInfectionZombieTraitsActiveCamo,
            IntInfectionZombieTraitsVisualAura,
            IntInfectionZombieTraitsForcedColor,
            IntInfectionAlphaZombieTraitsDamageResistance,
            IntInfectionAlphaZombieTraitsShieldMultiplier,
            IntInfectionAlphaZombieTraitsShieldRecharge,
            IntInfectionAlphaZombieTraitsHeadshotImmunity,
            IntInfectionAlphaZombieTraitsVampirism,
            IntInfectionAlphaZombieTraitsDamageModifier,
            SidInfectionAlphaZombieTraitsPrimaryWeapon,
            SidInfectionAlphaZombieTraitsSecondaryWeapon,
            IntInfectionAlphaZombieTraitsGrenadeCount,
            IntInfectionAlphaZombieTraitsGrenadeRecharge,
            IntInfectionAlphaZombieTraitsInfiniteAmmo,
            IntInfectionAlphaZombieTraitsWeaponPickup,
            IntInfectionAlphaZombieTraitsSpeed,
            IntInfectionAlphaZombieTraitsGravity,
            IntInfectionAlphaZombieTraitsVehicleUse,
            IntInfectionAlphaZombieTraitsSensor,
            IntInfectionAlphaZombieTraitsSensorRange,
            IntInfectionAlphaZombieTraitsWaypoint,
            IntInfectionAlphaZombieTraitsActiveCamo,
            IntInfectionAlphaZombieTraitsVisualAura,
            IntInfectionAlphaZombieTraitsForcedColor,
            IntInfectionHavenTraitsDamageResistance,
            IntInfectionHavenTraitsShieldMultiplier,
            IntInfectionHavenTraitsShieldRecharge,
            IntInfectionHavenTraitsHeadshotImmunity,
            IntInfectionHavenTraitsVampirism,
            IntInfectionHavenTraitsDamageModifier,
            SidInfectionHavenTraitsPrimaryWeapon,
            SidInfectionHavenTraitsSecondaryWeapon,
            IntInfectionHavenTraitsGrenadeCount,
            IntInfectionHavenTraitsGrenadeRecharge,
            IntInfectionHavenTraitsInfiniteAmmo,
            IntInfectionHavenTraitsWeaponPickup,
            IntInfectionHavenTraitsSpeed,
            IntInfectionHavenTraitsGravity,
            IntInfectionHavenTraitsVehicleUse,
            IntInfectionHavenTraitsSensor,
            IntInfectionHavenTraitsSensorRange,
            IntInfectionHavenTraitsWaypoint,
            IntInfectionHavenTraitsActiveCamo,
            IntInfectionHavenTraitsVisualAura,
            IntInfectionHavenTraitsForcedColor,
            IntInfectionLastManStandingTraitsDamageResistance,
            IntInfectionLastManStandingTraitsShieldMultiplier,
            IntInfectionLastManStandingTraitsShieldRecharge,
            IntInfectionLastManStandingTraitsHeadshotImmunity,
            IntInfectionLastManStandingTraitsVampirism,
            IntInfectionLastManStandingTraitsDamageModifier,
            SidInfectionLastManStandingTraitsPrimaryWeapon,
            SidInfectionLastManStandingTraitsSecondaryWeapon,
            IntInfectionLastManStandingTraitsGrenadeCount,
            IntInfectionLastManStandingTraitsGrenadeRecharge,
            IntInfectionLastManStandingTraitsInfiniteAmmo,
            IntInfectionLastManStandingTraitsWeaponPickup,
            IntInfectionLastManStandingTraitsSpeed,
            IntInfectionLastManStandingTraitsGravity,
            IntInfectionLastManStandingTraitsVehicleUse,
            IntInfectionLastManStandingTraitsSensor,
            IntInfectionLastManStandingTraitsSensorRange,
            IntInfectionLastManStandingTraitsWaypoint,
            IntInfectionLastManStandingTraitsActiveCamo,
            IntInfectionLastManStandingTraitsVisualAura,
            IntInfectionLastManStandingTraitsForcedColor,
            IntKothOpaqueHill,
            IntKothScoreToWin,
            IntKothTeamScoring,
            IntKothMovingHill,
            IntKothMovingHillOrder,
            IntKothInsideHillPoints,
            IntKothOutsideHillPoints,
            IntKothUncontestedPoints,
            IntKothKillPoints,
            IntKothHillTraitsDamageResistance,
            IntKothHillTraitsShieldMultiplier,
            IntKothHillTraitsShieldRecharge,
            IntKothHillTraitsHeadshotImmunity,
            IntKothHillTraitsVampirism,
            IntKothHillTraitsDamageModifier,
            SidKothHillTraitsPrimaryWeapon,
            SidKothHillTraitsSecondaryWeapon,
            IntKothHillTraitsGrenadeCount,
            IntKothHillTraitsGrenadeRecharge,
            IntKothHillTraitsInfiniteAmmo,
            IntKothHillTraitsWeaponPickup,
            IntKothHillTraitsSpeed,
            IntKothHillTraitsGravity,
            IntKothHillTraitsVehicleUse,
            IntKothHillTraitsSensor,
            IntKothHillTraitsSensorRange,
            IntKothHillTraitsWaypoint,
            IntKothHillTraitsActiveCamo,
            IntKothHillTraitsVisualAura,
            IntKothHillTraitsForcedColor,
            IntTerritoriesCaptureTime,
            IntTerritoriesGameMode,
            IntTerritoriesLockOnCapture,
            IntTerritoriesSuddenDeath,
            IntTerritoriesSpawnOnCapture,
            IntTerritoriesDefenderTraitsDamageResistance,
            IntTerritoriesDefenderTraitsShieldMultiplier,
            IntTerritoriesDefenderTraitsShieldRecharge,
            IntTerritoriesDefenderTraitsHeadshotImmunity,
            IntTerritoriesDefenderTraitsVampirism,
            IntTerritoriesDefenderTraitsDamageModifier,
            SidTerritoriesDefenderTraitsPrimaryWeapon,
            SidTerritoriesDefenderTraitsSecondaryWeapon,
            IntTerritoriesDefenderTraitsGrenadeCount,
            IntTerritoriesDefenderTraitsGrenadeRecharge,
            IntTerritoriesDefenderTraitsInfiniteAmmo,
            IntTerritoriesDefenderTraitsWeaponPickup,
            IntTerritoriesDefenderTraitsSpeed,
            IntTerritoriesDefenderTraitsGravity,
            IntTerritoriesDefenderTraitsVehicleUse,
            IntTerritoriesDefenderTraitsSensor,
            IntTerritoriesDefenderTraitsSensorRange,
            IntTerritoriesDefenderTraitsWaypoint,
            IntTerritoriesDefenderTraitsActiveCamo,
            IntTerritoriesDefenderTraitsVisualAura,
            IntTerritoriesDefenderTraitsForcedColor,
            IntTerritoriesAttackerTraitsDamageResistance,
            IntTerritoriesAttackerTraitsShieldMultiplier,
            IntTerritoriesAttackerTraitsShieldRecharge,
            IntTerritoriesAttackerTraitsHeadshotImmunity,
            IntTerritoriesAttackerTraitsVampirism,
            IntTerritoriesAttackerTraitsDamageModifier,
            SidTerritoriesAttackerTraitsPrimaryWeapon,
            SidTerritoriesAttackerTraitsSecondaryWeapon,
            IntTerritoriesAttackerTraitsGrenadeCount,
            IntTerritoriesAttackerTraitsGrenadeRecharge,
            IntTerritoriesAttackerTraitsInfiniteAmmo,
            IntTerritoriesAttackerTraitsWeaponPickup,
            IntTerritoriesAttackerTraitsSpeed,
            IntTerritoriesAttackerTraitsGravity,
            IntTerritoriesAttackerTraitsVehicleUse,
            IntTerritoriesAttackerTraitsSensor,
            IntTerritoriesAttackerTraitsSensorRange,
            IntTerritoriesAttackerTraitsWaypoint,
            IntTerritoriesAttackerTraitsActiveCamo,
            IntTerritoriesAttackerTraitsVisualAura,
            IntTerritoriesAttackerTraitsForcedColor,
            IntVipScoreToWin,
            IntVipGameMode,
            IntVipZoneCount,
            IntVipEndOnDeath,
            IntVipKillPoints,
            IntVipTakedownPoints,
            IntVipVipKillPoints,
            IntVipDeathPoints,
            IntVipZoneArrivalPoints,
            IntVipSuicidePoints,
            IntVipVipBetrayalPoints,
            IntVipBetrayalPoints,
            IntVipSelection,
            IntVipZoneMovement,
            IntVipZoneOrder,
            IntVipInfluenceRadius,
            IntVipTeamTraitsDamageResistance,
            IntVipTeamTraitsShieldMultiplier,
            IntVipTeamTraitsShieldRecharge,
            IntVipTeamTraitsHeadshotImmunity,
            IntVipTeamTraitsVampirism,
            IntVipTeamTraitsDamageModifier,
            SidVipTeamTraitsPrimaryWeapon,
            SidVipTeamTraitsSecondaryWeapon,
            IntVipTeamTraitsGrenadeCount,
            IntVipTeamTraitsGrenadeRecharge,
            IntVipTeamTraitsInfiniteAmmo,
            IntVipTeamTraitsWeaponPickup,
            IntVipTeamTraitsSpeed,
            IntVipTeamTraitsGravity,
            IntVipTeamTraitsVehicleUse,
            IntVipTeamTraitsSensor,
            IntVipTeamTraitsSensorRange,
            IntVipTeamTraitsWaypoint,
            IntVipTeamTraitsActiveCamo,
            IntVipTeamTraitsVisualAura,
            IntVipTeamTraitsForcedColor,
            IntVipInfluenceTraitsDamageResistance,
            IntVipInfluenceTraitsShieldMultiplier,
            IntVipInfluenceTraitsShieldRecharge,
            IntVipInfluenceTraitsHeadshotImmunity,
            IntVipInfluenceTraitsVampirism,
            IntVipInfluenceTraitsDamageModifier,
            SidVipInfluenceTraitsPrimaryWeapon,
            SidVipInfluenceTraitsSecondaryWeapon,
            IntVipInfluenceTraitsGrenadeCount,
            IntVipInfluenceTraitsGrenadeRecharge,
            IntVipInfluenceTraitsInfiniteAmmo,
            IntVipInfluenceTraitsWeaponPickup,
            IntVipInfluenceTraitsSpeed,
            IntVipInfluenceTraitsGravity,
            IntVipInfluenceTraitsVehicleUse,
            IntVipInfluenceTraitsSensor,
            IntVipInfluenceTraitsSensorRange,
            IntVipInfluenceTraitsWaypoint,
            IntVipInfluenceTraitsActiveCamo,
            IntVipInfluenceTraitsVisualAura,
            IntVipInfluenceTraitsForcedColor,
            IntVipVipTraitsDamageResistance,
            IntVipVipTraitsShieldMultiplier,
            IntVipVipTraitsShieldRecharge,
            IntVipVipTraitsHeadshotImmunity,
            IntVipVipTraitsVampirism,
            IntVipVipTraitsDamageModifier,
            SidVipVipTraitsPrimaryWeapon,
            SidVipVipTraitsSecondaryWeapon,
            IntVipVipTraitsGrenadeCount,
            IntVipVipTraitsGrenadeRecharge,
            IntVipVipTraitsInfiniteAmmo,
            IntVipVipTraitsWeaponPickup,
            IntVipVipTraitsSpeed,
            IntVipVipTraitsGravity,
            IntVipVipTraitsVehicleUse,
            IntVipVipTraitsSensor,
            IntVipVipTraitsSensorRange,
            IntVipVipTraitsWaypoint,
            IntVipVipTraitsActiveCamo,
            IntVipVipTraitsVisualAura,
            IntVipVipTraitsForcedColor,
            IntJuggernautScoreToWin,
            IntJuggernautKillPoints,
            IntJuggernautJuggyKillPoints,
            IntJuggernautKillAsJuggyPoints,
            IntJuggernautZoneArrivalPoints,
            IntJuggernautSuicidePoints,
            IntJuggernautBetrayalPoints,
            IntJuggernautInitialJuggySelection,
            IntJuggernautNextJuggySelection,
            IntJuggernautAlliedAgainstJuggy,
            IntJuggernautNextJuggyDelay,
            IntJuggernautZonesEnabled,
            IntJuggernautZoneMovement,
            IntJuggernautZoneOrder,
            IntJuggernautRespawnOnLoneJuggy,
            IntJuggernautJuggernautTraitsDamageResistance,
            IntJuggernautJuggernautTraitsShieldMultiplier,
            IntJuggernautJuggernautTraitsShieldRecharge,
            IntJuggernautJuggernautTraitsHeadshotImmunity,
            IntJuggernautJuggernautTraitsVampirism,
            IntJuggernautJuggernautTraitsDamageModifier,
            SidJuggernautJuggernautTraitsPrimaryWeapon,
            SidJuggernautJuggernautTraitsSecondaryWeapon,
            IntJuggernautJuggernautTraitsGrenadeCount,
            IntJuggernautJuggernautTraitsGrenadeRecharge,
            IntJuggernautJuggernautTraitsInfiniteAmmo,
            IntJuggernautJuggernautTraitsWeaponPickup,
            IntJuggernautJuggernautTraitsSpeed,
            IntJuggernautJuggernautTraitsGravity,
            IntJuggernautJuggernautTraitsVehicleUse,
            IntJuggernautJuggernautTraitsSensor,
            IntJuggernautJuggernautTraitsSensorRange,
            IntJuggernautJuggernautTraitsWaypoint,
            IntJuggernautJuggernautTraitsActiveCamo,
            IntJuggernautJuggernautTraitsVisualAura,
            IntJuggernautJuggernautTraitsForcedColor,
            IntUnknownTraitsDamageResistance,
            IntUnknownTraitsShieldMultiplier,
            IntUnknownTraitsShieldRecharge,
            IntUnknownTraitsHeadshotImmunity,
            IntUnknownTraitsVampirism,
            IntUnknownTraitsDamageModifier,
            SidUnknownTraitsPrimaryWeapon,
            SidUnknownTraitsSecondaryWeapon,
            IntUnknownTraitsGrenadeCount,
            IntUnknownTraitsGrenadeRecharge,
            IntUnknownTraitsInfiniteAmmo,
            IntUnknownTraitsWeaponPickup,
            IntUnknownTraitsSpeed,
            IntUnknownTraitsGravity,
            IntUnknownTraitsVehicleUse,
            IntUnknownTraitsSensor,
            IntUnknownTraitsSensorRange,
            IntUnknownTraitsWaypoint,
            IntUnknownTraitsActiveCamo,
            IntUnknownTraitsVisualAura,
            IntUnknownTraitsForcedColor,
            IntAssaultArmTime,
            IntAssaultDisarmTime,
            IntAssaultFuseTime,
            IntAssaultResetTime,
            IntAssaultCarrierTraitsDamageResistance,
            IntAssaultCarrierTraitsShieldMultiplier,
            IntAssaultCarrierTraitsShieldRecharge,
            IntAssaultCarrierTraitsHeadshotImmunity,
            IntAssaultCarrierTraitsVampirism,
            IntAssaultCarrierTraitsDamageModifier,
            SidAssaultCarrierTraitsPrimaryWeapon,
            SidAssaultCarrierTraitsSecondaryWeapon,
            IntAssaultCarrierTraitsGrenadeCount,
            IntAssaultCarrierTraitsGrenadeRecharge,
            IntAssaultCarrierTraitsInfiniteAmmo,
            IntAssaultCarrierTraitsWeaponPickup,
            IntAssaultCarrierTraitsSpeed,
            IntAssaultCarrierTraitsGravity,
            IntAssaultCarrierTraitsVehicleUse,
            IntAssaultCarrierTraitsSensor,
            IntAssaultCarrierTraitsSensorRange,
            IntAssaultCarrierTraitsWaypoint,
            IntAssaultCarrierTraitsActiveCamo,
            IntAssaultCarrierTraitsVisualAura,
            IntAssaultCarrierTraitsForcedColor,
            IntAssaultUnknown,
            IntAssaultGameMode,
            IntAssaultResetOnDisarm,
            IntAssaultNewUnknown,
            IntAssaultEnemyBombWaypoint,
            IntAssaultScoreToWin,
            IntAssaultNewUnknown2,
            NulAssaultNewUnknown,
            NulAssaultNewUnknown2,
            IntAssaultSuddenDeath,
            IntEditorOpenChannelVoice,
            IntEditorEditMode,
            IntEditorRespawnTime,
            IntEditorEditorTraitsDamageResistance,
            IntEditorEditorTraitsShieldMultiplier,
            IntEditorEditorTraitsShieldRecharge,
            IntEditorEditorTraitsHeadshotImmunity,
            IntEditorEditorTraitsVampirism,
            IntEditorEditorTraitsDamageModifier,
            SidEditorEditorTraitsPrimaryWeapon,
            SidEditorEditorTraitsSecondaryWeapon,
            IntEditorEditorTraitsGrenadeCount,
            IntEditorEditorTraitsGrenadeRecharge,
            IntEditorEditorTraitsInfiniteAmmo,
            IntEditorEditorTraitsWeaponPickup,
            IntEditorEditorTraitsSpeed,
            IntEditorEditorTraitsGravity,
            IntEditorEditorTraitsVehicleUse,
            IntEditorEditorTraitsSensor,
            IntEditorEditorTraitsSensorRange,
            IntEditorEditorTraitsWaypoint,
            IntEditorEditorTraitsActiveCamo,
            IntEditorEditorTraitsVisualAura,
            IntEditorEditorTraitsForcedColor,
            IntGlobalTraitsTemplateDamageResistance,
            IntGlobalTraitsTemplateShieldMultiplier,
            IntGlobalTraitsTemplateShieldRecharge,
            IntGlobalTraitsTemplateHeadshotImmunity,
            IntGlobalTraitsTemplateVampirism,
            IntGlobalTraitsTemplateDamageModifier,
            SidGlobalTraitsTemplatePrimaryWeapon,
            SidGlobalTraitsTemplateSecondaryWeapon,
            IntGlobalTraitsTemplateGrenadeCount,
            IntGlobalTraitsTemplateGrenadeRecharge,
            IntGlobalTraitsTemplateInfiniteAmmo,
            IntGlobalTraitsTemplateWeaponPickup,
            IntGlobalTraitsTemplateSpeed,
            IntGlobalTraitsTemplateGravity,
            IntGlobalTraitsTemplateVehicleUse,
            IntGlobalTraitsTemplateSensor,
            IntGlobalTraitsTemplateSensorRange,
            IntGlobalTraitsTemplateWaypoint,
            IntGlobalTraitsTemplateActiveCamo,
            IntGlobalTraitsTemplateVisualAura,
            IntGlobalTraitsTemplateForcedColor,
        }

        [TagStructure(Size = 0x14)]
        public class TextValuePair
        {
            public byte Flags;
            public ExpectedValueTypeValue ExpectedValueType;
            public short Unknown;
            public int IntegerValue;
            public StringId StringidValue;
            public StringId Name;
            public StringId Description;

            public enum ExpectedValueTypeValue : sbyte
            {
                IntegerIndex,
                StringidReference,
                Incremental,
            }
        }
    }
}

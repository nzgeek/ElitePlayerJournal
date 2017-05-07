using Newtonsoft.Json;
using NZgeek.ElitePlayerJournal.Converters;
using System;

namespace NZgeek.ElitePlayerJournal.Events
{
    /// <summary>
    ///     Identifies all of the event types that may be present in the Elite Dangerous journal files.
    /// </summary>
    /// <remarks>
    ///     The order of items here is based on the order they appear in the official journal manuals. Each section
    ///     lists the events from version 6 of the manual first, then any new events from version 7, etc.
    /// </remarks>
    [JsonConverter(typeof(EnumConverter<EventType>))]
    public enum EventType
    {
        Unknown = 0,

        // Section 2: File Format
        FileHeader = 2000,

        // Section 3: Startup
        ClearSavedGame = 3000,
        NewCommander,
        LoadGame,
        Progress,
        Rank,
        // v9
        Cargo,
        Loadout,
        Materials,
        // v10
        Passengers,

        // Section 4: Travel
        Docked = 4000,
        DockingCancelled,
        DockingDenied,
        DockingGranted,
        DockingRequested,
        DockingTimeout,
        FSDJump,
        Liftoff,
        Location,
        SupercruiseEntry,
        SupercruiseExit,
        Touchdown,
        Undocked,
        // v9
        StartJump,

        // Section 5: Combat
        Bounty = 5000,
        CapShipBond,
        Died,
        EscapeInterdiction,
        FactionKillBond,
        HeatDamage,
        HeatWarning,
        HullDamage,
        Interdicted,
        Interdiction,
        PVPKill,
        ShieldState,

        // Section 6: Exploration
        Scan = 6000,
        MaterialCollected,
        MaterialDiscarded,
        MaterialDiscovered,
        BuyExplorationData,
        SellExplorationData,
        Screenshot,

        // Section 7: Trade
        BuyTradeData = 7000,
        CollectCargo,
        EjectCargo,
        MarketBuy,
        MarketSell,
        MiningRefined,

        // Section 8: Station Services
        BuyAmmo = 8000,
        BuyDrones,
        CommunityGoalDiscard,
        CommunityGoalJoin,
        CommunityGoalReward,
        CrewAssign,
        CrewFire,
        CrewHire,
        EngineerApply,
        EngineerCraft,
        EngineerProgress,
        FetchRemoteModule,
        MassModuleStore,
        MissionAbandoned,
        MissionAccepted,
        MissionCompleted,
        MissionFailed,
        ModuleBuy,
        ModuleRetrieve,
        ModuleSell,
        ModuleSellRemote,
        ModuleStore,
        ModuleSwap,
        PayFines,
        PayLegacyFines,
        RedeemVoucher,
        RefuelAll,
        RefuelPartial,
        Repair,
        RepairAll,
        RestockVehicle,
        ScientificResearch,
        SellDrones,
        ShipyardBuy,
        ShipyardNew,
        ShipyardSell,
        ShipyardTransfer,
        ShipyardSwap,
        // v9
        SetUserShipName,


        // Section 9: Powerplay
        PowerplayCollect = 9000,
        PowerplayDefect,
        PowerplayDeliver,
        PowerplayFastTrack,
        PowerplayJoin,
        PowerplayLeave,
        PowerplaySalary,
        PowerplayVote,
        PowerplayVoucher,

        // Section 10: Other Events
        ApproachSettlement = 10000,
        CockpitBreached,
        CommitCrime,
        Continued,
        DatalinkScan,
        DatalinkVoucher,
        DataScanned,
        DockFighter,
        DockSRV,
        FuelScoop,
        JetConeBoost,
        JetConeDamage,
        LaunchFighter,
        LaunchSRV,
        Promotion,
        RebootRepair,
        ReceiveText,
        Resurrect,
        SelfDestruct,
        SendText,
        Synthesis,
        USSDrop,
        VehicleSwitch,
        WingAdd,
        WingJoin,
        WingLeave,
        // v9
        ChangeCrewRole,
        CrewMemberJoins,
        CrewMemberQuits,
        JoinACrew,
        KickCrewMember,
        QuitACrew,
        Scanned,
        // v10
        CrewLaunchFighter,
        CrewMemberRoleChange,
        EndCrewSession,
    }

    public static class EventTypeExtensions
    {
        public static string ToEventName(this EventType eventType)
        {
            switch (eventType)
            {
                case EventType.Unknown:
                    throw new NotSupportedException("Unknown event type.");

                case EventType.FileHeader:
                    return "Fileheader";

                default:
                    return eventType.ToString();
            }
        }
    }
}

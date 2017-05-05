using Newtonsoft.Json;
using NZgeek.ElitePlayerJournal.Converters;
using System;

namespace NZgeek.ElitePlayerJournal.Events
{
    [JsonConverter(typeof(EventTypeConverter))]
    public enum EventType
    {
        Unknown = 0,

        FileHeader = 10,
        NewCommander,
        LoadGame,
        Progress,
        Location,

        Rank,
        Promotion,

        Died,
        Resurrect,

        FSDJump = 100,
        SupercruiseEntry,
        SupercruiseExit,
        USSDrop,
        ApproachSettlement,
        DockingRequested,
        DockingCancelled,
        DockingGranted,
        DockingDenied,
        Docked,
        Undocked,
        Touchdown,
        Liftoff,
        LaunchSRV,
        DockSRV,
        FuelScoop,
        Scan,

        MissionAccepted = 200,
        MissionCompleted,
        MissionAbandoned,
        MissionFailed,
        CommunityGoalJoin,
        CommunityGoalReward,
        Bounty,
        FactionKillBond,
        RedeemVoucher,
        BuyExplorationData,
        SellExplorationData,

        MarketBuy,
        MarketSell,
        CollectCargo,
        EjectCargo,
        MaterialDiscovered,
        MaterialCollected,
        MaterialDiscarded,
        MiningRefined,
        Synthesis,

        ShipyardNew,
        ShipyardBuy,
        ShipyardSwap,
        ShipyardTransfer,
        ShipyardSell,
        ModuleBuy,
        ModuleSell,
        ModuleSellRemote,
        ModuleStore,
        ModuleRetrieve,
        FetchRemoteModule,

        BuyAmmo,
        RefuelAll,
        RepairAll,
        Repair,
        BuyDrones,

        EngineerProgress,
        EngineerCraft,
        EngineerApply,

        DataScanned,
        DatalinkScan,
        DatalinkVoucher,

        ReceiveText = 400,
        SendText,
        WingJoin,
        WingAdd,
        WingLeave,

        Interdiction,
        Interdicted,
        EscapeInterdiction,

        HullDamage,
        ShieldState,
        HeatWarning,
        RebootRepair,
        CockpitBreached,

        CommitCrime,
        PayFines,
        PayLegacyFines,

        Screenshot = 10000,
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

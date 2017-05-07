using Newtonsoft.Json;
using NZgeek.ElitePlayerJournal.Events;
using System;
using System.Collections.Generic;

namespace NZgeek.ElitePlayerJournal
{
    internal static class EventFactory
    {
        private static readonly Dictionary<EventType, Type> EventClasses = new Dictionary<EventType, Type>
        {
            // Startup
            { EventType.Cargo, typeof(Events.Startup.Cargo) },
            { EventType.ClearSavedGame, typeof(Events.Startup.ClearSavedGame) },
            { EventType.LoadGame, typeof(Events.Startup.LoadGame) },
            { EventType.Loadout, typeof(Events.Startup.Loadout) },
            { EventType.Materials, typeof(Events.Startup.Materials) },
            { EventType.NewCommander, typeof(Events.Startup.NewCommander) },
            { EventType.Passengers, typeof(Events.Startup.Passengers) },
            { EventType.Progress, typeof(Events.Startup.Progress) },
            { EventType.Rank, typeof(Events.Startup.Rank) },
            // Travel
            { EventType.Docked, typeof(Events.Travel.Docked) },
            { EventType.DockingCancelled, typeof(Events.Travel.DockingEvent) },
            { EventType.DockingDenied, typeof(Events.Travel.DockingDenied) },
            { EventType.DockingGranted, typeof(Events.Travel.DockingGranted) },
            { EventType.DockingRequested, typeof(Events.Travel.DockingEvent) },
            { EventType.DockingTimeout, typeof(Events.Travel.DockingEvent) },
            { EventType.FSDJump, typeof(Events.Travel.FrameShiftJump) },
            { EventType.Location, typeof(Events.Travel.Location) },
            { EventType.SupercruiseExit, typeof(Events.Travel.SupercruiseExit) },
            // Combat
            // Exploration
            { EventType.Screenshot, typeof(Events.Exploration.Screenshot) },
            // Trade
            // Station Services
            // Powerplay
            // Other events
            { EventType.ReceiveText, typeof(Events.Other.ReceiveText) },
            { EventType.SendText, typeof(Events.Other.SendText) },
        };

        public static Event CreateEvent(JournalFile journalFile, int lineNumber, string eventData)
        {
            var basicEvent = JsonConvert.DeserializeObject<EventBase>(eventData);

            var resultEvent = CreateEvent(journalFile, lineNumber, basicEvent.Type);
            resultEvent.LoadJson(eventData);
            return resultEvent;
        }

        public static Event CreateEvent(JournalFile journalFile, int lineNumber, EventType eventType)
        {
            if (!EventClasses.TryGetValue(eventType, out Type eventClass))
                eventClass = typeof(Event);

            var journalEvent = (Event)Activator.CreateInstance(eventClass);
            journalEvent.JournalFile = journalFile;
            journalEvent.LineNumber = lineNumber;
            return journalEvent;
        }
    }
}

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
            { EventType.FSDJump, typeof(FrameShiftJump) },
            { EventType.LoadGame, typeof(LoadGame) },
            { EventType.Screenshot, typeof(Screenshot) },
            { EventType.SupercruiseExit, typeof(SupercruiseExit) },
        };

        public static Event CreateEvent(JournalFile journalFile, int lineNumber, string eventData)
        {
            var basicEvent = CreateEvent(journalFile, lineNumber, EventType.Unknown);
            JsonConvert.PopulateObject(eventData, basicEvent);
            if (!EventClasses.ContainsKey(basicEvent.Type))
                return basicEvent;

            var resultEvent = CreateEvent(journalFile, lineNumber, basicEvent.Type);
            JsonConvert.PopulateObject(eventData, resultEvent);
            return resultEvent;
        }

        public static Event CreateEvent(JournalFile journalFile, int lineNumber, EventType eventType)
        {
            if (!EventClasses.TryGetValue(eventType, out Type eventClass))
                eventClass = typeof(Event);

            var returnEvent = (Event)Activator.CreateInstance(eventClass);

            returnEvent.JournalFile = journalFile;
            returnEvent.LineNumber = lineNumber;
            return returnEvent;
        }
    }
}

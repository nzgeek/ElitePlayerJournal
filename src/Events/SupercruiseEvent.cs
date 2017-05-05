﻿using Newtonsoft.Json;

namespace NZgeek.ElitePlayerJournal.Events
{
    public abstract class SupercruiseEvent : Event
    {
        protected SupercruiseEvent(EventType eventType)
            : base(eventType)
        {
        }

        [JsonProperty("StarSystem")]
        public string SystemName { get; set; }
    }
}
using Newtonsoft.Json;

namespace NZgeek.ElitePlayerJournal.Events
{
    public class FileHeader : Event
    {
        [JsonProperty("part")]
        public int Part { get; private set; }

        [JsonProperty("language")]
        public string Language { get; private set; }

        [JsonProperty("gameversion")]
        public string GameVersion { get; private set; }

        [JsonProperty("build")]
        public string Build { get; private set; }

        public override string ToString() => $"{base.ToString()} => {Language} / {GameVersion} build {Build}";
    }
}

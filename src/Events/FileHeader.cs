using Newtonsoft.Json;

namespace NZgeek.ElitePlayerJournal.Events
{
    public class FileHeader : Event
    {
        public FileHeader()
            : base(EventType.FileHeader)
        {
        }

        [JsonProperty("part")]
        public int Part { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("gameversion")]
        public string GameVersion { get; set; }

        [JsonProperty("build")]
        public string Build { get; set; }

        public override string ToString() => $"{base.ToString()} => {Language} / {GameVersion} build {Build}";
    }
}

using Newtonsoft.Json;
using System;
using System.IO;

namespace NZgeek.ElitePlayerJournal.Events.Exploration
{
    public class Screenshot : Event
    {
        public Screenshot()
            : base(EventType.Screenshot)
        {
        }

        [JsonProperty("Filename")]
        public string RawFileName { get; set; }

        [JsonProperty("Width")]
        public int Width { get; set; }

        [JsonProperty("Height")]
        public int Height { get; set; }

        [JsonProperty("System")]
        public string SystemName { get; set; }

        [JsonProperty("Body")]
        public string Body { get; set; }

        public string FileName => Path.GetFileName(RawFileName);

        public string FilePath
        {
            get
            {
                if (JournalFile == null) throw new InvalidOperationException();
                return Path.Combine(JournalFile.Journal.ScreenShotFolder, FileName);
            }
        }

        public override string ToString() => $"{base.ToString()} => \"{RawFileName}\" ({Width}x{Height})";
    }
}

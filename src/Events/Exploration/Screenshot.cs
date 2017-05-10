using Newtonsoft.Json;
using System;
using System.IO;

namespace NZgeek.ElitePlayerJournal.Events.Exploration
{
    public class Screenshot : Event
    {
        [JsonProperty("Filename")]
        public string RawFileName { get; private set; }

        [JsonProperty("Width")]
        public int Width { get; private set; }

        [JsonProperty("Height")]
        public int Height { get; private set; }

        [JsonProperty("System")]
        public string SystemName { get; private set; }

        [JsonProperty("Body")]
        public string Body { get; private set; }

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

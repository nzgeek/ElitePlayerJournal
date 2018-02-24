using NZgeek.ElitePlayerJournal.Events;
using System;
using System.Collections.Generic;
using System.IO;

namespace NZgeek.ElitePlayerJournal
{
    public class Journal
    {
        private SortedSet<JournalFile> _journalFiles;

        public Journal()
        {
            var userHome = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            JournalFolder = Path.Combine(userHome, "Saved Games", "Frontier Developments", "Elite Dangerous");

            var pictures = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            ScreenShotFolder = Path.Combine(pictures, "Frontier Developments", "Elite Dangerous");

            Console.WriteLine("Journal Folder:    " + JournalFolder);
            Console.WriteLine("Screenshot Folder: " + ScreenShotFolder);
        }

        public string JournalFolder { get; set; }

        public string ScreenShotFolder { get; set; }

        public void Load()
        {
            var journalDir = new DirectoryInfo(JournalFolder);
            var journalFiles = new SortedSet<JournalFile>();

            foreach (var journalFileInfo in journalDir.GetFiles("Journal.*.log"))
            {
                try
                {
                    var journalFile = new JournalFile(this, journalFileInfo);
                    journalFiles.Add(journalFile);
                }
                catch (JournalException)
                {
                }
            }

            _journalFiles = journalFiles;
        }


        public IEnumerable<Event> FindEvents(params EventType[] eventTypes)
        {
            return FindEvents(DateTime.MinValue, DateTime.MaxValue, eventTypes);
        }

        public IEnumerable<Event> FindEvents(DateTime fromDate, DateTime toDate, params EventType[] eventTypes)
        {
            if (eventTypes == null) throw new ArgumentNullException(nameof(eventTypes));

            Console.WriteLine("Action: Find events - " + string.Join(", ", eventTypes));
            foreach (var journalFile in _journalFiles)
            {
                Console.WriteLine("    searching " + journalFile.File.Name);
                var firstPossibleEvent = journalFile.GameStarted;
                var lastPossibleEvent = firstPossibleEvent + TimeSpan.FromDays(1);

                if (firstPossibleEvent > toDate || lastPossibleEvent < fromDate)
                    continue;

                foreach (var gameEvent in journalFile.FindEvents(fromDate, toDate, eventTypes))
                    yield return gameEvent;
            }
        }

        public Event FindPrevious(Event fromEvent, params EventType[] eventTypes)
        {
            if (fromEvent == null) throw new ArgumentNullException(nameof(fromEvent));
            if (eventTypes == null) throw new ArgumentNullException(nameof(eventTypes));
            if (eventTypes.Length == 0) throw new ArgumentException("At least one event type is required.", nameof(eventTypes));

            return null;
        }

        public Event FindNext(Event fromEvent, params EventType[] eventTypes)
        {
            if (fromEvent == null) throw new ArgumentNullException(nameof(fromEvent));
            if (eventTypes == null) throw new ArgumentNullException(nameof(eventTypes));
            if (eventTypes.Length == 0) throw new ArgumentException("At least one event type is required.", nameof(eventTypes));

            return null;
        }
    }
}

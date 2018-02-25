using Newtonsoft.Json;
using NZgeek.ElitePlayerJournal.Events;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace NZgeek.ElitePlayerJournal
{
    internal class JournalFile : IComparable<JournalFile>, IEnumerable<Event>
    {
        private static Regex _fileNameParser = new Regex(@"^Journal\.(?<date>\d{12})\.(?<part>\d{2})\.log$",
            RegexOptions.CultureInvariant | RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Compiled);

        private SortedList<Event, Event> _events;

        public JournalFile(Journal journal, FileInfo file)
        {
            var match = _fileNameParser.Match(file.Name);
            if (!match.Success)
                throw new JournalException("Invalid journal file \"{0}\".", file.Name);

            Journal = journal;
            File = file;

            GameStartedLocal = DateTime.ParseExact(match.Groups["date"].Value, "yyMMddHHmmss", CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal);
            GameStarted = GameStartedLocal.ToUniversalTime();

            Part = int.Parse(match.Groups["part"].Value, CultureInfo.InvariantCulture);

            Header = LoadHeader();
        }

        public Journal Journal { get; }

        public FileInfo File { get; }

        public DateTime GameStarted { get; }

        public DateTime GameStartedLocal { get; }

        public int Part { get; }

        public FileHeader Header { get; }

        private void LoadEvents()
        {
            if (_events != null)
                return;

            var events = new SortedList<Event, Event>();

            using (var journalStream = new FileStream(File.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (var reader = new StreamReader(journalStream, Encoding.UTF8, true))
                {
                    reader.ReadLine();
                    var lineNumber = 1;

                    string eventData;
                    while ((eventData = reader.ReadLine()) != null)
                    {
                        ++lineNumber;

                        if (string.IsNullOrWhiteSpace(eventData))
                            continue;

                        var gameEvent = EventFactory.CreateEvent(this, lineNumber, eventData);
                        if (gameEvent != null) events.Add(gameEvent, gameEvent);
                    }
                }
            }

            _events = events;
        }

        private FileHeader LoadHeader()
        {
            try
            {
                using (var journalStream = new FileStream(File.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (var reader = new StreamReader(journalStream, Encoding.UTF8, true))
                    {
                        var headerLine = reader.ReadLine();
                        if (string.IsNullOrEmpty(headerLine))
                            throw new JournalException("Missing journal header.");

                        var header = JsonConvert.DeserializeObject<FileHeader>(headerLine);
                        if (header.Part != Part)
                            throw new JournalException("Header does not match file name.");

                        header.JournalFile = this;
                        header.LineNumber = 1;
                        return header;
                    }
                }
            }
            catch (JournalException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new JournalException(ex, "Failed to reader journal header.");
            }
        }

        public int CompareTo(JournalFile other)
        {
            return StringComparer.InvariantCultureIgnoreCase.Compare(File.Name, other.File.Name);
        }

        public IEnumerator<Event> GetEnumerator()
        {
            LoadEvents();

            return _events.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerable<Event> FindEvents(DateTime fromDate, DateTime toDate, EventType[] eventTypes)
        {
            if (eventTypes == null) throw new ArgumentNullException(nameof(eventTypes));

            LoadEvents();

            if (_events.Count == 0)
                yield break;

            var firstEvent = _events.Values[0];
            var lastEvent = _events.Values[_events.Count - 1];

            if (toDate < firstEvent.Timestamp || fromDate > lastEvent.Timestamp)
                yield break;

            eventTypes = eventTypes ?? new EventType[0];

            foreach (var gameEvent in _events.Values)
            {
                if (gameEvent.Timestamp < fromDate)
                    continue;

                if (gameEvent.Timestamp > toDate)
                    break;

                if (eventTypes.Length == 0 || eventTypes.Contains(gameEvent.Type))
                    yield return gameEvent;
            }
        }

        public Event FindForwards(EventType[] eventTypes)
        {
            return FindForwards(0, eventTypes);
        }

        public Event FindForwards(Event fromEvent, EventType[] eventTypes)
        {
            if (fromEvent == null) throw new ArgumentNullException(nameof(fromEvent));
            if (fromEvent.JournalFile != this) throw new ArgumentException("Journal entry belongs to a different file.");

            var entryIndex = _events.IndexOfValue(fromEvent);
            if (entryIndex < 0)
                throw new JournalException("Journal event not found in file.");

            return FindForwards(entryIndex + 1, eventTypes);
        }

        private Event FindForwards(int fromIndex, EventType[] eventTypes)
        {
            if (eventTypes == null) throw new ArgumentNullException(nameof(eventTypes));
            if (eventTypes.Length == 0) throw new ArgumentException("At least one event type is required.", nameof(eventTypes));

            LoadEvents();

            for (var index = fromIndex; index < _events.Count; ++index)
            {
                var gameEvent = _events.Values[index];
                if (eventTypes.Contains(gameEvent.Type))
                    return gameEvent;
            }

            return null;
        }

        public Event FindBackwards(EventType[] eventTypes)
        {
            return FindForwards(_events.Count - 1, eventTypes);
        }

        public Event FindBackwards(Event fromEvent, EventType[] eventTypes)
        {
            if (fromEvent == null) throw new ArgumentNullException(nameof(fromEvent));
            if (fromEvent.JournalFile != this) throw new ArgumentException("Journal entry belongs to a different file.");

            var entryIndex = _events.IndexOfValue(fromEvent);
            if (entryIndex < 0)
                throw new JournalException("Journal event not found in file.");

            return FindBackwards(entryIndex - 1, eventTypes);
        }

        private Event FindBackwards(int fromIndex, EventType[] eventTypes)
        {
            if (eventTypes == null) throw new ArgumentNullException(nameof(eventTypes));
            if (eventTypes.Length == 0) throw new ArgumentException("At least one event type is required.", nameof(eventTypes));

            LoadEvents();

            for (var index = fromIndex; index >= 0; --index)
            {
                var gameEvent = _events.Values[index];
                if (eventTypes.Contains(gameEvent.Type))
                    return gameEvent;
            }

            return null;
        }
    }
}

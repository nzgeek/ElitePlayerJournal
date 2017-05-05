using System;
using System.Runtime.Serialization;

namespace NZgeek.ElitePlayerJournal
{
    public class JournalException : ApplicationException
    {
        public JournalException(string message)
            : base(message)
        {
        }

        public JournalException(string format, params object[] args)
            : base(string.Format(format, args))
        {
        }

        public JournalException(Exception innerException, string message)
            : base(message, innerException)
        {
        }

        public JournalException(Exception innerException, string format, params object[] args)
            : base(string.Format(format, args), innerException)
        {
        }

        protected JournalException(SerializationInfo serializationInfo, StreamingContext streamingContext)
            : base(serializationInfo, streamingContext)
        {
        }
    }
}

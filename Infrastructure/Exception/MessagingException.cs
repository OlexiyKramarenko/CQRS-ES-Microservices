using System;

namespace Infrastructure
{
    public class MessagingException : Exception
    {
        public MessagingExceptionType Type { get; }
        public Type SourceType { get; }

        public MessagingException(MessagingExceptionType type,
                                        Type sourceType = null,
                                        string message = null)
            : base(message)
        {
            Type = type;
            SourceType = sourceType;
        }
    }

    public enum MessagingExceptionType
    {
        NullCommand = 0,
        NullEvent = 1,
        InvalidCommand = 2,
        InvalidEvent = 3,
        EventStoreConcurency = 4,
        AggregateNotFound = 5,
        AggregateDeleted = 6
    }
}

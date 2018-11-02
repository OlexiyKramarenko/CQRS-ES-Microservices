using Infrastructure.Domain;
using System;

namespace Articles.WriteSide.Aggregates
{
    public class FailedReadSideEvent : AggregateRoot
    {
        public string Data { get; set; }

        public FailedReadSideEvent()
        {

        }

        public FailedReadSideEvent(Guid id, string data)
        {
            Id = id;
            Data = data;
        }
    }
}

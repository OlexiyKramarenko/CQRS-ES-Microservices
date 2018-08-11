using Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Text;

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

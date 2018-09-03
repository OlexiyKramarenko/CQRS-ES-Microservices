using System;

namespace Articles.Saga.Events.ToSaga.Interfaces
{
	public class ISagaFailedEvent
    {
		public Guid CorrelationId { get; set; }
		public string Data { get; set; } 
    }
}

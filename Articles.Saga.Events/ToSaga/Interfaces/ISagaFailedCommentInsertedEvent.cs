using System;

namespace Articles.Saga.Events.ToSaga.Interfaces
{
	public class ISagaFailedCommentInsertedEvent
    {
		public Guid CorrelationId { get; set; }
		public string Data { get; set; } 
    }
}

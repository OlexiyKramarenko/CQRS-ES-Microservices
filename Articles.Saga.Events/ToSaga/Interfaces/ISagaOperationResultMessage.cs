using System;

namespace Articles.Saga.Events.ToSaga.Interfaces
{
	public class ISagaOperationResultMessage
	{
		public Guid CorrelationId { get; set; }
		public string Name { get; set; }
	}
}

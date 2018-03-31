using System;

namespace Store.WriteSide.Events.ToSaga
{
	public class OrderDeletedEvent : IOrderDeletedEvent
	{
		public Guid AggregateId { get; set; }
	}
}

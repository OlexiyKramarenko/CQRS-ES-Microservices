using System;

namespace Store.WriteSide.Events.ToSaga
{
	public class OrderStatusDeletedEvent : IOrderStatusDeletedEvent
	{
		public Guid AggregateId { get; set; }
	}
}

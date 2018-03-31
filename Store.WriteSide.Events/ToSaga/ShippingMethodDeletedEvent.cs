using System;

namespace Store.WriteSide.Events.ToSaga
{
	public class ShippingMethodDeletedEvent : IShippingMethodDeletedEvent
	{
		public Guid AggregateId { get; set; }
	}
}

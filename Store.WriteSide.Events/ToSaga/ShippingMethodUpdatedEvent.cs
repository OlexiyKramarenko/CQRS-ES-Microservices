using System;

namespace Store.WriteSide.Events.ToSaga
{
	public class ShippingMethodUpdatedEvent : IShippingMethodUpdatedEvent
	{
		public string Title { get; set; }
		public decimal Price { get; set; } 
		public Guid AggregateId { get; set; }
	}
}

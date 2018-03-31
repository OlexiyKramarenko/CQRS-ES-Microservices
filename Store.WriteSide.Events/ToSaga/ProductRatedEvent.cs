using System;

namespace Store.WriteSide.Events.ToSaga
{
	public class ProductRatedEvent : IProductRatedEvent
	{
		public int Rating { get; set; }

		public Guid AggregateId { get; set; }
	}
}

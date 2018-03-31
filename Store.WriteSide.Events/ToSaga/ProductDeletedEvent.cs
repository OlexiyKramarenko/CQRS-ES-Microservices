using System;

namespace Store.WriteSide.Events.ToSaga
{
	public class ProductDeletedEvent : IProductDeletedEvent
	{
		public Guid AggregateId { get; set; }
	}
}

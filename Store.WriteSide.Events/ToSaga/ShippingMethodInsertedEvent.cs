using System;

namespace Store.WriteSide.Events.ToSaga
{
	public	class ShippingMethodInsertedEvent : IShippingMethodInsertedEvent
	{
		public DateTime AddedDate { get; set; }
		public string AddedBy { get; set; }
		public string Title { get; set; }
		public decimal Price { get; set; }
		public string Description { get; set; }
		public Guid AggregateId { get; set; }
	}
}

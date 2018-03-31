using System;

namespace Store.WriteSide.Events.ToSaga
{
	public class OrderItemInsertedEvent : IOrderItemInsertedEvent
	{
		public Guid AggregateId { get; set; }
		public DateTime AddedDate { get; set; }
		public string AddedBy { get; set; }
		public Guid OrderId { get; set; }
		public Guid ProductId { get; set; }
		public string Title { get; set; }
		public string SKU { get; set; }
		public decimal UnitPrice { get; set; }
		public int Quantity { get; set; }		
	}
}

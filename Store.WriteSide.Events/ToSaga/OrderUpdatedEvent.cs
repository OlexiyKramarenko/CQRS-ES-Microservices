using System;

namespace Store.WriteSide.Events.ToSaga
{
	public class OrderUpdatedEvent : IOrderUpdatedEvent
	{
		public Guid StatusId { get; set; }
		public string TransactionId { get; set; }
		public DateTime? ShippedDate { get; set; }
		public string TrackingId { get; set; }

		public Guid AggregateId { get; set; }
	}
}

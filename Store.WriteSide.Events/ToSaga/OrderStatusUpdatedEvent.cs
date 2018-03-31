using System;

namespace Store.WriteSide.Events.ToSaga
{
	public class OrderStatusUpdatedEvent : IOrderStatusUpdatedEvent
	{
		public DateTime AddedDate { get; set; }
		public string AddedBy { get; set; }
		public string Title { get; set; }

		public Guid AggregateId { get; set; }
	}
}

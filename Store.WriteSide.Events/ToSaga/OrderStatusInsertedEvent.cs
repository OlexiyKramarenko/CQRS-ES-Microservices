using System;

namespace Store.WriteSide.Events.ToSaga
{
	public class OrderStatusInsertedEvent : IOrderStatusInsertdEvent
	{
		public DateTime AddedDate { get; set; }
		public string AddedBy { get; set; }
		public string Title { get; set; }

		public Guid AggregateId { get; set; }
	}
}

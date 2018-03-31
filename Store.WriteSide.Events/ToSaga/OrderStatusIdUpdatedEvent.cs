using System; 

namespace Store.WriteSide.Events.ToSaga
{
	public class OrderStatusIdUpdatedEvent : IOrderStatusIdUpdatedEvent
	{
		public Guid StatusId { get; set; }

		public Guid AggregateId { get; set; }
	}
}

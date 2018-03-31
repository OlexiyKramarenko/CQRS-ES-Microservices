using Infrastructure.Contracts;
using System;

namespace Store.WriteSide.Events
{
	public interface IOrderUpdatedEvent : IEvent
	{
		Guid StatusId { get; set; }
		string TransactionId { get; set; }
		DateTime? ShippedDate { get; set; }
		string TrackingId { get; set; }
	}
}

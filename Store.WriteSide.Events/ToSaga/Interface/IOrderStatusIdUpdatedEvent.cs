using Infrastructure.Contracts;
using System;

namespace Store.WriteSide.Events
{
	public interface IOrderStatusIdUpdatedEvent : IEvent
	{
		Guid StatusId { get; set; }
	}
}

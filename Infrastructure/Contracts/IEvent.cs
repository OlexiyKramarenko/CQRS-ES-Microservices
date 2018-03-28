using System;

namespace Infrastructure.Contracts
{
	public interface IEvent
	{
		Guid AggregateId { get; }
	}
}

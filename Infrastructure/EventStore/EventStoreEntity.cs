using System;

namespace Infrastructure.EventStore
{
	public class EventStoreEntity
	{
		public Guid Id { get; set; }

		public Guid AggregateId { get; set; }
		
		public string Data { get; set; }
		
		public string EventType { get; set; }

		public DateTime CreatedDate { get; set; }

		public int Version { get; set; }

		public EventStoreEntity()
		{
			Id = Guid.NewGuid();
			CreatedDate = DateTime.UtcNow;
		}
	}
}

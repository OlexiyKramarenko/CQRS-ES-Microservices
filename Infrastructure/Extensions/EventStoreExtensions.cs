using Infrastructure.Contracts;
using Infrastructure.EventStore;
using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Reflection;

namespace Shared.Extensions
{
	public static class EventStoreExtensions
	{
		public static IEnumerable<EventStoreEntity> AsEventStoreEntities(this IEnumerable<IEvent> aggregateEvents) =>
			aggregateEvents.Select(aggregateEvent => new EventStoreEntity
			{
				AggregateId = aggregateEvent.AggregateId,
				Data = JsonConvert.SerializeObject(aggregateEvent),
				EventType = aggregateEvent.GetType().ToString()
			});

		public static IEnumerable<IEvent> AsAggregateEvents(this IEnumerable<EventStoreEntity> eventStoreEntities, Assembly assembly)
		{
			Type serializerType = typeof(JsonConvert);

			foreach (EventStoreEntity entity in eventStoreEntities)
			{
				Type eventType = assembly.GetType(entity.EventType);
				
				IEvent @event = (IEvent)serializerType.GetMethod(nameof(JsonConvert.DeserializeObject),
																 new[] { typeof(string) })
													  .MakeGenericMethod(eventType)
													  .Invoke(null, new[] { entity.Data });
				yield return @event;
			}
		}
	}
}

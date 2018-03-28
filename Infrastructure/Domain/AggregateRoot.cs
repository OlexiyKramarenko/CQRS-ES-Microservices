using Infrastructure.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Domain
{
	public abstract class AggregateRoot : IAggregateRoot
	{
		public Guid Id { get; protected set; }

		public int Version { get; protected set; } = -1;

		public List<IEvent> GetUncommittedEvents() => Events;

		public void MarkEventsAsCommitted() => Events.Clear();

		protected List<IEvent> Events { get; set; } = new List<IEvent>();

		public virtual void LoadFromHistory(IEnumerable<IEvent> events)
		{
			foreach (var @event in events)
			{ 
				this.ApplyChange(@event, false);
			}
		}
		 
		protected void ApplyChange(IEvent @event, bool isNew = true)
		{
			Type eventType = @event.GetType();
			 
			Type handleType = typeof(IHandle<>).MakeGenericType(eventType);
			 
			handleType.GetMethod(nameof(IHandle<IEvent>.Handle), new[] { eventType })
					  .Invoke(this, new object[] { @event });

			if (isNew)
				Events.Add(@event);
		}
	}
}

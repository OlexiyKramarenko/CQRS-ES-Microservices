using Articles.WriteSide.Events.ToSaga;
using Articles.WriteSide.Repository.Enums;
using Articles.WriteSide.Repository.Exceptions;
using Infrastructure.Contracts;
using Infrastructure.DataAccess;
using Infrastructure.Domain;
using Infrastructure.EventStore;
using Microsoft.EntityFrameworkCore;
using Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Linq; 
using System.Threading.Tasks;

namespace Articles.WriteSide.Repository
{
   public class ArticlesEventRepository : IEventRepository
	{
		ArticlesEventContext DbContext { get; }

		static readonly object EventStoreLocker = new object();

		public ArticlesEventRepository(ArticlesEventContext context)
		{
			DbContext = context;
		}
		
		public async Task PersistAsync<TAggregate>(TAggregate aggregate)
			where TAggregate : class, IAggregateRoot
		{
			List<IEvent> aggregateEvents = aggregate.GetUncommittedEvents();
			
			IEnumerable<EventStoreEntity> eventStoreEntities = aggregateEvents.AsEventStoreEntities();

			lock (EventStoreLocker)
			{
				int aggregateVersion = aggregate.Version;

				if (aggregateVersion != -1)
				{
					CheckAggregateVersion(aggregate.Id, aggregateVersion);
				}
				
				foreach (EventStoreEntity @event in eventStoreEntities)
				{
					@event.Version = ++aggregateVersion;
					DbContext.Events.Add(@event);
				}
			}

			await DbContext.SaveChangesAsync();
		}
		
		public async Task<TAggregate> GetByIdAsync<TAggregate>(Guid id)
			where TAggregate : IAggregateRoot, new()
		{
			List<EventStoreEntity> eventEntities = await DbContext.Events
														 .Where(e => e.AggregateId == id)
														 .AsNoTracking()
														 .OrderBy(e => e.CreatedDate)
														 .ToListAsync();
			if (!eventEntities.Any())
			{
				throw new ArticlesException(
					ArticlesExceptionType.AggregateNotFound,
					typeof(TAggregate));
			}

			var aggregate = new TAggregate();
			
			IEnumerable<IEvent> events = eventEntities.AsAggregateEvents(typeof(ArticleApprovedEvent).Assembly);
			
			aggregate.LoadFromHistory(events);

			return aggregate;
		}
		
		private void CheckAggregateVersion(Guid aggregateId, int verifiableVersion)
		{
			int currentAggregateVersion = DbContext.Events
												   .Where(e => e.AggregateId == aggregateId)
												   .Max(e => e.Version);

			if (verifiableVersion != currentAggregateVersion)
			{
				throw new ArticlesException(ArticlesExceptionType.EventStoreConcurency);
			}
		}
	}
}

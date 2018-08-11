using System;
using Articles.WriteSide.Events.ToSaga.Interfaces;

namespace Articles.WriteSide.Events.ToSaga
{
	public class SagaArticleDeletedEvent : ISagaArticleDeletedEvent
	{
		public Guid AggregateId { get; set; } 
	}
}

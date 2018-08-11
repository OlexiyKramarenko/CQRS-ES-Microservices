using Articles.WriteSide.Events.ToSaga.Interfaces;
using System;

namespace Articles.WriteSide.Events.ToSaga
{
	public class SagaArticleViewCountIncrementedEvent : ISagaArticleViewCountIncrementedEvent
	{
		public Guid AggregateId { get; set; }
	}
}

using Articles.WriteSide.Events.ToSaga.Interfaces;
using System;

namespace Articles.WriteSide.Events.ToSaga
{
	public class SagaArticleApprovedEvent : ISagaArticleApprovedEvent
	{
		public Guid AggregateId { get; set; }
	}
}

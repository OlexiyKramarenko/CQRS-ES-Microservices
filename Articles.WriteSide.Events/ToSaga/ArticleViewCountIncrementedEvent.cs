using Articles.WriteSide.Events.ToSaga.Interfaces;
using System;

namespace Articles.WriteSide.Events.ToSaga
{
	public class ArticleViewCountIncrementedEvent : IArticleViewCountIncrementedEvent
	{
		public Guid AggregateId { get; set; }
	}
}

using System;
using Articles.WriteSide.Events.ToSaga.Interfaces;

namespace Articles.WriteSide.Events.ToSaga
{
	public class ArticleDeletedEvent : IArticleDeletedEvent
	{
		public Guid AggregateId { get; set; } 
	}
}

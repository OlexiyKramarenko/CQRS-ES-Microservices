using Articles.WriteSide.Events.ToSaga.Interfaces;
using System;

namespace Articles.WriteSide.Events.ToSaga
{
	public class ArticleApprovedEvent : IArticleApprovedEvent
	{
		public Guid AggregateId { get; set; }
	}
}

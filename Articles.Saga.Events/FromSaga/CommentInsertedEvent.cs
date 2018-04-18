using Articles.Saga.Events.Interfaces;
using System;

namespace Articles.Saga.Events
{
	public class CommentInsertedEvent : ICommentInsertedEvent
	{
		private readonly ArticleSagaState sagaState;

		public CommentInsertedEvent(ArticleSagaState sagaState)
		{
			this.sagaState = sagaState;
		}

		public Guid CorrelationId => sagaState.CorrelationId;
		public DateTime AddedDate => sagaState.AddedDate;
		public string AddedBy => sagaState.AddedBy;
		public string AddedByEmail => sagaState.AddedByEmail;
		public string AddedByIp => sagaState.AddedByIp;
		public string Body => sagaState.Body;
		public Guid ArticleId => sagaState.ArticleId;
		public Guid AggregateId => sagaState.AggregateId;
	}
}

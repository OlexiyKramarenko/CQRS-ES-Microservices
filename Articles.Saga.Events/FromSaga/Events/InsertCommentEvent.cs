using Articles.Saga.Events.Interfaces;
using Articles.Saga.Events.FromSaga.States;
using System;

namespace Articles.Saga.Events
{
	public class InsertCommentEvent : IInsertCommentEvent
	{
		private readonly InsertCommentSagaState sagaState;

		public InsertCommentEvent(InsertCommentSagaState sagaState)
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
        public Guid CategoryId => sagaState.CategoryId;
        public Guid AggregateId => sagaState.AggregateId;
	}
}

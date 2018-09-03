using Automatonymous;
using System;

namespace Articles.Saga.Events.FromSaga.States
{
    public class InsertCommentSagaState : SagaStateMachineInstance
    {
        public Guid CorrelationId { get; set; }
        public State CurrentState { get; set; }

        public DateTime AddedDate { get; set; }
        public string AddedBy { get; set; }
        public string AddedByEmail { get; set; }
        public string AddedByIp { get; set; }
        public string Body { get; set; }
        public Guid ArticleId { get; set; }
        public Guid CategoryId { get; set; }
        public Guid AggregateId { get; set; }
    }
}

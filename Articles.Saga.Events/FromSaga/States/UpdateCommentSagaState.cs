using Automatonymous;
using System;

namespace Articles.Saga.Events.FromSaga.States
{
    public class UpdateCommentSagaState : SagaStateMachineInstance
    {
        public Guid CorrelationId { get; set; }
        public State CurrentState { get; set; }

        public Guid Id { get; set; }
        public string Body { get; set; }
        public Guid AggregateId { get; set; }
    }
}

using Automatonymous;
using System;

namespace Articles.Saga.Events.FromSaga.States
{
    public class ApproveArticleSagaState : SagaStateMachineInstance
    {
        public Guid CorrelationId { get; set; }
        public State CurrentState { get; set; }

        public Guid AggregateId { get; set; }
    }
}

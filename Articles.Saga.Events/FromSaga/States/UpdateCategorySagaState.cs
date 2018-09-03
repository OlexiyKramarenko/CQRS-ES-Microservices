using Automatonymous;
using System;

namespace Articles.Saga.Events.FromSaga.States
{
    public class UpdateCategorySagaState : SagaStateMachineInstance
    {
        public Guid CorrelationId { get; set; }
        public State CurrentState { get; set; }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public int Importance { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public Guid AggregateId { get; set; }
    }
}

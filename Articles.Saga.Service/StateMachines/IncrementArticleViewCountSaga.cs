using Articles.Saga.Events.FromSaga.Events;
using Articles.Saga.Events.FromSaga.States;
using Articles.Saga.Events.ToSaga.Interfaces;
using Articles.WriteSide.Commands.Cancel;
using Articles.WriteSide.Events.ToSaga.Interfaces;
using Automatonymous;
using System; 

namespace Articles.Saga.Service.StateMachines
{ 
    class IncrementArticleViewCountSaga : MassTransitStateMachine<IncrementArticleViewCountSagaState>
    {
        public Event<ISagaArticleViewCountIncrementedEvent> SagaArticleViewCountIncrementedEvent { get; set; }
        public Event<ISagaFailedEvent> SagaFailedEvent { get; set; }

        public IncrementArticleViewCountSaga()
        {
            InstanceState(s => s.CurrentState);
             
            Event(
                 () => this.SagaArticleViewCountIncrementedEvent,
                  x => x.CorrelateById(state => state.AggregateId,
            context => context.Message.AggregateId)
                .SelectId(context => Guid.NewGuid()));


            Event(() => this.SagaFailedEvent,
                   x => x.CorrelateById(context => context.Message.CorrelationId));

            Initially(
                When(this.SagaArticleViewCountIncrementedEvent)
                    .Then(context =>
                    {
                        context.Instance.AggregateId = context.Data.AggregateId;
                    })
                    .Publish(context =>
                    new IncrementArticleViewCountEvent(context.Instance)),

                    When(this.SagaFailedEvent)
                    .Publish(context => new CancelCommand
                    {
                        Data = context.Data.Data,
                        Id = Guid.NewGuid(),
                        EventName = nameof(IncrementArticleViewCountEvent)
                    })
                );
            
            SetCompletedWhenFinalized();
        }
    }
}

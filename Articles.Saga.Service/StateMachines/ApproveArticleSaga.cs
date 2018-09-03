using Articles.Saga.Events.FromSaga.Events;
using Articles.Saga.Events.FromSaga.States;
using Articles.Saga.Events.ToSaga.Interfaces;
using Articles.WriteSide.Commands.Cancel;
using Articles.WriteSide.Events.ToSaga.Interfaces;
using Automatonymous;
using System;

namespace Articles.Saga.Service.StateMachines
{
    class ApproveArticleSaga : MassTransitStateMachine<ApproveArticleSagaState>
    {
        public Event<ISagaArticleApprovedEvent> SagaArticleApprovedEvent { get; set; }
        public Event<ISagaFailedEvent> SagaFailedEvent { get; set; }

        public ApproveArticleSaga()
        {
            InstanceState(s => s.CurrentState);

            Event(
                 () => this.SagaArticleApprovedEvent,
                  x => x.CorrelateById(state => state.AggregateId,
            context => context.Message.AggregateId)
                .SelectId(context => Guid.NewGuid()));


            Event(() => this.SagaFailedEvent,
                   x => x.CorrelateById(context => context.Message.CorrelationId));

            Initially(
                When(this.SagaArticleApprovedEvent)
                    .Then(context =>
                    {
                        context.Instance.AggregateId = context.Data.AggregateId;
                    })
                    .Publish(context =>
                    new ApproveArticleEvent(context.Instance)),

                    When(this.SagaFailedEvent)
                    .Publish(context => new CancelCommand
                    {
                        Data = context.Data.Data,
                        Id = Guid.NewGuid(),
                        EventName = nameof(ApproveArticleEvent)
                    })
                );

            SetCompletedWhenFinalized();
        }
    }
}

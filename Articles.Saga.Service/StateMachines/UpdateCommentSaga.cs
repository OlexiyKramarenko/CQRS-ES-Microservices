using Articles.Saga.Events.FromSaga.Events;
using Articles.Saga.Events.FromSaga.States;
using Articles.Saga.Events.ToSaga.Interfaces;
using Articles.WriteSide.Commands.Cancel;
using Articles.WriteSide.Events.ToSaga.Interfaces;
using Automatonymous;
using System;

namespace Articles.Saga.Service.StateMachines
{
    class UpdateCommentSaga : MassTransitStateMachine<UpdateCommentSagaState>
    {
        public Event<ISagaCommentUpdatedEvent> SagaCommentUpdatedEvent { get; set; }
        public Event<ISagaFailedEvent> SagaFailedEvent { get; set; }

        public UpdateCommentSaga()
        {
            InstanceState(s => s.CurrentState);

            Event(
                 () => this.SagaCommentUpdatedEvent,
                  x => x.CorrelateById(state => state.AggregateId,
            context => context.Message.AggregateId)
                .SelectId(context => Guid.NewGuid()));


            Event(() => this.SagaFailedEvent,
                   x => x.CorrelateById(context => context.Message.CorrelationId));

            Initially(
                When(this.SagaCommentUpdatedEvent)
                    .Then(context =>
                    {
                        context.Instance.AggregateId = context.Data.AggregateId;
                        context.Instance.Body = context.Data.Body;
                    })
                    .Publish(context =>
                    new UpdateCommentEvent(context.Instance)),

                    When(this.SagaFailedEvent)
                    .Publish(context => new CancelCommand
                    {
                        Data = context.Data.Data,
                        Id = Guid.NewGuid(),
                        EventName = nameof(UpdateCommentEvent)
                    })
                );

            SetCompletedWhenFinalized();
        }
    }
}

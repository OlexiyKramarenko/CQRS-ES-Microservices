using Articles.Saga.Events.FromSaga.Events;
using Articles.Saga.Events.FromSaga.States;
using Articles.Saga.Events.ToSaga.Interfaces;
using Articles.WriteSide.Commands.Cancel;
using Articles.WriteSide.Events.ToSaga.Interfaces;
using Automatonymous;
using System;

namespace Articles.Saga.Service.StateMachines
{
    class UpdateCategorySaga : MassTransitStateMachine<UpdateCategorySagaState>
    {
        public Event<ISagaCategoryUpdatedEvent> SagaCategoryUpdatedEvent { get; set; }
        public Event<ISagaFailedEvent> SagaFailedEvent { get; set; }

        public UpdateCategorySaga()
        {
            InstanceState(s => s.CurrentState);

            Event(
                 () => this.SagaCategoryUpdatedEvent,
                  x => x.CorrelateById(state => state.AggregateId,
            context => context.Message.AggregateId)
                .SelectId(context => Guid.NewGuid()));


            Event(() => this.SagaFailedEvent,
                   x => x.CorrelateById(context => context.Message.CorrelationId));

            Initially(
                When(this.SagaCategoryUpdatedEvent)
                    .Then(context =>
                    {
                        context.Instance.AggregateId = context.Data.AggregateId;
                        context.Instance.Description = context.Data.Description;
                        context.Instance.ImageUrl = context.Data.ImageUrl;
                        context.Instance.Importance = context.Data.Importance;
                        context.Instance.Title = context.Data.Title;
                    })
                    .Publish(context =>
                    new UpdateCategoryEvent(context.Instance)),

                    When(this.SagaFailedEvent)
                    .Publish(context => new CancelCommand
                    {
                        Data = context.Data.Data,
                        Id = Guid.NewGuid(),
                        EventName = nameof(UpdateCategoryEvent)
                    })
                );

            SetCompletedWhenFinalized();
        }
    }
}

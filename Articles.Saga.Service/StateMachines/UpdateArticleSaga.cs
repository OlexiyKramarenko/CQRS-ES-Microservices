using Articles.Saga.Events.FromSaga.Events;
using Articles.Saga.Events.FromSaga.States;
using Articles.Saga.Events.ToSaga.Interfaces;
using Articles.WriteSide.Commands.Cancel;
using Articles.WriteSide.Events.ToSaga.Interfaces;
using Automatonymous;
using System; 

namespace Articles.Saga.Service.StateMachines
{ 
    class UpdateArticleSaga : MassTransitStateMachine<UpdateArticleSagaState>
    {
        public Event<ISagaArticleUpdatedEvent> SagaArticleUpdatedEvent { get; set; }
        public Event<ISagaFailedEvent> SagaFailedEvent { get; set; }

        public UpdateArticleSaga()
        {
            InstanceState(s => s.CurrentState);
             
            Event(
                 () => this.SagaArticleUpdatedEvent,
                  x => x.CorrelateById(state => state.AggregateId,
            context => context.Message.AggregateId)
                .SelectId(context => Guid.NewGuid()));


            Event(() => this.SagaFailedEvent,
                   x => x.CorrelateById(context => context.Message.CorrelationId));

            Initially(
                When(this.SagaArticleUpdatedEvent)
                    .Then(context =>
                    {
                        context.Instance.Abstract = context.Data.Abstract;
                        context.Instance.AggregateId = context.Data.AggregateId;
                        context.Instance.Approved = context.Data.Approved;
                        context.Instance.Body = context.Data.Body;
                        context.Instance.CategoryId = context.Data.CategoryId;
                        context.Instance.City = context.Data.City;
                        context.Instance.CommentsEnabled = context.Data.CommentsEnabled;
                        context.Instance.Country = context.Data.Country;
                        context.Instance.ExpireDate = context.Data.ExpireDate;
                        context.Instance.Listed = context.Data.Listed;
                        context.Instance.OnlyForMembers = context.Data.OnlyForMembers;
                        context.Instance.ReleaseDate = context.Data.ReleaseDate;
                        context.Instance.State = context.Data.State;
                        context.Instance.Title = context.Data.Title;                        
                    })
                    .Publish(context =>
                    new UpdateArticleEvent(context.Instance)),

                    When(this.SagaFailedEvent)
                    .Publish(context => new CancelCommand
                    {
                        Data = context.Data.Data,
                        Id = Guid.NewGuid(),
                        EventName = nameof(UpdateArticleEvent)
                    })
                );
            
            SetCompletedWhenFinalized();
        }
    }
}

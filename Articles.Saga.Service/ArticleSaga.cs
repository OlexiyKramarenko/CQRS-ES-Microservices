using Articles.Saga.Events;
using Articles.Saga.Events.ToSaga.Interfaces;
using Articles.WriteSide.Commands.Cancel;
using Articles.WriteSide.Events.ToSaga.Interfaces;
using Automatonymous;
using System;

namespace Articles.Saga
{
    class ArticleSaga : MassTransitStateMachine<ArticleSagaState>
    {
        public Event<ISagaCommentInsertedEvent> SagaCommentInsertedEvent { get; set; }
        public Event<ISagaFailedCommentInsertedEvent> SagaFailedCommentInsertedEvent { get; set; }

        public ArticleSaga()
        {
            InstanceState(s => s.CurrentState);

            #region Insert Comment
            Event(
                 () => this.SagaCommentInsertedEvent,
                  x => x.CorrelateBy(state => state.AddedByIp,
            context => context.Message.AddedByIp)
                .SelectId(context => Guid.NewGuid()));


            Event(() => this.SagaFailedCommentInsertedEvent,
                   x => x.CorrelateById(context => context.Message.CorrelationId));

            Initially(
                When(this.SagaCommentInsertedEvent)
                    .Then(context =>
                    {
                        context.Instance.AddedBy = context.Data.AddedBy;
                        context.Instance.AddedByEmail = context.Data.AddedByEmail;
                        context.Instance.AddedByIp = context.Data.AddedByIp;
                        context.Instance.AddedDate = context.Data.AddedDate;
                        context.Instance.ArticleId = context.Data.ArticleId;
                        context.Instance.CategoryId = context.Data.CategoryId;
                        context.Instance.Body = context.Data.Body;
                        context.Instance.AggregateId = context.Data.AggregateId;
                    })
                    .Publish(context =>
                    new CommentInsertedEvent(context.Instance)),

                    When(this.SagaFailedCommentInsertedEvent)
                    .Publish(context => new CancelCommand
                    {
                        Data = context.Data.Data,
                        Id = Guid.NewGuid(),
                        EventName = nameof(CommentInsertedEvent)
                    })
                );
            #endregion



            SetCompletedWhenFinalized();
        }

    }
}

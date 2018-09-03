using Articles.ReadSide.Repository;
using Articles.ReadSide.Repository.Entities;
using Articles.ReadSide.Service.Utils;
using Articles.Saga.Events;
using Articles.Saga.Events.Interfaces;
using Articles.Saga.Events.ToSaga.Interfaces;
using MassTransit;
using System.Threading.Tasks;
using Utils;

namespace Articles.ReadSide.Service.EventHandlers
{
    public class CommentInsertedEventHandler : IConsumer<IInsertCommentEvent>
    {
        public async Task Consume(ConsumeContext<IInsertCommentEvent> context)
        {
            try
            {
                var comment = new Comment
                {
                    Body = context.Message.Body,
                    AddedBy = context.Message.AddedBy,
                    AddedDate = context.Message.AddedDate,
                    AddedByIp = context.Message.AddedByIp,
                    AddedByEmail = context.Message.AddedByEmail,
                    ArticleId = context.Message.ArticleId.ToString(),
                };
                throw new System.Exception();
                var repo = new ArticlesRepository(MongoFactory.GetDatabase("test"));

                //repo.InsertComment(context.Message.CategoryId.ToString(),
                //                   context.Message.ArticleId.ToString(),
                //                   comment);
            }
            catch
            {
                var endPoint = await BusConfigurator.GetEndPointAsync(RabbitMqConstants.ArticleSagaQueue);

                await endPoint.Send<ISagaFailedEvent>(new
                {
                    CorrelationId = context.ConversationId,
                    Data =
                    $"Event : {nameof(IInsertCommentEvent)}, " +
                    $"{nameof(IInsertCommentEvent.AddedBy)} : { context.Message.AddedBy }, " +
                    $"{nameof(IInsertCommentEvent.AddedByEmail)} : { context.Message.AddedByEmail }, " +
                    $"{nameof(IInsertCommentEvent.AddedByIp)} : { context.Message.AddedByIp }, " +
                    $"{nameof(IInsertCommentEvent.AddedDate)} : { context.Message.AddedDate }, " +
                    $"{nameof(IInsertCommentEvent.ArticleId)} : { context.Message.ArticleId }, " +
                    $"{nameof(IInsertCommentEvent.Body)} : { context.Message.Body }"
                });
            }
        }
    }
}

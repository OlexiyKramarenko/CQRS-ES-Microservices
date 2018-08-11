using System.Threading.Tasks;
using Articles.WriteSide.Aggregates;
using Articles.WriteSide.Commands;
using Articles.WriteSide.Events.ToSaga.Interfaces;
using Infrastructure.Contracts;
using MassTransit;
using Utils;

namespace Articles.WriteSide.Service.CommandHandlers
{
    public class UpdateArticleCommandHandler : BaseCommandHandler, IConsumer<IUpdateArticleCommand>
    {
        public async Task Consume(ConsumeContext<IUpdateArticleCommand> context)
        {
            var command = context.Message;

            Article article = await EventRepository.GetByIdAsync<Article>(command.Id);

            article.Update(command.CategoryId, command.Title, command.Abstract,
            command.Body, command.Country, command.State, command.City, command.ReleaseDate, command.ExpireDate, command.Approved, command.Listed, command.CommentsEnabled, command.OnlyForMembers);

            await EventRepository.PersistAsync(article);
            await SendEventAsync(article);
        }

        private async Task SendEventAsync(Article article)
        {
            ISendEndpoint endPoint = await BusConfigurator.GetEndPointAsync(RabbitMqConstants.ArticleSagaQueue);
            foreach (IEvent @event in article.GetUncommittedEvents())
            {
                var obj = (ISagaArticleUpdatedEvent)@event;
                await endPoint.Send<ISagaArticleUpdatedEvent>(new
                {
                    obj.AggregateId,
                    obj.Abstract,
                    obj.Approved,
                    obj.Body,
                    obj.CategoryId,
                    obj.City,
                    obj.CommentsEnabled,
                    obj.Country,
                    obj.ExpireDate,
                    obj.Listed,
                    obj.OnlyForMembers,
                    obj.ReleaseDate,
                    obj.State,
                    obj.Title
                });
            }
        }
    }
}

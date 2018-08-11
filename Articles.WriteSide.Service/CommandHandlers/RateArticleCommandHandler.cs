using System.Threading.Tasks;
using Articles.WriteSide.Aggregates;
using Articles.WriteSide.Commands;
using Articles.WriteSide.Events.ToSaga.Interfaces;
using Infrastructure.Contracts;
using MassTransit;
using Utils;

namespace Articles.WriteSide.Service.CommandHandlers
{
	public class RateArticleCommandHandler : BaseCommandHandler, IConsumer<IRateArticleCommand>
	{ 
		public async Task Consume(ConsumeContext<IRateArticleCommand> context)
		{
			var command = context.Message;

			Article article = await EventRepository.GetByIdAsync<Article>(command.Id);
			article.RateArticle(command.Rating);
			await EventRepository.PersistAsync(article);
            await SendEventAsync(article);
        }

        private async Task SendEventAsync(Article article)
        {
            ISendEndpoint endPoint = await BusConfigurator.GetEndPointAsync(RabbitMqConstants.ArticleSagaQueue);
            foreach (IEvent @event in article.GetUncommittedEvents())
            {
                var obj = (ISagaArticleRatedEvent)@event;
                await endPoint.Send<ISagaArticleRatedEvent>(new
                {
                    obj.AggregateId,
                    obj.Rating
                });
            }
        }
    }
}

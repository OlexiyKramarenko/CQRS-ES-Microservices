using Articles.WriteSide.Aggregates;
using Articles.WriteSide.Commands;
using Articles.WriteSide.Events.ToSaga.Interfaces;
using Infrastructure.Contracts;
using MassTransit;
using System.Threading.Tasks;
using Utils;

namespace Articles.WriteSide.Service.CommandHandlers
{
	public class ApproveArticleCommandHandler : BaseCommandHandler, IConsumer<IApproveArticleCommand>
	{
		public async Task Consume(ConsumeContext<IApproveArticleCommand> context)
		{
			var command = context.Message;

			Article article = await EventRepository.GetByIdAsync<Article>(command.Id);
			article.Approve();
			await EventRepository.PersistAsync(article);
			await SendEventAsync(article);
		}

		private async Task SendEventAsync(Article article)
		{
            ISendEndpoint endPoint = await BusConfigurator.GetEndPointAsync(RabbitMqConstants.ArticleSagaQueue);
            foreach (IEvent @event in article.GetUncommittedEvents())
			{
				var obj = (ISagaArticleApprovedEvent)@event;
				await endPoint.Send<ISagaArticleApprovedEvent>(new
				{
					obj.AggregateId
				});
			}
		}
	}
}

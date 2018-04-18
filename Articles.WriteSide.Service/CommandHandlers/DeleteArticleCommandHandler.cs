using System.Threading.Tasks;
using Articles.WriteSide.Aggregates;
using Articles.WriteSide.Commands;
using Articles.WriteSide.Events.ToSaga.Interfaces;
using Infrastructure.Contracts;
using MassTransit;

namespace Articles.WriteSide.Service.CommandHandlers
{
	public class DeleteArticleCommandHandler : BaseCommandHandler, IConsumer<IDeleteArticleCommand>
	{ 
		public async Task Consume(ConsumeContext<IDeleteArticleCommand> context)
		{
			var command = context.Message;

			Article article = await EventRepository.GetByIdAsync<Article>(command.Id);
			article.Delete();
			await EventRepository.PersistAsync(article);
			await SendEventAsync(article);
		}

		private async Task SendEventAsync(Article article)
		{
			//ISendEndpoint endPoint = await EndPoint();
			//foreach (IEvent @event in article.GetUncommittedEvents())
			//{
			//	var obj = (IArticleDeletedEvent)@event;
			//	await endPoint.Send<IArticleDeletedEvent>(new
			//	{
			//		obj.AggregateId
			//	});
			//}
		}
	}
}

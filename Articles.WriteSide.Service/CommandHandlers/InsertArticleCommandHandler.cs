using System.Threading.Tasks;
using Articles.WriteSide.Aggregates;
using Articles.WriteSide.Commands;
using Articles.WriteSide.Events.ToSaga.Interfaces;
using Infrastructure.Contracts;
using MassTransit;
using Utils;

namespace Articles.WriteSide.Service.CommandHandlers
{
	public class InsertArticleCommandHandler : BaseCommandHandler, IConsumer<IInsertArticleCommand>
	{
		public async Task Consume(ConsumeContext<IInsertArticleCommand> context)
		{
			var command = context.Message;

			var article = new Article(
				command.Id,
				command.AddedDate,
				command.AddedBy,
				command.CategoryId,
				command.Title,
				command.Abstract,
				command.Body,
				command.Country,
				command.State,
				command.City,
				command.ReleaseDate,
				command.ExpireDate,
				command.Approved,
				command.Listed,
				command.CommentsEnabled,
				command.OnlyForMembers,
				command.ViewCount,
				command.Votes,
				command.TotalRating);

			await EventRepository.PersistAsync(article);
			await SendEventAsync(article);
		}

		private async Task SendEventAsync(Article article)
		{
            ISendEndpoint endPoint = await BusConfigurator.GetEndPointAsync(RabbitMqConstants.ArticleSagaQueue);
            foreach (IEvent @event in article.GetUncommittedEvents())
			{
				var obj = (ISagaCommentInsertedEvent)@event;
				await endPoint.Send<ISagaCommentInsertedEvent>(new
				{
					obj.AggregateId,
					obj.AddedBy,
					obj.AddedByEmail,
					obj.AddedByIp,
					obj.AddedDate,
					obj.ArticleId,
					obj.Body
				});
			}
		}
	}
}

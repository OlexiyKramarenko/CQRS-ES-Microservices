using System.Threading.Tasks;
using Articles.WriteSide.Aggregates;
using Articles.WriteSide.Commands;
using Infrastructure.DataAccess;
using MassTransit;

namespace Articles.WriteSide.Service.CommandHandlers
{
	public class DeleteArticleCommandHandler : IConsumer<IDeleteArticleCommand>
	{
		private static IEventRepository EventRepository { get; set; }

		public async Task Consume(ConsumeContext<IDeleteArticleCommand> context)
		{
			var command = context.Message;

			Article article = await EventRepository.GetByIdAsync<Article>(command.Id);
			article.Delete();
			await EventRepository.PersistAsync(article);
		}
	}
}

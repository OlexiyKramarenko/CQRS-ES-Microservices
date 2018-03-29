using System.Threading.Tasks;
using Articles.WriteSide.Aggregates;
using Articles.WriteSide.Commands;
using Infrastructure.DataAccess;
using MassTransit;

namespace Articles.WriteSide.Service.CommandHandlers
{
	public class RateArticleCommandHandler : IConsumer<IRateArticleCommand>
	{
		private static IEventRepository EventRepository { get; set; }

		public async Task Consume(ConsumeContext<IRateArticleCommand> context)
		{
			var command = context.Message;

			Article article = await EventRepository.GetByIdAsync<Article>(command.Id);
			article.RateArticle();
			await EventRepository.PersistAsync(article);
		}
	}
}

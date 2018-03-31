using System.Threading.Tasks;
using Articles.WriteSide.Aggregates;
using Articles.WriteSide.Commands;
using MassTransit;

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
		}
	}
}

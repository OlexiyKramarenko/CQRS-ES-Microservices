using System.Threading.Tasks;
using Articles.WriteSide.Aggregates;
using Articles.WriteSide.Commands;
using MassTransit;

namespace Articles.WriteSide.Service.CommandHandlers
{
	public class IncrementArticleViewCountCommandHandler : BaseCommandHandler, IConsumer<IIncrementArticleViewCountCommand>
	{ 
		public async Task Consume(ConsumeContext<IIncrementArticleViewCountCommand> context)
		{
			var command = context.Message;

			Article article = await EventRepository.GetByIdAsync<Article>(command.Id);
			article.Delete();
			await EventRepository.PersistAsync(article);
		}
	}
}

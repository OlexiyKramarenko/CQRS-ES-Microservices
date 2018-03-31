using System.Threading.Tasks;
using Articles.WriteSide.Aggregates;
using Articles.WriteSide.Commands; 
using MassTransit;

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
		}
	}
}

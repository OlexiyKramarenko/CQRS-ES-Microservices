using System.Threading.Tasks;
using Articles.WriteSide.Aggregates;
using Articles.WriteSide.Commands;
using MassTransit;

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
		}
	}
}

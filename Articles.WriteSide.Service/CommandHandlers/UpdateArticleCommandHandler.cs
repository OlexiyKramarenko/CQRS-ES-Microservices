using System.Threading.Tasks;
using Articles.WriteSide.Aggregates;
using Articles.WriteSide.Commands;
using Infrastructure.DataAccess;
using MassTransit;

namespace Articles.WriteSide.Service.CommandHandlers
{
	public class UpdateArticleCommandHandler : IConsumer<IUpdateArticleCommand>
	{
		private static IEventRepository EventRepository { get; set; }

		public async Task Consume(ConsumeContext<IUpdateArticleCommand> context)
		{
			var command = context.Message;

			Article article = await EventRepository.GetByIdAsync<Article>(command.Id);

			article.Update(command.Id, command.CategoryId, command.Title, command.Abstract,
			command.Body, command.Country, command.State, command.City, command.ReleaseDate, command.ExpireDate, command.Approved, command.Listed, command.CommentsEnabled, command.OnlyForMembers);

			await EventRepository.PersistAsync(article);
		}
	}
}

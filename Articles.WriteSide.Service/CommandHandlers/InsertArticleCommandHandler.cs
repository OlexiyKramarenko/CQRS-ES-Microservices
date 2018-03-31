using System.Threading.Tasks;
using Articles.WriteSide.Aggregates;
using Articles.WriteSide.Commands;
using MassTransit;

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
		}
	}
}

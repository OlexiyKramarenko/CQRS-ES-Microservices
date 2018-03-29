using System.Threading.Tasks;
using Articles.WriteSide.Aggregates;
using Articles.WriteSide.Commands;
using Infrastructure.DataAccess;
using MassTransit;

namespace Articles.WriteSide.Service.CommandHandlers
{
	public class InsertCommentCommandHandler : IConsumer<IInsertCommentCommand>
	{
		private static IEventRepository EventRepository { get; set; }

		public async Task Consume (ConsumeContext<IInsertCommentCommand> context)
		{
			var command = context.Message;

			var comment = new Comment(command.Id, command.AddedDate, command.AddedBy,
				command.AddedByEmail, command.AddedByIp, command.Body, command.ArticleId);

			await EventRepository.PersistAsync(comment);
		}
	}
}

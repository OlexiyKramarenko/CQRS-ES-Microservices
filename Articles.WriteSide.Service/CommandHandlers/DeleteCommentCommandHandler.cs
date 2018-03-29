using System.Threading.Tasks;
using Articles.WriteSide.Aggregates;
using Articles.WriteSide.Commands;
using Infrastructure.DataAccess;
using MassTransit;

namespace Articles.WriteSide.Service.CommandHandlers
{
	public class DeleteCommentCommandHandler : IConsumer<IDeleteCommentCommand>
	{
		private static IEventRepository EventRepository { get; set; }

		public async Task Consume(ConsumeContext<IDeleteCommentCommand> context)
		{
			var command = context.Message;

			Comment comment = await EventRepository.GetByIdAsync<Comment>(command.Id);
			comment.Delete();
			await EventRepository.PersistAsync(comment);
		} 
	}
}

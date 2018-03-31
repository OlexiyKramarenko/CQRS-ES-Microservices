using System.Threading.Tasks;
using Articles.WriteSide.Aggregates;
using Articles.WriteSide.Commands; 
using MassTransit;

namespace Articles.WriteSide.Service.CommandHandlers
{
	public class DeleteCommentCommandHandler : BaseCommandHandler, IConsumer<IDeleteCommentCommand>
	{
		public async Task Consume(ConsumeContext<IDeleteCommentCommand> context)
		{
			var command = context.Message;

			Comment comment = await EventRepository.GetByIdAsync<Comment>(command.Id);
			comment.Delete();
			await EventRepository.PersistAsync(comment);
		}
	}
}

using System.Threading.Tasks;
using Articles.WriteSide.Aggregates;
using Articles.WriteSide.Commands;
using MassTransit;

namespace Articles.WriteSide.Service.CommandHandlers
{
	public class UpdateCommentCommandHandler : BaseCommandHandler, IConsumer<IUpdateCommentCommand>
	{
		public async Task Consume(ConsumeContext<IUpdateCommentCommand> context)
		{
			var command = context.Message;
			Comment comment = await EventRepository.GetByIdAsync<Comment>(command.Id);
			comment.Update();
			await EventRepository.PersistAsync(comment);
		}
	}
}

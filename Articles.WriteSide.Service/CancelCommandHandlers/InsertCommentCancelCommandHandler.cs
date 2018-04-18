using Articles.WriteSide.Commands.Cancel;
using Articles.WriteSide.Service.CommandHandlers;
using Infrastructure.Domain;
using MassTransit;
using System.Threading.Tasks;

namespace Articles.WriteSide.Service.CancelCommandHandlers
{
    class InsertCommentCancelCommandHandler : BaseCommandHandler, IConsumer<IInsertCommentCancelCommand>
	{
		public async Task Consume(ConsumeContext<IInsertCommentCancelCommand> context)
		{
			var command = context.Message;

			
		}
		
	}
}

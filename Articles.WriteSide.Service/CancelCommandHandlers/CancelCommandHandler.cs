using Articles.WriteSide.Aggregates;
using Articles.WriteSide.Commands.Cancel;
using Articles.WriteSide.Service.CommandHandlers;
using MassTransit;
using System.Threading.Tasks;

namespace Articles.WriteSide.Service.CancelCommandHandlers
{
    public class CancelCommandHandler : BaseCommandHandler, IConsumer<ICancelCommand>
    {
        public async Task Consume(ConsumeContext<ICancelCommand> context)
        {
            var failedEvent = new FailedReadSideEvent(context.Message.Id, context.Message.Data);
            await EventRepository.PersistAsync(failedEvent);
        }
    }
}

using System.Threading.Tasks;
using Articles.WriteSide.Aggregates;
using Articles.WriteSide.Commands;
using Articles.WriteSide.Events.ToSaga.Interfaces;
using Infrastructure.Contracts;
using MassTransit;
using Utils;

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
            await SendEventAsync(comment);
        }

        private async Task SendEventAsync(Comment comment)
        {
            ISendEndpoint endPoint = await BusConfigurator.GetEndPointAsync(RabbitMqConstants.ArticleSagaQueue);
            foreach (IEvent @event in comment.GetUncommittedEvents())
            {
                var obj = (ISagaCommentUpdatedEvent)@event;
                await endPoint.Send<ISagaCommentUpdatedEvent>(new
                {
                    obj.AggregateId,
                    obj.Body
                });
            }
        }
    }
}

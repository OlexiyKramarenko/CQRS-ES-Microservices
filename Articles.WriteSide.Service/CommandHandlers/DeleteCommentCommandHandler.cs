using System.Threading.Tasks;
using Articles.WriteSide.Aggregates;
using Articles.WriteSide.Commands;
using Articles.WriteSide.Events.ToSaga.Interfaces;
using Infrastructure.Contracts;
using MassTransit;
using Utils;

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
			await SendEventAsync(comment);
		}

		private async Task SendEventAsync(Comment comment)
		{
            ISendEndpoint endPoint = await BusConfigurator.GetEndPointAsync(RabbitMqConstants.ArticleSagaQueue);
            foreach (IEvent @event in comment.GetUncommittedEvents())
            {
                var obj = (ISagaCommentDeletedEvent)@event;
                await endPoint.Send<ISagaCommentDeletedEvent>(new
                {
                    obj.AggregateId
                });
            }
        }
	}
}

using System.Threading.Tasks;
using Articles.WriteSide.Aggregates;
using Articles.WriteSide.Commands;
using Articles.WriteSide.Events.ToSaga.Interfaces;
using Infrastructure.Contracts;
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
			await SendEventAsync(comment);
		}

		private async Task SendEventAsync(Comment comment)
		{
			//ISendEndpoint endPoint = await EndPoint();
			//foreach (IEvent @event in comment.GetUncommittedEvents())
			//{
			//	var obj = (ICommentDeletedEvent)@event;
			//	await endPoint.Send<ICommentDeletedEvent>(new
			//	{
			//		obj.AggregateId
			//	});
			//}
		}
	}
}

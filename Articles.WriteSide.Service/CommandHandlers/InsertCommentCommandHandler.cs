using System.Threading.Tasks;
using Articles.WriteSide.Aggregates;
using Articles.WriteSide.Commands;
using Articles.WriteSide.Events.ToSaga.Interfaces;
using Infrastructure.Contracts;
using MassTransit;

namespace Articles.WriteSide.Service.CommandHandlers
{
	public class InsertCommentCommandHandler : BaseCommandHandler, IConsumer<IInsertCommentCommand>
	{ 
		public async Task Consume (ConsumeContext<IInsertCommentCommand> context)
		{
			var command = context.Message;

			var comment = new Comment(command.Id, command.AddedDate, command.AddedBy,
				command.AddedByEmail, command.AddedByIp, command.Body, command.ArticleId);
			//await EventRepository.PersistAsync(comment);
			await SendEventAsync(comment);
		}

		private async Task SendEventAsync(Comment comment)
		{
			ISendEndpoint endPoint = await GetEndPoint();
			foreach (IEvent @event in comment.GetUncommittedEvents())
			{
				var obj = (ISagaCommentInsertedEvent)@event;
				await endPoint.Send<ISagaCommentInsertedEvent>(new
				{
					obj.AggregateId,
					obj.AddedBy,
					obj.AddedByEmail,
					obj.AddedByIp,
					obj.AddedDate,
					obj.ArticleId,
					obj.Body
				});
			}
		}
	}
}

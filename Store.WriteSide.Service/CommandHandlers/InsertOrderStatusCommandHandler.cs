using Infrastructure.DataAccess;
using MassTransit;
using Store.WriteSide.Aggregates;
using Store.WriteSide.Commands;
using System.Threading.Tasks;

namespace Store.WriteSide.Service.CommandHandlers
{
	public class InsertOrderStatusCommandHandler : IConsumer<IInsertOrderStatusCommand>
	{
		private static IEventRepository EventRepository { get; set; }

		public async Task Consume(ConsumeContext<IInsertOrderStatusCommand> context)
		{
			var command = context.Message;
			var orderStatus = new OrderStatus(command.Id, command.AddedDate, command.AddedBy, command.Title);
			await EventRepository.PersistAsync(orderStatus);
		}
	}
}

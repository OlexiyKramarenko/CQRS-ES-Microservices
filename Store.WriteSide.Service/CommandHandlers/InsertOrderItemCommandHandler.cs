using Infrastructure.DataAccess;
using MassTransit;
using Store.WriteSide.Aggregates;
using Store.WriteSide.Commands;
using System.Threading.Tasks;

namespace Store.WriteSide.Service.CommandHandlers
{
	public class InsertOrderItemCommandHandler : IConsumer<IInsertOrderItemCommand>
	{
		private static IEventRepository EventRepository { get; set; }

		public async Task Consume(ConsumeContext<IInsertOrderItemCommand> context)
		{
			var command = context.Message;

			var orderItem = new OrderItem(
				command.Id, command.AddedDate, command.AddedBy,
				command.OrderId, command.ProductId, command.Title,
				command.SKU, command.UnitPrice, command.Quantity);

			await EventRepository.PersistAsync(orderItem);
		}
	}
}

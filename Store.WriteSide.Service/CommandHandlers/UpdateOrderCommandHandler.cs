using System.Threading.Tasks;
using Infrastructure.DataAccess;
using MassTransit;
using Store.WriteSide.Aggregates;
using Store.WriteSide.Commands;

namespace Store.WriteSide.Service.CommandHandlers
{
	public class UpdateOrderCommandHandler : IConsumer<IUpdateOrderCommand>
	{
		private static IEventRepository EventRepository { get; set; }

		public async Task Consume(ConsumeContext<IUpdateOrderCommand> context)
		{
			var command = context.Message;
			Order order = await EventRepository.GetByIdAsync<Order>(command.Id);
			await EventRepository.PersistAsync(order);
		}
	}
}

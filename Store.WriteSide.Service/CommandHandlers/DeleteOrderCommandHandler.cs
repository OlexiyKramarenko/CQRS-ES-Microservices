using Infrastructure.DataAccess;
using MassTransit;
using Store.WriteSide.Aggregates;
using Store.WriteSide.Commands; 
using System.Threading.Tasks;

namespace Store.WriteSide.Service.CommandHandlers
{
	public class DeleteOrderCommandHandler : IConsumer<IDeleteOrderCommand>
	{
		private static IEventRepository EventRepository { get; set; }

		public async Task Consume(ConsumeContext<IDeleteOrderCommand> context)
		{
			var command = context.Message;
			Order order = await EventRepository.GetByIdAsync<Order>(command.Id);
			order.Delete(command.Id);
			await EventRepository.PersistAsync(order);
		}
	}
}

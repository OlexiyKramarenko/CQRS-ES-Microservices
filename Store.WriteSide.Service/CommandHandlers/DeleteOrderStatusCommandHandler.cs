using Infrastructure.DataAccess;
using MassTransit;
using Store.WriteSide.Aggregates;
using Store.WriteSide.Commands; 
using System.Threading.Tasks;

namespace Store.WriteSide.Service.CommandHandlers
{
	public class DeleteOrderStatusCommandHandler : IConsumer<IDeleteOrderStatusCommand>
	{
		private static IEventRepository EventRepository { get; set; }

		public async Task Consume(ConsumeContext<IDeleteOrderStatusCommand> context)
		{
			var command = context.Message;
			OrderStatus orderStatus = await EventRepository.GetByIdAsync<OrderStatus>(command.Id);
			orderStatus.Delete();
			await EventRepository.PersistAsync(orderStatus);
		}
	}
}

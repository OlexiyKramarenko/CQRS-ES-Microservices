using Infrastructure.DataAccess;
using MassTransit;
using Store.WriteSide.Aggregates;
using Store.WriteSide.Commands; 
using System.Threading.Tasks;

namespace Store.WriteSide.Service.CommandHandlers
{
public	class DecrementProductUnitsInStockCommandHandler : IConsumer<IDecrementProductUnitsInStockCommand>
	{
		private static IEventRepository EventRepository { get; set; }

		public async Task Consume(ConsumeContext<IDecrementProductUnitsInStockCommand> context)
		{
			var command = context.Message; 
			Product product = await EventRepository.GetByIdAsync<Product>(command.Id);
			product.DecrementProductUnitsInStock(command.Quantity);
			await EventRepository.PersistAsync(product);
		}
	}
}

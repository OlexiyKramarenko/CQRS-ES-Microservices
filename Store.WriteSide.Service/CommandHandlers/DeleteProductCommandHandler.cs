using Infrastructure.DataAccess;
using MassTransit;
using Store.WriteSide.Aggregates;
using Store.WriteSide.Commands; 
using System.Threading.Tasks;

namespace Store.WriteSide.Service.CommandHandlers
{
	public class DeleteProductCommandHandler : IConsumer<IDeleteProductCommand>
	{
		private static IEventRepository EventRepository { get; set; }

		public async Task Consume(ConsumeContext<IDeleteProductCommand> context)
		{
			var command = context.Message;
			Product product = await EventRepository.GetByIdAsync<Product>(command.Id);
			product.Delete();
			await EventRepository.PersistAsync(product);
		}
	}
}

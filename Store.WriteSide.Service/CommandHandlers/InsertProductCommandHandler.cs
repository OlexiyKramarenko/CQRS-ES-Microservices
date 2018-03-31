using Infrastructure.DataAccess;
using MassTransit;
using Store.WriteSide.Aggregates;
using Store.WriteSide.Commands; 
using System.Threading.Tasks;

namespace Store.WriteSide.Service.CommandHandlers
{
	public class InsertProductCommandHandler : IConsumer<IInsertProductCommand>
	{
		private static IEventRepository EventRepository { get; set; }

		public async Task Consume(ConsumeContext<IInsertProductCommand> context)
		{
			var command = context.Message;
			Product product = await EventRepository.GetByIdAsync<Product>(command.Id);
			await EventRepository.PersistAsync(product);
		}
	}
}

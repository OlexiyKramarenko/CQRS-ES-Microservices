using System.Threading.Tasks;
using Infrastructure.DataAccess;
using MassTransit;
using Store.WriteSide.Aggregates;
using Store.WriteSide.Commands;

namespace Store.WriteSide.Service.CommandHandlers
{
	public class RateProductCommandHandler : IConsumer<IRateProductCommand>
	{
		private static IEventRepository EventRepository { get; set; }

		public async Task Consume(ConsumeContext<IRateProductCommand> context)
		{
			var command = context.Message;
			Product product = await EventRepository.GetByIdAsync<Product>(command.Id);
			await EventRepository.PersistAsync(product);
		}
	}
}

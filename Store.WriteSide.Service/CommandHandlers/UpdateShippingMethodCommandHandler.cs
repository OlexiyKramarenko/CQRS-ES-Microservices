using Infrastructure.DataAccess;
using MassTransit;
using Store.WriteSide.Aggregates;
using Store.WriteSide.Commands; 
using System.Threading.Tasks;

namespace Store.WriteSide.Service.CommandHandlers
{
	public class UpdateShippingMethodCommandHandler : IConsumer<IUpdateShippingMethodCommand>
	{
		private static IEventRepository EventRepository { get; set; }

		public async Task Consume(ConsumeContext<IUpdateShippingMethodCommand> context)
		{
			var command = context.Message;
			ShippingMethod shippingMethod = await EventRepository.GetByIdAsync<ShippingMethod>(command.Id);
			await EventRepository.PersistAsync(shippingMethod);
		}
	}
}

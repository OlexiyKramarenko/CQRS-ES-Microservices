using Infrastructure.DataAccess;
using MassTransit;
using Store.WriteSide.Aggregates;
using Store.WriteSide.Commands; 
using System.Threading.Tasks;

namespace Store.WriteSide.Service.CommandHandlers
{
	public class DeleteShippingMethodCommandHandler : IConsumer<IDeleteShippingMethodCommand>
	{
		private static IEventRepository EventRepository { get; set; }

		public async Task Consume(ConsumeContext<IDeleteShippingMethodCommand> context)
		{
			var command = context.Message;
			ShippingMethod shippingMethod = await EventRepository.GetByIdAsync<ShippingMethod>(command.Id);
			shippingMethod.Delete();
			await EventRepository.PersistAsync(shippingMethod);
		}
	}
}

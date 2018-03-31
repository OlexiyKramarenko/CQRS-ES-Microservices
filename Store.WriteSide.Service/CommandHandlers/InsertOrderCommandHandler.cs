using Infrastructure.DataAccess;
using MassTransit;
using Store.WriteSide.Aggregates;
using Store.WriteSide.Commands;
using System.Threading.Tasks;

namespace Store.WriteSide.Service.CommandHandlers
{
	public class InsertOrderCommandHandler : IConsumer<IInsertOrderCommand>
	{
		private static IEventRepository EventRepository { get; set; }

		public async Task Consume(ConsumeContext<IInsertOrderCommand> context)
		{
			var cmd = context.Message;
			Order order = new Order(
				cmd.Id, cmd.AddedDate, cmd.AddedBy, cmd.StatusId, cmd.ShippingMethod,
				cmd.SubTotal, cmd.Shipping, cmd.ShippingFirstName, cmd.ShippingLastName, cmd.ShippingStreet,
				cmd.ShippingPostalCode, cmd.ShippingCity, cmd.ShippingState,
				cmd.ShippingCountry, cmd.CustomerEmail, cmd.CustomerPhone,
				cmd.CustomerFax, cmd.TransactionId, cmd.ShippedDate, cmd.TrackingId);
			await EventRepository.PersistAsync(order);
		}
	}
}

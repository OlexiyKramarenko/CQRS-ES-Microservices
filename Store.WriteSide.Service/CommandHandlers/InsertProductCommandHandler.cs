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
			Product product = new Product(command.Id, command.AddedDate, command.AddedBy,
				command.DepartmentId, command.Title, command.Description, command.SKU,
				command.UnitPrice, command.DiscountPercentage, command.UnitsInStock,
				command.SmallImageUrl, command.FullImageUrl, command.Votes, command.TotalRating);

			await EventRepository.PersistAsync(product);
		}
	}
}

using System.Threading.Tasks;
using Articles.WriteSide.Aggregates;
using Articles.WriteSide.Commands;
using Infrastructure.DataAccess;
using MassTransit;

namespace Articles.WriteSide.Service.CommandHandlers
{
	public class InsertCategoryCommandHandler : IConsumer<IInsertCategoryCommand>
	{
		private static IEventRepository EventRepository { get; set; }

		public async Task Consume(ConsumeContext<IInsertCategoryCommand> context)
		{
			var command = context.Message;

			var category = new Category(command.Id, command.AddedDate, command.AddedBy,
				command.Title, command.Importance, command.Description, command.ImageUrl);

			await EventRepository.PersistAsync(category);
		}
	}
}

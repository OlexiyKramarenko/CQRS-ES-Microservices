using System.Threading.Tasks;
using Articles.WriteSide.Aggregates;
using Articles.WriteSide.Commands;
using MassTransit;

namespace Articles.WriteSide.Service.CommandHandlers
{
	public class InsertCategoryCommandHandler : BaseCommandHandler, IConsumer<IInsertCategoryCommand>
	{ 
		public async Task Consume(ConsumeContext<IInsertCategoryCommand> context)
		{
			var command = context.Message;

			var category = new Category(command.Id, command.AddedDate, command.AddedBy,
				command.Title, command.Importance, command.Description, command.ImageUrl);

			await EventRepository.PersistAsync(category);
		}
	}
}

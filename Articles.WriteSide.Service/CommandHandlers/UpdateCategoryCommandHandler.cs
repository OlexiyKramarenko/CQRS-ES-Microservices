using System.Threading.Tasks;
using Articles.WriteSide.Aggregates;
using Articles.WriteSide.Commands; 
using MassTransit;

namespace Articles.WriteSide.Service.CommandHandlers
{
	public class UpdateCategoryCommandHandler : BaseCommandHandler, IConsumer<IUpdateCategoryCommand>
	{ 
		public async Task Consume (ConsumeContext<IUpdateCategoryCommand> context)
		{
			var command = context.Message;
			Category category = await EventRepository.GetByIdAsync<Category>(command.Id);
			category.Update(category.Title, category.Importance, category.Description, category.ImageUrl);
			await EventRepository.PersistAsync(category);
		}
	}
}

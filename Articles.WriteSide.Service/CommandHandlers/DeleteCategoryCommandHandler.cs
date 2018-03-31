using System.Threading.Tasks;
using Articles.WriteSide.Aggregates;
using Articles.WriteSide.Commands;
using MassTransit;

namespace Articles.WriteSide.Service.CommandHandlers
{
	public class DeleteCategoryCommandHandler : BaseCommandHandler, IConsumer<IDeleteCategoryCommand>
	{  
		public async Task Consume(ConsumeContext<IDeleteCategoryCommand> context)
		{
			var command = context.Message;

			Category category = await EventRepository.GetByIdAsync<Category>(command.Id);
			category.Delete();
			await EventRepository.PersistAsync(category);
		}
	}
}

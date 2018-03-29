using System.Threading.Tasks;
using Articles.WriteSide.Aggregates;
using Articles.WriteSide.Commands;
using Infrastructure.DataAccess;
using MassTransit;

namespace Articles.WriteSide.Service.CommandHandlers
{
	public class UpdateCategoryCommandHandler : IConsumer<IUpdateCategoryCommand>
	{
		private static IEventRepository EventRepository { get; set; }

		public async Task Consume (ConsumeContext<IUpdateCategoryCommand> context)
		{
			var command = context.Message;

			Category category = await EventRepository.GetByIdAsync<Category>(command.Id);
			category.Update(category.Id, category.Title, category.Importance, category.Description, category.ImageUrl);

			await EventRepository.PersistAsync(category);
		}
	}
}

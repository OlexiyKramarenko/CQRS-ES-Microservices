using System.Threading.Tasks;
using Articles.WriteSide.Aggregates;
using Articles.WriteSide.Commands;
using Articles.WriteSide.Events.ToSaga.Interfaces;
using Infrastructure.Contracts;
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
			await SendEventAsync(category);
		}

		private async Task SendEventAsync(Category category)
		{
			//ISendEndpoint endPoint = await EndPoint();
			//foreach (IEvent @event in category.GetUncommittedEvents())
			//{
			//	var obj = (ICategoryDeletedEvent)@event;
			//	await endPoint.Send<ICategoryDeletedEvent>(new
			//	{
			//		obj.AggregateId
			//	});
			//}
		}
	}
}

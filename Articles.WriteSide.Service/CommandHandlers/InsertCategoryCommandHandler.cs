using System.Linq;
using System.Threading.Tasks;
using Articles.WriteSide.Aggregates;
using Articles.WriteSide.Commands;
using Articles.WriteSide.Events.ToSaga.Interfaces;
using Infrastructure.Contracts;
using MassTransit;
using Utils;

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
			
			category.GetUncommittedEvents()
				    .Select(@event => SendEvent(@event));
		}
		
		public async Task SendEvent(IEvent @event)
		{
            ISendEndpoint endPoint = await BusConfigurator.GetEndPointAsync(RabbitMqConstants.ArticleSagaQueue);
            var obj = (ISagaCategoryInsertedEvent)@event;			 
			await endPoint.Send<ISagaCategoryInsertedEvent>(new
			{
				obj.AggregateId,
				obj.AddedBy,
				obj.AddedDate,
			});
		}

	}
}

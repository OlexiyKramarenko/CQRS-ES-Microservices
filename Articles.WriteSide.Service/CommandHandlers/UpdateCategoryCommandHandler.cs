using System.Threading.Tasks;
using Articles.WriteSide.Aggregates;
using Articles.WriteSide.Commands;
using Articles.WriteSide.Events.ToSaga.Interfaces;
using Infrastructure.Contracts;
using MassTransit;
using Utils;

namespace Articles.WriteSide.Service.CommandHandlers
{
    public class UpdateCategoryCommandHandler : BaseCommandHandler, IConsumer<IUpdateCategoryCommand>
    {
        public async Task Consume(ConsumeContext<IUpdateCategoryCommand> context)
        {
            var command = context.Message;
            Category category = await EventRepository.GetByIdAsync<Category>(command.Id);
            category.Update(category.Title, category.Importance, category.Description, category.ImageUrl);
            await EventRepository.PersistAsync(category);
            await SendEventAsync(category);
        }

        private async Task SendEventAsync(Category category)
        {
            ISendEndpoint endPoint = await BusConfigurator.GetEndPointAsync(RabbitMqConstants.ArticleSagaQueue);
            foreach (IEvent @event in category.GetUncommittedEvents())
            {
                var obj = (ISagaCategoryUpdatedEvent)@event;
                await endPoint.Send<ISagaCategoryUpdatedEvent>(new
                {
                    obj.AggregateId,
                    obj.Description,
                    obj.ImageUrl,
                    obj.Importance,
                    obj.Title
                });
            }
        }
    }
}

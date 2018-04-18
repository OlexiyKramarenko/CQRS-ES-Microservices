using Articles.ReadSide.Repository;
using Articles.ReadSide.Repository.Entities;
using Articles.ReadSide.Service.Utils;
using Articles.Saga.Events.Interfaces;
using Articles.Saga.Events.ToSaga.Interfaces;
using MassTransit;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;
using Utils;

namespace Articles.ReadSide.Service.EventHandlers
{
	public class CommentInsertedEventHandler : IConsumer<ICommentInsertedEvent>
	{
		public async Task Consume(ConsumeContext<ICommentInsertedEvent> context)
		{
			//Response
			//publish event
			//await context.Publish<ISagaOperationResultMessage>(
			//	new
			//	{
			//		CorrelationId = Guid.NewGuid(),
			//		Name = "John"
			//	});

			IBusControl bus = BusConfigurator.ConfigureBus();
			Uri sendToUri = new Uri($"{RabbitMqConstants.RabbitMqUri}" + $"{RabbitMqConstants.ArticleSagaQueue}");
			ISendEndpoint endPoint = await bus.GetSendEndpoint(sendToUri);

			var r =context.Message;
			
			var repo = new ArticlesRepository(MongoFactory.GetDatabase("test"));
			repo.InsertCategory(new Category());

			//await repo.SaveDocs();



			await endPoint.Send<ISagaOperationResultMessage>(new
			{
				CorrelationId = Guid.NewGuid(),
				Name = "John"
			});

		}
	}
}

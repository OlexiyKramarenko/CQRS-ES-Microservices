using Infrastructure.DataAccess;
using MassTransit;
using System;
using System.Threading.Tasks;
using Utils;

namespace Articles.WriteSide.Service.CommandHandlers
{
	public class BaseCommandHandler
	{
		public static IEventRepository EventRepository { get; set; }

		public async Task<ISendEndpoint> GetEndPoint()
		{
			IBusControl bus = BusConfigurator.ConfigureBus();
			Uri sendToUri = new Uri($"{RabbitMqConstants.RabbitMqUri}" + $"{RabbitMqConstants.ArticleSagaQueue}");
			ISendEndpoint endPoint = await bus.GetSendEndpoint(sendToUri);
			return endPoint;
		}
		//public ISendEndpoint EndPoint
		//{
		//	get
		//	{
		//		IBusControl bus = BusConfigurator.ConfigureBus();
		//		Uri sendToUri = new Uri($"{RabbitMqConstants.RabbitMqUri}" + $"{RabbitMqConstants.ArticleSagaQueue}");
		//		ISendEndpoint endPoint = bus.GetSendEndpoint(sendToUri);
		//		return endPoint;
		//	}
		//}
	}
}

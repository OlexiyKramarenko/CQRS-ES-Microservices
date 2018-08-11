using MassTransit;
using MassTransit.RabbitMqTransport;
using System;
using System.Threading.Tasks;

namespace Utils
{
	public class BusConfigurator
	{
		public static IBusControl ConfigureBus(Action<IRabbitMqBusFactoryConfigurator, IRabbitMqHost> registrationAction = null)
		{
			return Bus.Factory.CreateUsingRabbitMq(cfg =>
			{
				var host = cfg.Host(new Uri(RabbitMqConstants.RabbitMqUri), hst =>
				{
					hst.Username(RabbitMqConstants.UserName);
					hst.Password(RabbitMqConstants.Password);
				});

				registrationAction?.Invoke(cfg, host);
			});
		}

        public static async Task<ISendEndpoint> GetEndPointAsync(string destination)
        {
            var bus = ConfigureBus();
            var sendToUri = new Uri($"{RabbitMqConstants.RabbitMqUri}" + destination);
            var endPoint = await bus.GetSendEndpoint(sendToUri);
            return endPoint;
        }
    }
}

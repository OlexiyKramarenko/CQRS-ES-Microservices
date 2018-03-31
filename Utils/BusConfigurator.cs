using MassTransit;
using MassTransit.RabbitMqTransport;
using System;

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
	}
}

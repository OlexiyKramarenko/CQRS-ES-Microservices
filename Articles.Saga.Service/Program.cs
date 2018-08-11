using Automatonymous;
using MassTransit;
using MassTransit.Saga;
using System;
using Utils;

namespace Articles.Saga
{
    class Program
    {
        static void Main(string[] args)
        {
			Console.Title = "Saga";
			  
			var bus = BusConfigurator.ConfigureBus((cfg, host) =>
			{
				cfg.ReceiveEndpoint(host, RabbitMqConstants.ArticleSagaQueue, e =>
				{
					e.StateMachineSaga(new ArticleSaga(), new InMemorySagaRepository<ArticleSagaState>());
				});
			});
			bus.Start();
			Console.WriteLine("Saga active.. Press enter to exit");
			Console.ReadLine();
			bus.Stop();
		}
    }
}

using Articles.Saga.Events.FromSaga.States;
using Articles.Saga.Service.StateMachines;
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
                    e.StateMachineSaga(new ApproveArticleSaga(), new InMemorySagaRepository<ApproveArticleSagaState>());
                    e.StateMachineSaga(new DeleteArticleSaga(), new InMemorySagaRepository<DeleteArticleSagaState>());
                    e.StateMachineSaga(new DeleteCategorySaga(), new InMemorySagaRepository<DeleteCategorySagaState>());
                    e.StateMachineSaga(new DeleteCommentSaga(), new InMemorySagaRepository<DeleteCommentSagaState>());
                    e.StateMachineSaga(new InsertArticleSaga(), new InMemorySagaRepository<InsertArticleSagaState>());
                    e.StateMachineSaga(new InsertCommentSaga(), new InMemorySagaRepository<InsertCommentSagaState>());
                    e.StateMachineSaga(new RateArticleSaga(), new InMemorySagaRepository<RateArticleSagaState>());
                    e.StateMachineSaga(new UpdateArticleSaga(), new InMemorySagaRepository<UpdateArticleSagaState>());
                    e.StateMachineSaga(new UpdateCategorySaga(), new InMemorySagaRepository<UpdateCategorySagaState>());
                    e.StateMachineSaga(new UpdateCommentSaga(), new InMemorySagaRepository<UpdateCommentSagaState>());
                });
			});
			bus.Start();
			Console.WriteLine("Saga active.. Press enter to exit");
			Console.ReadLine();
			bus.Stop();
		}
    }
}

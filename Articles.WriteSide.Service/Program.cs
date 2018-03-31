using Articles.WriteSide.Service.CommandHandlers;
using MassTransit;
using System;
using Utils;

namespace Articles.WriteSide.Service
{
	class Program
	{
		static void Main(string[] args)
		{
			string connectionString = new AppSettings("appsettings.json").GetConnectionString("DefaultConnection");
			
			BaseCommandHandler.EventRepository = RepositoryFactory.GetArticlesEventRepository(connectionString);

			var bus = BusConfigurator.ConfigureBus((cfg, host) =>
			{
				cfg.ReceiveEndpoint(host, RabbitMqConstants.ApproveArticleServiceQueue, e =>
				{
					e.Consumer<ApproveArticleCommandHandler>();
				});
				cfg.ReceiveEndpoint(host, RabbitMqConstants.DeleteArticleServiceQueue, e =>
				{
					e.Consumer<DeleteArticleCommandHandler>();
				});
				cfg.ReceiveEndpoint(host, RabbitMqConstants.DeleteCategoryServiceQueue, e =>
				{
					e.Consumer<DeleteCategoryCommandHandler>();
				});
				cfg.ReceiveEndpoint(host, RabbitMqConstants.DeleteCommentServiceQueue, e =>
				{
					e.Consumer<DeleteCommentCommandHandler>();
				});
				cfg.ReceiveEndpoint(host, RabbitMqConstants.IncrementArticleViewCountServiceQueue, e =>
				{
					e.Consumer<IncrementArticleViewCountCommandHandler>();
				});
				cfg.ReceiveEndpoint(host, RabbitMqConstants.InsertArticleServiceQueue, e =>
				{
					e.Consumer<InsertArticleCommandHandler>();
				});
				cfg.ReceiveEndpoint(host, RabbitMqConstants.InsertCategoryServiceQueue, e =>
				{
					e.Consumer<InsertCategoryCommandHandler>();
				});
				cfg.ReceiveEndpoint(host, RabbitMqConstants.InsertCommentServiceQueue, e =>
				{
					e.Consumer<InsertCommentCommandHandler>();
				});
				cfg.ReceiveEndpoint(host, RabbitMqConstants.RateArticleServiceQueue, e =>
				{
					e.Consumer<RateArticleCommandHandler>();
				});
				cfg.ReceiveEndpoint(host, RabbitMqConstants.UpdateArticleServiceQueue, e =>
				{
					e.Consumer<UpdateArticleCommandHandler>();
				});
				cfg.ReceiveEndpoint(host, RabbitMqConstants.UpdateCategoryServiceQueue, e =>
				{
					e.Consumer<UpdateCategoryCommandHandler>();
				});
				cfg.ReceiveEndpoint(host, RabbitMqConstants.UpdateCommentServiceQueue, e =>
				{
					e.Consumer<UpdateCommentCommandHandler>();
				});
			});

			bus.Start();
			Console.WriteLine("Articles.WriteSide.Service");
			Console.ReadLine();
			bus.Stop();
		}
	}
}

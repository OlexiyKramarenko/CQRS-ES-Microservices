using Articles.WriteSide.Service.CancelCommandHandlers;
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
			Console.Title = "WriteSide";

			string connectionString = new AppSettings("appsettings.json").GetConnectionString("DefaultConnection");
			
			BaseCommandHandler.EventRepository = RepositoryFactory.GetArticlesEventRepository(connectionString);

			var bus = BusConfigurator.ConfigureBus((cfg, host) =>
			{
				cfg.ReceiveEndpoint(host, RabbitMqConstants.ArticleWriteServiceQueue, e =>
				{
                    e.Consumer<ApproveArticleCommandHandler>();
                    e.Consumer<DeleteArticleCommandHandler>();
                    e.Consumer<DeleteCategoryCommandHandler>();
                    e.Consumer<DeleteCommentCommandHandler>();
                    e.Consumer<IncrementArticleViewCountCommandHandler>();
                    e.Consumer<InsertArticleCommandHandler>();
                    e.Consumer<InsertCategoryCommandHandler>();
                    e.Consumer<InsertCommentCommandHandler>();
                    e.Consumer<RateArticleCommandHandler>();
                    e.Consumer<UpdateArticleCommandHandler>();
                    e.Consumer<UpdateCategoryCommandHandler>();
                    e.Consumer<UpdateCommentCommandHandler>();

                    e.Consumer<CancelCommandHandler>();
				}); 
			});

			bus.Start();
			Console.WriteLine("Articles.WriteSide.Service");
			Console.ReadLine();
			bus.Stop();
		}
	}
}

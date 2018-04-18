using Articles.ReadSide.Repository;
using Articles.ReadSide.Repository.Entities;
using Articles.ReadSide.Service.EventHandlers;
using Articles.ReadSide.Service.Utils;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using System;
using Utils;

namespace Articles.ReadSide.Service
{
	class Program
	{
		static void Main(string[] args)
		{
			//setup our DI
			var serviceProvider = new ServiceCollection()
				.AddSingleton<IArticlesRepository, ArticlesRepository>()
				.AddSingleton(MongoFactory.GetDatabase("test"))
				.BuildServiceProvider();

			var bus = BusConfigurator.ConfigureBus((cfg, host) =>
			{
				cfg.ReceiveEndpoint(host, RabbitMqConstants.ArticlesReadSideServiceQueue, e =>
				{
					e.Consumer<CommentInsertedEventHandler>();
				});
			});

			bus.Start();

			Console.Title = "ReadSide";


			string catID = Guid.NewGuid().ToString();
			string articleID = Guid.NewGuid().ToString();

			var repo = new ArticlesRepository(MongoFactory.GetDatabase("test"));

			//repo.InsertCategory(new Category
			//{
			//	Id = catID
			//});

			//repo.InsertArticle(new Article
			//{
			//	Id = articleID,
			//	CategoryId = catID,
			//	AddedBy = "Anton"
			//});
			//repo.ApproveArticle(Guid.Parse(catID), Guid.Parse(articleID));
			//repo.DeleteArticle("5698380e-9f27-4eff-8e7c-fccf81f62913", "c4184dfb-1c0b-4e90-8203-6224f83deac4");

			//repo.InsertComment(catID, articleID, new Comment { AddedByEmail = "111@mail.ru", Id = Guid.NewGuid().ToString() });

			//repo.DeleteComment("ebc0b963-8345-4f4f-8fba-de5fb5d83e8b", "ae4a0c45-dcb5-472f-a096-5372cc61a450");

			string body = repo.GetArticleBody("ebc0b963-8345-4f4f-8fba-de5fb5d83e8b", "dd1d2dd5-d454-46f5-a2eb-43d622c19ee4");

			Console.ReadLine();




			bus.Stop();
		}
	}
}

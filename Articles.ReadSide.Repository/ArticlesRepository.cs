using Articles.ReadSide.Repository.Entities;
using MongoDB.Driver;
using System;
using System.Linq;

namespace Articles.ReadSide.Repository
{
	public class ArticlesRepository : IArticlesRepository
	{
		private IMongoCollection<Category> Categories
		{
			get
			{
				return _database.GetCollection<Category>(nameof(Category).ToLower());
			}
		}
		private IMongoCollection<Comment> Comments
		{
			get
			{
				return _database.GetCollection<Comment>(nameof(Comment).ToLower());
			}
		}

		IMongoDatabase _database;
		public ArticlesRepository()
		{

		}
		public ArticlesRepository(IMongoDatabase database)
		{
			_database = database;
		}

		public void InsertCategory(Category category)
		{
			Categories.InsertOne(category);
		}

		public void InsertArticle(Article article)
		{
			var update = Builders<Category>.Update.AddToSet(x => x.Articles, article);
			Categories.FindOneAndUpdate(x => x.Id == article.CategoryId, update);
		}

		public void ApproveArticle(Guid categoryId, Guid articleId)
		{
			var filter = Builders<Category>.Filter;

			var categoryIdAndArticleIdFilter = filter.And(
			  filter.Eq(x => x.Id, categoryId.ToString()),
			  filter.ElemMatch(x => x.Articles, c => c.Id == articleId.ToString()));

			var update = Builders<Category>.Update;

			var artticleApprovedSetter = update.Set(x => x.Articles[-1].Approved, true);
			Categories.UpdateOne(categoryIdAndArticleIdFilter, artticleApprovedSetter);
		}

		public void DeleteArticle(string categoryId, string articleId)
		{
			var filter = Builders<Category>.Filter.Eq(nameof(Category.Id), categoryId);

			var update = Builders<Category>.Update

				.PullFilter(nameof(Category.Articles),
						   Builders<Article>.Filter.Eq(nameof(Article.Id),
						   articleId));

			Categories.FindOneAndUpdate(filter, update);
		}

		public void DeleteCategory(Guid categoryId)
		{
			throw new NotImplementedException();
		}

		public void DeleteComment(string categoryId, string commentId)
		{
			var filter =
				Builders<Category>.Filter
								  .Eq(item => item.Id, categoryId);

			string field = $"{nameof(Category.Articles)}.$[].{nameof(Article.Comments)}";
			var update =
				Builders<Category>.Update
								  .PullFilter(field,
											  Builders<Comment>.Filter
															   .Eq(nameof(Comment.Id), commentId));

			Categories.FindOneAndUpdate(filter, update);
		}

		public void InsertComment(string categoryId, string articleId, Comment comment)
		{
			var filter =
				Builders<Category>.Filter
								  .And(Builders<Category>.Filter.Where(x => x.Id == categoryId),
									   Builders<Category>.Filter.Eq("Articles.Id", articleId));

			var update =
				Builders<Category>.Update
								  .Push($"{nameof(Category.Articles)}.$.{nameof(Article.Comments)}", comment);

			Categories.FindOneAndUpdate(filter, update);
		}

		public string GetArticleBody(string categoryId, string articleId)
		{
			//var filter =
			//	Builders<Category>.Filter
			//					  .And(Builders<Category>.Filter.Where(x => x.Id == categoryId),
			//						   Builders<Category>.Filter.Eq("Articles.Id", articleId));

			//var people = Categories.Find(filter).ToListAsync();

			//Article article = Categories.Find(a => a.Id == categoryId &&
			//								  a.Articles.Any(e => e.Id == articleId))
			//							.Project(a => a.Articles.ElementAt(-1))
			//							.SingleOrDefault();
			//return article.Body;

			var article = Categories.AsQueryable()
									.FirstOrDefault(a => a.Id == categoryId)
									?.Articles
									?.FirstOrDefault(a => a.Id == articleId);
			return null;
		}

		public int GetArticleCount()
		{
			throw new NotImplementedException();
		}

		public int GetArticleCount(Guid categoryId)
		{
			throw new NotImplementedException();
		}

		public int GetCommentCount(Guid articleId)
		{
			throw new NotImplementedException();
		}

		public int GetCommentCount()
		{
			throw new NotImplementedException();
		}

		public int GetPublishedArticleCount(DateTime currentDate)
		{
			throw new NotImplementedException();
		}

		public int GetPublishedArticleCount(Guid categoryId, DateTime currentDate)
		{
			throw new NotImplementedException();
		}

		public void IncrementArticleViewCount(Guid articleId)
		{
			throw new NotImplementedException();
		}

		public void RateArticle(Guid articleId, int rating)
		{
			throw new NotImplementedException();
		}





		//public async Task SaveDocs()
		//{
		//	string connectionString = "mongodb://localhost";
		//	var client = new MongoClient(connectionString);

		//	var database = client.GetDatabase("test");
		//	var collection = database.GetCollection<Person>("people");

		//	Person person1 = new Person
		//	{
		//		Name = "Jack",
		//		Age = 29,
		//		Languages = new List<string> { "english", "german" },
		//		Company = new Company
		//		{
		//			Name = "Google"
		//		}
		//	};
		//	await collection.InsertOneAsync(person1);
		//}

		//public void InsertArticle(Article article)
		//{
		//	Articles.InsertOneAsync(article);
		//}
	}
}

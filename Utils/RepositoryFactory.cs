using Articles.WriteSide.Repository;
using Infrastructure.DataAccess;
using Store.WriteSide.Repository;

namespace Utils
{
	public class RepositoryFactory
	{
		public static IEventRepository GetArticlesEventRepository(string connectionString)
		{
			return new ArticlesEventRepository(new ArticlesEventContext(connectionString));
		}

		public static IEventRepository GetStoreEventRepository(string connectionString)
		{
			return new StoreEventRepository(new StoreEventContext(connectionString));
		}
		
	}
}

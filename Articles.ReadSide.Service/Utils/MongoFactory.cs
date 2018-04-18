using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;
using MongoDB.Driver;

namespace Articles.ReadSide.Service.Utils
{
	public class MongoFactory
	{
		public static IMongoDatabase GetDatabase(string name)
		{
			string connectionString = "mongodb://localhost";
			var client = new MongoClient(connectionString);
			var database = client.GetDatabase(name);
			return database;
		}
		
	}
}

namespace Utils
{
	public static class RabbitMqConstants
	{
		public const string RabbitMqUri = "rabbitmq://localhost/accounting/";

		public const string UserName = "guest";
		public const string Password = "guest";

		public const string ArticleWriteServiceQueue = "article.write.service";

		public const string ArticleSagaQueue = "article.saga";
		public const string ArticlesReadSideServiceQueue = "article.read.service";
	}
}

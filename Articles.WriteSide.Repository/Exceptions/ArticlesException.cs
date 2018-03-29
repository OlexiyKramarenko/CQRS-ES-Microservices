using Articles.WriteSide.Repository.Enums;
using System; 

namespace Articles.WriteSide.Repository.Exceptions
{
	public class ArticlesException : Exception
	{
		public ArticlesExceptionType Type { get; }
		public Type SourceType { get; }
		public string Message { get; set; }

		public ArticlesException(ArticlesExceptionType type,
										Type sourceType = null,
										string message = null)
		{
			Type = type;
			SourceType = sourceType;
			Message = message;
		}
	}
}

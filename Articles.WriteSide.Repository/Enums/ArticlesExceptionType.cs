 
namespace Articles.WriteSide.Repository.Enums
{
	public enum ArticlesExceptionType 
	{
		NullCommand = 0,
		NullEvent = 1,
		InvalidCommand = 2,
		InvalidEvent = 3,
		EventStoreConcurency = 4,
		AggregateNotFound = 5,
		AggregateDeleted = 6
	}
}

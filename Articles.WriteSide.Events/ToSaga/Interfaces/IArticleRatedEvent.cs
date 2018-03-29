using Infrastructure.Contracts; 

namespace Articles.WriteSide.Events.ToSaga.Interfaces
{
	public interface IArticleRatedEvent : IEvent
	{
		int Rating { get; set; }
	}
}

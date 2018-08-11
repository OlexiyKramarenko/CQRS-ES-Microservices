using Infrastructure.Contracts; 

namespace Articles.WriteSide.Events.ToSaga.Interfaces
{
	public interface ISagaArticleRatedEvent : IEvent
	{
		int Rating { get; set; }
	}
}

using Infrastructure.Contracts;

namespace Articles.WriteSide.Events.ToSaga.Interfaces
{
	public interface ISagaCommentUpdatedEvent : IEvent
	{
		string Body { get; set; }
	}
}

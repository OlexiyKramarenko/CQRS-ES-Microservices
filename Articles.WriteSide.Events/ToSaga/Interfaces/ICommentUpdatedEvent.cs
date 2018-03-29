using Infrastructure.Contracts;

namespace Articles.WriteSide.Events.ToSaga.Interfaces
{
	public interface ICommentUpdatedEvent : IEvent
	{
		string Body { get; set; }
	}
}

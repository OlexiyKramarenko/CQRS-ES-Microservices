using Infrastructure.Contracts;

namespace Articles.WriteSide.Events.ToSaga.Interfaces
{
	public interface ISagaCategoryUpdatedEvent : IEvent
	{
		string Title { get; set; }
		int Importance { get; set; }
		string Description { get; set; }
		string ImageUrl { get; set; }
	}
}

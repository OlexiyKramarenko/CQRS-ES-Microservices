using Infrastructure.Contracts;

namespace Store.WriteSide.Events
{
	public interface IShippingMethodUpdatedEvent : IEvent
	{
		string Title { get; set; }
		decimal Price { get; set; }
	}
}

using Infrastructure.Contracts;

namespace Store.WriteSide.Events
{
	public interface IProductRatedEvent : IEvent
	{
		int Rating { get; set; }
	}
}

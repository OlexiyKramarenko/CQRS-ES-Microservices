using Infrastructure.Contracts;

namespace Store.WriteSide.Events
{
	public interface IDecrementProductUnitsInStockEvent : IEvent
	{
		int Quantity { get; set; }
	}
}

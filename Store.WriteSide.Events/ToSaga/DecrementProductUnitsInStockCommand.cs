using System;

namespace Store.WriteSide.Events.ToSaga
{
	public class DecrementProductUnitsInStockEvent : IDecrementProductUnitsInStockEvent
	{
		public int Quantity { get; set; }
		public Guid AggregateId { get; set; }
	}
}

using Infrastructure.Contracts;
using Infrastructure.Domain;
using Store.WriteSide.Events.ToSaga;
using System;

namespace Store.WriteSide.Aggregates
{
	public class OrderItem : AggregateRoot,
		IHandle<OrderItemInsertedEvent>
	{
		public DateTime AddedDate { get; set; }
		public string AddedBy { get; set; }
		public Guid OrderId { get; set; }
		public Guid ProductId { get; set; }
		public string Title { get; set; }
		public string SKU { get; set; }
		public decimal UnitPrice { get; set; }
		public int Quantity { get; set; }

		public OrderItem()
		{

		}
		public OrderItem(
			Guid id,
			DateTime addedDate,
			string addedBy,
			Guid orderId,
			Guid productId,
			string title,
			string SKU,
			decimal unitPrice,
			int quantity)
		{
			var @event = new OrderItemInsertedEvent
			{
				AggregateId = id,
				AddedDate = addedDate,
				AddedBy = addedBy,
				OrderId = orderId,
				ProductId = productId,
				Title = title,
				SKU = SKU,
				UnitPrice = unitPrice,
				Quantity = quantity
			};
			ApplyChange(@event);
		}

		public void Handle(OrderItemInsertedEvent @event)
		{
			AddedBy = @event.AddedBy;
			AddedDate = @event.AddedDate;
			Id = @event.AggregateId;
			OrderId = @event.OrderId;
			ProductId = @event.ProductId;
			Quantity = @event.Quantity;
			SKU = @event.SKU;
			Title = @event.Title;
			UnitPrice = @event.UnitPrice;
		}
	}
}

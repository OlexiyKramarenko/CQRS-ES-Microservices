using Infrastructure.Contracts;
using Infrastructure.Domain;
using Store.WriteSide.Events.ToSaga;
using System;

namespace Store.WriteSide.Aggregates
{
	public class ShippingMethod : AggregateRoot,
		IHandle<ShippingMethodDeletedEvent>,
		IHandle<ShippingMethodInsertedEvent>,
		IHandle<ShippingMethodUpdatedEvent>
	{
		public DateTime AddedDate { get; set; }
		public string AddedBy { get; set; }
		public string Title { get; set; }
		public decimal Price { get; set; }
		public string Description { get; set; }

		public ShippingMethod()
		{

		}
		public ShippingMethod(
			Guid id,
			DateTime addedDate,
			string addedBy,
			string title,
			decimal price,
			string description)
		{
			var @event = new ShippingMethodInsertedEvent
			{
				AggregateId = id,
				AddedDate = addedDate,
				AddedBy = addedBy,
				Title = title,
				Price = price,
				Description = description
			};
			ApplyChange(@event);
		}

		public void Update(int price, string title)
		{
			var @event = new ShippingMethodUpdatedEvent
			{
				AggregateId = Id,
				Price = price,
				Title = title
			};
			ApplyChange(@event);
		}

		public void Delete()
		{
			var @event = new ShippingMethodDeletedEvent
			{
				AggregateId = Id
			};
			ApplyChange(@event);
		}

		public void Handle(ShippingMethodDeletedEvent @event)
		{
			Id = @event.AggregateId;
		}

		public void Handle(ShippingMethodInsertedEvent @event)
		{
			AddedBy = @event.AddedBy;
			AddedDate = @event.AddedDate;
			Id = @event.AggregateId;
			Description = @event.Description;
			Price = @event.Price;
			Title = @event.Title;
		}

		public void Handle(ShippingMethodUpdatedEvent @event)
		{
			Id = @event.AggregateId;
			Price = @event.Price;
			Title = @event.Title;
		}
	}
}

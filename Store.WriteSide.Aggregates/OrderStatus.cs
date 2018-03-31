using Infrastructure.Contracts;
using Infrastructure.Domain;
using Store.WriteSide.Events.ToSaga;
using System;

namespace Store.WriteSide.Aggregates
{
	public class OrderStatus : AggregateRoot,
		IHandle<OrderStatusDeletedEvent>,
		IHandle<OrderStatusInsertedEvent>,
		IHandle<OrderStatusUpdatedEvent>
	{
		public DateTime AddedDate { get; set; }
		public string AddedBy { get; set; }
		public string Title { get; set; }

		public OrderStatus()
		{

		}
		public OrderStatus(Guid id, DateTime addedDate, string addedBy, string title)
		{
			var @event = new OrderStatusInsertedEvent
			{
				AggregateId = id,
				AddedDate = addedDate,
				AddedBy = AddedBy,
				Title = title
			};
			ApplyChange(@event);
		}

		public void Delete()
		{
			var @event = new OrderStatusDeletedEvent
			{
				AggregateId = Id
			};
			ApplyChange(@event);
		}

		public void Update(string addedBy, DateTime addedDate, string title)
		{
			var @event = new OrderStatusUpdatedEvent
			{
				AggregateId = Id,
				AddedBy = addedBy,
				AddedDate = addedDate,
				Title = title
			};
			ApplyChange(@event);
		}

		public void Update(Guid statusId)
		{
			var @event = new OrderStatusIdUpdatedEvent
			{
				AggregateId = Id,
				StatusId = statusId
			};
			ApplyChange(@event);
		}

		public void Handle(OrderStatusDeletedEvent @event)
		{
			Id = @event.AggregateId;
		}
		
		public void Handle(OrderStatusInsertedEvent @event)
		{
			AddedBy = @event.AddedBy;
			AddedDate = @event.AddedDate;
			Id = @event.AggregateId;
			Title = @event.Title;
		}

		public void Handle(OrderStatusUpdatedEvent @event)
		{
			AddedBy = @event.AddedBy;
			AddedDate = @event.AddedDate;
			Id = @event.AggregateId;
			Title = @event.Title;
		}
	}
}

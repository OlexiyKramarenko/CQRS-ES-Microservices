using Infrastructure.Contracts;
using Infrastructure.Domain;
using Store.WriteSide.Events.ToSaga;
using System;

namespace Store.WriteSide.Aggregates
{
	public class Order : AggregateRoot,
		IHandle<OrderDeletedEvent>,
		IHandle<OrderInsertedEvent>,
		IHandle<OrderUpdatedEvent>,
		IHandle<OrderStatusIdUpdatedEvent>
	{
		public DateTime AddedDate { get; set; }
		public string AddedBy { get; set; }
		public Guid StatusId { get; set; }
		public string ShippingMethod { get; set; }
		public decimal SubTotal { get; set; }
		public decimal Shipping { get; set; }
		public string ShippingFirstName { get; set; }
		public string ShippingLastName { get; set; }
		public string ShippingStreet { get; set; }
		public string ShippingPostalCode { get; set; }
		public string ShippingCity { get; set; }
		public string ShippingState { get; set; }
		public string ShippingCountry { get; set; }
		public string CustomerEmail { get; set; }
		public string CustomerPhone { get; set; }
		public string CustomerFax { get; set; }
		public string TransactionId { get; set; }
		public DateTime? ShippedDate { get; set; }
		public string TrackingId { get; set; }

		public Order()
		{

		}
		public Order(
				Guid id, DateTime addedDate, string addedBy, Guid statusId, string shippingMethod, decimal subTotal, decimal shipping, string shippingFirstName, string shippingLastName, string shippingStreet, string shippingPostalCode, string shippingCity, string shippingState, string shippingCountry, string customerEmail, string customerPhone, string customerFax, string transactionId, DateTime? shippedDate, string trackingId)
		{
			var @event = new OrderInsertedEvent
			{
				AggregateId = id,
				AddedDate = addedDate,
				AddedBy = addedBy,
				StatusId = statusId,
				ShippingMethod = shippingMethod,
				SubTotal = subTotal,
				Shipping = shipping,
				ShippingFirstName = shippingFirstName,
				ShippingLastName = shippingLastName,
				ShippingStreet = shippingStreet,
				ShippingPostalCode = shippingPostalCode,
				ShippingCity = shippingCity,
				ShippingState = shippingState,
				ShippingCountry = shippingCountry,
				CustomerEmail = customerEmail,
				CustomerPhone = customerPhone,
				CustomerFax = customerFax,
				TransactionId = transactionId,
				ShippedDate = shippedDate,
				TrackingId = trackingId
			};
			ApplyChange(@event);
		}
		public void Delete(Guid id)
		{
			var @event = new OrderDeletedEvent
			{
				AggregateId = id
			};
			ApplyChange(@event);
		}

		public void Update(
			Guid StatusId,
			string TransactionId,
			DateTime? ShippedDate,
			string TrackingId)
		{
			var @event = new OrderUpdatedEvent
			{
				AggregateId = Id,
				ShippedDate = ShippedDate,
				TransactionId = TransactionId,
				StatusId = StatusId,
				TrackingId = TrackingId
			};
			ApplyChange(@event);
		}

		public void Handle(OrderStatusIdUpdatedEvent @event)
		{
			Id = @event.AggregateId;
			StatusId = @event.StatusId;
		}

		public void Handle(OrderDeletedEvent @event)
		{
			Id = @event.AggregateId;
		}

		public void Handle(OrderInsertedEvent @event)
		{
			Id = @event.AggregateId;
			CustomerEmail = @event.CustomerEmail;
			CustomerFax = @event.CustomerFax;
			CustomerPhone = @event.CustomerPhone;
			ShippedDate = @event.ShippedDate;
			Shipping = @event.Shipping;
			ShippingCity = @event.ShippingCity;
			ShippingCountry = @event.ShippingCountry;
			ShippingFirstName = @event.ShippingFirstName;
			ShippingLastName = @event.ShippingLastName;
			ShippingMethod = @event.ShippingMethod;
			ShippingPostalCode = @event.ShippingPostalCode;
			ShippingState = @event.ShippingState;
			ShippingStreet = @event.ShippingStreet;
			StatusId = @event.StatusId;
			SubTotal = @event.SubTotal;
			TrackingId = @event.TrackingId;
			TransactionId = @event.TransactionId;
		}

		public void Handle(OrderUpdatedEvent @event)
		{
			Id = @event.AggregateId;
			ShippedDate = @event.ShippedDate;
			StatusId = @event.StatusId;
			TrackingId = @event.TrackingId;
			TransactionId = @event.TransactionId;
		}
	}
}

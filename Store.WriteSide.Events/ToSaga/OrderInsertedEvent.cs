using System;

namespace Store.WriteSide.Events.ToSaga
{
	public class OrderInsertedEvent : IOrderInsertedEvent
	{
		public Guid AggregateId { get; set; }
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
	}
}

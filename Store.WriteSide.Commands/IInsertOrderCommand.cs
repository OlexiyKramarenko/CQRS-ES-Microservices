using Infrastructure.Contracts;
using System;

namespace Store.WriteSide.Commands
{
	public interface IInsertOrderCommand : ICommand
	{
		DateTime AddedDate { get; set; }
		string AddedBy { get; set; }
		Guid StatusId { get; set; }
		string ShippingMethod { get; set; }
		decimal SubTotal { get; set; }
		decimal Shipping { get; set; }
		string ShippingFirstName { get; set; }
		string ShippingLastName { get; set; }
		string ShippingStreet { get; set; }
		string ShippingPostalCode { get; set; }
		string ShippingCity { get; set; }
		string ShippingState { get; set; }
		string ShippingCountry { get; set; }
		string CustomerEmail { get; set; }
		string CustomerPhone { get; set; }
		string CustomerFax { get; set; }
		string TransactionId { get; set; }
		DateTime? ShippedDate { get; set; }
		string TrackingId { get; set; }
	}
}

using Infrastructure.Contracts;
using System;

namespace Store.WriteSide.Commands
{
	public interface IUpdateOrderCommand : ICommand
	{
		Guid StatusId { get; set; }
		string TransactionId { get; set; }
		DateTime? ShippedDate { get; set; }
		string TrackingId { get; set; }
	}
}

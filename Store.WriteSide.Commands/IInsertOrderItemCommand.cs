using Infrastructure.Contracts;
using System;

namespace Store.WriteSide.Commands
{
	public interface IInsertOrderItemCommand : ICommand
	{
		DateTime AddedDate { get; set; }
		string AddedBy { get; set; }
		Guid OrderId { get; set; }
		Guid ProductId { get; set; }
		string Title { get; set; }
		string SKU { get; set; }
		decimal UnitPrice { get; set; }
		int Quantity { get; set; } 
	}
}

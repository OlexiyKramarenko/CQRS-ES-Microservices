using Infrastructure.Contracts;
using System;

namespace Store.WriteSide.Events
{
	public interface IShippingMethodInsertedEvent : IEvent
	{
		DateTime AddedDate { get; set; }
		string AddedBy { get; set; }
		string Title { get; set; }
		decimal Price { get; set; }
		string Description { get; set; }
	}
}

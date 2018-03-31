using Infrastructure.Contracts;
using System;

namespace Store.WriteSide.Events
{
	public interface IOrderStatusInsertdEvent : IEvent
	{
		DateTime AddedDate { get; set; }
		string AddedBy { get; set; }
		string Title { get; set; }
	}
}

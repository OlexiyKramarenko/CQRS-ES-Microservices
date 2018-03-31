using Infrastructure.Contracts;
using System;

namespace Store.WriteSide.Events
{
	public interface IDepartmentInsertedEvent : IEvent
	{
		DateTime AddedDate { get; set; }
		string AddedBy { get; set; }
		string Title { get; set; }
		int Importance { get; set; }
		string Description { get; set; }
		string ImageUrl { get; set; }
	}
}

using System;

namespace Store.WriteSide.Events.ToSaga
{
	public class DepartmentUpdatedEvent : IDepartmentUpdatedEvent
	{
		public DateTime AddedDate { get; set; }
		public string Title { get; set; }
		public int Importance { get; set; }
		public string Description { get; set; }
		public string ImageUrl { get; set; }

		public Guid AggregateId { get; set; }
	}
}

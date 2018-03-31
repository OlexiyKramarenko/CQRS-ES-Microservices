using System;

namespace Store.WriteSide.Events.ToSaga
{
	public class DepartmentInsertedEvent : IDepartmentInsertedEvent
	{
		public DateTime AddedDate { get; set; }
		public string AddedBy { get; set; }
		public string Title { get; set; }
		public int Importance { get; set; }
		public string Description { get; set; }
		public string ImageUrl { get; set; } 
		public Guid AggregateId { get; set; }
	}
}

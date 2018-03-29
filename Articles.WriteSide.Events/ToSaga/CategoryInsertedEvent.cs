using Articles.WriteSide.Events.ToSaga.Interfaces;
using System; 

namespace Articles.WriteSide.Events.ToSaga
{
	public class CategoryInsertedEvent : ICategoryInsertedEvent
	{
		public Guid AggregateId { get; set; }
		public DateTime AddedDate { get; set; }
		public string AddedBy { get; set; }
		public string Title { get; set; }
		public int Importance { get; set; }
		public string Description { get; set; }
		public string ImageUrl { get; set; } 
	}
}

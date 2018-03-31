using System;

namespace Store.WriteSide.Events.ToSaga
{
	public class ProductUpdatedEvent : IProductUpdatedEvent
	{
		public Guid AggregateId { get; set; }
		public DateTime AddedDate { get; set; }
		public string AddedBy { get; set; }
		public Guid DepartmentId { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string SKU { get; set; }
		public decimal UnitPrice { get; set; }
		public int DiscountPercentage { get; set; }
		public int UnitsInStock { get; set; }
		public string SmallImageUrl { get; set; }
		public string FullImageUrl { get; set; }
		public int Votes { get; set; }
		public int TotalRating { get; set; } 
	}
}

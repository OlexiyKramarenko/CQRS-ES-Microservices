
using System;

namespace Web.Models.Store
{
	public class AddProductViewModel
	{
		public Guid DepartmentId { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string SKU { get; set; }
		public decimal UnitPrice { get; set; }
		public int DiscountPercentage { get; set; }
		public int UnitsInStock { get; set; }
		public string SmallImageUrl { get; set; }
		public string FullImageUrl { get; set; }
	}
}


using System;

namespace Web.Models.Store
{
	public class ProductItemViewModel
	{
		public Guid Id { get; set; }
		public string ImageUrl { get; set; }
		public string Title { get; set; }
		public int Votes { get; set; }
		public int UnitsInStock { get; set; }
		public int DiscountPercentage { get; set; }
		public decimal FinalUnitPrice { get; set; }		
		public int AverageRating { get; set; }
		public int UnitPrice { get; set; }
	}
}



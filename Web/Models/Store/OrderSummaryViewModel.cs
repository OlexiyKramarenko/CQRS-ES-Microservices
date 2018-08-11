using System.Collections.Generic; 

namespace Web.Models.Store
{
    public class OrderSummaryViewModel
    {
		public IEnumerable<ShoppingCartItemViewModel> ShoppingCartItems { get; set; }
		public string ShippingMethod { get; set; } 		
		public decimal Subtotal { get; set; }
		public decimal Total { get; set; }
		public string ShippingDetails { get; set; }
	}
}

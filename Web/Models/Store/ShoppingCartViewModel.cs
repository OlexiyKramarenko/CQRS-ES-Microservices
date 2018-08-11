using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Web.Models.Store
{
	public class ShoppingCartViewModel
	{
		//public string ShippingMethod { get; set; }
		//public decimal ShippingMethodPrice { get; set; }
		//public IEnumerable<SelectListItem> ShippingMethods { get; set; }
		public IEnumerable<ShoppingCartItemViewModel> ShoppingCartItems { get; set; }
	}
}

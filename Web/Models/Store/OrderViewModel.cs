
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic; 

namespace Web.Models.Store
{
    public class OrderViewModel
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Street { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string PostalCode { get; set; }
		public string Country { get; set; } 

		public decimal Subtotal { get; set; }
		public SelectList ShippingMethods { get; set; }
		public Guid ShippingMethodId { get; set; }
		public decimal Total { get; set; }
		public List<OrderItemViewModel> OrderItems { get; set; }
	}
}



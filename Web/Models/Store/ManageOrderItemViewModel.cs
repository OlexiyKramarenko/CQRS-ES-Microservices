using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Web.Models.Store
{
	public class ManageOrderItemViewModel
	{
		public Guid Id { get; set; }
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
		public DateTime AddedDate { get; set; }
		public string ShippingLastName { get; set; }
		public int Subtotal { get; set; }
		public string Shipping { get; set; }
		public IEnumerable<ManageOrderedItemViewModel> OrderItems { get; set; } = new List<ManageOrderedItemViewModel>();
	}
}

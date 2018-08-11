using System;

namespace Web.Models.Store
{
    public class EditShippingMethodViewModel
    {
		public Guid Id { get; set; }
		public string AddedBy { get; set; }
		public string Title { get; set; }
		public decimal Price { get; set; }
	}
}

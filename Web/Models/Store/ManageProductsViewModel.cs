using System.Collections.Generic;

namespace Web.Models.Store
{
    public class ManageProductsViewModel
    {
		public IEnumerable<ManageOrderItemViewModel> ProductItems { get; set; }
	}
}

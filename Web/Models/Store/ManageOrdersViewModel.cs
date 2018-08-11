
using System.Collections.Generic;

namespace Web.Models.Store
{
    public class ManageOrdersViewModel
    {
		public IEnumerable<ManageOrderItemViewModel> OrderItems { get; set; }		
	}
}

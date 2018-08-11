
using System;

namespace Web.Models.Store
{
    public class ShowProductViewModel
    {
		public Guid Id { get; set; }
		public string Title { get; set; }   
        public string Description { get; set; }
		public decimal UnitPrice { get; set; }
	}
}

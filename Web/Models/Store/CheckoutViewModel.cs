using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; 
using Microsoft.AspNetCore.Mvc.Rendering; 

namespace Web.Models.Store
{
    public class CheckoutViewModel
	{
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string PostalCode { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        public List<SelectListItem> Countries { get; set; }
        public string Phone { get; set; }

		public string ShippingMethodId { get; set; }
		public IEnumerable<SelectListItem> ShippingMethods { get; set; }
	}
}

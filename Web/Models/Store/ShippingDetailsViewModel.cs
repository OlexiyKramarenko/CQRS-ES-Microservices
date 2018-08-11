
using System.ComponentModel.DataAnnotations;

namespace Web.Models.Store
{
    public class ShippingDetailsViewModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public double Price { get; set; }
    }
}

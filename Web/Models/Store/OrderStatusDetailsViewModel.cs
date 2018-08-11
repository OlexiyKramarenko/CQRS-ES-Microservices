using System;
using System.ComponentModel.DataAnnotations;

namespace Web.Models.Store
{
    public class OrderStatusDetailsViewModel
    {
        public Guid Id { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
		public DateTime AddedDate { get; set; }
        public string AddedBy { get; set; }
        [Required]
        public string Title { get; set; }
    }
}

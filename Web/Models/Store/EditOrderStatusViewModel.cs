using System;
using System.ComponentModel.DataAnnotations;

namespace Web.Models.Store
{
    public class EditOrderStatusViewModel
    {
		public Guid Id { get; set; }
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
		public DateTime AddedDate { get; set; }
		public string AddedBy { get; set; }
		public string Title { get; set; }
	}
}

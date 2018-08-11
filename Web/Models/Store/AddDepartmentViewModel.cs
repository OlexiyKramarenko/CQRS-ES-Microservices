using System; 
using System.ComponentModel.DataAnnotations; 

namespace Web.Models.Store
{
    public class AddDepartmentViewModel
    { 
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
		public DateTime AddedDate { get; set; }
		public string AddedBy { get; set; }
		[Required]
		public string Title { get; set; }
		[Required]
		public int Importance { get; set; }
		public string ImageUrl { get; set; }
		public string Description { get; set; }
	}
}

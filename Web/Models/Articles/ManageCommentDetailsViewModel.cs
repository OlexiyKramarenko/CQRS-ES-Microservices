using System;
using System.ComponentModel.DataAnnotations;

namespace Web.Models.Articles
{
	public class ManageCommentDetailsViewModel
	{
		public Guid Id { get; set; }
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
		public DateTime AddedDate { get; set; }
		public string AddedByIP { get; set; }
		public string AddedByEmail { get; set; }
		public string Body { get; set; }
	}
}

using System;
using System.ComponentModel.DataAnnotations;

namespace Web.Models.Articles
{
	public class AddArticleViewModel
	{
		public string AddedBy { get; set; }
		public string Category { get; set; }
		public Guid CategoryId { get; set; }
		public string Title { get; set; }
		public string Abstract { get; set; }
		public string Body { get; set; }
		public string Country { get; set; }
		public string State { get; set; }
		public string City { get; set; }
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
		public DateTime ReleaseDate { get; set; }
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]         public DateTime ExpireDate { get; set; }
		public bool Listed { get; set; }
		public bool CommentsEnabled { get; set; }
		public bool OnlyForMembers { get; set; }
		public bool Approved { get; set; }
	}
}

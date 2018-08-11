using System;
using System.ComponentModel.DataAnnotations;

namespace Web.Models.Articles
{
    public class ManageCommentItemViewModel
    {
		public Guid Id { get; set; }
		public string AddedBy { get; set; }
        public string AddedByEmail { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
		public DateTime AddedDate { get; set; }
        public string ArticleTitle { get; set; }
        public string Body { get; set; }
		public Guid ArticleId { get; set; }		
	}
}

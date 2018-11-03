using System;
using System.ComponentModel.DataAnnotations;

namespace Web.Models.Articles
{
    public class CommentDetailsViewModel
    {
        public Guid CategoryId { get; set; }
        public Guid ArticleId { get; set; }
		[Required]
        public string AddedBy { get; set; }
        [Required]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*")]
        public string AddedByEmail { get; set; }
        [Required]
        public string Body { get; set; }
    }
}

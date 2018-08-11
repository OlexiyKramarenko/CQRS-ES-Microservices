using System;

namespace Web.Models.Articles
{
    public class CommentItemViewModel
    {
        public Guid Id { get; set; }
        public string AddedBy { get; set; }
        public string AddedByEmail { get; set; }
        public DateTime AddedDate { get; set; }
        public string Body { get; set; }
    }
}

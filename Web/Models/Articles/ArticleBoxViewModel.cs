using System;

namespace Web.Models.Articles
{
    public class ArticleBoxViewModel
    {
        public string Title { get; set; }
        public bool Approved { get; set; }
        public Guid ArticleId { get; set; }
        public int UserCount { get; set; }
        public string AddedBy { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Category { get; set; }
        public int Views { get; set; }
        public string Location { get; set; }
        public string Abstract { get; set; }
        public string Body { get; set; }
        public double AverageRating { get; set; }
    }
}

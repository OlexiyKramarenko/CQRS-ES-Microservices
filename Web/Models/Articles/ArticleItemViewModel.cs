using System; 

namespace Web.Models.Articles
{
	public class ArticleItemViewModel
	{
		public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public string Title { get; set; }
		public bool OnlyForMembers { get; set; }
		public bool Approved { get; set; }
		public int Votes { get; set; }
		//public int AverageRating { get; set; }
		public string AddedBy { get; set; }
		public DateTime ReleaseDate { get; set; }
		public string CategoryTitle { get; set; }
		public int ViewCount { get; set; }
		public string Location { get; set; }
		public string Abstract { get; set; }
	}
}

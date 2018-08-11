using System;

namespace Web.Models.Articles
{
	public class BrowseArticlesViewModel
	{
		public Guid CategoryId { get; set; }
		public int PageIndex { get; set; }
		public int PageSize { get; set; }
	}
}

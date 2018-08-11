using System.Collections.Generic;

namespace Web.Models.Articles
{
	public class ShowArticleViewModel
	{		
		public List<CommentItemViewModel> Comments { get; set; } = new List<CommentItemViewModel>();
		public CommentDetailsViewModel PostComment { get; set; }
		public string Title { get; set; }
		public string Text { get; set; }
	}
}

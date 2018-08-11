
using System;
using System.Collections.Generic;

namespace Web.Models.Articles
{
    public class ManageCommentsViewModel
    {
		public IEnumerable<ManageCommentItemViewModel> CommentItems { get; set; }
	}
}

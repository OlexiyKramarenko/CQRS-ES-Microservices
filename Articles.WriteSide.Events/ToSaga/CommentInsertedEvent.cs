using Articles.WriteSide.Events.ToSaga.Interfaces;
using System;

namespace Articles.WriteSide.Events.ToSaga
{
	public class CommentInsertedEvent : ICommentInsertedEvent
	{
		public Guid AggregateId { get; set; }
		public DateTime AddedDate { get; set; }
		public string AddedBy { get; set; }
		public string AddedByEmail { get; set; }
		public string AddedByIp { get; set; }
		public string Body { get; set; }
		public Guid ArticleId { get; set; } 
	}
}

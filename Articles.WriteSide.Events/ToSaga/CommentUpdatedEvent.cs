using Articles.WriteSide.Events.ToSaga.Interfaces;
using System;

namespace Articles.WriteSide.Events.ToSaga
{
	public class CommentUpdatedEvent : ICommentUpdatedEvent
	{
		public Guid AggregateId { get; set; }
		public string Body { get; set; } 
	}
}

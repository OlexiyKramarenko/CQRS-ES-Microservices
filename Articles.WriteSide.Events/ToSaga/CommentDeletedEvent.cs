using Articles.WriteSide.Events.ToSaga.Interfaces;
using System;

namespace Articles.WriteSide.Events.ToSaga
{
	public class CommentDeletedEvent : ICommentDeletedEvent
	{
		public Guid AggregateId { get; set; }
	}
}

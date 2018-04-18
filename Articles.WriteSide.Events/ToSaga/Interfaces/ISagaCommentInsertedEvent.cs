using Infrastructure.Contracts;
using System;

namespace Articles.WriteSide.Events.ToSaga.Interfaces
{
	public interface ISagaCommentInsertedEvent : IEvent
	{
		DateTime AddedDate { get; }
		string AddedBy { get; }
		string AddedByEmail { get; }
		string AddedByIp { get; }
		string Body { get; }
		Guid ArticleId { get; }
	}
}

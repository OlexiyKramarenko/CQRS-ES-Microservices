using System;

namespace Articles.Saga.Events.Interfaces
{
	public interface ICommentInsertedEvent
	{
		DateTime AddedDate { get; }
		string AddedBy { get; }
		string AddedByEmail { get; }
		string AddedByIp { get; }
		string Body { get; }
		Guid ArticleId { get; }
        Guid CategoryId { get; }
    }
}

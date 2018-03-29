using Infrastructure.Contracts;
using System;

namespace Articles.WriteSide.Events.ToSaga.Interfaces
{
	public interface ICommentInsertedEvent : IEvent
	{
		DateTime AddedDate { get; set; }
		string AddedBy { get; set; }
		string AddedByEmail { get; set; }
		string AddedByIp { get; set; }
		string Body { get; set; }
		Guid ArticleId { get; set; }
	}
}

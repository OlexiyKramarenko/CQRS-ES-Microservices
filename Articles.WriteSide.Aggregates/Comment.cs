using Articles.WriteSide.Events.ToSaga;
using Infrastructure.Contracts;
using Infrastructure.Domain;
using System;

namespace Articles.WriteSide.Aggregates
{
	public class Comment :
		AggregateRoot,
		IHandle<CommentDeletedEvent>,
		IHandle<CommentInsertedEvent>,
		IHandle<CommentUpdatedEvent>
	{
		public Guid Id { get; set; }
		public DateTime AddedDate { get; set; }
		public string AddedBy { get; set; }
		public string AddedByEmail { get; set; }
		public string AddedByIp { get; set; }
		public string Body { get; set; }
		public Guid ArticleId { get; set; }
		public Article Article { get; set; }

		public Comment()
		{
		}

		public Comment(
			Guid AggregateId,
			DateTime AddedDate,
			string AddedBy,
			string AddedByEmail,
			string AddedByIp,
			string Body,
			Guid ArticleId)
		{
			var @event = new CommentInsertedEvent
			{
				AddedBy = AddedBy,
				AddedByEmail = AddedByEmail,
				AddedByIp = AddedByIp,
				AddedDate = AddedDate,
				AggregateId = AggregateId,
				ArticleId = ArticleId,
				Body = Body
			};
			ApplyChange(@event);
		}

		public void Delete()
		{
			Events.Add(new CommentDeletedEvent { AggregateId = Id });
		}

		public void Update()
		{
			Events.Add(new CommentUpdatedEvent
			{
				AggregateId = Id,
				Body = Body
			});
		}

		public void Handle(CommentDeletedEvent @event)
		{
			Id = @event.AggregateId;
		}

		public void Handle(CommentInsertedEvent @event)
		{
			AddedBy = @event.AddedBy;
			AddedByEmail = @event.AddedByEmail;
			AddedByIp = @event.AddedByIp;
			AddedDate = @event.AddedDate;
			Id = @event.AggregateId;
			ArticleId = @event.ArticleId;
			Body = @event.Body;
		}

		public void Handle(CommentUpdatedEvent @event)
		{
			Id = @event.AggregateId;
			Body = @event.Body;
		}
	}
}

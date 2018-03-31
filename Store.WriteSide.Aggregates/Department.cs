using Infrastructure.Contracts;
using Infrastructure.Domain;
using Store.WriteSide.Events.ToSaga;
using System;

namespace Store.WriteSide.Aggregates
{
	public class Department : AggregateRoot,
		IHandle<DepartmentDeletedEvent>,
		IHandle<DepartmentInsertedEvent>,
		IHandle<DepartmentUpdatedEvent>
	{
		public DateTime AddedDate { get; set; }
		public string AddedBy { get; set; }
		public string Title { get; set; }
		public int Importance { get; set; }
		public string Description { get; set; }
		public string ImageUrl { get; set; }

		public Department()
		{

		}

		public Department(
			Guid Id,
			DateTime AddedDate,
			string AddedBy,
			string Title,
			int Importance,
			string Description,
			string ImageUrl)
		{
			var @event = new DepartmentInsertedEvent
			{
				AggregateId = Id,
				AddedBy = AddedBy,
				AddedDate = AddedDate,
				Title = Title,
				Importance = Importance,
				Description = Description,
				ImageUrl = ImageUrl
			};
			ApplyChange(@event);
		}

		public void Delete(Guid id)
		{
			var @event = new DepartmentDeletedEvent
			{
				AggregateId = id
			};
			ApplyChange(@event);
		}

		public void Update(
			Guid Id,
			DateTime AddedDate,
			string Title,
			int Importance,
			string Description,
			string ImageUrl)
		{
			var @event = new DepartmentUpdatedEvent
			{
				AggregateId = Id,
				AddedDate = AddedDate,
				Description = Description,
				ImageUrl = ImageUrl,
				Importance = Importance,
				Title = Title
			};
			ApplyChange(@event);
		}

		public void Handle(DepartmentUpdatedEvent @event)
		{
			AddedDate = @event.AddedDate;
			Description = @event.Description;
			ImageUrl = @event.ImageUrl;
			Importance = @event.Importance;
			Title = @event.Title;
		}

		public void Handle(DepartmentInsertedEvent @event)
		{
			Id = @event.AggregateId;
			AddedBy = @event.AddedBy;
			AddedDate = @event.AddedDate;
			Description = @event.Description;
			ImageUrl = @event.ImageUrl;
			Importance = @event.Importance;
			Title = @event.Title;
		}

		public void Handle(DepartmentDeletedEvent @event)
		{
			Id = @event.AggregateId;
		}
	}
}

using Articles.WriteSide.Events.ToSaga;
using Infrastructure.Contracts;
using Infrastructure.Domain;
using System;

namespace Articles.WriteSide.Aggregates
{
	public class Category :
		AggregateRoot,
		IHandle<CategoryDeletedEvent>,
		IHandle<CategoryInsertedEvent>
	{
		public Guid Id { get; set; }
		public DateTime AddedDate { get; set; }
		public string AddedBy { get; set; }
		public string Title { get; set; }
		public int Importance { get; set; }
		public string Description { get; set; }
		public string ImageUrl { get; set; }

		public Category()
		{

		}
		public Category(
			Guid id,
			DateTime AddedDate,
			string AddedBy,
			string Title,
			int Importance,
			string Description,
			string ImageUrl)
		{
			var @event = new CategoryInsertedEvent
			{
				AddedBy = AddedBy,
				AggregateId = id,
				AddedDate = AddedDate,
				Description = Description,
				ImageUrl = ImageUrl,
				Importance = Importance,
				Title = Title
			};
			ApplyChange(@event);
		}

		public void Update(
			Guid id,
			string title,
			int importance,
			string description,
			string imageUrl)
		{
			Events.Add(new CategoryUpdatedEvent
			{
				AggregateId = Id,
				Description = description,
				ImageUrl = imageUrl,
				Importance = importance,
				Title = title
			});
		}

		public void Delete()
		{
			Events.Add(new CategoryDeletedEvent { AggregateId = Id });
		}

		public void Handle(CategoryInsertedEvent @event)
		{
			AddedBy = @event.AddedBy;
			AddedDate = @event.AddedDate;
			Id = @event.AggregateId;
			Description = @event.Description;
			ImageUrl = @event.ImageUrl;
			Importance = @event.Importance;
			Title = @event.Title;
		}

		public void Handle(CategoryDeletedEvent @event)
		{
			Id = @event.AggregateId;
		}

	}
}

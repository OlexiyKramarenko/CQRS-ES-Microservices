using Infrastructure.Contracts;
using Infrastructure.Domain;
using Store.WriteSide.Events.ToSaga;
using System;

namespace Store.WriteSide.Aggregates
{
	public class Product : AggregateRoot,
		IHandle<ProductDeletedEvent>,
		IHandle<ProductInsertedEvent>,
		IHandle<ProductRatedEvent>,
		IHandle<ProductUpdatedEvent>,
		IHandle<DecrementProductUnitsInStockEvent>
	{
		public DateTime AddedDate { get; set; }
		public string AddedBy { get; set; }
		public Guid DepartmentId { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string SKU { get; set; }
		public decimal UnitPrice { get; set; }
		public int DiscountPercentage { get; set; }
		public int UnitsInStock { get; set; }
		public string SmallImageUrl { get; set; }
		public string FullImageUrl { get; set; }
		public int Votes { get; set; }
		public int TotalRating { get; set; }

		public Product()
		{

		}
		public Product(
			Guid Id,
			DateTime AddedDate,
			string AddedBy,
			Guid DepartmentId,
			string Title,
			string Description,
			string SKU,
			decimal UnitPrice,
			int DiscountPercentage,
			int UnitsInStock,
			string SmallImageUrl,
			string FullImageUrl,
			int Votes,
			int TotalRating)
		{
			var @event = new ProductInsertedEvent
			{
				AggregateId = Id,
				AddedDate = AddedDate,
				AddedBy = AddedBy,
				DepartmentId = DepartmentId,
				Title = Title,
				Description = Description,
				SKU = SKU,
				UnitPrice = UnitPrice,
				DiscountPercentage = DiscountPercentage,
				UnitsInStock = UnitsInStock,
				SmallImageUrl = SmallImageUrl,
				FullImageUrl = FullImageUrl,
				Votes = Votes,
				TotalRating = TotalRating
			};
			ApplyChange(@event);
		}

		public void Delete()
		{
			var @event = new ProductDeletedEvent
			{
				AggregateId = Id
			};
			ApplyChange(@event);
		}

		public void Rate(int rating)
		{
			var @event = new ProductRatedEvent
			{
				AggregateId = Id,
				Rating = rating
			};
			ApplyChange(@event);
		}

		public void Update(
			DateTime addedDate,
			string addedBy,
			Guid departmentId,
			string title,
			string description,
			string SKU,
			decimal unitPrice,
			int discountPercentage,
			int unitsInStock,
			string smallImageUrl,
			string fullImageUrl,
			int votes,
			int totalRating)
		{
			var @event = new ProductUpdatedEvent
			{
				AggregateId = Id,
				AddedBy = addedBy,
				AddedDate = addedDate,
				DepartmentId = departmentId,
				Description = description,
				DiscountPercentage = discountPercentage,
				FullImageUrl = fullImageUrl,
				SKU = SKU,
				SmallImageUrl = smallImageUrl,
				Title = title,
				TotalRating = totalRating,
				UnitPrice = unitPrice,
				UnitsInStock = unitsInStock,
				Votes = votes
			};
			ApplyChange(@event);
		}

		public void DecrementProductUnitsInStock(int quantity)
		{
			var @event = new DecrementProductUnitsInStockEvent
			{
				AggregateId = Id,
				Quantity = quantity
			};
			ApplyChange(@event);
		}

		public void Handle(ProductInsertedEvent @event)
		{
			AddedBy = @event.AddedBy;
			AddedDate = @event.AddedDate;
			Id = @event.AggregateId;
			DepartmentId = @event.DepartmentId;
			Description = @event.Description;
			DiscountPercentage = @event.DiscountPercentage;
			FullImageUrl = @event.FullImageUrl;
			SKU = @event.SKU;
			SmallImageUrl = @event.SmallImageUrl;
			Title = @event.Title;
			TotalRating = @event.TotalRating;
			UnitPrice = @event.UnitPrice;
			UnitsInStock = @event.UnitsInStock;
			Votes = @event.Votes;
		}

		public void Handle(ProductRatedEvent @event)
		{
			Id = @event.AggregateId;
			TotalRating = @event.Rating;
		}

		public void Handle(ProductUpdatedEvent @event)
		{
			AddedBy = @event.AddedBy;
			AddedDate = @event.AddedDate;
			Id = @event.AggregateId;
			DepartmentId = @event.DepartmentId;
			Description = @event.Description;
			DiscountPercentage = @event.DiscountPercentage;
			FullImageUrl = @event.FullImageUrl;
			SKU = @event.SKU;
			SmallImageUrl = @event.SmallImageUrl;
			Title = @event.Title;
			TotalRating = @event.TotalRating;
			UnitPrice = @event.UnitPrice;
		}

		public void Handle(ProductDeletedEvent @event)
		{
			Id = @event.AggregateId;
		}

		public void Handle(DecrementProductUnitsInStockEvent @event)
		{
			Id = @event.AggregateId;
			//@event.Quantity;
		}
	}
}

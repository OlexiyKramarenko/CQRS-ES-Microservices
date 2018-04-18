using Articles.WriteSide.Commands.Cancel;
using Articles.WriteSide.Events.ToSaga;
using Infrastructure.Contracts;
using Infrastructure.Domain;
using System;
using System.Collections.Generic;

namespace Articles.WriteSide.Aggregates
{
	public class Article :
		AggregateRoot,
		IHandle<ArticleApprovedEvent>,
		IHandle<ArticleDeletedEvent>,
		IHandle<ArticleInsertedEvent>,
		IHandle<ArticleRatedEvent>,
		IHandle<ArticleUpdatedCommand>,
		IHandle<ArticleViewCountIncrementedEvent>
	{
		public DateTime AddedDate { get; set; }
		public string AddedBy { get; set; }
		public Guid CategoryId { get; set; }
		public string Title { get; set; }
		public string Abstract { get; set; }
		public string Body { get; set; }
		public string Country { get; set; }
		public string State { get; set; }
		public string City { get; set; }
		public DateTime ReleaseDate { get; set; }
		public DateTime ExpireDate { get; set; }
		public bool Approved { get; set; }
		public bool Listed { get; set; }
		public bool CommentsEnabled { get; set; }
		public bool OnlyForMembers { get; set; }
		public int ViewCount { get; set; }
		public int Rating { get; set; }
		public int Votes { get; set; }
		public int TotalRating { get; set; }
		public List<Comment> Comments { get; set; }
		public Category Category { get; set; }
		public Article()
		{

		}
		public Article(
			Guid id,
			DateTime addedDate,
			string addedBy,
			Guid categoryId,
			string title,
			string @abstract,
			string body,
			string country,
			string state,
			string city,
			DateTime releaseDate,
			DateTime expireDate,
			bool approved,
			bool listed,
			bool commentsEnabled,
			bool onlyForMembers,
			int viewCount,
			int votes,
			int totalRating)
		{
			var @event = new ArticleInsertedEvent
			{
				AggregateId = id,
				AddedDate = addedDate,
				AddedBy = addedBy,
				CategoryId = categoryId,
				Title = title,
				Abstract = @abstract,
				Body = body,
				Country = country,
				State = state,
				City = city,
				ReleaseDate = releaseDate,
				ExpireDate = expireDate,
				Approved = approved,
				Listed = listed,
				CommentsEnabled = commentsEnabled,
				OnlyForMembers = onlyForMembers,
				ViewCount = viewCount,
				Votes = votes,
				TotalRating = totalRating
			};
			ApplyChange(@event);
		}

		public void Update(
			Guid categoryId,
			string title,
			string @abstract,
			string body,
			string country,
			string state,
			string city,
			DateTime releaseDate,
			DateTime expireDate,
			bool approved,
			bool listed,
			bool commentsEnabled,
			bool onlyForMembers)
		{
			var @event = new ArticleUpdatedCommand
			{
				AggregateId = Id,
				Abstract = @abstract,
				Approved = approved,
				Body = body,
				CategoryId = categoryId,
				City = city,
				CommentsEnabled = commentsEnabled,
				Country = country,
				ExpireDate = expireDate,
				Listed = listed,
				OnlyForMembers = onlyForMembers,
				ReleaseDate = releaseDate,
				State = state,
				Title = title
			};
			ApplyChange(@event);
		}

		public void Delete()
		{
			var @event = new ArticleDeletedEvent
			{
				AggregateId = Id
			};
			ApplyChange(@event);
		}

		public void RateArticle(int rating)
		{
			var @event = new ArticleRatedEvent
			{
				AggregateId = Id,
				Rating = rating
			};
			ApplyChange(@event);
		}

		public void IncrementArticleViewCount()
		{
			var @event = new ArticleViewCountIncrementedEvent
			{
				AggregateId = Id
			};
			ApplyChange(@event);
		}

		public void Approve()
		{
			var @event = new ArticleApprovedEvent
			{
				AggregateId = Id
			};
			ApplyChange(@event);
		}



		public void Handle(ArticleApprovedEvent @event)
		{
			Id = @event.AggregateId;
		}

		public void Handle(ArticleDeletedEvent @event)
		{
			Id = @event.AggregateId;
		}

		public void Handle(ArticleInsertedEvent @event)
		{
			Abstract = @event.Abstract;
			AddedBy = @event.AddedBy;
			AddedDate = @event.AddedDate;
			Id = @event.AggregateId;
			Approved = @event.Approved;
			Body = @event.Body;
			CategoryId = @event.CategoryId;
			City = @event.City;
			CommentsEnabled = @event.CommentsEnabled;
			Country = @event.Country;
			ExpireDate = @event.ExpireDate;
			Listed = @event.Listed;
			OnlyForMembers = @event.OnlyForMembers;
			ReleaseDate = @event.ReleaseDate;
			State = @event.State;
			Title = @event.Title;
			TotalRating = @event.TotalRating;
			ViewCount = @event.ViewCount;
			Votes = @event.Votes;
		}

		public void Handle(ArticleRatedEvent @event)
		{
			Id = @event.AggregateId;
			Rating = @event.Rating;
		}

		public void Handle(ArticleUpdatedCommand @event)
		{
			Abstract = @event.Abstract;
			Id = @event.AggregateId;
			Approved = @event.Approved;
			Body = @event.Body;
			CategoryId = @event.CategoryId;
			City = @event.City;
			CommentsEnabled = @event.CommentsEnabled;
			Country = @event.Country;
			ExpireDate = @event.ExpireDate;
			Listed = @event.Listed;
			OnlyForMembers = @event.OnlyForMembers;
			ReleaseDate = @event.ReleaseDate;
			State = @event.State;
			Title = @event.Title;
		}

		public void Handle(ArticleViewCountIncrementedEvent @event)
		{
			Id = @event.AggregateId;
		}

		public void Handle(IInsertCommentCancelCommand @event)
		{
			
		}
	}
}

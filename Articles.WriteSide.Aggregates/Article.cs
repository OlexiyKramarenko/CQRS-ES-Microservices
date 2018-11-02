using Articles.WriteSide.Events.ToSaga;
using Infrastructure.Contracts;
using Infrastructure.Domain;
using System;
using System.Collections.Generic;

namespace Articles.WriteSide.Aggregates
{
    public class Article :
        AggregateRoot,
        IHandle<SagaArticleApprovedEvent>,
        IHandle<SagaArticleDeletedEvent>,
        IHandle<SagaArticleInsertedEvent>,
        IHandle<SagaArticleRatedEvent>,
        IHandle<SagaArticleUpdatedEvent>,
        IHandle<SagaArticleViewCountIncrementedEvent>
    {
        public DateTime AddedDate { get; private set; }
        public string AddedBy { get; private set; }
        public Guid CategoryId { get; private set; }
        public string Title { get; private set; }
        public string Abstract { get; private set; }
        public string Body { get; private set; }
        public string Country { get; private set; }
        public string State { get; private set; }
        public string City { get; private set; }
        public DateTime ReleaseDate { get; private set; }
        public DateTime ExpireDate { get; private set; }
        public bool Approved { get; private set; }
        public bool Listed { get; private set; }
        public bool CommentsEnabled { get; private set; }
        public bool OnlyForMembers { get; private set; }
        public int ViewCount { get; private set; }
        public int Rating { get; private set; }
        public int Votes { get; private set; }
        public int TotalRating { get; private set; }
        public List<Comment> Comments { get; private set; }
        public Category Category { get; private set; }

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
            var @event = new SagaArticleInsertedEvent
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
            var @event = new SagaArticleUpdatedEvent
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
            var @event = new SagaArticleDeletedEvent
            {
                AggregateId = Id
            };
            ApplyChange(@event);
        }

        public void RateArticle(int rating)
        {
            var @event = new SagaArticleRatedEvent
            {
                AggregateId = Id,
                Rating = rating
            };
            ApplyChange(@event);
        }

        public void IncrementArticleViewCount()
        {
            var @event = new SagaArticleViewCountIncrementedEvent
            {
                AggregateId = Id
            };
            ApplyChange(@event);
        }

        public void Approve()
        {
            var @event = new SagaArticleApprovedEvent
            {
                AggregateId = Id
            };
            ApplyChange(@event);
        }

        public void Handle(SagaArticleApprovedEvent @event)
        {
            Id = @event.AggregateId;
        }

        public void Handle(SagaArticleDeletedEvent @event)
        {
            Id = @event.AggregateId;
        }

        public void Handle(SagaArticleInsertedEvent @event)
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

        public void Handle(SagaArticleRatedEvent @event)
        {
            Id = @event.AggregateId;
            Rating = @event.Rating;
        }

        public void Handle(SagaArticleUpdatedEvent @event)
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

        public void Handle(SagaArticleViewCountIncrementedEvent @event)
        {
            Id = @event.AggregateId;
        }
    }
}

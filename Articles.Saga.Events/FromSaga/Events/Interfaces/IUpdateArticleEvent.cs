using System;

namespace Articles.Saga.Events.FromSaga.Events.Interfaces
{
    public interface IUpdateArticleEvent
    {
        Guid Id { get; }
        Guid CategoryId { get; }
        string Title { get; }
        string Abstract { get; }
        string Body { get; }
        string Country { get; }
        string State { get; }
        string City { get; }
        DateTime ReleaseDate { get; }
        DateTime ExpireDate { get; }
        bool Approved { get; }
        bool Listed { get; }
        bool CommentsEnabled { get; }
        bool OnlyForMembers { get; }
    }
}

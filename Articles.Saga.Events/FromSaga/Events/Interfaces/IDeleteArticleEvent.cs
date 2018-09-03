using System;

namespace Articles.Saga.Events.FromSaga.Events.Interfaces
{
    public interface IDeleteArticleEvent
    {
        Guid Id { get; }
    }
}

using System;

namespace Articles.Saga.Events.FromSaga.Events.Interfaces
{
    public interface IRateArticleEvent
    {
        Guid Id { get; }
        int Rating { get; }
    }
}

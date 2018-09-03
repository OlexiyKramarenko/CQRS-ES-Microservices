using System;

namespace Articles.Saga.Events.FromSaga.Events.Interfaces
{
    public interface IUpdateCommentEvent
    {
        Guid Id { get; }
        string Body { get; }
    }
}

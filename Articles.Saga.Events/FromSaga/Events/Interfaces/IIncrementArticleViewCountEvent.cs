using System;

namespace Articles.Saga.Events.FromSaga.Events.Interfaces
{
    public interface IIncrementArticleViewCountEvent
    {
        Guid CorrelationId { get; }
    }
}

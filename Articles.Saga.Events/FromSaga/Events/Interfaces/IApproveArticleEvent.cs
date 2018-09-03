using System;

namespace Articles.Saga.Events.FromSaga.Events.Interfaces
{
    public interface IApproveArticleEvent
    {
        Guid Id { get; }
    }
}

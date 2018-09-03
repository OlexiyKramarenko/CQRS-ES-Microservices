using System;

namespace Articles.Saga.Events.FromSaga.Events.Interfaces
{
    public interface IDeleteCategoryEvent
    {
        Guid Id { get; }
    }
}

using System;

namespace Articles.Saga.Events.FromSaga.Events.Interfaces
{
    public interface IUpdateCategoryEvent
    {
        Guid Id { get; }
        string Title { get; }
        int Importance { get; }
        string Description { get; }
        string ImageUrl { get; }
    }
}

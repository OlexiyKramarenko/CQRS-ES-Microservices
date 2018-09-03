using System;

namespace Articles.Saga.Events.FromSaga.Events.Interfaces
{
    public interface IInsertCategoryEvent
    {
        DateTime AddedDate { get; }
        string AddedBy { get; }
        string Title { get; }
        int Importance { get; }
        string Description { get; }
        string ImageUrl { get; }
    }
}

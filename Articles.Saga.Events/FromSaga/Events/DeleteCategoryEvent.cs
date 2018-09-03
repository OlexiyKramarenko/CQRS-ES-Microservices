using Articles.Saga.Events.FromSaga.Events.Interfaces;
using System;
using Articles.Saga.Events.FromSaga.States;

namespace Articles.Saga.Events.FromSaga.Events
{
    public class DeleteCategoryEvent : IDeleteCategoryEvent
    {
        private readonly DeleteCategorySagaState sagaState;

        public DeleteCategoryEvent(DeleteCategorySagaState sagaState)
        {
            this.sagaState = sagaState;
        }

        public Guid Id => sagaState.Id;
    }
}

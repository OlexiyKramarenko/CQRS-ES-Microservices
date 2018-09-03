using Articles.Saga.Events.FromSaga.Events.Interfaces;
using System;
using Articles.Saga.Events.FromSaga.States;

namespace Articles.Saga.Events.FromSaga.Events
{
    public class UpdateCategoryEvent : IUpdateCategoryEvent
    {
        private readonly UpdateCategorySagaState sagaState;

        public UpdateCategoryEvent(UpdateCategorySagaState sagaState)
        {
            this.sagaState = sagaState;
        }

        public Guid Id => sagaState.Id;
        public string Title => sagaState.Title;
        public int Importance => sagaState.Importance;
        public string Description => sagaState.Description;
        public string ImageUrl => sagaState.ImageUrl;
    }
}

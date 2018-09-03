using Articles.Saga.Events.FromSaga.Events.Interfaces;
using System;
using Articles.Saga.Events.FromSaga.States;

namespace Articles.Saga.Events.FromSaga.Events
{
    public class DeleteArticleEvent : IDeleteArticleEvent
    {
        private readonly DeleteArticleSagaState sagaState;

        public DeleteArticleEvent(DeleteArticleSagaState sagaState)
        {
            this.sagaState = sagaState;
        }

        public Guid Id => sagaState.Id;
    }
}

using Articles.Saga.Events.FromSaga.Events.Interfaces;
using System;
using Articles.Saga.Events.FromSaga.States;

namespace Articles.Saga.Events.FromSaga.Events
{
    public class DeleteCommentEvent : IDeleteCommentEvent
    {
        private readonly DeleteCommentSagaState sagaState;

        public DeleteCommentEvent(DeleteCommentSagaState sagaState)
        {
            this.sagaState = sagaState;
        }

        public Guid Id => sagaState.Id;
    }
}

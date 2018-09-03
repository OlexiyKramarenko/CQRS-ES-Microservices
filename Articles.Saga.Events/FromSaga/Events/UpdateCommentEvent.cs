using Articles.Saga.Events.FromSaga.Events.Interfaces;
using System;
using Articles.Saga.Events.FromSaga.States;

namespace Articles.Saga.Events.FromSaga.Events
{
    public class UpdateCommentEvent : IUpdateCommentEvent
    {
        private readonly UpdateCommentSagaState sagaState;

        public UpdateCommentEvent(UpdateCommentSagaState sagaState)
        {
            this.sagaState = sagaState;
        }

        public Guid Id => sagaState.Id;
        public string Body => sagaState.Body;
    }
}

using Articles.Saga.Events.FromSaga.Events.Interfaces;
using System;
using Articles.Saga.Events.FromSaga.States;

namespace Articles.Saga.Events.FromSaga.Events
{
    public class IncrementArticleViewCountEvent : IIncrementArticleViewCountEvent
    {
        private readonly IncrementArticleViewCountSagaState sagaState;

        public IncrementArticleViewCountEvent(IncrementArticleViewCountSagaState sagaState)
        {
            this.sagaState = sagaState;
        }

        public Guid Id => sagaState..Id;
    }
}

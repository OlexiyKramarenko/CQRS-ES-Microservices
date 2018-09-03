using Articles.Saga.Events.FromSaga.Events.Interfaces;
using System;
using Articles.Saga.Events.FromSaga.States;

namespace Articles.Saga.Events.FromSaga.Events
{
    public class RateArticleEvent : IRateArticleEvent
    {
        private readonly RateArticleSagaState sagaState;

        public RateArticleEvent(RateArticleSagaState sagaState)
        {
            this.sagaState = sagaState;
        }

        public Guid Id => sagaState.Id;
        public int Rating => sagaState.Rating;
    }
}

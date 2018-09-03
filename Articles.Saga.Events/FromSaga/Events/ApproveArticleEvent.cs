using Articles.Saga.Events.FromSaga.Events.Interfaces;
using Articles.Saga.Events.FromSaga.States;
using System;

namespace Articles.Saga.Events.FromSaga.Events
{
    public class ApproveArticleEvent : IApproveArticleEvent
    {
        private readonly ApproveArticleSagaState sagaState;

        public ApproveArticleEvent(ApproveArticleSagaState sagaState)
        {
            this.sagaState = sagaState;
        }

        public Guid Id => sagaState.Id;
    }
}

using Automatonymous;
using System;

namespace Articles.Saga.Events.FromSaga.States
{
    public class InsertArticleSagaState : SagaStateMachineInstance
    {
        public Guid CorrelationId { get; set; }
        public State CurrentState { get; set; }

        public DateTime AddedDate { get; set; }
        public string AddedBy { get; set; }
        public Guid CategoryId { get; set; }
        public string Title { get; set; }
        public string Abstract { get; set; }
        public string Body { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public bool Approved { get; set; }
        public bool Listed { get; set; }
        public bool CommentsEnabled { get; set; }
        public bool OnlyForMembers { get; set; }
        public int ViewCount { get; set; }
        public int Votes { get; set; }
        public int TotalRating { get; set; }
        public Guid AggregateId { get; set; }
    }
}

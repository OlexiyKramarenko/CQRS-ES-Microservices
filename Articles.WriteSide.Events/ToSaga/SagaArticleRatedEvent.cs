using Articles.WriteSide.Events.ToSaga.Interfaces;
using System; 

namespace Articles.WriteSide.Events.ToSaga
{
	public class SagaArticleRatedEvent : ISagaArticleRatedEvent
	{
		public Guid AggregateId { get; set; }
		public int Rating { get; set; }  
	}
}

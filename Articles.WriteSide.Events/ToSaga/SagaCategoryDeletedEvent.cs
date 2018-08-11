using Articles.WriteSide.Events.ToSaga.Interfaces;
using System; 

namespace Articles.WriteSide.Events.ToSaga
{
	public class SagaCategoryDeletedEvent : ISagaCategoryDeletedEvent
	{
		public Guid AggregateId { get; set; }
	}
}

using Articles.WriteSide.Events.ToSaga.Interfaces;
using System; 

namespace Articles.WriteSide.Events.ToSaga
{
	public class CategoryDeletedEvent : ICategoryDeletedEvent
	{
		public Guid AggregateId { get; set; }
	}
}

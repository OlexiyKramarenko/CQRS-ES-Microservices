using System;

namespace Store.WriteSide.Events.ToSaga
{
	public class DepartmentDeletedEvent : IDepartmentDeletedEvent
	{
		public Guid AggregateId { get; set; }
	}
}

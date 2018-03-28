using Infrastructure.Domain;
using System;
using System.Threading.Tasks;

namespace Infrastructure.DataAccess
{
	public interface IEventRepository 
	{
		Task PersistAsync<TAggregate>(TAggregate aggregate)
			where TAggregate : class, IAggregateRoot ;
		
		Task<TAggregate> GetByIdAsync<TAggregate>(Guid id)
			where TAggregate : IAggregateRoot , new();
	}
}

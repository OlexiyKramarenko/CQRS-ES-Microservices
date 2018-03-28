using System;

namespace Infrastructure.DataAccess
{
	public interface IUnitOfWork : IDisposable
	{
		void BeginTransaction();
		void Commit();
		void Rollback();
	}
}

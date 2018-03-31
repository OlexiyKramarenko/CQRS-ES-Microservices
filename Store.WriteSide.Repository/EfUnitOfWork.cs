using Infrastructure.DataAccess;
using System;

namespace Store.WriteSide.Repository
{
	public class EfUnitOfWork : IUnitOfWork
	{
		private readonly StoreEventContext _context;

		public StoreEventContext Context { get { return _context; } }

		public EfUnitOfWork(StoreEventContext context)
		{
			_context = context;
		}

		public void Commit()
		{
			int result = this.Context.SaveChanges();
		}

		public void BeginTransaction()
		{
			throw new NotImplementedException();
		}
		public void Rollback()
		{
			throw new NotImplementedException();
		}
		private bool disposed = false;

		protected virtual void Dispose(bool disposing)
		{
			if (!this.disposed)
			{
				if (disposing)
				{
					_context.Dispose();
				}
			}
			this.disposed = true;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}

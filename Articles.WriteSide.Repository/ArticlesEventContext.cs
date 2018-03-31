using Infrastructure.EventStore;
using Microsoft.EntityFrameworkCore;

namespace Articles.WriteSide.Repository
{
	public class ArticlesEventContext : DbContext
	{
		public DbSet<EventStoreEntity> Events { get; set; }

		private readonly string _connectionString;

		public ArticlesEventContext(string connectionString)
		{
			_connectionString = connectionString;
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(_connectionString);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<EventStoreEntity>().HasKey(a => a.Id);
		}
	}
}

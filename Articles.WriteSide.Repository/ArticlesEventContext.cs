using Infrastructure.EventStore;
using Microsoft.EntityFrameworkCore; 

namespace Articles.WriteSide.Repository
{
  public  class ArticlesEventContext : DbContext
	{
		public DbSet<EventStoreEntity> Events { get; set; }
				
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<EventStoreEntity>().HasKey(a => a.Id);
		}
	}
}

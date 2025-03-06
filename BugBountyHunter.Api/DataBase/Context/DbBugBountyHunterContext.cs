using BugBountyHunter.Api.DataBase.Entities;
using Microsoft.EntityFrameworkCore;

namespace BugBountyHunter.Api.DataBase.Context
{
    public class DbBugBountyHunterContext : DbContext, IDataContext
    {
        public DbBugBountyHunterContext()
        {
            
        }
        public DbBugBountyHunterContext(DbContextOptions<DbBugBountyHunterContext> options) : base(options)
        {
            
        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<ProgramEntity> Programs { get; set; }
        public DbSet<RapportEntity> Rapports { get; set; }
        public DbSet<EtsEntity> Ets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
    
        }
        IQueryable<T> IDataContext.Set<T>()
        {
            return base.Set<T>();
        }
    }
}

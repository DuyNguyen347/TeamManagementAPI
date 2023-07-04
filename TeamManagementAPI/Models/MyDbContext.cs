using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace TeamManagementAPI.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options) { }


        #region DbSet
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Stadium> Stadiums { get; set;}
        public DbSet<League> Leagues { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<League>()
            .HasQueryFilter(league => EF.Property<bool>(league, "isDeleted") == false);
            modelBuilder.Entity<Team>()
            .HasQueryFilter(league => EF.Property<bool>(league, "isDeleted") == false);
            modelBuilder.Entity<Stadium>()
            .HasQueryFilter(league => EF.Property<bool>(league, "isDeleted") == false);
            modelBuilder.Entity<Player>()
            .HasQueryFilter(league => EF.Property<bool>(league, "isDeleted") == false);
        }
    }
}

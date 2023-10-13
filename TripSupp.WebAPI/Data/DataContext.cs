using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TripSupp.WebAPI.Models;

namespace TripSupp.WebAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Destination>()
                .HasKey(b => new { b.DestinationId });
            modelBuilder.Entity<User>()
                .HasKey(b => new { b.Id });
        }
    }
}
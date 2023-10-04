using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TripSupp.WebAPI.Data.Models;

namespace TripSupp.WebAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Destination> Destinations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Destination>()
                .HasKey(b => new { b.DestinationId });
        }
    }
}
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.DataAccess
{
    

    public class CounterDbContext : DbContext
    {
        public CounterDbContext(DbContextOptions<CounterDbContext> options)
            : base(options)
        {
        }

        public DbSet<Counter> Counters { get; set; }
    }
}

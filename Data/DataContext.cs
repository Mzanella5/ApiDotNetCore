using Microsoft.EntityFrameworkCore;

namespace ApiTest.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Shift> shifts { get; set; }
        public DbSet<Store> stores { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    }
}

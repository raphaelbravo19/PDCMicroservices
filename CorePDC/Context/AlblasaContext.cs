using Microsoft.EntityFrameworkCore;

namespace CorePDC.Context
{
    public class AlblasaContext : DbContext, IAlblasaContext
    {
        public AlblasaContext(DbContextOptions<AlblasaContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Store> Stores { get; set; }
    }
}

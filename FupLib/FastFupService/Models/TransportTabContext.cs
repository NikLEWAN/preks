using Microsoft.EntityFrameworkCore;

namespace FastFupService.Models
{
    public class TransportTabContext : DbContext
    {
        public TransportTabContext(DbContextOptions<TransportTabContext> options)
            : base(options)
        {
        }

        public DbSet<TransportTab> TransportTabs { get; set; }
    }
}

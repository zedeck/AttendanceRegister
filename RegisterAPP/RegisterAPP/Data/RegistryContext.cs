using Microsoft.EntityFrameworkCore;
using RegisterAPP.Models;

namespace RegisterAPP.Data
{
    public class RegistryContext : DbContext
    {
        public RegistryContext(DbContextOptions<RegistryContext> opt) : base(opt)
        {

        }
        public DbSet<Registry> AttendaceRegistry { get; set; }
    }
}

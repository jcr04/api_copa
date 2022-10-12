using Microsoft.EntityFrameworkCore;

namespace api_copa.Models
{
    public class AdministradorContext : DbContext
    {
        public AdministradorContext(DbContextOptions<AdministradorContext> options)
            : base(options) 
        { 
        }
        public DbSet<AdministradorContext> administradorContexts { get; set; } = null!;
    }
}

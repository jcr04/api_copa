using api_copa.Model;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;



namespace api_copa.Models
{
    public class ClubeContext : DbContext
    {
        public ClubeContext(DbContextOptions<ClubeContext> options)
            : base(options) 
        { 
        }

        public DbSet<Clube> Clubs { get; set; } = null!;
    }
}

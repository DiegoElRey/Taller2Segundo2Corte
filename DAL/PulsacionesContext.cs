using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Entity;
namespace DAL
{
    public class PulsacionesContext : DbContext
    {
        public PulsacionesContext(DbContextOptions options):base(options)
        {
        }
        public DbSet<Persona> Personas { get; set; }
    }
}
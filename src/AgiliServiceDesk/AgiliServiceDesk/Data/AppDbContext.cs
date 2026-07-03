using AgiliServiceDesk.Models;
using Microsoft.EntityFrameworkCore;

namespace AgiliServiceDesk.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<Chamado> Chamados { get; set; }
    }
}

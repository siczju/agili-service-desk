using Microsoft.EntityFrameworkCore;
using AgiliServiceDesk.Models;

namespace AgiliServiceDesk.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Categoria> Categorias { get; set; }

    public DbSet<Chamado> Chamados { get; set; }
}
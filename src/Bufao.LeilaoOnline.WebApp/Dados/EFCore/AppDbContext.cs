using Bufao.LeilaoOnline.WebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace Bufao.LeilaoOnline.WebApp.Dados.EFCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public AppDbContext() { }

    public DbSet<Leilao> Leiloes { get; set; }
    public DbSet<Categoria> Categorias { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ObterStringConexao());
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Leilao>()
               .HasOne(l => l.Categoria)
               .WithMany(c => c.Leiloes)
               .HasForeignKey(l => l.IdCategoria);

        base.OnModelCreating(modelBuilder);
    }

    private static string ObterStringConexao()
    {
        return "Server=(localdb)\\MSSQLLocalDB;Database=BufaoLeiloesDB;Trusted_Connection=true";
    }

}

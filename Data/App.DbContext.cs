using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

public class AppDbContext : DbContext
{
    public DbSet<Produto> Produtos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=banco.db");
    }
}
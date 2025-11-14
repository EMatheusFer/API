using Microsoft.EntityFrameworkCore;
using ProjetoAPIBrito.Api.Domain.Models;
using ProjetoAPIBrito.Api.Data.Mappings;

namespace ProjetoAPIBrito.Api.Infrastructure.Data
{
    // public class AppDbContext : DbContext
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoMap());
        }
    }
}
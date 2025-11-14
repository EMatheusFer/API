using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoAPIBrito.Api.Domain.Models;

namespace ProjetoAPIBrito.Api.Data.Mappings
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            // Nome da tabela
            builder.ToTable("Produtos");

            // Chave primária
            builder.HasKey(p => p.Id);

            // Id (Identity/Serial)
            builder.Property(p => p.Id)
                   .ValueGeneratedOnAdd();

            // Nome
            builder.Property(p => p.Nome)
                   .IsRequired()
                   .HasMaxLength(100);

            // Descricao
            builder.Property(p => p.Descricao)
                   .IsRequired()
                   .HasMaxLength(300);

            // Preco
            builder.Property(p => p.Preco)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)");

            // Ativo
            builder.Property(p => p.Ativo)
                   .IsRequired();

            // DataInativacao
            builder.Property(p => p.DataInativacao);
                   
        }
    }
}
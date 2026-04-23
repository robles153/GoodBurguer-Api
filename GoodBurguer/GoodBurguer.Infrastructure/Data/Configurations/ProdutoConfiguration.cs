using GoodBurguer.GoodBurguer.Domain.Entities;
using GoodBurguer.GoodBurguer.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoodBurguer.GoodBurguer.Infrastructure.Data.Configurations
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produtos");
           
            builder.HasKey(p => p.Id);
           
            builder.Property(p => p.Nome)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(p => p.Preco)
                   .IsRequired()
                   .HasColumnType("decimal(10,2)");

            builder.Property(p => p.Tipo)
                   .IsRequired();

            builder.Property(p => p.Ativo)
                   .IsRequired();

            builder.HasData(
                new
                {
                    Id = Guid.Parse("a1f3c9b2-7d4e-4a1b-9c2e-1f7d8a2b3c4d"),
                    Nome = "X Burger",
                    Preco = 5.00m,
                    Tipo = TipoItem.Sanduiche,
                    Ativo = true
                },
                new
                {
                    Id = Guid.Parse("b2e4d6a8-9c1f-4d3a-b7e2-2c8f9a1b5d6e"),
                    Nome = "X Egg",
                    Preco = 4.50m,
                    Tipo = TipoItem.Sanduiche,
                    Ativo = true
                },
                new
                {
                    Id = Guid.Parse("c3d5e7f9-1a2b-4c3d-8e9f-3b7c6d5e4f2a"),
                    Nome = "X Bacon",
                    Preco = 7.00m,
                    Tipo = TipoItem.Sanduiche,
                    Ativo = true
                },
                new
                {
                    Id = Guid.Parse("d4e6f8a1-2b3c-4d5e-9f0a-4c8d7e6f5a3b"),
                    Nome = "Batata frita",
                    Preco = 2.00m,
                    Tipo = TipoItem.Acompanhamento,
                    Ativo = true
                },
                new
                {
                    Id = Guid.Parse("e5f7a9b2-3c4d-5e6f-0a1b-5d9e8f7a6b4c"),
                    Nome = "Refrigerante",
                    Preco = 2.50m,
                    Tipo = TipoItem.Bebida,
                    Ativo = true
                }
            );
        }
    }
}

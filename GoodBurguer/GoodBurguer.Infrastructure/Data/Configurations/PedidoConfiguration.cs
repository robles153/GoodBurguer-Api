using GoodBurguer.GoodBurguer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoodBurguer.GoodBurguer.Infrastructure.Data.Configurations
{
    public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("Pedidos");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Subtotal)
                   .IsRequired()
                   .HasColumnType("decimal(10,2)");

            builder.Property(p => p.Desconto)
                   .IsRequired()
                   .HasColumnType("decimal(10,2)");

            builder.Property(p => p.Total)
                   .IsRequired()
                   .HasColumnType("decimal(10,2)");

            builder.HasMany(p => p.Itens)
                   .WithOne()
                   .HasForeignKey(i => i.PedidoId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

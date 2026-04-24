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

            builder.OwnsOne(p => p.Subtotal, m =>
            {
                m.Property(p => p.Valor)
                 .HasColumnName("Subtotal")
                 .HasColumnType("decimal(10,2)");
            });

            builder.OwnsOne(p => p.Desconto, m =>
            {
                m.Property(p => p.Valor)
                 .HasColumnName("Desconto")
                 .HasColumnType("decimal(10,2)");
            });

            builder.OwnsOne(p => p.Total, m =>
            {
                m.Property(p => p.Valor)
                 .HasColumnName("Total")
                 .HasColumnType("decimal(10,2)");
            });

            builder.Navigation(p => p.Subtotal).IsRequired();
            builder.Navigation(p => p.Desconto).IsRequired();
            builder.Navigation(p => p.Total).IsRequired();

            builder.HasMany(p => p.Itens)
                   .WithOne()
                   .HasForeignKey(i => i.PedidoId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

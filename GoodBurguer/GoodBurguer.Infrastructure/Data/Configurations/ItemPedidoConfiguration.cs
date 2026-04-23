using GoodBurguer.GoodBurguer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoodBurguer.GoodBurguer.Infrastructure.Data.Configurations
{
    public class ItemPedidoConfiguration : IEntityTypeConfiguration<ItemPedido>
    {
        public void Configure(EntityTypeBuilder<ItemPedido> builder)
        {
            builder.ToTable("ItensPedido");
           
            builder.HasKey(i => i.Id);
           
            builder.Property(i => i.Nome)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(i => i.Preco)
                   .IsRequired()
                   .HasColumnType("decimal(10,2)");

            builder.Property(i => i.Tipo)
                   .IsRequired();
           
            builder.HasOne<Pedido>()
                   .WithMany(p => p.Itens)
                   .HasForeignKey(i => i.PedidoId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

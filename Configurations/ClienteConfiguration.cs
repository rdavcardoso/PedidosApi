namespace PedidosApi.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        // Nome da tabela
        builder.ToTable("Cliente");

        // Chave Primária
        builder.HasKey(c => c.Id);

        // Propriedade Obrigatória
        builder.Property(c => c.Nome)
            .IsRequired()
            .HasMaxLength(100);

        // Relacionamento: Cliente -> Pedido (1:N)
        builder.HasMany(c => c.Pedidos)
            .WithOne(p => p.Cliente)
            .HasForeignKey(p => p.ClienteId)
            .OnDelete(DeleteBehavior.Restrict);
    }
    
}
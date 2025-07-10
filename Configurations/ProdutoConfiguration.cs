using PedidosApi.Models;

namespace PedidosApi.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PedidosApi.Models;

public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
{
    public void Configure(EntityTypeBuilder<Produto> builder)
    {
        // Nome da tabela
        builder.ToTable("Produtos");
        
        // Chave Primária
        builder.HasKey(p => p.Id);
        
        // Propriedades Obrigatória
        builder.Property(p => p.Nome)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(p => p.Preco)
            .HasColumnType("decimal(18,2)")
            .IsRequired();
        
        // Relacionamento: Produto -> Pedido (1:N)
        builder.HasMany(p => p.Pedidos)
            .WithOne(pp => pp.Produto)
            .HasForeignKey(pp => pp.ProdutoId);
    }
    
}
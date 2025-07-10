namespace PedidosApi.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

public class PedidoProdutoConfiguration : IEntityTypeConfiguration<PedidoProduto>
{
    public void Configure(EntityTypeBuilder<PedidoProduto> builder)
    {
        // Nome da tabela
        builder.ToTable("PedidoProdutos");
        
        // Chave composta (PK)
        builder.HasKey(pp => new { pp.PedidoId, pp.ProdutoId });
        
        // Relacionamento N:1 com Pedido
        builder.HasOne(pp => pp.Pedido)
            .WithMany(p => p.Itens)
            .HasForeignKey(pp => pp.PedidoId)
            .OnDelete(DeleteBehavior.Restrict);
        
        // Relacionamento N:1 com Produto
        builder.HasOne(pp => pp.Produto)
            .WithMany(p => p.Pedidos)
            .HasForeignKey(pp => pp.ProdutoId)
            .OnDelete(DeleteBehavior.Restrict);
        
        // Quantidade obrigatória
        builder.Property(pp => pp.Quantidade)
            .IsRequired();
    }
    
}
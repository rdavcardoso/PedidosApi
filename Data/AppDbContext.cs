using Microsoft.EntityFrameworkCore;
using PedidosApi.Models;

namespace PedidosApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }
    
    public DbSet<Produto> Produtos => Set<Produto>();
    public DbSet<Cliente> Clientes => Set<Cliente>();
    public DbSet<Pedido> Pedidos => Set<Pedido>();
    public DbSet<PedidoProduto> PedidoProdutos => Set<PedidoProduto>();
    
}
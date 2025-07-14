using PedidosApi.Data;
using PedidosApi.Models;
using PedidosApi.Models.DTOs;

namespace PedidosApi.EndPoints;

using Microsoft.EntityFrameworkCore;
using PedidosApi.Models;
using PedidosApi.Models.DTOs;
using PedidosApi.Data;

public static class PedidoEndpoints
{
    public static void MapPedidoEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/pedidos", async (AppDbContext db) =>
        {
            var pedidos = await db.Pedidos
                .Include(p => p.Cliente)
                .Include(p => p.Itens)
                .ThenInclude(pp => pp.Produto)
                .ToListAsync();
                
            return Results.Ok(pedidos);
        })
        .WithTags("Pedidos")
        .WithName("ListarPedidos");
        
        app.MapGet("/pedidos/{id}", async (int id, AppDbContext db) =>
        {
            var pedido = await db.Pedidos
                .Include(p => p.Cliente)
                .Include(p => p.Itens)
                .ThenInclude(pp => pp.Produto)
                .FirstOrDefaultAsync(p => p.Id == id);
            
            return pedido != null ? Results.Ok(pedido) : Results.NotFound();
        })
        .WithTags("Pedidos")
        .WithName("ObterPedido");
        
        app.MapPost("/pedidos", async (PedidoCreateDto dto, AppDbContext db) =>
        {
            var cliente = await db.Clientes.FindAsync(dto.ClienteId);
            if (cliente == null)
                return Results.BadRequest("Cliente não encontrado.");

            var pedido = new Pedido
            {
                ClienteId = dto.ClienteId,
                Data = DateTime.UtcNow,
                Itens = dto.ProdutosIds.Select(produtoId => new PedidoProduto
                {
                    ProdutoId = produtoId
                }).ToList()
            };

            db.Pedidos.Add(pedido);
            await db.SaveChangesAsync();

            return Results.Created($"/pedidos/{pedido.Id}", pedido);
        })
        .WithTags("Pedidos")
        .WithName("CriarPedido");
        
        app.MapPut("/pedidos/{id}", async (int id, PedidoUpdateDto dto, AppDbContext db) =>
        {
            var pedido = await db.Pedidos
                .Include(p => p.Itens)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (pedido == null)
                return Results.NotFound();
            
            //Atualizando Produtos
            pedido.Itens.Clear();
            pedido.Itens = dto.ProdutosIds.Select(produtoId => new PedidoProduto
            {
                ProdutoId = produtoId
            }).ToList();

            await db.SaveChangesAsync();

            return Results.NoContent();
        })
        .WithTags("Pedidos")
        .WithName("AtualizarPedido");
        
        app.MapDelete("/pedidos/{id}", async (int id, AppDbContext db) =>
        {
            var pedido = await db.Pedidos.FindAsync(id);
            if (pedido == null)
                return Results.NotFound();

            db.Pedidos.Remove(pedido);
            await db.SaveChangesAsync();

            return Results.NoContent();

        })
        .WithTags("Pedidos")
        .WithName("RemoverPedido");
        
    }
    
}
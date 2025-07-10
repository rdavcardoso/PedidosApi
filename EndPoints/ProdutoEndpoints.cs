using PedidosApi.Data;
using PedidosApi.Models;
using PedidosApi.Models.DTOs;

namespace PedidosApi.EndPoints;

using Microsoft.EntityFrameworkCore;
using PedidosApi.Models;
using PedidosApi.Models.DTOs;
using PedidosApi.Data;


public static class ProdutoEndpoints
{
    public static void MapProdutoEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/produtos", async (AppDbContext db) =>
        {
            var produtos = await db.Produtos.ToListAsync();
            
            return Results.Ok(produtos);
        } );
        
        app.MapGet("/produtos/{id}", async (int id, AppDbContext db) =>
        {
            var produto = await db.Produtos.FindAsync(id);

            return produto != null ? Results.Ok(produto) : Results.NotFound();
        });
        
        app.MapPost("/produtos", async (ProdutoCreateDto dto, AppDbContext db) =>
        {
            var produto = new Produto
            {
                Nome = dto.Nome,
                Preco = dto.Preco,
                Quantidade = dto.Quantidade
            };

            db.Produtos.Add(produto);
            await db.SaveChangesAsync();

            return Results.Created($"/produtos/{produto.Id}", produto);
        });
        
        app.MapPut("/produtos/{id}", async (int id, ProdutoCreateDto dto, AppDbContext db) =>
        {
            var produto = await db.Produtos.FindAsync(id);
            if (produto == null)
                return Results.NotFound();

            produto.Nome = dto.Nome;
            produto.Preco = dto.Preco;
            produto.Quantidade = dto.Quantidade;

            await db.SaveChangesAsync();

            return Results.NoContent();
        });
        
        app.MapDelete("/produtos/{id}", async (int id, AppDbContext db) =>
        {
            var produto = await db.Produtos.FindAsync(id);
            if (produto == null)
                return Results.NotFound();

            db.Produtos.Remove(produto);
            db.SaveChangesAsync();

            return Results.NoContent();
        });
    }
    
}
namespace PedidosApi.Models.DTOs;

public class ProdutoDto
{
    public int Id { get; set; }
    public  string Nome { get; set; } = string.Empty;
    public decimal Preco { get; set; }
}
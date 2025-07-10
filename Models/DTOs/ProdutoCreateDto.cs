namespace PedidosApi.Models.DTOs;

public class ProdutoCreateDto
{
    public  string Nome { get; set; } = string.Empty;
    public decimal Preco { get; set; }
    public int Quantidade { get; set; }
}
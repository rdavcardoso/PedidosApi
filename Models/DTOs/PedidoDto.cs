namespace PedidosApi.Models.DTOs;

public class PedidoDto
{
    public int Id { get; set; }
    public DateTime Data { get; set; }
    public List<int> ProdutosIds { get; set; } = new();
    public int ClienteId { get; set; }
}
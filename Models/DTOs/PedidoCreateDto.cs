namespace PedidosApi.Models.DTOs;

public class PedidoCreateDto
{
    public int ClienteId { get; set; }
    public DateTime Data { get; set; }
    public List<int> ProdutosIds { get; set; }
}
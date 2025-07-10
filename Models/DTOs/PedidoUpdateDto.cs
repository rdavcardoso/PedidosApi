namespace PedidosApi.Models.DTOs;

public class PedidoUpdateDto
{
    public DateTime Data { get; set; }
    public List<int> ProdutosIds { get; set; }
}
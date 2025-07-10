namespace PedidosApi.Models.DTOs;

public class ClienteDto
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public List<PedidoResumoDto> Pedidos { get; set; } = new();
}
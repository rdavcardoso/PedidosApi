namespace PedidosApi.Models;

public class Produto
{
    public int Id { get; set; }
    public  string Nome { get; set; } = string.Empty;
    public decimal Preco { get; set; }
    public int Quantidade { get; set; }
    public List<PedidoProduto> Pedidos { get; set; } = new List<PedidoProduto>();
}
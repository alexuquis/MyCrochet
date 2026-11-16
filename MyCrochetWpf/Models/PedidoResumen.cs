namespace MyCrochetWpf.Models
{
    /// <summary>Proyección del grid de pedidos (Encargos + TipoPedidos + Estados).</summary>
    public class PedidoResumen
    {
        public int Id { get; set; }
        public string Cliente { get; set; } = string.Empty;
        public string TipoPedido { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
        public DateTime FechaEntrega { get; set; }
    }
}

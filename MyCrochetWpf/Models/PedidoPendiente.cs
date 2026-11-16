namespace MyCrochetWpf.Models
{
    /// <summary>Proyección de pedidos pendientes para FmInicio.</summary>
    public class PedidoPendiente
    {
        public string Cliente { get; set; } = string.Empty;
        public string TipoPedido { get; set; } = string.Empty;
        public DateTime Fecha { get; set; }
    }
}

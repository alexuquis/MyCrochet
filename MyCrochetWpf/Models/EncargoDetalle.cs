namespace MyCrochetWpf.Models
{
    /// <summary>Proyección del detalle de un pedido (FmVerPedido).</summary>
    public class EncargoDetalle
    {
        public string Cliente { get; set; } = string.Empty;
        public string? Contacto { get; set; }
        public string TipoPedido { get; set; } = string.Empty;
        public string? DescripcionPersonalizada { get; set; }
        public decimal PrecioFinal { get; set; }
        public DateTime FechaEntrega { get; set; }
        public decimal? Subtotal { get; set; }
        public decimal? Anticipo { get; set; }
        public decimal? CostoEnvio { get; set; }
        public string? NombreEnvio { get; set; }
    }
}

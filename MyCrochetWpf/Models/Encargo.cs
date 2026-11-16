namespace MyCrochetWpf.Models
{
    /// <summary>Fila de la tabla Encargos.</summary>
    public class Encargo
    {
        public int Id { get; set; }
        public string Cliente { get; set; } = string.Empty;
        public int TipoPedidoId { get; set; }
        public string? DescripcionPersonalizada { get; set; }
        public decimal PrecioFinal { get; set; }
        public DateTime FechaEntrega { get; set; }
        public int EstadoId { get; set; }
        public int? OpcionEnvioId { get; set; }
        public decimal? CostoEnvio { get; set; }
        public decimal? Subtotal { get; set; }
        public decimal? Anticipo { get; set; }
        public string? Contacto { get; set; }
    }
}

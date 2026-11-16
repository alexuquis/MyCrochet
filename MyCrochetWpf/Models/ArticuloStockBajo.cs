namespace MyCrochetWpf.Models
{
    /// <summary>Proyección de las alertas de stock de FmInicio (Inventario &lt;= 2).</summary>
    public class ArticuloStockBajo
    {
        public string? Marca { get; set; }
        public string Tamaño { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public int? Inventario { get; set; }
    }
}

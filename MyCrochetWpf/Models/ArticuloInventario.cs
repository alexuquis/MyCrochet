namespace MyCrochetWpf.Models
{
    /// <summary>Proyección del grid de inventario (Articulos + nombre de Categoria).</summary>
    public class ArticuloInventario
    {
        public int Id { get; set; }
        public string Categoria { get; set; } = string.Empty;
        public string? Marca { get; set; }
        public string Tamaño { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public int? Inventario { get; set; }
        public decimal Precio { get; set; }
    }
}

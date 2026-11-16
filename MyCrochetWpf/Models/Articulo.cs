namespace MyCrochetWpf.Models
{
    /// <summary>Fila de la tabla Articulos.</summary>
    public class Articulo
    {
        public int Id { get; set; }
        public int CategoriaId { get; set; }
        public int? Inventario { get; set; }
        public string Tamaño { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public byte[]? Modelo { get; set; }
        public string? Marca { get; set; }
    }
}

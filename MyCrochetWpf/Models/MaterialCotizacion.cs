namespace MyCrochetWpf.Models
{
    /// <summary>Proyección del combo de materiales de FmCotizador.</summary>
    public class MaterialCotizacion
    {
        public int Id { get; set; }
        public string NombreMaterial { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public string Categoria { get; set; } = string.Empty;
    }
}

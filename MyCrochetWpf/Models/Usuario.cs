namespace MyCrochetWpf.Models
{
    /// <summary>Fila de la tabla Usuarios.</summary>
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public int GeneroId { get; set; }
        public int RolesId { get; set; }
        public string Contraseña { get; set; } = string.Empty;
    }
}

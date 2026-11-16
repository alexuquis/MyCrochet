namespace MyCrochetWpf.Models
{
    /// <summary>Resultado del login: datos mínimos que llenan los valores de sesión.</summary>
    public class UsuarioSesion
    {
        public string Nombre { get; set; } = string.Empty;
        public int RolId { get; set; }
        public string Genero { get; set; } = string.Empty;
    }
}

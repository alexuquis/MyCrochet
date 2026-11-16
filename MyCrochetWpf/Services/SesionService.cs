using CommunityToolkit.Mvvm.ComponentModel;
using MyCrochetWpf.Models;

namespace MyCrochetWpf.Services
{
    /// <summary>
    /// Reemplazo mínimo de los valores estáticos de ConexGlobal (Fase C).
    /// La Fase D1 completará lo que falte; por ahora guarda nombre, rol y género.
    /// </summary>
    public sealed partial class SesionService : ObservableObject
    {
        public static SesionService Actual { get; } = new();

        private SesionService()
        {
        }

        [ObservableProperty]
        private string nombre = string.Empty;

        [ObservableProperty]
        private int rolId;

        [ObservableProperty]
        private string genero = string.Empty;

        [ObservableProperty]
        private bool autenticado;

        public void Iniciar(UsuarioSesion usuario)
        {
            Nombre = usuario.Nombre;
            RolId = usuario.RolId;
            Genero = usuario.Genero;
            Autenticado = true;
        }

        public void Cerrar()
        {
            Nombre = string.Empty;
            RolId = 0;
            Genero = string.Empty;
            Autenticado = false;
        }
    }
}

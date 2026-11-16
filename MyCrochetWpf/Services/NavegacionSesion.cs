using System.Linq;
using System.Windows;
using MyCrochetWpf.Views;

namespace MyCrochetWpf.Services
{
    /// <summary>
    /// Reemplazo del Application.Restart() del WinForms para "Cerrar Sesión".
    /// Las pantallas de la migración se reutilizan con Hide/Show (Inicio ↔ Pedidos),
    /// así que al volver al Login hay que cerrar también las que quedaron ocultas;
    /// de lo contrario sobreviven a la sesión y se duplican al volver a entrar.
    /// </summary>
    public static class NavegacionSesion
    {
        /// <summary>
        /// Limpia la sesión, abre un Login nuevo y cierra todas las demás ventanas
        /// (visibles u ocultas). El Login se muestra antes de cerrar para no apagar
        /// la aplicación con ShutdownMode.OnLastWindowClose.
        /// </summary>
        public static void VolverAlLogin()
        {
            SesionService.Actual.Cerrar();

            var login = new LoginWindow();
            login.Show();

            foreach (Window ventana in Application.Current.Windows.OfType<Window>().ToList())
            {
                if (ReferenceEquals(ventana, login)) continue;
                ventana.Close();
            }
        }
    }
}

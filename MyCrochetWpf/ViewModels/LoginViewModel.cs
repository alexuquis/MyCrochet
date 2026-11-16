using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyCrochetWpf.Data;
using MyCrochetWpf.Models;
using MyCrochetWpf.Services;

namespace MyCrochetWpf.ViewModels
{
    /// <summary>
    /// Login (Form1.cs → clase Login): autentica contra Usuarios y llena la sesión.
    /// La navegación a FmInicio se conecta en el paso C2.
    /// </summary>
    public partial class LoginViewModel : ObservableObject
    {
        private readonly RepositorioUsuarios repositorio;

        public LoginViewModel(RepositorioUsuarios? repositorio = null)
        {
            this.repositorio = repositorio ?? new RepositorioUsuarios();
        }

        /// <summary>Se dispara con los datos de sesión cuando la credencial es correcta.</summary>
        public event Action<UsuarioSesion>? LoginExitoso;

        /// <summary>La vista limpia el PasswordBox (no es bindable en WPF).</summary>
        public event Action? SolicitaLimpiarPassword;

        [ObservableProperty]
        private string usuario = string.Empty;

        [ObservableProperty]
        private string contrasena = string.Empty;

        [ObservableProperty]
        private string mensajeError = string.Empty;

        [ObservableProperty]
        private bool hayError;

        [RelayCommand]
        private void Entrar()
        {
            if (string.IsNullOrWhiteSpace(Usuario) || string.IsNullOrEmpty(Contrasena))
            {
                MostrarError("Ingrese su usuario y contraseña.");
                return;
            }

            UsuarioSesion? sesion;
            try
            {
                sesion = repositorio.Autenticar(Usuario.Trim(), Contrasena);
            }
            catch
            {
                MostrarError("No se pudo iniciar sesión. Intente nuevamente.");
                return;
            }

            if (sesion is null)
            {
                // Igual que el WinForms: mensaje en pantalla y limpiar campos.
                MostrarError("Usuario o contraseña incorrectos");
                Usuario = string.Empty;
                Contrasena = string.Empty;
                SolicitaLimpiarPassword?.Invoke();
                return;
            }

            HayError = false;
            MensajeError = string.Empty;
            SesionService.Actual.Iniciar(sesion);
            LoginExitoso?.Invoke(sesion);
        }

        private void MostrarError(string mensaje)
        {
            MensajeError = mensaje;
            HayError = true;
        }
    }
}

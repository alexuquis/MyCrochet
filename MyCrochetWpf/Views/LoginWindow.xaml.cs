using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using MyCrochetWpf.Models;
using MyCrochetWpf.ViewModels;

namespace MyCrochetWpf.Views
{
    /// <summary>
    /// Login migrado de Form1.cs (clase Login). Ventana sin bordes, arrastrable
    /// desde la barra rosa superior.
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly LoginViewModel viewModel;

        public LoginWindow()
        {
            InitializeComponent();

            viewModel = new LoginViewModel();
            viewModel.LoginExitoso += LoginExitoso;
            viewModel.SolicitaLimpiarPassword += LimpiarPassword;
            DataContext = viewModel;

            Loaded += (_, _) => TxtUsuario.Focus();
        }

        private void LoginExitoso(UsuarioSesion sesion)
        {
            // Mismo flujo que Form1.cs: ocultar/cerrar el Login y abrir FmInicio.
            // En WPF se abre Inicio antes de cerrar el Login para que la aplicación
            // no se apague con ShutdownMode.OnLastWindowClose; a diferencia del
            // WinForms (this.Hide()), el Login se cierra y C2c creará uno nuevo.
            new InicioWindow().Show();
            Close();
        }

        private void LimpiarPassword()
        {
            TxtPassword.Clear();
            TxtPassword.Focus();
        }

        private void TxtPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            viewModel.Contrasena = TxtPassword.Password;
        }

        private void BarraTitulo_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed && !EstaDentroDeBoton(e.OriginalSource as DependencyObject))
            {
                DragMove();
            }
        }

        private void Minimizar_Click(object sender, RoutedEventArgs e)
        {
            // Mismo efecto que el WinForms: desvanecer y minimizar.
            var animacion = new DoubleAnimation(1, 0, TimeSpan.FromMilliseconds(150));
            animacion.Completed += (_, _) =>
            {
                WindowState = WindowState.Minimized;
                BeginAnimation(OpacityProperty, null);
                Opacity = 1;
            };
            BeginAnimation(OpacityProperty, animacion);
        }

        private void Cerrar_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private static bool EstaDentroDeBoton(DependencyObject? origen)
        {
            while (origen is not null)
            {
                if (origen is Button) return true;
                origen = VisualTreeHelper.GetParent(origen);
            }
            return false;
        }
    }
}

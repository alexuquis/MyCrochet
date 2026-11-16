using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using MyCrochetWpf.ViewModels;

namespace MyCrochetWpf.Views
{
    /// <summary>
    /// Inicio migrado de FmInicio.cs. Ventana sin bordes que replica el layout
    /// del WinForms (ClientSize 1571x1167) dentro de un Viewbox proporcional.
    /// Los datos vienen de InicioViewModel (C2a).
    /// </summary>
    public partial class InicioWindow : Window
    {
        private readonly InicioViewModel viewModel;

        public InicioWindow()
        {
            InitializeComponent();

            viewModel = new InicioViewModel();
            DataContext = viewModel;

            viewModel.SolicitaIrAPedidos += IrAPedidosSolicitado;

            // FmInicio_VisibleChanged: cada vez que la ventana se muestra
            // (primer render o al volver desde otra pantalla) se recargan datos.
            IsVisibleChanged += Inicio_IsVisibleChanged;
            Loaded += AjustarAlAreaDeTrabajo;
        }

        /// <summary>
        /// FmInicio.cs → btnPedidos_Click / btnNuevoPed_Click: ocultar Inicio y mostrar
        /// Pedidos, reutilizando la instancia existente (equivalente a
        /// Application.OpenForms["FmPedidos"] del WinForms). Pedidos se refresca solo
        /// al volverse visible (IsVisibleChanged → Filtrar).
        /// </summary>
        private void IrAPedidosSolicitado()
        {
            PedidosWindow pedidos = Application.Current.Windows.OfType<PedidosWindow>().FirstOrDefault()
                ?? new PedidosWindow();

            // Mostrar antes de ocultar evita un instante sin ventanas visibles.
            pedidos.Show();
            pedidos.Activate();
            Hide();
        }

        private void Inicio_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue is true)
            {
                viewModel.Cargar();
            }
        }

        /// <summary>
        /// En pantallas menores que el diseño (1571x1167) la ventana se limita
        /// al área de trabajo; el Viewbox escala el contenido sin recortarlo.
        /// </summary>
        private void AjustarAlAreaDeTrabajo(object? sender, RoutedEventArgs e)
        {
            Rect area = SystemParameters.WorkArea;
            Width = Math.Min(Width, area.Width);
            Height = Math.Min(Height, area.Height);
            Left = area.Left + ((area.Width - Width) / 2);
            Top = area.Top + ((area.Height - Height) / 2);
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

        /// <summary>
        /// FmInicio.cs → button5_Click: confirmación Yes/No y, si acepta,
        /// Application.Restart() (aquí: sesión limpia + Login nuevo).
        /// </summary>
        private void CerrarSesion_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult respuesta = MessageBox.Show(this,
                "Deseas cerrar sesión?",
                "Cerrar Sesión",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            ProcesarCerrarSesion(respuesta == MessageBoxResult.Yes);
        }

        /// <summary>
        /// Reemplazo del Application.Restart() del WinForms: limpia SesionService,
        /// abre un Login nuevo y cierra esta ventana. NavegacionSesion cierra también
        /// las pantallas ocultas (Pedidos) para no dejarlas huérfanas. La confirmación
        /// llega como parámetro para poder ejercer ambas ramas desde el smoke test.
        /// </summary>
        internal void ProcesarCerrarSesion(bool confirmado)
        {
            if (!confirmado) return;

            Services.NavegacionSesion.VolverAlLogin();
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

using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using MyCrochetWpf.ViewModels;

namespace MyCrochetWpf.Views
{
    /// <summary>
    /// FmNuevoPedido migrado a WPF. Ventana sin bordes que replica el layout del
    /// WinForms (ClientSize 597x471); los datos, comandos y validaciones vienen de
    /// NuevoPedidoViewModel (C4-1). La vista solo muestra mensajes y cierra.
    /// </summary>
    public partial class NuevoPedidoWindow : Window
    {
        private readonly NuevoPedidoViewModel viewModel;

        public NuevoPedidoWindow()
        {
            InitializeComponent();

            viewModel = new NuevoPedidoViewModel();
            DataContext = viewModel;

            // MessageBox del WinForms: advertencia "Faltan datos", confirmación
            // "Registro Exitoso" y btnCerrar_Click.
            viewModel.SolicitaAdvertencia += MostrarAdvertencia;
            viewModel.PedidoGuardado += MostrarRegistroExitoso;
            viewModel.SolicitaCerrar += Close;

            // FmNuevoPedido_Load: catálogos y combos sin selección inicial.
            viewModel.Cargar();
        }

        /// <summary>MessageBox.Show(..., "Faltan datos", Warning).</summary>
        private void MostrarAdvertencia(string mensaje)
        {
            MessageBox.Show(this,
                mensaje,
                "Faltan datos",
                MessageBoxButton.OK,
                MessageBoxImage.Warning);
        }

        /// <summary>MessageBox.Show(..., "¡El pedido ha sido agregado!", Information).</summary>
        private void MostrarRegistroExitoso()
        {
            MessageBox.Show(this,
                "¡El pedido ha sido agregado!",
                "Registro Exitoso",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
        }

        /// <summary>panel1_MouseDown → MoverVentana del WinForms.</summary>
        private void BarraTitulo_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed && !EstaDentroDeBoton(e.OriginalSource as DependencyObject))
            {
                DragMove();
            }
        }

        /// <summary>btnCerrar_Click.</summary>
        private void Cerrar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private static bool EstaDentroDeBoton(DependencyObject? origen)
        {
            while (origen is not null)
            {
                if (origen is System.Windows.Controls.Button) return true;
                origen = VisualTreeHelper.GetParent(origen);
            }
            return false;
        }
    }
}

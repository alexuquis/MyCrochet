using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using MyCrochetWpf.ViewModels;

namespace MyCrochetWpf.Views
{
    /// <summary>
    /// FmVerPedido migrado a WPF. Ventana sin bordes que replica el layout del
    /// WinForms (ClientSize 410x510) en modo solo lectura; los datos vienen de
    /// VerPedidoViewModel (C5-1). La vista solo muestra el error y cierra.
    /// </summary>
    public partial class VerPedidoWindow : Window
    {
        private readonly VerPedidoViewModel viewModel;

        public VerPedidoWindow(int idPedido)
        {
            InitializeComponent();

            viewModel = new VerPedidoViewModel(idPedido);
            DataContext = viewModel;

            // FmVerPedido_Load: los eventos se suscriben antes de cargar para no
            // perder el aviso de "Error de Lectura" (decisión de C5).
            viewModel.SolicitaError += MostrarError;
            viewModel.SolicitaCerrar += Close;

            Loaded += (_, _) => viewModel.Cargar();
        }

        /// <summary>MessageBox.Show(..., "Error de Lectura", Error) del WinForms.</summary>
        private void MostrarError(string mensaje)
        {
            MessageBox.Show(this,
                mensaje,
                "Error de Lectura",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
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

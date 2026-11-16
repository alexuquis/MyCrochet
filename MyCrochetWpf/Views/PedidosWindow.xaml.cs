using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using MyCrochetWpf.Services;
using MyCrochetWpf.ViewModels;

namespace MyCrochetWpf.Views
{
    /// <summary>
    /// Pedidos migrado de FmPedidos.cs. Ventana sin bordes que replica el layout
    /// del WinForms (ClientSize 1100x700) dentro de un Viewbox proporcional.
    /// Los datos y comandos vienen de PedidosViewModel (C3-1).
    /// </summary>
    public partial class PedidosWindow : Window
    {
        private readonly PedidosViewModel viewModel;

        public PedidosWindow()
        {
            InitializeComponent();

            viewModel = new PedidosViewModel();
            DataContext = viewModel;

            viewModel.SolicitaConfirmarEliminar += ConfirmarEliminar;
            viewModel.SolicitaCerrarSesion += CerrarSesionSolicitado;
            viewModel.SolicitaIrAInicio += IrAInicioSolicitado;
            viewModel.SolicitaNuevoPedido += AbrirNuevoPedido;
            viewModel.SolicitaVerPedido += AbrirVerPedido;

            viewModel.Cargar();

            // Al volver a mostrarse se refresca el grid conservando los filtros.
            IsVisibleChanged += Pedidos_IsVisibleChanged;
            Loaded += AjustarAlAreaDeTrabajo;
        }

        private void Pedidos_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue is true)
            {
                viewModel.Filtrar();
            }
        }

        /// <summary>
        /// En pantallas menores que el diseño (1100x700) la ventana se limita al
        /// área de trabajo; el Viewbox escala el contenido sin recortarlo.
        /// </summary>
        private void AjustarAlAreaDeTrabajo(object? sender, RoutedEventArgs e)
        {
            Rect area = SystemParameters.WorkArea;
            Width = Math.Min(Width, area.Width);
            Height = Math.Min(Height, area.Height);
            Left = area.Left + ((area.Width - Width) / 2);
            Top = area.Top + ((area.Height - Height) / 2);
        }

        /// <summary>
        /// FmPedidos.cs → btnNuevoPed_Click: abre FmNuevoPedido como modal y al
        /// cerrarse recarga el grid. El WinForms llamaba a Pedidos() (sin filtros);
        /// aquí se reaplica el filtro vigente, mismo criterio que al eliminar.
        /// </summary>
        internal void AbrirNuevoPedido()
        {
            var nuevoPedido = new NuevoPedidoWindow
            {
                Owner = this
            };

            nuevoPedido.ShowDialog();
            viewModel.Filtrar();
        }

        /// <summary>
        /// FmPedidos.cs → VerPedido_Click: abre FmVerPedido como modal con el Id
        /// de la fila seleccionada. Es de solo lectura, así que el grid no se
        /// recarga al cerrar (igual que el WinForms).
        /// </summary>
        internal void AbrirVerPedido(int id)
        {
            var verPedido = new VerPedidoWindow(id)
            {
                Owner = this
            };

            verPedido.ShowDialog();
        }

        /// <summary>FmPedidos.cs → eliminarPedido_Click (confirmación Yes/No).</summary>
        private void ConfirmarEliminar(int id)
        {
            MessageBoxResult respuesta = MessageBox.Show(this,
                "Deseas eliminar este pedido?",
                "Confirmar",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);

            viewModel.ProcesarEliminarPedido(id, respuesta == MessageBoxResult.Yes);
        }

        /// <summary>FmPedidos.cs → button5_Click (Cerrar Sesión).</summary>
        private void CerrarSesionSolicitado()
        {
            MessageBoxResult respuesta = MessageBox.Show(this,
                "Deseas cerrar sesión?",
                "Cerrar Sesión",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (respuesta == MessageBoxResult.Yes)
            {
                ProcesarCerrarSesion(true);
            }
        }

        /// <summary>
        /// Mismo patrón que InicioWindow (C2c): limpiar sesión y volver al Login.
        /// NavegacionSesion cierra además la InicioWindow oculta por la navegación
        /// Inicio ↔ Pedidos (el WinForms lo resolvía con Application.Restart).
        /// La confirmación llega como parámetro para poder ejercer ambas ramas desde
        /// el smoke test sin el modal.
        /// </summary>
        internal void ProcesarCerrarSesion(bool confirmado)
        {
            if (!confirmado) return;

            NavegacionSesion.VolverAlLogin();
        }

        /// <summary>
        /// FmPedidos.cs → btnInicio_Click / btnlogo_Click: ocultar Pedidos y mostrar
        /// Inicio, reutilizando la instancia existente (equivalente a
        /// Application.OpenForms["FmInicio"] del WinForms). Inicio se refresca solo
        /// al volverse visible (IsVisibleChanged → Cargar).
        /// </summary>
        private void IrAInicioSolicitado()
        {
            InicioWindow inicio = Application.Current.Windows.OfType<InicioWindow>().FirstOrDefault()
                ?? new InicioWindow();

            // Mostrar antes de ocultar evita un instante sin ventanas visibles.
            inicio.Show();
            inicio.Activate();
            Hide();
        }

        /// <summary>
        /// WinForms selecciona la fila al hacer clic derecho (CellMouseDown); WPF no
        /// lo hace por defecto y el menú contextual actuaría sobre la fila anterior.
        /// </summary>
        private void Pedidos_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.OriginalSource is DependencyObject origen)
            {
                DataGridRow? fila = EncontrarAncestro<DataGridRow>(origen);
                if (fila is not null && sender is DataGrid grid)
                {
                    fila.IsSelected = true;
                    grid.SelectedItem = fila.Item;
                }
            }
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

        private static T? EncontrarAncestro<T>(DependencyObject origen) where T : DependencyObject
        {
            while (origen is not null)
            {
                if (origen is T encontrado) return encontrado;
                origen = VisualTreeHelper.GetParent(origen);
            }
            return null;
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

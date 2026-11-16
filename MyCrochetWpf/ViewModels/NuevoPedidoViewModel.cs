using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyCrochetWpf.Data;
using MyCrochetWpf.Models;

namespace MyCrochetWpf.ViewModels
{
    /// <summary>
    /// FmNuevoPedido: captura de un pedido nuevo. Los catálogos llegan sin la fila
    /// "Todos" (a diferencia de FmPedidos) y los combos arrancan sin selección,
    /// igual que el WinForms. La vista (C4-2) solo pregunta y muestra mensajes.
    /// </summary>
    public partial class NuevoPedidoViewModel : ObservableObject
    {
        private const string PackGif = "pack://application:,,,/MyCrochetWpf;component/Assets/Gifs/";

        private readonly RepositorioEncargos repositorioEncargos;
        private readonly RepositorioCatalogos repositorioCatalogos;

        public NuevoPedidoViewModel(
            RepositorioEncargos? repositorioEncargos = null,
            RepositorioCatalogos? repositorioCatalogos = null)
        {
            this.repositorioEncargos = repositorioEncargos ?? new RepositorioEncargos();
            this.repositorioCatalogos = repositorioCatalogos ?? new RepositorioCatalogos();

            // El DateTimePicker del WinForms arranca con la fecha actual.
            FechaEntrega = DateTime.Today;
        }

        /// <summary>La vista muestra el MessageBox de advertencia ("Faltan datos").</summary>
        public event Action<string>? SolicitaAdvertencia;

        /// <summary>La vista muestra "¡El pedido ha sido agregado!" ("Registro Exitoso").</summary>
        public event Action? PedidoGuardado;

        /// <summary>btnCerrar_Click: la vista cierra la ventana.</summary>
        public event Action? SolicitaCerrar;

        /// <summary>cmbNTipo: "SELECT Id, Nombre FROM TipoPedidos".</summary>
        public ObservableCollection<TipoPedido> Tipos { get; } = new();

        /// <summary>cmbEstado: "SELECT Id, Estado FROM Estados".</summary>
        public ObservableCollection<Estado> Estados { get; } = new();

        /// <summary>cmbNEnvio: "SELECT Id, Nombre FROM OpcionesEnvio".</summary>
        public ObservableCollection<OpcionEnvio> OpcionesEnvio { get; } = new();

        /// <summary>cmbNTipo.SelectedValue (null = sin selección).</summary>
        [ObservableProperty]
        private TipoPedido? tipoSeleccionado;

        /// <summary>cmbEstado.SelectedValue (null = sin selección).</summary>
        [ObservableProperty]
        private Estado? estadoSeleccionado;

        /// <summary>cmbNEnvio.SelectedValue (null = sin selección).</summary>
        [ObservableProperty]
        private OpcionEnvio? envioSeleccionado;

        /// <summary>txtNNom.</summary>
        [ObservableProperty]
        private string cliente = string.Empty;

        /// <summary>txtNContacto.</summary>
        [ObservableProperty]
        private string contacto = string.Empty;

        /// <summary>txtNDesc.</summary>
        [ObservableProperty]
        private string descripcion = string.Empty;

        /// <summary>datePed (el WinForms usa formato Short: solo fecha).</summary>
        [ObservableProperty]
        private DateTime? fechaEntrega;

        /// <summary>txtSub.</summary>
        [ObservableProperty]
        private string subtotal = "0";

        /// <summary>txtEnv.</summary>
        [ObservableProperty]
        private string envio = "0";

        /// <summary>txtAnt.</summary>
        [ObservableProperty]
        private string anticipo = "0";

        /// <summary>lblNTotal: (Subtotal + Envío) - Anticipo, calculado en vivo.</summary>
        [ObservableProperty]
        private decimal total;

        /// <summary>picBox1: GIF animado según el tipo de pedido (null = oculto).</summary>
        [ObservableProperty]
        private string? gifActual;

        /// <summary>picBox1.Visible.</summary>
        [ObservableProperty]
        private bool hayGif;

        partial void OnSubtotalChanged(string value) => CalcularTotal();

        partial void OnEnvioChanged(string value) => CalcularTotal();

        partial void OnAnticipoChanged(string value) => CalcularTotal();

        partial void OnGifActualChanged(string? value) => HayGif = value is not null;

        /// <summary>FmNuevoPedido_Load: catálogos y combos sin selección inicial.</summary>
        public void Cargar()
        {
            Tipos.Clear();
            foreach (var tipo in repositorioCatalogos.ListarTiposPedido())
            {
                Tipos.Add(tipo);
            }

            Estados.Clear();
            foreach (var estado in repositorioCatalogos.ListarEstados())
            {
                Estados.Add(estado);
            }

            OpcionesEnvio.Clear();
            foreach (var opcion in repositorioCatalogos.ListarOpcionesEnvio())
            {
                OpcionesEnvio.Add(opcion);
            }

            // Equal a "cmbNTipo.SelectedIndex = -1" del Load del WinForms.
            TipoSeleccionado = null;
            EstadoSeleccionado = null;
            EnvioSeleccionado = null;
        }

        /// <summary>textBox6_TextChanged → CalcularTotal().</summary>
        private void CalcularTotal()
        {
            decimal.TryParse(Subtotal, out decimal subtotal);
            decimal.TryParse(Envio, out decimal envio);
            decimal.TryParse(Anticipo, out decimal anticipo);

            Total = (subtotal + envio) - anticipo;
        }

        /// <summary>
        /// btnNPedido_Click: valida (el original solo validaba el nombre; los combos
        /// sin selección lanzaban una excepción), inserta y limpia el formulario.
        /// </summary>
        [RelayCommand]
        private void Guardar()
        {
            if (string.IsNullOrWhiteSpace(Cliente))
            {
                SolicitaAdvertencia?.Invoke("Ingresa el nombre del cliente.");
                return;
            }

            if (TipoSeleccionado is null)
            {
                SolicitaAdvertencia?.Invoke("Selecciona el tipo de pedido.");
                return;
            }

            if (EstadoSeleccionado is null)
            {
                SolicitaAdvertencia?.Invoke("Selecciona el estado del pedido.");
                return;
            }

            if (EnvioSeleccionado is null)
            {
                SolicitaAdvertencia?.Invoke("Selecciona la opción de envío.");
                return;
            }

            if (FechaEntrega is null)
            {
                SolicitaAdvertencia?.Invoke("Selecciona la fecha de entrega.");
                return;
            }

            if (!TryMonto(Subtotal, out decimal subtotal))
            {
                SolicitaAdvertencia?.Invoke("Ingresa un subtotal válido.");
                return;
            }

            if (!TryMonto(Envio, out decimal envio))
            {
                SolicitaAdvertencia?.Invoke("Ingresa un costo de envío válido.");
                return;
            }

            if (!TryMonto(Anticipo, out decimal anticipo))
            {
                SolicitaAdvertencia?.Invoke("Ingresa un anticipo válido.");
                return;
            }

            var encargo = new Encargo
            {
                Cliente = Cliente,
                Contacto = Contacto,
                TipoPedidoId = TipoSeleccionado.Id,
                DescripcionPersonalizada = Descripcion,
                Subtotal = subtotal,
                CostoEnvio = envio,
                PrecioFinal = Total,
                Anticipo = anticipo,
                // El DateTimePicker solo maneja fecha (formato Short).
                FechaEntrega = FechaEntrega.Value.Date,
                EstadoId = EstadoSeleccionado.Id,
                OpcionEnvioId = EnvioSeleccionado.Id
            };

            try
            {
                repositorioEncargos.Insertar(encargo);
            }
            catch
            {
                // Mismo criterio que el Login: el error de BD se muestra en pantalla.
                SolicitaAdvertencia?.Invoke("No se pudo registrar el pedido. Intente nuevamente.");
                return;
            }

            // Igual que el WinForms: primero el MessageBox y después Limpiartext().
            PedidoGuardado?.Invoke();
            Limpiar();
        }

        /// <summary>
        /// Limpiartext(): la ventana sigue abierta para capturar otro pedido. Un texto
        /// vacío o inválido cuenta como 0 (el original lanzaba excepción al guardar).
        /// </summary>
        internal void Limpiar()
        {
            Cliente = string.Empty;
            Descripcion = string.Empty;
            Contacto = string.Empty;
            Subtotal = "0";
            Envio = "0";
            Anticipo = "0";

            TipoSeleccionado = null;
            EstadoSeleccionado = null;
            EnvioSeleccionado = null;

            FechaEntrega = DateTime.Today;

            GifActual = null;
        }

        private static bool TryMonto(string texto, out decimal monto)
        {
            if (string.IsNullOrWhiteSpace(texto))
            {
                monto = 0m;
                return true;
            }

            return decimal.TryParse(texto, out monto);
        }

        /// <summary>cmbNTipo_SelectedIndexChanged: GIF de la animación del tipo.</summary>
        partial void OnTipoSeleccionadoChanged(TipoPedido? value)
        {
            GifActual = value?.Nombre switch
            {
                "Amigurumi" => PackGif + "Personaje.gif",
                "Animal" => PackGif + "Animal.gif",
                "Flores" => PackGif + "Flor.gif",
                _ => null
            };
        }

        /// <summary>btnCerrar_Click.</summary>
        [RelayCommand]
        private void Cerrar() => SolicitaCerrar?.Invoke();
    }
}

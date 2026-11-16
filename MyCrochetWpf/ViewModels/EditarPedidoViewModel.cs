using System.Collections.ObjectModel;
using System.Globalization;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyCrochetWpf.Data;
using MyCrochetWpf.Models;
using MyCrochetWpf.Services;

namespace MyCrochetWpf.ViewModels
{
    /// <summary>
    /// FmEditarPedido: captura de un pedido existente. Los catálogos llegan sin la
    /// fila "Todos" y la carga usa <see cref="RepositorioEncargos.ObtenerPorId"/> (B7).
    /// Decisiones de C6: el costo de envío se toma del campo tecleado (como
    /// FmNuevoPedido; el original lo pisaba con el Id de la opción), se valida con
    /// los criterios de C4-1a y el rol Empleado solo puede cambiar descripción y
    /// fecha, igual que los controles deshabilitados del WinForms.
    /// </summary>
    public partial class EditarPedidoViewModel : ObservableObject
    {
        private readonly RepositorioEncargos repositorioEncargos;
        private readonly RepositorioCatalogos repositorioCatalogos;
        private readonly int idPedido;

        /// <summary>Evita recalcular el total mientras se vuelcan los datos cargados.</summary>
        private bool cargando;

        /// <summary>totalPed del WinForms: se guarda tal cual, no se reparsea del texto.</summary>
        private decimal totalPed;

        public EditarPedidoViewModel(
            int idPedido,
            RepositorioEncargos? repositorioEncargos = null,
            RepositorioCatalogos? repositorioCatalogos = null)
        {
            this.idPedido = idPedido;
            this.repositorioEncargos = repositorioEncargos ?? new RepositorioEncargos();
            this.repositorioCatalogos = repositorioCatalogos ?? new RepositorioCatalogos();
        }

        /// <summary>La vista muestra el MessageBox de advertencia ("Faltan datos").</summary>
        public event Action<string>? SolicitaAdvertencia;

        /// <summary>
        /// La vista muestra "Error" con el mensaje recibido: carga
        /// ("Error al cargar los datos: …") o guardado ("Ocurrió un error al guardar: …").
        /// </summary>
        public event Action<string>? SolicitaError;

        /// <summary>La vista muestra "Pedido actualizado correctamente." ("Éxito") y cierra.</summary>
        public event Action? PedidoActualizado;

        /// <summary>btnCerrar_Click: la vista cierra la ventana.</summary>
        public event Action? SolicitaCerrar;

        /// <summary>cmbTipo: TipoPedidos sin "Todos".</summary>
        public ObservableCollection<TipoPedido> Tipos { get; } = new();

        /// <summary>cmbEnvio: OpcionesEnvio sin "Todos".</summary>
        public ObservableCollection<OpcionEnvio> OpcionesEnvio { get; } = new();

        /// <summary>cmbTipo.SelectedValue (null = sin selección).</summary>
        [ObservableProperty]
        private TipoPedido? tipoSeleccionado;

        /// <summary>cmbEnvio.SelectedValue (null = sin selección).</summary>
        [ObservableProperty]
        private OpcionEnvio? envioSeleccionado;

        /// <summary>txtNom.</summary>
        [ObservableProperty]
        private string cliente = string.Empty;

        /// <summary>txtContacto.</summary>
        [ObservableProperty]
        private string contacto = string.Empty;

        /// <summary>txtDesc.</summary>
        [ObservableProperty]
        private string descripcion = string.Empty;

        /// <summary>dateTimePicker1 (solo fecha).</summary>
        [ObservableProperty]
        private DateTime? fechaEntrega;

        /// <summary>txtSub (texto editable: el original guardaba el decimal parseado).</summary>
        [ObservableProperty]
        private string subtotal = string.Empty;

        /// <summary>txtAnt.</summary>
        [ObservableProperty]
        private string anticipo = string.Empty;

        /// <summary>txtEnv (costo de envío tecleado, decisión de C6).</summary>
        [ObservableProperty]
        private string costoEnvio = string.Empty;

        /// <summary>txtTotal: "$" + totalPed.ToString("0.00") del WinForms.</summary>
        [ObservableProperty]
        private string total = "$0.00";

        /// <summary>
        /// FmEditarPedido_Load: si el rol no es 1 (Empleado) se deshabilitan cliente,
        /// contacto, tipo, envío y montos; Descripción y Fecha siguen habilitadas.
        /// </summary>
        public bool PuedeEditarPedido => SesionService.Actual.RolId == 1;

        partial void OnSubtotalChanged(string value) => CalcularTotal();

        partial void OnAnticipoChanged(string value) => CalcularTotal();

        partial void OnCostoEnvioChanged(string value) => CalcularTotal();

        /// <summary>
        /// FmEditarPedido_Load: catálogos y luego los datos del pedido. Se invoca
        /// desde la vista después de suscribir los eventos (mismo criterio de C5).
        /// </summary>
        public void Cargar()
        {
            try
            {
                Tipos.Clear();
                foreach (var tipo in repositorioCatalogos.ListarTiposPedido())
                {
                    Tipos.Add(tipo);
                }

                OpcionesEnvio.Clear();
                foreach (var opcion in repositorioCatalogos.ListarOpcionesEnvio())
                {
                    OpcionesEnvio.Add(opcion);
                }

                Encargo? pedido = repositorioEncargos.ObtenerPorId(idPedido);
                if (pedido is null)
                {
                    // El WinForms dejaba el formulario vacío; se avisa y se cierra
                    // con el mismo criterio acordado en C5.
                    SolicitaError?.Invoke("Error al cargar los datos.");
                    SolicitaCerrar?.Invoke();
                    return;
                }

                // Sin recalcular durante la carga: el total inicial es PrecioFinal,
                // igual que la última línea del Load del WinForms.
                cargando = true;

                Cliente = pedido.Cliente;
                Contacto = pedido.Contacto ?? string.Empty;
                Descripcion = pedido.DescripcionPersonalizada ?? string.Empty;
                FechaEntrega = pedido.FechaEntrega;

                Subtotal = FormatearMonto(pedido.Subtotal);
                Anticipo = FormatearMonto(pedido.Anticipo);
                CostoEnvio = FormatearMonto(pedido.CostoEnvio);

                TipoSeleccionado = Tipos.FirstOrDefault(t => t.Id == pedido.TipoPedidoId);
                EnvioSeleccionado = pedido.OpcionEnvioId is int envioId
                    ? OpcionesEnvio.FirstOrDefault(o => o.Id == envioId)
                    : null;

                totalPed = pedido.PrecioFinal;
                Total = FormatearTotal(totalPed);

                cargando = false;
            }
            catch (Exception ex)
            {
                cargando = false;
                // Mismo texto del WinForms; la ventana se cierra tras el mensaje.
                SolicitaError?.Invoke("Error al cargar los datos: " + ex.Message);
                SolicitaCerrar?.Invoke();
            }
        }

        /// <summary>
        /// TextChanged de txtSub/txtAnt/txtEnv → CalcularTotal. El costo de envío
        /// sale del campo (decisión C6), no del Id de la opción del combo.
        /// </summary>
        private void CalcularTotal()
        {
            if (cargando) return;

            decimal.TryParse(Subtotal, out decimal subtotal);
            decimal.TryParse(CostoEnvio, out decimal envio);
            decimal.TryParse(Anticipo, out decimal anticipo);

            totalPed = (subtotal + envio) - anticipo;
            Total = FormatearTotal(totalPed);
        }

        /// <summary>
        /// btnGuardar_Click: valida (criterios de C4-1a), actualiza por Id y pide a
        /// la vista el MessageBox de éxito; la ventana se cierra después.
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

            if (!TryMonto(CostoEnvio, out decimal envio))
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
                Id = idPedido,
                Cliente = Cliente,
                Contacto = Contacto,
                TipoPedidoId = TipoSeleccionado.Id,
                DescripcionPersonalizada = Descripcion,
                Subtotal = subtotal,
                CostoEnvio = envio,
                PrecioFinal = totalPed,
                Anticipo = anticipo,
                FechaEntrega = FechaEntrega.Value.Date,
                OpcionEnvioId = EnvioSeleccionado.Id
            };

            try
            {
                repositorioEncargos.Actualizar(encargo);
            }
            catch (Exception ex)
            {
                SolicitaError?.Invoke("Ocurrió un error al guardar: " + ex.Message);
                return;
            }

            PedidoActualizado?.Invoke();
        }

        /// <summary>btnCerrar_Click.</summary>
        [RelayCommand]
        private void Cerrar() => SolicitaCerrar?.Invoke();

        /// <summary>txtSub/txtAnt/txtEnv del WinForms: DBNull se mostraba como "".</summary>
        private static string FormatearMonto(decimal? monto) =>
            monto is null ? string.Empty : monto.Value.ToString("0.00", CultureInfo.CurrentCulture);

        /// <summary>txtTotal: "$" + totalPed.ToString("0.00").</summary>
        private static string FormatearTotal(decimal monto) =>
            "$" + monto.ToString("0.00", CultureInfo.CurrentCulture);

        /// <summary>Mismo criterio de C4-1a: vacío o inválido cuenta como 0.</summary>
        private static bool TryMonto(string texto, out decimal monto)
        {
            if (string.IsNullOrWhiteSpace(texto))
            {
                monto = 0m;
                return true;
            }

            return decimal.TryParse(texto, out monto);
        }
    }
}

using System.Globalization;
using CommunityToolkit.Mvvm.ComponentModel;
using MyCrochetWpf.Data;
using MyCrochetWpf.Models;

namespace MyCrochetWpf.ViewModels
{
    /// <summary>
    /// FmVerPedido: detalle de un pedido en modo solo lectura. Los montos se
    /// formatean con "$#,##0.00" fijo (independiente de la configuración regional)
    /// y los nulos siguen el criterio del WinForms ($0.00 / "No especificado").
    /// La vista (C5-2) solo muestra el mensaje de error y cierra.
    /// </summary>
    public partial class VerPedidoViewModel : ObservableObject
    {
        // Formato fijo aprobado en C5 ("$#,##0.00"); la sección negativa coloca el
        // signo antes del $ como hacía ToString("C2") del WinForms.
        private const string FormatoMoneda = "$#,##0.00;-$#,##0.00";
        private const string FormatoFecha = "dd/MM/yyyy";

        private readonly RepositorioEncargos repositorio;
        private readonly int idPedido;

        public VerPedidoViewModel(int idPedido, RepositorioEncargos? repositorio = null)
        {
            this.idPedido = idPedido;
            this.repositorio = repositorio ?? new RepositorioEncargos();
        }

        /// <summary>
        /// La vista muestra "Error al cargar el detalle del pedido: …" con el título
        /// "Error de Lectura" del WinForms.
        /// </summary>
        public event Action<string>? SolicitaError;

        /// <summary>Tras el error la ventana se cierra (decisión de C5).</summary>
        public event Action? SolicitaCerrar;

        /// <summary>txtNom.</summary>
        [ObservableProperty]
        private string cliente = string.Empty;

        /// <summary>txtContacto (vacío si la BD trae NULL).</summary>
        [ObservableProperty]
        private string contacto = string.Empty;

        /// <summary>txtTipo.</summary>
        [ObservableProperty]
        private string tipoPedido = string.Empty;

        /// <summary>txxFecha con formato dd/MM/yyyy.</summary>
        [ObservableProperty]
        private string fechaEntrega = string.Empty;

        /// <summary>txtDesc.</summary>
        [ObservableProperty]
        private string descripcion = string.Empty;

        /// <summary>txtSub.</summary>
        [ObservableProperty]
        private string subtotal = "$0.00";

        /// <summary>txtEnvio (NombreEnvio o "No especificado").</summary>
        [ObservableProperty]
        private string envio = "No especificado";

        /// <summary>txtAnt.</summary>
        [ObservableProperty]
        private string anticipo = "$0.00";

        /// <summary>txtEnv (costo de envío).</summary>
        [ObservableProperty]
        private string costoEnvio = "$0.00";

        /// <summary>txtTotal (PrecioFinal).</summary>
        [ObservableProperty]
        private string total = "$0.00";

        /// <summary>
        /// FmVerPedido_Load: lee el detalle con el Id del constructor. Se llama
        /// desde la vista después de suscribir los eventos (el WinForms lo hacía
        /// en el Load del formulario).
        /// </summary>
        public void Cargar()
        {
            EncargoDetalle? detalle;

            try
            {
                detalle = repositorio.ObtenerDetalle(idPedido);
            }
            catch (Exception ex)
            {
                // Mismo texto del WinForms; la ventana se cierra tras el mensaje.
                SolicitaError?.Invoke("Error al cargar el detalle del pedido: " + ex.Message);
                SolicitaCerrar?.Invoke();
                return;
            }

            if (detalle is null)
            {
                // El WinForms dejaba la ventana vacía; C5 acordó avisar y cerrar.
                SolicitaError?.Invoke("Error al cargar el detalle del pedido.");
                SolicitaCerrar?.Invoke();
                return;
            }

            Cliente = detalle.Cliente;
            Contacto = detalle.Contacto ?? string.Empty;
            TipoPedido = detalle.TipoPedido;
            FechaEntrega = detalle.FechaEntrega.ToString(FormatoFecha, CultureInfo.InvariantCulture);
            Descripcion = detalle.DescripcionPersonalizada ?? string.Empty;
            Subtotal = FormatearMoneda(detalle.Subtotal);
            Envio = string.IsNullOrWhiteSpace(detalle.NombreEnvio) ? "No especificado" : detalle.NombreEnvio;
            Anticipo = FormatearMoneda(detalle.Anticipo);
            CostoEnvio = FormatearMoneda(detalle.CostoEnvio);
            Total = FormatearMoneda(detalle.PrecioFinal);
        }

        /// <summary>Mismo criterio del WinForms: NULL o vacío se muestra como "$0.00".</summary>
        private static string FormatearMoneda(decimal? monto)
        {
            decimal valor = monto ?? 0m;
            return valor.ToString(FormatoMoneda, CultureInfo.InvariantCulture);
        }
    }
}

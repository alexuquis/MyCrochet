using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyCrochetWpf.Data;
using MyCrochetWpf.Models;
using MyCrochetWpf.Services;

namespace MyCrochetWpf.ViewModels
{
    /// <summary>
    /// FmPedidos: grid de pedidos con filtros en vivo por texto, tipo y estado.
    /// C3-1 cubre datos, filtros y comandos; la ventana llega en C3-2.
    /// </summary>
    public partial class PedidosViewModel : ObservableObject
    {
        private readonly RepositorioEncargos repositorioEncargos;
        private readonly RepositorioCatalogos repositorioCatalogos;

        public PedidosViewModel(
            RepositorioEncargos? repositorioEncargos = null,
            RepositorioCatalogos? repositorioCatalogos = null)
        {
            this.repositorioEncargos = repositorioEncargos ?? new RepositorioEncargos();
            this.repositorioCatalogos = repositorioCatalogos ?? new RepositorioCatalogos();
        }

        /// <summary>La vista pregunta "Deseas eliminar este pedido?" antes de borrar.</summary>
        public event Action<int>? SolicitaConfirmarEliminar;

        /// <summary>FmNuevoPedido se abre en C4.</summary>
        public event Action? SolicitaNuevoPedido;

        /// <summary>FmVerPedido se abre en C5.</summary>
        public event Action<int>? SolicitaVerPedido;

        /// <summary>FmEditarPedido se abre en C6.</summary>
        public event Action<int>? SolicitaModificarPedido;

        /// <summary>La vista oculta Pedidos y muestra Inicio (C3-3).</summary>
        public event Action? SolicitaIrAInicio;

        /// <summary>La vista confirma y vuelve al Login (mismo patrón que C2c).</summary>
        public event Action? SolicitaCerrarSesion;

        /// <summary>Filas del grid (Encargos + TipoPedidos + Estados).</summary>
        public ObservableCollection<PedidoResumen> Pedidos { get; } = new();

        /// <summary>Combo de tipo: catálogo real con "Todos" (Id 0) al inicio.</summary>
        public ObservableCollection<TipoPedido> Tipos { get; } = new();

        /// <summary>Combo de estado: catálogo real con "Todos" (Id 0) al inicio.</summary>
        public ObservableCollection<Estado> Estados { get; } = new();

        /// <summary>FmPedidos.txtBusc.</summary>
        [ObservableProperty]
        private string filtroTexto = string.Empty;

        /// <summary>FmPedidos.cmbTipoFiltro (0 = Todos).</summary>
        [ObservableProperty]
        private int tipoIdSeleccionado;

        /// <summary>FmPedidos.cmbEstadoFiltro (0 = Todos).</summary>
        [ObservableProperty]
        private int estadoIdSeleccionado;

        partial void OnFiltroTextoChanged(string value) => Filtrar();

        partial void OnTipoIdSeleccionadoChanged(int value) => Filtrar();

        partial void OnEstadoIdSeleccionadoChanged(int value) => Filtrar();

        /// <summary>FmPedidos: fecha de entrega mínima del rango (null = sin límite).</summary>
        [ObservableProperty]
        private DateTime? fechaDesde;

        /// <summary>FmPedidos: fecha de entrega máxima del rango (null = sin límite).</summary>
        [ObservableProperty]
        private DateTime? fechaHasta;

        partial void OnFechaDesdeChanged(DateTime? value) => Filtrar();

        partial void OnFechaHastaChanged(DateTime? value) => Filtrar();

        /// <summary>FmPedidos_Load: eliminarPedido.Visible = (RolUsuarioAct == 1).</summary>
        public bool PuedeEliminarPedidos => SesionService.Actual.RolId == 1;

        /// <summary>FmPedidos_Load: catálogos + primera carga del grid.</summary>
        public void Cargar()
        {
            CargarCombos();
            Filtrar();
        }

        /// <summary>FmPedidos.cs → Combos(): catálogos + fila "Todos" (Id 0).</summary>
        public void CargarCombos()
        {
            Tipos.Clear();
            Tipos.Add(new TipoPedido { Id = 0, Nombre = "Todos" });
            foreach (var tipo in repositorioCatalogos.ListarTiposPedido())
            {
                Tipos.Add(tipo);
            }

            Estados.Clear();
            Estados.Add(new Estado { Id = 0, Nombre = "Todos" });
            foreach (var estado in repositorioCatalogos.ListarEstados())
            {
                Estados.Add(estado);
            }

            // Igual que los combos del WinForms: arrancan seleccionados en "Todos".
            TipoIdSeleccionado = 0;
            EstadoIdSeleccionado = 0;
        }

        /// <summary>FmPedidos.cs → Filtrar() + Pedidos(filtro, tipo, estado, desde, hasta).</summary>
        public void Filtrar()
        {
            int? tipo = TipoIdSeleccionado == 0 ? null : TipoIdSeleccionado;
            int? estado = EstadoIdSeleccionado == 0 ? null : EstadoIdSeleccionado;

            // Si la usuaria elige las fechas al revés, se ordenan para no dejar el
            // grid vacío por un rango imposible (FechaDesde > FechaHasta).
            DateTime? desde = FechaDesde;
            DateTime? hasta = FechaHasta;
            if (desde.HasValue && hasta.HasValue && desde > hasta)
            {
                (desde, hasta) = (hasta, desde);
            }

            Pedidos.Clear();
            foreach (var pedido in repositorioEncargos.Listar(FiltroTexto, tipo, estado, desde, hasta))
            {
                Pedidos.Add(pedido);
            }
        }

        /// <summary>
        /// Devuelve los filtros a su estado inicial ("Todos" y sin rango de fechas).
        /// </summary>
        [RelayCommand]
        private void LimpiarFiltros()
        {
            FiltroTexto = string.Empty;
            TipoIdSeleccionado = 0;
            EstadoIdSeleccionado = 0;
            FechaDesde = null;
            FechaHasta = null;
        }

        /// <summary>FmPedidos.cs → btnNuevoPed_Click (FmNuevoPedido.ShowDialog).</summary>
        [RelayCommand]
        private void NuevoPedido() => SolicitaNuevoPedido?.Invoke();

        /// <summary>Menú contextual → VerPedido_Click.</summary>
        [RelayCommand]
        private void VerPedido(PedidoResumen? pedido)
        {
            if (pedido is not null)
            {
                SolicitaVerPedido?.Invoke(pedido.Id);
            }
        }

        /// <summary>Menú contextual → ModificarPedido_Click.</summary>
        [RelayCommand]
        private void ModificarPedido(PedidoResumen? pedido)
        {
            if (pedido is not null)
            {
                SolicitaModificarPedido?.Invoke(pedido.Id);
            }
        }

        /// <summary>Menú contextual → eliminarPedido_Click: pide confirmación a la vista.</summary>
        [RelayCommand]
        private void EliminarPedido(PedidoResumen? pedido)
        {
            if (pedido is not null)
            {
                SolicitaConfirmarEliminar?.Invoke(pedido.Id);
            }
        }

        /// <summary>
        /// Confirmación ya resuelta por la vista (Yes/No del WinForms). A diferencia del
        /// original, tras borrar se reaplica el filtro vigente en lugar de recargar todo.
        /// </summary>
        public void ProcesarEliminarPedido(int id, bool confirmado)
        {
            if (!confirmado) return;

            repositorioEncargos.Eliminar(id);
            Filtrar();
        }

        /// <summary>Menú lateral → btnInicio_Click / btnlogo_Click.</summary>
        [RelayCommand]
        private void IrAInicio() => SolicitaIrAInicio?.Invoke();

        /// <summary>Menú lateral → button5_Click (Cerrar Sesión).</summary>
        [RelayCommand]
        private void CerrarSesion() => SolicitaCerrarSesion?.Invoke();
    }
}

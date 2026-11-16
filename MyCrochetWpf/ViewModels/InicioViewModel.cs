using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyCrochetWpf.Data;
using MyCrochetWpf.Models;
using MyCrochetWpf.Services;

namespace MyCrochetWpf.ViewModels
{
    /// <summary>
    /// FmInicio: saludo, pedidos pendientes, fechas del calendario y alertas de stock.
    /// La vista (InicioWindow) se construye en C2b y el refresco al reactivar en C2c.
    /// Las consultas ya existen en RepositorioEncargos y RepositorioArticulos.
    /// </summary>
    public partial class InicioViewModel : ObservableObject
    {
        private readonly RepositorioEncargos repositorioEncargos;
        private readonly RepositorioArticulos repositorioArticulos;

        /// <summary>La vista oculta Inicio y muestra Pedidos (C3-3).</summary>
        public event Action? SolicitaIrAPedidos;

        public InicioViewModel(
            RepositorioEncargos? repositorioEncargos = null,
            RepositorioArticulos? repositorioArticulos = null)
        {
            this.repositorioEncargos = repositorioEncargos ?? new RepositorioEncargos();
            this.repositorioArticulos = repositorioArticulos ?? new RepositorioArticulos();
        }

        /// <summary>"Bienvenido/Bienvenida, {Nombre}!" según el género de la sesión.</summary>
        [ObservableProperty]
        private string saludo = string.Empty;

        /// <summary>Controla el mensaje "No hay alertas" del panel de inventario.</summary>
        [ObservableProperty]
        private bool hayAlertas;

        /// <summary>Pedidos con EstadoId = 1, ordenados por fecha de entrega.</summary>
        public ObservableCollection<PedidoPendiente> Pedidos { get; } = new();

        /// <summary>Materiales con Inventario &lt;= 2.</summary>
        public ObservableCollection<ArticuloStockBajo> Alertas { get; } = new();

        /// <summary>Fechas a resaltar en el calendario (una por pedido pendiente).</summary>
        public ObservableCollection<DateTime> FechasPendientes { get; } = new();

        /// <summary>Equivale al constructor de FmInicio: saludo + pedidos + alertas.</summary>
        public void Cargar()
        {
            CargarSaludo();
            CargarPedidos();
            CargarAlertas();
        }

        /// <summary>FmInicio.cs → Saludo().</summary>
        public void CargarSaludo()
        {
            var sesion = SesionService.Actual;
            string bienvenida = sesion.Genero == "Femenino" ? "Bienvenida" : "Bienvenido";
            Saludo = bienvenida + ", " + sesion.Nombre + "!";
        }

        /// <summary>FmInicio.cs → CargarPedidos(): tabla y fechas del calendario.</summary>
        public void CargarPedidos()
        {
            Pedidos.Clear();
            FechasPendientes.Clear();

            foreach (var pedido in repositorioEncargos.ListarPendientes())
            {
                Pedidos.Add(pedido);
                FechasPendientes.Add(pedido.Fecha.Date);
            }
        }

        /// <summary>FmInicio.cs → Alertas(): material con menos de 2 existencias.</summary>
        public void CargarAlertas()
        {
            Alertas.Clear();

            foreach (var alerta in repositorioArticulos.ListarStockBajo())
            {
                Alertas.Add(alerta);
            }

            // Mismo criterio que el WinForms: si no hubo filas, se muestra "No hay alertas".
            HayAlertas = Alertas.Count > 0;
        }

        /// <summary>FmInicio.cs → btnPedidos_Click / btnNuevoPed_Click.</summary>
        [RelayCommand]
        private void IrAPedidos() => SolicitaIrAPedidos?.Invoke();
    }
}

using Microsoft.Data.Sqlite;
using MyCrochetWpf.Models;

namespace MyCrochetWpf.Data
{
    /// <summary>
    /// SELECTs de catálogos migrados 1:1 del proyecto WinForms.
    /// Los entities usan <c>Nombre</c>; aquí se mapea la columna real de cada tabla.
    /// </summary>
    public class RepositorioCatalogos
    {
        /// <summary>FmNuevoUs / FmConfiguracion / FmNuevoMaterial: "SELECT Id, Genero FROM Generos".</summary>
        public List<Genero> ListarGeneros() =>
            Consultar("SELECT Id, Genero FROM Generos",
                lector => new Genero { Id = lector.GetInt32(0), Nombre = lector.GetString(1) });

        /// <summary>FmNuevoUs / FmConfiguracion: "SELECT Id, Rol FROM Roles".</summary>
        public List<Rol> ListarRoles() =>
            Consultar("SELECT Id, Rol FROM Roles",
                lector => new Rol { Id = lector.GetInt32(0), Nombre = lector.GetString(1) });

        /// <summary>FmNuevoPedido / FmEditarPedido / FmPedidos: "SELECT Id, Nombre FROM TipoPedidos".</summary>
        public List<TipoPedido> ListarTiposPedido() =>
            Consultar("SELECT Id, Nombre FROM TipoPedidos",
                lector => new TipoPedido { Id = lector.GetInt32(0), Nombre = lector.GetString(1) });

        /// <summary>FmNuevoPedido / FmPedidos: "SELECT Id, Estado FROM Estados".</summary>
        public List<Estado> ListarEstados() =>
            Consultar("SELECT Id, Estado FROM Estados",
                lector => new Estado { Id = lector.GetInt32(0), Nombre = lector.GetString(1) });

        /// <summary>FmNuevoPedido / FmEditarPedido / FmPedidos: "SELECT Id, Nombre FROM OpcionesEnvio".</summary>
        public List<OpcionEnvio> ListarOpcionesEnvio() =>
            Consultar("SELECT Id, Nombre FROM OpcionesEnvio",
                lector => new OpcionEnvio { Id = lector.GetInt32(0), Nombre = lector.GetString(1) });

        private static List<T> Consultar<T>(string query, Func<SqliteDataReader, T> mapear)
        {
            var resultados = new List<T>();

            using var conexion = Db.OpenConnection();
            using var comando = conexion.CreateCommand();
            comando.CommandText = query;

            using var lector = comando.ExecuteReader();
            while (lector.Read())
            {
                resultados.Add(mapear(lector));
            }

            return resultados;
        }
    }
}

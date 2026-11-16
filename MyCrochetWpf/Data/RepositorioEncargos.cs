using MyCrochetWpf.Models;

namespace MyCrochetWpf.Data
{
    /// <summary>
    /// Consultas de Encargos migradas 1:1 del proyecto WinForms
    /// (FmPedidos, FmNuevoPedido, FmVerPedido, FmEditarPedido, FmInicio).
    /// </summary>
    public class RepositorioEncargos
    {
        /// <summary>FmPedidos.cs: grid con filtro de texto, tipo y estado opcionales.</summary>
        public List<PedidoResumen> Listar(string filtro = "", int? tipo = null, int? estado = null)
        {
            // SQL Server usaba '+' para concatenar y CAST(... AS NVARCHAR).
            const string query = @"SELECT e.Id, e.Cliente, tp.Nombre AS TipoPedido, es.Estado, e.FechaEntrega
                                   FROM Encargos e
                                   INNER JOIN TipoPedidos tp ON e.TipoPedidoId = tp.Id
                                   INNER JOIN Estados es ON e.EstadoId = es.Id
                                   WHERE (e.Cliente LIKE '%' || @filtro || '%'
                                          OR CAST(e.Id AS TEXT) LIKE '%' || @filtro || '%'
                                          OR @filtro = '')
                                   AND (e.TipoPedidoId = @tipo OR @tipo IS NULL)
                                   AND (e.EstadoId = @estado OR @estado IS NULL)";

            var pedidos = new List<PedidoResumen>();

            using var conexion = Db.OpenConnection();
            using var comando = conexion.CreateCommand();
            comando.CommandText = query;
            comando.Parameters.AddWithValue("@filtro", filtro);
            comando.Parameters.AddWithValue("@tipo", (object?)tipo ?? DBNull.Value);
            comando.Parameters.AddWithValue("@estado", (object?)estado ?? DBNull.Value);

            using var lector = comando.ExecuteReader();
            while (lector.Read())
            {
                pedidos.Add(new PedidoResumen
                {
                    Id = lector.GetInt32(0),
                    Cliente = lector.GetString(1),
                    TipoPedido = lector.GetString(2),
                    Estado = lector.GetString(3),
                    FechaEntrega = lector.GetDateTime(4)
                });
            }

            return pedidos;
        }

        /// <summary>FmNuevoPedido.cs: INSERT del pedido completo.</summary>
        public int Insertar(Encargo encargo)
        {
            const string query = @"INSERT INTO Encargos
                (Cliente, Contacto, TipoPedidoId, DescripcionPersonalizada, Subtotal, CostoEnvio,
                 PrecioFinal, Anticipo, FechaEntrega, EstadoId, OpcionEnvioId)
                VALUES (@cliente, @contacto, @tipo, @desc, @subtotal, @envioCosto,
                        @precio, @anticipo, @fecha, @estado, @envioOpcionId)";

            using var conexion = Db.OpenConnection();
            using var comando = conexion.CreateCommand();
            comando.CommandText = query;
            comando.Parameters.AddWithValue("@cliente", encargo.Cliente);
            comando.Parameters.AddWithValue("@contacto", (object?)encargo.Contacto ?? DBNull.Value);
            comando.Parameters.AddWithValue("@tipo", encargo.TipoPedidoId);
            comando.Parameters.AddWithValue("@desc", (object?)encargo.DescripcionPersonalizada ?? DBNull.Value);
            comando.Parameters.AddWithValue("@subtotal", (object?)encargo.Subtotal ?? DBNull.Value);
            comando.Parameters.AddWithValue("@envioCosto", (object?)encargo.CostoEnvio ?? DBNull.Value);
            comando.Parameters.AddWithValue("@precio", encargo.PrecioFinal);
            comando.Parameters.AddWithValue("@anticipo", (object?)encargo.Anticipo ?? DBNull.Value);
            comando.Parameters.AddWithValue("@fecha", encargo.FechaEntrega);
            comando.Parameters.AddWithValue("@estado", encargo.EstadoId);
            comando.Parameters.AddWithValue("@envioOpcionId", (object?)encargo.OpcionEnvioId ?? DBNull.Value);

            return comando.ExecuteNonQuery();
        }

        /// <summary>FmPedidos.cs: DELETE por Id.</summary>
        public int Eliminar(int id)
        {
            const string query = "DELETE FROM Encargos WHERE Id = @id";

            using var conexion = Db.OpenConnection();
            using var comando = conexion.CreateCommand();
            comando.CommandText = query;
            comando.Parameters.AddWithValue("@id", id);

            return comando.ExecuteNonQuery();
        }

        /// <summary>FmVerPedido.cs: detalle con INNER JOIN TipoPedidos y LEFT JOIN OpcionesEnvio.</summary>
        public EncargoDetalle? ObtenerDetalle(int id)
        {
            const string query = @"SELECT e.Cliente, e.Contacto, tp.Nombre AS TipoPedido,
                                          e.DescripcionPersonalizada, e.PrecioFinal, e.FechaEntrega,
                                          e.Subtotal, e.Anticipo, e.CostoEnvio, oe.Nombre AS NombreEnvio
                                   FROM Encargos e
                                   INNER JOIN TipoPedidos tp ON e.TipoPedidoId = tp.Id
                                   LEFT JOIN OpcionesEnvio oe ON e.OpcionEnvioId = oe.Id
                                   WHERE e.Id = @id";

            using var conexion = Db.OpenConnection();
            using var comando = conexion.CreateCommand();
            comando.CommandText = query;
            comando.Parameters.AddWithValue("@id", id);

            using var lector = comando.ExecuteReader();
            if (!lector.Read()) return null;

            return new EncargoDetalle
            {
                Cliente = lector.GetString(0),
                Contacto = lector.IsDBNull(1) ? null : lector.GetString(1),
                TipoPedido = lector.GetString(2),
                DescripcionPersonalizada = lector.IsDBNull(3) ? null : lector.GetString(3),
                PrecioFinal = lector.GetDecimal(4),
                FechaEntrega = lector.GetDateTime(5),
                Subtotal = lector.IsDBNull(6) ? null : lector.GetDecimal(6),
                Anticipo = lector.IsDBNull(7) ? null : lector.GetDecimal(7),
                CostoEnvio = lector.IsDBNull(8) ? null : lector.GetDecimal(8),
                NombreEnvio = lector.IsDBNull(9) ? null : lector.GetString(9)
            };
        }

        /// <summary>FmEditarPedido.cs: datos actuales del pedido por Id.</summary>
        public Encargo? ObtenerPorId(int id)
        {
            // El original no selecciona EstadoId (el formulario no edita estado).
            const string query = @"SELECT Cliente, Contacto, TipoPedidoId, DescripcionPersonalizada,
                                          PrecioFinal, FechaEntrega, OpcionEnvioId, CostoEnvio,
                                          Subtotal, Anticipo
                                   FROM Encargos WHERE Id = @id";

            using var conexion = Db.OpenConnection();
            using var comando = conexion.CreateCommand();
            comando.CommandText = query;
            comando.Parameters.AddWithValue("@id", id);

            using var lector = comando.ExecuteReader();
            if (!lector.Read()) return null;

            return new Encargo
            {
                Id = id,
                Cliente = lector.GetString(0),
                Contacto = lector.IsDBNull(1) ? null : lector.GetString(1),
                TipoPedidoId = lector.GetInt32(2),
                DescripcionPersonalizada = lector.IsDBNull(3) ? null : lector.GetString(3),
                PrecioFinal = lector.GetDecimal(4),
                FechaEntrega = lector.GetDateTime(5),
                OpcionEnvioId = lector.IsDBNull(6) ? null : lector.GetInt32(6),
                CostoEnvio = lector.IsDBNull(7) ? null : lector.GetDecimal(7),
                Subtotal = lector.IsDBNull(8) ? null : lector.GetDecimal(8),
                Anticipo = lector.IsDBNull(9) ? null : lector.GetDecimal(9)
            };
        }

        /// <summary>FmEditarPedido.cs: UPDATE por Id (no modifica EstadoId, igual que el original).</summary>
        public int Actualizar(Encargo encargo)
        {
            const string query = @"UPDATE Encargos
                                   SET Cliente = @cliente, Contacto = @contacto, TipoPedidoId = @tipo,
                                       DescripcionPersonalizada = @desc, PrecioFinal = @precioFinal,
                                       FechaEntrega = @fecha, OpcionEnvioId = @opcionEnvio,
                                       CostoEnvio = @costoEnvio, Subtotal = @subtotal,
                                       Anticipo = @anticipo
                                   WHERE Id = @id";

            using var conexion = Db.OpenConnection();
            using var comando = conexion.CreateCommand();
            comando.CommandText = query;
            comando.Parameters.AddWithValue("@cliente", encargo.Cliente);
            comando.Parameters.AddWithValue("@contacto", (object?)encargo.Contacto ?? DBNull.Value);
            comando.Parameters.AddWithValue("@tipo", encargo.TipoPedidoId);
            comando.Parameters.AddWithValue("@desc", (object?)encargo.DescripcionPersonalizada ?? DBNull.Value);
            comando.Parameters.AddWithValue("@precioFinal", encargo.PrecioFinal);
            comando.Parameters.AddWithValue("@fecha", encargo.FechaEntrega);
            comando.Parameters.AddWithValue("@opcionEnvio", (object?)encargo.OpcionEnvioId ?? DBNull.Value);
            comando.Parameters.AddWithValue("@costoEnvio", (object?)encargo.CostoEnvio ?? DBNull.Value);
            comando.Parameters.AddWithValue("@subtotal", (object?)encargo.Subtotal ?? DBNull.Value);
            comando.Parameters.AddWithValue("@anticipo", (object?)encargo.Anticipo ?? DBNull.Value);
            comando.Parameters.AddWithValue("@id", encargo.Id);

            return comando.ExecuteNonQuery();
        }

        /// <summary>FmInicio.cs: pedidos pendientes (EstadoId = 1), ordenados por entrega.</summary>
        public List<PedidoPendiente> ListarPendientes()
        {
            const string query = @"SELECT E.Cliente, TP.Nombre AS TipoPedido, E.FechaEntrega AS Fecha
                                   FROM Encargos E
                                   INNER JOIN TipoPedidos TP ON E.TipoPedidoId = TP.Id
                                   WHERE E.EstadoId = 1
                                   ORDER BY E.FechaEntrega ASC";

            var pedidos = new List<PedidoPendiente>();

            using var conexion = Db.OpenConnection();
            using var comando = conexion.CreateCommand();
            comando.CommandText = query;

            using var lector = comando.ExecuteReader();
            while (lector.Read())
            {
                pedidos.Add(new PedidoPendiente
                {
                    Cliente = lector.GetString(0),
                    TipoPedido = lector.GetString(1),
                    Fecha = lector.GetDateTime(2)
                });
            }

            return pedidos;
        }
    }
}

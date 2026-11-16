using MyCrochetWpf.Models;

namespace MyCrochetWpf.Data
{
    /// <summary>
    /// Consultas de Articulos y Categorias migradas 1:1 del proyecto WinForms
    /// (FmInventario, FmNuevoMaterial, FmEditarMaterial, FmCotizador, FmInicio).
    /// </summary>
    public class RepositorioArticulos
    {
        /// <summary>FmInventario.cs: grid con filtro de texto y categoría.</summary>
        public List<ArticuloInventario> Listar(string filtro = "", int categoriaId = 0)
        {
            const string query = @"SELECT A.Id, C.Categoria, A.Marca, A.Tamaño, A.Color, A.Inventario, A.Precio
                                   FROM Articulos A INNER JOIN Categorias C ON A.CategoriaId = C.Id
                                   WHERE (A.Id LIKE @filtro OR A.Marca LIKE @filtro OR @filtro = '')
                                   AND (@categoriaId = 0 OR A.CategoriaId = @categoriaId)";

            var articulos = new List<ArticuloInventario>();

            using var conexion = Db.OpenConnection();
            using var comando = conexion.CreateCommand();
            comando.CommandText = query;
            comando.Parameters.AddWithValue("@filtro", "%" + filtro + "%");
            comando.Parameters.AddWithValue("@categoriaId", categoriaId);

            using var lector = comando.ExecuteReader();
            while (lector.Read())
            {
                articulos.Add(new ArticuloInventario
                {
                    Id = lector.GetInt32(0),
                    Categoria = lector.GetString(1),
                    Marca = lector.IsDBNull(2) ? null : lector.GetString(2),
                    Tamaño = lector.GetString(3),
                    Color = lector.GetString(4),
                    Inventario = lector.IsDBNull(5) ? null : lector.GetInt32(5),
                    Precio = lector.GetDecimal(6)
                });
            }

            return articulos;
        }

        /// <summary>FmNuevoMaterial / FmEditarMaterial / FmInventario: "SELECT Id, Categoria FROM Categorias".</summary>
        public List<Categoria> ListarCategorias()
        {
            const string query = "SELECT Id, Categoria FROM Categorias";
            var categorias = new List<Categoria>();

            using var conexion = Db.OpenConnection();
            using var comando = conexion.CreateCommand();
            comando.CommandText = query;

            using var lector = comando.ExecuteReader();
            while (lector.Read())
            {
                categorias.Add(new Categoria { Id = lector.GetInt32(0), Nombre = lector.GetString(1) });
            }

            return categorias;
        }

        /// <summary>FmNuevoMaterial.cs: INSERT del material.</summary>
        public int Insertar(Articulo articulo)
        {
            const string query = @"INSERT INTO Articulos (CategoriaId, Inventario, Tamaño, Color, Precio, Marca)
                                   VALUES (@CategoriaId, @Inventario, @Tamaño, @Color, @Precio, @Marca)";

            using var conexion = Db.OpenConnection();
            using var comando = conexion.CreateCommand();
            comando.CommandText = query;
            comando.Parameters.AddWithValue("@CategoriaId", articulo.CategoriaId);
            comando.Parameters.AddWithValue("@Inventario", (object?)articulo.Inventario ?? DBNull.Value);
            comando.Parameters.AddWithValue("@Tamaño", articulo.Tamaño);
            comando.Parameters.AddWithValue("@Color", articulo.Color);
            comando.Parameters.AddWithValue("@Precio", articulo.Precio);
            comando.Parameters.AddWithValue("@Marca", (object?)articulo.Marca ?? DBNull.Value);

            return comando.ExecuteNonQuery();
        }

        /// <summary>FmEditarMaterial.cs: SELECT de los datos actuales por Id.</summary>
        public Articulo? ObtenerPorId(int id)
        {
            const string query = @"SELECT CategoriaId, Inventario, Tamaño, Color, Precio, Marca
                                   FROM Articulos WHERE Id = @id";

            using var conexion = Db.OpenConnection();
            using var comando = conexion.CreateCommand();
            comando.CommandText = query;
            comando.Parameters.AddWithValue("@id", id);

            using var lector = comando.ExecuteReader();
            if (!lector.Read()) return null;

            return new Articulo
            {
                Id = id,
                CategoriaId = lector.GetInt32(0),
                Inventario = lector.IsDBNull(1) ? null : lector.GetInt32(1),
                Tamaño = lector.GetString(2),
                Color = lector.GetString(3),
                Precio = lector.GetDecimal(4),
                Marca = lector.IsDBNull(5) ? null : lector.GetString(5)
            };
        }

        /// <summary>FmEditarMaterial.cs: UPDATE por Id.</summary>
        public int Actualizar(Articulo articulo)
        {
            const string query = @"UPDATE Articulos
                                   SET CategoriaId = @catId, Inventario = @stock, Tamaño = @tamano,
                                       Color = @color, Precio = @precio, Marca = @marca
                                   WHERE Id = @id";

            using var conexion = Db.OpenConnection();
            using var comando = conexion.CreateCommand();
            comando.CommandText = query;
            comando.Parameters.AddWithValue("@catId", articulo.CategoriaId);
            comando.Parameters.AddWithValue("@stock", (object?)articulo.Inventario ?? DBNull.Value);
            comando.Parameters.AddWithValue("@tamano", articulo.Tamaño);
            comando.Parameters.AddWithValue("@color", articulo.Color);
            comando.Parameters.AddWithValue("@precio", articulo.Precio);
            comando.Parameters.AddWithValue("@marca", (object?)articulo.Marca ?? DBNull.Value);
            comando.Parameters.AddWithValue("@id", articulo.Id);

            return comando.ExecuteNonQuery();
        }

        /// <summary>FmInventario.cs: DELETE por Id.</summary>
        public int Eliminar(int id)
        {
            const string query = "DELETE FROM Articulos WHERE Id = @id";

            using var conexion = Db.OpenConnection();
            using var comando = conexion.CreateCommand();
            comando.CommandText = query;
            comando.Parameters.AddWithValue("@id", id);

            return comando.ExecuteNonQuery();
        }

        /// <summary>
        /// FmCotizador.cs: materiales únicos para el combo.
        /// SQL Server concatenaba con '+'; en SQLite se usa '||'.
        /// </summary>
        public List<MaterialCotizacion> ListarParaCotizador()
        {
            const string query = @"SELECT MIN(A.Id) AS Id, A.Marca || ' - ' || A.Tamaño AS NombreMaterial,
                                          A.Precio, C.Categoria
                                   FROM Articulos A INNER JOIN Categorias C ON A.CategoriaId = C.Id
                                   GROUP BY A.Marca, A.Tamaño, A.Precio, C.Categoria";

            var materiales = new List<MaterialCotizacion>();

            using var conexion = Db.OpenConnection();
            using var comando = conexion.CreateCommand();
            comando.CommandText = query;

            using var lector = comando.ExecuteReader();
            while (lector.Read())
            {
                materiales.Add(new MaterialCotizacion
                {
                    Id = lector.GetInt32(0),
                    NombreMaterial = lector.IsDBNull(1) ? string.Empty : lector.GetString(1),
                    Precio = lector.GetDecimal(2),
                    Categoria = lector.GetString(3)
                });
            }

            return materiales;
        }

        /// <summary>FmInicio.cs: alertas de stock bajo (Inventario &lt;= 2).</summary>
        public List<ArticuloStockBajo> ListarStockBajo()
        {
            const string query = "SELECT Marca, Tamaño, Color, Inventario FROM Articulos WHERE Inventario <= 2";

            var articulos = new List<ArticuloStockBajo>();

            using var conexion = Db.OpenConnection();
            using var comando = conexion.CreateCommand();
            comando.CommandText = query;

            using var lector = comando.ExecuteReader();
            while (lector.Read())
            {
                articulos.Add(new ArticuloStockBajo
                {
                    Marca = lector.IsDBNull(0) ? null : lector.GetString(0),
                    Tamaño = lector.GetString(1),
                    Color = lector.GetString(2),
                    Inventario = lector.IsDBNull(3) ? null : lector.GetInt32(3)
                });
            }

            return articulos;
        }
    }
}

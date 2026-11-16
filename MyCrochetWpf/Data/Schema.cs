using Microsoft.Data.Sqlite;

namespace MyCrochetWpf.Data
{
    /// <summary>
    /// Esquema de mycrochet.db. Inferido de las queries del proyecto WinForms y
    /// verificado contra INFORMATION_SCHEMA de CrochetDB (solo lectura).
    /// </summary>
    public static class Schema
    {
        private const string Ddl = @"
CREATE TABLE IF NOT EXISTS Generos (
    Id      INTEGER PRIMARY KEY AUTOINCREMENT,
    Genero  TEXT NOT NULL
);

CREATE TABLE IF NOT EXISTS Roles (
    Id   INTEGER PRIMARY KEY AUTOINCREMENT,
    Rol  TEXT NOT NULL
);

CREATE TABLE IF NOT EXISTS Usuarios (
    Id          INTEGER PRIMARY KEY AUTOINCREMENT,
    Nombre      TEXT NOT NULL,
    GeneroId    INTEGER NOT NULL,
    RolesId     INTEGER NOT NULL,
    Contraseña  TEXT NOT NULL,
    FOREIGN KEY (GeneroId) REFERENCES Generos(Id),
    FOREIGN KEY (RolesId) REFERENCES Roles(Id)
);

CREATE TABLE IF NOT EXISTS Categorias (
    Id         INTEGER PRIMARY KEY AUTOINCREMENT,
    Categoria  TEXT NOT NULL
);

CREATE TABLE IF NOT EXISTS Articulos (
    Id           INTEGER PRIMARY KEY AUTOINCREMENT,
    CategoriaId  INTEGER NOT NULL,
    Inventario   INTEGER,
    Tamaño       TEXT NOT NULL,
    Color        TEXT NOT NULL,
    Precio       REAL NOT NULL,
    Modelo       BLOB,
    Marca        TEXT,
    FOREIGN KEY (CategoriaId) REFERENCES Categorias(Id)
);

CREATE TABLE IF NOT EXISTS TipoPedidos (
    Id      INTEGER PRIMARY KEY AUTOINCREMENT,
    Nombre  TEXT NOT NULL
);

CREATE TABLE IF NOT EXISTS Estados (
    Id      INTEGER PRIMARY KEY AUTOINCREMENT,
    Estado  TEXT NOT NULL
);

CREATE TABLE IF NOT EXISTS OpcionesEnvio (
    Id      INTEGER PRIMARY KEY AUTOINCREMENT,
    Nombre  TEXT NOT NULL
);

CREATE TABLE IF NOT EXISTS Encargos (
    Id                      INTEGER PRIMARY KEY AUTOINCREMENT,
    Cliente                 TEXT NOT NULL,
    TipoPedidoId            INTEGER NOT NULL,
    DescripcionPersonalizada TEXT,
    PrecioFinal             REAL NOT NULL,
    FechaEntrega            TEXT NOT NULL,
    EstadoId                INTEGER NOT NULL,
    OpcionEnvioId           INTEGER,
    CostoEnvio              REAL,
    Subtotal                REAL,
    Anticipo                REAL,
    Contacto                TEXT,
    FOREIGN KEY (TipoPedidoId)  REFERENCES TipoPedidos(Id),
    FOREIGN KEY (EstadoId)      REFERENCES Estados(Id),
    FOREIGN KEY (OpcionEnvioId) REFERENCES OpcionesEnvio(Id)
);
";

        /// <summary>
        /// Crea las tablas si no existen y siembra los datos mínimos la primera vez.
        /// Es idempotente: se puede llamar en cada arranque.
        /// </summary>
        public static void EnsureCreated()
        {
            using var conexion = Db.OpenConnection();

            using (var comando = conexion.CreateCommand())
            {
                comando.CommandText = Ddl;
                comando.ExecuteNonQuery();
            }

            Sembrar(conexion);
        }

        private static void Sembrar(SqliteConnection conexion)
        {
            using var transaccion = conexion.BeginTransaction();

            // Valores reales de CrochetDB (solo lectura), conservando sus Id.
            SembrarCatalogo(conexion, transaccion, "Generos", "Genero",
                new[] { "Femenino", "Masculino", "Prefiero no decirlo" });

            SembrarCatalogo(conexion, transaccion, "Roles", "Rol",
                new[] { "Administrador", "Empleado" });

            SembrarCatalogo(conexion, transaccion, "Categorias", "Categoria",
                new[] { "Estambre", "Empaque", "Accesorios" });

            SembrarCatalogo(conexion, transaccion, "TipoPedidos", "Nombre",
                new[] { "Amigurumi", "Animal", "Flores" });

            SembrarCatalogo(conexion, transaccion, "Estados", "Estado",
                new[] { "Pendiente", "En Proceso", "Completado", "Cancelado" });

            SembrarCatalogo(conexion, transaccion, "OpcionesEnvio", "Nombre",
                new[] { "Entrega personal", "Estafeta", "DHL", "Ninguna" });

            SembrarAdmin(conexion, transaccion);

            transaccion.Commit();
        }

        private static void SembrarCatalogo(SqliteConnection conexion, SqliteTransaction transaccion,
            string tabla, string columna, string[] valores)
        {
            using var conteo = conexion.CreateCommand();
            conteo.Transaction = transaccion;
            conteo.CommandText = $"SELECT COUNT(*) FROM {tabla};";
            if ((long)conteo.ExecuteScalar()! > 0) return;

            for (var i = 0; i < valores.Length; i++)
            {
                using var insert = conexion.CreateCommand();
                insert.Transaction = transaccion;
                insert.CommandText = $"INSERT INTO {tabla} (Id, {columna}) VALUES (@id, @valor);";
                insert.Parameters.AddWithValue("@id", i + 1);
                insert.Parameters.AddWithValue("@valor", valores[i]);
                insert.ExecuteNonQuery();
            }
        }

        private static void SembrarAdmin(SqliteConnection conexion, SqliteTransaction transaccion)
        {
            using var conteo = conexion.CreateCommand();
            conteo.Transaction = transaccion;
            conteo.CommandText = "SELECT COUNT(*) FROM Usuarios;";
            if ((long)conteo.ExecuteScalar()! > 0) return;

            // Usuario mínimo para poder iniciar sesión; la dueña lo cambia en Configuración.
            using var insert = conexion.CreateCommand();
            insert.Transaction = transaccion;
            insert.CommandText = @"INSERT INTO Usuarios (Nombre, GeneroId, RolesId, Contraseña)
                                   VALUES (@nombre, @genero, @rol, @contra);";
            insert.Parameters.AddWithValue("@nombre", "admin");
            insert.Parameters.AddWithValue("@genero", 1);
            insert.Parameters.AddWithValue("@rol", 1);
            insert.Parameters.AddWithValue("@contra", "admin");
            insert.ExecuteNonQuery();
        }
    }
}

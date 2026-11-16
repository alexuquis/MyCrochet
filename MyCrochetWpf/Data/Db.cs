using System.IO;
using Microsoft.Data.Sqlite;

namespace MyCrochetWpf.Data
{
    /// <summary>
    /// Acceso centralizado a la base SQLite.
    /// Reemplaza la cadena hardcodeada de ConexGlobal del proyecto WinForms.
    /// </summary>
    public static class Db
    {
        public const string FileName = "mycrochet.db";

        /// <summary>El archivo vive junto al ejecutable, sin configuración externa.</summary>
        public static string DatabasePath { get; } =
            Path.Combine(AppContext.BaseDirectory, FileName);

        public static string ConnectionString { get; } =
            new SqliteConnectionStringBuilder
            {
                DataSource = DatabasePath,
                Mode = SqliteOpenMode.ReadWriteCreate
            }.ToString();

        /// <summary>
        /// Abre una conexión con las foreign keys activas.
        /// SQLite las desactiva por defecto en cada conexión.
        /// </summary>
        public static SqliteConnection OpenConnection()
        {
            var conexion = new SqliteConnection(ConnectionString);
            conexion.Open();

            using var pragma = conexion.CreateCommand();
            pragma.CommandText = "PRAGMA foreign_keys = ON;";
            pragma.ExecuteNonQuery();

            return conexion;
        }

        /// <summary>
        /// Garantiza que mycrochet.db exista desde el primer arranque.
        /// El esquema de tablas se crea en el paso B2 (EnsureCreated).
        /// </summary>
        public static void EnsureDatabase()
        {
            using var conexion = OpenConnection();
        }
    }
}

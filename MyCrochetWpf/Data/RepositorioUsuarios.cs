using MyCrochetWpf.Models;

namespace MyCrochetWpf.Data
{
    /// <summary>
    /// Consultas de Usuarios migradas 1:1 del proyecto WinForms
    /// (Form1.cs, FmUsuarios.cs, FmNuevoUs.cs, FmConfiguracion.cs).
    /// Reemplaza SqlDataAdapter/SqlCommandBuilder por CRUD manual parametrizado.
    /// </summary>
    public class RepositorioUsuarios
    {
        /// <summary>Login: Form1.cs (INNER JOIN con Generos).</summary>
        public UsuarioSesion? Autenticar(string nombre, string contrasena)
        {
            const string query = @"SELECT U.Nombre, U.RolesId, G.Genero
                                   FROM Usuarios U INNER JOIN Generos G ON U.GeneroId = G.Id
                                   WHERE U.Nombre = @nombre AND U.Contraseña = @contrasena";

            using var conexion = Db.OpenConnection();
            using var comando = conexion.CreateCommand();
            comando.CommandText = query;
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@contrasena", contrasena);

            using var lector = comando.ExecuteReader();
            if (!lector.Read()) return null;

            return new UsuarioSesion
            {
                Nombre = lector.GetString(0),
                RolId = lector.GetInt32(1),
                Genero = lector.GetString(2)
            };
        }

        /// <summary>FmUsuarios.cs: SELECT Id, Nombre, Contraseña, GeneroId, RolesId.</summary>
        public List<Usuario> Listar()
        {
            const string query = "SELECT Id, Nombre, Contraseña, GeneroId, RolesId FROM Usuarios";

            var usuarios = new List<Usuario>();

            using var conexion = Db.OpenConnection();
            using var comando = conexion.CreateCommand();
            comando.CommandText = query;

            using var lector = comando.ExecuteReader();
            while (lector.Read())
            {
                usuarios.Add(new Usuario
                {
                    Id = lector.GetInt32(0),
                    Nombre = lector.GetString(1),
                    Contraseña = lector.GetString(2),
                    GeneroId = lector.GetInt32(3),
                    RolesId = lector.GetInt32(4)
                });
            }

            return usuarios;
        }

        /// <summary>FmNuevoUs.cs: INSERT del nuevo perfil.</summary>
        public int Insertar(Usuario usuario)
        {
            const string query = @"INSERT INTO Usuarios (Nombre, GeneroId, RolesId, Contraseña)
                                   VALUES (@nombre, @genero, @rol, @contra)";

            using var conexion = Db.OpenConnection();
            using var comando = conexion.CreateCommand();
            comando.CommandText = query;
            comando.Parameters.AddWithValue("@nombre", usuario.Nombre);
            comando.Parameters.AddWithValue("@genero", usuario.GeneroId);
            comando.Parameters.AddWithValue("@rol", usuario.RolesId);
            comando.Parameters.AddWithValue("@contra", usuario.Contraseña);

            return comando.ExecuteNonQuery();
        }

        /// <summary>
        /// FmUsuarios.cs: guardado de fila del grid. Equivale al UPDATE que generaba
        /// SqlCommandBuilder, pero manual y por PK.
        /// </summary>
        public int Actualizar(Usuario usuario)
        {
            const string query = @"UPDATE Usuarios
                                   SET Nombre = @nombre, Contraseña = @contra,
                                       GeneroId = @genero, RolesId = @rol
                                   WHERE Id = @id";

            using var conexion = Db.OpenConnection();
            using var comando = conexion.CreateCommand();
            comando.CommandText = query;
            comando.Parameters.AddWithValue("@nombre", usuario.Nombre);
            comando.Parameters.AddWithValue("@contra", usuario.Contraseña);
            comando.Parameters.AddWithValue("@genero", usuario.GeneroId);
            comando.Parameters.AddWithValue("@rol", usuario.RolesId);
            comando.Parameters.AddWithValue("@id", usuario.Id);

            return comando.ExecuteNonQuery();
        }

        /// <summary>FmConfiguracion.cs: verificación previa del usuario/contraseña actuales.</summary>
        public bool ExisteCredencial(string nombreActual, string contrasenaActual)
        {
            const string query = @"SELECT COUNT(*) FROM Usuarios
                                   WHERE Nombre = @nombreActual AND Contraseña = @contraActual";

            using var conexion = Db.OpenConnection();
            using var comando = conexion.CreateCommand();
            comando.CommandText = query;
            comando.Parameters.AddWithValue("@nombreActual", nombreActual);
            comando.Parameters.AddWithValue("@contraActual", contrasenaActual);

            return (long)comando.ExecuteScalar()! > 0;
        }

        /// <summary>FmConfiguracion.cs: UPDATE del perfil por nombre actual.</summary>
        public int ActualizarPerfil(string nombreActual, string nombreNuevo,
            string contrasenaNueva, int generoId, int rolId)
        {
            const string query = @"UPDATE Usuarios
                                   SET Nombre = @nombreNuevo, Contraseña = @contraNueva,
                                       GeneroId = @genero, RolesId = @rol
                                   WHERE Nombre = @nombreActual";

            using var conexion = Db.OpenConnection();
            using var comando = conexion.CreateCommand();
            comando.CommandText = query;
            comando.Parameters.AddWithValue("@nombreNuevo", nombreNuevo);
            comando.Parameters.AddWithValue("@contraNueva", contrasenaNueva);
            comando.Parameters.AddWithValue("@genero", generoId);
            comando.Parameters.AddWithValue("@rol", rolId);
            comando.Parameters.AddWithValue("@nombreActual", nombreActual);

            return comando.ExecuteNonQuery();
        }

        /// <summary>FmUsuarios.cs: DELETE por Id.</summary>
        public int Eliminar(int id)
        {
            const string query = "DELETE FROM Usuarios WHERE Id = @id";

            using var conexion = Db.OpenConnection();
            using var comando = conexion.CreateCommand();
            comando.CommandText = query;
            comando.Parameters.AddWithValue("@id", id);

            return comando.ExecuteNonQuery();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyCrochet
{
    public partial class FmUsuarios : Form
    {
        SqlDataAdapter adaptador;
        DataTable tablaUsuarios;

        public FmUsuarios()
        {
            InitializeComponent();
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        // Función para mover la ventana
        private void MoverVentana(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, 0xA1, 0x2, 0);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                adaptador.Update(tablaUsuarios);
                MessageBox.Show("Los perfiles se han actualizado", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron guardar los cambios: " + ex.Message);
            }
        }

        private void FmUsuarios_Load(object sender, EventArgs e)
        {
            tabla();
            CargarUsuarios();
        }

        private void tabla()
        {
            Color rosaPastel = ColorTranslator.FromHtml("#FEA9BE");
            Color guindaLetra = ColorTranslator.FromHtml("#861940");

            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ReadOnly = false;

            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = rosaPastel;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = guindaLetra;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dataGridView1.EnableHeadersVisualStyles = false;

            dataGridView1.DefaultCellStyle.SelectionBackColor = rosaPastel;
            dataGridView1.DefaultCellStyle.SelectionForeColor = guindaLetra;
            dataGridView1.RowTemplate.Height = 20;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CargarUsuarios()
        {
            string query = "SELECT Id, Nombre, Contraseña, GeneroId, RolesId FROM Usuarios";

            adaptador = new SqlDataAdapter(query, ConexGlobal.cadena);
            SqlCommandBuilder constructorComandos = new SqlCommandBuilder(adaptador);

            tablaUsuarios = new DataTable();
            adaptador.Fill(tablaUsuarios);

            dataGridView1.DataSource = tablaUsuarios;

            dataGridView1.Columns["Id"].ReadOnly = true;
            dataGridView1.Columns["Id"].Visible = false;
            dataGridView1.Columns["GeneroId"].HeaderText = "ID Género";
            dataGridView1.Columns["RolesId"].HeaderText = "ID Rol";
        }

        private void btnNewPerfil_Click(object sender, EventArgs e)
        {
            FmNuevoUs pantallaUs = new FmNuevoUs();
            pantallaUs.ShowDialog();
            CargarUsuarios();
        }

        private void eliminarPerfilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int idSeleccionado = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
                string nombreUsuario = dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString();

                if (idSeleccionado == 1)
                {
                    MessageBox.Show("No puedes eliminar al Administrador principal del sistema.", "Acción bloqueada", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                DialogResult respuesta = MessageBox.Show(
                    "¿Estás segura de que deseas eliminar el acceso para '" + nombreUsuario + "'?\nEsta acción no se puede deshacer.",
                    "Confirmar Eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (respuesta == DialogResult.Yes)
                {
                    try
                    {
                        using (SqlConnection conexion = new SqlConnection(ConexGlobal.cadena))
                        {
                            conexion.Open();
                            string query = "DELETE FROM Usuarios WHERE Id = @id";

                            using (SqlCommand cmd = new SqlCommand(query, conexion))
                            {
                                cmd.Parameters.AddWithValue("@id", idSeleccionado);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        MessageBox.Show("Usuario eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        CargarUsuarios();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocurrió un error al intentar eliminar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}

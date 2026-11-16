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
    public partial class FmInventario : Form
    {
        public FmInventario()
        {
            InitializeComponent();
        }


        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private async void btnMinimizar_Click(object sender, EventArgs e)
        {
            // Efecto para minimizar
            for (double i = 1.0; i >= 0; i -= 0.1)
            {
                this.Opacity = i;
                await Task.Delay(10);
            }
            this.WindowState = FormWindowState.Minimized;
            this.Opacity = 1.0;
        }

        private void FmInventario_Load(object sender, EventArgs e)
        {
            eliminarMatToolStripMenuItem1.Visible = (ConexGlobal.RolUsuarioAct == 1);
            CargarArticulos();
            CargarCategorias();
            disenoInventario();
        }

        private void CargarArticulos(string filtro = "", int categoriaId = 0)
        {
            using (SqlConnection con = new SqlConnection(ConexGlobal.cadena))
            {
                con.Open();

                string query = @"SELECT A.Id, C.Categoria, A.Marca, A.Tamaño, A.Color, A.Inventario, A.Precio
                FROM Articulos A INNER JOIN Categorias C ON A.CategoriaId = C.Id WHERE (A.Id LIKE @filtro OR A.Marca LIKE @filtro OR @filtro = '')
                AND (@categoriaId = 0 OR A.CategoriaId = @categoriaId)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@filtro", "%" + filtro + "%");
                cmd.Parameters.AddWithValue("@categoriaId", categoriaId);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;
            }
        }

        private void CargarCategorias()
        {
            using (SqlConnection con = new SqlConnection(ConexGlobal.cadena))
            {
                con.Open();

                SqlDataAdapter da = new SqlDataAdapter("SELECT Id, Categoria FROM Categorias", con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Agregar opción "Todos"
                DataRow fila = dt.NewRow();
                fila["Id"] = 0;
                fila["Categoria"] = "Todos";
                dt.Rows.InsertAt(fila, 0);

                combMateriales.DataSource = dt;
                combMateriales.DisplayMember = "Categoria";
                combMateriales.ValueMember = "Id";
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int categoriaId = Convert.ToInt32(combMateriales.SelectedValue);
            CargarArticulos(textBox1.Text, categoriaId);
        }

        private void combMateriales_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combMateriales.SelectedValue != null
                && combMateriales.SelectedValue is int)
            {
                int categoriaId = (int)combMateriales.SelectedValue;
                CargarArticulos(textBox1.Text, categoriaId);
            }
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dataGridView1.ClearSelection();
                dataGridView1.Rows[e.RowIndex].Selected = true;
                dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }

        private void eliminarMaterialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int idSelec = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
            FmEditarMaterial ventanaEditar = new FmEditarMaterial(idSelec);
            ventanaEditar.ShowDialog();

            CargarArticulos();
        }

        private void eliminarMatToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int idSeleccionado = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
            string marca = dataGridView1.CurrentRow.Cells["Marca"].Value.ToString();
            string color = dataGridView1.CurrentRow.Cells["Color"].Value.ToString();

            DialogResult respuesta = MessageBox.Show("¿Deseas eliminar el material '" + marca + " - " + color + "'?\nEsta acción no se puede deshacer.",
                                     "Confirmar Eliminación",
                MessageBoxButtons.YesNo,
                 MessageBoxIcon.Error);

            if (respuesta == DialogResult.Yes)
            {

                string query = "DELETE FROM Articulos WHERE Id = @id";

                using (SqlConnection conexion = new SqlConnection(ConexGlobal.cadena))
                {
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@id", idSeleccionado);
                        conexion.Open();
                        comando.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Material eliminado del inventario", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarArticulos();
            }


        }
        private void disenoInventario()
        {
            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dataGridView1.DefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#861940");
            dataGridView1.DefaultCellStyle.BackColor = Color.White;

            dataGridView1.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#FEA9BE");
            dataGridView1.DefaultCellStyle.SelectionForeColor = ColorTranslator.FromHtml("#861940");

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#861940");
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dataGridView1.ColumnHeadersHeight = 35;

            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FFF0F5"); // Un rosa súper sutil

            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.GridColor = ColorTranslator.FromHtml("#FEA9BE");


            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;
        }

        private void btnNuevoPed_Click(object sender, EventArgs e)
        {
            FmNuevoMaterial ventanaNuevo = new FmNuevoMaterial();
            ventanaNuevo.ShowDialog();

            CargarArticulos();
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form VentanaInicio = Application.OpenForms["FmInicio"];

            if (VentanaInicio == null)
            {
                VentanaInicio = new FmInicio();
                VentanaInicio.Show();
            }
            else
            {
                VentanaInicio.Show();
            }
        }

        private void btnPedidos_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form VentanaPed = Application.OpenForms["FmPedidos"];

            if (VentanaPed == null)
            {
                VentanaPed = new FmPedidos();
                VentanaPed.Show();
            }
            else
            {
                VentanaPed.Show();
            }
        }

        private void btnCotizacion_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form VentanaCot = Application.OpenForms["FmCotizador"];

            if (VentanaCot == null)
            {
                VentanaCot = new FmCotizador();
                VentanaCot.Show();
            }
            else
            {
                VentanaCot.Show();
            }
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form VentanaConfig = Application.OpenForms["FmConfiguracion"];

            if (VentanaConfig == null)
            {
                VentanaConfig = new FmConfiguracion();
                VentanaConfig.Show();
            }
            else
            {
                VentanaConfig.Show();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show(
               "Deseas cerrar sesión?",
               "Cerrar Sesión",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question
           );


            if (respuesta == DialogResult.Yes)
            {
                Application.Restart();
            }
        }

        private void btnlogo_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form Ventanainicio = Application.OpenForms["Fminicio"];

            if (Ventanainicio == null)
            {
                Ventanainicio = new FmInicio();
                Ventanainicio.Show();
            }
            else
            {
                Ventanainicio.Show();
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
    }
}

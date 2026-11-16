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
    public partial class FmNuevoMaterial : Form
    {
        public FmNuevoMaterial()
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

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnAgregarMat_Click(object sender, EventArgs e)
        {
            // categ
            if (cmbCateg.SelectedIndex == -1)
            {
                MessageBox.Show("Selecciona una categoría");
                return;
            }

            int categoriaId = Convert.ToInt32(cmbCateg.SelectedValue);

            int.TryParse(txtStock.Text, out int stock);
            decimal.TryParse(txtPrecio.Text, out decimal precio);

            // Insertar
            string query = "INSERT INTO Articulos (CategoriaId, Inventario, Tamaño, Color, Precio, Marca) " +
                           "VALUES (@CategoriaId, @Inventario, @Tamaño, @Color, @Precio, @Marca)";

            using (SqlConnection conexion = new SqlConnection(ConexGlobal.cadena))
            {
                SqlCommand comando = new SqlCommand(query, conexion);

                comando.Parameters.AddWithValue("@CategoriaId", categoriaId);
                comando.Parameters.AddWithValue("@Inventario", stock);
                comando.Parameters.AddWithValue("@Tamaño", txtTam.Text);
                comando.Parameters.AddWithValue("@Color", txtColor.Text);
                comando.Parameters.AddWithValue("@Precio", precio);
                comando.Parameters.AddWithValue("@Marca", txtMarca.Text);

                conexion.Open();
                comando.ExecuteNonQuery();
            }

            MessageBox.Show("Material agregado al inventario:)");
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtMarca.Clear();
            cmbCateg.SelectedIndex = -1;
            txtColor.Clear();
            txtStock.Clear();
            txtPrecio.Clear();
            txtTam.Clear();
        }

        private void FmNuevoMaterial_Load(object sender, EventArgs e)
        {
            //categ
            string query = "SELECT Id, Categoria FROM Categorias";
            SqlDataAdapter adaptador = new SqlDataAdapter(query, ConexGlobal.cadena);
            DataTable tablaCategorias = new DataTable();
            adaptador.Fill(tablaCategorias);

            cmbCateg.DataSource = tablaCategorias;
            cmbCateg.DisplayMember = "Categoria";
            cmbCateg.ValueMember = "Id";

            cmbCateg.SelectedIndex = -1;
        }

        private void cmbCateg_SelectedIndexChanged(object sender, EventArgs e)
        {
            //animaciones
            if (cmbCateg.SelectedIndex == -1) return;

            string tipoSeleccionado = cmbCateg.Text;

            switch (tipoSeleccionado)
            {
                case "Estambre":
                    pictureBox1.ImageLocation = @"C:\Users\DELL\source\repos\MyCrochet\MyCrochet\AnimacionesFinal\Estambre2.gif";
                    pictureBox1.Visible = true;
                    break;

                case "Accesorios":
                    pictureBox1.ImageLocation = @"C:\Users\DELL\source\repos\MyCrochet\MyCrochet\AnimacionesFinal\Ojo.gif";
                    pictureBox1.Visible = true;
                    break;

                case "Empaque":
                    pictureBox1.ImageLocation = @"C:\Users\DELL\source\repos\MyCrochet\MyCrochet\AnimacionesFinal\Gancho.gif";
                    pictureBox1.Visible = true;
                    break;

                default:
                    pictureBox1.ImageLocation = null;
                    pictureBox1.Visible = false;
                    break;
            }
        }
    }
}

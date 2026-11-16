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
    public partial class FmEditarMaterial : Form
    {
        private int idArt;
        public FmEditarMaterial(int idSelec)
        {
            InitializeComponent();
            idArt = idSelec;
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

        private void FmEditarMaterial_Load(object sender, EventArgs e)
        {
            CargarCateg();
            ActuDatos();
        }

        private void CargarCateg()
        {
            string query = "SELECT Id, Categoria FROM Categorias";
            using (SqlConnection conexion = new SqlConnection(ConexGlobal.cadena))
            {
                SqlDataAdapter adaptador = new SqlDataAdapter(query, conexion);
                DataTable dt = new DataTable();
                adaptador.Fill(dt);

                cmbCateg.DataSource = dt;
                cmbCateg.DisplayMember = "Categoria";
                cmbCateg.ValueMember = "Id";
            }
        }
        private void ActuDatos()
        {
            string query = "SELECT CategoriaId, Inventario, Tamaño, Color, Precio, Marca FROM Articulos WHERE Id = @id";

            using (SqlConnection conexion = new SqlConnection(ConexGlobal.cadena))
            {
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@id", idArt);
                    conexion.Open();

                    using (SqlDataReader lector = comando.ExecuteReader())
                    {
                        if (lector.Read())
                        {
                            txtTipo.Text = lector["Marca"].ToString();
                            txtcant.Text = lector["Inventario"].ToString();
                            txtTam.Text = lector["Tamaño"].ToString();
                            txtColor.Text = lector["Color"].ToString();
                            txtPrecio.Text = lector["Precio"].ToString();

                            txtcod.Text = idArt.ToString();
                            txtcod.Enabled = false;

                            cmbCateg.SelectedValue = lector["CategoriaId"];
                        }
                    }
                }
            }
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            string query = @"UPDATE Articulos SET CategoriaId = @catId, Inventario = @stock, Tamaño = @tamano, 
                         Color = @color, Precio = @precio, Marca = @marca WHERE Id = @id";

            using (SqlConnection conexion = new SqlConnection(ConexGlobal.cadena))
            {
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@catId", cmbCateg.SelectedValue);
                    comando.Parameters.AddWithValue("@stock", Convert.ToInt32(txtcant.Text));
                    comando.Parameters.AddWithValue("@tamano", txtTam.Text);
                    comando.Parameters.AddWithValue("@color", txtColor.Text);

                    string precioLimpio = txtPrecio.Text.Replace("$", "").Trim();
                    comando.Parameters.AddWithValue("@precio", Convert.ToDecimal(precioLimpio));

                    comando.Parameters.AddWithValue("@marca", txtTipo.Text);
                    comando.Parameters.AddWithValue("@id", idArt);

                    conexion.Open();
                    int filasAfectadas = comando.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        MessageBox.Show("Los cambios se han guardado correctamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo actualizar el material, Vuelve a Intertarlo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }



        }
    }
}

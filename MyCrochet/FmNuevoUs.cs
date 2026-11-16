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
    public partial class FmNuevoUs : Form
    {
        public FmNuevoUs()
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnMinim_Click(object sender, EventArgs e)
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

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(ConexGlobal.cadena);
                conexion.Open();

                string query = "INSERT INTO Usuarios (Nombre, GeneroId, RolesId, Contraseña) VALUES (@nombre, @genero, @rol, @contra)";

                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@nombre", txtUsuario.Text);
                    comando.Parameters.AddWithValue("@genero", cmbGenero.SelectedValue);
                    comando.Parameters.AddWithValue("@rol", cmbRol.SelectedValue);
                    comando.Parameters.AddWithValue("@contra", txtpassword.Text);

                    comando.ExecuteNonQuery();

                    txtUsuario.Clear();
                    txtpassword.Clear();
                }
                conexion.Close();
            }
            catch (Exception)
            {
            }
        }

        private void FmNuevoUs_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(ConexGlobal.cadena);
                conexion.Open();


                SqlDataAdapter daGeneros = new SqlDataAdapter("SELECT Id, Genero FROM Generos", conexion);
                DataTable dtGeneros = new DataTable();
                daGeneros.Fill(dtGeneros);
                cmbGenero.DataSource = dtGeneros;
                cmbGenero.DisplayMember = "Genero";
                cmbGenero.ValueMember = "Id";


                SqlDataAdapter daRoles = new SqlDataAdapter("SELECT Id, Rol FROM Roles", conexion);
                DataTable dtRoles = new DataTable();
                daRoles.Fill(dtRoles);
                cmbRol.DataSource = dtRoles;
                cmbRol.DisplayMember = "Rol";
                cmbRol.ValueMember = "Id";

                conexion.Close();
            }
            catch (Exception)
            {
            }
        }
    }
    }


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
    public partial class FmConfiguracion : Form
    {
        public FmConfiguracion()
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

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FmConfiguracion_Load(object sender, EventArgs e)
        {
            try
            {
                if (ConexGlobal.RolUsuarioAct != 1)
                {
                    btnNewPerfil.Visible = false; //no para empleados
                }

                txtUserAct.Text = ConexGlobal.NombreUsuarioAct;

                SqlConnection conexion = new SqlConnection(ConexGlobal.cadena);
                conexion.Open();

                //comboboxs
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

        private void btnNewPerfil_Click(object sender, EventArgs e)
        {
            FmUsuarios pantallaUs = new FmUsuarios();
            pantallaUs.Show();
            
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(ConexGlobal.cadena);
                conexion.Open();

                string queryVerificar = "SELECT COUNT(*) FROM Usuarios WHERE Nombre = @nombreActual AND Contraseña = @contraActual";
                using (SqlCommand cmdVerificar = new SqlCommand(queryVerificar, conexion))
                {
                    cmdVerificar.Parameters.AddWithValue("@nombreActual", txtUserAct.Text);
                    cmdVerificar.Parameters.AddWithValue("@contraActual", txtContraAct.Text);

                    int existe = (int)cmdVerificar.ExecuteScalar();

                    if (existe > 0)
                    {
                        string queryActualizar = "UPDATE Usuarios SET Nombre = @nombreNuevo, Contraseña = @contraNueva, GeneroId = @genero, RolesId = @rol WHERE Nombre = @nombreActual";
                        using (SqlCommand cmdActualizar = new SqlCommand(queryActualizar, conexion))
                        {
                            cmdActualizar.Parameters.AddWithValue("@nombreNuevo", txtUserNuevo.Text);
                            cmdActualizar.Parameters.AddWithValue("@contraNueva", txtContraNueva.Text);
                            cmdActualizar.Parameters.AddWithValue("@genero", cmbGenero.SelectedValue);
                            cmdActualizar.Parameters.AddWithValue("@rol", cmbRol.SelectedValue);
                            cmdActualizar.Parameters.AddWithValue("@nombreActual", txtUserAct.Text);

                            cmdActualizar.ExecuteNonQuery();

                            txtContraAct.Clear();
                            txtUserNuevo.Clear();
                            txtContraNueva.Clear();

                            ConexGlobal.NombreUsuarioAct = txtUserNuevo.Text;
                            txtUserAct.Text = txtUserNuevo.Text;
                        }
                    }
                    else
                    {
                        MessageBox.Show("El usuario o la contraseña actual son incorrectos", "Datos Incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                conexion.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al intentar actualizar el perfil: " + ex.Message, "Error",MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }

        }

        private void btnInicio_Click(object sender, EventArgs e)
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

        private void btnPedidos_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form Ventanapedido = Application.OpenForms["Fmpedidos"];

            if (Ventanapedido == null)
            {
                Ventanapedido = new FmPedidos();
                Ventanapedido.Show();
            }
            else
            {
                Ventanapedido.Show();
            }
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form VentanaInv = Application.OpenForms["FmInventario"];

            if (VentanaInv == null)
            {
                VentanaInv = new FmInventario();
                VentanaInv.Show();
            }
            else
            {
                VentanaInv.Show();
            }
        }

        private void btnCotizacion_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form Ventanacotizacion = Application.OpenForms["FmCotizador"];

            if (Ventanacotizacion == null)
            {
                Ventanacotizacion = new FmCotizador();
                Ventanacotizacion.Show();
            }
            else
            {
                Ventanacotizacion.Show();
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

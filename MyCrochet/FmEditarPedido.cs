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
    public partial class FmEditarPedido : Form
    {
        public int IdPedido = 0;
        decimal totalPed = 0;
        public FmEditarPedido(int id)
        {
            InitializeComponent();
            IdPedido = id;
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


        private void FmEditarPedido_Load(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(ConexGlobal.cadena))
                {
                    conexion.Open();

                    SqlDataAdapter daTipos = new SqlDataAdapter("SELECT Id, Nombre FROM TipoPedidos", conexion);
                    DataTable dtTipos = new DataTable();
                    daTipos.Fill(dtTipos);
                    cmbTipo.DataSource = dtTipos;
                    cmbTipo.DisplayMember = "Nombre";
                    cmbTipo.ValueMember = "Id";

                    SqlDataAdapter daEnvios = new SqlDataAdapter("SELECT Id, Nombre FROM OpcionesEnvio", conexion);
                    DataTable dtEnvios = new DataTable();
                    daEnvios.Fill(dtEnvios);
                    cmbEnvio.DataSource = dtEnvios;
                    cmbEnvio.DisplayMember = "Nombre";
                    cmbEnvio.ValueMember = "Id";

                    if (IdPedido > 0)
                    {
                        
                        string query = @"SELECT Cliente, Contacto, TipoPedidoId, DescripcionPersonalizada, PrecioFinal, FechaEntrega, OpcionEnvioId, CostoEnvio, Subtotal, Anticipo FROM Encargos WHERE Id = @id";

                        using (SqlCommand cmd = new SqlCommand(query, conexion))
                        {
                            cmd.Parameters.AddWithValue("@id", IdPedido);
                            using (SqlDataReader lector = cmd.ExecuteReader())
                            {
                                if (lector.Read())
                                {
                                    txtNom.Text = lector["Cliente"].ToString();
                                    txtContacto.Text = lector["Contacto"].ToString();
                                    txtDesc.Text = lector["DescripcionPersonalizada"].ToString();
                                    txtSub.Text = lector["Subtotal"].ToString();
                                    txtAnt.Text = lector["Anticipo"].ToString();
                                    txtEnv.Text = lector["CostoEnvio"].ToString();
                                    txtTotal.Text = "$" + Convert.ToDecimal(lector["PrecioFinal"]).ToString("0.00");
                                    dateTimePicker1.Value = Convert.ToDateTime(lector["FechaEntrega"]);

                                    cmbTipo.SelectedValue = lector["TipoPedidoId"];

                                    if (lector["OpcionEnvioId"] != DBNull.Value)
                                        cmbEnvio.SelectedValue = lector["OpcionEnvioId"];

                                    decimal.TryParse(lector["PrecioFinal"].ToString(), out totalPed);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Rol 0Empleado
            if (ConexGlobal.RolUsuarioAct != 1)
            {
                txtNom.Enabled = false;
                txtContacto.Enabled = false;     
                cmbTipo.Enabled = false;
                txtSub.Enabled = false;
                txtAnt.Enabled = false;
                txtEnv.Enabled = false;
                txtTotal.Enabled = false;
                cmbEnvio.Enabled = false;
            }
        }
        private void CalcularTotal()
        {
            decimal.TryParse(txtSub.Text, out decimal subtotal);
            decimal.TryParse(txtAnt.Text, out decimal anticipo);


            decimal envio = 0;
            if (cmbEnvio.SelectedValue != null)
            {
                decimal.TryParse(cmbEnvio.SelectedValue.ToString(), out envio);
                txtEnv.Text = envio.ToString("0.00");
            }

            totalPed = (subtotal + envio) - anticipo;
            txtTotal.Text = "$" + totalPed.ToString("0.00");
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(ConexGlobal.cadena))
                {
                    conexion.Open();

                    string query = @"UPDATE Encargos SET Cliente = @cliente, Contacto = @contacto, TipoPedidoId = @tipo, DescripcionPersonalizada = @desc, PrecioFinal = @precioFinal, FechaEntrega = @fecha, OpcionEnvioId = @opcionEnvio, CostoEnvio = @costoEnvio, Subtotal = @subtotal, Anticipo = @anticipo WHERE Id = @id";

                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@cliente", txtNom.Text);
                        comando.Parameters.AddWithValue("@contacto", txtContacto.Text); 
                        comando.Parameters.AddWithValue("@tipo", cmbTipo.SelectedValue);
                        comando.Parameters.AddWithValue("@desc", txtDesc.Text);
                        comando.Parameters.AddWithValue("@precioFinal", totalPed);
                        comando.Parameters.AddWithValue("@fecha", dateTimePicker1.Value);
                        comando.Parameters.AddWithValue("@id", IdPedido);

                        decimal.TryParse(txtEnv.Text.Replace("$", ""), out decimal costoEnvio);
                        decimal.TryParse(txtSub.Text.Replace("$", ""), out decimal subtotal);
                        decimal.TryParse(txtAnt.Text.Replace("$", ""), out decimal anticipo);

                        comando.Parameters.AddWithValue("@opcionEnvio", cmbEnvio.SelectedValue ?? DBNull.Value);
                        comando.Parameters.AddWithValue("@costoEnvio", costoEnvio);
                        comando.Parameters.AddWithValue("@subtotal", subtotal);
                        comando.Parameters.AddWithValue("@anticipo", anticipo);

                        comando.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Pedido actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al guardar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSub_TextChanged(object sender, EventArgs e)
        {
            CalcularTotal();
        }

        private void txtAnt_TextChanged(object sender, EventArgs e)
        {
            CalcularTotal();
        }

        private void txtEnv_TextChanged(object sender, EventArgs e)
        {
            CalcularTotal();
        }

        private void txtNom_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

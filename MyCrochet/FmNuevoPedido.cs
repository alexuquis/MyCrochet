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
    public partial class FmNuevoPedido : Form
    {
        decimal totalPed = 0;
        public FmNuevoPedido()
        {
            InitializeComponent();

        }

        //Lib
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

        private void label8_Click(object sender, EventArgs e)
        {

        }
        //pa cargar los combobox
        private void CargarCombos()
        {
            using (SqlConnection conexion = new SqlConnection(ConexGlobal.cadena))
            {
                string queryTipo = "SELECT Id, Nombre FROM TipoPedidos";
                SqlDataAdapter adaptadorTipo = new SqlDataAdapter(queryTipo, conexion);
                DataTable dtTipos = new DataTable();
                adaptadorTipo.Fill(dtTipos);
                cmbNTipo.DataSource = dtTipos;
                cmbNTipo.DisplayMember = "Nombre";
                cmbNTipo.ValueMember = "Id";


                string queryEstado = "SELECT Id, Estado FROM Estados";
                SqlDataAdapter adaptadorEstado = new SqlDataAdapter(queryEstado, conexion);
                DataTable dtEstados = new DataTable();
                adaptadorEstado.Fill(dtEstados);
                cmbEstado.DataSource = dtEstados;
                cmbEstado.DisplayMember = "Estado";
                cmbEstado.ValueMember = "Id";

                string queryEnvio = "SELECT Id, Nombre FROM OpcionesEnvio";
                SqlDataAdapter adaptadorEnvio = new SqlDataAdapter(queryEnvio, conexion);
                DataTable dtEnvios = new DataTable();
                adaptadorEnvio.Fill(dtEnvios);
                cmbNEnvio.DataSource = dtEnvios;
                cmbNEnvio.DisplayMember = "Nombre";
                cmbNEnvio.ValueMember = "Id";
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            CalcularTotal();
        }
        private void CalcularTotal()
        {

            decimal.TryParse(txtSub.Text, out decimal subtotal);
            decimal.TryParse(txtEnv.Text, out decimal envio);
            decimal.TryParse(txtAnt.Text, out decimal anticipo);

            totalPed = (subtotal + envio) - anticipo;

            lblNTotal.Text = totalPed.ToString("0.00");
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void FmNuevoPedido_Load(object sender, EventArgs e)
        {
            CargarCombos();

            cmbNTipo.SelectedIndex = -1;
            cmbEstado.SelectedIndex = -1;
            cmbNEnvio.SelectedIndex = -1;

        }



        private void btnNPedido_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNNom.Text))
            {
                MessageBox.Show("Ingresa el nombre del cliente.", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string query = @"INSERT INTO Encargos (Cliente, Contacto, TipoPedidoId, DescripcionPersonalizada, Subtotal, CostoEnvio, PrecioFinal, Anticipo, FechaEntrega, EstadoId, OpcionEnvioId) 
         VALUES (@cliente, @contacto, @tipo, @desc, @subtotal, @envioCosto, @precio, @anticipo, @fecha, @estado, @envioOpcionId)";

            using (SqlConnection conexion = new SqlConnection(ConexGlobal.cadena))
            {
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@cliente", txtNNom.Text);
                    comando.Parameters.AddWithValue("@contacto", txtNContacto.Text);
                    comando.Parameters.AddWithValue("@tipo", Convert.ToInt32(cmbNTipo.SelectedValue));
                    comando.Parameters.AddWithValue("@desc", txtNDesc.Text);
                    comando.Parameters.AddWithValue("@fecha", datePed.Value);
                    comando.Parameters.AddWithValue("@estado", Convert.ToInt32(cmbEstado.SelectedValue));
                    comando.Parameters.AddWithValue("@envioOpcionId", Convert.ToInt32(cmbNEnvio.SelectedValue));

                    comando.Parameters.AddWithValue("@subtotal", Convert.ToDecimal(txtSub.Text));
                    comando.Parameters.AddWithValue("@envioCosto", Convert.ToDecimal(txtEnv.Text));
                    comando.Parameters.AddWithValue("@anticipo", Convert.ToDecimal(txtAnt.Text));

                    
                    comando.Parameters.AddWithValue("@precio", Convert.ToDecimal(lblNTotal.Text));

                    conexion.Open();
                    comando.ExecuteNonQuery();

                    MessageBox.Show("¡El pedido ha sido agregado!", "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Limpiartext();
                }
            }
        }

        private void cmbNTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //animaciones
            if (cmbNTipo.SelectedIndex == -1) return;

            string tipoSeleccionado = cmbNTipo.Text;

            switch (tipoSeleccionado)
            {
                case "Amigurumi":
                    picBox1.ImageLocation = @"C:\Users\DELL\source\repos\MyCrochet\MyCrochet\AnimacionesFinal\Personaje.gif";
                    picBox1.Visible = true;
                    break;

                case "Animal":
                    picBox1.ImageLocation = @"C:\Users\DELL\source\repos\MyCrochet\MyCrochet\AnimacionesFinal\Animal.gif";
                    picBox1.Visible = true;
                    break;

                case "Flores":
                    picBox1.ImageLocation = @"C:\Users\DELL\source\repos\MyCrochet\MyCrochet\AnimacionesFinal\Flor.gif";
                    picBox1.Visible = true;
                    break;

                default:
                    picBox1.ImageLocation = null;
                    picBox1.Visible = false;
                    break;
            }
        }

        private void Limpiartext()
        {
            txtNNom.Clear();
            txtNDesc.Clear();
            txtNContacto.Clear();
            txtSub.Text = "0";
            txtEnv.Text = "0";
            txtAnt.Text = "0";

            cmbNTipo.SelectedIndex = -1;
            cmbEstado.SelectedIndex = -1;
            cmbNEnvio.SelectedIndex = -1;

            datePed.Value = DateTime.Now;

            lblNTotal.Text = "0.00";

            picBox1.ImageLocation = null;
            picBox1.Visible = false;
        }
    }
}

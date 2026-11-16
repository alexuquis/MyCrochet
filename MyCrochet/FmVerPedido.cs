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
    public partial class FmVerPedido : Form
    {
        public int IdPedido = 0;
        public FmVerPedido(int id)
        {
            InitializeComponent();
            IdPedido = id;
        }


        // Función para mover la ventana
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();


        private void MoverVentana(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, 0xA1, 0x2, 0);
            }
        }
        /////

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void FmVerPedido_Load(object sender, EventArgs e)
        {
            if (IdPedido > 0)
            {
                try
                {
                    using (SqlConnection conexion = new SqlConnection(ConexGlobal.cadena))
                    {
                        conexion.Open();

                        string query = @"SELECT e.Cliente, e.Contacto, tp.Nombre AS TipoPedido,  e.DescripcionPersonalizada, e.PrecioFinal, e.FechaEntrega, 
                                        e.Subtotal, e.Anticipo, e.CostoEnvio, oe.Nombre AS NombreEnvio FROM Encargos e INNER JOIN TipoPedidos tp ON e.TipoPedidoId = tp.Id 
                                        LEFT JOIN OpcionesEnvio oe ON e.OpcionEnvioId = oe.Id  WHERE e.Id = @id";

                        using (SqlCommand cmd = new SqlCommand(query, conexion))
                        {
                            cmd.Parameters.AddWithValue("@id", IdPedido);
                            using (SqlDataReader lector = cmd.ExecuteReader())
                            {
                                if (lector.Read())
                                {
                                    txtNom.Text = lector["Cliente"].ToString();
                                    txtContacto.Text = lector["Contacto"].ToString();
                                    txtTipo.Text = lector["TipoPedido"].ToString();
                                    txtDesc.Text = lector["DescripcionPersonalizada"].ToString();

                                    txxFecha.Text = Convert.ToDateTime(lector["FechaEntrega"]).ToString("dd/MM/yyyy");

                                    txtSub.Text = lector["Subtotal"] != DBNull.Value ?
                                                  Convert.ToDecimal(lector["Subtotal"]).ToString("C2") : "$0.00";

                                    txtAnt.Text = lector["Anticipo"] != DBNull.Value ?
                                                  Convert.ToDecimal(lector["Anticipo"]).ToString("C2") : "$0.00";

                                    txtEnv.Text = lector["CostoEnvio"] != DBNull.Value ?
                                                       Convert.ToDecimal(lector["CostoEnvio"]).ToString("C2") : "$0.00";

                                    txtTotal.Text = Convert.ToDecimal(lector["PrecioFinal"]).ToString("C2");

                                    txtEnvio.Text = lector["NombreEnvio"] != DBNull.Value ?
                                                          lector["NombreEnvio"].ToString() : "No especificado";
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar el detalle del pedido: " + ex.Message, "Error de Lectura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

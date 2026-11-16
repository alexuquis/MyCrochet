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
    public partial class FmInicio : Form
    {
        public FmInicio()
        {
            InitializeComponent();
            Saludo();
            CargarPedidos();
            Alertas();

        }

        private void Saludo()
        {
            string saludo = "Bienvenido";
            if (ConexGlobal.GeneroUsuarioAct == "Femenino")
            {
                saludo = "Bienvenida";
            }

            label2.Text = saludo + ", " + ConexGlobal.NombreUsuarioAct + "!";
        }
        //transparencias
        private void FmInicio_Load(object sender, EventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private async void btnMinimizar_Click(object sender, EventArgs e)
        {
            for (double i = 1.0; i >= 0; i -= 0.1)
            {
                this.Opacity = i;
                await Task.Delay(10);
            }
            this.WindowState = FormWindowState.Minimized;
            this.Opacity = 1.0;
        }

        private void CargarPedidos()
        {
            DataTable tablaPedidos = new DataTable();
            List<DateTime> fechasPendientes = new List<DateTime>();

            //Consultar pedidos existentes
            string query = @"SELECT  E.Cliente, TP.Nombre AS 'Tipo de Pedido', E.FechaEntrega AS 'Fecha' FROM Encargos E
                     INNER JOIN TipoPedidos TP ON E.TipoPedidoId = TP.Id  WHERE E.EstadoId = 1  ORDER BY E.FechaEntrega ASC";

            using (SqlConnection conexion = new SqlConnection(ConexGlobal.cadena))
            {
                using (SqlDataAdapter adaptador = new SqlDataAdapter(query, conexion))
                {

                    adaptador.Fill(tablaPedidos);
                }
            }

            dataGridView1.DataSource = tablaPedidos;

            foreach (DataRow fila in tablaPedidos.Rows)
            {

                if (fila["Fecha"] != DBNull.Value)
                {
                    fechasPendientes.Add(Convert.ToDateTime(fila["Fecha"]));
                }
            }
            //mostras fechas con pedidos existentes en el calendario
            monthCalendar1.BoldedDates = fechasPendientes.ToArray();
            monthCalendar1.UpdateBoldedDates();

            dataGridView1.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy";
            DisenoPedidos();
        }


        //Alertas de Inventario
        private void Alertas()
        {
            flowLayoutPanel1.Controls.Clear();
            //Mostrar material con menos de 2 existencias
            string query = @"SELECT Marca, Tamaño, Color, Inventario FROM Articulos WHERE Inventario <= 2";

            using (SqlConnection conexion = new SqlConnection(ConexGlobal.cadena))
            {
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    conexion.Open();

                    using (SqlDataReader lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            string marca = lector["Marca"] != DBNull.Value ? lector["Marca"].ToString() : "Sin marca";
                            string tamano = lector["Tamaño"].ToString();
                            string color = lector["Color"].ToString();
                            string cantidad = lector["Inventario"].ToString();

                            //alertita visual
                            Label lblAlerta = new Label();
                            lblAlerta.Text = $" {marca} - {color}\nTamaño: {tamano} | Quedan: {cantidad}";

                            lblAlerta.AutoSize = false;
                            lblAlerta.Width = flowLayoutPanel1.Width - 25;
                            lblAlerta.Height = 55;
                            lblAlerta.BackColor = ColorTranslator.FromHtml("#FEA9BE");
                            lblAlerta.ForeColor = ColorTranslator.FromHtml("#861940");
                            lblAlerta.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                            lblAlerta.TextAlign = ContentAlignment.MiddleLeft;
                            lblAlerta.Padding = new Padding(10, 0, 0, 0);
                            lblAlerta.Margin = new Padding(5);

                            flowLayoutPanel1.Controls.Add(lblAlerta);
                        }
                    }
                }
            }

            //por si no hay alertas
            if (flowLayoutPanel1.Controls.Count == 0)
            {
                Label lblOk = new Label();
                lblOk.Text = "No hay alertas";
                lblOk.AutoSize = false;
                lblOk.Width = flowLayoutPanel1.Width - 25;
                lblOk.Height = 50;
                lblOk.TextAlign = ContentAlignment.MiddleCenter;
                lblOk.ForeColor = Color.Gray;
                lblOk.Font = new Font("Segoe UI", 10, FontStyle.Italic);
                flowLayoutPanel1.Controls.Add(lblOk);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void btnlogo_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void FmInicio_Load_1(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }



        private void FmInicio_Shown_1(object sender, EventArgs e)
        {
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

        private void btnNuevoPed_Click(object sender, EventArgs e)
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

        private void button6_Click(object sender, EventArgs e)
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DisenoPedidos()
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
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FFF0F5");

            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.GridColor = ColorTranslator.FromHtml("#FEA9BE");

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;
        }

        private void FmInicio_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                CargarPedidos();
                Alertas
                    ();
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

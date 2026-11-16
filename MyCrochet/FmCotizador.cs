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
    public partial class FmCotizador : Form
    {
        SqlConnection conexion = new SqlConnection(ConexGlobal.cadena); //conex sql

        decimal totalMat = 0;
        decimal totalObra = 0;
        public FmCotizador()
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

        private void CalManoObra()
        {
            decimal.TryParse(txtPrecioH.Text, out decimal costo);
            decimal.TryParse(txtCantH.Text, out decimal horas);
            totalObra = costo * horas;

            lblTotalObra.Text = "$" + totalObra.ToString("0.00");

            CalcularTotalFinal();

        }
        private void txtPrecioH_TextChanged(object sender, EventArgs e)
        {
            CalManoObra();
        }

        private void txtCantH_TextChanged(object sender, EventArgs e)
        {
            CalManoObra();
        }


        private void CargarMat()
        {
            string query = @"SELECT MIN(A.Id) AS Id, A.Marca + ' - ' + A.Tamaño AS NombreMaterial,A.Precio, C.Categoria 
                     FROM Articulos A INNER JOIN Categorias C ON A.CategoriaId = C.Id GROUP BY A.Marca, A.Tamaño, A.Precio, C.Categoria";

            SqlDataAdapter adaptador = new SqlDataAdapter(query, ConexGlobal.cadena);
            DataTable tablaMateriales = new DataTable();
            adaptador.Fill(tablaMateriales);

            cmbMateriales.DataSource = tablaMateriales;
            cmbMateriales.DisplayMember = "NombreMaterial";
            cmbMateriales.ValueMember = "Precio";

        }


        private void btnAgMaterial_Click(object sender, EventArgs e)
        {
            decimal precioBase = Convert.ToDecimal(cmbMateriales.SelectedValue);
            decimal.TryParse(txtCantM.Text, out decimal cantidad);

            decimal subtotal = 0;


            DataRowView filaSeleccionada = (DataRowView)cmbMateriales.SelectedItem;
            string categoria = filaSeleccionada["Categoria"].ToString().ToLower();

            if (categoria == "Estambre")
            {
                subtotal = (precioBase / 100m) * cantidad;
            }
            else
            {
                subtotal = precioBase * cantidad;
            }

            totalMat += subtotal;
            listBox1.Items.Add(cantidad + " x " + cmbMateriales.Text + " - $" + subtotal.ToString("0.00"));
            lblMat.Text = "$" + totalMat.ToString("0.00");
            CalcularTotalFinal();

        }

        private void CalcularTotalFinal()
        {
            decimal subtotal = totalObra + totalMat;
            lblSub.Text = "$" + subtotal.ToString("0.00");

            decimal.TryParse(txtGanancia.Text, out decimal gananciaPorcentaje);

            decimal dineroGanancia = subtotal * (gananciaPorcentaje / 100m);
            decimal granTotal = subtotal + dineroGanancia;

            lblTotal.Text = "$" + granTotal.ToString("0.00");
        }

        private void txtGanancia_TextChanged(object sender, EventArgs e)
        {
            CalcularTotalFinal();
        }

        private void FmCotizador_Load(object sender, EventArgs e)
        {
            CargarMat();
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form Ventanainicio = Application.OpenForms["FmInicio"];

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
            Form Ventanapedidos = Application.OpenForms["FmPedidos"];

            if (Ventanapedidos == null)
            {
                Ventanapedidos = new FmInventario();
                Ventanapedidos.Show();
            }
            else
            {
                Ventanapedidos.Show();
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

        private void btnConfig_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form Ventanaconfig = Application.OpenForms["FmConfiguracion"];

            if (Ventanaconfig == null)
            {
                Ventanaconfig = new FmConfiguracion();
                Ventanaconfig.Show();
            }
            else
            {
                Ventanaconfig.Show();
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

        private void listBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int index = listBox1.IndexFromPoint(e.Location);
                if (index != ListBox.NoMatches)
                {
                    listBox1.SelectedIndex = index;
                }
            }
        }

        private void eliminarMaterialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            { 
                string textoItem = listBox1.SelectedItem.ToString();
                string[] partes = textoItem.Split('$');

               
                if (partes.Length > 1)
                {
                    decimal.TryParse(partes[1].Trim(), out decimal precioRestar);
                    totalMat -= precioRestar;
                    if (totalMat < 0) totalMat = 0;

                    lblMat.Text = "$" + totalMat.ToString("0.00");
                    listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                    CalcularTotalFinal();
                }
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

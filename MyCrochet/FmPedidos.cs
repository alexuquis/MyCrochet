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
    public partial class FmPedidos : Form
    {
        public FmPedidos()
        {
            InitializeComponent();
        }


        private void dataGridViewPedidos_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dataGridViewPedidos.CurrentCell = dataGridViewPedidos.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
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

        private void FmPedidos_Load(object sender, EventArgs e)
        {
            Pedidos();
            Combos();
            disenoPedidos();
            eliminarPedido.Visible = (ConexGlobal.RolUsuarioAct == 1);
        }
        //Mostrar pedidos ya existentes
        private void Pedidos(string filtro = "", int? tipo = null, int? estado = null)
        {
            string query = @"SELECT e.Id, e.Cliente, tp.Nombre AS TipoPedido,es.Estado, e.FechaEntrega FROM Encargos e
                            INNER JOIN TipoPedidos tp ON e.TipoPedidoId = tp.Id INNER JOIN Estados es ON e.EstadoId = es.Id
                          WHERE (e.Cliente LIKE '%' + @filtro + '%' OR CAST(e.Id AS NVARCHAR) LIKE '%' + @filtro + '%'
                           OR @filtro = '') AND (e.TipoPedidoId = @tipo OR @tipo IS NULL)AND (e.EstadoId = @estado OR @estado IS NULL)";

            SqlDataAdapter da = new SqlDataAdapter(query, ConexGlobal.cadena);
            da.SelectCommand.Parameters.AddWithValue("@filtro", filtro);
            da.SelectCommand.Parameters.AddWithValue("@tipo", (object)tipo ?? DBNull.Value);
            da.SelectCommand.Parameters.AddWithValue("@estado", (object)estado ?? DBNull.Value);

            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridViewPedidos.DataSource = dt;
        }


        private void Combos()
        {
            // tipo
            SqlDataAdapter daTipo = new SqlDataAdapter("SELECT Id, Nombre FROM TipoPedidos", ConexGlobal.cadena);
            DataTable dtTipo = new DataTable();
            daTipo.Fill(dtTipo);
            DataRow filaTipo = dtTipo.NewRow();
            filaTipo["Id"] = 0;
            filaTipo["Nombre"] = "Todos";
            dtTipo.Rows.InsertAt(filaTipo, 0);

            cmbTipoFiltro.DataSource = dtTipo;
            cmbTipoFiltro.DisplayMember = "Nombre";
            cmbTipoFiltro.ValueMember = "Id";
            cmbTipoFiltro.SelectedIndex = 0;


            // Estado
            SqlDataAdapter daEstado = new SqlDataAdapter("SELECT Id, Estado FROM Estados", ConexGlobal.cadena);
            DataTable dtEstado = new DataTable();
            daEstado.Fill(dtEstado);
            DataRow filaEstado = dtEstado.NewRow();
            filaEstado["Id"] = 0;
            filaEstado["Estado"] = "Todos";
            dtEstado.Rows.InsertAt(filaEstado, 0);

            cmbEstadoFiltro.DataSource = dtEstado;
            cmbEstadoFiltro.DisplayMember = "Estado";
            cmbEstadoFiltro.ValueMember = "Id";
            cmbEstadoFiltro.SelectedIndex = 0;
        }

        private void Filtrar()
        {
            string texto = txtBusc.Text;

            int? tipo = null;
            int? estado = null;

            if (cmbTipoFiltro.SelectedValue is int tipoVal && tipoVal != 0)
                tipo = tipoVal;

            if (cmbEstadoFiltro.SelectedValue is int estadoVal && estadoVal != 0)
                estado = estadoVal;

            Pedidos(texto, tipo, estado);
        }


        private void txtBusc_TextChanged(object sender, EventArgs e)
        {
            Filtrar();
        }

        private void cmbTipoFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filtrar();
        }

        private void cmbEstadoFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filtrar();
        }


        private void disenoPedidos()
        {
            dataGridViewPedidos.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dataGridViewPedidos.DefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#861940");
            dataGridViewPedidos.DefaultCellStyle.BackColor = Color.White;

            dataGridViewPedidos.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#FEA9BE");
            dataGridViewPedidos.DefaultCellStyle.SelectionForeColor = ColorTranslator.FromHtml("#861940");

            dataGridViewPedidos.EnableHeadersVisualStyles = false;
            dataGridViewPedidos.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#861940");
            dataGridViewPedidos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewPedidos.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dataGridViewPedidos.ColumnHeadersHeight = 35;

            dataGridViewPedidos.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FFF0F5");

            dataGridViewPedidos.BackgroundColor = Color.White;
            dataGridViewPedidos.BorderStyle = BorderStyle.None;
            dataGridViewPedidos.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewPedidos.GridColor = ColorTranslator.FromHtml("#FEA9BE");

            dataGridViewPedidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewPedidos.RowHeadersVisible = false;
            dataGridViewPedidos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewPedidos.AllowUserToAddRows = false;

            if (dataGridViewPedidos.Columns.Contains("FechaEntrega"))
            {
                dataGridViewPedidos.Columns["FechaEntrega"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
        }

        private void btnNuevoPed_Click(object sender, EventArgs e)
        {
            FmNuevoPedido ventanaNuevo = new FmNuevoPedido();
            ventanaNuevo.ShowDialog();
            Pedidos();
        }

        private void dataGridViewPedidos_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            //click derecho
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dataGridViewPedidos.ClearSelection();
                dataGridViewPedidos.Rows[e.RowIndex].Selected = true;
                dataGridViewPedidos.CurrentCell = dataGridViewPedidos.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }

        private void VerPedido_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridViewPedidos.CurrentRow.Cells["Id"].Value);
            FmVerPedido ventanaVer = new FmVerPedido(id);
            ventanaVer.ShowDialog();
        }

        private void eliminarPedido_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridViewPedidos.CurrentRow.Cells["Id"].Value);

            DialogResult respuesta = MessageBox.Show("Deseas eliminar este pedido?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (respuesta == DialogResult.Yes)
            {
                string query = "DELETE FROM Encargos WHERE Id = @id";
                using (SqlConnection conexion = new SqlConnection(ConexGlobal.cadena))
                {
                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@id", id);
                        conexion.Open();
                        comando.ExecuteNonQuery();
                    }
                }
                Pedidos();
            }

        }

        private void ModificarPedido_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridViewPedidos.CurrentRow.Cells["Id"].Value);
            FmEditarPedido ventanaEditar = new FmEditarPedido(id);
            ventanaEditar.ShowDialog();
            Pedidos();
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
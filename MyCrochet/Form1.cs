using System.Data;
using System.Data.SqlClient;
namespace MyCrochet

{
    public partial class Login : Form
    {
        SqlConnection conexion = new SqlConnection(ConexGlobal.cadena); //conex sql
        public Login()
        {
            InitializeComponent();

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


        private void Login_Load(object sender, EventArgs e)
        {
            // transparencia
            panel3.Parent = pictureBox5;
            panel3.BackColor = Color.Transparent;


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {   
            //Verificar Usuario
            using (SqlConnection conexion = new SqlConnection(ConexGlobal.cadena))
            {
                string query = @"SELECT U.Nombre, U.RolesId, G.Genero  FROM Usuarios U INNER JOIN Generos G ON U.GeneroId = G.Id 
                         WHERE U.Nombre = @nombre AND U.Contraseña = @contrasena";

                using (SqlCommand comando = new SqlCommand(query, conexion))
                {   
                    //comprobar Usuario y contraseña
                    comando.Parameters.AddWithValue("@nombre", txtUsuario.Text);
                    comando.Parameters.AddWithValue("@contrasena", txtPassword.Text);

                    conexion.Open();

                    using (SqlDataReader lector = comando.ExecuteReader())
                    {
                        if (lector.Read())
                        {
                            //variables globales
                            ConexGlobal.NombreUsuarioAct = lector["Nombre"].ToString();
                            ConexGlobal.RolUsuarioAct = Convert.ToInt32(lector["RolesId"]);
                            ConexGlobal.GeneroUsuarioAct = lector["Genero"].ToString();

                            this.Hide();
                            FmInicio pantallaInicio = new FmInicio();
                            pantallaInicio.Show();
                        }
                        else
                        {
                            label3.Visible = true;
                            txtUsuario.Clear();
                            txtPassword.Clear();
                        }
                    }
                }
            }
        }

        private void btnprobarconexion_Click(object sender, EventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }




        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Activa el WS_EX_COMPOSITED
                return cp;
            }
        }
    }
}

namespace MyCrochet
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing || components != null)
            {
            }
            else
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            panel1 = new Panel();
            btnMinimizar = new Button();
            btnCerrar = new Button();
            pictureBox5 = new PictureBox();
            panel3 = new Panel();
            txtUsuario = new TextBox();
            label3 = new Label();
            txtPassword = new TextBox();
            pictureBox1 = new PictureBox();
            label2 = new Label();
            label1 = new Label();
            btnEntrar = new Button();
            pictureBox3 = new PictureBox();
            pictureBox4 = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(254, 169, 190);
            panel1.Controls.Add(btnMinimizar);
            panel1.Controls.Add(btnCerrar);
            panel1.Location = new Point(-13, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(573, 29);
            panel1.TabIndex = 1;
            panel1.Paint += panel1_Paint;
            panel1.MouseDown += MoverVentana;
            // 
            // btnMinimizar
            // 
            btnMinimizar.BackColor = Color.Transparent;
            btnMinimizar.BackgroundImage = (Image)resources.GetObject("btnMinimizar.BackgroundImage");
            btnMinimizar.BackgroundImageLayout = ImageLayout.Zoom;
            btnMinimizar.Location = new Point(481, 3);
            btnMinimizar.Name = "btnMinimizar";
            btnMinimizar.Size = new Size(28, 23);
            btnMinimizar.TabIndex = 1;
            btnMinimizar.UseVisualStyleBackColor = false;
            btnMinimizar.Click += btnMinimizar_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.BackColor = Color.Transparent;
            btnCerrar.BackgroundImage = (Image)resources.GetObject("btnCerrar.BackgroundImage");
            btnCerrar.BackgroundImageLayout = ImageLayout.Zoom;
            btnCerrar.FlatAppearance.BorderColor = Color.FromArgb(134, 25, 64);
            btnCerrar.FlatAppearance.MouseDownBackColor = Color.FromArgb(134, 25, 64);
            btnCerrar.FlatAppearance.MouseOverBackColor = Color.FromArgb(134, 25, 64);
            btnCerrar.Location = new Point(515, 3);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(26, 23);
            btnCerrar.TabIndex = 0;
            btnCerrar.UseVisualStyleBackColor = false;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // pictureBox5
            // 
            pictureBox5.BackgroundImage = (Image)resources.GetObject("pictureBox5.BackgroundImage");
            pictureBox5.Image = (Image)resources.GetObject("pictureBox5.Image");
            pictureBox5.Location = new Point(-5, 22);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(550, 466);
            pictureBox5.TabIndex = 3;
            pictureBox5.TabStop = false;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Transparent;
            panel3.BackgroundImage = (Image)resources.GetObject("panel3.BackgroundImage");
            panel3.BackgroundImageLayout = ImageLayout.Stretch;
            panel3.Controls.Add(txtUsuario);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(txtPassword);
            panel3.Controls.Add(pictureBox1);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(label1);
            panel3.Controls.Add(btnEntrar);
            panel3.Controls.Add(pictureBox3);
            panel3.Controls.Add(pictureBox4);
            panel3.Location = new Point(86, 44);
            panel3.Name = "panel3";
            panel3.Size = new Size(374, 401);
            panel3.TabIndex = 4;
            // 
            // txtUsuario
            // 
            txtUsuario.BackColor = Color.FromArgb(254, 169, 190);
            txtUsuario.BorderStyle = BorderStyle.None;
            txtUsuario.Font = new Font("KG Red Hands", 12.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUsuario.ForeColor = SystemColors.Window;
            txtUsuario.Location = new Point(101, 198);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(195, 23);
            txtUsuario.TabIndex = 15;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Constantia", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.DarkRed;
            label3.Location = new Point(97, 307);
            label3.Name = "label3";
            label3.Size = new Size(180, 14);
            label3.TabIndex = 14;
            label3.Text = "Usuario o contraseña incorrectos";
            label3.Visible = false;
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.FromArgb(254, 169, 190);
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.Font = new Font("Comfortaa", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.ForeColor = SystemColors.Window;
            txtPassword.Location = new Point(101, 276);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(195, 14);
            txtPassword.TabIndex = 1;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(53, 189);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(270, 41);
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click_1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Good Bakwan", 12.7499981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(134, 25, 64);
            label2.Location = new Point(53, 239);
            label2.Name = "label2";
            label2.Size = new Size(175, 21);
            label2.TabIndex = 7;
            label2.Text = "Ingrese la Contraseña:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Good Bakwan", 12.7499981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(134, 25, 64);
            label1.Location = new Point(53, 165);
            label1.Name = "label1";
            label1.Size = new Size(150, 21);
            label1.TabIndex = 6;
            label1.Text = "Ingrese su Usuario:";
            // 
            // btnEntrar
            // 
            btnEntrar.BackgroundImage = (Image)resources.GetObject("btnEntrar.BackgroundImage");
            btnEntrar.BackgroundImageLayout = ImageLayout.Stretch;
            btnEntrar.FlatAppearance.BorderSize = 0;
            btnEntrar.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 247, 248);
            btnEntrar.FlatStyle = FlatStyle.Flat;
            btnEntrar.Font = new Font("Good Bakwan", 15.7499981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnEntrar.ForeColor = Color.FromArgb(255, 247, 248);
            btnEntrar.Location = new Point(101, 330);
            btnEntrar.Name = "btnEntrar";
            btnEntrar.Size = new Size(173, 41);
            btnEntrar.TabIndex = 2;
            btnEntrar.Text = "Iniciar Sesión";
            btnEntrar.UseVisualStyleBackColor = true;
            btnEntrar.Click += btnEntrar_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.BackgroundImage = (Image)resources.GetObject("pictureBox3.BackgroundImage");
            pictureBox3.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox3.Location = new Point(53, 263);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(270, 41);
            pictureBox3.TabIndex = 2;
            pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.BackgroundImage = (Image)resources.GetObject("pictureBox4.BackgroundImage");
            pictureBox4.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox4.Location = new Point(72, 13);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(224, 149);
            pictureBox4.TabIndex = 5;
            pictureBox4.TabStop = false;
            // 
            // Login
            // 
            AcceptButton = btnEntrar;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 224, 224);
            ClientSize = new Size(546, 489);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Controls.Add(pictureBox5);
            Cursor = Cursors.Hand;
            FormBorderStyle = FormBorderStyle.None;
            Name = "Login";
            Text = "MyCrochet-Inicio";
            Load += Login_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnMinimizar;
        private Button btnCerrar;
        private PictureBox pictureBox5;
        private Panel panel3;
        private PictureBox pictureBox3;
        private Button btnEntrar;
        private PictureBox pictureBox4;
        private Label label1;
        private Label label2;
        private PictureBox pictureBox1;
        private TextBox txtPassword;
        private Label label3;
        private TextBox txtUsuario;
    }
}

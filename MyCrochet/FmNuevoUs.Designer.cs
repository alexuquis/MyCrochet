namespace MyCrochet
{
    partial class FmNuevoUs
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FmNuevoUs));
            label6 = new Label();
            label3 = new Label();
            panel1 = new Panel();
            btnCerrar = new Button();
            txtUsuario = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label5 = new Label();
            label7 = new Label();
            btnEntrar = new Button();
            txtpassword = new TextBox();
            cmbGenero = new ComboBox();
            cmbRol = new ComboBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Super Mindset", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.FromArgb(134, 25, 64);
            label6.Location = new Point(91, 51);
            label6.Name = "label6";
            label6.Size = new Size(188, 30);
            label6.TabIndex = 17;
            label6.Text = "Agregar Perfil";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.FromArgb(254, 169, 190);
            label3.Font = new Font("Segoe UI", 2.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(134, 25, 64);
            label3.Location = new Point(-3, 34);
            label3.Margin = new Padding(1, 0, 3, 0);
            label3.Name = "label3";
            label3.Size = new Size(377, 4);
            label3.TabIndex = 20;
            label3.Text = resources.GetString("label3.Text");
            // 
            // panel1
            // 
            panel1.Controls.Add(btnCerrar);
            panel1.Location = new Point(-3, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(381, 33);
            panel1.TabIndex = 56;
            panel1.MouseDown += MoverVentana;
            // 
            // btnCerrar
            // 
            btnCerrar.BackColor = Color.Transparent;
            btnCerrar.BackgroundImage = (Image)resources.GetObject("btnCerrar.BackgroundImage");
            btnCerrar.BackgroundImageLayout = ImageLayout.Zoom;
            btnCerrar.FlatAppearance.BorderColor = Color.FromArgb(134, 25, 64);
            btnCerrar.FlatAppearance.MouseDownBackColor = Color.FromArgb(134, 25, 64);
            btnCerrar.FlatAppearance.MouseOverBackColor = Color.FromArgb(134, 25, 64);
            btnCerrar.Location = new Point(336, 8);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(26, 22);
            btnCerrar.TabIndex = 52;
            btnCerrar.UseVisualStyleBackColor = false;
            btnCerrar.Click += button2_Click;
            // 
            // txtUsuario
            // 
            txtUsuario.BorderStyle = BorderStyle.None;
            txtUsuario.Font = new Font("KG Red Hands", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUsuario.ForeColor = SystemColors.ActiveCaptionText;
            txtUsuario.Location = new Point(21, 120);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(149, 16);
            txtUsuario.TabIndex = 57;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("KG Red Hands", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(134, 25, 64);
            label1.Location = new Point(198, 98);
            label1.Name = "label1";
            label1.Size = new Size(65, 19);
            label1.TabIndex = 59;
            label1.Text = "Género:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("KG Red Hands", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(134, 25, 64);
            label2.Location = new Point(21, 98);
            label2.Name = "label2";
            label2.Size = new Size(66, 19);
            label2.TabIndex = 60;
            label2.Text = "Usuario:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("KG Red Hands", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(134, 25, 64);
            label5.Location = new Point(198, 148);
            label5.Name = "label5";
            label5.Size = new Size(95, 19);
            label5.TabIndex = 61;
            label5.Text = "Contraseña:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("KG Red Hands", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.FromArgb(134, 25, 64);
            label7.Location = new Point(21, 148);
            label7.Name = "label7";
            label7.Size = new Size(34, 19);
            label7.TabIndex = 62;
            label7.Text = "Rol:";
            // 
            // btnEntrar
            // 
            btnEntrar.BackgroundImage = (Image)resources.GetObject("btnEntrar.BackgroundImage");
            btnEntrar.BackgroundImageLayout = ImageLayout.Stretch;
            btnEntrar.FlatAppearance.BorderSize = 0;
            btnEntrar.FlatAppearance.MouseOverBackColor = Color.FromArgb(251, 233, 233);
            btnEntrar.FlatStyle = FlatStyle.Flat;
            btnEntrar.Font = new Font("KG Red Hands", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnEntrar.ForeColor = Color.FromArgb(134, 25, 64);
            btnEntrar.Location = new Point(109, 209);
            btnEntrar.Name = "btnEntrar";
            btnEntrar.Size = new Size(152, 33);
            btnEntrar.TabIndex = 63;
            btnEntrar.Text = "Agregar Perfil";
            btnEntrar.UseVisualStyleBackColor = true;
            btnEntrar.Click += btnEntrar_Click;
            // 
            // txtpassword
            // 
            txtpassword.BorderStyle = BorderStyle.None;
            txtpassword.Font = new Font("KG Red Hands", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtpassword.ForeColor = SystemColors.ActiveCaptionText;
            txtpassword.Location = new Point(198, 170);
            txtpassword.Name = "txtpassword";
            txtpassword.Size = new Size(149, 16);
            txtpassword.TabIndex = 65;
            // 
            // cmbGenero
            // 
            cmbGenero.BackColor = Color.FromArgb(255, 247, 248);
            cmbGenero.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGenero.Font = new Font("KG Red Hands", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbGenero.FormattingEnabled = true;
            cmbGenero.Location = new Point(198, 117);
            cmbGenero.Name = "cmbGenero";
            cmbGenero.Size = new Size(149, 24);
            cmbGenero.TabIndex = 67;
            // 
            // cmbRol
            // 
            cmbRol.BackColor = Color.FromArgb(255, 247, 248);
            cmbRol.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRol.Font = new Font("KG Red Hands", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbRol.FormattingEnabled = true;
            cmbRol.Location = new Point(21, 167);
            cmbRol.Name = "cmbRol";
            cmbRol.Size = new Size(149, 24);
            cmbRol.TabIndex = 68;
            // 
            // FmNuevoUs
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(251, 233, 233);
            ClientSize = new Size(371, 258);
            Controls.Add(cmbRol);
            Controls.Add(cmbGenero);
            Controls.Add(txtpassword);
            Controls.Add(btnEntrar);
            Controls.Add(label7);
            Controls.Add(label5);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtUsuario);
            Controls.Add(panel1);
            Controls.Add(label3);
            Controls.Add(label6);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            Name = "FmNuevoUs";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FmNuevoUs";
            Load += FmNuevoUs_Load;
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label6;
        private Label label3;
        private Panel panel1;
        private Button btnCerrar;
        private TextBox txtUsuario;
        private Label label1;
        private Label label2;
        private Label label5;
        private Label label7;
        private Button btnEntrar;
        private TextBox txtpassword;
        private ComboBox cmbGenero;
        private ComboBox cmbRol;
    }
}
namespace MyCrochet
{
    partial class FmEditarPedido
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FmEditarPedido));
            btnGuardar = new Button();
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label5 = new Label();
            label2 = new Label();
            label4 = new Label();
            txtContacto = new TextBox();
            txtNom = new TextBox();
            dateTimePicker1 = new DateTimePicker();
            panel1 = new Panel();
            btnCerrar = new Button();
            cmbEnvio = new ComboBox();
            txtAnt = new TextBox();
            txtSub = new TextBox();
            txtEnv = new TextBox();
            txtDesc = new TextBox();
            label3 = new Label();
            label1 = new Label();
            txtTotal = new TextBox();
            cmbTipo = new ComboBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnGuardar
            // 
            btnGuardar.BackgroundImage = (Image)resources.GetObject("btnGuardar.BackgroundImage");
            btnGuardar.BackgroundImageLayout = ImageLayout.Stretch;
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatAppearance.MouseOverBackColor = Color.FromArgb(251, 233, 233);
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("KG Red Hands", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnGuardar.ForeColor = Color.FromArgb(134, 25, 64);
            btnGuardar.Location = new Point(210, 453);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(170, 38);
            btnGuardar.TabIndex = 56;
            btnGuardar.Text = "Guardar cambios";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.BackColor = Color.Transparent;
            label12.Font = new Font("KG Red Hands", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.ForeColor = Color.FromArgb(134, 25, 64);
            label12.Location = new Point(218, 401);
            label12.Name = "label12";
            label12.Size = new Size(120, 19);
            label12.TabIndex = 55;
            label12.Text = "Costo de envio:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.Transparent;
            label11.Font = new Font("KG Red Hands", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.ForeColor = Color.FromArgb(134, 25, 64);
            label11.Location = new Point(218, 345);
            label11.Name = "label11";
            label11.Size = new Size(128, 19);
            label11.TabIndex = 54;
            label11.Text = "Opción de envio:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.Transparent;
            label10.Font = new Font("KG Red Hands", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.ForeColor = Color.FromArgb(134, 25, 64);
            label10.Location = new Point(24, 401);
            label10.Name = "label10";
            label10.Size = new Size(70, 19);
            label10.TabIndex = 53;
            label10.Text = "Anticipo:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("KG Red Hands", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.FromArgb(134, 25, 64);
            label9.Location = new Point(24, 345);
            label9.Name = "label9";
            label9.Size = new Size(71, 19);
            label9.TabIndex = 52;
            label9.Text = "Subtotal:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("KG Red Hands", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.FromArgb(134, 25, 64);
            label8.Location = new Point(145, 178);
            label8.Name = "label8";
            label8.Size = new Size(115, 22);
            label8.TabIndex = 51;
            label8.Text = "Descripción:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("KG Red Hands", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.FromArgb(134, 25, 64);
            label7.Location = new Point(218, 109);
            label7.Name = "label7";
            label7.Size = new Size(140, 19);
            label7.TabIndex = 50;
            label7.Text = "Fecha de Entrega:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("KG Red Hands", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(134, 25, 64);
            label5.Location = new Point(24, 109);
            label5.Name = "label5";
            label5.Size = new Size(117, 19);
            label5.TabIndex = 49;
            label5.Text = "Tipo de Pedido:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("KG Red Hands", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(134, 25, 64);
            label2.Location = new Point(218, 61);
            label2.Name = "label2";
            label2.Size = new Size(121, 19);
            label2.TabIndex = 48;
            label2.Text = "Num/Red social:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("KG Red Hands", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(134, 25, 64);
            label4.Location = new Point(24, 61);
            label4.Name = "label4";
            label4.Size = new Size(149, 19);
            label4.TabIndex = 47;
            label4.Text = "Nombre del Cliente:";
            // 
            // txtContacto
            // 
            txtContacto.BorderStyle = BorderStyle.None;
            txtContacto.Font = new Font("KG Red Hands", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtContacto.ForeColor = SystemColors.ActiveCaptionText;
            txtContacto.Location = new Point(218, 83);
            txtContacto.Name = "txtContacto";
            txtContacto.Size = new Size(162, 16);
            txtContacto.TabIndex = 42;
            // 
            // txtNom
            // 
            txtNom.BorderStyle = BorderStyle.None;
            txtNom.Font = new Font("KG Red Hands", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNom.ForeColor = SystemColors.ActiveCaptionText;
            txtNom.Location = new Point(24, 83);
            txtNom.Name = "txtNom";
            txtNom.Size = new Size(161, 16);
            txtNom.TabIndex = 41;
            txtNom.TextChanged += txtNom_TextChanged;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CalendarMonthBackground = Color.FromArgb(251, 233, 233);
            dateTimePicker1.Cursor = Cursors.Hand;
            dateTimePicker1.Font = new Font("Leelawadee UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(218, 131);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.RightToLeft = RightToLeft.No;
            dateTimePicker1.Size = new Size(162, 23);
            dateTimePicker1.TabIndex = 39;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnCerrar);
            panel1.Location = new Point(-5, 8);
            panel1.Name = "panel1";
            panel1.Size = new Size(421, 33);
            panel1.TabIndex = 35;
            // 
            // btnCerrar
            // 
            btnCerrar.BackColor = Color.Transparent;
            btnCerrar.BackgroundImage = (Image)resources.GetObject("btnCerrar.BackgroundImage");
            btnCerrar.BackgroundImageLayout = ImageLayout.Zoom;
            btnCerrar.FlatAppearance.BorderColor = Color.FromArgb(134, 25, 64);
            btnCerrar.FlatAppearance.MouseDownBackColor = Color.FromArgb(134, 25, 64);
            btnCerrar.FlatAppearance.MouseOverBackColor = Color.FromArgb(134, 25, 64);
            btnCerrar.Location = new Point(369, 8);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(26, 22);
            btnCerrar.TabIndex = 2;
            btnCerrar.UseVisualStyleBackColor = false;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // cmbEnvio
            // 
            cmbEnvio.BackColor = Color.FromArgb(255, 247, 248);
            cmbEnvio.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEnvio.Font = new Font("KG Red Hands", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbEnvio.FormattingEnabled = true;
            cmbEnvio.Items.AddRange(new object[] { "Entrega Personal", "Estafeta", "DHL", "Ninguna" });
            cmbEnvio.Location = new Point(218, 371);
            cmbEnvio.Name = "cmbEnvio";
            cmbEnvio.Size = new Size(162, 24);
            cmbEnvio.TabIndex = 43;
            // 
            // txtAnt
            // 
            txtAnt.BorderStyle = BorderStyle.None;
            txtAnt.Font = new Font("KG Red Hands", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtAnt.Location = new Point(24, 423);
            txtAnt.Name = "txtAnt";
            txtAnt.Size = new Size(161, 16);
            txtAnt.TabIndex = 46;
            txtAnt.TextChanged += txtAnt_TextChanged;
            // 
            // txtSub
            // 
            txtSub.BorderStyle = BorderStyle.None;
            txtSub.Font = new Font("KG Red Hands", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSub.Location = new Point(24, 371);
            txtSub.Name = "txtSub";
            txtSub.Size = new Size(161, 16);
            txtSub.TabIndex = 45;
            txtSub.TextChanged += txtSub_TextChanged;
            // 
            // txtEnv
            // 
            txtEnv.BackColor = SystemColors.Window;
            txtEnv.BorderStyle = BorderStyle.None;
            txtEnv.Font = new Font("KG Red Hands", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEnv.Location = new Point(218, 423);
            txtEnv.Name = "txtEnv";
            txtEnv.Size = new Size(162, 16);
            txtEnv.TabIndex = 44;
            txtEnv.TextChanged += txtEnv_TextChanged;
            // 
            // txtDesc
            // 
            txtDesc.BorderStyle = BorderStyle.None;
            txtDesc.Font = new Font("KG Red Hands", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDesc.Location = new Point(24, 203);
            txtDesc.Multiline = true;
            txtDesc.Name = "txtDesc";
            txtDesc.Size = new Size(356, 126);
            txtDesc.TabIndex = 40;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.FromArgb(254, 169, 190);
            label3.Font = new Font("Segoe UI", 2.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(134, 25, 64);
            label3.Location = new Point(-5, 41);
            label3.Margin = new Padding(1, 0, 3, 0);
            label3.Name = "label3";
            label3.Size = new Size(416, 4);
            label3.TabIndex = 37;
            label3.Text = resources.GetString("label3.Text");
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("KG Red Hands", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(134, 25, 64);
            label1.Location = new Point(24, 453);
            label1.Name = "label1";
            label1.Size = new Size(47, 19);
            label1.TabIndex = 57;
            label1.Text = "Total:";
            // 
            // txtTotal
            // 
            txtTotal.BorderStyle = BorderStyle.None;
            txtTotal.Font = new Font("KG Red Hands", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTotal.Location = new Point(24, 475);
            txtTotal.Name = "txtTotal";
            txtTotal.Size = new Size(161, 16);
            txtTotal.TabIndex = 58;
            // 
            // cmbTipo
            // 
            cmbTipo.BackColor = Color.FromArgb(255, 247, 248);
            cmbTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipo.Font = new Font("KG Red Hands", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbTipo.FormattingEnabled = true;
            cmbTipo.Items.AddRange(new object[] { "Amigurumi", "Flores", "Animal" });
            cmbTipo.Location = new Point(24, 131);
            cmbTipo.Name = "cmbTipo";
            cmbTipo.Size = new Size(161, 24);
            cmbTipo.TabIndex = 38;
            // 
            // FmEditarPedido
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(251, 233, 233);
            ClientSize = new Size(410, 510);
            Controls.Add(txtTotal);
            Controls.Add(label1);
            Controls.Add(btnGuardar);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label5);
            Controls.Add(label2);
            Controls.Add(label4);
            Controls.Add(txtContacto);
            Controls.Add(txtNom);
            Controls.Add(dateTimePicker1);
            Controls.Add(panel1);
            Controls.Add(cmbEnvio);
            Controls.Add(txtAnt);
            Controls.Add(txtSub);
            Controls.Add(txtEnv);
            Controls.Add(txtDesc);
            Controls.Add(cmbTipo);
            Controls.Add(label3);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            Name = "FmEditarPedido";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FmEditarPedido";
            Load += FmEditarPedido_Load;
            MouseDown += MoverVentana;
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnGuardar;
        private Label label12;
        private Label label11;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label5;
        private Label label2;
        private Label label4;
        private TextBox txtContacto;
        private TextBox txtNom;
        private DateTimePicker dateTimePicker1;
        private Panel panel1;
        private Button btnCerrar;
        private ComboBox cmbEnvio;
        private TextBox txtAnt;
        private TextBox txtSub;
        private TextBox txtEnv;
        private TextBox txtDesc;
        private Label label3;
        private Label label1;
        private TextBox txtTotal;
        private ComboBox cmbTipo;
    }
}
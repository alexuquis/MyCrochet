namespace MyCrochet
{
    partial class FmNuevoPedido
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FmNuevoPedido));
            label3 = new Label();
            cmbNTipo = new ComboBox();
            datePed = new DateTimePicker();
            txtNDesc = new TextBox();
            txtNNom = new TextBox();
            txtNContacto = new TextBox();
            cmbNEnvio = new ComboBox();
            txtEnv = new TextBox();
            txtSub = new TextBox();
            txtAnt = new TextBox();
            label4 = new Label();
            label2 = new Label();
            label5 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            lblNTotal = new Label();
            label1 = new Label();
            btnCerrar = new Button();
            panel1 = new Panel();
            label6 = new Label();
            btnNPedido = new Button();
            label13 = new Label();
            cmbEstado = new ComboBox();
            picBox1 = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picBox1).BeginInit();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.FromArgb(254, 169, 190);
            label3.Font = new Font("Segoe UI", 2.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(134, 25, 64);
            label3.Location = new Point(-2, 33);
            label3.Margin = new Padding(1, 0, 3, 0);
            label3.Name = "label3";
            label3.Size = new Size(598, 4);
            label3.TabIndex = 13;
            label3.Text = resources.GetString("label3.Text");
            // 
            // cmbNTipo
            // 
            cmbNTipo.BackColor = Color.FromArgb(255, 247, 248);
            cmbNTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbNTipo.Font = new Font("KG Red Hands", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbNTipo.FormattingEnabled = true;
            cmbNTipo.Items.AddRange(new object[] { "Amigurumi", "Flores", "Animal" });
            cmbNTipo.Location = new Point(27, 182);
            cmbNTipo.Name = "cmbNTipo";
            cmbNTipo.Size = new Size(161, 24);
            cmbNTipo.TabIndex = 14;
            cmbNTipo.SelectedIndexChanged += cmbNTipo_SelectedIndexChanged;
            // 
            // datePed
            // 
            datePed.CalendarMonthBackground = Color.FromArgb(251, 233, 233);
            datePed.Cursor = Cursors.Hand;
            datePed.Font = new Font("Leelawadee UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            datePed.Format = DateTimePickerFormat.Short;
            datePed.Location = new Point(221, 182);
            datePed.Name = "datePed";
            datePed.RightToLeft = RightToLeft.No;
            datePed.Size = new Size(162, 23);
            datePed.TabIndex = 15;
            // 
            // txtNDesc
            // 
            txtNDesc.BorderStyle = BorderStyle.None;
            txtNDesc.Font = new Font("KG Red Hands", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNDesc.Location = new Point(27, 245);
            txtNDesc.Multiline = true;
            txtNDesc.Name = "txtNDesc";
            txtNDesc.Size = new Size(356, 92);
            txtNDesc.TabIndex = 16;
            // 
            // txtNNom
            // 
            txtNNom.BorderStyle = BorderStyle.None;
            txtNNom.Font = new Font("KG Red Hands", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNNom.ForeColor = SystemColors.ActiveCaptionText;
            txtNNom.Location = new Point(27, 134);
            txtNNom.Name = "txtNNom";
            txtNNom.Size = new Size(161, 16);
            txtNNom.TabIndex = 17;
            // 
            // txtNContacto
            // 
            txtNContacto.BorderStyle = BorderStyle.None;
            txtNContacto.Font = new Font("KG Red Hands", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNContacto.ForeColor = SystemColors.ActiveCaptionText;
            txtNContacto.Location = new Point(221, 134);
            txtNContacto.Name = "txtNContacto";
            txtNContacto.Size = new Size(162, 16);
            txtNContacto.TabIndex = 18;
            // 
            // cmbNEnvio
            // 
            cmbNEnvio.BackColor = Color.FromArgb(255, 247, 248);
            cmbNEnvio.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbNEnvio.Font = new Font("KG Red Hands", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbNEnvio.FormattingEnabled = true;
            cmbNEnvio.Location = new Point(27, 379);
            cmbNEnvio.Name = "cmbNEnvio";
            cmbNEnvio.Size = new Size(162, 24);
            cmbNEnvio.TabIndex = 19;
            // 
            // txtEnv
            // 
            txtEnv.BackColor = SystemColors.Window;
            txtEnv.BorderStyle = BorderStyle.None;
            txtEnv.Font = new Font("KG Red Hands", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEnv.Location = new Point(27, 431);
            txtEnv.Name = "txtEnv";
            txtEnv.Size = new Size(162, 16);
            txtEnv.TabIndex = 20;
            txtEnv.Text = "0";
            txtEnv.TextChanged += textBox6_TextChanged;
            // 
            // txtSub
            // 
            txtSub.BorderStyle = BorderStyle.None;
            txtSub.Font = new Font("KG Red Hands", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSub.Location = new Point(212, 379);
            txtSub.Name = "txtSub";
            txtSub.Size = new Size(161, 16);
            txtSub.TabIndex = 21;
            txtSub.TextChanged += textBox6_TextChanged;
            // 
            // txtAnt
            // 
            txtAnt.BorderStyle = BorderStyle.None;
            txtAnt.Font = new Font("KG Red Hands", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtAnt.Location = new Point(212, 431);
            txtAnt.Name = "txtAnt";
            txtAnt.Size = new Size(161, 16);
            txtAnt.TabIndex = 22;
            txtAnt.Text = "0";
            txtAnt.TextChanged += textBox6_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("KG Red Hands", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(134, 25, 64);
            label4.Location = new Point(27, 112);
            label4.Name = "label4";
            label4.Size = new Size(149, 19);
            label4.TabIndex = 24;
            label4.Text = "Nombre del Cliente:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("KG Red Hands", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(134, 25, 64);
            label2.Location = new Point(221, 112);
            label2.Name = "label2";
            label2.Size = new Size(121, 19);
            label2.TabIndex = 25;
            label2.Text = "Num/Red social:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("KG Red Hands", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(134, 25, 64);
            label5.Location = new Point(27, 160);
            label5.Name = "label5";
            label5.Size = new Size(117, 19);
            label5.TabIndex = 26;
            label5.Text = "Tipo de Pedido:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("KG Red Hands", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.FromArgb(134, 25, 64);
            label7.Location = new Point(221, 160);
            label7.Name = "label7";
            label7.Size = new Size(140, 19);
            label7.TabIndex = 27;
            label7.Text = "Fecha de Entrega:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("KG Red Hands", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.FromArgb(134, 25, 64);
            label8.Location = new Point(152, 220);
            label8.Name = "label8";
            label8.Size = new Size(115, 22);
            label8.TabIndex = 28;
            label8.Text = "Descripción:";
            label8.Click += label8_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("KG Red Hands", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.FromArgb(134, 25, 64);
            label9.Location = new Point(212, 353);
            label9.Name = "label9";
            label9.Size = new Size(71, 19);
            label9.TabIndex = 29;
            label9.Text = "Subtotal:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.Transparent;
            label10.Font = new Font("KG Red Hands", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.ForeColor = Color.FromArgb(134, 25, 64);
            label10.Location = new Point(213, 409);
            label10.Name = "label10";
            label10.Size = new Size(70, 19);
            label10.TabIndex = 30;
            label10.Text = "Anticipo:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.Transparent;
            label11.Font = new Font("KG Red Hands", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.ForeColor = Color.FromArgb(134, 25, 64);
            label11.Location = new Point(27, 353);
            label11.Name = "label11";
            label11.Size = new Size(128, 19);
            label11.TabIndex = 31;
            label11.Text = "Opción de envio:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.BackColor = Color.Transparent;
            label12.Font = new Font("KG Red Hands", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.ForeColor = Color.FromArgb(134, 25, 64);
            label12.Location = new Point(27, 409);
            label12.Name = "label12";
            label12.Size = new Size(120, 19);
            label12.TabIndex = 32;
            label12.Text = "Costo de envio:";
            // 
            // lblNTotal
            // 
            lblNTotal.AutoSize = true;
            lblNTotal.BackColor = Color.FromArgb(134, 25, 64);
            lblNTotal.Font = new Font("Good Bakwan", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNTotal.ForeColor = Color.FromArgb(255, 247, 248);
            lblNTotal.Location = new Point(493, 364);
            lblNTotal.Name = "lblNTotal";
            lblNTotal.Size = new Size(60, 30);
            lblNTotal.TabIndex = 23;
            lblNTotal.Text = "0.00";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Good Bakwan", 21.7499962F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(134, 25, 64);
            label1.Location = new Point(407, 359);
            label1.Name = "label1";
            label1.Size = new Size(87, 36);
            label1.TabIndex = 33;
            label1.Text = "Total:";
            // 
            // btnCerrar
            // 
            btnCerrar.BackColor = Color.Transparent;
            btnCerrar.BackgroundImage = (Image)resources.GetObject("btnCerrar.BackgroundImage");
            btnCerrar.BackgroundImageLayout = ImageLayout.Zoom;
            btnCerrar.FlatAppearance.BorderColor = Color.FromArgb(134, 25, 64);
            btnCerrar.FlatAppearance.MouseDownBackColor = Color.FromArgb(134, 25, 64);
            btnCerrar.FlatAppearance.MouseOverBackColor = Color.FromArgb(134, 25, 64);
            btnCerrar.Location = new Point(553, 8);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(26, 22);
            btnCerrar.TabIndex = 2;
            btnCerrar.UseVisualStyleBackColor = false;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnCerrar);
            panel1.Location = new Point(-2, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(593, 33);
            panel1.TabIndex = 4;
            panel1.MouseDown += MoverVentana;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Super Mindset", 30F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.FromArgb(134, 25, 64);
            label6.Location = new Point(176, 56);
            label6.Name = "label6";
            label6.Size = new Size(236, 42);
            label6.TabIndex = 12;
            label6.Text = "Nuevo Pedido";
            // 
            // btnNPedido
            // 
            btnNPedido.BackgroundImage = (Image)resources.GetObject("btnNPedido.BackgroundImage");
            btnNPedido.BackgroundImageLayout = ImageLayout.Stretch;
            btnNPedido.FlatAppearance.BorderSize = 0;
            btnNPedido.FlatAppearance.MouseOverBackColor = Color.FromArgb(251, 233, 233);
            btnNPedido.FlatStyle = FlatStyle.Flat;
            btnNPedido.Font = new Font("KG Red Hands", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnNPedido.ForeColor = Color.FromArgb(134, 25, 64);
            btnNPedido.Location = new Point(407, 409);
            btnNPedido.Name = "btnNPedido";
            btnNPedido.Size = new Size(159, 37);
            btnNPedido.TabIndex = 34;
            btnNPedido.Text = "Registrar Pedido";
            btnNPedido.UseVisualStyleBackColor = true;
            btnNPedido.Click += btnNPedido_Click;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.BackColor = Color.Transparent;
            label13.Font = new Font("KG Red Hands", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label13.ForeColor = Color.FromArgb(134, 25, 64);
            label13.Location = new Point(416, 112);
            label13.Name = "label13";
            label13.Size = new Size(140, 19);
            label13.TabIndex = 35;
            label13.Text = "Estado del Pedido:";
            // 
            // cmbEstado
            // 
            cmbEstado.BackColor = Color.FromArgb(255, 247, 248);
            cmbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstado.Font = new Font("KG Red Hands", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbEstado.FormattingEnabled = true;
            cmbEstado.Items.AddRange(new object[] { "Amigurumi", "Flores", "Animal" });
            cmbEstado.Location = new Point(416, 131);
            cmbEstado.Name = "cmbEstado";
            cmbEstado.Size = new Size(161, 24);
            cmbEstado.TabIndex = 36;
            // 
            // picBox1
            // 
            picBox1.Location = new Point(396, 182);
            picBox1.Name = "picBox1";
            picBox1.Size = new Size(181, 155);
            picBox1.SizeMode = PictureBoxSizeMode.Zoom;
            picBox1.TabIndex = 37;
            picBox1.TabStop = false;
            // 
            // FmNuevoPedido
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(251, 233, 233);
            ClientSize = new Size(597, 471);
            Controls.Add(picBox1);
            Controls.Add(cmbEstado);
            Controls.Add(label13);
            Controls.Add(btnNPedido);
            Controls.Add(label1);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label5);
            Controls.Add(label2);
            Controls.Add(label4);
            Controls.Add(lblNTotal);
            Controls.Add(txtAnt);
            Controls.Add(txtSub);
            Controls.Add(txtEnv);
            Controls.Add(cmbNEnvio);
            Controls.Add(txtNContacto);
            Controls.Add(txtNNom);
            Controls.Add(txtNDesc);
            Controls.Add(datePed);
            Controls.Add(cmbNTipo);
            Controls.Add(label3);
            Controls.Add(label6);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FmNuevoPedido";
            Text = "FmNuevoPedido";
            Load += FmNuevoPedido_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label3;
        private ComboBox cmbNTipo;
        private DateTimePicker datePed;
        private TextBox txtNDesc;
        private TextBox txtNNom;
        private TextBox txtNContacto;
        private ComboBox cmbNEnvio;
        private TextBox txtEnv;
        private TextBox txtSub;
        private TextBox txtAnt;
        private Label label4;
        private Label label2;
        private Label label5;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label lblNTotal;
        private Label label1;
        private Button btnCerrar;
        private Panel panel1;
        private Label label6;
        private Button btnNPedido;
        private Label label13;
        private ComboBox cmbEstado;
        private PictureBox picBox1;
    }
}
namespace MyCrochet
{
    partial class FmNuevoMaterial
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FmNuevoMaterial));
            panel1 = new Panel();
            btnCerrar = new Button();
            label3 = new Label();
            label6 = new Label();
            label2 = new Label();
            label4 = new Label();
            txtMarca = new TextBox();
            label1 = new Label();
            txtColor = new TextBox();
            label7 = new Label();
            label8 = new Label();
            txtPrecio = new TextBox();
            txtStock = new TextBox();
            cmbCateg = new ComboBox();
            btnAgregarMat = new Button();
            label9 = new Label();
            txtTam = new TextBox();
            pictureBox1 = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btnCerrar);
            panel1.Location = new Point(1, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(512, 33);
            panel1.TabIndex = 14;
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
            btnCerrar.Location = new Point(473, 8);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(26, 22);
            btnCerrar.TabIndex = 2;
            btnCerrar.UseVisualStyleBackColor = false;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.FromArgb(254, 169, 190);
            label3.Font = new Font("Segoe UI", 2.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(134, 25, 64);
            label3.Location = new Point(-10, 33);
            label3.Margin = new Padding(1, 0, 3, 0);
            label3.Name = "label3";
            label3.Size = new Size(531, 4);
            label3.TabIndex = 15;
            label3.Text = resources.GetString("label3.Text");
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Super Mindset", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.FromArgb(134, 25, 64);
            label6.Location = new Point(150, 52);
            label6.Name = "label6";
            label6.Size = new Size(212, 34);
            label6.TabIndex = 16;
            label6.Text = "Nuevo Material";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("KG Red Hands", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(134, 25, 64);
            label2.Location = new Point(21, 102);
            label2.Name = "label2";
            label2.Size = new Size(84, 19);
            label2.TabIndex = 29;
            label2.Text = "Categoria:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("KG Red Hands", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(134, 25, 64);
            label4.Location = new Point(192, 110);
            label4.Name = "label4";
            label4.Size = new Size(95, 19);
            label4.TabIndex = 28;
            label4.Text = "Marca/Tipo:";
            // 
            // txtMarca
            // 
            txtMarca.BorderStyle = BorderStyle.None;
            txtMarca.Font = new Font("KG Red Hands", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMarca.ForeColor = Color.Black;
            txtMarca.Location = new Point(192, 132);
            txtMarca.Name = "txtMarca";
            txtMarca.Size = new Size(138, 16);
            txtMarca.TabIndex = 26;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("KG Red Hands", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(134, 25, 64);
            label1.Location = new Point(192, 168);
            label1.Name = "label1";
            label1.Size = new Size(51, 19);
            label1.TabIndex = 33;
            label1.Text = "Color:";
            // 
            // txtColor
            // 
            txtColor.BorderStyle = BorderStyle.None;
            txtColor.Font = new Font("KG Red Hands", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtColor.ForeColor = SystemColors.ActiveCaptionText;
            txtColor.Location = new Point(192, 190);
            txtColor.Name = "txtColor";
            txtColor.Size = new Size(84, 16);
            txtColor.TabIndex = 31;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("KG Red Hands", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.FromArgb(134, 25, 64);
            label7.Location = new Point(192, 224);
            label7.Name = "label7";
            label7.Size = new Size(119, 19);
            label7.TabIndex = 37;
            label7.Text = "Precio Unitario:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("KG Red Hands", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.FromArgb(134, 25, 64);
            label8.Location = new Point(21, 224);
            label8.Name = "label8";
            label8.Size = new Size(53, 19);
            label8.TabIndex = 36;
            label8.Text = "Stock:";
            // 
            // txtPrecio
            // 
            txtPrecio.BorderStyle = BorderStyle.None;
            txtPrecio.Font = new Font("KG Red Hands", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPrecio.ForeColor = SystemColors.ActiveCaptionText;
            txtPrecio.Location = new Point(192, 246);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(84, 16);
            txtPrecio.TabIndex = 35;
            // 
            // txtStock
            // 
            txtStock.BorderStyle = BorderStyle.None;
            txtStock.Font = new Font("KG Red Hands", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtStock.ForeColor = Color.Black;
            txtStock.Location = new Point(21, 246);
            txtStock.Name = "txtStock";
            txtStock.Size = new Size(95, 16);
            txtStock.TabIndex = 34;
            // 
            // cmbCateg
            // 
            cmbCateg.BackColor = Color.FromArgb(255, 247, 248);
            cmbCateg.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCateg.Font = new Font("KG Red Hands", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbCateg.FormattingEnabled = true;
            cmbCateg.Location = new Point(21, 124);
            cmbCateg.Name = "cmbCateg";
            cmbCateg.Size = new Size(138, 24);
            cmbCateg.TabIndex = 38;
            cmbCateg.SelectedIndexChanged += cmbCateg_SelectedIndexChanged;
            // 
            // btnAgregarMat
            // 
            btnAgregarMat.BackgroundImage = (Image)resources.GetObject("btnAgregarMat.BackgroundImage");
            btnAgregarMat.BackgroundImageLayout = ImageLayout.Stretch;
            btnAgregarMat.FlatAppearance.BorderSize = 0;
            btnAgregarMat.FlatAppearance.MouseOverBackColor = Color.FromArgb(251, 233, 233);
            btnAgregarMat.FlatStyle = FlatStyle.Flat;
            btnAgregarMat.Font = new Font("KG Red Hands", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAgregarMat.ForeColor = Color.FromArgb(134, 25, 64);
            btnAgregarMat.Location = new Point(348, 229);
            btnAgregarMat.Name = "btnAgregarMat";
            btnAgregarMat.Size = new Size(152, 33);
            btnAgregarMat.TabIndex = 39;
            btnAgregarMat.Text = "Agregar Material";
            btnAgregarMat.UseVisualStyleBackColor = true;
            btnAgregarMat.Click += btnAgregarMat_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("KG Red Hands", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.FromArgb(134, 25, 64);
            label9.Location = new Point(21, 168);
            label9.Name = "label9";
            label9.Size = new Size(68, 19);
            label9.TabIndex = 40;
            label9.Text = "Tamaño:";
            // 
            // txtTam
            // 
            txtTam.BorderStyle = BorderStyle.None;
            txtTam.Font = new Font("KG Red Hands", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTam.ForeColor = Color.Black;
            txtTam.Location = new Point(21, 190);
            txtTam.Name = "txtTam";
            txtTam.Size = new Size(95, 16);
            txtTam.TabIndex = 41;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Location = new Point(348, 102);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(152, 121);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 42;
            pictureBox1.TabStop = false;
            pictureBox1.Visible = false;
            // 
            // FmNuevoMaterial
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(251, 233, 233);
            ClientSize = new Size(512, 286);
            Controls.Add(pictureBox1);
            Controls.Add(txtTam);
            Controls.Add(label9);
            Controls.Add(btnAgregarMat);
            Controls.Add(cmbCateg);
            Controls.Add(label7);
            Controls.Add(label8);
            Controls.Add(txtPrecio);
            Controls.Add(txtStock);
            Controls.Add(label1);
            Controls.Add(txtColor);
            Controls.Add(label2);
            Controls.Add(label4);
            Controls.Add(txtMarca);
            Controls.Add(label6);
            Controls.Add(panel1);
            Controls.Add(label3);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            Name = "FmNuevoMaterial";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FmNuevoMaterial";
            Load += FmNuevoMaterial_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button btnCerrar;
        private Label label3;
        private Label label6;
        private Label label2;
        private Label label4;
        private TextBox txtMarca;
        private Label label1;
        private TextBox txtColor;
        private Label label7;
        private Label label8;
        private TextBox txtPrecio;
        private TextBox txtStock;
        private ComboBox cmbCateg;
        private Button btnAgregarMat;
        private Label label9;
        private TextBox txtTam;
        private PictureBox pictureBox1;
    }
}
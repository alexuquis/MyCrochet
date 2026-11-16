namespace MyCrochet
{
    partial class FmCotizador
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FmCotizador));
            label2 = new Label();
            button5 = new Button();
            label1 = new Label();
            btnlogo = new Button();
            panel3 = new Panel();
            panel1 = new Panel();
            btnMinimizar = new Button();
            btnCerrar = new Button();
            panel4 = new Panel();
            label15 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            panel5 = new Panel();
            lblTotalObra = new Label();
            label8 = new Label();
            txtCantH = new TextBox();
            label7 = new Label();
            label6 = new Label();
            txtPrecioH = new TextBox();
            panel6 = new Panel();
            lblMat = new Label();
            label14 = new Label();
            btnAgMaterial = new Button();
            label13 = new Label();
            label12 = new Label();
            cmbMateriales = new ComboBox();
            listBox1 = new ListBox();
            contextMenuStrip1 = new ContextMenuStrip(components);
            eliminarMaterialToolStripMenuItem = new ToolStripMenuItem();
            txtCantM = new TextBox();
            panel7 = new Panel();
            panel8 = new Panel();
            label11 = new Label();
            lblTotal = new Label();
            txtGanancia = new TextBox();
            label18 = new Label();
            lblSub = new Label();
            label16 = new Label();
            panel2 = new Panel();
            pictureBox5 = new PictureBox();
            pictureBox4 = new PictureBox();
            pictureBox3 = new PictureBox();
            btnInicio = new Button();
            pictureBox2 = new PictureBox();
            btnPedidos = new Button();
            pictureBox1 = new PictureBox();
            btnInventario = new Button();
            btnConfig = new Button();
            btnCotizacion = new Button();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            panel7.SuspendLayout();
            panel8.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Super Mindset", 48F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(134, 25, 64);
            label2.Location = new Point(249, 51);
            label2.Name = "label2";
            label2.Size = new Size(277, 68);
            label2.TabIndex = 3;
            label2.Text = "Cotizador";
            // 
            // button5
            // 
            button5.BackColor = Color.FromArgb(134, 25, 64);
            button5.BackgroundImageLayout = ImageLayout.Stretch;
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatAppearance.MouseOverBackColor = Color.FromArgb(134, 25, 64);
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Good Bakwan", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button5.ForeColor = Color.FromArgb(255, 247, 248);
            button5.Location = new Point(55, 634);
            button5.Name = "button5";
            button5.Size = new Size(175, 28);
            button5.TabIndex = 5;
            button5.Text = "Cerrar Sesión";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(134, 25, 64);
            label1.Font = new Font("Segoe UI", 2.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(134, 25, 64);
            label1.Location = new Point(3, 147);
            label1.Margin = new Padding(1, 0, 3, 0);
            label1.Name = "label1";
            label1.Size = new Size(228, 4);
            label1.TabIndex = 4;
            label1.Text = resources.GetString("label1.Text");
            // 
            // btnlogo
            // 
            btnlogo.BackColor = Color.Transparent;
            btnlogo.BackgroundImage = (Image)resources.GetObject("btnlogo.BackgroundImage");
            btnlogo.BackgroundImageLayout = ImageLayout.Zoom;
            btnlogo.FlatAppearance.BorderSize = 0;
            btnlogo.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnlogo.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnlogo.FlatStyle = FlatStyle.Flat;
            btnlogo.Location = new Point(18, 13);
            btnlogo.Name = "btnlogo";
            btnlogo.Size = new Size(196, 123);
            btnlogo.TabIndex = 4;
            btnlogo.UseVisualStyleBackColor = false;
            btnlogo.Click += btnlogo_Click;
            // 
            // panel3
            // 
            panel3.BackgroundImage = (Image)resources.GetObject("panel3.BackgroundImage");
            panel3.BackgroundImageLayout = ImageLayout.Stretch;
            panel3.Controls.Add(label1);
            panel3.Controls.Add(btnlogo);
            panel3.Location = new Point(21, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(231, 151);
            panel3.TabIndex = 4;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(254, 169, 190);
            panel1.Controls.Add(btnMinimizar);
            panel1.Controls.Add(btnCerrar);
            panel1.Location = new Point(-1, -1);
            panel1.Name = "panel1";
            panel1.Size = new Size(1102, 29);
            panel1.TabIndex = 8;
            // 
            // btnMinimizar
            // 
            btnMinimizar.BackColor = Color.Transparent;
            btnMinimizar.BackgroundImage = (Image)resources.GetObject("btnMinimizar.BackgroundImage");
            btnMinimizar.BackgroundImageLayout = ImageLayout.Zoom;
            btnMinimizar.Location = new Point(1029, 3);
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
            btnCerrar.Location = new Point(1063, 3);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(26, 23);
            btnCerrar.TabIndex = 0;
            btnCerrar.UseVisualStyleBackColor = false;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(255, 247, 248);
            panel4.Controls.Add(label15);
            panel4.Controls.Add(label5);
            panel4.Controls.Add(label4);
            panel4.Controls.Add(label3);
            panel4.Controls.Add(label2);
            panel4.Controls.Add(panel5);
            panel4.Controls.Add(panel6);
            panel4.Controls.Add(panel7);
            panel4.ForeColor = Color.FromArgb(254, 169, 190);
            panel4.Location = new Point(284, 40);
            panel4.Name = "panel4";
            panel4.Size = new Size(804, 646);
            panel4.TabIndex = 10;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.BackColor = Color.FromArgb(254, 169, 190);
            label15.Font = new Font("KG Red Hands", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label15.ForeColor = SystemColors.ControlLightLight;
            label15.Location = new Point(165, 375);
            label15.Name = "label15";
            label15.Size = new Size(82, 28);
            label15.TabIndex = 48;
            label15.Text = "TOTAL";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.FromArgb(254, 169, 190);
            label5.Font = new Font("KG Red Hands", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = SystemColors.ControlLightLight;
            label5.Location = new Point(526, 160);
            label5.Name = "label5";
            label5.Size = new Size(110, 28);
            label5.TabIndex = 7;
            label5.Text = "Material";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.FromArgb(254, 169, 190);
            label4.Font = new Font("KG Red Hands", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.ControlLightLight;
            label4.Location = new Point(110, 160);
            label4.Name = "label4";
            label4.Size = new Size(176, 28);
            label4.TabIndex = 6;
            label4.Text = "Mano de Obra";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.FromArgb(254, 169, 190);
            label3.Font = new Font("Segoe UI", 2.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(134, 25, 64);
            label3.Location = new Point(53, 119);
            label3.Margin = new Padding(1, 0, 3, 0);
            label3.Name = "label3";
            label3.Size = new Size(706, 4);
            label3.TabIndex = 5;
            label3.Text = resources.GetString("label3.Text");
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(251, 233, 233);
            panel5.Controls.Add(lblTotalObra);
            panel5.Controls.Add(label8);
            panel5.Controls.Add(txtCantH);
            panel5.Controls.Add(label7);
            panel5.Controls.Add(label6);
            panel5.Controls.Add(txtPrecioH);
            panel5.Location = new Point(53, 171);
            panel5.Name = "panel5";
            panel5.Size = new Size(302, 190);
            panel5.TabIndex = 44;
            // 
            // lblTotalObra
            // 
            lblTotalObra.AutoSize = true;
            lblTotalObra.BackColor = Color.FromArgb(254, 169, 190);
            lblTotalObra.Font = new Font("Good Bakwan", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotalObra.ForeColor = Color.FromArgb(255, 247, 248);
            lblTotalObra.Location = new Point(209, 133);
            lblTotalObra.Name = "lblTotalObra";
            lblTotalObra.Size = new Size(58, 24);
            lblTotalObra.TabIndex = 45;
            lblTotalObra.Text = "$0.00";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("KG Red Hands", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.FromArgb(134, 25, 64);
            label8.Location = new Point(25, 138);
            label8.Name = "label8";
            label8.Size = new Size(178, 19);
            label8.TabIndex = 47;
            label8.Text = "Total de Mano de obra:";
            // 
            // txtCantH
            // 
            txtCantH.BorderStyle = BorderStyle.None;
            txtCantH.Font = new Font("KG Red Hands", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCantH.ForeColor = SystemColors.ActiveCaptionText;
            txtCantH.Location = new Point(167, 91);
            txtCantH.Name = "txtCantH";
            txtCantH.Size = new Size(106, 16);
            txtCantH.TabIndex = 43;
            txtCantH.TextChanged += txtCantH_TextChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("KG Red Hands", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.FromArgb(134, 25, 64);
            label7.Location = new Point(25, 88);
            label7.Name = "label7";
            label7.Size = new Size(139, 19);
            label7.TabIndex = 46;
            label7.Text = "Horas Trabajadas:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("KG Red Hands", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.FromArgb(134, 25, 64);
            label6.Location = new Point(25, 49);
            label6.Name = "label6";
            label6.Size = new Size(123, 19);
            label6.TabIndex = 45;
            label6.Text = "Costo por hora:";
            // 
            // txtPrecioH
            // 
            txtPrecioH.BorderStyle = BorderStyle.None;
            txtPrecioH.Font = new Font("KG Red Hands", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPrecioH.ForeColor = SystemColors.ActiveCaptionText;
            txtPrecioH.Location = new Point(154, 51);
            txtPrecioH.Name = "txtPrecioH";
            txtPrecioH.Size = new Size(119, 16);
            txtPrecioH.TabIndex = 42;
            txtPrecioH.TextChanged += txtPrecioH_TextChanged;
            // 
            // panel6
            // 
            panel6.BackColor = Color.FromArgb(251, 233, 233);
            panel6.Controls.Add(lblMat);
            panel6.Controls.Add(label14);
            panel6.Controls.Add(btnAgMaterial);
            panel6.Controls.Add(label13);
            panel6.Controls.Add(label12);
            panel6.Controls.Add(cmbMateriales);
            panel6.Controls.Add(listBox1);
            panel6.Controls.Add(txtCantM);
            panel6.Location = new Point(402, 171);
            panel6.Name = "panel6";
            panel6.Size = new Size(357, 404);
            panel6.TabIndex = 45;
            // 
            // lblMat
            // 
            lblMat.AutoSize = true;
            lblMat.BackColor = Color.FromArgb(254, 169, 190);
            lblMat.Font = new Font("Good Bakwan", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMat.ForeColor = Color.FromArgb(255, 247, 248);
            lblMat.Location = new Point(183, 360);
            lblMat.Name = "lblMat";
            lblMat.Size = new Size(58, 24);
            lblMat.TabIndex = 51;
            lblMat.Text = "$0.00";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.BackColor = Color.Transparent;
            label14.Font = new Font("KG Red Hands", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label14.ForeColor = Color.FromArgb(134, 25, 64);
            label14.Location = new Point(41, 364);
            label14.Name = "label14";
            label14.Size = new Size(136, 19);
            label14.TabIndex = 52;
            label14.Text = "Total de Material:";
            // 
            // btnAgMaterial
            // 
            btnAgMaterial.BackgroundImage = (Image)resources.GetObject("btnAgMaterial.BackgroundImage");
            btnAgMaterial.BackgroundImageLayout = ImageLayout.Stretch;
            btnAgMaterial.FlatAppearance.BorderSize = 0;
            btnAgMaterial.FlatAppearance.MouseOverBackColor = Color.FromArgb(251, 233, 233);
            btnAgMaterial.FlatStyle = FlatStyle.Flat;
            btnAgMaterial.Font = new Font("KG Red Hands", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAgMaterial.ForeColor = Color.FromArgb(134, 25, 64);
            btnAgMaterial.Location = new Point(107, 124);
            btnAgMaterial.Name = "btnAgMaterial";
            btnAgMaterial.Size = new Size(152, 33);
            btnAgMaterial.TabIndex = 50;
            btnAgMaterial.Text = "Agregar Material";
            btnAgMaterial.UseVisualStyleBackColor = true;
            btnAgMaterial.Click += btnAgMaterial_Click;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.BackColor = Color.Transparent;
            label13.Font = new Font("KG Red Hands", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label13.ForeColor = Color.FromArgb(134, 25, 64);
            label13.Location = new Point(31, 86);
            label13.Name = "label13";
            label13.Size = new Size(136, 19);
            label13.TabIndex = 49;
            label13.Text = "Cantidad/gramos:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.BackColor = Color.Transparent;
            label12.Font = new Font("KG Red Hands", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.ForeColor = Color.FromArgb(134, 25, 64);
            label12.Location = new Point(31, 50);
            label12.Name = "label12";
            label12.Size = new Size(161, 19);
            label12.TabIndex = 48;
            label12.Text = "Seleccionar Material:";
            // 
            // cmbMateriales
            // 
            cmbMateriales.BackColor = Color.FromArgb(255, 247, 248);
            cmbMateriales.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMateriales.Font = new Font("KG Red Hands", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbMateriales.FormattingEnabled = true;
            cmbMateriales.Items.AddRange(new object[] { "Amigurumi", "Flores", "Animal" });
            cmbMateriales.Location = new Point(198, 49);
            cmbMateriales.Name = "cmbMateriales";
            cmbMateriales.Size = new Size(130, 24);
            cmbMateriales.TabIndex = 39;
            // 
            // listBox1
            // 
            listBox1.BorderStyle = BorderStyle.None;
            listBox1.ContextMenuStrip = contextMenuStrip1;
            listBox1.Font = new Font("Lucida Sans", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            listBox1.ForeColor = Color.FromArgb(134, 25, 64);
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 13;
            listBox1.Location = new Point(41, 179);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(287, 156);
            listBox1.TabIndex = 41;
            listBox1.MouseDown += listBox1_MouseDown;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { eliminarMaterialToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(164, 26);
            // 
            // eliminarMaterialToolStripMenuItem
            // 
            eliminarMaterialToolStripMenuItem.Name = "eliminarMaterialToolStripMenuItem";
            eliminarMaterialToolStripMenuItem.Size = new Size(163, 22);
            eliminarMaterialToolStripMenuItem.Text = "Eliminar Material";
            eliminarMaterialToolStripMenuItem.Click += eliminarMaterialToolStripMenuItem_Click;
            // 
            // txtCantM
            // 
            txtCantM.BorderStyle = BorderStyle.None;
            txtCantM.Font = new Font("KG Red Hands", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCantM.ForeColor = SystemColors.ActiveCaptionText;
            txtCantM.Location = new Point(198, 88);
            txtCantM.Name = "txtCantM";
            txtCantM.Size = new Size(130, 16);
            txtCantM.TabIndex = 40;
            // 
            // panel7
            // 
            panel7.BackColor = Color.FromArgb(251, 233, 233);
            panel7.Controls.Add(panel8);
            panel7.Controls.Add(txtGanancia);
            panel7.Controls.Add(label18);
            panel7.Controls.Add(lblSub);
            panel7.Controls.Add(label16);
            panel7.Location = new Point(53, 391);
            panel7.Name = "panel7";
            panel7.Size = new Size(302, 184);
            panel7.TabIndex = 46;
            // 
            // panel8
            // 
            panel8.BackColor = Color.FromArgb(254, 169, 190);
            panel8.Controls.Add(label11);
            panel8.Controls.Add(lblTotal);
            panel8.Location = new Point(48, 111);
            panel8.Name = "panel8";
            panel8.Size = new Size(208, 52);
            panel8.TabIndex = 52;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.Transparent;
            label11.Font = new Font("Good Bakwan", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.ForeColor = Color.FromArgb(134, 25, 64);
            label11.Location = new Point(3, 14);
            label11.Name = "label11";
            label11.Size = new Size(88, 30);
            label11.TabIndex = 47;
            label11.Text = "TOTAL:";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.BackColor = Color.FromArgb(134, 25, 64);
            lblTotal.Font = new Font("Good Bakwan", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotal.ForeColor = Color.FromArgb(255, 247, 248);
            lblTotal.Location = new Point(97, 14);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(74, 30);
            lblTotal.TabIndex = 45;
            lblTotal.Text = "$0.00";
            // 
            // txtGanancia
            // 
            txtGanancia.BorderStyle = BorderStyle.None;
            txtGanancia.Font = new Font("KG Red Hands", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtGanancia.ForeColor = SystemColors.ActiveCaptionText;
            txtGanancia.Location = new Point(129, 82);
            txtGanancia.Name = "txtGanancia";
            txtGanancia.Size = new Size(119, 16);
            txtGanancia.TabIndex = 51;
            txtGanancia.TextChanged += txtGanancia_TextChanged;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.BackColor = Color.Transparent;
            label18.Font = new Font("KG Red Hands", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label18.ForeColor = Color.FromArgb(134, 25, 64);
            label18.Location = new Point(35, 82);
            label18.Name = "label18";
            label18.Size = new Size(88, 19);
            label18.TabIndex = 50;
            label18.Text = "Ganancia %:";
            // 
            // lblSub
            // 
            lblSub.AutoSize = true;
            lblSub.BackColor = Color.FromArgb(254, 169, 190);
            lblSub.Font = new Font("Good Bakwan", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSub.ForeColor = Color.FromArgb(255, 247, 248);
            lblSub.Location = new Point(112, 42);
            lblSub.Name = "lblSub";
            lblSub.Size = new Size(58, 24);
            lblSub.TabIndex = 49;
            lblSub.Text = "$0.00";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.BackColor = Color.Transparent;
            label16.Font = new Font("KG Red Hands", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label16.ForeColor = Color.FromArgb(134, 25, 64);
            label16.Location = new Point(35, 46);
            label16.Name = "label16";
            label16.Size = new Size(71, 19);
            label16.TabIndex = 48;
            label16.Text = "Subtotal:";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(254, 169, 190);
            panel2.Controls.Add(pictureBox5);
            panel2.Controls.Add(button5);
            panel2.Controls.Add(pictureBox4);
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(pictureBox3);
            panel2.Controls.Add(btnInicio);
            panel2.Controls.Add(pictureBox2);
            panel2.Controls.Add(btnPedidos);
            panel2.Controls.Add(pictureBox1);
            panel2.Controls.Add(btnInventario);
            panel2.Controls.Add(btnConfig);
            panel2.Controls.Add(btnCotizacion);
            panel2.Location = new Point(-1, 24);
            panel2.Name = "panel2";
            panel2.Size = new Size(269, 678);
            panel2.TabIndex = 9;
            // 
            // pictureBox5
            // 
            pictureBox5.BackgroundImage = (Image)resources.GetObject("pictureBox5.BackgroundImage");
            pictureBox5.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox5.Image = (Image)resources.GetObject("pictureBox5.Image");
            pictureBox5.Location = new Point(11, 425);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(38, 34);
            pictureBox5.TabIndex = 42;
            pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.BackgroundImage = (Image)resources.GetObject("pictureBox4.BackgroundImage");
            pictureBox4.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(11, 368);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(38, 34);
            pictureBox4.TabIndex = 41;
            pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.BackgroundImage = (Image)resources.GetObject("pictureBox3.BackgroundImage");
            pictureBox3.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(11, 308);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(38, 34);
            pictureBox3.TabIndex = 40;
            pictureBox3.TabStop = false;
            // 
            // btnInicio
            // 
            btnInicio.BackgroundImage = (Image)resources.GetObject("btnInicio.BackgroundImage");
            btnInicio.BackgroundImageLayout = ImageLayout.Stretch;
            btnInicio.FlatAppearance.BorderSize = 0;
            btnInicio.FlatAppearance.MouseOverBackColor = Color.FromArgb(254, 169, 190);
            btnInicio.FlatStyle = FlatStyle.Flat;
            btnInicio.Font = new Font("KG Red Hands", 12.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnInicio.ForeColor = Color.FromArgb(134, 25, 64);
            btnInicio.Location = new Point(55, 187);
            btnInicio.Name = "btnInicio";
            btnInicio.Size = new Size(197, 41);
            btnInicio.TabIndex = 33;
            btnInicio.Text = "Inicio";
            btnInicio.UseVisualStyleBackColor = true;
            btnInicio.Click += btnInicio_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImage = (Image)resources.GetObject("pictureBox2.BackgroundImage");
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(11, 251);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(38, 34);
            pictureBox2.TabIndex = 39;
            pictureBox2.TabStop = false;
            // 
            // btnPedidos
            // 
            btnPedidos.BackgroundImage = (Image)resources.GetObject("btnPedidos.BackgroundImage");
            btnPedidos.BackgroundImageLayout = ImageLayout.Stretch;
            btnPedidos.FlatAppearance.BorderSize = 0;
            btnPedidos.FlatAppearance.MouseOverBackColor = Color.FromArgb(254, 169, 190);
            btnPedidos.FlatStyle = FlatStyle.Flat;
            btnPedidos.Font = new Font("KG Red Hands", 12.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnPedidos.ForeColor = Color.FromArgb(134, 25, 64);
            btnPedidos.Location = new Point(55, 244);
            btnPedidos.Name = "btnPedidos";
            btnPedidos.Size = new Size(197, 41);
            btnPedidos.TabIndex = 35;
            btnPedidos.Text = "Pedidos";
            btnPedidos.UseVisualStyleBackColor = true;
            btnPedidos.Click += btnPedidos_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(11, 194);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(38, 34);
            pictureBox1.TabIndex = 38;
            pictureBox1.TabStop = false;
            // 
            // btnInventario
            // 
            btnInventario.BackgroundImage = (Image)resources.GetObject("btnInventario.BackgroundImage");
            btnInventario.BackgroundImageLayout = ImageLayout.Stretch;
            btnInventario.FlatAppearance.BorderSize = 0;
            btnInventario.FlatAppearance.MouseOverBackColor = Color.FromArgb(254, 169, 190);
            btnInventario.FlatStyle = FlatStyle.Flat;
            btnInventario.Font = new Font("KG Red Hands", 12.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnInventario.ForeColor = Color.FromArgb(134, 25, 64);
            btnInventario.Location = new Point(55, 301);
            btnInventario.Name = "btnInventario";
            btnInventario.Size = new Size(197, 41);
            btnInventario.TabIndex = 36;
            btnInventario.Text = "Inventario";
            btnInventario.UseVisualStyleBackColor = true;
            btnInventario.Click += btnInventario_Click;
            // 
            // btnConfig
            // 
            btnConfig.BackgroundImage = (Image)resources.GetObject("btnConfig.BackgroundImage");
            btnConfig.BackgroundImageLayout = ImageLayout.Stretch;
            btnConfig.FlatAppearance.BorderSize = 0;
            btnConfig.FlatAppearance.MouseOverBackColor = Color.FromArgb(254, 169, 190);
            btnConfig.FlatStyle = FlatStyle.Flat;
            btnConfig.Font = new Font("KG Red Hands", 12.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnConfig.ForeColor = Color.FromArgb(134, 25, 64);
            btnConfig.Location = new Point(55, 418);
            btnConfig.Name = "btnConfig";
            btnConfig.Size = new Size(197, 41);
            btnConfig.TabIndex = 37;
            btnConfig.Text = "Configuración";
            btnConfig.UseVisualStyleBackColor = true;
            btnConfig.Click += btnConfig_Click;
            // 
            // btnCotizacion
            // 
            btnCotizacion.BackgroundImage = (Image)resources.GetObject("btnCotizacion.BackgroundImage");
            btnCotizacion.BackgroundImageLayout = ImageLayout.Stretch;
            btnCotizacion.FlatAppearance.BorderSize = 0;
            btnCotizacion.FlatAppearance.MouseOverBackColor = Color.FromArgb(254, 169, 190);
            btnCotizacion.FlatStyle = FlatStyle.Flat;
            btnCotizacion.Font = new Font("KG Red Hands", 12.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCotizacion.ForeColor = Color.White;
            btnCotizacion.Location = new Point(55, 361);
            btnCotizacion.Name = "btnCotizacion";
            btnCotizacion.Size = new Size(197, 41);
            btnCotizacion.TabIndex = 34;
            btnCotizacion.Text = "Cotización";
            btnCotizacion.UseVisualStyleBackColor = true;
            // 
            // FmCotizador
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 700);
            Controls.Add(panel1);
            Controls.Add(panel4);
            Controls.Add(panel2);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            Name = "FmCotizador";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FmCotizador";
            Load += FmCotizador_Load;
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel1.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            contextMenuStrip1.ResumeLayout(false);
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label2;
        private Button button5;
        private Label label1;
        private Button btnlogo;
        private Panel panel3;
        private Panel panel1;
        private Button btnMinimizar;
        private Button btnCerrar;
        private Panel panel4;
        private Label label3;
        private Panel panel2;
        private Label label4;
        private Label label5;
        private ComboBox cmbMateriales;
        private ListBox listBox1;
        private TextBox txtCantM;
        private TextBox txtCantH;
        private TextBox txtPrecioH;
        private Panel panel5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label lblTotalObra;
        private Panel panel6;
        private Panel panel7;
        private Label lblTotal;
        private Label label11;
        private Label label13;
        private Label label12;
        private Label label15;
        private Label lblMat;
        private Label label14;
        private Button btnAgMaterial;
        private Label label16;
        private Panel panel8;
        private TextBox txtGanancia;
        private Label label18;
        private Label lblSub;
        private PictureBox pictureBox5;
        private PictureBox pictureBox4;
        private PictureBox pictureBox3;
        private Button btnInicio;
        private PictureBox pictureBox2;
        private Button btnPedidos;
        private PictureBox pictureBox1;
        private Button btnInventario;
        private Button btnConfig;
        private Button btnCotizacion;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem eliminarMaterialToolStripMenuItem;
    }
}
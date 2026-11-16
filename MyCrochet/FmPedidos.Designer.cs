namespace MyCrochet
{
    partial class FmPedidos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FmPedidos));
            btnMinimizar = new Button();
            panel4 = new Panel();
            label5 = new Label();
            label4 = new Label();
            label6 = new Label();
            btnNuevoPed = new Button();
            cmbEstadoFiltro = new ComboBox();
            cmbTipoFiltro = new ComboBox();
            txtBusc = new TextBox();
            label3 = new Label();
            label2 = new Label();
            dataGridViewPedidos = new DataGridView();
            EditorPedidos = new ContextMenuStrip(components);
            VerPedido = new ToolStripMenuItem();
            ModificarPedido = new ToolStripMenuItem();
            eliminarPedido = new ToolStripMenuItem();
            panel1 = new Panel();
            btnCerrar = new Button();
            panel3 = new Panel();
            label1 = new Label();
            btnlogo = new Button();
            button5 = new Button();
            panel2 = new Panel();
            pictureBox5 = new PictureBox();
            pictureBox4 = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            btnConfig = new Button();
            btnCotizacion = new Button();
            btnInventario = new Button();
            btnPedidos = new Button();
            btnInicio = new Button();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPedidos).BeginInit();
            EditorPedidos.SuspendLayout();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
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
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(255, 247, 248);
            panel4.Controls.Add(label5);
            panel4.Controls.Add(label4);
            panel4.Controls.Add(label6);
            panel4.Controls.Add(btnNuevoPed);
            panel4.Controls.Add(cmbEstadoFiltro);
            panel4.Controls.Add(cmbTipoFiltro);
            panel4.Controls.Add(txtBusc);
            panel4.Controls.Add(label3);
            panel4.Controls.Add(label2);
            panel4.Controls.Add(dataGridViewPedidos);
            panel4.Location = new Point(284, 40);
            panel4.Name = "panel4";
            panel4.Size = new Size(804, 646);
            panel4.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("KG Red Hands", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(134, 25, 64);
            label5.Location = new Point(415, 156);
            label5.Name = "label5";
            label5.Size = new Size(140, 19);
            label5.TabIndex = 54;
            label5.Text = "Estado del Pedido:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("KG Red Hands", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(134, 25, 64);
            label4.Location = new Point(270, 156);
            label4.Name = "label4";
            label4.Size = new Size(117, 19);
            label4.TabIndex = 53;
            label4.Text = "Tipo de Pedido:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("KG Red Hands", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.FromArgb(134, 25, 64);
            label6.Location = new Point(76, 156);
            label6.Name = "label6";
            label6.Size = new Size(120, 19);
            label6.TabIndex = 52;
            label6.Text = "Buscar Pedido...";
            // 
            // btnNuevoPed
            // 
            btnNuevoPed.BackgroundImage = (Image)resources.GetObject("btnNuevoPed.BackgroundImage");
            btnNuevoPed.BackgroundImageLayout = ImageLayout.Stretch;
            btnNuevoPed.FlatAppearance.BorderSize = 0;
            btnNuevoPed.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 247, 248);
            btnNuevoPed.FlatStyle = FlatStyle.Flat;
            btnNuevoPed.Font = new Font("KG Red Hands", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnNuevoPed.ForeColor = Color.FromArgb(134, 25, 64);
            btnNuevoPed.Location = new Point(590, 160);
            btnNuevoPed.Name = "btnNuevoPed";
            btnNuevoPed.Size = new Size(165, 41);
            btnNuevoPed.TabIndex = 51;
            btnNuevoPed.Text = "Nuevo Pedido";
            btnNuevoPed.UseVisualStyleBackColor = true;
            btnNuevoPed.Click += btnNuevoPed_Click;
            // 
            // cmbEstadoFiltro
            // 
            cmbEstadoFiltro.BackColor = Color.FromArgb(255, 247, 248);
            cmbEstadoFiltro.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstadoFiltro.Font = new Font("KG Red Hands", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbEstadoFiltro.FormattingEnabled = true;
            cmbEstadoFiltro.Location = new Point(415, 178);
            cmbEstadoFiltro.Name = "cmbEstadoFiltro";
            cmbEstadoFiltro.Size = new Size(140, 24);
            cmbEstadoFiltro.TabIndex = 41;
            cmbEstadoFiltro.SelectedIndexChanged += cmbEstadoFiltro_SelectedIndexChanged;
            // 
            // cmbTipoFiltro
            // 
            cmbTipoFiltro.BackColor = Color.FromArgb(255, 247, 248);
            cmbTipoFiltro.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoFiltro.Font = new Font("KG Red Hands", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbTipoFiltro.FormattingEnabled = true;
            cmbTipoFiltro.Location = new Point(270, 178);
            cmbTipoFiltro.Name = "cmbTipoFiltro";
            cmbTipoFiltro.Size = new Size(139, 24);
            cmbTipoFiltro.TabIndex = 40;
            cmbTipoFiltro.SelectedIndexChanged += cmbTipoFiltro_SelectedIndexChanged;
            // 
            // txtBusc
            // 
            txtBusc.Location = new Point(76, 178);
            txtBusc.Name = "txtBusc";
            txtBusc.Size = new Size(176, 23);
            txtBusc.TabIndex = 9;
            txtBusc.TextChanged += txtBusc_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.FromArgb(254, 169, 190);
            label3.Font = new Font("Segoe UI", 2.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(134, 25, 64);
            label3.Location = new Point(49, 109);
            label3.Margin = new Padding(1, 0, 3, 0);
            label3.Name = "label3";
            label3.Size = new Size(706, 4);
            label3.TabIndex = 8;
            label3.Text = resources.GetString("label3.Text");
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Super Mindset", 48F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(134, 25, 64);
            label2.Location = new Point(149, 41);
            label2.Name = "label2";
            label2.Size = new Size(516, 68);
            label2.TabIndex = 7;
            label2.Text = "Gestión de Pedidos";
            // 
            // dataGridViewPedidos
            // 
            dataGridViewPedidos.BackgroundColor = Color.FromArgb(251, 233, 233);
            dataGridViewPedidos.BorderStyle = BorderStyle.None;
            dataGridViewPedidos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewPedidos.ContextMenuStrip = EditorPedidos;
            dataGridViewPedidos.GridColor = SystemColors.WindowText;
            dataGridViewPedidos.Location = new Point(49, 234);
            dataGridViewPedidos.Name = "dataGridViewPedidos";
            dataGridViewPedidos.ScrollBars = ScrollBars.Vertical;
            dataGridViewPedidos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewPedidos.Size = new Size(706, 371);
            dataGridViewPedidos.TabIndex = 3;
            dataGridViewPedidos.CellMouseDown += dataGridViewPedidos_CellMouseDown;
            dataGridViewPedidos.CellMouseUp += dataGridViewPedidos_CellMouseUp;
            // 
            // EditorPedidos
            // 
            EditorPedidos.Items.AddRange(new ToolStripItem[] { VerPedido, ModificarPedido, eliminarPedido });
            EditorPedidos.Name = "contextMenuStrip1";
            EditorPedidos.Size = new Size(166, 70);
            // 
            // VerPedido
            // 
            VerPedido.Name = "VerPedido";
            VerPedido.Size = new Size(165, 22);
            VerPedido.Text = "Ver Pedido";
            VerPedido.Click += VerPedido_Click;
            // 
            // ModificarPedido
            // 
            ModificarPedido.Name = "ModificarPedido";
            ModificarPedido.Size = new Size(165, 22);
            ModificarPedido.Text = "Modificar Pedido";
            ModificarPedido.Click += ModificarPedido_Click;
            // 
            // eliminarPedido
            // 
            eliminarPedido.Name = "eliminarPedido";
            eliminarPedido.Size = new Size(165, 22);
            eliminarPedido.Text = "Eliminar Pedido";
            eliminarPedido.Click += eliminarPedido_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(254, 169, 190);
            panel1.Controls.Add(btnMinimizar);
            panel1.Controls.Add(btnCerrar);
            panel1.Location = new Point(-1, -1);
            panel1.Name = "panel1";
            panel1.Size = new Size(1102, 29);
            panel1.TabIndex = 5;
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
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(254, 169, 190);
            panel2.Controls.Add(pictureBox5);
            panel2.Controls.Add(pictureBox4);
            panel2.Controls.Add(pictureBox3);
            panel2.Controls.Add(pictureBox2);
            panel2.Controls.Add(pictureBox1);
            panel2.Controls.Add(btnConfig);
            panel2.Controls.Add(btnCotizacion);
            panel2.Controls.Add(btnInventario);
            panel2.Controls.Add(btnPedidos);
            panel2.Controls.Add(btnInicio);
            panel2.Controls.Add(button5);
            panel2.Controls.Add(panel3);
            panel2.Location = new Point(-1, 24);
            panel2.Name = "panel2";
            panel2.Size = new Size(269, 678);
            panel2.TabIndex = 6;
            // 
            // pictureBox5
            // 
            pictureBox5.BackgroundImage = (Image)resources.GetObject("pictureBox5.BackgroundImage");
            pictureBox5.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox5.Image = (Image)resources.GetObject("pictureBox5.Image");
            pictureBox5.Location = new Point(11, 412);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(38, 34);
            pictureBox5.TabIndex = 22;
            pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.BackgroundImage = (Image)resources.GetObject("pictureBox4.BackgroundImage");
            pictureBox4.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(11, 355);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(38, 34);
            pictureBox4.TabIndex = 21;
            pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.BackgroundImage = (Image)resources.GetObject("pictureBox3.BackgroundImage");
            pictureBox3.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(11, 295);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(38, 34);
            pictureBox3.TabIndex = 20;
            pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImage = (Image)resources.GetObject("pictureBox2.BackgroundImage");
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(11, 238);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(38, 34);
            pictureBox2.TabIndex = 19;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(11, 181);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(38, 34);
            pictureBox1.TabIndex = 18;
            pictureBox1.TabStop = false;
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
            btnConfig.Location = new Point(55, 405);
            btnConfig.Name = "btnConfig";
            btnConfig.Size = new Size(197, 41);
            btnConfig.TabIndex = 17;
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
            btnCotizacion.ForeColor = Color.FromArgb(134, 25, 64);
            btnCotizacion.Location = new Point(55, 348);
            btnCotizacion.Name = "btnCotizacion";
            btnCotizacion.Size = new Size(197, 41);
            btnCotizacion.TabIndex = 14;
            btnCotizacion.Text = "Cotización";
            btnCotizacion.UseVisualStyleBackColor = true;
            btnCotizacion.Click += btnCotizacion_Click;
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
            btnInventario.Location = new Point(55, 288);
            btnInventario.Name = "btnInventario";
            btnInventario.Size = new Size(197, 41);
            btnInventario.TabIndex = 16;
            btnInventario.Text = "Inventario";
            btnInventario.UseVisualStyleBackColor = true;
            btnInventario.Click += btnInventario_Click;
            // 
            // btnPedidos
            // 
            btnPedidos.BackgroundImage = (Image)resources.GetObject("btnPedidos.BackgroundImage");
            btnPedidos.BackgroundImageLayout = ImageLayout.Stretch;
            btnPedidos.FlatAppearance.BorderSize = 0;
            btnPedidos.FlatAppearance.MouseOverBackColor = Color.FromArgb(254, 169, 190);
            btnPedidos.FlatStyle = FlatStyle.Flat;
            btnPedidos.Font = new Font("KG Red Hands", 12.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnPedidos.ForeColor = Color.White;
            btnPedidos.Location = new Point(55, 231);
            btnPedidos.Name = "btnPedidos";
            btnPedidos.Size = new Size(197, 41);
            btnPedidos.TabIndex = 15;
            btnPedidos.Text = "Pedidos";
            btnPedidos.UseVisualStyleBackColor = true;
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
            btnInicio.Location = new Point(55, 174);
            btnInicio.Name = "btnInicio";
            btnInicio.Size = new Size(197, 41);
            btnInicio.TabIndex = 13;
            btnInicio.Text = "Inicio";
            btnInicio.UseVisualStyleBackColor = true;
            btnInicio.Click += btnInicio_Click;
            // 
            // FmPedidos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 700);
            Controls.Add(panel4);
            Controls.Add(panel1);
            Controls.Add(panel2);
            FormBorderStyle = FormBorderStyle.None;
            MinimizeBox = false;
            Name = "FmPedidos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FmPedidos";
            Load += FmPedidos_Load;
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPedidos).EndInit();
            EditorPedidos.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnMinimizar;
        private Panel panel4;
        private Panel panel1;
        private Button btnCerrar;
        private DataGridView dataGridViewPedidos;
        private Label label3;
        private Label label2;
        private TextBox txtBusc;
        private ContextMenuStrip EditorPedidos;
        private ToolStripMenuItem VerPedido;
        private ToolStripMenuItem ModificarPedido;
        private ComboBox cmbEstadoFiltro;
        private ComboBox cmbTipoFiltro;
        private Button btnNuevoPed;
        private Label label5;
        private Label label4;
        private Label label6;
        private Panel panel3;
        private Label label1;
        private Button btnlogo;
        private Button button5;
        private Panel panel2;
        private PictureBox pictureBox5;
        private PictureBox pictureBox4;
        private PictureBox pictureBox3;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private Button btnConfig;
        private Button btnCotizacion;
        private Button btnInventario;
        private Button btnPedidos;
        private Button btnInicio;
        private ToolStripMenuItem eliminarPedido;
    }
}
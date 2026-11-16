namespace MyCrochet
{
    partial class FmUsuarios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FmUsuarios));
            panel1 = new Panel();
            btnCerrar = new Button();
            label3 = new Label();
            label6 = new Label();
            dataGridView1 = new DataGridView();
            contextMenuStrip1 = new ContextMenuStrip(components);
            eliminarPerfilToolStripMenuItem = new ToolStripMenuItem();
            btnGuardar = new Button();
            btnNewPerfil = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btnCerrar);
            panel1.Location = new Point(1, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(455, 33);
            panel1.TabIndex = 57;
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
            btnCerrar.Location = new Point(415, 8);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(26, 22);
            btnCerrar.TabIndex = 52;
            btnCerrar.UseVisualStyleBackColor = false;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.FromArgb(254, 169, 190);
            label3.Font = new Font("Segoe UI", 2.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(134, 25, 64);
            label3.Location = new Point(1, 35);
            label3.Margin = new Padding(1, 0, 3, 0);
            label3.Name = "label3";
            label3.Size = new Size(453, 4);
            label3.TabIndex = 62;
            label3.Text = resources.GetString("label3.Text");
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Super Mindset", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.FromArgb(134, 25, 64);
            label6.Location = new Point(174, 51);
            label6.Name = "label6";
            label6.Size = new Size(106, 30);
            label6.TabIndex = 61;
            label6.Text = "Perfiles";
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = SystemColors.ButtonHighlight;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.ContextMenuStrip = contextMenuStrip1;
            dataGridView1.GridColor = SystemColors.InactiveBorder;
            dataGridView1.Location = new Point(24, 84);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ScrollBars = ScrollBars.Vertical;
            dataGridView1.Size = new Size(407, 170);
            dataGridView1.TabIndex = 63;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { eliminarPerfilToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(148, 26);
            // 
            // eliminarPerfilToolStripMenuItem
            // 
            eliminarPerfilToolStripMenuItem.Name = "eliminarPerfilToolStripMenuItem";
            eliminarPerfilToolStripMenuItem.Size = new Size(147, 22);
            eliminarPerfilToolStripMenuItem.Text = "Eliminar Perfil";
            eliminarPerfilToolStripMenuItem.Click += eliminarPerfilToolStripMenuItem_Click;
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
            btnGuardar.Location = new Point(122, 274);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(145, 26);
            btnGuardar.TabIndex = 71;
            btnGuardar.Text = "Guardar Cambios";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnAgregar_Click;
            // 
            // btnNewPerfil
            // 
            btnNewPerfil.BackColor = Color.FromArgb(134, 25, 64);
            btnNewPerfil.BackgroundImageLayout = ImageLayout.Stretch;
            btnNewPerfil.FlatAppearance.BorderSize = 0;
            btnNewPerfil.FlatAppearance.MouseOverBackColor = Color.FromArgb(134, 25, 64);
            btnNewPerfil.FlatStyle = FlatStyle.Flat;
            btnNewPerfil.Font = new Font("KG Red Hands", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnNewPerfil.ForeColor = Color.White;
            btnNewPerfil.Location = new Point(273, 275);
            btnNewPerfil.Name = "btnNewPerfil";
            btnNewPerfil.Size = new Size(158, 26);
            btnNewPerfil.TabIndex = 72;
            btnNewPerfil.Text = "Agregar Nuevo Perfil";
            btnNewPerfil.UseVisualStyleBackColor = false;
            btnNewPerfil.Click += btnNewPerfil_Click;
            // 
            // FmUsuarios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(251, 233, 233);
            ClientSize = new Size(454, 313);
            Controls.Add(btnNewPerfil);
            Controls.Add(btnGuardar);
            Controls.Add(dataGridView1);
            Controls.Add(label3);
            Controls.Add(label6);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            Name = "FmUsuarios";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FmUsuarios";
            Load += FmUsuarios_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button btnCerrar;
        private Label label3;
        private Label label6;
        private DataGridView dataGridView1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem eliminarPerfilToolStripMenuItem;
        private Button btnGuardar;
        private Button btnNewPerfil;
    }
}
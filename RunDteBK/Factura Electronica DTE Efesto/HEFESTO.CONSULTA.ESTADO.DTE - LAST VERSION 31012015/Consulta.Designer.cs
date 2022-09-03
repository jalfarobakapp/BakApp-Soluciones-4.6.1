namespace HEFESTO.CONSULTA.ESTADO.DTE
{
    partial class Consulta
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Consulta));
            this.cmbCertificados = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.cmpNombre = new System.Windows.Forms.TextBox();
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            this.listView1 = new System.Windows.Forms.ListView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnProcesar = new System.Windows.Forms.Button();
            this.barrProgres = new System.Windows.Forms.ProgressBar();
            this.cmpDetalle = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tCertificado = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.cmpRutCert = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tProceso = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.consultarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tCertificado.SuspendLayout();
            this.tProceso.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbCertificados
            // 
            this.cmbCertificados.FormattingEnabled = true;
            this.cmbCertificados.Location = new System.Drawing.Point(6, 35);
            this.cmbCertificados.Name = "cmbCertificados";
            this.cmbCertificados.Size = new System.Drawing.Size(505, 21);
            this.cmbCertificados.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(410, 31);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Seleccionar archivo";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmpNombre
            // 
            this.cmpNombre.Location = new System.Drawing.Point(7, 33);
            this.cmpNombre.Name = "cmpNombre";
            this.cmpNombre.ReadOnly = true;
            this.cmpNombre.Size = new System.Drawing.Size(390, 20);
            this.cmpNombre.TabIndex = 0;
            // 
            // openFile
            // 
            this.openFile.FileName = "openFileDialog1";
            // 
            // listView1
            // 
            this.listView1.ContextMenuStrip = this.contextMenuStrip1;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.Location = new System.Drawing.Point(7, 62);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(504, 215);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.consultarToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 48);
            this.contextMenuStrip1.Text = "Consultar";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(416, 527);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(106, 23);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnProcesar
            // 
            this.btnProcesar.Location = new System.Drawing.Point(302, 527);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(107, 23);
            this.btnProcesar.TabIndex = 4;
            this.btnProcesar.Text = "Procesar";
            this.btnProcesar.UseVisualStyleBackColor = true;
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
            // 
            // barrProgres
            // 
            this.barrProgres.Location = new System.Drawing.Point(12, 526);
            this.barrProgres.Name = "barrProgres";
            this.barrProgres.Size = new System.Drawing.Size(282, 23);
            this.barrProgres.TabIndex = 5;
            // 
            // cmpDetalle
            // 
            this.cmpDetalle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.cmpDetalle.Location = new System.Drawing.Point(7, 283);
            this.cmpDetalle.Multiline = true;
            this.cmpDetalle.Name = "cmpDetalle";
            this.cmpDetalle.Size = new System.Drawing.Size(504, 57);
            this.cmpDetalle.TabIndex = 6;
            this.cmpDetalle.Text = "Haga doble click sobre un  item de la grilla para ver el detalle.";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(8, 9);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(521, 107);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tCertificado);
            this.tabControl1.Controls.Add(this.tProceso);
            this.tabControl1.Location = new System.Drawing.Point(8, 134);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(525, 372);
            this.tabControl1.TabIndex = 8;
            // 
            // tCertificado
            // 
            this.tCertificado.BackColor = System.Drawing.SystemColors.Control;
            this.tCertificado.Controls.Add(this.label3);
            this.tCertificado.Controls.Add(this.cmpRutCert);
            this.tCertificado.Controls.Add(this.label1);
            this.tCertificado.Controls.Add(this.cmbCertificados);
            this.tCertificado.Location = new System.Drawing.Point(4, 22);
            this.tCertificado.Name = "tCertificado";
            this.tCertificado.Padding = new System.Windows.Forms.Padding(3);
            this.tCertificado.Size = new System.Drawing.Size(517, 346);
            this.tCertificado.TabIndex = 0;
            this.tCertificado.Text = "Certificado";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Rut del Certificado";
            // 
            // cmpRutCert
            // 
            this.cmpRutCert.Location = new System.Drawing.Point(9, 92);
            this.cmpRutCert.Name = "cmpRutCert";
            this.cmpRutCert.Size = new System.Drawing.Size(170, 20);
            this.cmpRutCert.TabIndex = 2;
            this.cmpRutCert.Text = "9580332-6";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(246, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Seleccione el certificado a utilizar en las consultas.";
            // 
            // tProceso
            // 
            this.tProceso.BackColor = System.Drawing.SystemColors.Control;
            this.tProceso.Controls.Add(this.label2);
            this.tProceso.Controls.Add(this.button1);
            this.tProceso.Controls.Add(this.cmpDetalle);
            this.tProceso.Controls.Add(this.cmpNombre);
            this.tProceso.Controls.Add(this.listView1);
            this.tProceso.Location = new System.Drawing.Point(4, 22);
            this.tProceso.Name = "tProceso";
            this.tProceso.Padding = new System.Windows.Forms.Padding(3);
            this.tProceso.Size = new System.Drawing.Size(517, 346);
            this.tProceso.TabIndex = 1;
            this.tProceso.Text = "Proceso";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(276, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Seleccione el archivo csv con la información a consultar.";
            // 
            // consultarToolStripMenuItem
            // 
            this.consultarToolStripMenuItem.Name = "consultarToolStripMenuItem";
            this.consultarToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.consultarToolStripMenuItem.Text = "Consultar";
            this.consultarToolStripMenuItem.Click += new System.EventHandler(this.consultarToolStripMenuItem_Click);
            // 
            // Consulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 561);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.barrProgres);
            this.Controls.Add(this.btnProcesar);
            this.Controls.Add(this.btnCancelar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Consulta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HEFESTO - Consulta estado de un DTE";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tCertificado.ResumeLayout(false);
            this.tCertificado.PerformLayout();
            this.tProceso.ResumeLayout(false);
            this.tProceso.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbCertificados;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox cmpNombre;
        private System.Windows.Forms.OpenFileDialog openFile;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnProcesar;
        private System.Windows.Forms.ProgressBar barrProgres;
        private System.Windows.Forms.TextBox cmpDetalle;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tCertificado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tProceso;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox cmpRutCert;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem consultarToolStripMenuItem;
 
    }
}


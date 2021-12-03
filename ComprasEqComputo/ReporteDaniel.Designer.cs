
namespace ComprasEqComputo
{
    partial class ReporteDaniel
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReporteDaniel));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.solicita = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ticket = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sisac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sisacempresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sisaccomprador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sisacestatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sisaccodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sisacdescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.navsolicitud = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.navnotacomprador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.navautorizador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.navaprobado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.navfechaaprobado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.navpedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.exportarAExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.solicita,
            this.ticket,
            this.sisac,
            this.sisacempresa,
            this.sisaccomprador,
            this.sisacestatus,
            this.sisaccodigo,
            this.sisacdescripcion,
            this.navsolicitud,
            this.navnotacomprador,
            this.navautorizador,
            this.navaprobado,
            this.navfechaaprobado,
            this.navpedido});
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(0, 24);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(1374, 562);
            this.dataGridView1.TabIndex = 3;
            // 
            // solicita
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.solicita.DefaultCellStyle = dataGridViewCellStyle11;
            this.solicita.HeaderText = "Solicita";
            this.solicita.Name = "solicita";
            this.solicita.ReadOnly = true;
            this.solicita.Width = 70;
            // 
            // ticket
            // 
            this.ticket.HeaderText = "Ticket";
            this.ticket.Name = "ticket";
            this.ticket.ReadOnly = true;
            // 
            // sisac
            // 
            this.sisac.HeaderText = "SISAC Ticket";
            this.sisac.Name = "sisac";
            this.sisac.ReadOnly = true;
            // 
            // sisacempresa
            // 
            this.sisacempresa.HeaderText = "SISAC Empresa";
            this.sisacempresa.Name = "sisacempresa";
            this.sisacempresa.ReadOnly = true;
            // 
            // sisaccomprador
            // 
            this.sisaccomprador.HeaderText = "SISAC Comprador";
            this.sisaccomprador.Name = "sisaccomprador";
            this.sisaccomprador.ReadOnly = true;
            // 
            // sisacestatus
            // 
            this.sisacestatus.HeaderText = "SISAC Estatus";
            this.sisacestatus.Name = "sisacestatus";
            this.sisacestatus.ReadOnly = true;
            // 
            // sisaccodigo
            // 
            this.sisaccodigo.HeaderText = "SISAC Codigo";
            this.sisaccodigo.Name = "sisaccodigo";
            this.sisaccodigo.ReadOnly = true;
            // 
            // sisacdescripcion
            // 
            this.sisacdescripcion.HeaderText = "SISAC Descripcion";
            this.sisacdescripcion.Name = "sisacdescripcion";
            this.sisacdescripcion.ReadOnly = true;
            // 
            // navsolicitud
            // 
            this.navsolicitud.HeaderText = "NAV Solicitud";
            this.navsolicitud.Name = "navsolicitud";
            this.navsolicitud.ReadOnly = true;
            // 
            // navnotacomprador
            // 
            this.navnotacomprador.HeaderText = "NAV Nota de Comprador";
            this.navnotacomprador.Name = "navnotacomprador";
            this.navnotacomprador.ReadOnly = true;
            // 
            // navautorizador
            // 
            this.navautorizador.HeaderText = "NAV Autorizador";
            this.navautorizador.Name = "navautorizador";
            this.navautorizador.ReadOnly = true;
            // 
            // navaprobado
            // 
            this.navaprobado.HeaderText = "NAV Aprobado";
            this.navaprobado.Name = "navaprobado";
            this.navaprobado.ReadOnly = true;
            // 
            // navfechaaprobado
            // 
            this.navfechaaprobado.HeaderText = "NAV Fecha Aprobado";
            this.navfechaaprobado.Name = "navfechaaprobado";
            this.navfechaaprobado.ReadOnly = true;
            // 
            // navpedido
            // 
            this.navpedido.HeaderText = "NAV Pedido";
            this.navpedido.Name = "navpedido";
            this.navpedido.ReadOnly = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportarAExcelToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1374, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // exportarAExcelToolStripMenuItem
            // 
            this.exportarAExcelToolStripMenuItem.Name = "exportarAExcelToolStripMenuItem";
            this.exportarAExcelToolStripMenuItem.Size = new System.Drawing.Size(102, 20);
            this.exportarAExcelToolStripMenuItem.Text = "Exportar a Excel";
            this.exportarAExcelToolStripMenuItem.Click += new System.EventHandler(this.exportarAExcelToolStripMenuItem_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(551, 153);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(273, 281);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // ReporteDaniel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1374, 586);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ReporteDaniel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte SiTTis Compras General";
            this.Load += new System.EventHandler(this.ReporteDaniel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exportarAExcelToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn solicita;
        private System.Windows.Forms.DataGridViewTextBoxColumn ticket;
        private System.Windows.Forms.DataGridViewTextBoxColumn sisac;
        private System.Windows.Forms.DataGridViewTextBoxColumn sisacempresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn sisaccomprador;
        private System.Windows.Forms.DataGridViewTextBoxColumn sisacestatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn sisaccodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn sisacdescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn navsolicitud;
        private System.Windows.Forms.DataGridViewTextBoxColumn navnotacomprador;
        private System.Windows.Forms.DataGridViewTextBoxColumn navautorizador;
        private System.Windows.Forms.DataGridViewTextBoxColumn navaprobado;
        private System.Windows.Forms.DataGridViewTextBoxColumn navfechaaprobado;
        private System.Windows.Forms.DataGridViewTextBoxColumn navpedido;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
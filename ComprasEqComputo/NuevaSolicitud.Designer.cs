
namespace ComprasEqComputo
{
    partial class NuevaSolicitud
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NuevaSolicitud));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.numempleado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apepat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apemat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.base1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.puesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.empresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombrecompleto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ubicacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.departamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.direccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buscar = new System.Windows.Forms.TextBox();
            this.buscar2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.numempleado2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apepat2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apemat2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cc2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.base2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.puesto2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.empresa2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombrecompleto2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numempleado,
            this.nombre,
            this.apepat,
            this.apemat,
            this.cc,
            this.base1,
            this.puesto,
            this.empresa,
            this.nombrecompleto,
            this.ubicacion,
            this.departamento,
            this.direccion});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(3, 30);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(537, 245);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // numempleado
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            this.numempleado.DefaultCellStyle = dataGridViewCellStyle2;
            this.numempleado.HeaderText = "ID";
            this.numempleado.Name = "numempleado";
            this.numempleado.ReadOnly = true;
            this.numempleado.Visible = false;
            this.numempleado.Width = 50;
            // 
            // nombre
            // 
            this.nombre.HeaderText = "Nombre";
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            this.nombre.Visible = false;
            // 
            // apepat
            // 
            this.apepat.HeaderText = "apepat";
            this.apepat.Name = "apepat";
            this.apepat.ReadOnly = true;
            this.apepat.Visible = false;
            // 
            // apemat
            // 
            this.apemat.HeaderText = "apemat";
            this.apemat.Name = "apemat";
            this.apemat.ReadOnly = true;
            this.apemat.Visible = false;
            // 
            // cc
            // 
            this.cc.HeaderText = "cc";
            this.cc.Name = "cc";
            this.cc.ReadOnly = true;
            this.cc.Visible = false;
            // 
            // base1
            // 
            this.base1.HeaderText = "base1";
            this.base1.Name = "base1";
            this.base1.ReadOnly = true;
            this.base1.Visible = false;
            // 
            // puesto
            // 
            this.puesto.HeaderText = "puesto";
            this.puesto.Name = "puesto";
            this.puesto.ReadOnly = true;
            this.puesto.Visible = false;
            // 
            // empresa
            // 
            this.empresa.HeaderText = "empresa";
            this.empresa.Name = "empresa";
            this.empresa.ReadOnly = true;
            this.empresa.Visible = false;
            // 
            // nombrecompleto
            // 
            this.nombrecompleto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nombrecompleto.HeaderText = "Nombre";
            this.nombrecompleto.Name = "nombrecompleto";
            this.nombrecompleto.ReadOnly = true;
            // 
            // ubicacion
            // 
            this.ubicacion.HeaderText = "Ubicacion";
            this.ubicacion.Name = "ubicacion";
            this.ubicacion.ReadOnly = true;
            this.ubicacion.Visible = false;
            // 
            // departamento
            // 
            this.departamento.HeaderText = "Departamento";
            this.departamento.Name = "departamento";
            this.departamento.ReadOnly = true;
            this.departamento.Visible = false;
            // 
            // direccion
            // 
            this.direccion.HeaderText = "Direccion";
            this.direccion.Name = "direccion";
            this.direccion.ReadOnly = true;
            this.direccion.Visible = false;
            // 
            // buscar
            // 
            this.buscar.Location = new System.Drawing.Point(92, 4);
            this.buscar.Name = "buscar";
            this.buscar.Size = new System.Drawing.Size(448, 20);
            this.buscar.TabIndex = 1;
            this.buscar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyUp);
            // 
            // buscar2
            // 
            this.buscar2.Location = new System.Drawing.Point(86, 4);
            this.buscar2.Name = "buscar2";
            this.buscar2.Size = new System.Drawing.Size(451, 20);
            this.buscar2.TabIndex = 2;
            this.buscar2.TextChanged += new System.EventHandler(this.buscar2_TextChanged);
            this.buscar2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.buscar2_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Comprar a:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Lo solicita:";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numempleado2,
            this.nombre2,
            this.apepat2,
            this.apemat2,
            this.cc2,
            this.base2,
            this.puesto2,
            this.empresa2,
            this.nombrecompleto2});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView2.EnableHeadersVisualStyles = false;
            this.dataGridView2.Location = new System.Drawing.Point(3, 30);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.Size = new System.Drawing.Size(537, 245);
            this.dataGridView2.TabIndex = 10;
            this.dataGridView2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellClick);
            // 
            // numempleado2
            // 
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            this.numempleado2.DefaultCellStyle = dataGridViewCellStyle5;
            this.numempleado2.HeaderText = "ID";
            this.numempleado2.Name = "numempleado2";
            this.numempleado2.ReadOnly = true;
            this.numempleado2.Visible = false;
            this.numempleado2.Width = 50;
            // 
            // nombre2
            // 
            this.nombre2.HeaderText = "nombre";
            this.nombre2.Name = "nombre2";
            this.nombre2.ReadOnly = true;
            this.nombre2.Visible = false;
            // 
            // apepat2
            // 
            this.apepat2.HeaderText = "apepat";
            this.apepat2.Name = "apepat2";
            this.apepat2.ReadOnly = true;
            this.apepat2.Visible = false;
            // 
            // apemat2
            // 
            this.apemat2.HeaderText = "apemat";
            this.apemat2.Name = "apemat2";
            this.apemat2.ReadOnly = true;
            this.apemat2.Visible = false;
            // 
            // cc2
            // 
            this.cc2.HeaderText = "cc";
            this.cc2.Name = "cc2";
            this.cc2.ReadOnly = true;
            this.cc2.Visible = false;
            // 
            // base2
            // 
            this.base2.HeaderText = "base1";
            this.base2.Name = "base2";
            this.base2.ReadOnly = true;
            this.base2.Visible = false;
            // 
            // puesto2
            // 
            this.puesto2.HeaderText = "puesto";
            this.puesto2.Name = "puesto2";
            this.puesto2.ReadOnly = true;
            this.puesto2.Visible = false;
            // 
            // empresa2
            // 
            this.empresa2.HeaderText = "empresa";
            this.empresa2.Name = "empresa2";
            this.empresa2.ReadOnly = true;
            this.empresa2.Visible = false;
            // 
            // nombrecompleto2
            // 
            this.nombrecompleto2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nombrecompleto2.HeaderText = "Nombre";
            this.nombrecompleto2.Name = "nombrecompleto2";
            this.nombrecompleto2.ReadOnly = true;
            // 
            // NuevaSolicitud
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 276);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buscar2);
            this.Controls.Add(this.buscar);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NuevaSolicitud";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nueva Solicitud";
            this.Load += new System.EventHandler(this.NuevaSolicitud_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox buscar;
        private System.Windows.Forms.TextBox buscar2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn numempleado2;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre2;
        private System.Windows.Forms.DataGridViewTextBoxColumn apepat2;
        private System.Windows.Forms.DataGridViewTextBoxColumn apemat2;
        private System.Windows.Forms.DataGridViewTextBoxColumn cc2;
        private System.Windows.Forms.DataGridViewTextBoxColumn base2;
        private System.Windows.Forms.DataGridViewTextBoxColumn puesto2;
        private System.Windows.Forms.DataGridViewTextBoxColumn empresa2;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombrecompleto2;
        private System.Windows.Forms.DataGridViewTextBoxColumn numempleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn apepat;
        private System.Windows.Forms.DataGridViewTextBoxColumn apemat;
        private System.Windows.Forms.DataGridViewTextBoxColumn cc;
        private System.Windows.Forms.DataGridViewTextBoxColumn base1;
        private System.Windows.Forms.DataGridViewTextBoxColumn puesto;
        private System.Windows.Forms.DataGridViewTextBoxColumn empresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombrecompleto;
        private System.Windows.Forms.DataGridViewTextBoxColumn ubicacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn departamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn direccion;
    }
}
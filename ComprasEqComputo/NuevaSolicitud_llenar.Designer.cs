
namespace ComprasEqComputo
{
    partial class NuevaSolicitud_llenar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NuevaSolicitud_llenar));
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.sittiusuario = new System.Windows.Forms.NumericUpDown();
            this.stock = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.text_nombre = new System.Windows.Forms.TextBox();
            this.text_puesto = new System.Windows.Forms.TextBox();
            this.text_cc = new System.Windows.Forms.TextBox();
            this.text_empresa = new System.Windows.Forms.TextBox();
            this.text_num = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.text_dep = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.text_dir = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.text_ubi = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tipo = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.sittiusuario)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Puesto:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Centro de Costos:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 180);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "Empresa:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 244);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 16);
            this.label8.TabIndex = 7;
            this.label8.Text = "SiTTi Usuario:";
            // 
            // sittiusuario
            // 
            this.sittiusuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sittiusuario.Location = new System.Drawing.Point(126, 242);
            this.sittiusuario.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.sittiusuario.Name = "sittiusuario";
            this.sittiusuario.Size = new System.Drawing.Size(83, 22);
            this.sittiusuario.TabIndex = 9;
            // 
            // stock
            // 
            this.stock.AutoSize = true;
            this.stock.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stock.Location = new System.Drawing.Point(234, 244);
            this.stock.Name = "stock";
            this.stock.Size = new System.Drawing.Size(131, 20);
            this.stock.TabIndex = 10;
            this.stock.Text = "¿Reponer Stock?";
            this.stock.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(86, 403);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(200, 35);
            this.button1.TabIndex = 13;
            this.button1.Text = "Guardar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // text_nombre
            // 
            this.text_nombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.text_nombre.Location = new System.Drawing.Point(81, 8);
            this.text_nombre.Name = "text_nombre";
            this.text_nombre.Size = new System.Drawing.Size(279, 20);
            this.text_nombre.TabIndex = 1;
            // 
            // text_puesto
            // 
            this.text_puesto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.text_puesto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.text_puesto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.text_puesto.Location = new System.Drawing.Point(78, 61);
            this.text_puesto.Name = "text_puesto";
            this.text_puesto.Size = new System.Drawing.Size(282, 20);
            this.text_puesto.TabIndex = 3;
            // 
            // text_cc
            // 
            this.text_cc.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.text_cc.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.text_cc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.text_cc.Location = new System.Drawing.Point(140, 89);
            this.text_cc.Name = "text_cc";
            this.text_cc.Size = new System.Drawing.Size(220, 20);
            this.text_cc.TabIndex = 4;
            // 
            // text_empresa
            // 
            this.text_empresa.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.text_empresa.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.text_empresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.text_empresa.Location = new System.Drawing.Point(86, 179);
            this.text_empresa.Name = "text_empresa";
            this.text_empresa.Size = new System.Drawing.Size(274, 20);
            this.text_empresa.TabIndex = 7;
            // 
            // text_num
            // 
            this.text_num.Location = new System.Drawing.Point(126, 34);
            this.text_num.Name = "text_num";
            this.text_num.ReadOnly = true;
            this.text_num.Size = new System.Drawing.Size(234, 20);
            this.text_num.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "No. Empleado:";
            // 
            // text_dep
            // 
            this.text_dep.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.text_dep.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.text_dep.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.text_dep.Location = new System.Drawing.Point(126, 119);
            this.text_dep.Name = "text_dep";
            this.text_dep.Size = new System.Drawing.Size(234, 20);
            this.text_dep.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "Departamento:";
            // 
            // text_dir
            // 
            this.text_dir.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.text_dir.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.text_dir.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.text_dir.Location = new System.Drawing.Point(96, 149);
            this.text_dir.Name = "text_dir";
            this.text_dir.Size = new System.Drawing.Size(266, 20);
            this.text_dir.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 150);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 16);
            this.label7.TabIndex = 13;
            this.label7.Text = "Direccion:";
            // 
            // text_ubi
            // 
            this.text_ubi.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.text_ubi.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.text_ubi.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.text_ubi.Location = new System.Drawing.Point(96, 209);
            this.text_ubi.Name = "text_ubi";
            this.text_ubi.Size = new System.Drawing.Size(264, 20);
            this.text_ubi.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(12, 210);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 16);
            this.label9.TabIndex = 15;
            this.label9.Text = "Ubicación:";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(15, 324);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(345, 70);
            this.richTextBox1.TabIndex = 12;
            this.richTextBox1.Text = "";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(12, 305);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(121, 16);
            this.label10.TabIndex = 17;
            this.label10.Text = "Comentarios T.I.";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(12, 276);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(44, 16);
            this.label11.TabIndex = 18;
            this.label11.Text = "Tipo:";
            // 
            // tipo
            // 
            this.tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tipo.FormattingEnabled = true;
            this.tipo.Location = new System.Drawing.Point(62, 275);
            this.tipo.Name = "tipo";
            this.tipo.Size = new System.Drawing.Size(147, 21);
            this.tipo.TabIndex = 11;
            // 
            // NuevaSolicitud_llenar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 447);
            this.Controls.Add(this.tipo);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.text_ubi);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.text_dir);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.text_dep);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.text_num);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.text_empresa);
            this.Controls.Add(this.text_cc);
            this.Controls.Add(this.text_puesto);
            this.Controls.Add(this.text_nombre);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.stock);
            this.Controls.Add(this.sittiusuario);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NuevaSolicitud_llenar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nueva Solicitud";
            this.Load += new System.EventHandler(this.NuevaSolicitud_llenar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sittiusuario)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown sittiusuario;
        private System.Windows.Forms.CheckBox stock;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox text_nombre;
        private System.Windows.Forms.TextBox text_puesto;
        private System.Windows.Forms.TextBox text_cc;
        private System.Windows.Forms.TextBox text_empresa;
        private System.Windows.Forms.TextBox text_num;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox text_dep;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox text_dir;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox text_ubi;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox tipo;
    }
}
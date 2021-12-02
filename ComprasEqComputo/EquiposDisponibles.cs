using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComprasEqComputo
{
    public partial class EquiposDisponibles : Form
    {
        public EquiposDisponibles()
        {
            InitializeComponent();
        }

        private void EquiposDisponibles_Load(object sender, EventArgs e)
        {
            if (Form1.lista_disponibles_usuario.Any())
            {
                foreach (String[] n in Form1.lista_disponibles_usuario)
                {
                    n[1] = (n[1] == "NO REGISTRADO") ? n[5] : n[1];
                    n[21] = (n[2] == "NO REGISTRADO") ? n[1] : n[21];
                    DateTime fecha_solicita = DateTime.Parse(n[12]);
                    dataGridView1.Rows.Add(n[0], n[24], n[21], n[15], fecha_solicita.ToShortDateString(), n[10], n[19]);
                    dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    Clipboard.SetText(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                }
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Form1.lista = 2;
                Form1.sitti_ti = dataGridView1.Rows[e.RowIndex].Cells["sitti_ti_id"].Value.ToString();
                Form1.cid = dataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToString();
                VerCompra vercompra = new VerCompra();
                vercompra.ShowDialog();
            }
        }
    }
}

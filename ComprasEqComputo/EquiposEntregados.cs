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
    public partial class EquiposEntregados : Form
    {
        public EquiposEntregados()
        {
            InitializeComponent();
        }

        private void EquiposEntregados_Load(object sender, EventArgs e)
        {
            buscar.Focus();
            if (Form1.lista_entregados.Any())
            {
                foreach (String[] n in Form1.lista_entregados)
                {
                    n[1] = (n[1] == "NO REGISTRADO") ? n[5] : n[1];
                    n[21] = (n[2] == "NO REGISTRADO") ? n[1] : n[21];
                    DateTime fecha_solicita = DateTime.Parse(n[12]);

                    dataGridView1.Rows.Add(n[0], n[23], n[24], n[15], fecha_solicita.ToString("yyyy/MM/dd"), n[10]);
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

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            dataGridView1.Rows.Clear();
            if (Form1.lista_entregados.Any())
            {
                foreach (String[] n in Form1.lista_entregados)
                {
                    n[1] = (n[1] == "NO REGISTRADO") ? n[5] : n[1];
                    n[21] = (n[2] == "NO REGISTRADO") ? n[1] : n[21];
                    DateTime fecha_solicita = DateTime.Parse(n[12]);

                    String buscar_usuario = n[23].ToString().ToUpper();
                    String buscar_economico = n[15].ToString().ToUpper();
                    String buscar_comprado_a = n[21].ToString().ToUpper();
                    String buscar_tipo = n[24].ToString().ToUpper();
                    if (buscar_usuario.Contains(buscar.Text.ToUpper()) || buscar_economico.Contains(buscar.Text.ToUpper()) || buscar_comprado_a.Contains(buscar.Text.ToUpper()) || buscar_tipo.Contains(buscar.Text.ToUpper()))
                    {
                        dataGridView1.Rows.Add(n[0], n[23], n[24], n[15], fecha_solicita.ToString("yyyy/MM/dd"), n[10]);
                    }
                }
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Form1.lista = 3;
                Form1.sitti_ti = dataGridView1.Rows[e.RowIndex].Cells["sitti_ti_id"].Value.ToString();
                Form1.cid = dataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToString();
                VerCompra vercompra = new VerCompra();
                vercompra.ShowDialog();
            }
        }
    }
}

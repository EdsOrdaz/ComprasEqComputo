using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComprasEqComputo
{
    public partial class NuevaSolicitud : Form
    {
        public static String[] comprar_a = new String[12];
        public static String[] solicita = new String[9];

        public NuevaSolicitud()
        {
            InitializeComponent();
        }

        private void NuevaSolicitud_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();

            buscar.Focus();
            dataGridView2.Hide();
            buscar.Text = "";
            buscar2.Text = "";
            buscar2.Hide();
            label2.Hide();

            if (Form1.lista_nomina.Any())
            {
                foreach (String[] n in Form1.lista_nomina)
                {
                    dataGridView1.Rows.Add(n[0], n[1], n[2], n[3], n[4], n[5], n[6], n[7], n[8], n[9], n[10], n[11]);
                    if (n[0] != "S/N")
                    {
                        dataGridView2.Rows.Add(n[0], n[1], n[2], n[3], n[4], n[5], n[6], n[7], n[8]);
                    }
                }
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            dataGridView1.Rows.Clear();
            if (!string.IsNullOrEmpty(buscar.Text))
            {
                foreach (String[] empleado in Form1.lista_nomina)
                {
                    String nmayus = empleado[8].ToString().ToUpper();
                    if (nmayus.Contains(buscar.Text.ToUpper()))
                    {
                        dataGridView1.Rows.Add(empleado[0], empleado[1], empleado[2], empleado[3], empleado[4], empleado[5], empleado[6], empleado[7], empleado[8], empleado[9], empleado[10], empleado[11]);
                    }
                }
            }
            else
            {
                foreach (String[] empleado in Form1.lista_nomina)
                {
                    dataGridView1.Rows.Add(empleado[0], empleado[1], empleado[2], empleado[3], empleado[4], empleado[5], empleado[6], empleado[7], empleado[8], empleado[9], empleado[10], empleado[11]);
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                comprar_a[0] = dataGridView1.Rows[e.RowIndex].Cells["numempleado"].Value.ToString();
                comprar_a[1] = dataGridView1.Rows[e.RowIndex].Cells["nombre"].Value.ToString();
                comprar_a[2] = dataGridView1.Rows[e.RowIndex].Cells["apepat"].Value.ToString();
                comprar_a[3] = dataGridView1.Rows[e.RowIndex].Cells["apemat"].Value.ToString();
                comprar_a[4] = dataGridView1.Rows[e.RowIndex].Cells["cc"].Value.ToString();
                comprar_a[5] = dataGridView1.Rows[e.RowIndex].Cells["base1"].Value.ToString();
                comprar_a[6] = dataGridView1.Rows[e.RowIndex].Cells["puesto"].Value.ToString();
                comprar_a[7] = dataGridView1.Rows[e.RowIndex].Cells["empresa"].Value.ToString();
                comprar_a[8] = dataGridView1.Rows[e.RowIndex].Cells["nombrecompleto"].Value.ToString();
                comprar_a[9] = dataGridView1.Rows[e.RowIndex].Cells["ubicacion"].Value.ToString();
                comprar_a[10] = dataGridView1.Rows[e.RowIndex].Cells["departamento"].Value.ToString();
                comprar_a[11] = dataGridView1.Rows[e.RowIndex].Cells["direccion"].Value.ToString();

                dataGridView1.Hide();

                label1.Hide();
                buscar.Hide();
                buscar2.Show();
                label2.Show();

                buscar2.Focus();
                dataGridView2.Show();
            }
        }

        private void buscar2_KeyUp(object sender, KeyEventArgs e)
        {
            dataGridView2.Rows.Clear();
            if (!string.IsNullOrEmpty(buscar2.Text))
            {
                foreach (String[] empleado in Form1.lista_nomina)
                {
                    String nmayus = empleado[8].ToString().ToUpper();
                    if (nmayus.Contains(buscar2.Text.ToUpper()))
                    {
                        if (empleado[0] != "S/N")
                        {
                            dataGridView2.Rows.Add(empleado[0], empleado[1], empleado[2], empleado[3], empleado[4], empleado[5], empleado[6], empleado[7], empleado[8]);
                        }
                    }
                }
            }
            else
            {
                foreach (String[] empleado in Form1.lista_nomina)
                {
                    if (empleado[0] != "S/N")
                    {
                        dataGridView2.Rows.Add(empleado[0], empleado[1], empleado[2], empleado[3], empleado[4], empleado[5], empleado[6], empleado[7], empleado[8]);
                    }
                }
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                solicita[0] = dataGridView2.Rows[e.RowIndex].Cells["numempleado2"].Value.ToString();
                solicita[1] = dataGridView2.Rows[e.RowIndex].Cells["nombre2"].Value.ToString();
                solicita[2] = dataGridView2.Rows[e.RowIndex].Cells["apepat2"].Value.ToString();
                solicita[3] = dataGridView2.Rows[e.RowIndex].Cells["apemat2"].Value.ToString();
                solicita[4] = dataGridView2.Rows[e.RowIndex].Cells["cc2"].Value.ToString();
                solicita[5] = dataGridView2.Rows[e.RowIndex].Cells["base2"].Value.ToString();
                solicita[6] = dataGridView2.Rows[e.RowIndex].Cells["puesto2"].Value.ToString();
                solicita[7] = dataGridView2.Rows[e.RowIndex].Cells["empresa2"].Value.ToString();
                solicita[8] = dataGridView2.Rows[e.RowIndex].Cells["nombrecompleto2"].Value.ToString();
                NuevaSolicitud_llenar llenar = new NuevaSolicitud_llenar();
                llenar.ShowDialog();
                Close();
            }
        }

        private void buscar2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

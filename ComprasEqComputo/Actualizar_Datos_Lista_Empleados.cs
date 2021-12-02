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
    public partial class Actualizar_Datos_Lista_Empleados : Form
    {
        public static String[] empleado = new String[12];

        public Actualizar_Datos_Lista_Empleados()
        {
            InitializeComponent();
        }

        private void Actualizar_Datos_Lista_Empleados_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
            if (Form1.lista_nomina.Any())
            {
                foreach (String[] n in Form1.lista_nomina)
                {
                    if (n[0] != "S/N")
                    {
                        dataGridView1.Rows.Add(n[0], n[1], n[2], n[3], n[4], n[5], n[6], n[7], n[8], n[9], n[10], n[11]);
                    }
                }
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            dataGridView1.Rows.Clear();
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                foreach (String[] empleado in Form1.lista_nomina)
                {
                    String nmayus = empleado[8].ToString().ToUpper();
                    if (nmayus.Contains(textBox1.Text.ToUpper()))
                    {
                        if (empleado[0] != "S/N")
                        {
                            dataGridView1.Rows.Add(empleado[0], empleado[1], empleado[2], empleado[3], empleado[4], empleado[5], empleado[6], empleado[7], empleado[8], empleado[9], empleado[10], empleado[11]);
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
                        dataGridView1.Rows.Add(empleado[0], empleado[1], empleado[2], empleado[3], empleado[4], empleado[5], empleado[6], empleado[7], empleado[8], empleado[9], empleado[10], empleado[11]);
                    }
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                empleado[0] = dataGridView1.Rows[e.RowIndex].Cells["numempleado"].Value.ToString();
                empleado[1] = dataGridView1.Rows[e.RowIndex].Cells["nombre"].Value.ToString();
                empleado[2] = dataGridView1.Rows[e.RowIndex].Cells["apepat"].Value.ToString();
                empleado[3] = dataGridView1.Rows[e.RowIndex].Cells["apemat"].Value.ToString();
                empleado[4] = dataGridView1.Rows[e.RowIndex].Cells["cc"].Value.ToString();
                empleado[5] = dataGridView1.Rows[e.RowIndex].Cells["base1"].Value.ToString();
                empleado[6] = dataGridView1.Rows[e.RowIndex].Cells["puesto"].Value.ToString();
                empleado[7] = dataGridView1.Rows[e.RowIndex].Cells["empresa"].Value.ToString();
                empleado[8] = dataGridView1.Rows[e.RowIndex].Cells["nombrecompleto"].Value.ToString();
                empleado[9] = dataGridView1.Rows[e.RowIndex].Cells["ubicacion"].Value.ToString();
                empleado[10] = dataGridView1.Rows[e.RowIndex].Cells["departamento"].Value.ToString();
                empleado[11] = dataGridView1.Rows[e.RowIndex].Cells["direccion"].Value.ToString();

                Actualizar_Datos_Llenar llenar_datos = new Actualizar_Datos_Llenar();
                llenar_datos.ShowDialog();
                Close();
            }
        }
    }
}

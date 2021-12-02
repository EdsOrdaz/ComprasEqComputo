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
    public partial class EntregarEquipo_ListadeUsuarios : Form
    {
        public static String[] empleado = new String[12];

        public EntregarEquipo_ListadeUsuarios()
        {
            InitializeComponent();
        }

        private void EntregarEquipo_ListadeUsuarios_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
            if (Form1.lista_nomina.Any())
            {
                foreach (String[] n in Form1.lista_nomina)
                {
                    if (n[0] != "S/N")
                    {
                        dataGridView1.Rows.Add(n[8]);
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
                            dataGridView1.Rows.Add(empleado[8]);
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
                        dataGridView1.Rows.Add(empleado[8]);
                    }
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                empleado[8] = dataGridView1.Rows[e.RowIndex].Cells["nombrecompleto"].Value.ToString();

                DialogResult nombre = MessageBox.Show("Registrar equipo entregado a " + empleado[8] + "?", "Compras Pendientes", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(nombre==DialogResult.Yes)
                {
                    using (SqlConnection conexion2 = new SqlConnection(Form1.conexionsql_infeq))
                    {
                        try
                        {
                            conexion2.Open();
                            String insert = "UPDATE ComprasEqComputo SET stock_disponible=@stock_disponible, entregada=@entregada, nombre_entrega=@nombre_entrega " +
                                "WHERE cid='" + Form1.cid + "'";

                            SqlCommand cmdIns = new SqlCommand(insert, conexion2);

                            cmdIns.Parameters.AddWithValue("@stock_disponible", "0");
                            cmdIns.Parameters.AddWithValue("@entregada", "1");
                            cmdIns.Parameters.AddWithValue("@nombre_entrega", empleado[8]);

                            cmdIns.ExecuteNonQuery();
                            cmdIns.Parameters.Clear();

                            cmdIns.Dispose();
                            cmdIns = null;
                            MessageBox.Show("Datos guardados correctamente.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Form1.actualizar = true;
                            Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error al registrar equipo como entregado.\n\nMensaje: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
    }
}

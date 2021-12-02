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
    public partial class TipoCompra : Form
    {
        public TipoCompra()
        {
            InitializeComponent();
        }

        private void TipoCompra_Load(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conexion2 = new SqlConnection(Form1.conexionsql_infeq))
                {
                    conexion2.Open();
                    String sql2 = "SELECT valor FROM Configuracion WHERE nombre='Compras_Tipos'";
                    SqlCommand comm2 = new SqlCommand(sql2, conexion2);
                    SqlDataReader nwReader2 = comm2.ExecuteReader();
                    if (nwReader2.Read())
                    {
                        String phrase = nwReader2["valor"].ToString();
                        String[] words = phrase.Split(',');

                        int i = 0;
                        foreach (var word in words)
                        {
                            if (i < 1)
                            {
                                richTextBox1.AppendText($"{word}");
                            }
                            else
                            {
                                richTextBox1.AppendText(Environment.NewLine + $"{word}");
                            }
                            i++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener tipos de compras.\n\nMensaje: " + ex.Message, "Compras", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String phrase = richTextBox1.Text;
            String[] words = phrase.Split('\n');


            richTextBox1.Text = "";
            int i = 1;
            String coma = ",";
            foreach (var word in words)
            {
                if(i==words.Length)
                {
                    coma = "";
                }
                richTextBox1.Text += $"{word}"+coma;
                i++;
            }
            try
            {
                using (SqlConnection conexion2 = new SqlConnection(Form1.conexionsql_infeq))
                {
                    conexion2.Open();
                    String sql2 = "UPDATE Configuracion SET valor = '" + richTextBox1.Text + "' WHERE nombre = 'Compras_Tipos'";
                    SqlCommand comm2 = new SqlCommand(sql2, conexion2);
                    SqlDataReader nwReader2 = comm2.ExecuteReader();
                }
                MessageBox.Show("Tipos de compras guardados.", "Compras", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar tipos de compras..\n\nMensaje: " + ex.Message, "Información del Equipo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }
            richTextBox1.Text = "";
        }
    }
}

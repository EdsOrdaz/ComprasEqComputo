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
    public partial class ActualizarComentarioTI : Form
    {
        public ActualizarComentarioTI()
        {
            InitializeComponent();
        }

        private void ActualizarComentarioTI_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = VerCompra.verpedido[19];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conexion2 = new SqlConnection(Form1.conexionsql_infeq))
            {
                try
                {
                    conexion2.Open();
                    String insert = "UPDATE ComprasEqComputo SET comentario_ti=@comentario_ti WHERE cid='" + Form1.cid + "'";

                    SqlCommand cmdIns = new SqlCommand(insert, conexion2);

                    cmdIns.Parameters.AddWithValue("@comentario_ti", richTextBox1.Text);

                    cmdIns.ExecuteNonQuery();
                    cmdIns.Parameters.Clear();

                    cmdIns.Dispose();
                    cmdIns = null;
                    MessageBox.Show("Comentario actualizado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Form1.actualizar = true;
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar el comentario.\n\nMensaje: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

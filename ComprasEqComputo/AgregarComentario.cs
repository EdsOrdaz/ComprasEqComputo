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
    public partial class AgregarComentario : Form
    {
        public AgregarComentario()
        {
            InitializeComponent();
        }
        public static String usuario;

        private void AgregarComentario_Load(object sender, EventArgs e)
        {
            if(VerCompra.usuario_comentario=="E")
            {
                label4.Text = "Edson Ordaz";
                usuario = "4307";
                comboBox1.SelectedIndex = 2;
            }
            if(VerCompra.usuario_comentario=="D")
            {
                label4.Text = "Daniel Gonzalez";
                usuario = "4523";
                comboBox1.SelectedIndex = 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = richTextBox1.Text.ToUpper();
            using (SqlConnection conexion = new SqlConnection(Form1.conexionsql_sitti))
            {
                try
                {
                    conexion.Open();
                    String insert = "INSERT INTO ms_historico (id_ms_ticket, id_usr_com, fecha_com, comentario) " +
                        "VALUES (@id_ms_ticket, @id_usr_com, @fecha_com, @comentario)";

                    SqlCommand cmdIns = new SqlCommand(insert, conexion);

                    cmdIns.Parameters.AddWithValue("@id_ms_ticket", VerCompra.verpedido[10]);
                    cmdIns.Parameters.AddWithValue("@id_usr_com", usuario);
                    cmdIns.Parameters.AddWithValue("@fecha_com", DateTime.Now.ToString("s"));
                    cmdIns.Parameters.AddWithValue("@comentario", richTextBox1.Text.ToUpper());

                    
                    cmdIns.ExecuteNonQuery();
                    cmdIns.Parameters.Clear();

                    cmdIns.CommandText = "SELECT @@IDENTITY";

                    cmdIns.Dispose();
                    cmdIns = null;
                    
                    String estatus="";
                    switch(comboBox1.SelectedIndex.ToString())
                    {
                        case "0":
                            estatus = "PU";
                            break;
                        case "1":
                            estatus = "PP";
                            break;
                        case "2":
                            estatus = "P";
                            break;
                        case "3":
                            estatus = "S";
                            break;
                    }

                    String actualizar_estatus = "UPDATE ms_ticket SET status = '" +  estatus + "' WHERE id_ms_ticket='" + VerCompra.verpedido[10] + "'";
                    Console.WriteLine(actualizar_estatus);
                    Console.WriteLine(actualizar_estatus);
                    Console.WriteLine(actualizar_estatus);
                    Console.WriteLine(actualizar_estatus);
                    SqlCommand comm = new SqlCommand(actualizar_estatus, conexion);
                    comm.ExecuteReader();

                    MessageBox.Show("Comentario Insertado.", "Agregar Comentario", MessageBoxButtons.OK,MessageBoxIcon.Information);
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al agregar comentario.\n\nMensaje: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

        }

        private void richTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Shift && e.KeyCode == Keys.E)
            {
                richTextBox1.Text = "FAVOR DE INDICAR ESTATUS.";
            }
        }
    }
}

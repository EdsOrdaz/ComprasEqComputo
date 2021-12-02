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
    public partial class AsignarEconomico : Form
    {
        public AsignarEconomico()
        {
            InitializeComponent();
        }

        private void AsignarEconomico_Load(object sender, EventArgs e)
        {
            comentario_ti.Text = VerCompra.comment_ti;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(economico.Text))
            {
                MessageBox.Show("El número económico no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection conexion = new SqlConnection(Form1.conexionsql_infeq))
                {
                    conexion.Open();

                    String stock = (VerCompra.reponerstock == "1") ? ", stock_disponible='1' " : "";

                    String actualizareconomico = "UPDATE ComprasEqComputo SET comentario_ti = '" + comentario_ti.Text + "', economico='" + economico.Text + "', " +
                        "fecha_entrega='"+ DateTime.Now.ToString("s") +"'"+ stock+" WHERE cid='" + Form1.cid + "'";
                    SqlCommand comm = new SqlCommand(actualizareconomico, conexion);
                    comm.ExecuteReader();

                    MessageBox.Show("Equipo registrado.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    conexion.Close();
                    Form1.actualizar = true;
                    Close();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error al actualizar datos..." + error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void economico_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }
    }
}

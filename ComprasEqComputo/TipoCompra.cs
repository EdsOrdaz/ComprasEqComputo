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
                    String sql2 = "SELECT * FROM ComprasEqComputo_tipo";
                    SqlCommand comm2 = new SqlCommand(sql2, conexion2);
                    SqlDataReader nwReader2 = comm2.ExecuteReader();
                    while (nwReader2.Read())
                    {
                        dataGridView1.Rows.Add(nwReader2["tid"].ToString(), nwReader2["tipo"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener tipos de compras.\n\nMensaje: " + ex.Message, "Compras", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }
        }

        int LastNewRowIndex = -1;

        private void dataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            LastNewRowIndex = e.Row.Index - 1;
        }

        private void dataGridView1_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            if(LastNewRowIndex > -1)
            {
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
                DataGridViewRow dgvR = dataGridView1.Rows[LastNewRowIndex];
                foreach (DataGridViewCell cell in dgvR.Cells)
                {
                    if (cell.ColumnIndex == 1)
                    {
                        if(!String.IsNullOrEmpty(cell.Value.ToString()))
                        {
                            try
                            {
                                int tid=0;
                                using (SqlConnection conexion2 = new SqlConnection(Form1.conexionsql_infeq))
                                {
                                    conexion2.Open();
                                    String sql2 = "INSERT INTO ComprasEqComputo_tipo (tipo) VALUES (@tipo)";
                                    SqlCommand cmdIns = new SqlCommand(sql2, conexion2);
                                    cmdIns.Parameters.AddWithValue("@tipo", cell.Value.ToString());
                                    
                                    cmdIns.ExecuteNonQuery();
                                    cmdIns.Parameters.Clear();

                                    cmdIns.CommandText = "SELECT @@IDENTITY";

                                    tid = Convert.ToInt32(cmdIns.ExecuteScalar());

                                    dataGridView1.Rows[LastNewRowIndex].Cells[0].Value = tid;

                                    cmdIns.Dispose();
                                    cmdIns = null;
                                }
                            }
                            catch(Exception mj)
                            {
                                dataGridView1.Rows[LastNewRowIndex].DefaultCellStyle.BackColor = Color.LightSalmon;
                                MessageBox.Show("Error al agregar tipo de compra "+ cell.Value.ToString() + "\nERROR: "+mj.Message, "TIPO DE COMPRA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                dataGridView1.Enabled = false;
                            }
                        }
                    }
                }
                LastNewRowIndex = -1;
            }
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dataGridView1.EditingControl.GetType() == typeof(DataGridViewTextBoxEditingControl)) 
            { 
                ((DataGridViewTextBoxEditingControl)dataGridView1.EditingControl).CharacterCasing = CharacterCasing.Upper; 
            }
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DataGridViewRow dgvR = dataGridView1.Rows[dataGridView1.CurrentRow.Index];
            foreach (DataGridViewCell cell in dgvR.Cells)
            {
                if (cell.ColumnIndex == 0)
                {
                    try
                    {
                        using (SqlConnection conexion2 = new SqlConnection(Form1.conexionsql_infeq))
                        {
                            conexion2.Open();
                            String sql2 = "DELETE FROM ComprasEqComputo_tipo WHERE tid='" + Convert.ToInt32(cell.Value) + "'";
                            SqlCommand comm2 = new SqlCommand(sql2, conexion2);
                            SqlDataReader nwReader2 = comm2.ExecuteReader();
                        }
                    }
                    catch (Exception mj)
                    {
                        MessageBox.Show("Error al eliminar tipo de compra " + cell.Value.ToString() + "\nERROR: " + mj.Message, "TIPO DE COMPRA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dataGridView1.Enabled = false;
                    }
                }
            }
        }
    }
}

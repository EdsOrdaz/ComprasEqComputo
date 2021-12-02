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
    public partial class Actualizar_Datos_Llenar : Form
    {
        public Actualizar_Datos_Llenar()
        {
            InitializeComponent();
        }

        private void Actualizar_Datos_Llenar_Load(object sender, EventArgs e)
        {
            if(VerCompra.verpedido[13] == "1")
            {
                stock.Checked = true;
            }
            text_nombre.Text = Actualizar_Datos_Lista_Empleados.empleado[8];
            text_num.Text = Actualizar_Datos_Lista_Empleados.empleado[0];
            text_puesto.Text = Actualizar_Datos_Lista_Empleados.empleado[6];
            text_cc.Text = Actualizar_Datos_Lista_Empleados.empleado[4];
            text_dep.Text = Actualizar_Datos_Lista_Empleados.empleado[10];
            text_dir.Text = Actualizar_Datos_Lista_Empleados.empleado[11];
            text_empresa.Text = Actualizar_Datos_Lista_Empleados.empleado[7];
            text_ubi.Text = Actualizar_Datos_Lista_Empleados.empleado[9];
            richTextBox1.Text = VerCompra.verpedido[19];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conexion2 = new SqlConnection(Form1.conexionsql_infeq))
            {
                try
                {
                    conexion2.Open();
                    String insert = "UPDATE ComprasEqComputo SET nombre=@nombre, ap_paterno=@ap_paterno, ap_materno=@ap_materno, " +
                        "no_trabajador=@no_trabajador, puesto=@puesto, cc=@cc, empresa=@empresa, " +
                        "stock_reponer=@stock_reponer, stock_disponible=@stock_disponible, comentario_ti=@comentario_ti WHERE cid='" + Form1.cid + "'";

                    SqlCommand cmdIns = new SqlCommand(insert, conexion2);

                    int es_stock = (stock.Checked) ? 1 : 0;

                    cmdIns.Parameters.AddWithValue("@nombre", Actualizar_Datos_Lista_Empleados.empleado[1]);
                    cmdIns.Parameters.AddWithValue("@ap_paterno", Actualizar_Datos_Lista_Empleados.empleado[2]);
                    cmdIns.Parameters.AddWithValue("@ap_materno", Actualizar_Datos_Lista_Empleados.empleado[3]);
                    cmdIns.Parameters.AddWithValue("@no_trabajador", text_num.Text.ToUpper());
                    cmdIns.Parameters.AddWithValue("@puesto", text_puesto.Text.ToUpper());
                    cmdIns.Parameters.AddWithValue("@cc", text_cc.Text.ToUpper());
                    cmdIns.Parameters.AddWithValue("@empresa", text_empresa.Text.ToUpper());
                    cmdIns.Parameters.AddWithValue("@stock_reponer", es_stock);
                    cmdIns.Parameters.AddWithValue("@stock_disponible", es_stock);
                    cmdIns.Parameters.AddWithValue("@comentario_ti", richTextBox1.Text);

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
                    MessageBox.Show("Error al insertar usuario en tabla usuarios.\n\nMensaje: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

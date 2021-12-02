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
    public partial class VerCompra : Form
    {
        public VerCompra()
        {
            InitializeComponent();
        }

        public static String comment_ti;
        public static String reponerstock;
        public static String[] verpedido = new String[25];
        public static String usuario_comentario;

        private void VerCompra_Load(object sender, EventArgs e)
        {
            registrar_eco.Text = (Form1.registrareconomico == true) ? "Registrar Económico" : "Entregar Equipo";

            stock.Visible = false;
            economico.Visible = false;
            eco_text.Visible = false;

            List<String[]> lista = new List<String[]>();

            switch(Form1.lista)
            {
                case 0:
                    this.Text = "Ver Compra Pendiente";
                    lista = Form1.lista_compras;
                break;

                case 1:
                    this.Text = "Ver Equipo de Stock";
                    lista = Form1.lista_disponibles_stock;
                break;

                case 2:
                    this.Text = "Ver Equipo Pendiente";
                    lista = Form1.lista_disponibles_usuario;
                break;

                case 3:
                    this.Text = "Ver Equipo Entregado";
                    lista = Form1.lista_entregados;
                break;

                default:
                    this.Text = "Ver Compra Pendiente";
                    lista = Form1.lista_compras;
                break;
            }

            String nombrecompleto = "";
            foreach (String[] empleado in lista)
            {
                String nmayus = empleado[0].ToString().ToUpper();
                if (nmayus == Form1.cid)
                {
                    verpedido[0] = empleado[0]; //cid
                    verpedido[1] = empleado[1]; //nombre
                    verpedido[2] = empleado[2]; //ap_paterno
                    verpedido[3] = empleado[3]; //ap_materno
                    verpedido[4] = empleado[4]; //no_trabajador
                    verpedido[5] = empleado[5]; //puesto
                    verpedido[6] = empleado[6]; //cc
                    verpedido[7] = empleado[7]; //empresa
                    verpedido[8] = empleado[8]; //solicita
                    verpedido[9] = empleado[9]; //fecha_solicitud
                    verpedido[10] = empleado[10]; //sitti_ti
                    verpedido[11] = empleado[11]; //sitti_usuario
                    verpedido[12] = empleado[12]; //fecha_entrega
                    verpedido[13] = empleado[13]; //stock_reponer
                    verpedido[14] = empleado[14]; //stock_disponible
                    verpedido[15] = empleado[15]; //economico
                    verpedido[16] = empleado[16]; //sisac
                    verpedido[17] = empleado[17]; //hardware
                    verpedido[18] = empleado[18]; //entregada
                    verpedido[19] = empleado[19]; //comentario_ti
                    verpedido[20] = empleado[20]; //ultimo_comentario
                    verpedido[21] = empleado[21]; //nombre_entrega
                    //Este se llena en el form 
                    verpedido[22] = empleado[22]; //Estatus sitti TI
                    verpedido[23] = empleado[24]; //Tipo de compra (CPU o LAP)
                    verpedido[24] = empleado[25]; //Pedido de compra



                    //Entregar pienza o laptops
                    if(empleado[24] == "CPU" || empleado[24] == "LAPTOP")
                    {
                        registrar_eco.Text = (Form1.registrareconomico == true) ? "Registrar Económico" : "Entregar Equipo";
                    }
                    else
                    {
                        registrar_eco.Text = "Entregar " + empleado[24].ToLower();
                    }



                    String solicita_nombre = "";
                    if (String.IsNullOrEmpty(nombrecompleto))
                    {
                        foreach (String[] nomina in Form1.lista_nomina)
                        {
                            String nom = nomina[0].ToString().ToUpper();
                            if (nom == empleado[8])
                            {
                                nombrecompleto = nomina[8].ToString();
                                solicita_nombre = nomina[8].ToString();
                            }
                        }
                    }



                    DateTime fecha_solicita = DateTime.Parse(empleado[9]);


                    int columnas = 8;

                    dataGridView2.Rows.Add("Tipo:", empleado[24]);
                    dataGridView2.Rows.Add("Nombre:", empleado[21]);
                    dataGridView2.Rows.Add("Puesto", empleado[5]);
                    dataGridView2.Rows.Add("Centro de Costos:", empleado[6]);
                    dataGridView2.Rows.Add("Empresa:", empleado[7]);
                    dataGridView2.Rows.Add("Solicita:", solicita_nombre);
                    dataGridView2.Rows.Add("Fecha Solicitud:", fecha_solicita.ToShortDateString());
                    //dataGridView2.Rows.Add("Sisac:", empleado[16]);

                    //No mostrar sitti de usuario si no existe
                    if(Convert.ToInt32(empleado[11]) > 1000)
                    {
                        dataGridView2.Rows.Add("SiTTi Usuario:", empleado[11]);
                        columnas += 1;
                    }
                    dataGridView2.Rows.Add("SiTTi Compra:", empleado[10]);

                    empleado[17] = (String.IsNullOrEmpty(empleado[17]) ? "SIN SOLICITUD" : empleado[17]);
                    //dataGridView2.Rows.Add("Núm. Solicitud:", empleado[17]);


                    //MOSTRAR DATOS DE SISAC SI EXISTEN
                    foreach (String[] sisac in Form1.lista_sisac)
                    {
                        if (sisac[0] == empleado[0])
                        {
                            dataGridView2.Rows.Add("SiSAC Ticket:", sisac[1]);
                            dataGridView2.Rows.Add("SiSAC Empresa:", sisac[2]);
                            dataGridView2.Rows.Add("SiSAC Solicita:", sisac[3]);
                            dataGridView2.Rows.Add("SiSAC Comprador:", sisac[4]);
                            dataGridView2.Rows.Add("SiSAC Estatus:", sisac[5]);
                            dataGridView2.Rows.Add("SiSAC Codigo:", sisac[6]);
                            dataGridView2.Rows.Add("SiSAC Descripcion:", sisac[7]);
                            dataGridView2.Rows.Add("SiSAC Marca:", sisac[8]);
                            dataGridView2.Rows.Add("SiSAC Ultimo Precio:", sisac[9]);

                            columnas += 9;
                        }
                    }


                    //MOSTRAR DATOS DE NAV SI EXISTEN
                    foreach (String[] nav in Form1.lista_nav)
                    {
                        if(nav[0] == empleado[0])
                        {
                            dataGridView2.Rows.Add("NAV Solicitud:", nav[8]);
                            /*
                            empleado[25] = (String.IsNullOrEmpty(empleado[25]) ? "SIN PEDIDO" : empleado[25]);
                            dataGridView2.Rows.Add("NAV Pedido:", empleado[25]);
                            */

                            nav[4] = (String.IsNullOrEmpty(nav[4]) ? "SIN PEDIDO" : nav[4]);
                            dataGridView2.Rows.Add("NAV Pedido:", nav[4]);

                            dataGridView2.Rows.Add("NAV Descripcion:", nav[3]);
                            dataGridView2.Rows.Add("NAV Nota Comprador:", nav[5]);

                            nav[7] = (nav[7] == "1") ? "APROBADO" : "SIN APROBAR";
                            dataGridView2.Rows.Add("NAV Autorizado:", nav[7]);

                            dataGridView2.Rows.Add("NAV Autorizador:", nav[6]);
                            dataGridView2.Rows.Add("NAV Fecha Aprobacion:", nav[8]);
                            dataGridView2.Rows.Add("NAV Activo:", nav[2]);
                            columnas += 8;
                        }
                    }
                    dataGridView2.Rows.Add("ID:", empleado[0]);


                    System.Windows.Forms.DataGridViewCellStyle boldStyle = new System.Windows.Forms.DataGridViewCellStyle();
                    boldStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);

                    for (int i = 0; i <= columnas; i++)
                    {
                        dataGridView2.Rows[i].Cells[0].Style = boldStyle;
                        dataGridView2.Rows[i].Cells[0].Style.BackColor = Color.Silver;
                    }
                    this.dataGridView2.ClearSelection();



                    try
                    {
                        using (SqlConnection conexion = new SqlConnection(Form1.conexionsql_sitti))
                        {
                            conexion.Open();
                            SqlCommand comm = new SqlCommand("SELECT * FROM ms_ticket WHERE id_ms_ticket='" + empleado[10] + "'", conexion);
                            SqlDataReader nwReader = comm.ExecuteReader();
                            while (nwReader.Read())
                            {
                                try
                                {
                                    using (SqlConnection conexion2 = new SqlConnection(Form1.conexionsql_sitti))
                                    {
                                        conexion2.Open();
                                        SqlCommand comm2 = new SqlCommand("SELECT h.fecha_com, e.nombre+' '+e.ap_paterno as 'usuario', h.comentario, (SELECT nombre+' '+ap_paterno+' '+ap_materno FROM cg_empleado WHERE no_empleado=CONVERT(varchar(50),CONVERT(int,'" + empleado[8] + "'))) as solicita FROM [bd_SiTTi].[dbo].[ms_historico] h INNER JOIN cg_usuario u ON h.id_usr_com=u.id_usuario INNER JOIN cg_empleado e ON u.id_empleado=e.id_empleado where h.id_ms_ticket='" + empleado[10] + "' ORDER BY fecha_com DESC", conexion2);

                                        
                                        SqlDataReader nwReader2 = comm2.ExecuteReader();
                                        while (nwReader2.Read())
                                        {
                                            dataGridView1.Rows.Add(nwReader2["fecha_com"].ToString(), nwReader2["usuario"].ToString(), nwReader2["comentario"].ToString());
                                            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                                        }
                                    }
                                }
                                catch (System.Exception ex)
                                {
                                    MessageBox.Show("Error en la busqueda de compras pendientes.\n\nMensaje: " + ex.Message, "Información del Equipo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                                if (String.IsNullOrEmpty(empleado[15]))
                                {
                                    stock.Visible = (empleado[13].ToString() == "1") ? true : false;
                                }
                                else
                                {
                                    eco_text.Visible = true;
                                    economico.Visible = true;
                                    economico.Text = empleado[15];
                                }

                                empleado[19] = (String.IsNullOrEmpty(empleado[19])) ? "Sin comentarios." : empleado[19];
                                text_comentariosti.Text = empleado[19];

                                comment_ti = empleado[19];
                                reponerstock = empleado[13];
                            }
                        }
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show("Error en la busqueda de compras pendientes.\n\nMensaje: " + ex.Message, "Información del Equipo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        


            if(Form1.lista == 3)
            {
                actualizar_datos.Enabled = false;
                registrar_eco.Enabled = false;
            }
            else
            {
                actualizar_datos.Enabled = true;
                registrar_eco.Enabled = false;
                if (verpedido[22] == "C" || verpedido[22] == "S")
                {
                    registrar_eco.Enabled = true;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Boton Registrar Economico
            if (Form1.registrareconomico == true && (verpedido[23] == "LAPTOP" || verpedido[23] == "CPU"))
            {
                AsignarEconomico asignar_eco = new AsignarEconomico();
                asignar_eco.ShowDialog();

                if (Form1.actualizar == true)
                {
                    Close();
                }
            }
            
            //Boton entregar equipo
            else
            {
                //Entregar mismo Usuario al que se compro
                DialogResult entrega = MessageBox.Show("Marcar equipo como entregado a " + verpedido[1] + " " + verpedido[2] + " " + verpedido[3] + "?", "Compras Pendientes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (entrega == DialogResult.Yes)
                {
                    using (SqlConnection conexion2 = new SqlConnection(Form1.conexionsql_infeq))
                    {
                        try
                        {
                            conexion2.Open();
                            String insert = "UPDATE ComprasEqComputo SET stock_disponible=@stock_disponible, entregada=@entregada, nombre_entrega=@nombre_entrega, " +
                                "fecha_entrega='" + DateTime.Now.ToString("s") + "' WHERE cid='" + Form1.cid + "'";

                            SqlCommand cmdIns = new SqlCommand(insert, conexion2);

                            cmdIns.Parameters.AddWithValue("@stock_disponible", "0");
                            cmdIns.Parameters.AddWithValue("@entregada", "1");
                            cmdIns.Parameters.AddWithValue("@nombre_entrega", verpedido[1] + " " + verpedido[2] + " " + verpedido[3]);

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

                //Entregar diferente usuario al que se compro
                if (entrega == DialogResult.No)
                {
                    EntregarEquipo_ListadeUsuarios listausuarios_entregar = new EntregarEquipo_ListadeUsuarios();
                    listausuarios_entregar.ShowDialog();
                    Close();
                }
            }
        }

        private void actualizar_datos_Click(object sender, EventArgs e)
        {
            Actualizar_Datos_Lista_Empleados listaempleados = new Actualizar_Datos_Lista_Empleados();
            listaempleados.ShowDialog();
            Close();
        }

        private void text_comentariosti_DoubleClick(object sender, EventArgs e)
        {
            ActualizarComentarioTI actualizar_ti = new ActualizarComentarioTI();
            actualizar_ti.ShowDialog();
            if (Form1.actualizar == true)
            {
                Close();
            }
        }

        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.E)
            {
                usuario_comentario = "E";
                AgregarComentario agregar = new AgregarComentario();
                agregar.ShowDialog();
            }
            if(e.KeyCode == Keys.D)
            {
                usuario_comentario = "D";
                AgregarComentario agregar = new AgregarComentario();
                agregar.ShowDialog();
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                if (!String.IsNullOrEmpty(dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()))
                {
                    Clipboard.SetText(dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                }
            }
        }
    }
}

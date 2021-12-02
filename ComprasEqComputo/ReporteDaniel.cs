using Microsoft.Office.Interop.Excel;
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
    public partial class ReporteDaniel : Form
    {
        public ReporteDaniel()
        {
            InitializeComponent();
        }

        public static List<String[]> lista_sitti = new List<String[]>();
        public static List<String[]> lista_sisac = new List<String[]>();
        public static List<String[]> lista_nav = new List<String[]>();

        public static List<String> lista_num_sitti = new List<String>();
        public static List<String> lista_num_nav = new List<String>();

        private void ReporteDaniel_Load(object sender, EventArgs e)
        {
            lista_sitti.Clear();
            lista_sisac.Clear();
            lista_nav.Clear();
            lista_num_sitti.Clear();
            lista_num_nav.Clear();

            dataGridView1.Rows.Clear();

            //SITTI
            try
            {
                using (SqlConnection conexion_sitti = new SqlConnection(Form1.conexionsql_sitti))
                {
                    conexion_sitti.Open();
                    SqlCommand comm = new SqlCommand("SELECT e.nombre+' '+e.ap_paterno as [solicita], m.descripcion as [descripcion], m.id_ms_ticket as [ticket], " +
                        "m.fecha_solicita [fecha], m.scNAV_hardware, m.scNAV_software , M.no_SiSAC FROM [bd_SiTTi].[dbo].[ms_ticket] m " +
                        "INNER JOIN [bd_SiTTi].[dbo].[cg_empleado] e ON m.id_empl_solicita=e.id_empleado where m.id_usr_asignado=4523 AND " +
                        "m.id_area_soporte=6 AND (m.status IN ('P','PP','A','PU'))", conexion_sitti);
                    SqlDataReader sitti_bd = comm.ExecuteReader();

                    while (sitti_bd.Read())
                    {
                        String[] sitti = new String[6];
                        sitti[0] = sitti_bd["solicita"].ToString();
                        sitti[1] = sitti_bd["descripcion"].ToString();
                        sitti[2] = sitti_bd["ticket"].ToString();
                        sitti[3] = sitti_bd["fecha"].ToString();
                        sitti[4] = sitti_bd["scNAV_hardware"].ToString();

                        if (String.IsNullOrEmpty(sitti_bd["scNAV_hardware"].ToString()))
                        {
                            sitti[4] = sitti_bd["scNAV_software"].ToString();
                        }
                        if(!String.IsNullOrEmpty(sitti[4]))
                        {
                            lista_num_nav.Add(sitti[4]);
                        }

                        sitti[5] = sitti_bd["no_SiSAC"].ToString();
                        if(!String.IsNullOrEmpty(sitti[5]))
                        {
                            lista_num_sitti.Add(sitti[5]);
                        }
                        lista_sitti.Add(sitti);
                    }
                }
            }
            catch(Exception error)
            {
                MessageBox.Show("Error al obtener datos del SiTTi\n\nError: " + error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Windows.Forms.Application.Exit();
            }


            //SISAC
            try
            {
                using (SqlConnection conexion_sisac = new SqlConnection(Form1.conexionsql_sisac))
                {
                    conexion_sisac.Open();
                    SqlCommand comm_sisac = new SqlCommand("SELECT [No.] as [ticket], [Empresa(s)] as [empresa], Solicitante as [solicita], Comprador as [comprador], " +
                        "Estatus as [estatus], Código as [codigo], Descripción as [descripcion], Marca as [marca], [Último Precio] as [ultimoprecio] " +
                        "FROM [bd_SiSAC].[dbo].[LNJ_Tablas_Comparativas] where [No.] IN ("+ String.Join(",", lista_num_sitti) + ")", conexion_sisac);
                    SqlDataReader sisac_bd = comm_sisac.ExecuteReader();

                    while (sisac_bd.Read())
                    {
                        String[] sisac = new String[9];
                        sisac[0] = sisac_bd["ticket"].ToString();
                        sisac[1] = sisac_bd["empresa"].ToString();
                        sisac[2] = sisac_bd["solicita"].ToString();
                        sisac[3] = sisac_bd["comprador"].ToString();
                        sisac[4] = sisac_bd["estatus"].ToString();
                        sisac[5] = sisac_bd["codigo"].ToString();
                        sisac[6] = sisac_bd["descripcion"].ToString();
                        sisac[7] = sisac_bd["marca"].ToString();
                        sisac[8] = sisac_bd["ultimoprecio"].ToString();
                        lista_sisac.Add(sisac);
                    }
                }
            }
            catch(Exception error)
            {
                MessageBox.Show("Error al obtener datos de SiSAC\n\nError: " + error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Windows.Forms.Application.Exit();
            }
           
            //NAV DICOMEX
            try
            {
                using (SqlConnection conexion_nav = new SqlConnection(Form1.conexionsql_nav))
                {
                    conexion_nav.Open();
                    SqlCommand comm_nav = new SqlCommand("select l.Request as [solicitud], No_ as [activo], l.Description as [descripcion] , " +
                        "l.[No_ Purchase Order] as [pedido], l.[Note to Buyer] as [notacomprador], p.[User approval] as [autorizador], p.[Approved] as [aprobado], " +
                        "p.[Fecha_Hora Aprobación] as [horaaprobacion] from [DICOMEX$Lines purchase request] l LEFT JOIN [DICOMEX$Purchase Request Header ] p " +
                        "ON p.[Request]=l.Request where l.Request " +
                        "IN ('"+ String.Join("' ,'", lista_num_nav) + "')", conexion_nav);
                    SqlDataReader nav_bd = comm_nav.ExecuteReader();

                    while (nav_bd.Read())
                    {
                        String[] nav = new String[8];
                        nav[0] = nav_bd["solicitud"].ToString();
                        nav[1] = nav_bd["activo"].ToString();
                        nav[2] = nav_bd["descripcion"].ToString();
                        nav[3] = nav_bd["pedido"].ToString();
                        nav[4] = nav_bd["notacomprador"].ToString();
                        nav[5] = nav_bd["autorizador"].ToString();
                        nav[6] = nav_bd["aprobado"].ToString();
                        nav[6] = (nav[6] == "1") ? "APROBADO" : "SIN APROBAR";
                        nav[7] = nav_bd["horaaprobacion"].ToString();
                        lista_nav.Add(nav);
                    }
                }
            }
            catch(Exception error)
            {
                MessageBox.Show("Error al obtener datos de NAV DICOMEX\n\nError: " + error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Windows.Forms.Application.Exit();
            }
            
            
            //NAV EXPROMAT
            try
            {
                using (SqlConnection conexion_nav = new SqlConnection(Form1.conexionsql_nav))
                {
                    conexion_nav.Open();
                    SqlCommand comm_nav = new SqlCommand("select l.Request as [solicitud], No_ as [activo], l.Description as [descripcion] , " +
                        "l.[No_ Purchase Order] as [pedido], l.[Note to Buyer] as [notacomprador], p.[User approval] as [autorizador], p.[Approved] as [aprobado], " +
                        "p.[Fecha_Hora Aprobación] as [horaaprobacion] from [EXPROMAT$Lines purchase request] l LEFT JOIN [EXPROMAT$Purchase Request Header] p " +
                        "ON p.[Request]=l.Request where l.Request " +
                        "IN ('"+ String.Join("' ,'", lista_num_nav) + "')", conexion_nav);
                    SqlDataReader nav_bd = comm_nav.ExecuteReader();

                    while (nav_bd.Read())
                    {
                        String[] nav = new String[8];
                        nav[0] = nav_bd["solicitud"].ToString();
                        nav[1] = nav_bd["activo"].ToString();
                        nav[2] = nav_bd["descripcion"].ToString();
                        nav[3] = nav_bd["pedido"].ToString();
                        nav[4] = nav_bd["notacomprador"].ToString();
                        nav[5] = nav_bd["autorizador"].ToString();
                        nav[6] = nav_bd["aprobado"].ToString();
                        nav[6] = (nav[6] == "1") ? "APROBADO" : "SIN APROBAR";
                        nav[7] = nav_bd["horaaprobacion"].ToString();
                        lista_nav.Add(nav);
                    }
                }
            }
            catch(Exception error)
            {
                MessageBox.Show("Error al obtener datos de NAV EXPROMAT\n\nError: " + error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Windows.Forms.Application.Exit();
            }
            
            //NAV TECS
            try
            {
                using (SqlConnection conexion_nav = new SqlConnection(Form1.conexionsql_nav))
                {
                    conexion_nav.Open();
                    SqlCommand comm_nav = new SqlCommand("select l.Request as [solicitud], No_ as [activo], l.Description as [descripcion] , " +
                        "l.[No_ Purchase Order] as [pedido], l.[Note to Buyer] as [notacomprador], p.[User approval] as [autorizador], p.[Approved] as [aprobado], " +
                        "p.[Fecha_Hora Aprobación] as [horaaprobacion] from [TECS$Lines purchase request] l LEFT JOIN [TECS$Purchase Request Header ] p " +
                        "ON p.[Request]=l.Request where l.Request " +
                        "IN ('"+ String.Join("' ,'", lista_num_nav) + "')", conexion_nav);
                    SqlDataReader nav_bd = comm_nav.ExecuteReader();

                    while (nav_bd.Read())
                    {
                        String[] nav = new String[8];
                        nav[0] = nav_bd["solicitud"].ToString();
                        nav[1] = nav_bd["activo"].ToString();
                        nav[2] = nav_bd["descripcion"].ToString();
                        nav[3] = nav_bd["pedido"].ToString();
                        nav[4] = nav_bd["notacomprador"].ToString();
                        nav[5] = nav_bd["autorizador"].ToString();
                        nav[6] = nav_bd["aprobado"].ToString();
                        nav[6] = (nav[6] == "1") ? "APROBADO" : "SIN APROBAR";
                        nav[7] = nav_bd["horaaprobacion"].ToString();
                        lista_nav.Add(nav);
                    }
                }
            }
            catch(Exception error)
            {
                MessageBox.Show("Error al obtener datos de NAV EXPROMAT\n\nError: " + error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Windows.Forms.Application.Exit();
            }
            
            //NAV CEPSA
            try
            {
                using (SqlConnection conexion_nav = new SqlConnection(Form1.conexionsql_nav))
                {
                    conexion_nav.Open();
                    SqlCommand comm_nav = new SqlCommand("select l.Request as [solicitud], No_ as [activo], l.Description as [descripcion] , " +
                        "l.[No_ Purchase Order] as [pedido], l.[Note to Buyer] as [notacomprador], p.[User approval] as [autorizador], p.[Approved] as [aprobado], " +
                        "p.[Fecha_Hora Aprobación] as [horaaprobacion] from [CEPSA$Lines purchase request] l LEFT JOIN [CEPSA$Purchase Request Header ] p " +
                        "ON p.[Request]=l.Request where l.Request " +
                        "IN ('"+ String.Join("' ,'", lista_num_nav) + "')", conexion_nav);
                    SqlDataReader nav_bd = comm_nav.ExecuteReader();

                    while (nav_bd.Read())
                    {
                        String[] nav = new String[8];
                        nav[0] = nav_bd["solicitud"].ToString();
                        nav[1] = nav_bd["activo"].ToString();
                        nav[2] = nav_bd["descripcion"].ToString();
                        nav[3] = nav_bd["pedido"].ToString();
                        nav[4] = nav_bd["notacomprador"].ToString();
                        nav[5] = nav_bd["autorizador"].ToString();
                        nav[6] = nav_bd["aprobado"].ToString();
                        nav[6] = (nav[6] == "1") ? "APROBADO" : "SIN APROBAR";
                        nav[7] = nav_bd["horaaprobacion"].ToString();
                        lista_nav.Add(nav);
                    }
                }
            }
            catch(Exception error)
            {
                MessageBox.Show("Error al obtener datos de NAV EXPROMAT\n\nError: " + error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Windows.Forms.Application.Exit();
            }

            //NAV TRACSA
            try
            {
                using (SqlConnection conexion_nav = new SqlConnection(Form1.conexionsql_nav))
                {
                    conexion_nav.Open();
                    SqlCommand comm_nav = new SqlCommand("select l.Request as [solicitud], No_ as [activo], l.Description as [descripcion] , " +
                        "l.[No_ Purchase Order] as [pedido], l.[Note to Buyer] as [notacomprador], p.[User approval] as [autorizador], p.[Approved] as [aprobado], " +
                        "p.[Fecha_Hora Aprobación] as [horaaprobacion] from [TRACSA$Lines purchase request] l LEFT JOIN [TRACSA$Purchase Request Header ] p " +
                        "ON p.[Request]=l.Request where l.Request " +
                        "IN ('" + String.Join("' ,'", lista_num_nav) + "')", conexion_nav);
                    SqlDataReader nav_bd = comm_nav.ExecuteReader();

                    while (nav_bd.Read())
                    {
                        String[] nav = new String[8];
                        nav[0] = nav_bd["solicitud"].ToString();
                        nav[1] = nav_bd["activo"].ToString();
                        nav[2] = nav_bd["descripcion"].ToString();
                        nav[3] = nav_bd["pedido"].ToString();
                        nav[4] = nav_bd["notacomprador"].ToString();
                        nav[5] = nav_bd["autorizador"].ToString();
                        nav[6] = nav_bd["aprobado"].ToString();
                        nav[6] = (nav[6] == "1") ? "APROBADO" : "SIN APROBAR";
                        nav[7] = nav_bd["horaaprobacion"].ToString();
                        lista_nav.Add(nav);
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error al obtener datos de NAV TRACSA\n\nError: " + error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Windows.Forms.Application.Exit();
            }


            foreach (String[] sitti in lista_sitti)
            {
                String[] sisac_nuevo = new String[9];
                String[] nav_nuevo = new String[9];
                foreach (String[] sisac in lista_sisac)
                {
                    if (sisac[0] == sitti[5])
                    {
                        sisac_nuevo[0] = sisac[0];
                        sisac_nuevo[1] = sisac[1];
                        sisac_nuevo[2] = sisac[2];
                        sisac_nuevo[3] = sisac[3];
                        sisac_nuevo[4] = sisac[4];
                        sisac_nuevo[5] = sisac[5];
                        sisac_nuevo[6] = sisac[6];
                        sisac_nuevo[7] = sisac[7];
                        sisac_nuevo[8] = sisac[8];
                        for (int i = 0; i <= 8; i++)
                        {
                            //sisac_nuevo[i] = (String.IsNullOrEmpty(sisac_nuevo[i])) ? "N/A" : sisac_nuevo[i];
                        }
                        break;
                    }
                }
                foreach(String[] nav in lista_nav)
                {
                    if(nav[0] == sitti[4])
                    {
                        nav_nuevo[0] = nav[0];
                        nav_nuevo[1] = nav[1];
                        nav_nuevo[2] = nav[2];
                        nav_nuevo[3] = nav[3];
                        nav_nuevo[4] = nav[4];
                        nav_nuevo[5] = nav[5];
                        nav_nuevo[6] = nav[6];
                        nav_nuevo[7] = nav[7];
                        for (int i = 0; i <= 7; i++)
                        {
                            //nav_nuevo[i] = (String.IsNullOrEmpty(nav_nuevo[i])) ? "N/A" : nav_nuevo[i];
                        }
                        nav_nuevo[7] = (String.Equals(nav[7], "01/01/1753 12:00:00 a. m.")) ? "" : nav[7];
                        break;
                    }
                }
                //Descripcion de sisac
                sisac_nuevo[6] = (String.IsNullOrEmpty(sisac_nuevo[6])) ? nav_nuevo[2] : sisac_nuevo[6];
                dataGridView1.Rows.Add(sitti[0], sitti[2], sisac_nuevo[0], sisac_nuevo[1], sisac_nuevo[3], sisac_nuevo[4], sisac_nuevo[5], sisac_nuevo[6], nav_nuevo[0], nav_nuevo[4], nav_nuevo[5], nav_nuevo[6], nav_nuevo[7], nav_nuevo[3]);
                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }

            //ExportarDataGridViewExcel(dataGridView1);
        }


        void ExportarDataGridViewExcel(DataGridView grd)
        {
            using (SaveFileDialog fichero = new SaveFileDialog { Filter = @"Excel (*.xls)|*.xls" })
            {
                if (fichero.ShowDialog() == DialogResult.OK)
                {
                    Microsoft.Office.Interop.Excel.Application aplicacion = new Microsoft.Office.Interop.Excel.Application();
                    Workbook librosTrabajo = aplicacion.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
                    Worksheet hojaTrabajo = (Worksheet)librosTrabajo.Worksheets.get_Item(1);
                    int iCol = 0;
                    foreach (DataGridViewColumn column in dataGridView1.Columns)
                        if (column.Visible)
                            hojaTrabajo.Cells[1, ++iCol] = column.HeaderText;
                    for (int i = 0; i < grd.Rows.Count - 1; i++)
                    {
                        for (int j = 0; j < grd.Columns.Count; j++)
                        {
                            if (grd.Rows[i].Cells[j].Value is null)
                            {
                                hojaTrabajo.Cells[i + 2, j + 1] = "";
                            }
                            else
                            {
                                hojaTrabajo.Cells[i + 2, j + 1] = grd.Rows[i].Cells[j].Value.ToString();
                            }
                        }
                    }
                    librosTrabajo.SaveAs(fichero.FileName, XlFileFormat.xlWorkbookNormal,
                                          System.Reflection.Missing.Value, System.Reflection.Missing.Value, false, false,
                                          XlSaveAsAccessMode.xlShared, false, false,
                                          System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value);
                    aplicacion.Quit();
                }
            }
            MessageBox.Show("Reporte guardado.", "Reporte de Compras", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void exportarAExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportarDataGridViewExcel(dataGridView1);
        }
    }
}

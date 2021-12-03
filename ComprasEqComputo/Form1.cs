using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ComprasEqComputo
{
    public partial class Form1 : Form
    {
        /*
         * V1.144
         * - SE AGREGAN CAMPOS (SISAC, HARDWARE Y SOFTWARE) EN AGREGAR COMENTARIOS
         * - SE ENVIA CORREO AL AGREGAR COMENTARIOS
         */
        private String versiontext = "1.144";
        private String version = "568b94fbcbf31d2d2a6093f7c825ba48";

        public static String conexionsql_infeq = "server=148.223.153.37,5314; database=InfEq;User ID=eordazs;Password=Corpame*2013; integrated security = false ; MultipleActiveResultSets=True";
        public static String conexionsql_sitti = "server=148.223.153.43\\MSSQLSERVER1; database=bd_SiTTi;User ID=sa;Password=At3n4; integrated security = false ; MultipleActiveResultSets=True";
        public static String conexionsql_sisac = "server=148.223.153.43\\MSSQLSERVER1; database=bd_SiSAC;User ID=sa;Password=At3n4; integrated security = false ; MultipleActiveResultSets=True";
        public static String conexionsql_nomina = "server=40.76.105.1,5055; database=Nom2001;User ID=reportesUNNE;Password=8rt=h!RdP9gVy; integrated security = false ; MultipleActiveResultSets=True";
        public static String conexionsql_nav = "server=40.76.105.1,5055; database=UnneProd;User ID=reportesUNNE;Password=8rt=h!RdP9gVy; integrated security = false ; MultipleActiveResultSets=True";
        public static String nombrebd = "[InfEq].[dbo].[ComprasEqComputo]";

        public static String cid;
        public static String sitti_ti;
        public static Boolean actualizar = false;

        //Variable para cambiar el boton de VerCompra para registrar economico o entregar equipo
        public static Boolean registrareconomico = true;

        //Activarla para entregar directo un equipo
        public static Boolean registrar_pendientes = true;

        /*  0 = Lista_compras
         *  1 = lista disponibles stock
         *  2 = lista disponibles usuarios
         *  3 = lista entregados
         */
        public static int lista = 0;

        public static List<String[]> lista_nomina = new List<String[]>();
        public static List<String[]> lista_compras = new List<String[]>();
        public static List<String[]> lista_disponibles_usuario = new List<String[]>();
        public static List<String[]> lista_disponibles_stock = new List<String[]>();
        public static List<String[]> lista_entregados = new List<String[]>();
        public static List<String[]> lista_nav = new List<String[]>();
        public static List<String[]> lista_sisac = new List<String[]>();

        public static List<String[]> lista_actualiza_compra = new List<String[]>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Actualizar()
        {
            lista_compras.Clear();
            lista_disponibles_usuario.Clear();
            lista_disponibles_stock.Clear();
            lista_entregados.Clear();
            lista_nomina.Clear();
            lista_nav.Clear();
            lista_sisac.Clear();

            lista_actualiza_compra.Clear();

            dataGridView1.Rows.Clear();

            
            this.FormBorderStyle = FormBorderStyle.None;
            this.TransparencyKey = Color.Gray;
            this.BackColor = Color.Gray;
            

            menuStrip1.Visible = false;
            dataGridView1.Visible = false;
            pictureBox1.BringToFront();
            pictureBox1.Visible = true;
            label1.Visible = true;

            if (backgroundWorker1.IsBusy != true)
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            Actualizar();
        }



        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //Validar version del programa
            try
            {
                label1.BeginInvoke(new System.Action(() => { label1.Text = "Validando versión..."; }));
                using (SqlConnection conexion_version = new SqlConnection(conexionsql_infeq))
                {
                    conexion_version.Open();
                    String sql2 = "SELECT (SELECT valor FROM Configuracion WHERE nombre='Compras_Version') as version,valor FROM Configuracion WHERE nombre='Compras_hash'";
                    SqlCommand comm2 = new SqlCommand(sql2, conexion_version);
                    SqlDataReader nwReader2 = comm2.ExecuteReader();
                    if (nwReader2.Read())
                    {
                        if (nwReader2["valor"].ToString() != version)
                        {
                            MessageBox.Show("No se puede inciar sesion porque hay una nueva version.\n\nNueva Version: " + nwReader2["version"].ToString() + "\nVersion actual: " + versiontext + "\n\nEl programa se cerrara.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            System.Windows.Forms.Application.Exit();
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se puedo verificar la version del programa.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        System.Windows.Forms.Application.Exit();
                        return;
                    }
                    conexion_version.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en validar la version del programa\n\nMensaje: " + ex.Message, "Información del Equipo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Windows.Forms.Application.Exit();
                return;
            }

            //Cargar lista de Nomina
            try
            {
                using (SqlConnection conexion_nom = new SqlConnection(conexionsql_nomina))
                {
                    conexion_nom.Open();
                    String consulta = "SELECT nomtrab.nombre, nomtrab.apepat, nomtrab.apemat, ISNULL(CC.desubi,'') AS [cc], ISNULL(nompais.despai,'') AS [base], nomtrab.cvetra as numempleado,  ISNULL(nomciud.desciu,'') AS [empresa], RTRIM(LTRIM(ISNULL(nompues.despue,''))) AS [Puesto] , ISNULL(nompais.despai,'') AS 'Ubicacion', desdep as 'Departamento', desare as 'Direccion' FROM nomtrab LEFT JOIN nompues ON nomtrab.cvepue = nompues.cvepue AND nomtrab.cvecia = nompues.cvecia LEFT JOIN nomciud ON nomtrab.cvepa2 = nomciud.cvepai AND nomtrab.cveci2 = nomciud.cveciu AND nomtrab.cvecia = nomciud.cvecia LEFT JOIN nomubic CC ON nomtrab.cvepa2 = CC.cvepai AND nomtrab.cveci2 = CC.cveciu AND nomtrab.cvecia = CC.cvecia AND nomtrab.cveubi = CC.cveubi LEFT JOIN nompais ON nomtrab.cvepa2 = nompais.cvepai AND nomtrab.cvecia = nompais.cvecia left join nomarea on nomtrab.cveare=nomarea.cveare and nomtrab.cvecia =nomarea.cvecia  left join nomdept on nomtrab.cvedep=nomdept.cvedep and nomarea.cveare=nomdept.cveare and nomtrab.cvecia = nomdept.cvecia WHERE nomtrab.status = 'A'";
                    SqlCommand comm = new SqlCommand(consulta, conexion_nom);
                    SqlDataReader nwReader = comm.ExecuteReader();

                    String[] na = new String[12];
                    na[0] = "S/N";
                    na[1] = "NO REGISTRADO";
                    na[2] = "NO REGISTRADO";
                    na[3] = "NO REGISTRADO";
                    na[4] = "NO REGISTRADO";
                    na[5] = "NO REGISTRADO";
                    na[6] = "NO REGISTRADO";
                    na[7] = "NO REGISTRADO";
                    na[8] = "NO REGISTRADO";
                    na[9] = "NO REGISTRADO";
                    na[10] = "NO REGISTRADO";
                    na[11] = "NO REGISTRADO";
                    lista_nomina.Add(na);

                    while (nwReader.Read())
                    {
                        String[] n = new String[12];
                        n[0] = nwReader["numempleado"].ToString().TrimEnd(' ');
                        n[1] = nwReader["nombre"].ToString().TrimEnd(' ');
                        n[2] = nwReader["apepat"].ToString().TrimEnd(' ');
                        n[3] = nwReader["apemat"].ToString().TrimEnd(' ');
                        n[4] = nwReader["cc"].ToString().TrimEnd(' ');
                        n[5] = nwReader["base"].ToString().TrimEnd(' ');
                        n[6] = nwReader["Puesto"].ToString().TrimEnd(' ');
                        n[7] = nwReader["empresa"].ToString().TrimEnd(' ');
                        n[8] = n[1] + " " + n[2] + " " + n[3];
                        n[9] = nwReader["ubicacion"].ToString().TrimEnd(' ');
                        n[10] = nwReader["departamento"].ToString().TrimEnd(' ');
                        n[11] = nwReader["direccion"].ToString().TrimEnd(' ');
                        lista_nomina.Add(n);

                        label1.BeginInvoke(new System.Action(() => { label1.Text = "Cargando empleado: "+n[0]; }));
                    }
                    conexion_nom.Close();
                }
            }
            catch (System.Exception ex)
            {
                e.Cancel = true;
                MessageBox.Show("Error en la lectura de empleados.\nEl Programa se cerrara.\n\nMensaje: " + ex.Message, "Información del Equipo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Windows.Forms.Application.Exit();
            }

            //ALMACENAR LISTA DE EQUIPOS
            try
            {
                label1.BeginInvoke(new System.Action(() => { label1.Text = "Cargando compras"; }));
                using (SqlConnection conexion_comprasequipos = new SqlConnection(conexionsql_infeq))
                {
                    conexion_comprasequipos.Open();
                    SqlCommand comm = new SqlCommand("SELECT * FROM " + nombrebd + " ORDER BY cid DESC", conexion_comprasequipos);
                    SqlDataReader nwReader = comm.ExecuteReader();

                    while (nwReader.Read())
                    {
                        String[] nav = new String[9];
                        String[] sisac = new String[10];

                        String[] n = new String[26];
                        n[0] = nwReader["cid"].ToString();
                        n[1] = nwReader["nombre"].ToString();
                        n[2] = nwReader["ap_paterno"].ToString();
                        n[3] = nwReader["ap_materno"].ToString();
                        n[4] = nwReader["no_trabajador"].ToString();
                        n[5] = nwReader["puesto"].ToString();
                        n[6] = nwReader["cc"].ToString();
                        n[7] = nwReader["empresa"].ToString();
                        n[8] = nwReader["solicita"].ToString();
                        n[9] = nwReader["fecha_solicitud"].ToString();
                        n[10] = nwReader["sitti_ti"].ToString();
                        n[11] = nwReader["sitti_usuario"].ToString();
                        n[12] = nwReader["fecha_entrega"].ToString();
                        n[13] = nwReader["stock_reponer"].ToString();
                        n[14] = nwReader["stock_disponible"].ToString();
                        n[15] = nwReader["economico"].ToString();
                        n[16] = nwReader["sisac"].ToString();
                        n[17] = nwReader["hardware"].ToString();
                        n[18] = nwReader["entregada"].ToString();
                        n[19] = nwReader["comentario_ti"].ToString();
                        //ULTIMO COMENTARIO SE CARGA MAS ABAJO
                        n[21] = n[1] + " " + n[2] + " " + n[3];
                        //n[22] = Carga mas abajo el status del ticket (P, C, S)
                        n[23] = nwReader["nombre_entrega"].ToString();
                        n[24] = nwReader["tipo"].ToString();
                        n[25] = nwReader["pedidocompra"].ToString();

                        //Cargar equipos pendientes y ultimo comentario (sin economico)
                        if (String.IsNullOrEmpty(nwReader["economico"].ToString()) && nwReader["entregada"].ToString() == "0")
                        {
                            lista_compras.Add(n);
                        }


                        //Cargar equipos con economico
                        else
                        {
                            n[22] = "S";
                            //Equipos ya entregados a usuario
                            if (nwReader["entregada"].ToString() == "1")
                            {
                                n[20] = nwReader["ultimo_comentario"].ToString();
                                lista_entregados.Add(n);
                            }

                            //Equipos ya en sistemas pero aun no entregados
                            else
                            {
                                //Equipos disponibles de STOCK
                                if (nwReader["stock_disponible"].ToString() == "1")
                                {
                                    n[20] = nwReader["ultimo_comentario"].ToString();
                                    lista_disponibles_stock.Add(n);
                                }
                                //Equipos disponibles de usuarios para preparar
                                else
                                {
                                    n[20] = nwReader["ultimo_comentario"].ToString();
                                    lista_disponibles_usuario.Add(n);
                                }
                            }
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                e.Cancel = true;
                MessageBox.Show("Error en la busqueda de compras pendientes.\nEl Programa se cerrara.\n\nMensaje: " + ex.Message, "Información del Equipo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Windows.Forms.Application.Exit();
            }



            //CARGAR DATOS
            foreach (String[] compras in lista_compras)
            {
                // ULTIMO COMENTARIO, SISAC, SOLICITUD
                try
                {
                    using (SqlConnection conexion_historico = new SqlConnection(conexionsql_sitti))
                    {
                        conexion_historico.Open();
                        SqlCommand comm_h = new SqlCommand("SELECT TOP(1) h.*,t.scNAV_software,t.scNAV_hardware,t.no_SiSAC,t.status,ci.nombre " +
                            "FROM [bd_SiTTi].[dbo].[ms_historico] h LEFT JOIN [bd_SiTTi].[dbo].[ms_ticket] t ON h.id_ms_ticket=t.id_ms_ticket " +
                            "LEFT JOIN [bd_SiTTi].[dbo].[cg_cis] ci ON t.id_cis=ci.id_cis " +
                            "WHERE h.id_ms_ticket='" + compras[10] + "' " +
                            "ORDER BY h.id_ms_historico DESC", conexion_historico);
                        SqlDataReader historico = comm_h.ExecuteReader();
                        while (historico.Read())
                        {
                            /*
                             * lista_actualiza_compra
                             * 0 => CID
                             * 1 => SiTTi_ti
                             * 2 => Ultimo Comentario
                             * 3 => Fecha Ultimo Comentario
                             * 4 => Sisac
                             * 5 => # Solicitud
                             * 6 => Estatus SiTTi
                             * 7 => scNAV_hardware (para insertar)
                             * 8 => scNAV_software
                             * 9 => CI
                             */
                            String[] ultimo_comentario = new String[11];
                            ultimo_comentario[0] = compras[0];
                            ultimo_comentario[1] = compras[10];
                            ultimo_comentario[2] = historico["comentario"].ToString();
                            ultimo_comentario[3] = historico["fecha_com"].ToString();
                            ultimo_comentario[6] = historico["status"].ToString();
                            ultimo_comentario[7] = historico["scNAV_hardware"].ToString();
                            ultimo_comentario[8] = historico["scNAV_software"].ToString();
                            ultimo_comentario[9] = historico["nombre"].ToString();

                            if (!String.IsNullOrEmpty(historico["no_SiSAC"].ToString()))
                            {
                                ultimo_comentario[4] = historico["no_SiSAC"].ToString();
                            }


                            if (String.IsNullOrEmpty(historico["scNAV_hardware"].ToString()) && String.IsNullOrEmpty(historico["scNAV_software"].ToString()))
                            {
                                //No guardar nada
                            }
                            else if (String.IsNullOrEmpty(historico["scNAV_hardware"].ToString()))
                            {
                                compras[17] = historico["scNAV_software"].ToString();
                                ultimo_comentario[5] = historico["scNAV_software"].ToString();
                            }
                            else
                            {
                                compras[17] = historico["scNAV_hardware"].ToString();
                                ultimo_comentario[5] = historico["scNAV_hardware"].ToString();
                            }

                            label1.BeginInvoke(new System.Action(() => { label1.Text = "Cargando comentario: " + compras[0]; }));
                            lista_actualiza_compra.Add(ultimo_comentario);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al leer el ultimo comentario del sitti: " + compras[10] + ".\n\nMensaje: " + ex.Message, "Compras", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }


                //CARGAR PEDIDO DE COMPRA Y TRAER DATOS DE NAV
                if (!String.IsNullOrEmpty(compras[17]))
                {
                    using (SqlConnection conexion_pedidocompra = new SqlConnection(conexionsql_nav))
                    {
                        conexion_pedidocompra.Open();
                        SqlCommand comm_pc = new SqlCommand("select TOP(1) l.Request as [solicitud], No_ as [activo], l.Description as [descripcion] , l.[No_ Purchase Order] as [pedido], " +
                            "l.[Note to Buyer] as [notacomprador], p.[User approval] as [autorizador], p.[Approved] as [aprobado], p.[Fecha_Hora Aprobación] as [horaaprobacion] " +
                            "from [" + compras[7] + "$Lines purchase request] l " +
                            "LEFT JOIN [" + compras[7] + "$Purchase Request Header ] p ON p.[Request]=l.Request where l.Request='" + compras[17] + "'", conexion_pedidocompra);

                        SqlDataReader pedidocompra = comm_pc.ExecuteReader();
                        while (pedidocompra.Read())
                        {
                            String[] nav = new String[9];
                            nav[0] = compras[0]; //Obtiene CID
                            nav[1] = pedidocompra["solicitud"].ToString();  // Num de Solicitud
                            nav[2] = pedidocompra["activo"].ToString();     // Num de activo
                            nav[3] = pedidocompra["descripcion"].ToString();// Descripcion de la compra
                            nav[4] = pedidocompra["pedido"].ToString();     // Pedido de compra
                            nav[5] = pedidocompra["notacomprador"].ToString();  //  Nota de comprador
                            nav[6] = pedidocompra["autorizador"].ToString(); //Autorizador
                            nav[7] = pedidocompra["aprobado"].ToString();   // Si esta aprobado (1 o 0)
                            nav[8] = pedidocompra["horaaprobacion"].ToString(); //Hora de aprobacion
                            lista_nav.Add(nav);
                        }
                        label1.BeginInvoke(new System.Action(() => { label1.Text = "Cargando NAV: " + compras[0]; }));
                    }
                }



                //CARGAR SISAC
                if (!String.IsNullOrEmpty(compras[16]))
                {
                    try
                    {
                        using (SqlConnection conexion_sisac = new SqlConnection(conexionsql_sisac))
                        {
                            conexion_sisac.Open();
                            SqlCommand comm_sisac = new SqlCommand("SELECT [No.] as [ticket], [Empresa(s)] as [empresa], Solicitante as [solicita], " +
                                "Comprador as [comprador], Estatus as [estatus], Código as [codigo], Descripción as [descripcion], Marca as [marca], " +
                                "[Último Precio] as [ultimoprecio] " +
                                "FROM [bd_SiSAC].[dbo].[LNJ_Tablas_Comparativas] where [No.]='" + compras[16] + "'", conexion_sisac);
                            SqlDataReader sisacdb = comm_sisac.ExecuteReader();
                            while (sisacdb.Read())
                            {
                                String[] sisac = new String[10];
                                sisac[0] = compras[0];
                                sisac[1] = sisacdb["ticket"].ToString(); //Numero de Ticket sisac
                                sisac[2] = sisacdb["empresa"].ToString(); //Empresas
                                sisac[3] = sisacdb["solicita"].ToString(); //Quien levanta el Sisac
                                sisac[4] = sisacdb["comprador"].ToString(); //Quien es el comprador
                                sisac[5] = sisacdb["estatus"].ToString(); //Estatus actual
                                sisac[6] = sisacdb["codigo"].ToString(); //Codigo si existe
                                sisac[7] = sisacdb["descripcion"].ToString(); //Descripcion del producto
                                sisac[8] = sisacdb["marca"].ToString(); //Marca
                                sisac[9] = sisacdb["ultimoprecio"].ToString(); //Ultimo Precio
                                lista_sisac.Add(sisac);
                            }
                            label1.BeginInvoke(new System.Action(() => { label1.Text = "Cargando SiSAC: " + compras[0]; }));
                        }
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Error al actualizar datos de SiSac de la compra " + compras[0] + "\n\nError: " + error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        System.Windows.Forms.Application.Exit();
                    }
                }
            }

            //INSERTAR ULTIMO COMENTARIO, SISAC Y SOLICITUD
            foreach (String[] comentario in lista_actualiza_compra)
            {
                try
                {
                    using (SqlConnection conexion_comprasequipos = new SqlConnection(conexionsql_infeq))
                    {
                        conexion_comprasequipos.Open();
                        String agregar_ultimo_comentario = "UPDATE " + nombrebd + " SET sisac=@sisac, hardware=@hardware, ultimo_comentario=@comentario WHERE cid=@cid";
                        SqlCommand comm_agrega_comment = new SqlCommand(agregar_ultimo_comentario, conexion_comprasequipos);

                        comm_agrega_comment.Parameters.AddWithValue("@comentario", comentario[2]);
                        comm_agrega_comment.Parameters.AddWithValue("@cid", comentario[0]);
                        
                        //Revisar si esta vacio sisac
                        if (String.IsNullOrEmpty(comentario[4]))
                        {
                            comm_agrega_comment.Parameters.AddWithValue("@sisac", DBNull.Value);
                        }
                        else
                        {
                            comm_agrega_comment.Parameters.AddWithValue("@sisac", comentario[4]);
                        }
                        //Revisar si esta vacio solicitud de compra
                        if (String.IsNullOrEmpty(comentario[5]))
                        {
                            comm_agrega_comment.Parameters.AddWithValue("@hardware", DBNull.Value);
                        }
                        else
                        {
                            comm_agrega_comment.Parameters.AddWithValue("@hardware", comentario[5]);
                        }

                        comm_agrega_comment.ExecuteNonQuery();
                        comm_agrega_comment.Parameters.Clear();
                        comm_agrega_comment.Dispose();
                        comm_agrega_comment = null;


                        int i = 0;
                        foreach (String[] compras in lista_compras)
                        {
                            if (compras[0] == comentario[0])
                            {
                                DateTime fechacomentario2 = Convert.ToDateTime(comentario[3]);
                                lista_compras[i][20] = fechacomentario2.ToString("dd/MM/yyyy") + ": " + comentario[2];

                                //Guardar Sisac
                                lista_compras[i][16] = comentario[4];
                                //Guardar Solicitud de compra
                                lista_compras[i][17] = comentario[5];
                                //Guardar Estatus del sitti
                                lista_compras[i][22] = comentario[6];
                            }
                            i++;
                        }

                        label1.BeginInvoke(new System.Action(() => { label1.Text = "Actualizando Comentarios: " + comentario[1]; }));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al insertar datos de la compra: " + comentario[0] + ".\n\nMensaje: " + ex.Message, "Compras", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
            }

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                System.Windows.Forms.Application.Exit();
            }
            if (lista_compras.Any())
            {
                int contarceldas = 0;
                foreach (String[] n in lista_compras)
                {
                    DateTime fecha_solicita = DateTime.Parse(n[9]);


                    n[1] = (n[1] == "NO REGISTRADO") ? n[5] : n[1];
                    n[21] = (n[2] == "NO REGISTRADO") ? n[1] : n[21];

                    String stock_agregar = "";
                    if(n[13] == "1")
                    {
                        stock_agregar= " (STOCK)";
                    }

                    dataGridView1.Rows.Add(n[0], n[24], n[10], n[17], n[16], n[7], n[21] + stock_agregar, fecha_solicita.ToShortDateString(), n[20], n[10], n[22]);
                    if (n[22] == "C" || n[22] == "S")
                    {
                        dataGridView1.Rows[contarceldas].DefaultCellStyle.BackColor = Color.PaleGreen;
                    }
                    if (n[22] == "P")
                    {
                        dataGridView1.Rows[contarceldas].DefaultCellStyle.BackColor = Color.LightSalmon;
                    }
                    dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    contarceldas++;
                }
            }


            menuStrip1.Visible = true;
            dataGridView1.Visible = true;
            pictureBox1.Visible = false;

            label1.Visible = false;

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.BackColor = Control.DefaultBackColor;
            this.Icon = ComprasEqComputo.Properties.Resources.ComprasEqComputo;

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null && !String.IsNullOrEmpty(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()))
                {
                    Clipboard.SetText(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                }
            }
        }

        private void nuevaSolicitudToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            NuevaSolicitud nueva_solicitud = new NuevaSolicitud();
            nueva_solicitud.ShowDialog();

            if (actualizar == true)
            {
                Actualizar();
                actualizar = false;
            }

            Show();
        }

        private void verEquiposDisponiblesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            registrareconomico = false;
            EquiposDisponibles equiposdisponibles = new EquiposDisponibles();
            equiposdisponibles.ShowDialog();
            if (actualizar == true)
            {
                Actualizar();
                actualizar = false;
            }
        }

        private void stockEntregadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            registrareconomico = false;
            EquiposEntregados equiposentregados = new EquiposEntregados();
            equiposentregados.ShowDialog();
        }

        private void stockPendientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            registrareconomico = false;
            EquiposDisponibleStock equiposdisponibles_stock = new EquiposDisponibleStock();
            equiposdisponibles_stock.ShowDialog();
            if (actualizar == true)
            {
                Actualizar();
                actualizar = false;
            }
        }

        private void actualizarDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                registrareconomico = true;
                lista = 0;
                sitti_ti = dataGridView1.Rows[e.RowIndex].Cells["sitti_ti_id"].Value.ToString();
                cid = dataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToString();
                VerCompra vercompra = new VerCompra();
                vercompra.ShowDialog();
                if (actualizar == true)
                {
                    Actualizar();
                    actualizar = false;
                }
            }
        }

        private void tiposDeCompraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TipoCompra tipodecompra = new TipoCompra();
            tipodecompra.ShowDialog();
        }

        private void eliminarCompraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EliminarCompra eliminarcompra = new EliminarCompra();
            eliminarcompra.ShowDialog();
        }

        private void reporteSiTTiDanielToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReporteDaniel dani = new ReporteDaniel();
            dani.ShowDialog();
        }

    }
}

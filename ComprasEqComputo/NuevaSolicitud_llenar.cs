using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace ComprasEqComputo
{
    public partial class NuevaSolicitud_llenar : Form
    {
        public NuevaSolicitud_llenar()
        {
            InitializeComponent();
        }

        private void NuevaSolicitud_llenar_Load(object sender, EventArgs e)
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

                        foreach (var word in words)
                        {
                            tipo.Items.Add($"{word}");
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
            text_nombre.Text = NuevaSolicitud.comprar_a[8];
            text_num.Text = NuevaSolicitud.comprar_a[0];
            text_puesto.Text = NuevaSolicitud.comprar_a[6];
            text_cc.Text = NuevaSolicitud.comprar_a[4];
            text_dep.Text = NuevaSolicitud.comprar_a[10];
            text_dir.Text = NuevaSolicitud.comprar_a[11];
            text_empresa.Text = NuevaSolicitud.comprar_a[7];
            text_ubi.Text = NuevaSolicitud.comprar_a[9];
            tipo.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (sittiusuario.Value < 1)
            {
                MessageBox.Show("El # de SiTTi de usuario debe ser mayor a 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int sitti_generado = 0;
            
            //insertar sitti de compra (de Edson a Daniel)
            using (SqlConnection conexion = new SqlConnection(Form1.conexionsql_sitti))
            {
                try
                {
                    conexion.Open();
                    String insert = "INSERT INTO ms_ticket (id_empl_solicita, fecha_solicita, id_cat_ticket, id_urgencia, id_impacto, id_prioridad, " +
                        "id_area_soporte, id_cat_soporte, id_cis, id_usr_asignado, descripcion, notas, fecha_limite, fecha_termino, id_asigno, empresa, base, " +
                        "cc, puesto, medioReporte, fecha_asigno, status, uniTiempo, Tiempo, banJust, just, id_usr_just, fecha_just, prov_externo, fecha_asigC, " +
                        "error_usr, scNAV, scNAV_hardware, scNAV_software, no_SiSAC, no_modif, id_usr_ult_modif, fecha_ult_modif, desarrollo) " +
                        "VALUES (@id_empl_solicita, @fecha_solicita, @id_cat_ticket, @id_urgencia, @id_impacto, @id_prioridad, @id_area_soporte, @id_cat_soporte, " +
                        "@id_cis, @id_usr_asignado, @descripcion, @notas, @fecha_limite, @fecha_termino, @id_asigno, @empresa, @base, @cc, @puesto, @medioReporte, " +
                        "@fecha_asigno, @status, @uniTiempo, @Tiempo, @banJust, @just, @id_usr_just, @fecha_just, @prov_externo, @fecha_asigC, @error_usr, @scNAV, " +
                        "@scNAV_hardware, @scNAV_software, @no_SiSAC, @no_modif, @id_usr_ult_modif, @fecha_ult_modif, @desarrollo)";

                    SqlCommand cmdIns = new SqlCommand(insert, conexion);

                    DateTime hora;
                    String fecha_limite;
                    String fecha_limite_correo;
                    hora = checarhora(45);
                    fecha_limite = hora.ToString("yyyy-MM-ddTHH:mm:ss.fff");
                    fecha_limite_correo = hora.ToString("dd/MM/yyyy HH:mm:ss tt");


                    String comentarios_ti = "";
                    String comentarios_ti_correo = "";
                    if (!String.IsNullOrEmpty(richTextBox1.Text))
                    {
                        comentarios_ti = "\n\nCOMENTARIOS: " + richTextBox1.Text;
                        comentarios_ti_correo = "<b>COMENTARIOS:</b> " + richTextBox1.Text + "<br><br>";
                    }

                    String mensajecorreo = "DANI FAVOR DE REALIZAR UNA COMPRA PARA EL SIGUIENTE USUARIO.";
                    String mensaje = "DANI FAVOR DE REALIZAR UNA COMPRA PARA EL SIGUIENTE USUARIO." +
                        "\n\nTIPO:    " + tipo.SelectedItem +
                        "\nNOMBRE:    " + text_nombre.Text.ToUpper() +
                        "\nNUM.EMPLEADO:    " + text_num.Text.ToUpper() +
                        "\nPUESTO: " + text_puesto.Text.ToUpper() +
                        "\nCENTRO DE COSTOS: " + text_cc.Text.ToUpper() +
                        "\nDEPARTAMENTO: " + text_dep.Text.ToUpper() +
                        "\nDIRECCION: " + text_dir.Text.ToUpper() +
                        "\nEMPRESA: " + text_empresa.Text.ToUpper() +
                        "\nUBICACION: " + text_ubi.Text.ToUpper() + comentarios_ti.ToUpper() + "";

                    cmdIns.Parameters.AddWithValue("@id_empl_solicita", "854");
                    cmdIns.Parameters.AddWithValue("@fecha_solicita", DateTime.Now.ToString("s"));
                    cmdIns.Parameters.AddWithValue("@id_cat_ticket", "1");
                    cmdIns.Parameters.AddWithValue("@id_urgencia", "3");
                    cmdIns.Parameters.AddWithValue("@id_impacto", "3");
                    cmdIns.Parameters.AddWithValue("@id_prioridad", "9");
                    cmdIns.Parameters.AddWithValue("@id_area_soporte", "6");
                    cmdIns.Parameters.AddWithValue("@id_cat_soporte", "2095");
                    cmdIns.Parameters.AddWithValue("@id_cis", "4757");
                    cmdIns.Parameters.AddWithValue("@id_usr_asignado", "4523");
                    cmdIns.Parameters.AddWithValue("@descripcion", mensaje);
                    cmdIns.Parameters.AddWithValue("@notas", "");
                    cmdIns.Parameters.AddWithValue("@fecha_limite", fecha_limite);
                    cmdIns.Parameters.AddWithValue("@fecha_termino", DBNull.Value);
                    cmdIns.Parameters.AddWithValue("@id_asigno", "4307");
                    cmdIns.Parameters.AddWithValue("@empresa", "TRACSA");
                    cmdIns.Parameters.AddWithValue("@base", "TULA");
                    cmdIns.Parameters.AddWithValue("@cc", "SISTEMAS");
                    cmdIns.Parameters.AddWithValue("@puesto", "COORDINADOR DE SOPORTE TECNICO");
                    cmdIns.Parameters.AddWithValue("@medioReporte", "SiTTi");
                    cmdIns.Parameters.AddWithValue("@fecha_asigno", DateTime.Now.ToString("s"));
                    cmdIns.Parameters.AddWithValue("@status", "P");
                    cmdIns.Parameters.AddWithValue("@uniTiempo", "D");
                    cmdIns.Parameters.AddWithValue("@Tiempo", "5");
                    cmdIns.Parameters.AddWithValue("@banJust", "N");
                    cmdIns.Parameters.AddWithValue("@just", DBNull.Value);
                    cmdIns.Parameters.AddWithValue("@id_usr_just", DBNull.Value);
                    cmdIns.Parameters.AddWithValue("@fecha_just", DBNull.Value);
                    cmdIns.Parameters.AddWithValue("@prov_externo", DBNull.Value);
                    cmdIns.Parameters.AddWithValue("@fecha_asigC", DateTime.Now.ToString("s"));
                    cmdIns.Parameters.AddWithValue("@error_usr", DBNull.Value);
                    cmdIns.Parameters.AddWithValue("@scNAV", "N");
                    cmdIns.Parameters.AddWithValue("@scNAV_hardware", DBNull.Value);
                    cmdIns.Parameters.AddWithValue("@scNAV_software", DBNull.Value);
                    cmdIns.Parameters.AddWithValue("@no_SiSAC", DBNull.Value);
                    cmdIns.Parameters.AddWithValue("@no_modif", 0);
                    cmdIns.Parameters.AddWithValue("@id_usr_ult_modif", DBNull.Value);
                    cmdIns.Parameters.AddWithValue("@fecha_ult_modif", DBNull.Value);
                    cmdIns.Parameters.AddWithValue("@desarrollo", "N");

                    cmdIns.ExecuteNonQuery();
                    cmdIns.Parameters.Clear();

                    cmdIns.CommandText = "SELECT @@IDENTITY";

                    sitti_generado = Convert.ToInt32(cmdIns.ExecuteScalar());

                    cmdIns.Dispose();
                    cmdIns = null;


                    #region Enviar Correo
                    List<string> lstAllRecipients = new List<string>();
                    //Below is hardcoded - can be replaced with db data
                    lstAllRecipients.Add("daniel.gonzalez@unne.com.mx");

                    Outlook.Application outlookApp = new Outlook.Application();
                    Outlook._MailItem oMailItem = (Outlook._MailItem)outlookApp.CreateItem(Outlook.OlItemType.olMailItem);
                    Outlook.Inspector oInspector = oMailItem.GetInspector;

                    // Recipient
                    Outlook.Recipients oRecips = (Outlook.Recipients)oMailItem.Recipients;
                    foreach (String recipient in lstAllRecipients)
                    {
                        Outlook.Recipient oRecip = (Outlook.Recipient)oRecips.Add(recipient);
                        oRecip.Resolve();
                    }
                    oMailItem.Subject = "Compra de "+ tipo.SelectedItem+" " + sitti_generado;
                    //oMailItem.Subject = "Compra de Equipo " + sitti_generado;

                    String FirmaBody = oMailItem.HTMLBody;

                    oMailItem.HTMLBody = "<html xmlns:v=\"urn:schemas-microsoft-com:vml\" xmlns:o=\"urn:schemas-microsoft-com:office:office\" xmlns:w=\"urn:schemas-microsoft-com:office:word\" xmlns:x=\"urn:schemas-microsoft-com:office:excel\" xmlns:m=\"http://schemas.microsoft.com/office/2004/12/omml\" xmlns=\"http://www.w3.org/TR/REC-html40\"><head><meta http-equiv=Content-Type content=\"text/html; charset=iso-8859-1\"><meta name=Generator content=\"Microsoft Word 15 (filtered medium)\"><!--[if !mso]>   <style>v\\:* {behavior:url(#default#VML);}o\\:* {behavior:url(#default#VML);}w\\:* {behavior:url(#default#VML);}.shape {behavior:url(#default#VML);}</style><![endif]-->   <style>   <!--/* Font Definitions */@font-face	{font-family:Helvetica;	panose-1:2 11 6 4 2 2 2 2 2 4;}@font-face	{font-family:\"Cambria Math\";	panose-1:2 4 5 3 5 4 6 3 2 4;}@font-face	{font-family:Calibri;	panose-1:2 15 5 2 2 2 4 3 2 4;}@font-face	{font-family:Tahoma;	panose-1:2 11 6 4 3 5 4 4 2 4;}@font-face	{font-family:Verdana;	panose-1:2 11 6 4 3 5 4 4 2 4;}/* Style Definitions */p.MsoNormal, li.MsoNormal, div.MsoNormal	{margin:0cm;	margin-bottom:.0001pt;	font-size:11.0pt;	font-family:\"Calibri\",sans-serif;	mso-fareast-language:EN-US;}a:link, span.MsoHyperlink	{mso-style-priority:99;	color:#0563C1;	text-decoration:underline;}a:visited, span.MsoHyperlinkFollowed	{mso-style-priority:99;	color:#954F72;	text-decoration:underline;}span.EstiloCorreo17	{mso-style-type:personal-compose;	font-family:\"Calibri\",sans-serif;	color:#2F5496;}.MsoChpDefault	{mso-style-type:export-only;	font-family:\"Calibri\",sans-serif;	mso-fareast-language:EN-US;}@page WordSection1	{size:612.0pt 792.0pt;	margin:70.85pt 3.0cm 70.85pt 3.0cm;}div.WordSection1	{page:WordSection1;}-->   </style><!--[if gte mso 9]>   <xml>   <o:shapedefaults v:ext=\"edit\" spidmax=\"1026\" /></xml><![endif]--><!--[if gte mso 9]>   <xml>   <o:shapelayout v:ext=\"edit\">      <o:idmap v:ext=\"edit\" data=\"1\" />   </o:shapelayout></xml><![endif]--></head><body lang=ES-MX link=\"#0563C1\" vlink=\"#954F72\"><div class=WordSection1><p class=MsoNormal>   <span style='color:#2F5496'>      " + mensajecorreo + "<o:p></o:p>   </span></p><p class=MsoNormal>   <span style='color:#2F5496'>      <o:p>&nbsp;</o:p>   </span></p><table class=MsoNormalTable border=0 cellspacing=0 cellpadding=0 width=0 style='width:305.0pt;margin-left:.1pt;border-collapse:collapse'>   <tr style='height:15.0pt'>      <td width=117 nowrap valign=bottom style='width:88.0pt;border:solid windowtext 1.0pt;background:#DDEBF7;padding:0cm 3.5pt 0cm 3.5pt;height:15.0pt'><p class=MsoNormal>   <b>      <span style='color:black;mso-fareast-language:ES-MX'>Tipo:       <o:p></o:p>      </span>   </b></p>      </td>      <td width=289 nowrap valign=bottom style='width:217.0pt;border:solid windowtext 1.0pt;border-left:none;padding:0cm 3.5pt 0cm 3.5pt;height:15.0pt'><p class=MsoNormal>   <span style='color:black;mso-fareast-language:ES-MX'>      " + tipo.SelectedItem + "<o:p></o:p>   </span></p>      </td>   </tr>   <tr style='height:15.0pt'>      <td width=117 nowrap valign=bottom style='width:88.0pt;border:solid windowtext 1.0pt;background:#DDEBF7;padding:0cm 3.5pt 0cm 3.5pt;height:15.0pt'><p class=MsoNormal>   <b>      <span style='color:black;mso-fareast-language:ES-MX'>Nombre:       <o:p></o:p>      </span>   </b></p>      </td>      <td width=289 nowrap valign=bottom style='width:217.0pt;border:solid windowtext 1.0pt;border-left:none;padding:0cm 3.5pt 0cm 3.5pt;height:15.0pt'><p class=MsoNormal>   <span style='color:black;mso-fareast-language:ES-MX'>      " + text_nombre.Text.ToUpper() + "<o:p></o:p>   </span></p>      </td>   </tr>   <tr style='height:15.0pt'>      <td width=117 nowrap valign=bottom style='width:88.0pt;border:solid windowtext 1.0pt;border-top:none;background:#DDEBF7;padding:0cm 3.5pt 0cm 3.5pt;height:15.0pt'><p class=MsoNormal>   <b>      <span style='color:black;mso-fareast-language:ES-MX'>Núm. Empleado:      <o:p></o:p>      </span>   </b></p>      </td>      <td width=289 nowrap valign=bottom style='width:217.0pt;border-top:none;border-left:none;border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;padding:0cm 3.5pt 0cm 3.5pt;height:15.0pt'><p class=MsoNormal>   <span style='color:black;mso-fareast-language:ES-MX'>      " + text_num.Text.ToUpper() + "<o:p></o:p>   </span></p>      </td>   </tr>   <tr style='height:15.0pt'>      <td width=117 nowrap valign=bottom style='width:88.0pt;border:solid windowtext 1.0pt;border-top:none;background:#DDEBF7;padding:0cm 3.5pt 0cm 3.5pt;height:15.0pt'><p class=MsoNormal>   <b>      <span style='color:black;mso-fareast-language:ES-MX'>Puesto:      <o:p></o:p>      </span>   </b></p>      </td>      <td width=289 nowrap valign=bottom style='width:217.0pt;border-top:none;border-left:none;border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;padding:0cm 3.5pt 0cm 3.5pt;height:15.0pt'><p class=MsoNormal>   <span style='color:black;mso-fareast-language:ES-MX'>      " + text_puesto.Text.ToUpper() + "<o:p></o:p>   </span></p>      </td>   </tr>   <tr style='height:15.0pt'>      <td width=117 nowrap valign=bottom style='width:88.0pt;border:solid windowtext 1.0pt;border-top:none;background:#DDEBF7;padding:0cm 3.5pt 0cm 3.5pt;height:15.0pt'><p class=MsoNormal>   <b>      <span style='color:black;mso-fareast-language:ES-MX'>Centro de Costos:      <o:p></o:p>      </span>   </b></p>      </td>      <td width=289 nowrap valign=bottom style='width:217.0pt;border-top:none;border-left:none;border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;padding:0cm 3.5pt 0cm 3.5pt;height:15.0pt'><p class=MsoNormal>   <span style='color:black;mso-fareast-language:ES-MX'>      " + text_cc.Text.ToUpper() + "<o:p></o:p>   </span></p>      </td>   </tr>   <tr style='height:15.0pt'>      <td width=117 nowrap valign=bottom style='width:88.0pt;border:solid windowtext 1.0pt;border-top:none;background:#DDEBF7;padding:0cm 3.5pt 0cm 3.5pt;height:15.0pt'><p class=MsoNormal>   <b>      <span style='color:black;mso-fareast-language:ES-MX'>Departamento:      <o:p></o:p>      </span>   </b></p>      </td>      <td width=289 nowrap valign=bottom style='width:217.0pt;border-top:none;border-left:none;border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;padding:0cm 3.5pt 0cm 3.5pt;height:15.0pt'><p class=MsoNormal>   <span style='color:black;mso-fareast-language:ES-MX'>      " + text_dep.Text.ToUpper() + "<o:p></o:p>   </span></p>      </td>   </tr>   <tr style='height:15.0pt'>      <td width=117 nowrap valign=bottom style='width:88.0pt;border:solid windowtext 1.0pt;border-top:none;background:#DDEBF7;padding:0cm 3.5pt 0cm 3.5pt;height:15.0pt'><p class=MsoNormal>   <b>      <span style='color:black;mso-fareast-language:ES-MX'>Dirección:      <o:p></o:p>      </span>   </b></p>      </td>      <td width=289 nowrap valign=bottom style='width:217.0pt;border-top:none;border-left:none;border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;padding:0cm 3.5pt 0cm 3.5pt;height:15.0pt'><p class=MsoNormal>   <span style='color:black;mso-fareast-language:ES-MX'>      " + text_dir.Text.ToUpper() + "<o:p></o:p>   </span></p>      </td>   </tr>   <tr style='height:15.0pt'>      <td width=117 nowrap valign=bottom style='width:88.0pt;border:solid windowtext 1.0pt;border-top:none;background:#DDEBF7;padding:0cm 3.5pt 0cm 3.5pt;height:15.0pt'><p class=MsoNormal>   <b>      <span style='color:black;mso-fareast-language:ES-MX'>Empresa:       <o:p></o:p>      </span>   </b></p>      </td>      <td width=289 nowrap valign=bottom style='width:217.0pt;border-top:none;border-left:none;border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;padding:0cm 3.5pt 0cm 3.5pt;height:15.0pt'><p class=MsoNormal>   <span style='color:black;mso-fareast-language:ES-MX'>      " + text_empresa.Text.ToUpper() + "<o:p></o:p>   </span></p>      </td>   </tr>   <tr style='height:15.75pt'>      <td width=117 nowrap valign=bottom style='width:88.0pt;border:solid windowtext 1.0pt;border-top:none;background:#DDEBF7;padding:0cm 3.5pt 0cm 3.5pt;height:15.75pt'><p class=MsoNormal>   <b>      <span style='color:black;mso-fareast-language:ES-MX'>Ubicación:       <o:p></o:p>      </span>   </b></p>      </td>      <td width=289 nowrap valign=bottom style='width:217.0pt;border-top:none;border-left:none;border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;padding:0cm 3.5pt 0cm 3.5pt;height:15.75pt'><p class=MsoNormal>   <span style='color:black;mso-fareast-language:ES-MX'>      " + text_ubi.Text.ToUpper() + "<o:p></o:p>   </span></p>      </td>   </tr></table><p class=MsoNormal>   <span style='color:#2F5496'>      <o:p>&nbsp;</o:p>   </span></p><p class=MsoNormal>  <span style='color:#2F5496'> " + comentarios_ti_correo + "</span><span style='color:#2F5496'>No. SiTTi: </span><b><span style='font-size:8.0pt;font-family:\"Verdana\",sans-serif;color:#990000'>" + sitti_generado + "</span></b>";

                    oMailItem.HTMLBody += FirmaBody;
                    oMailItem.Display(true);
                    #endregion

                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al crear sitti de compra.\n\nMensaje: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            //insertar pendiente de compra
            using (SqlConnection conexion2 = new SqlConnection(Form1.conexionsql_infeq))
            {
                try
                {
                    conexion2.Open();
                    String insert = "INSERT INTO ComprasEqComputo (nombre, ap_paterno, ap_materno, no_trabajador, puesto, cc, empresa, solicita, fecha_solicitud, " +
                        "sitti_ti, sitti_usuario, fecha_entrega, stock_reponer, stock_disponible, economico, sisac, hardware, entregada, comentario_ti, " +
                        "ultimo_comentario, tipo) VALUES (@nombre, @ap_paterno, @ap_materno, @no_trabajador, @puesto, @cc, @empresa, @solicita, " +
                        "@fecha_solicitud, @sitti_ti, @sitti_usuario, @fecha_entrega, @stock_reponer, @stock_disponible, @economico, @sisac, @hardware, " +
                        "@entregada, @comentario_ti, @ultimo_comentario, @tipo)";

                    SqlCommand cmdIns = new SqlCommand(insert, conexion2);

                    int es_stock = (stock.Checked) ? 1 : 0;

                    NuevaSolicitud.comprar_a[1] = (NuevaSolicitud.comprar_a[1] == "NO REGISTRADO") ? text_nombre.Text.ToUpper() : NuevaSolicitud.comprar_a[1];
                    cmdIns.Parameters.AddWithValue("@nombre", NuevaSolicitud.comprar_a[1]);
                    cmdIns.Parameters.AddWithValue("@ap_paterno", NuevaSolicitud.comprar_a[2]);
                    cmdIns.Parameters.AddWithValue("@ap_materno", NuevaSolicitud.comprar_a[3]);
                    cmdIns.Parameters.AddWithValue("@no_trabajador", text_num.Text.ToUpper());
                    cmdIns.Parameters.AddWithValue("@puesto", text_puesto.Text.ToUpper());
                    cmdIns.Parameters.AddWithValue("@cc", text_cc.Text.ToUpper());
                    cmdIns.Parameters.AddWithValue("@empresa", text_empresa.Text.ToUpper());
                    cmdIns.Parameters.AddWithValue("@solicita", NuevaSolicitud.solicita[0]);
                    cmdIns.Parameters.AddWithValue("@fecha_solicitud", DateTime.Now.ToString("s"));
                    cmdIns.Parameters.AddWithValue("@sitti_ti", sitti_generado);
                    cmdIns.Parameters.AddWithValue("@sitti_usuario", sittiusuario.Value);
                    cmdIns.Parameters.AddWithValue("@fecha_entrega", DBNull.Value);
                    cmdIns.Parameters.AddWithValue("@stock_reponer", es_stock);
                    cmdIns.Parameters.AddWithValue("@stock_disponible", 0);
                    cmdIns.Parameters.AddWithValue("@economico", DBNull.Value);
                    cmdIns.Parameters.AddWithValue("@sisac", DBNull.Value);
                    cmdIns.Parameters.AddWithValue("@hardware", DBNull.Value);
                    cmdIns.Parameters.AddWithValue("@entregada", 0);
                    cmdIns.Parameters.AddWithValue("@comentario_ti", richTextBox1.Text);
                    cmdIns.Parameters.AddWithValue("@ultimo_comentario", DBNull.Value);
                    cmdIns.Parameters.AddWithValue("@tipo", tipo.SelectedItem);

                    cmdIns.ExecuteNonQuery();
                    cmdIns.Parameters.Clear();
                    cmdIns.CommandText = "SELECT @@IDENTITY";

                    int insertID = Convert.ToInt32(cmdIns.ExecuteScalar());

                    Form1.actualizar = true;

                    cmdIns.Dispose();
                    cmdIns = null;


                    MessageBox.Show("Datos guardados correctamente.\n\nSe creo el SiTTi de compra # " + sitti_generado, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al insertar usuario en tabla usuarios.\n\nMensaje: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private DateTime checarhora(int horas)
        {
            DateTime ahora = DateTime.Now;
            TimeSpan iniciocomida = new TimeSpan(14, 0, 0);
            TimeSpan terminodia = new TimeSpan(18, 0, 0);
            DateTime agregado = DateTime.Now.AddHours(horas);

            DateTime ahora2 = DateTime.Now;
            for (int i = 1; i <= horas; i++)
            {
                ahora = ahora.AddHours(1);

                if (ahora2.TimeOfDay < iniciocomida && ahora.TimeOfDay > iniciocomida)
                {
                    ahora = ahora.AddHours(1);
                }

                if (ahora2.TimeOfDay < terminodia && ahora.TimeOfDay > terminodia)
                {
                    ahora = ahora.AddHours(14);
                }

                ahora2 = ahora.AddHours(-1);


                if (ahora.DayOfWeek == DayOfWeek.Saturday)
                {
                    ahora = ahora.AddDays(1);
                    ahora2 = ahora2.AddDays(1);
                }
                if (ahora.DayOfWeek == DayOfWeek.Sunday)
                {
                    ahora = ahora.AddDays(1);
                    ahora2 = ahora2.AddDays(1);
                }
            }
            return ahora;
        }

    }
}

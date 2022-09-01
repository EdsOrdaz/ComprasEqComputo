using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Runtime.CompilerServices;
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
        public static String ci;
        public static String correo;

        private void AgregarComentario_Load(object sender, EventArgs e)
        {
            if(VerCompra.usuario_comentario=="E")
            {
                label4.Text = "Edson Eduardo Ordaz";
                correo = "daniel.gonzalez@unne.com.mx";
                usuario = "4307";
                comboBox1.SelectedIndex = 2;
            }
            if(VerCompra.usuario_comentario=="D")
            {
                label4.Text = "Daniel Gonzalez";
                correo = "edson.ordaz@unne.com.mx";
                usuario = "4523";
                comboBox1.SelectedIndex = 0;
            }

            foreach(String[] sitti in Form1.lista_actualiza_compra)
            {
                if(sitti[1] == VerCompra.verpedido[10])
                {
                    sisactxt.Text = sitti[4];
                    hardwaretxt.Text = sitti[7];
                    softwaretxt.Text = sitti[8];
                    ci = sitti[9];
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            richTextBox1.Enabled = false;

            if(String.IsNullOrEmpty(richTextBox1.Text))
            {
                MessageBox.Show("No puede estar vacio el campo de comentario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                button1.Enabled = true;
                richTextBox1.Enabled = true;
                return;
            }

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

                    String actualizar_estatus = "UPDATE ms_ticket SET status=@estatus, scNAV='S', scNAV_hardware=@hardware, scNAV_software=@software, no_SiSAC=@sisac" +
                        " WHERE id_ms_ticket=@ticket";

                    SqlCommand comm = new SqlCommand(actualizar_estatus, conexion);
                    //validar hardware
                    if (!String.IsNullOrEmpty(hardwaretxt.Text))
                    {
                        comm.Parameters.AddWithValue("@hardware", hardwaretxt.Text);
                    }
                    else
                    {
                        comm.Parameters.AddWithValue("@hardware", DBNull.Value);
                    }
                    //Valida software
                    if (!String.IsNullOrEmpty(softwaretxt.Text))
                    {
                        comm.Parameters.AddWithValue("@software", softwaretxt.Text);
                    }
                    else
                    {
                        comm.Parameters.AddWithValue("@software", DBNull.Value);
                    }
                    //Valida sisac
                    if (!String.IsNullOrEmpty(sisactxt.Text))
                    {
                        comm.Parameters.AddWithValue("@sisac", sisactxt.Text);
                    }
                    else
                    {
                        comm.Parameters.AddWithValue("@sisac", DBNull.Value);
                    }
                    comm.Parameters.AddWithValue("@estatus", estatus);
                    comm.Parameters.AddWithValue("@ticket", VerCompra.verpedido[10]);
                    
                    comm.ExecuteNonQuery();
                    comm.Parameters.Clear();
                    comm.Dispose();
                    comm = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al agregar comentario.\n\nMensaje: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }



            //ENVIO CORREO
            try
            {
                MailMessage mailMessage = new MailMessage();
                MailAddressCollection to = mailMessage.To;
                object[] obj = new object[1] { correo };
                object[] array = obj;
                bool[] obj2 = new bool[1] { true };
                bool[] array2 = obj2;
                NewLateBinding.LateCall(to, null, "Add", obj, null, null, obj2, IgnoreReturn: true);
                if (array2[0])
                {
                    correo = (string)RuntimeHelpers.GetObjectValue(array[0]);
                }
                mailMessage.Bcc.Add("notificaciones@unne.com.mx");
                mailMessage.From = new MailAddress("notificaciones@unne.com.mx");
                mailMessage.Subject = "SiTTi - Ticket " + VerCompra.verpedido[10] + ": " + ci;
                mailMessage.Body = "<span style=\"font-family:Verdana; font-size: 10pt;\">" + label4.Text.ToUpper() + " actualizó el ticket con el siguiente comentario...<br><br><b>" + richTextBox1.Text + "</b><br><br>En caso de ser necesario, favor de ingresar al SiTTi [http://148.223.153.43/SiTTi] para dar seguimiento y/o adjuntar información solicitada.</span><span style=\"font-family: Verdana; font-size: 9pt; color: #FF0000; \"><br><br> <b>Nota: Favor de <u>no</u> contestar a este correo</b></span>";
                mailMessage.IsBodyHtml = true;
                mailMessage.Priority = MailPriority.Normal;
                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Host = "189.254.9.189";
                smtpClient.Port = 587;
                smtpClient.EnableSsl = false;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential("notificaciones", "t78Q7JBkmucE");

                smtpClient.Send(mailMessage);
                MessageBox.Show("Comentario insertado.", "Compras", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error al enviar correo.\n\nError: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            button1.Enabled = true;
            richTextBox1.Enabled = true;
        }

        private void richTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Shift && e.KeyCode == Keys.E)
            {
                richTextBox1.Text = "FAVOR DE INDICAR ESTATUS.";
            }
        }
    
        public void enviar_comentario_mail()
        {
            
        }
    }
}

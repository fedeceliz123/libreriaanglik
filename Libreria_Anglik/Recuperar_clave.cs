using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Libreria_Anglik
{
    public partial class Recuperar_clave : Form
    {
        public Recuperar_clave()
        {
            InitializeComponent();
        }

        // hacer que se mueva ventana desde la tabla de barra

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParanm);

        private void panel14_MouseDown_1(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel14_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        //

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRecuperar_Click(object sender, EventArgs e)
        {
            ConsultasSQL RecClav = new ConsultasSQL();

            RecClav.RecuperarClave(textBoxMail.Text);

            //enviar mail


            System.Net.Mail.MailMessage mgs = new System.Net.Mail.MailMessage();

            mgs.To.Add(textBoxMail.Text);
            mgs.Subject = "Recuperacion de usuario y clave Anglik";
            mgs.SubjectEncoding = System.Text.Encoding.UTF8;
            mgs.Body = RecClav.RecuperarClave(textBoxMail.Text);
            mgs.BodyEncoding = System.Text.Encoding.UTF8;
            mgs.IsBodyHtml = true;

            mgs.From = new System.Net.Mail.MailAddress("fede_celiz92@hotmail.com");

            System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();

            cliente.Credentials = new System.Net.NetworkCredential("fede_celiz92@hotmail.com", "Fede1234");

            // puerto y host para hotmail 

            cliente.Port = 587;
            cliente.EnableSsl = true;

            cliente.Host = "smtp.office365.com";

            try
            {
                MensajeOk oMensaje = new MensajeOk();
                if (RecClav.RecuperarClave(textBoxMail.Text) != null)
                {
                    cliente.Send(mgs);
                   
                    oMensaje.Show();
                    oMensaje.lblMensaje.Text = "Se le envio un mail con su Usuario y Contraseña ";
                    textBoxMail.Clear();
                    textBoxMail.Enabled = false;
                    btnRecuperar.Enabled = false;

                }
                else
                {
                    oMensaje.Show();
                    oMensaje.lblMensaje.Text = "El mail no pudo ser entregado: Email no registrado ";
                    textBoxMail.Clear();
                }
            }
            catch
            {
                MensajeOk oMensaje = new MensajeOk();
                oMensaje.Show();
                oMensaje.lblMensaje.Text = "El mail no pudo ser entregado ";
            }

            //
        }
       



    
        }
    }


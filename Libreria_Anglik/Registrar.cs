using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//validar mail
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;

namespace Libreria_Anglik
{
    public partial class Registrar : Form
    {
        public Registrar()
        {
            InitializeComponent();
        }
        // hacer que se mueva ventana desde la tabla de barra

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParanm);



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


        private void CargarComboPais()
        {


            DataTable dt = new DataTable();
            ConsultasSQL cP = new ConsultasSQL();
            dt = cP.CargarComboPais();
            cbPais.DataSource = dt;
            cbPais.DisplayMember = "nombrepais";
            cbPais.ValueMember = "id";


        }

        private void CargarComboProvincia()
        {


            DataTable dt = new DataTable();
            ConsultasSQL cP = new ConsultasSQL();
            if (cbPais.SelectedIndex != 0)
            {
                dt = cP.CargarComboProvincia(int.Parse(cbPais.SelectedValue.ToString()));
                cbProvincia.DataSource = dt;
                cbProvincia.DisplayMember = "estadonombre";
                cbProvincia.ValueMember = "id";
            }



        }

        private void Registrar_Load(object sender, EventArgs e)
        {
            CargarComboPais();

            cbPais.SelectedIndex = 0;

            Limpiar();

            cbProvincia.Enabled = false;


           
        }

        private void textBoxDNI_KeyUp(object sender, KeyEventArgs e)
        {

            if (textBoxDNI.Text.Length >= 5)
            {
                panelGeneral.Enabled = true;
                panelCliente.Enabled = true;
                panelCliente.Visible = true;

            }
            else
            {
                panelGeneral.Enabled = false;
                panelCliente.Enabled = false;
                panelCliente.Visible = false;
            }



            ConsultasSQL Consulta = new ConsultasSQL();

            if (Consulta.EsEmpledo(textBoxDNI.Text) == true)
            {
                comboBoxPuesto.SelectedIndex = 1;
                panelCliente.Enabled = false;
                panelCliente.Visible = false;
            }
            else if (Consulta.EsProveedor(textBoxDNI.Text) == true)
            {
                comboBoxPuesto.SelectedIndex = 2;
                panelCliente.Enabled = false;
                panelCliente.Visible = false;
            }
            else
            {
                comboBoxPuesto.SelectedIndex = 0;
                panelCliente.Enabled = true;

            }
        }

        private void cbPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarComboProvincia();
            cbProvincia.Enabled = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBoxClave.UseSystemPasswordChar = false;
                textBoxRepClave.UseSystemPasswordChar = false;
            }
            else
            {
                textBoxClave.UseSystemPasswordChar = true;
                textBoxRepClave.UseSystemPasswordChar = true;
            }
        }

        private void Limpiar()
        {
            textBoxApellido.Clear();
            textBoxNombre.Clear();
            textBoxDNI.Clear();
            textBoxDir.Clear();
            textBoxClave.Clear();
            textBoxMail.Clear();
            textBoxRepClave.Clear();
            textBoxTel.Clear();
            textBoxUser.Clear();
            comboBoxPuesto.SelectedIndex = 0;
            comboBoxSexo.SelectedIndex = 0;
            textBoxNumero.Clear();
            textBoxOcupacion.Clear();
            textBoxDNI.Focus();
            cbProvincia.Text = "Seleccione";
            cbPais.SelectedIndex = 0;
            textBoxLocalidad.Clear();
            textBoxCP.Clear();
            tbBarrio.Clear();
            tbCodArea.Clear();
            tbDpto.Clear();
            tbPiso.Clear();
            dtpFechaNac.Value = DateTime.Now;
            cbProvincia.Enabled = false;


        }

        private void textBoxDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloNumeros(e);
        }

        private void textBoxCP_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloNumeros(e);
        }

        private void textBoxNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloNumeros(e);
        }

        private void tbCodArea_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloNumeros(e);
        }

        private void textBoxTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloNumeros(e);
        }


        //validar mail
        private Boolean email_bien_escrito(String email)
        {
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private void ErroresUsuario()
        {

            if (panelCliente.Visible == true)
            {
                if (textBoxNombre.Text == "")
                {
                    errorProviderNombre.SetError(textBoxNombre, "Ingrese nombre");
                }
                else
                {
                    errorProviderNombre.Clear();
                }
                if (textBoxApellido.Text == "")
                {
                    errorProviderApellido.SetError(textBoxApellido, "Ingrese apellido");
                }
                else
                {
                    errorProviderApellido.Clear();
                }
            }

            if (textBoxDNI.Text == "")
            {
                errorProviderDni.SetError(textBoxDNI, "Ingrese N° de DNI");
            }
            else
            {
                errorProviderDni.Clear();
            }


            if (textBoxUser.Text == "")
            {
                errorProviderUsuario.SetError(textBoxUser, "Ingrese un nombre de usuario");
            }
            else
            {
                errorProviderUsuario.Clear();
            }
            if (textBoxMail.Text == "" || email_bien_escrito(textBoxMail.Text) == false)
            {
                if (textBoxMail.Text == "")
                {
                    errorProviderMail.SetError(textBoxMail, "Ingrese un mail");
                }
                if (email_bien_escrito(textBoxMail.Text) == false)
                {
                    errorProviderMail.SetError(textBoxMail, "Mail Incorrecto");
                }

            }
            else
            {
                errorProviderMail.Clear();
            }
            if (textBoxClave.Text == "")
            {

                errorProviderClave.SetError(textBoxClave, "Ingrese una clave");


            }
            else
            {
                errorProviderClave.Clear();
            }
            if (textBoxRepClave.Text != textBoxClave.Text)
            {
                errorProviderRepClave.SetError(textBoxRepClave, "Ingrese la misma clave del campo clave");
            }
            else
            {
                errorProviderRepClave.Clear();
            }




        }


        


    private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (textBoxDNI.Text == "" || textBoxUser.Text == "" || textBoxMail.Text == "" || textBoxClave.Text == "" || textBoxRepClave.Text == "" || email_bien_escrito(textBoxMail.Text) == false || textBoxClave.Text != textBoxRepClave.Text && panelCliente.Visible == false)
            {
                MensajeOk mjs = new MensajeOk();

                mjs.lblMensaje.Text = "Complete todos los campos obligatorios de usuario ";
                mjs.Show();


            }
            else if (panelCliente.Visible == true && (textBoxNombre.Text == "" || textBoxApellido.Text == "" ||  comboBoxSexo.SelectedIndex == 0|| Calcularedad()<16||cbPais.SelectedIndex==0||textBoxLocalidad.Text==""||textBoxDir.Text==""||textBoxNumero.Text==""||tbCodArea.Text==""||textBoxTel.Text==""))
            {
                MensajeOk mjs = new MensajeOk();

                mjs.lblMensaje.Text = "Complete todos los campos obligatorios de cliente. Tambien debe ser mayor de 16 años";
                mjs.Show();
            }

            else
            {

                Mensaje_Si_No mensaje = new Mensaje_Si_No();
                mensaje.lblMensaje.Text = "Seguro que desea registrase";

                if (mensaje.ShowDialog() == DialogResult.Yes)
                {

                    try
                    {

                       
                        Clases_Direcciones.ConsultasDirecciones conDir = new Clases_Direcciones.ConsultasDirecciones();
                        Clases_Direcciones.DireccionesR Dir = new Clases_Direcciones.DireccionesR();

                        Clases_Emails.ConsultasEmail conMail = new Clases_Emails.ConsultasEmail();
                        Clases_Emails.EmailR mail = new Clases_Emails.EmailR();

                        Clases_Telefonos.ConsutaTelefonos conTel = new Clases_Telefonos.ConsutaTelefonos();
                        Clases_Telefonos.TelefonosR Tel = new Clases_Telefonos.TelefonosR();

                        Clases_Clientes.ConsultasClientes conCliente = new Clases_Clientes.ConsultasClientes();
                        Clases_Clientes.ClientesR Cliente = new Clases_Clientes.ClientesR();


                        if (panelCliente.Visible == true)
                        {
                            Cliente.Dni = textBoxDNI.Text;
                            Cliente.Nombre = textBoxNombre.Text;
                            Cliente.Apellido = textBoxApellido.Text;

                            DateTime fechaNac = dtpFechaNac.Value;
                            DateTime hoy= DateTime.Now;

                            Cliente.Fecha_Nacimiento = fechaNac;
                            Cliente.Sexo = comboBoxSexo.Text;
                            Cliente.Ocupacion = textBoxOcupacion.Text;
                            Cliente.Fecha_de_ingreso = hoy.ToString("yyyy-MM-dd");
                            Cliente.IVA = "";


                            conCliente.CargaCliene(Cliente);

                            Dir.DNI_CUIT = textBoxDNI.Text;
                            Dir.Pais = cbPais.Text;
                            Dir.Provincia = cbProvincia.Text;
                            Dir.Localidad = textBoxLocalidad.Text;
                            Dir.CP = textBoxCP.Text;
                            Dir.Barrio = tbBarrio.Text;
                            Dir.Calle = textBoxDir.Text;
                            Dir.Altura = textBoxNumero.Text;
                            Dir.Piso = tbPiso.Text;
                            Dir.Dpto = tbDpto.Text;

                            if (textBoxDir.Text != "")
                            {
                                conDir.CargarDireccion(Dir);
                            }

                            mail.DNI_CUIT = textBoxDNI.Text;
                            mail.Email = textBoxMail.Text;

                            conMail.CargarEmail(mail);

                            Tel.DNI_CUIT = textBoxDNI.Text;
                            Tel.Codigo_de_area = tbCodArea.Text;
                            Tel.Telefono = textBoxTel.Text;
                            if (tbCodArea.Text != "" && textBoxTel.Text != "")
                            {
                                conTel.CargarTelefono(Tel);
                            }


                        }

                        ConsultasSQL con = new ConsultasSQL();

                        con.CargarUsuarioNuevo(textBoxDNI.Text, comboBoxPuesto.SelectedItem.ToString(), textBoxUser.Text, textBoxMail.Text, textBoxClave.Text);



                        //enviar mail


                        System.Net.Mail.MailMessage mgs = new System.Net.Mail.MailMessage();

                        mgs.To.Add(textBoxMail.Text);
                        mgs.Subject = "Se registro en Anglik";
                        mgs.SubjectEncoding = System.Text.Encoding.UTF8;
                        mgs.Body = "Ustes se registro con el usuario " + textBoxUser.Text + " y su clave es " + textBoxClave.Text;
                        mgs.BodyEncoding = System.Text.Encoding.UTF8;
                        mgs.IsBodyHtml = true;

                        mgs.From = new System.Net.Mail.MailAddress("fede_celiz92@hotmail.com");

                        System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();

                        cliente.Credentials = new System.Net.NetworkCredential("fede_celiz92@hotmail.com", "Fede1234");

                        // puerto y host para hotmail 

                        cliente.Port = 587;
                        cliente.EnableSsl = true;

                        cliente.Host = "smtp.office365.com";

                        //


                        //puerto gmail


                        //cliente.Port = 587;
                        //cliente.EnableSsl = true;
                        //cliente.Host = "smtp.gmail.com";

                        try
                        {
                            cliente.Send(mgs);
                            MensajeOk oMensaje = new MensajeOk();
                            oMensaje.Show();
                            oMensaje.lblMensaje.Text = "Registrado se envio su Usuario y clave a su mail ";
                        }
                        catch
                        {
                            MensajeOk oMensaje = new MensajeOk();
                            oMensaje.Show();
                            oMensaje.lblMensaje.Text = "El mail no pudo ser entregado ";
                        }

                        //

                        Limpiar();





                    }
                    catch (Exception ex)
                    {
                        MensajeOk a = new MensajeOk();
                        a.lblMensaje.Text = ex.Message;
                        a.Show();

                    }


                    this.Close();


                }

            }


        }


        private double Calcularedad()
        {
            TimeSpan Edad = DateTime.Now - dtpFechaNac.Value;
            double años = Edad.Days / 365.25;

            return años;

        }

        private DateTime mayor()
        {
            DateTime fecha = DateTime.Now;

            DateTime fecha2= fecha.AddDays(-(16*365.25));

            return fecha2;


        }


        private void ErroresClientes()
        {
            if (textBoxApellido.Text == ""||textBoxNombre.Text==""||comboBoxSexo.SelectedIndex==0||Calcularedad()<16||cbPais.SelectedIndex==0||cbProvincia.SelectedIndex==0||textBoxLocalidad.Text==""||textBoxCP.Text==""||tbBarrio.Text==""||textBoxDir.Text==""||textBoxNumero.Text==""||textBoxTel.Text==""||tbCodArea.Text=="")
            {
                MensajeOk a = new MensajeOk();
                a.Show();
                a.lblMensaje.Text = "Por favor complete todos los datos.   (su edad debe ser mayor a 16 años)";
            }

        }

       
    }
}

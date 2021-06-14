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

namespace Libreria_Anglik.Login1
{
    public partial class Login1 : Form
    {
        public Login1()
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked==true)
            {
                tbClave.UseSystemPasswordChar = false;

            }
            else
            {
                tbClave.UseSystemPasswordChar = true;
            }
        }

        private void llblRegistrar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Registrar oRegistrar = new Registrar();
            oRegistrar.Show();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            if (tbUser.Text == "" || tbClave.Text == "")
            {
                MensajeOk mjs = new MensajeOk();
                mjs.lblMensaje.Text = "Ingrese su usuario y contraseña";
                mjs.Show();
            }
            else
            {
                ConsultasSQL Registrado = new ConsultasSQL();

                if (Registrado.IniciarSecion(tbUser.Text, tbClave.Text) == true)
                {
                    if (Registrado.Tipo(tbUser.Text, tbClave.Text) == "Empleado")
                    {

                        ConsultasSQL con = new ConsultasSQL();
                        Menu menu = new Menu();
                        string a = con.Permisos(tbUser.Text);

                        string nom = con.Nombre(tbUser.Text);

                       

                        menu.Permiso = a;
                        menu.lblNombre.Text = "Bienvenido " + nom;
                       
                        menu.Show();

                    }
                    else if (Registrado.Tipo(tbUser.Text, tbClave.Text) == "Proveedor")
                    {
                        

                        Menu_Proveedores Prov = new Menu_Proveedores();
                       Prov.lblprov.Text= Registrado.Proveedor_N(tbUser.Text, tbClave.Text);
                        Prov.Show();
                    }
                    else if (Registrado.Tipo(tbUser.Text, tbClave.Text) == "Cliente")
                    {
                        Menu_Clientes Cliente = new Menu_Clientes();
                        Cliente.Show();

                    }


                   // tbClave.Enabled = false;
                    //tbUser.Enabled = false;
                    //btnIniciar.Enabled = false;
                    //llblRecuperar.Enabled = false;
                    //llblRegistrar.Enabled = false;
                    tbClave.Clear();
                    tbUser.Clear();

                    //this.WindowState = FormWindowState.Minimized;

                    

                    
                }
                else
                {
                    MensajeOk a = new MensajeOk();
                    a.Show();
                    a.lblMensaje.Text = "Usuario o clave Incorrecta";

                }


            }

        }

        private void Error()
        {
            if(tbUser.Text=="" )
            {
                epUser.SetError(tbUser,"Ingrese Usuario");
            }
            else
            {
                epUser.Clear();
            }
            if(tbClave.Text=="")
            {
                epClave.SetError(tbClave, "Ingrese una clave");
            }
            else
            {
                epClave.Clear();
            }


        }

        private void llblRecuperar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Rep_clave a = new Rep_clave();
            a.Show();
        }

       
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Libreria_Anglik
{
    public partial class Menu : Form
    {

        public string Permiso { get; set; }
        public Menu()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();

           
            

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        // hacer contenedor el panel

        private void AbrirFormhijo(object formhijo)
        {
            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);

            Form fh = formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(fh);
            this.panelContenedor.Tag = fh;

            fh.Show();

        }



        private void Quitar_btn_desplegables()
        {
          
            btnProveedores.Visible = false;
            btnCarCompra.Visible = false;
            btnRepVenta.Visible = false;
            btnRepProd.Visible = false;
            btnRepEmp.Visible = false;
            btnRepComp.Visible = false;
            btnDatosPersonal.Visible = false;
            btnAsistencia.Visible = false;

           

        }




        private void Menu_Load(object sender, EventArgs e)
        {
            Clases_Mensajes.Consulta_mensajes conmen = new Clases_Mensajes.Consulta_mensajes();

            if (Permiso!= "Gerente")
            {
                btnCompras.Enabled = false;
                btnReportes.Enabled = false;
                btnDatosPersonal.Enabled = false;
                btnPagos.Enabled = false;
            }



            if(conmen.HayMensajesNoLeidos()==true)
            {
                pbNoleido.Visible = true;
            }
            else
            {
                pbNoleido.Visible = false;
            }


            AbrirFormhijo(new Inicio());
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            AbrirFormhijo(new Ventas());
        }

        private void btnCargaPoducto_Click(object sender, EventArgs e)
        {
            AbrirFormhijo(new Carga_Productos());
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AbrirFormhijo(new Inicio());
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            AbrirFormhijo(new Inventario());
        }

        private void btnInventario_MouseHover(object sender, EventArgs e)
        {
        
            Quitar_btn_desplegables();
           

        }

        private void btnVentas_MouseHover(object sender, EventArgs e)
        {
            Quitar_btn_desplegables();
        }

        private void btnCompras_MouseHover(object sender, EventArgs e)
        {
            Quitar_btn_desplegables();
            btnProveedores.Visible = true;
            btnCarCompra.Visible = true;
           


        }

        private void btnReportes_MouseHover(object sender, EventArgs e)
        {
            Quitar_btn_desplegables();
            btnRepVenta.Visible = true;
            btnRepProd.Visible = true;
            btnRepEmp.Visible = true;
            btnRepComp.Visible = true;
            
        }

        private void btnCargaPoducto_MouseHover(object sender, EventArgs e)
        {
            Quitar_btn_desplegables();
        }

        
    
        private void panelMenu_MouseHover(object sender, EventArgs e)
        {
            Quitar_btn_desplegables();
        }

        private void btnPersonal_MouseHover(object sender, EventArgs e)
        {
            Quitar_btn_desplegables();

            
                btnAsistencia.Visible = true;
                btnDatosPersonal.Visible = true;
           

            
        }

        private void btnAsistencia_Click(object sender, EventArgs e)
        {
            AbrirFormhijo(new Asistencia_Personal());
            Quitar_btn_desplegables();
        }

        private void btnCarCompra_Click(object sender, EventArgs e)
        {

            Quitar_btn_desplegables();
            //compra permiso

                AbrirFormhijo(new Compra());
                
            
            
            
           
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {

            Quitar_btn_desplegables();
            
               //proveedores permiso
           
                AbrirFormhijo(new Proveedores());
                
            
          
           
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            Quitar_btn_desplegables();
        }

        private void btnDatosPersonal_Click(object sender, EventArgs e)
        {
            Quitar_btn_desplegables();

           
                AbrirFormhijo(new Empledos());

            
          
           

         
        }

        private void btnRepProd_Click(object sender, EventArgs e)
        {
            Quitar_btn_desplegables();
            
                AbrirFormhijo(new Reportes_Productos());

            
          
            


          
        }

        private void btnRepVenta_Click(object sender, EventArgs e)
        {
            Quitar_btn_desplegables();

            
                AbrirFormhijo(new Reportes_Ventas());

            
          
            
        }

        private void btnRepEmp_Click(object sender, EventArgs e)
        {
            Quitar_btn_desplegables();
           
                AbrirFormhijo(new Reportes_Empleados());

            
           
           

            
        }

        private void btnPagos_Click(object sender, EventArgs e)
        {
            Quitar_btn_desplegables();
           
                AbrirFormhijo(new Pagos());

            
          
          
            
        }

        private void btnPagos_MouseHover(object sender, EventArgs e)
        {
            Quitar_btn_desplegables();
        }

        private void btnRepComp_Click(object sender, EventArgs e)
        {
            Quitar_btn_desplegables();
            
                AbrirFormhijo(new Reportes_Compras());

            
           
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Mensajes a = new Mensajes();
            if (a.ShowDialog() == DialogResult.OK)
            {
                Clases_Mensajes.Consulta_mensajes conmen = new Clases_Mensajes.Consulta_mensajes();

                if (conmen.HayMensajesNoLeidos() == true)
                {
                    pbNoleido.Visible = true;
                }
                else
                {
                    pbNoleido.Visible = false;
                }
            }
       }

        private void timerActualizacion_Tick(object sender, EventArgs e)
        {

            Clases_Mensajes.Consulta_mensajes conmen = new Clases_Mensajes.Consulta_mensajes();

            if (conmen.HayMensajesNoLeidos() == true)
            {
                pbNoleido.Visible = true;
            }
            else
            {
                pbNoleido.Visible = false;
            }

        }

        private void Menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            timerActualizacion.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Quitar_btn_desplegables();



            AbrirFormhijo(new Cargar_Cliente());
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

            Mensaje_Si_No mensaje = new Mensaje_Si_No();
            mensaje.lblMensaje.Text = "Seguro que desea cerrar su sesion";

            if (mensaje.ShowDialog() == DialogResult.Yes)
            {
               
               

                this.Close();
            }
        }

        private void panelMenu_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

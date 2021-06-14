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
    public partial class Proveedor_Mensaje : Form
    {
        public Proveedor_Mensaje()
        {
            InitializeComponent();
        }

        private void tbMensaje_KeyUp(object sender, KeyEventArgs e)
        {
            lblCaracteres.Text = "Caracteres disponibles " + (1500-tbMensaje.Text.Length).ToString();


        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (tbProveedor.Text == "" || tbMensaje.Text == "" || tbAsunto.Text == "")
            {
                MensajeOk a = new MensajeOk();
                a.Show();
                a.lblMensaje.Text = "Coplete todos los campos";
            }
            else
            {
                Mensaje_Si_No mensaje = new Mensaje_Si_No();
                mensaje.lblMensaje.Text = "Seguro que desea enviar el mensaje";

                if (mensaje.ShowDialog() == DialogResult.Yes)
                {
                    Clases_Mensajes.MensajesR men = new Clases_Mensajes.MensajesR();
                    Clases_Mensajes.Consulta_mensajes conMen = new Clases_Mensajes.Consulta_mensajes();

                    men.DNI_CUIT = tbProveedor.Text;
                    men.Asunto = tbAsunto.Text;
                    men.Mensaje = tbMensaje.Text;
                    men.Fecha = DateTime.Now;
                    men.Leido = "No";

                    conMen.EnviarMensaje(men);

                    tbAsunto.Clear();
                    tbMensaje.Clear();
                    tbProveedor.Clear();

                }
            }

        }

        private void tbProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloNumeros(e);
        }
    }
}

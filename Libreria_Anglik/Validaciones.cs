using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Libreria_Anglik
{
    class Validaciones
    {
        public Boolean TextBoxNull(string Text)
        {
            Boolean a;

            if (Text == "")
            {
                a = true;
            }
            else
            {
                a = false;
            }

            return a;

        }

        public static void  SoloNumeros(KeyPressEventArgs pr)
        {
            if (char.IsDigit(pr.KeyChar))
            {
                pr.Handled = false;
            }
            else if (char.IsControl(pr.KeyChar))
            {
                pr.Handled = false;
            }
            else
            {
                pr.Handled = true;

                MensajeOk oMensaje = new MensajeOk();
                   oMensaje.Show();
                  oMensaje.lblMensaje.Text = "Solo ingresar numeros ";
            }

        }


        }



    }


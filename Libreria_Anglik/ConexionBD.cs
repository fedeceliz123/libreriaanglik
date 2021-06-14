using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace Libreria_Anglik
{
    internal class ConexionBD
    {
        private SqlConnection Conexion = new SqlConnection();
        private string cadena = "Data Source=FEDE\\SQLEXPRESS;Initial Catalog=Libreria_Anglik; Integrated Security=True";

       //  base de datos en la nube:   Server=tcp:celiz.database.windows.net,1433;Initial Catalog = Anglik; Persist Security Info=False;User ID = adm; Password=Fede1234; MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout = 30;

    public SqlConnection Conetar()
        {

            try
            {

                Conexion = new SqlConnection(cadena);

                if (Conexion.State.Equals(ConnectionState.Open))
                {
                    Conexion.Close();
                }
                else
                {
                    Conexion.Open();
                }
                

            }
            catch (Exception ex)
            {
               

                MensajeOk mensaje = new MensajeOk();
                mensaje.lblMensaje.Text = ex.Message;
                mensaje.Show();

               


            }

            return Conexion;

        }
    }
}
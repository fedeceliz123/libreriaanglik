using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Libreria_Anglik.Clases_Mensajes
{
    class Consulta_mensajes:ConexionBD
    {

        public void EnviarMensaje(MensajesR men)
        {
            try
            {

                string cargar = "insert into Mensajes (DNI_CUIT,Asunto,Mensaje,Fecha,Leido)values(@dni,@asunto,@mensaje,@fecha,@leido)";

                SqlCommand comando = new SqlCommand(cargar, Conetar());

                comando.Parameters.AddWithValue("@dni", men.DNI_CUIT);

                comando.Parameters.AddWithValue("@asunto", men.Asunto);

                comando.Parameters.AddWithValue("@mensaje", men.Mensaje);

                comando.Parameters.AddWithValue("@fecha", men.Fecha);

                comando.Parameters.AddWithValue("@leido", men.Leido);

                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MensajeOk a = new MensajeOk();
                a.Show();
                a.lblMensaje.Text = ex.Message;


            }
        }


        public DataTable ListarLeidos()
        {
            string Consulta = "select ID, DNI_CUIT+', '+CONVERT(nvarchar(8),Fecha,101) as 'Mens' from Mensajes where Leido='Si' order by Fecha";
            SqlDataAdapter da = new SqlDataAdapter(Consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;


        }
        public DataTable ListarNoLeidos()
        {
            string Consulta = "select ID, DNI_CUIT+', '+CONVERT(nvarchar(8),Fecha,101) as 'Mens' from Mensajes where Leido='No' order by Fecha";
            SqlDataAdapter da = new SqlDataAdapter(Consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;


        }



        public DataRow CargarCampos(string id)
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            DataRow dr;

            string consulta = "select Asunto,Mensaje,Fecha from Mensajes where ID=" + id;

            SqlDataAdapter da = new SqlDataAdapter(consulta, Conetar());
            da.Fill(ds);
            dr = ds.Tables[0].Rows[0];

            return dr;


        }

        public void CargarLeido(string id)
        {
            try
            {

                string Modificar = " UPDATE Mensajes set Leido='Si' where ID="+id;

                SqlCommand comando = new SqlCommand(Modificar, Conetar());



                comando.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MensajeOk a = new MensajeOk();
                a.Show();
                a.lblMensaje.Text = ex.Message;


            }


        }

        public Boolean HayMensajesNoLeidos()
        {
            string Consulta = "select Leido from Mensajes where Leido='No' order by Fecha";
            Boolean hay;

            SqlCommand Comando = new SqlCommand(Consulta, Conetar());

            SqlDataReader lector = Comando.ExecuteReader();



            if (lector.Read() == true)
            {
                hay = true;
            }
            else
            {
                hay = false;
            }

            Conetar();

            return hay;




        }

    }
}

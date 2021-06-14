using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Libreria_Anglik.Clases_Emails
{
    class ConsultasEmail:ConexionBD
    {
        ///  listar
        public DataTable Listar()
        {
            string Consulta = "select * from Emails";
            SqlDataAdapter da = new SqlDataAdapter(Consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;

        }

        public DataTable ListarFiltro(string Numero)
        {
            string Consulta = "select * from Emails where DNI_CUIT='" + Numero + "'";
            SqlDataAdapter da = new SqlDataAdapter(Consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;

        }

        /// 

        public DataRow CargarCampos( string id)
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            DataRow dr;

            string consulta = "select * from Emails where Id='" + id + "'";

            SqlDataAdapter da = new SqlDataAdapter(consulta, Conetar());
            da.Fill(ds);
            dr = ds.Tables[0].Rows[0];

            return dr;


        }


        public void CargarEmail(EmailR mail)
        {
            try
            {

                string cargar = "insert into Emails (DNI_CUIT,Email) VALUES (@persona,@mail)";

                Conetar();

                SqlCommand comando = new SqlCommand(cargar, Conetar());

                comando.Parameters.AddWithValue("@persona", mail.DNI_CUIT);

                comando.Parameters.AddWithValue("@mail", mail.Email);

               
                comando.ExecuteNonQuery();
                Conetar();





            }
            catch (Exception ex)
            {
                MensajeOk a = new MensajeOk();
                a.Show();
                a.lblMensaje.Text = ex.Message;
            }

        }

        //
        //modificar mails

        public void ModificarMail(EmailR mail)
        {
            try
            {

                string Modificar = " UPDATE Emails set DNI_CUIT='" + mail.DNI_CUIT + "', Email='" + mail.Email + "' where Id=" + mail.Id;

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

        public void BorrarMail(string dnicuit)
        {
            try
            {
                string borrar = "delete from Emails where DNI_CUIT='" + dnicuit + "'";

                SqlCommand comando = new SqlCommand(borrar, Conetar());

                comando.ExecuteNonQuery();



            }
            catch (Exception ex)
            {
                MensajeOk a = new MensajeOk();
                a.Show();
                a.lblMensaje.Text = ex.Message;
            }



        }


        public void BorrarMailID(long ID)
        {
            try
            {
                string borrar = "delete from Emails where Id=" + ID ;

                SqlCommand comando = new SqlCommand(borrar, Conetar());

                comando.ExecuteNonQuery();



            }
            catch (Exception ex)
            {
                MensajeOk a = new MensajeOk();
                a.Show();
                a.lblMensaje.Text = ex.Message;
            }



        }

    }
}

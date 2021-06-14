using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Libreria_Anglik.Clases_Telefonos
{
    class ConsutaTelefonos : ConexionBD
    {
        ///  listar
        public DataTable Listar()
        {
            string Consulta = "select * from Telefonos";
            SqlDataAdapter da = new SqlDataAdapter(Consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;

        }

        public DataTable ListarFiltro(string Numero)
        {
            string Consulta = "select Id,DNI_CUIT,Codigo_de_area as 'Codigo',Telefono from Telefonos where DNI_CUIT='" + Numero + "'";
            SqlDataAdapter da = new SqlDataAdapter(Consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;

        }

        /// 


        public DataRow CargarCampos(string id)
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            DataRow dr;

            string consulta = "select * from Telefonos where Id='" + id + "'";

            SqlDataAdapter da = new SqlDataAdapter(consulta, Conetar());
            da.Fill(ds);
            dr = ds.Tables[0].Rows[0];

            return dr;


        }



        public void CargarTelefono(TelefonosR Tel)
        {
            try
            {

                string cargar = "insert into Telefonos (DNI_CUIT,Codigo_de_area,Telefono) VALUES (@persona,@codigo,@telefono)";

                Conetar();

                SqlCommand comando = new SqlCommand(cargar, Conetar());

                comando.Parameters.AddWithValue("@persona", Tel.DNI_CUIT);

                comando.Parameters.AddWithValue("@codigo", Tel.Codigo_de_area);

                comando.Parameters.AddWithValue("@telefono", Tel.Telefono);



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

        // modificar telefono

        ///
        ///
        public void ModificarTelefono(TelefonosR tel)
        {
            try
            {

                string Modificar = " UPDATE Telefonos set  DNI_CUIT='" + tel.DNI_CUIT + "', Codigo_de_area='" + tel.Codigo_de_area + "', Telefono='" + tel.Telefono + "' where Id=" + tel.Id;

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


        public void BorrarTelefono(string dnicuit)
        {
            try
            {
                string borrar = "delete from Telefonos where DNI_CUIT='" + dnicuit + "'";

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

        public void BorrarTelefonoID(long ID)
        {
            try
            {
                string borrar = "delete from Telefonos where Id=" + ID;

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

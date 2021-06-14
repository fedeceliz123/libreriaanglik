using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Libreria_Anglik.Clases_Direcciones
{
    class ConsultasDirecciones : ConexionBD
    {
        ///  listar
        public DataTable Listar()
        {
            string Consulta = "select * from Direcciones";
            SqlDataAdapter da = new SqlDataAdapter(Consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;

        }

        public DataTable ListarFiltro(string Numero)
        {
            string Consulta = "select * from Direcciones where DNI_CUIT='" +Numero+"'";
            SqlDataAdapter da = new SqlDataAdapter(Consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;

        }


        //
        public DataRow CargarCampos(string id)
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            DataRow dr;

            string consulta = "select * from Direcciones where ID='" + id + "'";

            SqlDataAdapter da = new SqlDataAdapter(consulta, Conetar());
            da.Fill(ds);
            dr = ds.Tables[0].Rows[0];

            return dr;


        }






        /// cargar direccion


        public void CargarDireccion(DireccionesR Dir)
        {
            try
            {

                string cargar = "insert into Direcciones VALUES (@persona,@pais,@provincia,@localidad,@cp,@barrio,@calle,@altura,@piso,@dpto)";

                Conetar();

                SqlCommand comando = new SqlCommand(cargar, Conetar());

                comando.Parameters.AddWithValue("@persona", Dir.DNI_CUIT);

                comando.Parameters.AddWithValue("@pais", Dir.Pais);

                comando.Parameters.AddWithValue("@provincia", Dir.Provincia);

                comando.Parameters.AddWithValue("@localidad", Dir.Localidad);

                comando.Parameters.AddWithValue("@cp", Dir.CP);

                comando.Parameters.AddWithValue("@barrio", Dir.Barrio);

                comando.Parameters.AddWithValue("@calle", Dir.Calle);

                comando.Parameters.AddWithValue("@altura", Dir.Altura);

                comando.Parameters.AddWithValue("@piso", Dir.Piso);

                comando.Parameters.AddWithValue("@dpto", Dir.Dpto);

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


        


        public void BorrarDireccion(string dnicuit)
        {
            try
            {
                string borrar = "delete from Direcciones where DNI_CUIT='" + dnicuit+"'";

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



        public void BorrarDireccionID(long ID)
        {
            try
            {
                string borrar = "delete from Direcciones where ID=" + ID;

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

        //
        //modificar

        public void ModificarDireccion(DireccionesR dir)
        {
            try
            {

                string Modificar = " UPDATE Direcciones set DNI_CUIT='" + dir.DNI_CUIT + "', Pais='" + dir.Pais + "', Provincia='" + dir.Provincia +"', Localidad='" +dir.Localidad +"', CP='"+dir.CP+"',Barrio='"+dir.Barrio+"', Calle='"+dir.Calle+"', Altura='"+dir.Altura+"', Piso='"+dir.Piso+"', Dpto='"+dir.Dpto+"' where ID='" + dir.ID + "'";

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

    }
}

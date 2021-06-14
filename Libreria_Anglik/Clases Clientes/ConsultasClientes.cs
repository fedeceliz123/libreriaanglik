using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Libreria_Anglik.Clases_Clientes
{
    class ConsultasClientes:ConexionBD
    {

        public DataTable CargarCombo()
        {try
            {
                string Consulta = "select Dni, Nombre +' ,'+ Apellido as cli from Clientes order by cli";
                SqlDataAdapter da = new SqlDataAdapter(Consulta, Conetar());
                DataSet ds = new DataSet();



                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                return null;

            }

          

           

        }

        public DataRow CargarCampos(string dni)
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            DataRow dr;

            string consulta = "select * from Clientes where Dni='" + dni + "'";

            SqlDataAdapter da = new SqlDataAdapter(consulta, Conetar());
            da.Fill(ds);
            dr = ds.Tables[0].Rows[0];

            return dr;


        }



        public void CargaCliene(ClientesR cli)
        {
            try
            {

                string cargar = "insert into Clientes (Dni,Nombre,Apellido,Fecha_Nacimiento,Sexo,Ocupacion,Fecha_de_ingreso,Activo,IVA) VALUES (@dni,@nombre,@apellido,@fechaN,@sexo,@ocupacion,@fecha,@Activo,@iva)";

                Conetar();

                SqlCommand comando = new SqlCommand(cargar, Conetar());

                comando.Parameters.AddWithValue("@dni", cli.Dni);

                comando.Parameters.AddWithValue("@nombre", cli.Nombre);

                comando.Parameters.AddWithValue("@apellido", cli.Apellido);

                comando.Parameters.AddWithValue("@fechaN", cli.Fecha_Nacimiento);

                comando.Parameters.AddWithValue("@sexo", cli.Sexo);

                comando.Parameters.AddWithValue("@ocupacion", cli.Ocupacion);

                comando.Parameters.AddWithValue("@fecha", cli.Fecha_de_ingreso);

                comando.Parameters.AddWithValue("@Activo","Si" );

                comando.Parameters.AddWithValue("@iva", cli.IVA);





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


        public DataTable ListarClientes(string act)
        {
            try
            {
                string Consulta = "select Dni,Nombre,Apellido,Fecha_Nacimiento as 'Fecha de nacimiento', Sexo, Ocupacion,Fecha_de_ingreso as 'Fecha de ingreso',IVA from Clientes where Activo='"+act+"'";
                SqlDataAdapter da = new SqlDataAdapter(Consulta, Conetar());
                DataSet ds = new DataSet();



                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                return null;

            }





        }

        public DataTable ListarClientesporDni(string act, string dni)
        {
            try
            {
                string Consulta = "select Dni,Nombre,Apellido,Fecha_Nacimiento as 'Fecha de nacimiento', Sexo, Ocupacion,Fecha_de_ingreso as 'Fecha de ingreso',IVA from Clientes where Activo='" + act + "' and Dni like '%"+dni+"%'";
                SqlDataAdapter da = new SqlDataAdapter(Consulta, Conetar());
                DataSet ds = new DataSet();



                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                return null;

            }


        }
        public DataTable ListarClientesporNombre(string act, string dni)
        {
            try
            {
                string Consulta = "select Dni,Nombre,Apellido,Fecha_Nacimiento as 'Fecha de nacimiento', Sexo, Ocupacion,Fecha_de_ingreso as 'Fecha de ingreso',IVA from Clientes where Activo='" + act + "' and Nombre like '%" + dni + "%'";
                SqlDataAdapter da = new SqlDataAdapter(Consulta, Conetar());
                DataSet ds = new DataSet();



                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                return null;

            }


        }

        public DataTable ListarClientesporApellido(string act, string dni)
        {
            try
            {
                string Consulta = "select Dni,Nombre,Apellido,Fecha_Nacimiento as 'Fecha de nacimiento', Sexo, Ocupacion,Fecha_de_ingreso as 'Fecha de ingreso',IVA from Clientes where Activo='" + act + "' and Apellido like '%" + dni + "%'";
                SqlDataAdapter da = new SqlDataAdapter(Consulta, Conetar());
                DataSet ds = new DataSet();



                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                return null;

            }


        }


        public void BorrarCliente (string egreso,string dni)
        {

          

            try
            {
                string Borrar = "update Clientes set Activo='No', Fecha_Egreso='" + egreso + "' where Dni='" + dni + "' ";

                SqlCommand comando = new SqlCommand(Borrar, Conetar());

                comando.ExecuteNonQuery();



            }
            catch (Exception ex)
            {
                MensajeOk a = new MensajeOk();
                a.Show();
                a.lblMensaje.Text = ex.Message;
            }


        }

        public void ModificarCliente(ClientesR Pro)
        {
            try
            {

                string Modificar = "set dateformat dmy UPDATE Clientes set Dni='" + Pro.Dni + "', Nombre='" + Pro.Nombre + "', Apellido='" + Pro.Apellido + "', Fecha_Nacimiento='" + Pro.Fecha_Nacimiento + "' ,Sexo='" + Pro.Sexo + "' , Ocupacion='"+Pro.Ocupacion+"', IVA='"+Pro.IVA+ "' where Dni='" + Pro.Dni + "'";

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

        public void BorrarCliente (string dni)
        {
            try
            {

                string Modificar = "set dateformat dmy UPDATE Clientes set Activo='No',Fecha_Egreso='"+DateTime.Now.ToString("yyyy-MM-dd")+"'where Dni='" + dni + "'";

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

        public void ReactivarCliente(string dni)
        {
            try
            {

                string Modificar = "set dateformat dmy UPDATE Clientes set Activo='Si' where Dni='" + dni + "'";

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

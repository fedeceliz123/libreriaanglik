using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Libreria_Anglik.Clases_Empleados
{
    class ConsultasEmpledos:ConexionBD
    {
        public DataTable CargarComboVendedores()
        {
            try
            {
                string Consulta = "select DNI, Nombre +' ,'+ Apellido as vendedor from Empleados where Puesto='Vendedor' order by vendedor";
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

        public DataTable CargarCombo()
        {
            string Consulta = "select DNI, Nombre +' ,'+ Apellido as Empl from Empleados where Activo='Si' order by Empl";
            SqlDataAdapter da = new SqlDataAdapter(Consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;
        }

        public DataRow CargarCampos(string dni)
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            DataRow dr;

            string consulta = "select * from Empleados where DNI='" + dni + "'";

            SqlDataAdapter da = new SqlDataAdapter(consulta, Conetar());
            da.Fill(ds);
            dr = ds.Tables[0].Rows[0];

            return dr;


        }

        public DataTable Listar(string activo)
        {
            string Consulta = "select DNI,Nombre,Apellido,Sexo,Fecha_Nacimeinto as 'Fecha de Nacimiento',Puesto,Fecha_Ingreso as 'Fecha de ingreso' from Empleados where Activo='" + activo+"'";
            SqlDataAdapter da = new SqlDataAdapter(Consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;

        }
        public DataTable ListarporDni(string activo,string dni)
        {
            string Consulta = "select DNI,Nombre,Apellido,Sexo,Fecha_Nacimeinto as 'Fecha de Nacimiento',Puesto,Fecha_Ingreso as 'Fecha de ingreso' from Empleados where Activo='" + activo + "' and DNI like '%"+dni+"%'";
            SqlDataAdapter da = new SqlDataAdapter(Consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;

        }
        public DataTable ListarporNombre(string activo, string dni)
        {
            string Consulta = "select DNI,Nombre,Apellido,Sexo,Fecha_Nacimeinto as 'Fecha de Nacimiento',Puesto,Fecha_Ingreso as 'Fecha de ingreso' from Empleados where Activo='" + activo + "' and Nombre like '%" + dni + "%'";
            SqlDataAdapter da = new SqlDataAdapter(Consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;

        }

        public DataTable ListarporApellido(string activo, string dni)
        {
            string Consulta = "select DNI,Nombre,Apellido,Sexo,Fecha_Nacimeinto as 'Fecha de Nacimiento',Puesto,Fecha_Ingreso as 'Fecha de ingreso' from Empleados where Activo='" + activo + "' and Apellido like '%" + dni + "%'";
            SqlDataAdapter da = new SqlDataAdapter(Consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;

        }


        public void CargarEmpleado(string dni, string nombre, string apellido, string sexo, DateTime fechan,   string puesto, DateTime Fecha_Ingreso)
        {
            try
            {

                string cargar = "insert into Empleados VALUES (@dni,@nombre,@apellido,@sexo,@fechaN,@puesto,@fecha,@activo,@fechae)";

                Conetar();

                SqlCommand comando = new SqlCommand(cargar, Conetar());

                comando.Parameters.AddWithValue("@dni", dni);

                comando.Parameters.AddWithValue("@nombre", nombre);

                comando.Parameters.AddWithValue("@apellido", apellido);

                comando.Parameters.AddWithValue("@sexo", sexo);

                comando.Parameters.AddWithValue("@fechaN", fechan);
                
                comando.Parameters.AddWithValue("@puesto", puesto);
                
                comando.Parameters.AddWithValue("@fecha", Fecha_Ingreso);

                comando.Parameters.AddWithValue("@activo", "Si");

                comando.Parameters.AddWithValue("@fechae", "");

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


        public void ModificarEmpledos(EmpleadosR Empl)
        {
            try
            {

                string Modificar = "set dateformat dmy UPDATE Empleados set DNI='" + Empl.DNI + "', Nombre='" +Empl.Nombre+ "', Apellido='" + Empl.Apellido + "', Sexo='" + Empl.Sexo + "', Fecha_Nacimeinto='" + Empl.Fecha_Nacimiento +"', Puesto='"+Empl.Puesto +   "', Fecha_Ingreso='" + Empl.Fecha_Ingreso + "' where DNI='" + Empl.DNI + "'";

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

        public void BorrarEmpledo(string dni,string egreso)
        {
            try
            {
                string borrar = "update Empleados set Activo='No',Fecha_Egreso='"+egreso +" ' where DNI='" + dni + "'";

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


        public DataTable ListarFiltro(string nombre )
        {
            string Consulta = "select Nombre+', '+Apellido as 'Empleado' from Empleados where 'Empleado' like '%"+nombre+"%'";
            SqlDataAdapter da = new SqlDataAdapter(Consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;

        }

        public string PermisoAceptado(string user, string clave)
        {


            string permiso ="";
            string Consulta = "select Puesto from Empleados where DNI=(select Dni from Login where Usuario='"+user+"' and Contraseña='"+clave+ "') and Puesto='Gerente'";
            SqlCommand comando = new SqlCommand(Consulta, Conetar());
            SqlDataReader leer = comando.ExecuteReader();

            if(leer.Read()==true)
            {
                permiso = leer["Puesto"].ToString();

            }

            return permiso;


        }


        public void RestableserEmpleado(string dni)
        {
            try
            {
                string borrar = "update Empleados set Activo='Si' where DNI='" + dni + "'";

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

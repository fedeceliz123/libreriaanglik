using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Libreria_Anglik.Clases_Asistencia
{
    class ConsultasAsistencia:ConexionBD
    {
        
        public void CargarIngreso(AsistenciasR asist)
        {
            string cargar = "insert into Asistencia(DNI_Empleado,Fecha,Hora_Ingreso) VALUES (@dni,@fecha,@horain)";

            Conetar();

            SqlCommand comando = new SqlCommand(cargar, Conetar());

            comando.Parameters.AddWithValue("@dni", asist.DNI_Empledo);

            comando.Parameters.AddWithValue("@fecha", asist.Fecha);

            comando.Parameters.AddWithValue("@horain", asist.Hora_Ingreso);

          

            comando.ExecuteNonQuery();
            Conetar();

        }

        public void Cargarsalida(AsistenciasR asist, string dni, DateTime fecha)
        {
            string cargar = "UPDATE Asistencia set Hora_salida=@horasal,Hora_total=@horatotal where DNI_Empleado='"+dni +"' and Fecha='"+fecha +"'" ;

            Conetar();

            SqlCommand comando = new SqlCommand(cargar, Conetar());


            comando.Parameters.AddWithValue("@horasal", asist.Hora_salida);

            comando.Parameters.AddWithValue("@horatotal", asist.Hora_total);

            comando.ExecuteNonQuery();
            Conetar();

        }

        public DateTime reHoraIng(string empledo,DateTime fecha)
        {
            string consulta = "select Hora_Ingreso from Asistencia where DNI_Empleado='"+empledo+"' and Fecha='"+ fecha+"'";
            DateTime horain=DateTime.Parse("01/01/1900");
            Conetar();
            SqlCommand comando = new SqlCommand(consulta, Conetar());
            SqlDataReader leer = comando.ExecuteReader();

            if(leer.Read()==true)
            {



                horain = DateTime.Parse(leer["Hora_Ingreso"].ToString());

               
            }

            Conetar();

            return horain;
        }

        public DataTable ListaFitrada(string empleado, string fecha)
        {
            string consulta= "select e.Nombre+', '+e.Apellido as 'Empleado',a.Fecha,a.Hora_Ingreso,a.Hora_salida,a.Hora_total from Asistencia a, Empleados e where e.DNI=a.DNI_Empleado and a.DNI_Empleado='"+empleado+"' and Fecha like '"+fecha+"%'";

            SqlDataAdapter da = new SqlDataAdapter(consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;

        }

        public string DiasTrabajados(string empleado, string fecha)
        {
            string consulta = "select COUNT(Fecha) as 'dias' from Asistencia where DNI_Empleado='"+empleado+"' and Fecha like '"+fecha+"%'";

            string Usuario = null;
            Conetar();
            SqlCommand Comando = new SqlCommand(consulta, Conetar());
            SqlDataReader lector = Comando.ExecuteReader();



            if (lector.Read() == true)
            {
                Usuario = lector["dias"].ToString();
            }

            Conetar();

            return Usuario;

        }

        public string HorasTrabajadas(string empleado, string fecha)
        {
            string consulta = "select SUM(Hora_total) as 'horas' from Asistencia where DNI_Empleado='" + empleado + "' and Fecha like '" + fecha + "%'";

            string Usuario = null;
            Conetar();
            SqlCommand Comando = new SqlCommand(consulta, Conetar());
            SqlDataReader lector = Comando.ExecuteReader();



            if (lector.Read() == true)
            {
                Usuario = lector["horas"].ToString();
            }

            Conetar();

            return Usuario;

        }


    }
}

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
    class ConsultasSQL : ConexionBD 
    {

        public Boolean IniciarSecion(string Usuario, string Clave)
        {


            string Consulta = "SELECT Usuario, Contraseña FROM Login WHERE Usuario='" + Usuario + "' AND Contraseña='" + Clave + "'";



            Conetar();
            SqlCommand Comando = new SqlCommand(Consulta, Conetar());
            SqlDataReader lector = Comando.ExecuteReader();

            Conetar();
            Boolean a = lector.Read();
           
            return a;
        }


        public string Permisos(string usuario) 
        {
            string Consulta = "select Puesto from Empleados where DNI=(select Dni from Login where Usuario='"+usuario+"')";

            string Usuario = null;

            Conetar();
            SqlCommand Comando = new SqlCommand(Consulta, Conetar());
            SqlDataReader lector = Comando.ExecuteReader();
            Conetar();
            if (lector.Read() == true)
            {
                Usuario = lector["Puesto"].ToString();
            }

            Conetar();

            return Usuario;

        }

        public string Nombre(string usuario)
        {
            string Consulta = "select Nombre,Apellido from Empleados where DNI=(select Dni from Login where Usuario='" + usuario + "')";

            string Usuario = null;

            Conetar();
            SqlCommand Comando = new SqlCommand(Consulta, Conetar());
            SqlDataReader lector = Comando.ExecuteReader();
            Conetar();
            if (lector.Read() == true)
            {
                Usuario = lector["Nombre"].ToString()+" "+ lector["Apellido"].ToString();
            }

            Conetar();

            return Usuario;

        }



        public string Tipo(string usuario,string clave)
        {
            string Consulta = "SELECT Tipo FROM Login WHERE Usuario='" + usuario + "' AND Contraseña='" + clave + "'";
            string Usuario= null;
            Conetar();
            SqlCommand Comando = new SqlCommand(Consulta, Conetar());
            SqlDataReader lector = Comando.ExecuteReader();

            

            if (lector.Read() == true)
            {
                Usuario = lector["Tipo"].ToString();
            }

            Conetar();

            return Usuario;

        }

        

        public SqlCommand CargarUsuarioNuevo( string dni,string puesto,string usuario,string mail, string clave)
        {
            string consulta = "insert into Login  values (@usuario ,@dni,@clave,@mail,@Tipo)";

            Conetar();
            SqlCommand Comando = new SqlCommand(consulta, Conetar());
            Comando.Parameters.AddWithValue("@usuario", usuario);
            Comando.Parameters.AddWithValue("@dni", dni);
            Comando.Parameters.AddWithValue("@Tipo", puesto);
            Comando.Parameters.AddWithValue("@mail", mail);
            Comando.Parameters.AddWithValue("@clave", clave);
            

            Comando.ExecuteNonQuery();
            Conetar();

            return Comando;

        }

        //public SqlCommand CargarClienteNuevo(string dni,string nombre,string apellido,DateTime fecha_nac,string sexo, string direccion, string numero, string telefono,string email,string ocupacion,string telefono2,DateTime fecha, string CP,string localidad, string provincia)
        //{
        //    string consulta = "insert into Clientes  values (@dni,@nombre,@apellido,@fecha_nac,@sexo,@direccion,@numero,@telefono,@mail,@ocupacion,@telefono2,@fecha,@cp,@localidad,@provincia)";

        //    Conetar();
        //    SqlCommand Comando = new SqlCommand(consulta, Conetar());
        //    Comando.Parameters.AddWithValue("@dni", dni);
        //    Comando.Parameters.AddWithValue("@nombre", nombre);
        //    Comando.Parameters.AddWithValue("@apellido", apellido);
        //    Comando.Parameters.AddWithValue("@fecha_nac", fecha_nac);
        //    Comando.Parameters.AddWithValue("@sexo", sexo);
        //    Comando.Parameters.AddWithValue("@direccion", direccion);
        //    Comando.Parameters.AddWithValue("@numero", numero);
        //    Comando.Parameters.AddWithValue("@telefono", telefono);
        //    Comando.Parameters.AddWithValue("@mail", email);
        //    Comando.Parameters.AddWithValue("@ocupacion", ocupacion);
        //    Comando.Parameters.AddWithValue("@telefono2", telefono2);
        //    Comando.Parameters.AddWithValue("@fecha",fecha );
        //    Comando.Parameters.AddWithValue("@cp",CP );
        //    Comando.Parameters.AddWithValue("@localidad",localidad );
        //    Comando.Parameters.AddWithValue("@Provincia", provincia );



        //    Comando.ExecuteNonQuery();
        //    Conetar();

        //    return Comando;

        //}


        public string RecuperarClave(string Email)
        {
            string consulta = "select Usuario, Contraseña from Login where Email='"+Email+"'";
            string Usuario, Contraseña,Mensaje_mail;


            Conetar();

            SqlCommand comando = new SqlCommand(consulta, Conetar());
            SqlDataReader leer = comando.ExecuteReader();

            

            if (leer.Read() == true)
            {
                Usuario = leer["Usuario"].ToString();
                Contraseña = leer["Contraseña"].ToString();

            }
            else
            {
                Usuario = null;
                Contraseña = null;

            }


            if (Usuario != null && Contraseña != null)
            {
                Mensaje_mail = "Su usuario:" + Usuario + " su contraseña:" + Contraseña;
            }
            else
            {
                Mensaje_mail = null;
            }
            Conetar();

            return Mensaje_mail;


        }

        public Boolean MailExiste(string mail)
        {
            string consulta = "select Usuario, Contraseña from Login where Email='" + mail + "'";

            Boolean a = false;

            SqlCommand comando = new SqlCommand(consulta, Conetar());
            SqlDataReader leer = comando.ExecuteReader();

            if (leer.Read() == true)
            {
                a = true;
            }

            return a;

         }


        public Boolean EsEmpledo(string Identificar)
        {
            string consulta = "select DNI from Empleados where DNI='" + Identificar + "'";
            Boolean resultado;

            Conetar();

            SqlCommand Comando = new SqlCommand(consulta, Conetar());
            SqlDataReader leer = Comando.ExecuteReader();

            Conetar();

            if (leer.Read() == true)
            {
                resultado = true;
            }
            else
            {
                resultado = false;
            }

            return resultado;

        }

        public Boolean EsProveedor(string Cuit)
        {
            string consulta = "select CUIT from Proveedores where CUIT='" + Cuit+"'";
            Boolean resultado;

            Conetar();

            SqlCommand Comando = new SqlCommand(consulta, Conetar());
            SqlDataReader leer = Comando.ExecuteReader();

            Conetar();

            if (leer.Read() == true)
            {
                resultado = true;
            }
            else
            {
                resultado = false;
            }

            return resultado;


        }


        public DataTable CargarComboPais()
        {
            string Consulta = "select id, nombrepais from Paises order by nombrepais";
            SqlDataAdapter da = new SqlDataAdapter(Consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;


        }

        public DataTable CargarComboProvincia(int cod_pais)
        {
            string Consulta = "select id, estadonombre from estados where ubicacionpais="+cod_pais;
            SqlDataAdapter da = new SqlDataAdapter(Consulta, Conetar());
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;


        }

        public string Proveedor_N(string user, string clave)
        {
            string consulta = "select CUIT from Proveedores where CUIT=(select dni from Login where Usuario='"+user+"' and Contraseña='"+clave+"')";
            SqlCommand Comando = new SqlCommand(consulta, Conetar());
            SqlDataReader leer = Comando.ExecuteReader();

            if (leer.Read() == true)
            {
                return leer["CUIT"].ToString();
            }
            else
            {
                return "";
            }

            


        }

    }
}

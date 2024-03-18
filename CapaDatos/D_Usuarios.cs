using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace CapaDatos
{
    public class D_Usuarios

    {
        //Instanciamos la base de datos

        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString) ;


        //metodo para listar
        public DataTable D_Listar()
        {


            SqlCommand cmd = new SqlCommand("sp_listar", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            return dt;
        }
        //metodo para insertar datos
        public void D_Insertar(E_Usuarios obje )
        {
            string nombre = obje.Nombre;
            string apellido = obje.Apellido;
            string direccion = obje.Direccion;
            var fecha = obje.Fecha;
            string celular = obje.Celular;
           
            string consulta = "insert into [dbo].[Agenda](nombre, apellido, direccion, fecha, celular) values ('"+nombre+"', '"+apellido+"', '"+direccion+"', '"+fecha+"', '"+celular+"')";
            conexion.Open();
            SqlCommand cmd = new SqlCommand(consulta, conexion);

            cmd.ExecuteNonQuery();
            conexion.Close();


        }
        //metodo para modificar datos
        public void D_Modificar(E_Usuarios obje)
        {
            int buscarID = obje.Id;
            string nombre = obje.Nombre;
            string apellido = obje.Apellido;
            string direccion = obje.Direccion;
            var fecha = obje.Fecha;
            string celular = obje.Celular;

            string cadena = "UPDATE [dbo].[Agenda] SET nombre = '" + nombre + "', apellido = '" + apellido + "', direccion =  '" + direccion + "', fecha = '" + fecha + "', celular = '" + celular + "'  where ID = '" + buscarID + "'";

            conexion.Open();
            SqlCommand cmd = new SqlCommand(cadena, conexion);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }
        //metodo para eliminar datos
        public void D_Eliminar(E_Usuarios obje)
        {
            int buscarID = obje.Id;

            string cadena = "delete from [dbo].[Agenda] where id = '" + buscarID + "'";

            conexion.Open();
            SqlCommand cmd = new SqlCommand(cadena, conexion);

            cmd.ExecuteNonQuery();
            conexion.Close();

        }


    }
}

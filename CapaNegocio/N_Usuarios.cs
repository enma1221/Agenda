using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;
using System.Data;

namespace CapaNegocio
{
    public class N_Usuarios
    {
        //instanciamos la clase de la capa Datos
        D_Usuarios usuariosDatos = new D_Usuarios();


        //retorna el metodo listar de la capa Datos
        public DataTable N_Listar()
        {
            return usuariosDatos.D_Listar();
        }

        /*establecemos un constructor con parametros luego llamamos al metodo de la Capa Datos
        */
        public void N_Insertar(string nombre, string apellido, string direccion, string fecha, string celular)
        {
            E_Usuarios N_Ins = new E_Usuarios
            {
                Nombre = nombre,
                Apellido = apellido,
                Direccion = direccion,
                Fecha = fecha,
                Celular = celular
            };
            usuariosDatos.D_Insertar(N_Ins);
        }
        /*establecemos un constructor con parametros luego llamamos al metodo de la Capa Datos
        */
        public void N_Modificar(int id, string nombre, string apellido, string direccion, string fecha, string celular)
        {
            E_Usuarios E_modi = new E_Usuarios
            {
                Id = id,
                Nombre = nombre,
                Apellido = apellido,
                Direccion = direccion,
                Fecha = fecha,
                Celular = celular
            };
            usuariosDatos.D_Modificar(E_modi);
        }
        /*establecemos un constructor con parametros luego llamamos al metodo de la Capa Datos
        */
        public void N_Eliminar(int id)
        {

            E_Usuarios E_eli = new E_Usuarios { Id = id };
            usuariosDatos.D_Eliminar(E_eli);
        }

    }
}


/*using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CapaDatos
{
    public class D_Usuarios
    {
        // Declarar la instancia única como estática y privada
        private static D_Usuarios _instance;

        // Agregar un objeto de bloqueo para garantizar la concurrencia segura
        private static readonly object LockObject = new object();

        // Instanciamos la base de datos
        private SqlConnection conexion;

        // Constructor privado para evitar instanciación directa
        private D_Usuarios()
        {
            // Inicializamos la conexión a la base de datos
            conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        }

        // Método estático para obtener la instancia única
        public static D_Usuarios GetInstance()
        {
            // Doble bloqueo para garantizar la concurrencia segura
            if (_instance == null)
            {
                lock (LockObject)
                {
                    if (_instance == null)
                    {
                        _instance = new D_Usuarios();
                    }
                }
            }

            return _instance;
        }

        // Resto de tus métodos
        // ...

        // Método para listar
        public DataTable D_Listar()
        {
            SqlCommand cmd = new SqlCommand("sp_listar", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            return dt;
        }

        // Método para insertar datos
        public void D_Insertar(E_Usuarios obje)
        {
            // Tu código aquí
        }

        // Método para modificar datos
        public void D_Modificar(E_Usuarios obje)
        {
            // Tu código aquí
        }

        // Método para eliminar datos
        public void D_Eliminar(E_Usuarios obje)
        {
            // Tu código aquí
        }
    }
}
*/

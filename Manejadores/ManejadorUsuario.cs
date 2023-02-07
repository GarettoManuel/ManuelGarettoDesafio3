using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManuelGarettoDesafio3.Manejadores
{
    internal static class ManejadorUsuario
    {
        public static string cadenaConexion = "Data Source=(localdb)\\localhost;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


        public static Models.Usuario devolverUsuario(long id)
        {


            Models.Usuario usuario = new Models.Usuario();
            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand("SELECT * FROM Usuario WHERE Id=@id", conn);
                SqlParameter idParam = new SqlParameter();
                idParam.Value = id;
                idParam.SqlDbType = SqlDbType.VarChar;
                idParam.ParameterName = "id";

                comando.Parameters.Add(idParam);

                /*SqlCommand comando = new SqlCommand("SELECT * FROM Usuario WHERE Id=1", conn);*/
                conn.Open();

                SqlDataReader reader = comando.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();

                    usuario.Id = reader.GetInt64(0);
                    usuario.Nombre = reader.GetString(1);
                    usuario.Apellido = reader.GetString(2);
                    usuario.NombreUsuario = reader.GetString(3);
                    usuario.Contraseña = reader.GetString(4);
                    usuario.Mail = reader.GetString(5);

                }

                Console.WriteLine("Id = " + usuario.Id);
                Console.WriteLine("Nombre = " + usuario.Nombre);
                Console.WriteLine("Apellido = " + usuario.Apellido);
                Console.WriteLine("Nombre Usuario = " + usuario.NombreUsuario);
                Console.WriteLine("Contraseña = " + usuario.Contraseña);
                Console.WriteLine("Mail = " + usuario.Mail);

            }
            return usuario;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManuelGarettoDesafio3.Manejadores
{
    internal static class ManejadorLogin
    {
        public static string cadenaConexion = "Data Source=(localdb)\\localhost;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public static Models.Usuario InicioSesion(string mail, string contraseña)
        {
            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand("SELECT * FROM Usuario WHERE Mail = @mail AND Contraseña = @contraseña", conn);


                SqlParameter Mail = new SqlParameter();
                Mail.ParameterName = "mail";
                Mail.SqlValue = SqlDbType.VarChar;
                Mail.Value = mail;

                SqlParameter Contraseña = new SqlParameter();
                Contraseña.ParameterName = "contraseña";
                Contraseña.SqlValue = SqlDbType.VarChar;
                Contraseña.Value = contraseña;

                comando.Parameters.Add(Mail);
                comando.Parameters.Add(Contraseña);
                conn.Open();
                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        Models.Usuario usuario = new Models.Usuario();
                        reader.Read();
                        usuario.Nombre = reader.GetString(1);
                        usuario.Apellido = reader.GetString(2);
                        usuario.NombreUsuario = reader.GetString(3);
                        usuario.Mail = reader.GetString(5);
                        Console.WriteLine("Usuario encontrado");
                        return usuario;

                    }
                    else
                    {
                        Console.WriteLine("Usuario no encontrado");
                        return null;
                    }
                }


            }
        }
    }
}

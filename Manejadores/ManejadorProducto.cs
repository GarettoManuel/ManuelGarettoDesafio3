using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManuelGarettoDesafio3.Manejadores
{
    
    internal static class ManejadorProducto
    {
        public static string cadenaConexion = "Data Source=(localdb)\\localhost;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static Models.Producto obtenerProducto(long idUsuario)
        {
            Models.Producto producto = new Models.Producto();
            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand("SELECT * FROM Producto WHERE IdUsuario = @idUsuario", conn);
                conn.Open();

                SqlParameter prodParam = new SqlParameter();
                prodParam.Value = idUsuario;
                prodParam.SqlDbType = SqlDbType.VarChar;
                prodParam.ParameterName = "IdUsuario";

                comando.Parameters.Add(prodParam);

                SqlDataReader reader = comando.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        Console.WriteLine("Id = " + Convert.ToInt64(reader["Id"]));
                        Console.WriteLine("Descripciones = " + reader["Descripciones"].ToString());
                        Console.WriteLine("Costo = " + reader.GetDecimal(2));
                        Console.WriteLine("Precio Venta = " + Convert.ToDecimal(reader["PrecioVenta"]));
                        Console.WriteLine("Stock = " + Convert.ToInt32(reader["Stock"]));
                        Console.WriteLine("Id Usuario = " + Convert.ToInt64(reader["IdUsuario"]));


                    }


                }
                return producto;
            }

        }
    }
}

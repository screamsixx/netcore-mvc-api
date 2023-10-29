using Data.Cliente;
using Data.Tienda;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Tienda
{
    public class TiendaEntity
    {
        private static class ConnectionHelper
        {
            private static string ConnectionString = "Data Source=127.0.0.1;Initial Catalog=bd_tienda;User ID=dev;Password=123456789;";
            public static SqlConnection GetConnection() { return new SqlConnection(ConnectionString); }
        }

        public static List<TiendaModel> GetTiendas()
        {
            List<TiendaModel> tiendas = new List<TiendaModel>();
            using (SqlConnection connection = ConnectionHelper.GetConnection())
            {
                string query = "GetTiendas";
                SqlCommand command = new SqlCommand(query, connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    TiendaModel tienda = new TiendaModel
                    {
                        TiendaID = Convert.ToInt32(reader["TiendaID"]),
                        Sucursal = reader["Sucursal"].ToString(),
                        Direccion = reader["Direccion"].ToString(),
                    };
                    tiendas.Add(tienda);
                }
                reader.Close();
            }
            return tiendas;
        }
        public static int InsertTienda(TiendaModel tienda)
        {
            using (SqlConnection connection = ConnectionHelper.GetConnection())
            {
                string query = "InsertTienda";
                SqlCommand command = new SqlCommand(query, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Sucursal", tienda.Sucursal);
                command.Parameters.AddWithValue("@Direccion", tienda.Direccion);
                connection.Open();
                command.ExecuteNonQuery();
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected;
            }
        }
        public static int UpdateTienda(TiendaModel tienda)
        {
            using (SqlConnection connection = ConnectionHelper.GetConnection())
            {
                string query = "UpdateTienda";
                SqlCommand command = new SqlCommand(query, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@TiendaID", tienda.TiendaID);
                command.Parameters.AddWithValue("@Sucursal", tienda.Sucursal);
                command.Parameters.AddWithValue("@Direccion", tienda.Direccion);
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected;
            }
        }

    }
}

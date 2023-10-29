using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Data.Cliente;

namespace Entity.Cliente
{
    public class ClienteEntity
    {
        private static class ConnectionHelper
        {
            private static string ConnectionString = "Data Source=127.0.0.1;Initial Catalog=bd_tienda;User ID=dev;Password=123456789;";
            public static SqlConnection GetConnection() { return new SqlConnection(ConnectionString); }
        }
        public static List<ClienteModel> GetClientes()
        {
            List<ClienteModel> clientes = new List<ClienteModel>();
            using (SqlConnection connection = ConnectionHelper.GetConnection())
            {
                string query = "GetClientes";
                SqlCommand command = new SqlCommand(query, connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ClienteModel cliente = new ClienteModel
                    {
                        ClienteID = Convert.ToInt32(reader["ClienteID"]),
                        Nombre = reader["Nombre"].ToString(),
                        Apellidos = reader["Apellidos"].ToString(),
                        Direccion = reader["Direccion"].ToString(),
                        Email = reader["Email"].ToString(),
                        Password = reader["Password"].ToString()
                    };

                    clientes.Add(cliente);
                }
                reader.Close();
            }
            return clientes;
        }
        public static int InsertCliente(ClienteModel cliente)
        {
            using (SqlConnection connection = ConnectionHelper.GetConnection())
            {
                string query = "InsertCliente";
                SqlCommand command = new SqlCommand(query, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                command.Parameters.AddWithValue("@Apellidos", cliente.Apellidos);
                command.Parameters.AddWithValue("@Direccion", cliente.Direccion);
                command.Parameters.AddWithValue("@Email", cliente.Email);
                command.Parameters.AddWithValue("@Password", cliente.Password);
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected;
            }
        }
        public static int UpdateCliente(ClienteModel cliente)
        {
            using (SqlConnection connection = ConnectionHelper.GetConnection())
            {
                string query = "UpdateCliente";
                SqlCommand command = new SqlCommand(query, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ClienteID", cliente.ClienteID);
                command.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                command.Parameters.AddWithValue("@Apellidos", cliente.Apellidos);
                command.Parameters.AddWithValue("@Direccion", cliente.Direccion);
                command.Parameters.AddWithValue("@Email", cliente.Email);
                command.Parameters.AddWithValue("@Password", cliente.Password);
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected;
            }
        }

    }
}

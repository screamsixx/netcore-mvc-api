using Data.Cliente;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Entity.Usuario
{
    public class UsuarioEntity
    {

        private static class ConnectionHelper
        {
            private static string ConnectionString = "Data Source=127.0.0.1;Initial Catalog=bd_tienda;User ID=dev;Password=123456789;";
            public static SqlConnection GetConnection() { return new SqlConnection(ConnectionString); }
        }

        public static isvalid Login(string email, string password)
        {
                     isvalid ob = new isvalid();

        bool isValidLogin = false;
            using (SqlConnection connection = ConnectionHelper.GetConnection())
            {
                string query = "Login";
                SqlCommand command = new SqlCommand(query, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@password", password);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string clienteID = reader["ClienteID"].ToString();

                    if (clienteID != "0")
                    {
                        ob.Valid = true;
                        ob.Email = email;
                        ob.UserId = clienteID;
                    }
                    else
                    {
                        ob.Valid = false;   
                    }
                    break;
                }
                reader.Close();
            }
            return ob;
        }
    }
}

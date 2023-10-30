using Data.Carrito;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Carrito
{
    public class CarritoEntity
    {
        private static class ConnectionHelper
        {
            private static string ConnectionString = "Data Source=127.0.0.1;Initial Catalog=bd_tienda;User ID=dev;Password=123456789;";
            public static SqlConnection GetConnection() { return new SqlConnection(ConnectionString); }
        }
        public static int InsertarCarrito(CarritoModel carrito)
        {
            using (SqlConnection connection = ConnectionHelper.GetConnection())
            {
                using (SqlCommand command = new SqlCommand("[dbo].[InsertCarrito]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ClienteID", carrito.ClienteID);
                    command.Parameters.AddWithValue("@ArticuloID", carrito.ArticuloID);
                    command.Parameters.AddWithValue("@Cantidad", carrito.Cantidad);
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected;
                }
            }
        }
        public static List<Detallecarrito> GetCarritoByClienteID(int clienteId)
        {
            List<Detallecarrito> carritos = new List<Detallecarrito>();

            using (SqlConnection connection = ConnectionHelper.GetConnection())
            {
                using (SqlCommand command = new SqlCommand("[dbo].[GetCarritoByClienteID]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ClienteID", clienteId);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Detallecarrito carrito = new Detallecarrito();
                        carrito.CarritoID = Convert.ToInt32(reader["CarritoID"]);
                        carrito.ClienteID = Convert.ToInt32(reader["ClienteID"]);
                        carrito.ArticuloID = Convert.ToInt32(reader["ArticuloID"]);
                        carrito.Cantidad = Convert.ToInt32(reader["Cantidad"]);
                        carrito.Descripcion = Convert.ToString(reader["Descripcion"]);
                        carrito.Precio = Convert.ToDecimal(reader["Precio"]);

                        // Verificar si la columna "Imagen" no es nula antes de intentar convertirla
                        if (!reader.IsDBNull(reader.GetOrdinal("Imagen")))
                        {
                            carrito.Imagen = Convert.ToBase64String((byte[])reader["Imagen"]);
                        }
                        else
                        {
                            // Asignar un valor predeterminado o nulo en caso de que la imagen sea nula
                            carrito.Imagen = null;
                        }

                        carritos.Add(carrito);
                    }

                }
            }

            return carritos;
        }

        public static int SumarCantidadCarrito(Detallecarrito detallecarrito)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = ConnectionHelper.GetConnection())
            {
                using (SqlCommand command = new SqlCommand("[dbo].[SumarCantidadCarrito]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CarritoID", detallecarrito.CarritoID);
                    command.Parameters.AddWithValue("@ClienteID", detallecarrito.ClienteID);
                    command.Parameters.AddWithValue("@ArticuloID", detallecarrito.ArticuloID);
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
            }
            return rowsAffected;
        }
        public static int RestarCantidadCarrito(Detallecarrito detallecarrito)
        {
            int rowsAffected = 0;
            using (SqlConnection connection = ConnectionHelper.GetConnection())
            {
                using (SqlCommand command = new SqlCommand("[dbo].[RestarCantidadCarrito]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CarritoID", detallecarrito.CarritoID);
                    command.Parameters.AddWithValue("@ClienteID", detallecarrito.ClienteID);
                    command.Parameters.AddWithValue("@ArticuloID", detallecarrito.ArticuloID);
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
            }
            return rowsAffected;
        }



    }
}






using Data.Articulo;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Entity.Articulo
{
    public class ArticuloEntity
    {
        private static class ConnectionHelper
        {
            private static string ConnectionString = "Data Source=127.0.0.1;Initial Catalog=bd_tienda;User ID=dev;Password=123456789;";
            public static SqlConnection GetConnection() { return new SqlConnection(ConnectionString); }
        }

        public static List<ArticuloModel> GetArticulos()
        {
            List<ArticuloModel> articulos = new List<ArticuloModel>();
            using (SqlConnection connection = ConnectionHelper.GetConnection())
            {
                string query = "GetArticulos";
                SqlCommand command = new SqlCommand(query, connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                   ArticuloModel articulo = new ArticuloModel
                    {
                        ArticuloID = Convert.ToInt32(reader["ArticuloID"]),
                        Codigo = reader["Codigo"].ToString(),
                        Descripcion = reader["Descripcion"].ToString(),
                        Precio = Convert.ToDecimal(reader["Precio"]),
                        //Imagen = "data:image/png;base64," + Convert.ToBase64String((byte[])reader["Imagen"]),
                        Stock = Convert.ToInt32(reader["Stock"]),
                        TiendaID = Convert.ToInt32(reader["TiendaID"])
                    };
                    if (reader["Imagen"] != DBNull.Value)
                    {
                        articulo.Imagen = "data:image/png;base64," + Convert.ToBase64String((byte[])reader["Imagen"]);
                    }
                    else
                    {
                        // Si la columna "Imagen" es nula, puedes asignar un valor predeterminado o dejarla en blanco según tus necesidades.
                        articulo.Imagen = ""; // O cualquier otro valor predeterminado
                    }
                    articulos.Add(articulo);
                }
                reader.Close();
            }
            return articulos;
        }

        //public static int InsertArticulo(ArticuloModel articulo)
        //{
        //    using (SqlConnection connection = ConnectionHelper.GetConnection())
        //    {
        //        string query = "InsertArticulo";
        //        SqlCommand command = new SqlCommand(query, connection);
        //        command.CommandType = CommandType.StoredProcedure;
        //        command.Parameters.AddWithValue("@Codigo", articulo.Codigo);
        //        command.Parameters.AddWithValue("@Descripcion", articulo.Descripcion);
        //        command.Parameters.AddWithValue("@Precio", articulo.Precio);
        //        command.Parameters.AddWithValue("@Imagen", articulo.Imagen);
        //        command.Parameters.AddWithValue("@Stock", articulo.Stock);
        //        command.Parameters.AddWithValue("@TiendaID", articulo.TiendaID);
        //        connection.Open();
        //        int rowsAffected = command.ExecuteNonQuery();
        //        return rowsAffected;
        //    }
        //}

        public static int InsertArticulo(ArticuloModel articulo)
        {
            using (SqlConnection connection = ConnectionHelper.GetConnection())
            {
                string query = "InsertArticulo";
                SqlCommand command = new SqlCommand(query, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Codigo", articulo.Codigo);
                command.Parameters.AddWithValue("@Descripcion", articulo.Descripcion);
                command.Parameters.AddWithValue("@Precio", articulo.Precio);
                // Convertir el string base64 a un array de bytes
                byte[] imagenBytes = Convert.FromBase64String(articulo.Imagen);
                command.Parameters.AddWithValue("@Imagen", imagenBytes);
                command.Parameters.AddWithValue("@Stock", articulo.Stock);
                command.Parameters.AddWithValue("@TiendaID", articulo.TiendaID);
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected;
            }
        }

        public static int DeleteArticuloByID(ArticuloModel articulo)
        {
            using (SqlConnection connection = ConnectionHelper.GetConnection())
            {
                string query = "DeleteArticuloByID";
                SqlCommand command = new SqlCommand(query, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ArticuloID", articulo.ArticuloID);
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected;
            }
        }



        public static int UpdateArticulo(ArticuloModel articulo)
        {
            using (SqlConnection connection = ConnectionHelper.GetConnection())
            {
                string query = "UpdateArticulo";
                SqlCommand command = new SqlCommand(query, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ArticuloID", articulo.ArticuloID);
                command.Parameters.AddWithValue("@Codigo", articulo.Codigo);
                command.Parameters.AddWithValue("@Descripcion", articulo.Descripcion);
                command.Parameters.AddWithValue("@Precio", articulo.Precio);
                string base64Image = articulo.Imagen;
                string imageData = base64Image.Substring(base64Image.IndexOf(',') + 1);
                byte[] imagenBytes = Convert.FromBase64String(imageData);
                command.Parameters.AddWithValue("@Imagen", imagenBytes);
                command.Parameters.AddWithValue("@Stock", articulo.Stock);
                command.Parameters.AddWithValue("@TiendaID", articulo.TiendaID);
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected;
            }
        }

        public static List<ArticuloModel> GetProductosById(int articuloID)
        {
            List<ArticuloModel> productos = new List<ArticuloModel>();
            using (SqlConnection connection = ConnectionHelper.GetConnection())
            {
                string query = "GetProductosById";
                SqlCommand command = new SqlCommand(query, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ArticuloID", articuloID);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ArticuloModel producto = new ArticuloModel
                    {
                        ArticuloID = Convert.ToInt32(reader["ArticuloID"]),
                        Codigo = reader["Codigo"].ToString(),
                        Descripcion = reader["Descripcion"].ToString(),
                        Precio = Convert.ToDecimal(reader["Precio"]),
                        Imagen = "data:image/png;base64," + Convert.ToBase64String((byte[])reader["Imagen"]),
                        Stock = Convert.ToInt32(reader["Stock"]),
                        TiendaID = Convert.ToInt32(reader["TiendaID"])
                    };
                    productos.Add(producto);
                }
                reader.Close();
            }
            return productos;
        }

    }
}

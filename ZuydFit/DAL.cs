using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZuydFit
{
    public class DAL
    {
        public string connectionString = "Data Source=.;Initial Catalog=HierKomtDeDatabase!!!!;Integrated Security=True";

        public DAL() 
        {

            /*public void CreateItem(Item item)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string sql = "INSERT INTO Product (Name, Description, Price, ProductCode, Brand) " +
                            "VALUES (@Name, @Description, @price, @ProductCode, @Brand) ";
                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {
                            command.Parameters.AddWithValue("Name", @item.Name);
                            command.Parameters.AddWithValue("Description", @item.Description);
                            command.Parameters.AddWithValue("Price", @item.Price);
                            command.Parameters.AddWithValue("ProductCode", item.ProductCode);
                            command.Parameters.AddWithValue("Brand", item.Brand);
                            command.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex) { throw ex; }
            }*/
            /*public void ReadItem(List<Item> items)
            {

                using (SqlConnection connection = new SqlConnection())
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        connection.ConnectionString = connectionString;
                        connection.Open();
                        command.Connection = connection;
                        command.CommandText = "SELECT Name, Description, Price, ProductCode, Brand " +
                            "FROM Product ORDER BY ID ";
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                //de uitroeptekens staan ervoor omdat de copiler denkt dat het een null waarde kan hebben terwijl dat zeker niet zo is.
                                items?.Add(new Item(reader[0].ToString(), reader[1].ToString(),
                                    decimal.Parse(reader[2].ToString()!), reader[3]?.ToString()));
                            }
                        }
                    }
                }
            }*/
            /*public void UpdateItem(Item item)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string sql = "UPDATE Product SET name = @name, Description = @description, Price = @price," +
                            " ProductCode = @productCode, Brand = @brand WHERE Id = @id";
                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {
                            command.Parameters.AddWithValue("Id", @item.Id);
                            command.Parameters.AddWithValue("Name", @item.Name);
                            command.Parameters.AddWithValue("Description", item.Description);
                            command.Parameters.AddWithValue("Price", @item.Price);
                            command.Parameters.AddWithValue("ProductCode", @item.ProductCode);
                            command.Parameters.AddWithValue("Brand", @item.Brand);
                            command.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex) { throw ex; }
            }*/
            /*public void DeleteItem(int ProductCode)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "DELETE FROM Product WHERE ProductCode = @ProductCode";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@ProductCode", ProductCode);
                        command.ExecuteNonQuery();
                    }
                }
            }*/



        }
    }
}

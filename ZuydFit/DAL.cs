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

            public void ReadItem(Item item)
            {
                Items.Clear();
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string sql = "SELECT * FROM Item, Product";
                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {

                                    Items.Add(new Item(reader[2].ToString(),
                                                       Convert.ToDouble(reader[3].ToString()),
                                                       reader[4].ToString()
                                                       ));
                                }
                            }
                        }
                    }


                }
                catch (Exception ex)
                {
                    throw (ex);
                }

            }
            public void CreateItem(Item item)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string sql = "INSERT INTO Product (Name, price) VALUES (@Name, @Price)";

                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {
                            command.Parameters.AddWithValue("@Name", item.Name);
                            command.Parameters.AddWithValue("@Price", item.Price);
                            command.ExecuteNonQuery();
                        }

                        string sql2 = "INSERT INTO Item (description) VALUES (@Description)";

                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {
                            command.Parameters.AddWithValue("@Description", item.Description);
                            command.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw (ex);
                }
            }
            public void UpdateItem(Item item)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string sql = "UPDATE Item SET itemName = @ItemName, price = @Price, description = @Description ";

                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {
                            command.Parameters.AddWithValue("@ItemName", item.Name);
                            command.Parameters.AddWithValue("@Price", item.Price);
                            command.Parameters.AddWithValue("@Description", item.Description);
                            command.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw (ex);
                }

            }
            public void DeleteItem(Item item)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string sql = "DELETE Item WHERE ItemId = @Id";
                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {
                            command.Parameters.AddWithValue("@Id", item.ItemId);
                            command.ExecuteNonQuery();
                        }


                    }

                }
                catch (Exception ex)
                {
                    throw (ex);
                }




            }
        }
    }
}

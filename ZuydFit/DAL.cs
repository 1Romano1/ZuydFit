using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ZuydFit
{
    public class DAL
    {
        public List <Activity> activities = new List <Activity> ();
       
        public static string connectionString = "Data Source=.;Initial Catalog=ZuydFit;Integrated Security=True";
        
        
        public DAL()
        {
        }

        public static void CreateActivity(Activity activity)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "INSERT INTO Activity (Name, Description, Duration, Sets) " +
                        "VALUES (@Name, @Description, @Duration, @Sets)";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("Name", activity.Name);
                        command.Parameters.AddWithValue("Description", activity.Description);
                        command.Parameters.AddWithValue("Duration", activity.Duration);
                        command.Parameters.AddWithValue("Sets", activity.Sets);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex) 
            {

            }
        }
        public static void ReadActivity(List<Activity> activities)
        {

            using (SqlConnection connection = new SqlConnection())
            {
                using (SqlCommand command = new SqlCommand())
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = "SELECT Name, Description, Duration, Sets " +
                        "FROM Activity ORDER BY ID ";
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            activities.Add(new Activity(reader[0].ToString(), reader[1].ToString(),
                                decimal.Parse(reader[2].ToString()), int.Parse(reader[3].ToString())));
                        }
                    }
                }
            }
        }
        public void UpdateActivity(Activity activity)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "UPDATE Activity SET name = @name, Description = @description, Duration = @Duration," +
                        " Sets = @Sets WHERE Id = @id";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        //command.Parameters.AddWithValue("Id", activity.Id);
                        command.Parameters.AddWithValue("Name", activity.Name);
                        command.Parameters.AddWithValue("Description", activity.Description);
                        command.Parameters.AddWithValue("Duration", activity.Duration);
                        command.Parameters.AddWithValue("Sets", activity.Sets);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex) { throw ex; }
        }
        public static void DeleteActivity(string Name)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "DELETE FROM Activity WHERE Name = @Name";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Name", Name);
                    command.ExecuteNonQuery();
                }
            }
        }

        


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


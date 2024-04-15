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

        public List<Activity> activities = new List<Activity>();
        public List<Advice> Advices { get; set; } = new List<Advice>();
        public static string connectionString = "Data Source=.;Initial Catalog=ZuydFit;Integrated Security=True;Encrypt=False";

        public DAL()
        {
        }


        public void CreateActivity(Activity activity)
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
                throw new Exception("Error creating activity.", ex);
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

        public static void CreateAdvice(Advice advice)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "INSERT INTO Advice (Description, Title) " +
                        "VALUES (@Description, @Title) ";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("Description", @advice.Description);
                        command.Parameters.AddWithValue("Title", @advice.Title);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex) { throw ex; }
        }
        public void ReadAdvice()
        {
            try {
                using (SqlConnection connection = new SqlConnection())
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        connection.ConnectionString = connectionString;
                        connection.Open();
                        command.Connection = connection;
                        command.CommandText = "SELECT Title, Description FROM Advice ORDER BY ID ";
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Advices.Add(new Advice(reader[0].ToString(), reader[1].ToString()));
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { throw ex; }
        }

        public Advice GetAdviceByTitle(string title)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection())
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        connection.ConnectionString = connectionString;
                        connection.Open();
                        command.Connection = connection;
                        command.CommandText = "SELECT Id, Title, Description " +
                            "FROM Advice WHERE Title = @Title";
                        command.Parameters.AddWithValue("@Title", title);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                return (new Advice(Int32.Parse(reader[0].ToString()), reader[1].ToString(), reader[2].ToString()));
                            }
                            return null;
                        }
                    }
                }
            }
            catch (Exception ex) { throw ex; }
        }


        public void UpdateAdvice(Advice advice)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "UPDATE Advice SET Id = @Id, Title = @Title, Description = @description, " +
                        "WHERE Id = @id";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("Id", advice.Id);
                        command.Parameters.AddWithValue("Title", advice.Title);
                        command.Parameters.AddWithValue("Description", advice.Description);
                        
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex) { throw ex; }
        }
        public void DeleteAdvice(Advice advice)
        {
            try {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "DELETE FROM Advice WHERE Id= @Id";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Id", advice.Id);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex) { throw ex; }
        }
    }
}


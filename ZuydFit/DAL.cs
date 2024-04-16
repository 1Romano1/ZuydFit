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

        public List<Location> loactions = new List<Location>();

        public string connectionString = "Data Source=LAPPIEMELLIE;Initial Catalog=ZuydFit;Integrated Security=True";

        public void CreateLocation(Location location)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "INSERT INTO Location (Classroom, Address, Zipcode, City) " +
                        "VALUES (@Classroom, @Address, @Zipcode, @City) ";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("Classroom", @location.Classroom);
                        command.Parameters.AddWithValue("Address", @location.Address);
                        command.Parameters.AddWithValue("Zipcode", @location.Zipcode);
                        command.Parameters.AddWithValue("City", @location.City);
                        // command.Parameters.AddWithValue("Training", @location.Trainings);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ReadLocation(List<Location> locations)
        {

            using (SqlConnection connection = new SqlConnection())
            {
                using (SqlCommand command = new SqlCommand())
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = "SELECT Classroom, Address, Zipcode, City " +
                        "FROM Location ORDER BY ID ";
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //de uitroeptekens staan ervoor omdat de copiler denkt dat het een null waarde kan hebben terwijl dat zeker niet zo is.
                            locations?.Add(new Location(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString()));
                        }
                    }
                }
            }
        }

        public void DeleteLocation(int Id)
        {
           using (SqlConnection connection = new SqlConnection(connectionString))
           {
               connection.Open();
               string sql = "DELETE FROM Location WHERE Id = @Id";
               using (SqlCommand command = new SqlCommand(sql, connection))
               {
                   command.Parameters.AddWithValue("@Id", Id);
                   command.ExecuteNonQuery();
               }
           }
        }

        public void UpdateLocation(Location location)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "UPDATE Location SET Classroom = @classroom, Address = @address, Zipcode = @zipcode," +
                        " City = @city WHERE Id = @id";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("Id", location.Id);
                        command.Parameters.AddWithValue("Classroom", location.Classroom);
                        command.Parameters.AddWithValue("Address", location.Address);
                        command.Parameters.AddWithValue("Zipcode", location.Zipcode);
                        command.Parameters.AddWithValue("City", location.City);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex) { throw ex; }
        }

    }
}

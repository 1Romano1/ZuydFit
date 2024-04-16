using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZuydFit.ZuydFit;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ZuydFit
{
    public class DAL
    {
        public string connectionString = "Data Source=DESKTOP-UC5L5BN;Initial Catalog = ZuydFit;Integrated Security = True";

        public DAL() { }

        List<Planning> plannings = new List<Planning>();
        public void CreatePlanning(Planning planning)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "INSERT INTO Planning (DateTime, Activity) VALUES (@DateTime, @Activity) ";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("DateTime", @planning.DateTime);
                        command.Parameters.AddWithValue("Activity", @planning.ActivityId);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex) { throw ex; }
        }
        public void ReadPlanning(List<Planning> plannings)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                using (SqlCommand command = new SqlCommand())
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = "SELECT DateTime, Activity FROM Planning ORDER BY ID";
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string dateTimeString = reader["DateTime"].ToString();
                            string activityId = reader["Activity"].ToString();

                            try
                            {
                                DateTime dateTime = DateTime.Parse(dateTimeString);
                                plannings?.Add(new Planning(dateTime, activityId));
                            }
                            catch (FormatException ex)
                            {

                                Console.WriteLine($"Failed to parse DateTime string: {dateTimeString}. Error: {ex.Message}");
                            }
                        }
                    }
                }


            }
        }
        public void UpdatePlanning(Planning planning)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "UPDATE Planning SET DateTime = @DateTime, ActivityId = @ActivityId WHERE Id = @Id";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Id", planning.Id);
                        command.Parameters.AddWithValue("@DateTime", planning.DateTime);
                        command.Parameters.AddWithValue("@ActivityId", planning.ActivityId);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeletePlanning(Planning planning)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "DELETE FROM Planning WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Id", planning.Id);
                    command.ExecuteNonQuery();
                }
            }
        }

    }
}
           


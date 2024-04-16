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
        public List<Goal> Goals { get; set; } = new List<Goal>();

        //public static string connectionString = "Data Source=LAPPIEMELLIE;Initial Catalog=ZuydFit;Integrated Security=True";
        public string connectionString = "Data Source=.;Initial Catalog=ZuydFit;Integrated Security=True";


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
        public void DeleteLocation(string Classroom)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "DELETE FROM Location WHERE Classroom = @Classroom";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Classroom", Classroom);
                    command.ExecuteNonQuery();
                }
            }
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

            }
        }
        public void ReadActivity(List<Activity> activities)
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
                        command.Parameters.AddWithValue("Id", activity.Id);
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
        public void DeleteActivity(string Name)
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


        public void CreateGoal(Goal goal)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "INSERT INTO Goal ( Name, Description, ProgressionId) " +
                        "VALUES ( @name, @Description, @ProgressionId) ";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("Name", goal.Name);
                        command.Parameters.AddWithValue("Description", goal.Description);
                        command.Parameters.AddWithValue("ProgressionId", goal.Progression);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex) { 
                throw ex; }
        }
        public Goal GetGoalByName(string name)
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
                        command.CommandText = "SELECT Id, Name, Description " +
                            "FROM Goal WHERE Name = @Name";
                        command.Parameters.AddWithValue("@Name", name);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                return (new Goal(Int32.Parse(reader[0].ToString()), reader[1].ToString(), reader[2].ToString()));
                            }
                            return null;
                        }
                    }
                }
            }
            catch (Exception ex) { throw ex; }
        }
        public void ReadGoal()
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
                        command.CommandText = "SELECT Name, Description, ProgressionId FROM Goal ORDER BY ID ";
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Goals.Add(new (reader[0].ToString(), reader[1].ToString(), reader[2].ToString()));
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { throw ex; }
        }
        public void UpdateGoal(Goal goal)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "UPDATE Goal SET Name = @Name, Description = @description, ProgressionId = @ProgressionId " +
                        "WHERE Id = @Id";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("Id", goal.Id);
                        command.Parameters.AddWithValue("Name", goal.Name);
                        command.Parameters.AddWithValue("Description", goal.Description);
                        command.Parameters.AddWithValue("ProgressionId", goal.Progression);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex) { throw ex; }
        }
        public void DeleteGoal(Goal goal)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "DELETE FROM dbo.Goal WHERE Id = @Id";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Id", goal.Id);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex) { throw ex; }
        }


        public void CreateAdvice(Advice advice)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "INSERT INTO Advice (Id, Description) " +
                        "VALUES (@Id, @Description) ";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("Id", @advice.Id);
                        command.Parameters.AddWithValue("Description", @advice.Description);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex) { throw ex; }
        }
        public void ReadAdvice()
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
                    string sql = "UPDATE Advice SET Id = @Id, Description = @description, " +
                        "WHERE Id = @id";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("Id", advice.Id);
                        command.Parameters.AddWithValue("Description", advice.Description);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex) { throw ex; }
        }
        public void DeleteAdvice(Advice advice)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "DELETE FROM Advice WHERE Id = @Id";
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


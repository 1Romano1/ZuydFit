using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ZuydFit
{
    public class DAL
    {

        public List<Activity> activities = new List<Activity>();
        public List<Advice> Advices { get; set; } = new List<Advice>();
        public List<Goal> Goals { get; set; } = new List<Goal>();
        List<Planning> plannings = new List<Planning>();
        public List<Progression> Progrresions = new List<Progression>();

        //public static string connectionString = "Data Source=LAPPIEMELLIE;Initial Catalog=ZuydFit;Integrated Security=True";
        public string connectionString = "Data Source=.;Initial Catalog=ZuydFit;Integrated Security=True";


        //DAL van Location.
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
                    string sql = "UPDATE Location SET Classroom = @Classroom, Address = @Address, Zipcode = @Zipcode," +
                        " City = @City WHERE Id = @id";
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


        //DAL van Activity.
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


        //DAL van Goal.
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
            catch (Exception ex)
            {
                throw ex;
            }
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
                        command.CommandText = "SELECT id, Name, Description, ProgressionId FROM Goal ORDER BY ID ";
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Goals.Add(new(Int32.Parse(reader[0].ToString()), reader[1].ToString(), reader[2].ToString(), reader[3].ToString()));
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


        //DAL van Advice.
        public void CreateAdvice(Advice advice)
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
            try
            {
                using (SqlConnection connection = new SqlConnection())
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        connection.ConnectionString = connectionString;
                        connection.Open();
                        command.Connection = connection;
                        command.CommandText = "SELECT Id, Title, Description FROM Advice ORDER BY Id ";
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Advices.Add(new Advice(Int32.Parse(reader[0].ToString()), reader[1].ToString(), reader[2].ToString()));
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { throw ex; }
        }
        public List<Advice> GetAdviceByTitle(string title)
        {
            try
            {
                Advices.Clear();
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
                                Advices.Add(new Advice(Int32.Parse(reader[0].ToString()), reader[1].ToString(), reader[2].ToString()));
                                //return (new Advice(Int32.Parse(reader[0].ToString()), reader[1].ToString(), reader[2].ToString()));
                            }
                            return Advices;
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
                    string sql = "UPDATE Advice SET Title = @Title, Description = @description WHERE Id = @id";
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
            try
            {
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


        //DAL van Planning.
        public void CreatePlanning(Planning planning)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "INSERT INTO Planning (DateTime, ActivityId) " + "VALUES (@DateTime, @ActivityId)";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("DateTime", planning.DateTime);
                        command.Parameters.AddWithValue("ActivityId", planning.ActivityId);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {

            }
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
                    command.CommandText = "SELECT DateTime, ActivityId" + " FROM Planning ORDER BY ID ";
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            plannings.Add(new Planning(DateTime.Parse(reader[0].ToString()), int.Parse(reader[1].ToString())));

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
                    string sql = "UPDATE Planning SET DateTime = @DateTime, ActivityId = @activityId  WHERE Id = @id";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("Id", planning.Id);
                        command.Parameters.AddWithValue("DateTime", planning.DateTime);
                        command.Parameters.AddWithValue("ActivityId", planning.ActivityId);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex) { throw ex; }
        }
        public void DeletePlanning(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "DELETE FROM Planning WHERE ActiivityId = @ActivityId";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Name", ActivityId);
                    command.ExecuteNonQuery();
                }
            }
        }


        //DAL van Progression.
        public void CreateProgression(Progression progression)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "INSERT INTO Progression (Percentage, Description) " +
                        "VALUES (@Percentage, @Description) ";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("Percentage", @progression.Percentage);
                        command.Parameters.AddWithValue("Description", @progression.Description);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex) { throw ex; }
        }
        public void ReadProgression()
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
                        command.CommandText = "SELECT Id, Description, Percentage FROM Progression ORDER BY ID ";
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Progrresions.Add(new Progression(Int32.Parse(reader[0].ToString()), reader[1].ToString, Int32.Parse(reader[1].ToString())));
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { throw ex; }
        }
        public Progression GetProgressionById(int id)
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
                        command.CommandText = "SELECT Id, Description, Percentage " +
                            "FROM Progression WHERE Id = @Id";
                        command.Parameters.AddWithValue("@Id", id);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                return (new Progression(reader[0].ToString(), Int32.Parse(reader[1].ToString())));
                            }
                            return null;
                        }
                    }
                }
            }
            catch (Exception ex) { throw ex; }
        }
        public void UpdateProgression(Progression progression)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "UPDATE Progression SET Id = @Id, Description = @description, Percentage = @Percentage" +
                        "WHERE Id = @id";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("Id", progression.Id);
                        command.Parameters.AddWithValue("Description", progression.Description);
                        command.Parameters.AddWithValue("Percentage", progression.Percentage);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex) { throw ex; }
        }
        public void DeleteProgression(Progression progression)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "DELETE FROM Progression WHERE Id = @Id";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Id", progression.Id);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex) { throw ex; }
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "DELETE FROM Planning WHERE Id = @Id";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex; // This line might not be necessary, you can simply use 'throw;' 
            }
        }

    }
}



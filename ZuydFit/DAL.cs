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
        public List<Advice> Advices { get; set; }
        public string connectionString = "Data Source=.;Initial Catalog=ZuydFit;Integrated Security=True;Encrypt=False";


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
            public void ReadAdvice(Advice advice)
            {
                try { 
                using (SqlConnection connection = new SqlConnection())
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        connection.ConnectionString = connectionString;
                        connection.Open();
                        command.Connection = connection;
                        command.CommandText = "SELECT Id, Description " +
                            "FROM Advice ORDER BY ID ";
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Advices.Add(new Advice (reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString()));
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { throw ex ; }
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
                try { 
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

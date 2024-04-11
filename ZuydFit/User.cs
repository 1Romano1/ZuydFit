using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZuydFit.ZuydFit;

namespace ZuydFit
{
    using System;
    using System.Linq;

    namespace ZuydFit
    {
        public class User
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int PersonalNumber { get; set; }
            public string Password { get; set; }

            public User(int id, string firstName, string lastName, int personalNumber, string password)
            {
                Id = id;
                FirstName = firstName;
                LastName = lastName;
                PersonalNumber = personalNumber;
                Password = password;
            }
            public User() { }
            var users = new User[]
        {
            new User(1, "John", "Doe", 123456789, "password123"),
            new User(2, "Jane", "Smith", 987654321, "letmein")
        }.AsQueryable();

            // Maak een nieuwe instantie van de User-klasse
            
            public void EmployeeLogin(IQueryable<User> users)
            {
                bool isLoggedIn = false;

                while (!isLoggedIn)
                {
                    Console.WriteLine("Enter your  Personalnumber:");
                    string personalNumber = Console.ReadLine();

                    Console.WriteLine("Enter your password:");
                    string password = Console.ReadLine();

                    var user = users.FirstOrDefault(u => u.PersonalNumber.ToString() == personalNumber);

                    if (user != null && user.Password == password)
                    {
                        isLoggedIn = true;
                        Console.Clear();
                        Console.WriteLine("You are now in the home screen.");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Incorrect username or password. Please try again.");
                    }
                }
            }
        }
    }
}


    


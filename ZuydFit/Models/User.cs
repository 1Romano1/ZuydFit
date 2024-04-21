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
        public abstract class User
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int PersonalNumber { get; set; }
            public string Password { get; set; }
            public DAL DAL { get; set; }


            /*public User(string firstName, string lastName, int personalNumber, string password)
            {
                FirstName = firstName;
                LastName = lastName;
                PersonalNumber = personalNumber;
                Password = password;
            }*/
            public User(int personalNumber,string password )
            {
                PersonalNumber = personalNumber;
                Password = password;
            }


            //Login functie voor de athlete en trianer.
            public abstract bool Login();
        }
    }
}
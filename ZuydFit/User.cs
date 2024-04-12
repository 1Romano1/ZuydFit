﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZuydFit
{
    public class User 
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PersonalNumber { get; set; }


        public User(string firstName, string lastName, int personalNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            PersonalNumber = personalNumber;
        }
    }
}

﻿using System;
using SQLite;

namespace imPACt.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Classification { get; set; }
        public string Location { get; set; }
        public int Role { get; set; } //Role: 1 is Mentee, 2 is Mentor, 3 is Admin
        //Interests
    }
}
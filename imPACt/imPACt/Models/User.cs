using System;
using System.Collections.Generic;
using SQLite;

namespace imPACt.Models
{
    [Table("Users")]
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Classification { get; set; }
        public string Location { get; set; }
        public int Role { get; set; } //Role: 1 is Mentee, 2 is Mentor, 3 is Admin
        public Boolean LoggedIn { get; set; }

        
        public List<User> Mentors { get; set; }
        public List<User> Mentees { get; set; }
        public List<string> Interests { get; set; }
    }
}

using System;
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

        
        //public User[] Mentors { get; set; }
        //public User[] Mentees { get; set; }
        //public String[] Interests { get; set; }
    }
}

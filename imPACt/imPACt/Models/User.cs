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
        public string University { get; set; }
        public string Classification { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string Major { get; set; }
        public string Minor { get; set; }
        public string ProfilePhoto { get; set; }
        public string Role { get; set; } //"Mentee" or "Mentor"
        //public String[] Interests { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using imPACt.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
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
        public List<string> Interests = new List<string>();
        public bool[] InterestedInEvents = new bool[4];
        public string Role { get; set; } //"Mentee" or "Mentor"
        //public String[] Interests { get; set; }
        public string UniversityInterest { get; set; }
        public string LocationInterest { get; set; }
        public string MajorInterest { get; set; }
        public string ClassificationInterest { get; set; }
    }
}
}

using System;
using SQLite;

namespace imPACt.Models
{
    [Table("Connections")]
    public class Connection
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int MenteeID { get; set; }
        public int MentorID { get; set; }
    }
}

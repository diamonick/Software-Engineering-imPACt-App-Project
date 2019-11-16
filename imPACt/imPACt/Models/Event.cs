using System;
using SQLite;

namespace imPACt.Models
{
    public class Event
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int CreatorID { get; set; }
        public string Location { get; set; }
        public DateTime EventDateTime { get; set; }
        public string Summary { get; set; }
        public int NumAttendees { get; set; }
    }
}

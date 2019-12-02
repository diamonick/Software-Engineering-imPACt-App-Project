using System;
using SQLite;

namespace imPACt.Models
{
    [Table("Events")]
    public class Event
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int CreatorID { get; set; }
        public string Keyword { get; set; }
        public string Location { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Photo { get; set; }
        public string EventDateTime { get; set; }
        public string Summary { get; set; }
        public int NumAttendees { get; set; }
    }
}

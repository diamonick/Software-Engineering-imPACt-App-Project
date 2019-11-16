using System;
using SQLite;

namespace imPACt.Models
{
    public class Message
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int FromID { get; set; }
        public int ToID { get; set; }
        public string MessageContent { get; set; }
        public DateTime DateTimeSent { get; set; }
    }
}

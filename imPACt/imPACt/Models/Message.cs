using System;
using SQLite;

namespace imPACt.Models
{
    [Table("Messages")]
    public class Message
    {
        [PrimaryKey, AutoIncrement]
        public String User { get; set; }
        //public int ID { get; set; }
        //public int FromID { get; set; }
        //public int ToID { get; set; }
        public string MessageContent { get; set; }
        //public DateTime DateTimeSent { get; set; }
        public bool IsSystemMessage;
        public bool IsOwnMessage;
    }
}

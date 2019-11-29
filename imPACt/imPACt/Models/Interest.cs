using System;
using SQLite;

namespace imPACt.Models
{
    [Table("Interests")]
    public class Interest
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string InterestName { get; set; }
        //Many to one relationship with Users
        public int OwnerUserId { get; set; }
    }
}

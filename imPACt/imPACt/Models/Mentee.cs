﻿using System;
using SQLite;

namespace imPACt.Models
{
    [Table("Mentors")]
    public class Mentor
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Classification { get; set; }
        public string Location { get; set; }
    }
}
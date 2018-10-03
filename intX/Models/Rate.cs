using System;
using SQLite;

namespace intX.Models
{
    public class Rate
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Password { get; set; }
        public string q1 { get; set; }
        public string q2 { get; set; }
        public string q3 { get; set; }
        public string q4 { get; set; }
        public string left { get; set; }
        public string center { get; set; }
        public string right { get; set; }
        public string lang { get; set; }
    }
}

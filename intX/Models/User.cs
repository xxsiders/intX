using System;
using SQLite;

namespace intX.Models
{
    public class User
    {
        [PrimaryKey,AutoIncrement]
        public int ID
        {
            get;
            set;
        }
        public int Rate
        {
            get;
            set;
        }
        public string q1
        {
            get;
            set;
        }
        public string q2
        {
            get;
            set;
        }
        public string q3
        {
            get;
            set;
        }
        public string q4
        {
            get;
            set;
        }
        public string email
        {
            get;
            set;
        }
        public string phone
        {
            get;
            set;
        }
        public DateTime date
        {
            get;
            set;
        }

    }
}

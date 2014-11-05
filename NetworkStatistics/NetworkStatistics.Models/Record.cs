namespace NetworkStatistics.Models
{
    using System;

    public class Record
    {
        public int Id { get; set; }

        public virtual User User{get;set;}

        public DateTime Date { get; set; }

        public string Host { get; set; }
    }
}

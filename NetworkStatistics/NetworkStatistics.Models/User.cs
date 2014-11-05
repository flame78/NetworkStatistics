namespace NetworkStatistics.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class User
    {
        public int Id { get; set; }

        [Index("IX_MacUserAgent",1, IsUnique = true)]
        public string Mac { get; set; }

        [Index("IX_MacUserAgent", 2, IsUnique = true)]
        public string UserAgent { get; set; }

        public string Name { get; set; }
    }
}
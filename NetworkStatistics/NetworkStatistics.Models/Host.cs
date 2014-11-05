namespace NetworkStatistics.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Host
    {
        public int Id { get; set; }

        [Required]
     //   [Index("IX_Name", 1, IsUnique = true)]
        public string Name { get; set; }
    }
}

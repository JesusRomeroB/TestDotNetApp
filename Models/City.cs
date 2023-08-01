using System.ComponentModel.DataAnnotations;

namespace TestDotNetApp.Models
{
    public class City
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        public int Cod { get; set; }
        [Required]
        public string Name { get; set; }
    }
}

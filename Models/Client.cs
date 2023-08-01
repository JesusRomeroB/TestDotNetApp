using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestDotNetApp.Models
{
    public class Client
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        public int Cod { get; set; }
        [Required]
        public string Name { get; set; }
        public int IdCity { get; set; }

        [ForeignKey("IdCity")]
        public City City { get; set; }
    }
}

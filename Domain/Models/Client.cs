using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestDotNetApp.Domain.Models
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
        [ForeignKey("City")]
        public int IdCity { get; set; }
    }
}

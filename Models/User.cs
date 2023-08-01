using System.ComponentModel.DataAnnotations;

namespace TestDotNetApp.Models
{
    public class User
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Pass { get; set; }
        [Required]
        public string Email { get; set; }
        public string Photo { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Organisationstool.Models
{
    public class Organisator
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Passwort { get; set; }
    }
}

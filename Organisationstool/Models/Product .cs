using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Organisationstool.Models
{
    public class Product
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public Double Price { get; set; }
        [Required]

        public string? Bild { get; set; }

        [NotMapped]
        public IFormFile? BildStream { get; set; }
    }
}

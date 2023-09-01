using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Organisationstool.Models
{
    public class M_Aufgaben
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Adresse { get; set; }

        [Required]
        public string? Aufgabe { get; set; }
        [Required]

        public DateTime Uhrzeitab { get; set; }
        [Required]

        public DateTime Uhrzeitbis { get; set; }


    }
}

using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Organisationstool.Models
{
    public class Mitwirkende
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Essen { get; set; }
        [Required]
        public string? Allergien { get; set; }
        [Required]
        public string? Aufgaben { get; set; }
      
        public DateTime? Uhrzeitab { get; set; }
        
        public DateTime? Uhrzeitbis { get; set; }


        public int? VeranstaltungId { get; set; }
        [ForeignKey("VeranstaltungId")]
        [ValidateNever]
        public Veranstaltungen? Veranstaltung { get; set; }




    }
}

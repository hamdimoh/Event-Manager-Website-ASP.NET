using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Organisationstool.Models
{
    public class Gast
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


       
        public int VeranstaltungId { get; set; }
        [ForeignKey("VeranstaltungId")]
        [ValidateNever]
        public Veranstaltungen? Veranstaltung { get; set; }
        





    }
}

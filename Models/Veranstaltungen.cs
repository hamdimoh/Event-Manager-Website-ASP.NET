using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace Organisationstool.Models
{
    public class Veranstaltungen
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Name der Veranstaltung")]
        public string? NamederVeranstaltung { get; set; }
        [Required]
        public string? Adresse { get; set; }
        [Required]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:H:mm}")]
        public DateTime Datum { get; set; }
        
        public string? Bemerkung { get; set; }
        [Required]
        public int? Nrgäste { get; set; }
        [Required]
        public int? NrMit { get; set; }
        [Required]
        public Double Budget { get; set; }
        [Required]
        public string? Essen { get; set; }


        [Required]
        public string? Bild { get; set; }

        [NotMapped]
        public IFormFile?  BildStream { get; set; }

        [NotMapped]
        public string? CurrentTeilnehmerName { get; set; }
        public string? Aufgaben { get; set; }


    }
}

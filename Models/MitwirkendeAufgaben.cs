using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Organisationstool.Models
{
    public class MitwirkendeAufgaben
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int VeranstaltungId { get; set; }
        [ForeignKey("VeranstaltungId")]
        public Veranstaltungen Veranstaltung { get; set; }
        [Required]
        public int MitwirkendeId { get; set; }
        [ForeignKey("MitwirkendeId")]
        public Mitwirkende Mitwirkende { get; set; }
    }
}

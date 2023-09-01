using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Organisationstool.Models
{
    public class Buchungen
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser? User { get; set; }

        [Required]
        public int VeranstaltungId { get; set; }

        [ForeignKey("VeranstaltungId")]
        public virtual Veranstaltungen? Veranstaltung { get; set; }

        [Required]
        public DateTime Datum { get; set; }
    }
}

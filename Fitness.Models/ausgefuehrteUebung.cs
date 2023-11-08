using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fitness.Models
{
    public class AusgefuehrteUebung
    {
        [Key]
        public Guid AusgefuehrteUebungId { get; set; }

        public Guid UebungId { get; set; }
        [ForeignKey("UebungId")]
        //[ValidateNever]
        public Uebung? Uebung { get; set; }

        public List<Set>? Sets { get; set; }

    }
}

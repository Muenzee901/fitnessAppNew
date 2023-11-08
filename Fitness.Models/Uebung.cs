using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Fitness.Models
{
    public enum Muskelkategorie
    {
        Brust,
        Bizeps,
        Trizeps,
        Rücken,
        Bauch,
        UntererRücken
    }

    public class Uebung
    {
        [Key]
        public Guid UebungId { get; set; }

        [Required(ErrorMessage = "Es muss ein Name für die Übung angegeben werden")]
        public string Name { get; set; }

        [MaxLength(500, ErrorMessage = "Es dürfen nicht mehr als 500 Zeichen genutzt werden")]
        [DisplayName("Ausführung")]
        public string? Ausfuehrung { get; set; }

        public Muskelkategorie Muskelgruppe { get; set; }

    }
}

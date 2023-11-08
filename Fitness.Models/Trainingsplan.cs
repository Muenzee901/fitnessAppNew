using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fitness.Models
{
    public class Trainingsplan
    {
        [Key]
        public Guid TrainingsplanId { get; set; }

        [Required]
        public string Name { get; set; }

        public List<GeplanteUebung> geplanteUebungen { get; } = new List<GeplanteUebung>();

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.Models
{
    public class GeplanteUebung
    {
        [Key]
        public Guid GeplanteUebungId { get; set; }

        [ForeignKey("TrainingsplanId")]
        public Guid TrainingsplanId { get; set; }

        public Guid UebungId { get; set; }
        [ForeignKey("UebungId")]
        //[ValidateNever]
        public Uebung? Uebung { get; set; }

        public int? AnzahlSaetze { get; set; }
    }
}

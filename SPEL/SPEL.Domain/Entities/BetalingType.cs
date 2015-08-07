using SPEL.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPEL.Domain.Entities
{
    public class BetalingType : Entity
    {
        public decimal Bedrag { get; set; }
        public String BetalingTypeNaam { get; set; }
        public int? SportklasseID {get;set;}
        [ForeignKey("SportklasseID")]
        public virtual Sportklasse Sportklasse { get; set; }

    }
}

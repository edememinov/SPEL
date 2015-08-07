using SPEL.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPEL.Domain.Entities
{
    public class Inschrijving : Entity
    {
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = false)]
        public DateTime datumInschrijving { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = false)]
        public DateTime? datumUitschrijving { get; set; }

        
        public int lidId { get; set; }


        public int sportklasseId { get; set; }

        [ForeignKey(name: "sportklasseId")]
        public virtual Sportklasse sportklasse { get; set; }

        [ForeignKey(name: "lidId")]
        public virtual Lid lid {get; set;}
    }
}

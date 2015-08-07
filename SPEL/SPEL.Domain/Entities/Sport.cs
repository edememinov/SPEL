using SPEL.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPEL.Domain.Entities
{
    public enum TypeSport { Balsport, Fietssport, Atletiek}

    public class Sport : Entity
    {
        [Required]
        public string naam {get; set;}

        [Required]
        public TypeSport typeSport { get; set; }

        public string beschrijving { get; set; }

        public virtual ICollection<Sportklasse> klasses {get; set;}

    
    }
}

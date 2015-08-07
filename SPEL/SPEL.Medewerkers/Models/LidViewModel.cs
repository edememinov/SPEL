using SPEL.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace SPEL.Medewerkers.Models
{
    public class LidViewModel
    {
        public IEnumerable<Lid> leden { get; set; }
    }
}
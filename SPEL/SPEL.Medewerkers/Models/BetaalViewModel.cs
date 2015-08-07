using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SPEL.Domain.Entities;

namespace SPEL.Medewerkers.Models
{
    public class BetaalViewModel
    {
        public IEnumerable<Betaling> betaaldeRekeningen {get;set;}
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SPEL.Domain.Entities;

namespace SPEL.Medewerkers.Models
{
    public class PrintenViewModel
    {
        public List<Lid> leden { get; set; }
        public List<Inschrijving> inschrijvingen { get; set; }
        public List<Betaling> betaling { get; set; }
        public List<Sportklasse> klasses { get; set; }


    }
}
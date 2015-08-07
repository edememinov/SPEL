using SPEL.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPEL.Medewerkers.Models
{
    public class InschrijvingViewModel
    {
        public List<Sportklasse> klasses { get; set; }
        public Lid lid { get; set; }
    }
}
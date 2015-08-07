using SPEL.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SPEL.Medewerkers.Models
{
    public class PerPeriodeViewModel
    {
        public bool inuit { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = false)]
        [Display(Name = "Begin datum")]
        public DateTime beginDatum { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = false)]
        [Display(Name = "Eind datum")]
        public DateTime eindDatum { get; set; }

        [Display(Name = "Zoeken naar alleen uitgeschreven personen")]
        public IEnumerable<Inschrijving> inschrijvingen { get; set; }
    }
}
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
    public enum KlassenIndeling { Kinderen, Junioren, Senioren, VijftigPlus}

    public class Sportklasse : Entity
    {
        [Required]
        public string naam { get; set; }

        public int minLeeftijd
        {
            get
            {
                int leeftijd = 0;
                switch (indeling)
                {
                    case KlassenIndeling.Kinderen:
                        {
                            leeftijd = 6;
                            break;
                        }
                    case KlassenIndeling.Junioren:
                        {
                            leeftijd = 12;
                            break;
                        }
                    case KlassenIndeling.Senioren:
                        {
                            leeftijd = 16;
                            break;
                        }
                    case KlassenIndeling.VijftigPlus:
                        {
                            leeftijd = 50;
                            break;
                        }
                }

                return leeftijd;
            }
        }

        public int maxLeeftijd
        {
            get
            {
                int leeftijd = 0;
                switch (indeling)
                {
                    case KlassenIndeling.Kinderen:
                        {
                            leeftijd = 12;
                            break;
                        }
                    case KlassenIndeling.Junioren:
                        {
                            leeftijd = 16;
                            break;
                        }
                    case KlassenIndeling.Senioren:
                        {
                            leeftijd = 100;
                            break;
                        }
                    case KlassenIndeling.VijftigPlus:
                        {
                            leeftijd = 100;
                            break;
                        }
                }

                return leeftijd;
        }
        }

        [Required]
        public KlassenIndeling indeling { get; set; }

        [Required]
        public int SportID { get; set; }

        [ForeignKey("SportID")]
        public virtual Sport sport { get; set; }

    }
}

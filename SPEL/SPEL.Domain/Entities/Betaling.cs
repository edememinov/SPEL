using SPEL.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPEL.Domain.Entities
{
    public class Betaling : Entity
    {
        public int BetalingTypeID { get; set; }
        public int LidID {get;set;}
        public virtual Lid Lid{get;set;}
        public virtual BetalingType BetalingType{get;set;}
        public bool Betaald { get; set; }
        public decimal Bedrag { get; set; }
       
    }
}

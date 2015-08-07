using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SPEL.Domain.Concrete
{
    public class Entity
    {
        [HiddenInput(DisplayValue = false)]
        [Key]
        public int ID { get; set; }
    }
}

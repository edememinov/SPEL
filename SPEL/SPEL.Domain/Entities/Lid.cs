using SPEL.Domain.Concrete;
using SPEL.Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SPEL.Domain.Entities
{
    public enum Geslacht
    {
        man,
        vrouw
    }


    public class Lid : Entity
    {
        [Required]
        public String Naam { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = false)]
        [Display(Name = "Geboorte datum")]
        [ValidateDateRange(FirstDate = "01/01/1910", SecondDate = "01/01/2016")]
        public DateTime GebDatum { get; set; }
        [Required]
        public Geslacht Geslacht { get; set; }
        
        public String Woonplaats { get; set; }
        
        public String Adres { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public String Email { get; set; }

        public int? Telnr { get; set; }

        public int? PassID { get; set; }

        public String Pasfoto { get; set; }

        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }

        
        
    }
    

}

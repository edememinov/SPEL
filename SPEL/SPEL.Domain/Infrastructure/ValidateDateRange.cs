using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPEL.Domain.Infrastructure
{
    public class ValidateDateRange : ValidationAttribute
    {
        public String FirstDate { get; set; }
        public String SecondDate { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // your validation logic
            if ((DateTime) value >= DateTime.Parse(FirstDate) && (DateTime) value <= DateTime.Parse(SecondDate))
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Datum is niet binnen het bereik");
            }
        }
        
    }
}

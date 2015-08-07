using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SPEL.Leden.Models;
using SPEL.Domain.Entities;
using Microsoft.AspNet.Identity;

namespace SPEL.Leden.Models
{
    public class LoginViewModellen
    {
        public ExternalLoginConfirmationViewModel login { get; set;}
        public IEnumerable<Lid> leden { get; set; }
        public IList<UserLoginInfo> Logins { get; set; }
    }
}
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fogasnaplo.Models
{
    public class Users : IdentityUser
    {
        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        [Required(ErrorMessage = "A mező kitöltése kötelező!")]
        public string VezetekNev { get; set; }
        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        [Required(ErrorMessage = "A mező kitöltése kötelező!")]
        public string KeresztNev { get; set; }
        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        [Required(ErrorMessage = "A mező kitöltése kötelező!")]
        public string HorgaszIgazolvany { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        [Required(ErrorMessage = "A mező kitöltése kötelező!")]
        public string Csapatnev { get; set; }

    }
}

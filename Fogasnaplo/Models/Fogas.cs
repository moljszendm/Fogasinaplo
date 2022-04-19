using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fogasnaplo.Models
{
    public class Fogas
    {
        public int Id { get; set; }
        [Display(Name = "Név")]
        [StringLength(60)]
        public string Nev { get; set; }
        [Display(Name = "Csapat neve")]
        [StringLength(60)]
        public string CsapatNev { get; set; }

        [Display(Name = "Fogás ideje")]
        public DateTime Ido { get; set; }

        [Display(Name = "Halfaj")]
        public string HalFajtak { get; set; }

        [Display(Name = "Súly (kg)")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Suly { get; set; }

        [Display(Name = "Horgász állás")]
        public int Allasok { get; set; }


        public Fogas()
        {

        }
    }

}

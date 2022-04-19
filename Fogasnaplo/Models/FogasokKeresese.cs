using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fogasnaplo.Models
{
    public class FogasokKeresese
    {
        public string NevKeres { get; set; }
        public string CsapatKeres { get; set; }
        public SelectList CsapatLista { get; set; }
        public List<Fogas> FogasLista { get; set; }
    }
}

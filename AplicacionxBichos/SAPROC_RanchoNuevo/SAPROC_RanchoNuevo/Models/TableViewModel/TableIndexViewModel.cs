using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAPROC_RanchoNuevo.Models.TableViewModel
{
    public class TableIndexViewModel
    {
        public string nfilaylote { get; set; }
        public DateTime fechainicio { get; set; }

        public DateTime fechatermino { get; set; }
        public float temperatura { get; set; }
        public int nvolteos { get; set; }
        public int nviajes { get; set; }
        public float cascarrilo  { get; set; }
        public float toneladas { get; set; }
        public float produccion { get; set; }
        public float conversion { get; set; }
        public string estado { get; set; }

        
    }
}
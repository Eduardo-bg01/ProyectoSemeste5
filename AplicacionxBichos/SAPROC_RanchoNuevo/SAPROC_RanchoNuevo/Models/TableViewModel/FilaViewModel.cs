using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAPROC_RanchoNuevo.Models.TableViewModel
{
    public class FilaViewModel
    {
        public int idFila { get; set; }
        public string identificadorFila { get; set; }

        public int? nViajes { get; set; }

        public double? cCascarrillo { get; set; }

        public string Comentarios { get; set; }
        
        public double? toneladasLinea { get; set; }

        public double? produccion { get; set; }
    }
}
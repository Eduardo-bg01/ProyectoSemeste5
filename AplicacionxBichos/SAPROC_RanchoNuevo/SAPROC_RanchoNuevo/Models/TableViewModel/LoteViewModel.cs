using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SAPROC_RanchoNuevo.Models.TableViewModel
{
    public class LoteViewModel
    {
        public int idLote { get; set; }
        public string identificadorLote { get; set; }
        public int? nFilas { get; set; }
        public DateTime? fecha_Inicio { get; set; }
        public DateTime? fecha_Termino { get; set; }
        public string estadoLote { get; set; }
        public DateTime? fecha_Registro { get; set; }
    }
}
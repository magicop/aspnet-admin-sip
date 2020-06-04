using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sip.Models.Dto
{
    public class Solicitud
    {
        #region Accesadores y Mutadores
        public int id { get; set; }
        public string descripcionPrestacion { get; set; }
        public string nombrePrestador { get; set; }
        public string isapre { get; set; }
        public string rutNombreAfiliado { get; set; }
        public string estado { get; set; }
        #endregion
    }
}
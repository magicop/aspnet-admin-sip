using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sip.Models.Dto
{
    public class Prestacion
    {
        #region Accesadores y Mutadores
        public int codPaquete { get; set; }
        public string descripcion { get; set; }
        public string estado { get; set; }
        public DateTime fechaInicio { get; set; }
        public DateTime fechaTermino { get; set; }
        public string isapre { get; set; }
        public int idprestacion { get; set; }
        #endregion
    }
}
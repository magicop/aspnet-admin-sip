using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sip.Models.Dto
{
    public class Prestador
    {
        #region Accesadores y Mutadores
        public int id { get; set; }
        public int rut { get; set; }
        public int rutInstitucion { get; set; }
        public int secuencia { get; set; }
        public string isapre { get; set; }
        public string estado { get; set; }
        public DateTime fechaInicio { get; set; }
        public DateTime fechaTermino { get; set; }
        public string observacion { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string direccionWeb { get; set; }
        #endregion
    }
}
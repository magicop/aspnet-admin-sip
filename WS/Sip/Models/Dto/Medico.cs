using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sip.Models.Dto
{
    public class Medico
    {
        #region Accesadores y Mutadores
        public int idPrestacion { get; set; }
        public int idPrestador { get; set; }
        public string isapre { get; set; }
        public string nombre { get; set; }
        public int rut { get; set; }
        #endregion
    }
}
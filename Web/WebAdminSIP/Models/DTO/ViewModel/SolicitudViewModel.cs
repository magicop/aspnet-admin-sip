using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAdminSIP.Models.DTO.ViewModel
{
    public class SolicitudViewModel
    {
        #region Accesadores y Mutadores

        public int rut { get; set; }
        public int id { get; set; }
        public string prestacion { get; set; }
        public string prestador { get; set; }
        public string isapre { get; set; }
        public string afiliado { get; set; }
        public string estado { get; set; }
        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAdminSIP.Models.DTO
{
    public class Prestacion
    {

        #region Accesadores y Mutadores
        public int codPaquete { get; set; }

        public int codPaqueteNew { get; set; }

        public string descripcion { get; set; }

        public string isapre { get; set; }

        public string estado { get; set; }

        public DateTime inicioVigencia { get; set; }

        public DateTime terminoVigencia { get; set; }

        public string codIsapre { get; set; }
        public SelectList LstIsapres { get; set; }

        public int idprestacion { get; set; }
        
        #endregion

        #region Constructor
        // Inicializa el constructor sin parámetros y le asigna los valores correspondientes
        public Prestacion()
        {
            List<SelectListItem> lstIsapre = new List<SelectListItem>();

            lstIsapre.Add(new SelectListItem() { Text = "Banmédica", Value = "B" });
            lstIsapre.Add(new SelectListItem() { Text = "Vida Tres", Value = "T" });

            LstIsapres = new SelectList(lstIsapre, "Value", "Text");

        }
        #endregion
    }



}
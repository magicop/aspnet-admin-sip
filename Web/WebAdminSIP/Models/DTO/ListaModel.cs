using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAdminSIP.Models.ApiRest;

namespace WebAdminSIP.Models.DTO
{
    public class ListaModel
    {
        #region Accesadores y Mutadores
        //public string CodIsapre { get; set; }
        //public SelectList LstIsapres { get; set; }
        //public string CodPrestacion { get; set; }
        //public SelectList LstPrestaciones { get; set; }
        //public string CodPrestador { get; set; }
        //public SelectList LstPrestadores { get; set; }
        public List<SelectListItem> lstIsapre = new List<SelectListItem>();
        public SelectList LstIsapres { get; set; }

        public string descripcion { get; set; }

        public string isapre { get; set; }
        public SelectList LstPrestaciones { get; set; }

        public string prestador { get; set; }
        #endregion

        #region Constructor
        // Inicializa el constructor sin parámetros y le asigna los valores correspondientes
        public ListaModel()
        {

            var _restIngresos = new ApiRest.IngresosRest();

            var lstPrestaciones = _restIngresos.ListarPrestaciones();
            LstPrestaciones = new SelectList(lstPrestaciones, "idprestacion", "descripcion");


            lstIsapre.Add(new SelectListItem() { Text = "Banmédica", Value = "B" });
            lstIsapre.Add(new SelectListItem() { Text = "Vida Tres", Value = "T" });
            
            LstIsapres = new SelectList(lstIsapre, "Value", "Text");

        }
        #endregion
    }
}
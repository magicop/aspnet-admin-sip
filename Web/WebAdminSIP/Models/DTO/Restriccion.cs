using LinqToExcel.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAdminSIP.Models.DTO
{
    public class Restriccion
    {
        [ExcelColumn("PRESSIP_ID")]
        public int idprestacion { get; set; }
        [ExcelColumn("PLSA_CCOD")]
        public string codplan { get; set; }
        [ExcelColumn("ISAP_CEMPRESA")]
        public string isapre { get; set; }
        public string codIsapre { get; set; }
        public SelectList LstIsapres { get; set; }


        #region Constructor
        // Inicializa el constructor sin parámetros y le asigna los valores correspondientes
        public Restriccion()
        {
            List<SelectListItem> lstIsapre = new List<SelectListItem>();

            lstIsapre.Add(new SelectListItem() { Text = "Banmédica", Value = "B" });
            lstIsapre.Add(new SelectListItem() { Text = "Vida Tres", Value = "T" });

            LstIsapres = new SelectList(lstIsapre, "Value", "Text");

        }
        #endregion
    }
}
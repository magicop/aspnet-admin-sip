using LinqToExcel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAdminSIP.Models.ApiRest;
using WebAdminSIP.Models.DTO;

namespace WebAdminSIP.Controllers
{
    public class RestriccionController : Controller
    {
        // Llama al Api Rest para llamar al Webservice
        IngresosRest _restSip = new IngresosRest();

        // GET: Restriccion
        public ActionResult Index()
        {
            return View();
        }

        #region General
        public ActionResult FormAgregar()
        {
            return View(new Restriccion());
        }

        public ActionResult Agregar(Restriccion r)
        {
            _restSip.PostAgregarRestriccionExcel(2, r.codplan, r.isapre);

            if (r.isapre == "B" || r.isapre == "banmedica")
            {
                List<Restriccion> model = _restSip.GetRestricciones(r.codplan, "banmedica");
                return View("Banmedica", model);
            }
            else
            {
                List<Restriccion> model = _restSip.GetRestricciones(r.codplan, "vidatres");
                return View("VidaTres", model);
            }
        }

        public ActionResult FormBuscar()
        {
            return View(new Restriccion());
        }
        public ActionResult Buscar(Restriccion r)
        {
            if(r.isapre == "B")
            {
                List<Restriccion> model = _restSip.GetRestricciones(r.codplan, "banmedica");
                return View("Banmedica", model);
            }
            else
            {
                List<Restriccion> model = _restSip.GetRestricciones(r.codplan, "vidatres");
                return View("VidaTres", model);
            }
        }

        public ActionResult Eliminar(Restriccion r)
        {

            _restSip.PostEliminarRestriccion(r.codplan, r.isapre);

            if (r.isapre == "banmedica")
            {
                List<Restriccion> model = _restSip.GetRestricciones(r.codplan, "banmedica");
                return View("Banmedica", model);
            }
            else
            {
                List<Restriccion> model = _restSip.GetRestricciones(r.codplan, "vidatres");
                return View("VidaTres", model);
            }
        }
        #endregion

        #region Excel
        [HttpPost]
        public ActionResult AgregarExcel(Restriccion objEmpDetail, HttpPostedFileBase FileUpload)
        {

            //EmployeeDBEntities objEntity = new EmployeeDBEntities();
            string data = "";
            if (FileUpload != null)
            {
                if (FileUpload.ContentType == "application/vnd.ms-excel" || FileUpload.ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                {
                    string filename = FileUpload.FileName;

                    if (filename.EndsWith(".xlsx"))
                    {
                        string targetpath = Server.MapPath("~/DetailFormatInExcel/");
                        FileUpload.SaveAs(targetpath + filename);
                        string pathToExcelFile = targetpath + filename;

                        string sheetName = "Hoja1";

                        var excelFile = new ExcelQueryFactory(pathToExcelFile);
                        var empDetails = from a in excelFile.Worksheet<Restriccion>(sheetName) select a;
                        foreach (var a in empDetails)
                        {
                            if (a.codplan != null && a.isapre != null && a.idprestacion != 0)
                            {

                                _restSip.PostAgregarRestriccionExcel(a.idprestacion, a.codplan, a.isapre);
                                
                            }
                        }
                    }

                    
                }
            }

            return View("FormAgregar", new Restriccion());

        }
        #endregion
    }
}
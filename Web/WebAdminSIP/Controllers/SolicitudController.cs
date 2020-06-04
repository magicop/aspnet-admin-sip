using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAdminSIP.Models.ApiRest;
using WebAdminSIP.Models.DTO;
using WebAdminSIP.Models.DTO.ViewModel;

namespace WebAdminSIP.Controllers
{
    public class SolicitudController : Controller
    {
        #region Variables y Action Index

        // Llama al Api Rest para llamar al Webservice
        IngresosRest _restIngresos = new IngresosRest();

        // GET: Pago
        public ActionResult Index()
        {
            return View();
        }
        #endregion

        #region Form por rut
        public ActionResult FormRut()
        {
            return View();
        }
        #endregion

        #region Form por id
        public ActionResult FormId()
        {
            return View();
        }
        #endregion

        #region Por rut
        [HttpPost]
        public ActionResult PorRut(SolicitudViewModel model)
        {
            try
            {
                // Se pasa a clase DTO para mostrar el modelo
                DtoToViewModel ToDTO = new DtoToViewModel();
                List<SolicitudViewModel> solicitudList = _restIngresos.GetSolicitudes("rut", model.rut.ToString());
                return View(solicitudList);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error");
            }
        }
        #endregion

        #region Por id
        [HttpPost]
        public ActionResult PorId(SolicitudViewModel model)
        {
            try
            {
                // Se pasa a clase DTO para mostrar el modelo
                DtoToViewModel ToDTO = new DtoToViewModel();
                List<SolicitudViewModel> solicitudList = _restIngresos.GetSolicitudes("id", model.id.ToString());
                return View(solicitudList);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error");
            }
        }
        #endregion
    }
}
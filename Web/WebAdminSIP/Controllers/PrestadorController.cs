using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAdminSIP.Models.DTO.ViewModel;
using WebAdminSIP.Models.ApiRest;
using WebAdminSIP.Models.DTO;

namespace WebAdminSIP.Controllers
{
    public class PrestadorController : Controller
    {


        #region Variables y Action Index

        // Llama al Api Rest para llamar al Webservice
        IngresosRest _restSip = new IngresosRest();

        #endregion

        #region Banmedica
        [HttpGet]
        public ActionResult Banmedica(Prestador p)
        {
            try
            {
                // Se pasa a clase DTO para mostrar el modelo
                DtoToViewModel ToDTO = new DtoToViewModel();
                List<Prestador> model = _restSip.GetPrestadoresB();
                return View(model);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error");
            }
        }
        #endregion

        #region VidaTres
        [HttpGet]
        public ActionResult VidaTres(Prestador p)
        {
            try
            {
                // Se pasa a clase DTO para mostrar el modelo
                DtoToViewModel ToDTO = new DtoToViewModel();
                List<Prestador> model = _restSip.GetPrestadoresT();
                return View(model);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error");
            }
        }
        #endregion

        [HttpGet]
        public ActionResult Eliminar(string isapre, int rut)
        {
            try
            {

                _restSip.PostEliminarPrestador(rut, isapre);

                if(isapre == "banmedica")
                {
                    List<Prestador> model = _restSip.GetPrestadoresB();
                    return View("Banmedica", model);
                }
                else
                {
                    List<Prestador> model = _restSip.GetPrestadoresT();
                    return View("VidaTres", model);
                }
                
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error");
            }
        }

        public ActionResult FormAgregar()
        {
            return View();
        }

    }
}
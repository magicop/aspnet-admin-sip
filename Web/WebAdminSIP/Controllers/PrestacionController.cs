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
    public class PrestacionController : Controller
    {
        #region Variables y Action Index

        // Llama al Api Rest para llamar al Webservice
        IngresosRest _restSip = new IngresosRest();

        // GET: Pago
        public ActionResult Index()
        {
            return View();
        }
        #endregion

        #region Banmedica
        [HttpGet]
        public ActionResult Banmedica(Prestacion p)
        {
            try
            {

                List<Prestacion> model = _restSip.GetPrestacionesB();
                return View(model);

            }
            catch (Exception ex)
            {
                return RedirectToAction("Error");
            }
        }

        [HttpGet]
        public ActionResult TerminarVigenciaB(int codpaquete)
        {
            try
            {

                _restSip.PostTerminarVigencia(codpaquete);

                List<Prestacion> model = _restSip.GetPrestacionesB();
                return View("Banmedica", model);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error");
            }
        }

        #endregion

        #region VidaTres
        [HttpGet]
        public ActionResult VidaTres(Prestacion p)
        {
            try
            {
                // Se pasa a clase DTO para mostrar el modelo
                DtoToViewModel ToDTO = new DtoToViewModel();
                List<Prestacion> model = _restSip.GetPrestacionesT();
                return View(model);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error");
            }
        }

        [HttpGet]
        public ActionResult TerminarVigenciaT(Prestacion p)
        {
            try
            {
                DtoToViewModel ToDTO = new DtoToViewModel();

                _restSip.PostTerminarVigencia(p.codPaquete);

                List<Prestacion> model = _restSip.GetPrestacionesT();
                return View("VidaTres", model);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error");
            }
        }
        #endregion

        #region General
        [HttpGet]
        public ActionResult FormEditar(int codpaquete, string isapre, string descripcion)
        {
            try
            {
                Prestacion p = new Prestacion();
                p.codPaquete = codpaquete;
                if (isapre == "B")
                {
                    p.isapre = "Banmedica";
                }
                else
                {
                    p.isapre = "Vida Tres";
                }

                p.descripcion = descripcion;

                return View(p);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error");
            }
        }

        [HttpPost]
        public ActionResult Editar(Prestacion p)
        {
            try
            {
                _restSip.PostEditarPrestacion(p.codPaquete, p.isapre, p.codPaqueteNew, p.descripcion);

                List<Prestacion> model = _restSip.GetPrestacionesB();
                return View("Banmedica",model);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error");
            }
        }

        public ActionResult FormAgregar()
        {
            return View(new Prestacion());
        }

        public ActionResult Agregar(Prestacion p)
        {
            try
            {

                _restSip.PostAgregarPrestacion(p.isapre, p.codPaquete, p.descripcion);

                if (p.isapre == "B")
                {
                    List<Prestacion> model = _restSip.GetPrestacionesB();
                    return View("Banmedica",model);
                }
                else
                {
                    List<Prestacion> model = _restSip.GetPrestacionesT();
                    return View("VidaTres",model);
                }
                
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error");
            }
        }
        #endregion


    }
}
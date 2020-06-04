using log4net;
using log4net.Config;
using Sip.Models.Contracts;
using Sip.Models.Dto;
using Sip.Utils;
using System;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Sip.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class HomeController : Controller
    {

        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(HomeController));
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sipRepository"></param>
        public HomeController(ISipRepository sipRepository)
        {
            XmlConfigurator.Configure();
        }

        /// <summary>
        /// Base64 y desencriptaid.
        /// </summary>
        /// </summary>
        /// <returns></returns>
        public ActionResult Index(string id)
        {
            try
            {
                if (id == null) return View("NonAuth");
                var emp = new ConsultaAD().ObtenerEmpleadoRun(Utilitarios.Desencripta(id));
                if (emp == null) return View("NonAuth");
                var user = new Empleado(emp);
                ViewBag.RunEjecutivo = user.Run.Split('-')[0];
                ViewBag.UserName = user.Nombre + " " + user.Apellidos;
                ViewBag.Id = id;
                Log.Debug("Ejecutivo OK");
                return View();
            }
            catch(Exception ex)
            {
                Log.Error(string.Format("{0} {1} {2}", ex.Message, ex.InnerException, ex.StackTrace));
                return View("NonAuth");
            }
        }


    }
}

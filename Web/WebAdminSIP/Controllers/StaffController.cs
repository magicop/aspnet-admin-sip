using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAdminSIP.Models.ApiRest;
using WebAdminSIP.Models.DTO;

namespace WebAdminSIP.Controllers
{
    public class StaffController : Controller
    {
        // Llama al Api Rest para llamar al Webservice
        IngresosRest _restSip = new IngresosRest();

        // GET: Staff
        public ActionResult Index()
        {
            return View(new ListaModel());
        }

        public ActionResult Buscar(ListaModel l)
        {
            List<Medico> model = _restSip.GetMedicos(Convert.ToInt32(l.prestador), Convert.ToInt32(l.descripcion), l.isapre);
            return View("Resultado", model);
        }

        public ActionResult FormAgregar()
        {
            return View();
        }
        public ActionResult Agregar()
        {
            return View();
        }

        public ActionResult Eliminar(int rut)
        {
            _restSip.PostEliminarMedico(rut);
            return View("Index", new ListaModel());
        }

        public JsonResult GetInstituciones(int id)
        {
            List<SelectListItem> subCat = new List<SelectListItem>();

            subCat.Add(new SelectListItem
            {
                Text = "Seleccione el prestador",
                Value = "0"
            });

            #region Comentario
            //switch (id)
            //{
            //    case 1:
            //        subCat.Add(new SelectListItem { Text = "CLINICA UNIVERSIDAD DE LOS ANDES", Value = "11" });
            //        subCat.Add(new SelectListItem { Text = "NUEVA CLINICA CORDILLERA", Value = "13" });
            //        break;
            //    case 2:
            //        subCat.Add(new SelectListItem { Text = "IOPA INST. OFTALMOLOGICO", Value = "10" });
            //        subCat.Add(new SelectListItem { Text = "CLINICA OFTAL. KYDOFT ARAUCO", Value = "15" });
            //        break;
            //    case 3:
            //        subCat.Add(new SelectListItem { Text = "IOPA INST. OFTALMOLOGICO", Value = "10" });
            //        subCat.Add(new SelectListItem { Text = "CLINICA OFTAL. KYDOFT ARAUCO", Value = "15" });
            //        subCat.Add(new SelectListItem { Text = "CLINICA TABANCURA", Value = "8" });
            //        subCat.Add(new SelectListItem { Text = "CLINICA UNIVERSIDAD DE LOS ANDES", Value = "11" });
            //        break;
            //    case 4:
            //        subCat.Add(new SelectListItem { Text = "CLINICA TABANCURA", Value = "8" });
            //        subCat.Add(new SelectListItem { Text = "CLINICA UNIVERSIDAD DE LOS ANDES", Value = "11" });
            //        break;
            //    case 5:
            //        subCat.Add(new SelectListItem { Text = "CLINICA UNIVERSIDAD DE LOS ANDES", Value = "11" });
            //        break;
            //    case 6:
            //        subCat.Add(new SelectListItem { Text = "CLINICA UNIVERSIDAD DE LOS ANDES", Value = "11" });
            //        break;
            //    case 7:
            //        subCat.Add(new SelectListItem { Text = "CLINICA TABANCURA", Value = "8" });
            //        subCat.Add(new SelectListItem { Text = "CLINICA UNVIERSIDAD DE LOS ANDES", Value = "11" });
            //        break;
            //    case 8:
            //        subCat.Add(new SelectListItem { Text = "CLINICA UNIVERSIDAD DE LOS ANDES", Value = "11" });
            //        subCat.Add(new SelectListItem { Text = "NUEVA CLINICA CORDILLERA", Value = "13" });
            //        break;
            //    case 9:
            //        subCat.Add(new SelectListItem { Text = "CLINICA UNIVERSIDAD DE LOS ANDES", Value = "11" });
            //        subCat.Add(new SelectListItem { Text = "NUEVA CLINICA CORDILLERA", Value = "13" });
            //        break;
            //    case 10:
            //        subCat.Add(new SelectListItem { Text = "CLINICA INDISA", Value = "5" });
            //        subCat.Add(new SelectListItem { Text = "CLINICA UNIVERSIDAD DE LOS ANDES", Value = "11" });
            //        break;
            //    case 11:
            //        subCat.Add(new SelectListItem { Text = "CLINICA UNIVERSIDAD DE LOS ANDES", Value = "11" });
            //        subCat.Add(new SelectListItem { Text = "NUEVA CLINICA CORDILLERA", Value = "13" });
            //        break;
            //    case 12:
            //        subCat.Add(new SelectListItem { Text = "CLINICA TABANCURA", Value = "8" });
            //        subCat.Add(new SelectListItem { Text = "CLINICA UNIVERSIDAD DE LOS ANDES", Value = "11" });
            //        break;
            //    case 13:
            //        subCat.Add(new SelectListItem { Text = "CLINICA TABANCURA", Value = "8" });
            //        subCat.Add(new SelectListItem { Text = "CLINICA UNIVERSIDAD DE LOS ANDES", Value = "11" });
            //        break;
            //    case 14:
            //        subCat.Add(new SelectListItem { Text = "CLINICA TABANCURA", Value = "8" });
            //        subCat.Add(new SelectListItem { Text = "CLINICA UNIVERSIDAD DE LOS ANDES", Value = "11" });
            //        break;
            //    case 15:
            //        subCat.Add(new SelectListItem { Text = "CLINICA TABANCURA", Value = "8" });
            //        subCat.Add(new SelectListItem { Text = "CLINICA UNIVERSIDAD DE LOS ANDES", Value = "11" });
            //        break;
            //    case 16:
            //        subCat.Add(new SelectListItem { Text = "CLINICA TABANCURA", Value = "8" });
            //        subCat.Add(new SelectListItem { Text = "CLINICA UNIVERSIDAD DE LOS ANDES", Value = "11" });
            //        subCat.Add(new SelectListItem { Text = "NUEVA CLINICA CORDILLERA", Value = "13" });
            //        break;
            //    case 17:
            //        subCat.Add(new SelectListItem { Text = "CLINICA TABANCURA", Value = "8" });
            //        subCat.Add(new SelectListItem { Text = "CLINICA UNIVERSIDAD DE LOS ANDES", Value = "11" });
            //        subCat.Add(new SelectListItem { Text = "NUEVA CLINICA CORDILLERA", Value = "13" });
            //        break;
            //    case 18:
            //        subCat.Add(new SelectListItem { Text = "CLINICA TABANCURA", Value = "8" });
            //        subCat.Add(new SelectListItem { Text = "CLINICA UNIVERSIDAD DE LOS ANDES", Value = "11" });
            //        break;
            //    case 19:
            //        subCat.Add(new SelectListItem { Text = "CLINICA TABANCURA", Value = "8" });
            //        subCat.Add(new SelectListItem { Text = "CLINICA UNIVERSIDAD DE LOS ANDES", Value = "11" });
            //        subCat.Add(new SelectListItem { Text = "NUEVA CLINICA CORDILLERA", Value = "13" });
            //        break;
            //    case 20:
            //        subCat.Add(new SelectListItem { Text = "CLINICA TABANCURA", Value = "8" });
            //        subCat.Add(new SelectListItem { Text = "CLINICA UNIVERSIDAD DE LOS ANDES", Value = "11" });
            //        break;
            //    case 21:
            //        subCat.Add(new SelectListItem { Text = "CLINICA TABANCURA", Value = "8" });
            //        subCat.Add(new SelectListItem { Text = "CLINICA UNIVERSIDAD DE LOS ANDES", Value = "11" });
            //        break;
            //    case 25:
            //        subCat.Add(new SelectListItem { Text = "CLINICA TABANCURA", Value = "8" });
            //        subCat.Add(new SelectListItem { Text = "CLINICA UNIVERSIDAD DE LOS ANDES", Value = "11" });
            //        break;
            //    case 26:
            //        subCat.Add(new SelectListItem { Text = "CLINICA UNIVERSIDAD DE LOS ANDES", Value = "11" });
            //        break;
            //    case 27:
            //        subCat.Add(new SelectListItem { Text = "INST. OFTAL. PUERTA DEL SOL", Value = "12" });
            //        break;
            //    case 28:
            //        subCat.Add(new SelectListItem { Text = "CLINICA SOMNO - MEDICINA DEL SUEÑO", Value = "14" });
            //        break;
            //    case 29:
            //        subCat.Add(new SelectListItem { Text = "CLINICA TABANCURA", Value = "8" });
            //        break;


            //    default:
            //        break;
            //}
            #endregion

            switch (id)
            {
                case 1:
                    subCat.Add(new SelectListItem { Text = "CLINICA TABANCURA", Value = "8" });
                    subCat.Add(new SelectListItem { Text = "CLINICA AVANSALUD", Value = "9" });
                    break;
                case 2:
                    subCat.Add(new SelectListItem { Text = "CLINICA TABANCURA", Value = "8" });
                    subCat.Add(new SelectListItem { Text = "CLINICA LAS CONDES", Value = "1" });
                    subCat.Add(new SelectListItem { Text = "IOPA INST. OFTALMOLOGICO", Value = "10" });
                    subCat.Add(new SelectListItem { Text = "CLINICA OFTAL. KYDOFT ARAUCO", Value = "15" });
                    break;
                case 3:
                    subCat.Add(new SelectListItem { Text = "CLINICA DAVILA", Value = "3" });
                    subCat.Add(new SelectListItem { Text = "CLINCIA UC SAN CARLOS DE APOQUINDO", Value = "7" });
                    break;
                case 4:
                    subCat.Add(new SelectListItem { Text = "CLINICA DAVILA", Value = "3" });
                    subCat.Add(new SelectListItem { Text = "CLINICA LAS CONDES", Value = "1" });
                    subCat.Add(new SelectListItem { Text = "CLINICA INDISA", Value = "5" });
                    break;
                case 5:
                    subCat.Add(new SelectListItem { Text = "CLINICA LAS CONDES", Value = "1" });
                    subCat.Add(new SelectListItem { Text = "CLINICA DAVILA", Value = "3" });
                    subCat.Add(new SelectListItem { Text = "CLINICA TABANCURA", Value = "8" });
                    break;
                case 6:
                    subCat.Add(new SelectListItem { Text = "CLINICA AVANSALUD", Value = "9" });
                    break;
                case 7:
                    subCat.Add(new SelectListItem { Text = "CLINCIA UC SAN CARLOS DE APOQUINDO", Value = "7" });
                    break;
                case 8:
                    subCat.Add(new SelectListItem { Text = "CLINICA LAS CONDES", Value = "1" });
                    subCat.Add(new SelectListItem { Text = "CLINICA DAVILA", Value = "3" });
                    break;
                case 9:
                    subCat.Add(new SelectListItem { Text = "CLINICA LAS CONDES", Value = "1" });
                    subCat.Add(new SelectListItem { Text = "CLINICA DAVILA", Value = "3" });
                    break;
                case 10:
                    subCat.Add(new SelectListItem { Text = "CLINICA LAS CONDES", Value = "1" });
                    subCat.Add(new SelectListItem { Text = "CLINICA INDISA", Value = "5" });
                    break;
                case 11:
                    subCat.Add(new SelectListItem { Text = "CLINICA DAVILA", Value = "3" });
                    break;
                //case 12:
                    
                //    break;
                //case 13:
                    
                //    break;
                //case 14:
                    
                //    break;
                //case 15:
                    
                //    break;
                //case 16:
                    
                //    break;
                //case 17:
                    
                //    break;
                //case 18:
                    
                //    break;
                //case 19:
                    
                //    break;
                //case 20:
                    
                //    break;
                //case 21:
                    
                //    break;
                //case 25:
                    
                //    break;
                //case 26:
                    
                //    break;
                case 27:
                    subCat.Add(new SelectListItem { Text = "INST. OFTAL. PUERTA DEL SOL", Value = "12" });
                    break;
                //case 28:
                    
                //    break;
                //case 29:
                    
                //    break;


                default:
                    break;
            }

            return Json(new SelectList(subCat,
                            "Value", "Text"));
        }
    }
}
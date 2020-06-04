using Sip.Exceptions;
using Sip.Filters;
using Sip.Models.Contracts;
using Sip.Models.Dto;
using Sip.Resources.Messages;
using Sip.Utils;
using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Http;
using log4net;
using log4net.Config;

namespace Sip.Controllers
{
    /// <summary>
    /// Permite solicitar el beneficio cuenta segura o conocida para los afiliados, para ello cuenta con una
    /// serie de api's que devuelven infomación de alfiliado y sus cargas, entre otras características.
    /// </summary>
    /// 

    public class SipController : ApiController
    {
        private readonly ISipRepository _sipRepository;

        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(SipController));
        /// <summary>
        /// Constructor al que se le inyecta la interfaz IRepository.
        /// </summary>
        /// <param name="sipRepository">Run del prestador.</param>
        /// <returns>Información del afiliado.</returns>
        public SipController(ISipRepository sipRepository)
        {
            _sipRepository = sipRepository;
        }

        /// <summary>
        /// Devuelve la información de afiliado siempre y cuando éste tenga acceso al beneficio.
        /// </summary>
        /// <param name="run">Run del afiliado.</param>
        /// <returns>Información del afiliado.</returns>
        [HttpGet]
        [Route("api/afiliado/{run}")]
        public IHttpActionResult ObtenerAfiliado(int run)
        {
            try
            {
                var afiliado = _sipRepository.ObtenerDatosAfiliado(run);
                if (afiliado != null)
                {
                    return Ok(afiliado);
                }
                return NotFound();

            }
            catch (SipException)
            {
                return BadRequest(string.Format(ExceptionMessages.Ex_Afiliado, run));
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        /// <summary>
        /// Devuelve las prestaciones autorizadas para el plan de salud.
        /// </summary>
        /// <param name="plan">Plan de salud.</param>
        /// <param name="isapre">Isapre (B o T).</param>
        /// <returns>Lista de prestaciones autorizadas para el plan de salud.</returns>
        [HttpGet]
        [Route("api/prestacion/{isapre}/{*plan}")]
        public IHttpActionResult ObtenerPrestacionesPorPlan(string isapre,string plan )
        {
            try
            {
                var prestaciones = _sipRepository.ObtenerPrestaciones(plan, isapre);
                if (prestaciones == null)
                {
                    return NotFound();
                }
                return Ok(prestaciones);

            }
            catch (SipException)
            {
                return BadRequest(string.Format(ExceptionMessages.Ex_Prestcacion, plan, isapre));
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        /// <summary>
        /// Devuelve los prestadores asociados a la prestacion  y al plan de salud.
        /// </summary>
        /// <param name="plan">Plan de salud.</param>
        /// <param name="prestacion">Identificador de la prestación.</param>
        /// <param name="isapre">Isapre (B o T).</param>
        /// <returns>Lista de prestadores para la prestación y el copago para el afiliado.</returns>
        [HttpGet]
        [Route("api/prestador/{isapre}/{prestacion}/{*plan}")]
        public IHttpActionResult ObtenerPrestadoresPorPlanPrestacion( string isapre,string plan, int prestacion)
        {
            try
            {
                //var prestadores = _sipRepository.ObtenerPrestadores(plan,prestacion, isapre).Select(x=>x.COPAGO &&
                //    ).Where(x => x.COPAGO!=-1).ToList();

                var p = _sipRepository.ObtenerPrestadores(plan, prestacion, isapre);

                var prestadores = from prest in p
                                  where prest.COPAGO != -1
                                  select new
                                  {
                                      COPAGO = String.Format("{0:C0}", prest.COPAGO),
                                      prest.ISAP_CEMPRESA,
                                      prest.PRESTSIP_DIRECCION,
                                      prest.PRESTSIP_DIRWEB,
                                      prest.PRESTSIP_FINICIO_VIGENCIA,
                                      prest.PRESTSIP_FTERMINO_VIGENCIA,
                                      prest.PRESTSIP_ID,
                                      prest.PRESTSIP_TELEFONO,
                                      prest.PRTA_NOMBRE,
                                      prest.PRTA_NRUT,
                                      prest.TRAMO
                                  };
                           

                if (prestadores == null)
                {
                    return NotFound();
                }
                return Ok(prestadores);

                

            }
            catch (SipException)
            {
                return BadRequest(string.Format(ExceptionMessages.Ex_Prestador, plan,prestacion));
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }


        /// <summary>
        /// Devuelve los beneficiarios que tiene acceso a la prestación.
        /// </summary>
        /// <param name="run">Run del afiliado.</param>
        /// <param name="prestacion">Identificador de la prestación.</param>
        /// <returns>Lista de beneficiarios del afiliado.</returns>
        [HttpGet]
        [Route("api/beneficiario/{run}/{prestacion}")]
        public IHttpActionResult ObtenerBeneficiariosPorAfiliadoyPrestacion(int run, int prestacion)
        {
            try
            {
                var afiliado = new AfiliadoSip {Afiliado = _sipRepository.ObtenerDatosAfiliado(run)};


                if (afiliado.Afiliado != null)
                {
                    if (afiliado.Afiliado.TIENECOBERTURASIP.Equals("S"))
                    {
                        afiliado.Beneficiarios = _sipRepository.ObtenerBeneficiarios(prestacion, run, afiliado.Afiliado.ISAP_CEMPRESA);
                    }

                    return Ok(afiliado);

                }
                return NotFound();

            }
            catch (SipException)
            {
                return BadRequest(string.Format(ExceptionMessages.Ex_Beneficiario,run, prestacion));
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        /// <summary>
        /// Devuelve las condiciones de acceso a la prestación.
        /// </summary>
        /// <param name="prestacion">Identificador de la prestación.</param>
        /// <param name="isapre">Isapre (B o T).</param>
        /// <returns>Condiciones de acceso a la prestación.</returns>
        [HttpGet]
        [Route("api/condicion/{isapre}/{prestacion}")]
        public IHttpActionResult ObtenerCondicionesAcceso(string isapre, int prestacion )
        {
            try
            {
                var condiciones = _sipRepository.ObtenerCondicionesdeAcceso(prestacion, isapre);
                if (condiciones == null)
                {
                    return NotFound();
                }
                return Ok(condiciones);

            }
            catch (SipException)
            {
                return BadRequest(string.Format(ExceptionMessages.Ex_Condiciones, prestacion,isapre));
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        /// <summary>
        /// Devuelve el staff de médicos del prestador asocoados a la prestación
        /// </summary>
        /// <param name="isapre">Isapre (B o T).</param>
        /// <param name="prestacion">Identificador de la prestación.</param>
        /// <param name="prestador">Identificador del pretador.</param>
        /// <returns>Staff médico asociado a la prestación.</returns>
        [HttpGet]
        [Route("api/medico/{isapre}/{prestacion}/{prestador}")]
        public IHttpActionResult ObtenerStaffMedico(string isapre, int prestacion, int prestador )
        {
            try
            {
                var staff = _sipRepository.ObtenerStaffMedico(prestador,prestacion, isapre);
                if (staff == null)
                {
                    return NotFound();
                }
                return Ok(staff);

            }
            catch (SipException)
            {
                return BadRequest(string.Format(ExceptionMessages.EX_Staff,prestador, prestacion));
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }


        /// <summary>
        /// Crea un presupuesto para el beneficio SIP.
        /// </summary>
        /// <param name="sip">Objeto de tipo DatosSip.</param>
        /// <returns>Identificador del presupuesto.</returns>
        [HttpPost]
        [SecureResourceAttribute]
        [Route("api/sip/presupuesto")]
        public IHttpActionResult CreaPresupuesto([FromBody] DatosSip sip)
        {
            try
            {

                var identificadorSip =  _sipRepository.CreaPresupuesto(sip);

                return Ok(identificadorSip);

            }
            catch(SipException)
            {
                return BadRequest(string.Format(ExceptionMessages.Ex_CreaSip));

            }
            catch (Exception)
            {
                return InternalServerError();
            }

        }

        /// <summary>
        /// Crea una solicitid para el beneficio SIP.
        /// </summary>
        /// <param name="sip">Objeto de tipo DatosSip.</param>
        /// <returns>Identificador de la solicitud.</returns>
        [HttpPost]
        [SecureResourceAttribute]
        [Route("api/sip/solicitud")]
        public IHttpActionResult CreaSip([FromBody] DatosSip sip)
        {
            try
            {
                var identificadorSip = _sipRepository.CreaSip(sip);

                return Ok(identificadorSip);

            }
            catch (SipException)
            {
                return BadRequest(string.Format(ExceptionMessages.Ex_CreaSip));

            }
            catch (Exception)
            {
                return InternalServerError();
            }

        }

        /// <summary>
        /// Crea una solicitid para el beneficio SIP.
        /// </summary>
        /// <param name="id">Identificador del presupuesto.</param>
        /// <returns>datos del presupuesto.</returns>
        [HttpGet]
        [Route("api/sip/presupuesto/{id}/pdf")]
        public HttpResponseMessage ObtenerPresupuesto(int id)
        {
            try
            {

                var presupuesto = _sipRepository.ObtenerPresupuesto(id);

                if (presupuesto == null) return Request.CreateResponse(HttpStatusCode.NotFound);
                var presupuestoSip = new DtoPresupuestoSip
                {
                    Sip = presupuesto,
                    Prestadores = _sipRepository.ObtenerPrestadores(presupuesto.PLSA_CCOD, (int) presupuesto.PRESSIP_ID,
                        presupuesto.ISAP_CEMPRESA)
                };


                var archivo = Utilitarios.Presupuesto(presupuestoSip);

                var configPdf = new PdfParams
                {
                    Key = ConfigurationManager.AppSettings["expertpdfKey"],
                    Html = archivo.ToString()
                };
                var bytes = Utilitarios.GetBytesFromHtmlString(configPdf);

                //MemoryStream stream = new MemoryStream(bytes);

                HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
                result.Content = new ByteArrayContent(bytes);
                result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                {
                    FileName = "Presupuesto.pdf"
                };


                result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");

                return result;
            }
            catch (SipException)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, string.Format(ExceptionMessages.Ex_Presupuesto, id));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError,ex.Message);//InternalServerError();
            }


        }

        /// <summary>
        /// Pdf de una solicitid  SIP.
        /// </summary>
        /// <param name="id">Identificador del presupuesto.</param>
        /// <returns>Pdf.</returns>
        [HttpGet]
        [Route("api/sip/solicitud/{id}/pdf")]
        public HttpResponseMessage ObtenerSolicitud(int id)
        {
            try
            {
                var solicitud = _sipRepository.ObtenerSolicitud(id);

                if (solicitud == null) return Request.CreateResponse(HttpStatusCode.NotFound);
                var archivo = Utilitarios.Solicitud(solicitud);

                var configPdf = new PdfParams
                {
                    Key = ConfigurationManager.AppSettings["expertpdfKey"],
                    Html = archivo.ToString()
                };
                var bytes = Utilitarios.GetBytesFromHtmlString(configPdf);

                //MemoryStream stream = new MemoryStream(bytes);

                var result = new HttpResponseMessage(HttpStatusCode.OK);
                result.Content = new ByteArrayContent(bytes);
                result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                {
                    FileName = "Solicitud.pdf"
                };


                result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");

                return result;
            }
            catch (SipException)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, string.Format(ExceptionMessages.Ex_Presupuesto, id));
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);//InternalServerError();
            }


        }

        /// <summary>
        /// Envia copia de solicitud a prestador.
        /// </summary>
        /// <param name="id">Identificador del presupuesto.</param>
        /// <returns>Pdf.</returns>
        [HttpGet]
        [Route("api/sip/solicitud/{id}/mail")]
        public IHttpActionResult EnviarSolicitud(int id)
        {
            try
            {
                var solicitud = _sipRepository.ObtenerSolicitud(id);

                if (solicitud != null)
                {
                    var subjectMail = solicitud.ISAP_CEMPRESA =="T" ? "Solicitud beneficio cuenta segura":"Solicitud beneficio cuenta conocida";
                    var bodyMail = solicitud.ISAP_CEMPRESA =="T" ? "Estimado prestador, adjuntamos una nueva solicitud para beneficio cuenta segura":"Estimado prestador, adjuntamos una nueva solicitud para  beneficio cuenta conocida";

                    StringBuilder archivo = Utilitarios.CopiaPrestador(solicitud);

                    var configPdf = new PdfParams
                    {
                        Key = ConfigurationManager.AppSettings["expertpdfKey"],
                        Html = archivo.ToString()
                    };
                    var bytes = Utilitarios.GetBytesFromHtmlString(configPdf);

                    var stream = new MemoryStream(bytes);

                    Mail.File = stream;
                    Mail.To = Utilitarios.GetMailPrestador((int)solicitud.PRESTSIP_ID, solicitud.ISAP_CEMPRESA);
                    Mail.From = ConfigurationManager.AppSettings["mailFrom"];
                    Mail.Subject =subjectMail;
                    Mail.Body = bodyMail;
                    Mail.Send();


                    return Ok();
                }
                return BadRequest(string.Format(ExceptionMessages.Ex_Mail));
            }
            catch (SipException)
            {
                return BadRequest(string.Format(ExceptionMessages.Ex_Presupuesto, id));
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }


        }


        /// <summary>
        /// Pdf de una solicitid  SIP.
        /// </summary>
        /// <param name="id">Identificador del presupuesto.</param>
        /// <returns>Pdf.</returns>
        [HttpGet]
        [Route("api/sip/solicitud/copia/{id}/pdf")]
        public HttpResponseMessage ObtenerCopia(int id)
        {
            try
            {
                var solicitud = _sipRepository.ObtenerSolicitud(id);
                Log.Debug(string.Format("Ejecuta ObtenerSolicitud(id) (ID: {0})", id));
                if (solicitud == null) return Request.CreateResponse(HttpStatusCode.NotFound);
                var archivo = Utilitarios.Solicitud(solicitud);
                Log.Debug(string.Format("Ejecuta Utilitarios.Solicitud(solicitud (ID: {0})", id));

                var configPdf = new PdfParams
                {
                    Key = ConfigurationManager.AppSettings["expertpdfKey"],
                    Html = archivo.ToString()
                };
                var bytes = Utilitarios.GetBytesFromHtmlString(configPdf);

                Log.Debug(string.Format("Ejecuta Utilitarios.GetBytesFromHtmlString(configPdf) (ID: {0})", id));

                //Marca de agua
                var texto=ConfigurationManager.AppSettings["texto_watermark"];
                bytes = Utilitarios.WaterMark(bytes, string.Format(texto, DateTime.Now));

                Log.Debug(string.Format("Ejecuta Utilitarios.WaterMark(bytes, string.Format(texto, DateTime.Now) (ID: {0})", id));

                //MemoryStream stream = new MemoryStream(bytes);

                var result = new HttpResponseMessage(HttpStatusCode.OK);
                result.Content = new ByteArrayContent(bytes);
                result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                {
                    FileName = "Solicitud.pdf"
                };

                result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");

                Log.Debug(string.Format("Retorna result del PDF (ID: {0})", id));

                return result;
            }
            catch (SipException ex)
            {
                Log.Debug(string.Format(ExceptionMessages.Ex_Presupuesto, id));
                Log.Debug(string.Format("{0} {1} {2}", ex.Message, ex.InnerException, ex.StackTrace));
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, string.Format(ExceptionMessages.Ex_Presupuesto, id));
            }
            catch (Exception ex)
            {
                Log.Debug(string.Format(ExceptionMessages.Ex_Presupuesto, id));
                Log.Debug(string.Format("{0} {1} {2} {3}", HttpStatusCode.InternalServerError, ex.Message, ex.InnerException, ex.StackTrace));

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);//InternalServerError();
            }
        }
    }
}

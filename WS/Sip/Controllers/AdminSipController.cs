using Sip.Filters;
using Sip.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Sip.Controllers
{
    public class AdminSipController : ApiController
    {
        private IAdminSipRepository _sipRepository;

        public AdminSipController(IAdminSipRepository sipRepository)
        {
            this._sipRepository = sipRepository;
        }

        #region Get
        [HttpGet]
        [SecureResourceAttribute]
        [Route("api/GetPrestaciones/{isapre}")]
        public IHttpActionResult GetPrestaciones(string isapre)
        {
            try
            {
                var prestaciones = _sipRepository.obtenerPrestaciones(isapre);

                if (prestaciones != null)
                {
                    return Ok(prestaciones);
                }
                return NotFound();

            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpGet]
        [SecureResourceAttribute]
        [Route("api/GetPrestadores/{isapre}")]
        public IHttpActionResult GetPrestadores(string isapre)
        {
            try
            {
                var prestadores = _sipRepository.obtenerPrestadores(isapre);

                if (prestadores != null)
                {
                    return Ok(prestadores);
                }
                return NotFound();

            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpGet]
        [SecureResourceAttribute]
        [Route("api/GetSolicitudes/{accion}/{var_aux}")]
        public IHttpActionResult GetSolicitudes(string accion, int var_aux)
        {
            try
            {
                var solicitudes = _sipRepository.obtenerSolicitudes(accion, var_aux);

                if (solicitudes != null)
                {
                    return Ok(solicitudes);
                }
                return NotFound();

            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpGet]
        [SecureResourceAttribute]
        [Route("api/GetMedicos/{idprestacion}/{idprestador}/{isapre}")]
        public IHttpActionResult GetMedicos(int idprestacion, int idprestador, string isapre)
        {
            try
            {
                var medicos = _sipRepository.obtenerMedicos(idprestacion, idprestador, isapre);

                if (medicos != null)
                {
                    return Ok(medicos);
                }
                return NotFound();

            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpGet]
        [SecureResourceAttribute]
        [Route("api/GetRestricciones/{codplan}/{isapre}")]
        public IHttpActionResult GetRestricciones(string codplan, string isapre)
        {
            try
            {
                var rest = _sipRepository.obtenerRestricciones(codplan, isapre);

                if (rest != null)
                {
                    return Ok(rest);
                }
                return NotFound();

            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpGet]
        [SecureResourceAttribute]
        [Route("api/ListarPrestaciones/")]
        public IHttpActionResult listarPrestaciones()
        {
            try
            {
                var prest = _sipRepository.listarPrestaciones();

                if (prest != null)
                {
                    return Ok(prest);
                }
                return NotFound();

            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
        #endregion

        #region Post
        [HttpPost]
        [SecureResourceAttribute]
        [Route("api/PostAgregarPrestacion/{isapre}/{codpaquete}/{descripcion}")]
        public IHttpActionResult PostAgregarPrestacion(string isapre, int codpaquete, string descripcion)
        {
            try
            {
                var prestacion = _sipRepository.agregarPrestacion(isapre, codpaquete, descripcion);

                if (prestacion == true)
                {
                    return Ok(prestacion);
                }
                return NotFound();

            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        [SecureResourceAttribute]
        [Route("api/PostAgregarPrestador/{isapre}/{rut}/{nombre}/{rutinstitucion}/{secuencia}/{estado}/{fechaInicio}/{observacion}/{direccion}/{telefono}/{sitioweb}")]
        public IHttpActionResult PostAgregarPrestador(string isapre, int rut, string nombre,
            int rutinstitucion, int secuencia, string estado, DateTime fechaInicio, string observacion,
            string direccion, string telefono, string sitioweb)
        {
            try
            {
                var prestacion = _sipRepository.agregarPrestador(isapre, rut, nombre, rutinstitucion,
                        secuencia, estado, fechaInicio, observacion, direccion, telefono, sitioweb);

                if (prestacion == true)
                {
                    return Ok(prestacion);
                }
                return NotFound();

            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        [SecureResourceAttribute]
        [Route("api/PostAgregarMedico/{rut}/{nombre}/{idprest}/{idpress}/{isapre}")]
        public IHttpActionResult PostAgregarMedico(int rut, string nombre, int idprest, int idpress, string isapre)
        {
            try
            {
                var medico = _sipRepository.agregarMedico(rut, nombre, idprest, idpress, isapre);

                if (medico == true)
                {
                    return Ok(medico);
                }
                return NotFound();

            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        [SecureResourceAttribute]
        [Route("api/PostAgregarCondicionPrestacion/{idpress}/{condicion}/{funcion}/{tipo}/{estado}/{fechaInicio}/{isapre}")]
        public IHttpActionResult PostAgregarCondicionPrestacion(int idpress, string condicion, string funcion,
            string tipo, string estado, DateTime fechaInicio, string isapre)
        {
            try
            {
                var condicionprest = _sipRepository.agregarCondicionPrestacion(idpress, condicion, funcion, tipo, estado, fechaInicio, isapre);

                if (condicionprest == true)
                {
                    return Ok(condicionprest);
                }
                return NotFound();

            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        [SecureResourceAttribute]
        [Route("api/PostTerminarVigenciaPrestacion/{codpaquete}")]
        public IHttpActionResult PostTerminarVigenciaPrestacion(int codpaquete)
        {
            try
            {
                var termvigencia = _sipRepository.terminarVigenciaPrestacion(codpaquete);

                if (termvigencia == true)
                {
                    return Ok(termvigencia);
                }
                return NotFound();

            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        [SecureResourceAttribute]
        [Route("api/PostEliminarPrestador/{isapre}/{rut}")]
        public IHttpActionResult PostEliminarPrestador(string isapre, int rut)
        {
            try
            {
                var elimprest = _sipRepository.eliminarPrestador(isapre, rut);

                if (elimprest == true)
                {
                    return Ok(elimprest);
                }
                return NotFound();

            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        [SecureResourceAttribute]
        [Route("api/PostEditarPrestacion/{codpaqueteanterior}/{codpaquetenuevo}/{isapre}/{descripcion}")]
        public IHttpActionResult PostEditarPrestador(int codpaqueteanterior, string isapre, int codpaquetenuevo, string descripcion)
        {
            try
            {
                var editprest = _sipRepository.editarPrestador(codpaqueteanterior, isapre, codpaquetenuevo, descripcion);


                if (editprest == true)
                {
                    return Ok(editprest);
                }
                return NotFound();

            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        [SecureResourceAttribute]
        [Route("api/PostAgregarRestriccionExcel/{idprestacion}/{codplan}/{isapre}")]
        public IHttpActionResult PostAgregarRestriccionExcel(int idprestacion, string codplan, string isapre)
        {
            try
            {
                var aux_isapre = "";

                if (isapre == "banmedica" || isapre == "B")
                {
                    aux_isapre = "B";
                }
                else if (isapre == "vidatres" || isapre == "T")
                {
                    aux_isapre = "T";
                }

                var excel = _sipRepository.agregarRestriccionExcel(idprestacion, codplan, aux_isapre);

                if (excel == true)
                {
                    return Ok(excel);
                }
                return NotFound();

            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        [SecureResourceAttribute]
        [Route("api/PostEliminarRestriccion/{codplan}/{isapre}")]
        public IHttpActionResult PostEliminarRestriccion(string codplan, string isapre)
        {
            try
            {

                var elimprest = _sipRepository.eliminarRestriccion(codplan, isapre);

                if (elimprest == true)
                {
                    return Ok(elimprest);
                }
                return NotFound();

            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        [SecureResourceAttribute]
        [Route("api/PostEliminarMedico/{rut}")]
        public IHttpActionResult PostEliminarMedico(int rut)
        {
            try
            {
                var elimprest = _sipRepository.eliminarMedico(rut);

                if (elimprest == true)
                {
                    return Ok(elimprest);
                }
                return NotFound();

            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        #endregion
    }
}
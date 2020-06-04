using WebAdminSIP.Models.DTO;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Script.Serialization;
using WebAdminSIP.Models.DTO.ViewModel;

namespace WebAdminSIP.Models.ApiRest
{
    public class IngresosRest
    {

        #region Variables y Constructor
        public string usuario { get; set; }
        public string contrasena { get; set; }
        public string urlrest { get; set; }

        // Pasa las credenciales para poder conectarse al sistema
        public IngresosRest()
        {
            urlrest = Convert.ToString(ConfigurationManager.AppSettings["RestApiIngresos"]);
            usuario = Convert.ToString(ConfigurationManager.AppSettings["UserIngresos"]);
            contrasena = Convert.ToString(ConfigurationManager.AppSettings["ContrasenaIngresos"]);
        }
        #endregion

        #region Gets
        public List<Prestacion> GetPrestacionesB()
        {

            // Obtiene el link más los parametros
            var parametros = string.Format("/GetPrestaciones/{0}/", "banmedica");
            JArray stuff = Utils.getServiceRest(urlrest, parametros, usuario, contrasena);

            var prestacionList = new List<Prestacion>();

            if (stuff.Count > 0)
            {
                for (var i = 0; i < stuff.Count; i++)
                {
                    var pr = new Prestacion();

                    // Si stuff[i]["nombre"] no es nulo hacer la conversión
                    // La variable dentro del stuff hace referencia a la clase del webservice
                    pr.codPaquete = stuff[i]["codPaquete"] != null ? Convert.ToInt32(stuff[i]["codPaquete"].ToString()) : 0;
                    pr.descripcion = stuff[i]["descripcion"] != null ? stuff[i]["descripcion"].ToString() : string.Empty;
                    pr.estado = stuff[i]["estado"] != null ? stuff[i]["estado"].ToString() : string.Empty;
                    pr.inicioVigencia = stuff[i]["fechaInicio"] != null ? Convert.ToDateTime(stuff[i]["fechaInicio"].ToString()) : DateTime.Now;
                    pr.terminoVigencia = stuff[i]["fechaTermino"] != null ? Convert.ToDateTime(stuff[i]["fechaTermino"].ToString()) : DateTime.Now;
                    pr.isapre = stuff[i]["isapre"] != null ? stuff[i]["isapre"].ToString() : string.Empty;
                    
                    prestacionList.Add(pr);
                }
            }

            return prestacionList;
        }

        public List<Prestacion> GetPrestacionesT()
        {

            // Obtiene el link más los parametros
            var parametros = string.Format("/GetPrestaciones/{0}/", "vidatres");
            JArray stuff = Utils.getServiceRest(urlrest, parametros, usuario, contrasena);

            var prestacionList = new List<Prestacion>();

            if (stuff.Count > 0)
            {
                for (var i = 0; i < stuff.Count; i++)
                {
                    var pr = new Prestacion();

                    // Si stuff[i]["nombre"] no es nulo hacer la conversión
                    // La variable dentro del stuff hace referencia a la clase del webservice
                    pr.codPaquete = stuff[i]["codPaquete"] != null ? Convert.ToInt32(stuff[i]["codPaquete"].ToString()) : 0;
                    pr.descripcion = stuff[i]["descripcion"] != null ? stuff[i]["descripcion"].ToString() : string.Empty;
                    pr.estado = stuff[i]["estado"] != null ? stuff[i]["estado"].ToString() : string.Empty;
                    pr.inicioVigencia = stuff[i]["fechaInicio"] != null ? Convert.ToDateTime(stuff[i]["fechaInicio"].ToString()) : DateTime.Now;
                    pr.terminoVigencia = stuff[i]["fechaTermino"] != null ? Convert.ToDateTime(stuff[i]["fechaTermino"].ToString()) : DateTime.Now;
                    pr.isapre = stuff[i]["isapre"] != null ? stuff[i]["isapre"].ToString() : string.Empty;

                    prestacionList.Add(pr);
                }
            }

            return prestacionList;
        }

        public List<Prestador> GetPrestadoresB()
        {

            // Obtiene el link más los parametros
            var parametros = string.Format("/GetPrestadores/{0}/", "banmedica");
            JArray stuff = Utils.getServiceRest(urlrest, parametros, usuario, contrasena);

            var prestadorList = new List<Prestador>();

            if (stuff.Count > 0)
            {
                for (var i = 0; i < stuff.Count; i++)
                {
                    var pr = new Prestador();


                    // Si stuff[i]["nombre"] no es nulo hacer la conversión
                    // La variable dentro del stuff hace referencia a la clase del webservice
                    pr.rut = stuff[i]["rut"] != null ? Convert.ToInt32(stuff[i]["rut"].ToString()) : 0;
                    pr.nombre = stuff[i]["nombre"] != null ? stuff[i]["nombre"].ToString() : string.Empty;
                    pr.isapre = stuff[i]["isapre"] != null ? stuff[i]["isapre"].ToString() : string.Empty;
                    pr.institucion = stuff[i]["rutInstitucion"] != null ? Convert.ToInt32(stuff[i]["rutInstitucion"].ToString()) : 0;
                    pr.secuencia = stuff[i]["secuencia"] != null ? Convert.ToInt32(stuff[i]["secuencia"].ToString()) : 0;

                    prestadorList.Add(pr);
                }
            }

            return prestadorList;
        }

        public List<Prestador> GetPrestadoresT()
        {

            // Obtiene el link más los parametros
            var parametros = string.Format("/GetPrestadores/{0}/", "vidatres");
            JArray stuff = Utils.getServiceRest(urlrest, parametros, usuario, contrasena);

            var prestadorList = new List<Prestador>();

            if (stuff.Count > 0)
            {
                for (var i = 0; i < stuff.Count; i++)
                {
                    var pr = new Prestador();


                    // Si stuff[i]["nombre"] no es nulo hacer la conversión
                    // La variable dentro del stuff hace referencia a la clase del webservice
                    pr.rut = stuff[i]["rut"] != null ? Convert.ToInt32(stuff[i]["rut"].ToString()) : 0;
                    pr.nombre = stuff[i]["nombre"] != null ? stuff[i]["nombre"].ToString() : string.Empty;
                    pr.isapre = stuff[i]["isapre"] != null ? stuff[i]["isapre"].ToString() : string.Empty;
                    pr.institucion = stuff[i]["rutInstitucion"] != null ? Convert.ToInt32(stuff[i]["rutInstitucion"].ToString()) : 0;
                    pr.secuencia = stuff[i]["secuencia"] != null ? Convert.ToInt32(stuff[i]["secuencia"].ToString()) : 0;

                    prestadorList.Add(pr);
                }
            }

            return prestadorList;
        }

        public List<SolicitudViewModel> GetSolicitudes(string accion, string var_aux)
        {

            // Obtiene el link más los parametros
            var parametros = string.Format("/GetSolicitudes/{0}/{1}", accion, var_aux);
            JArray stuff = Utils.getServiceRest(urlrest, parametros, usuario, contrasena);

            var solicitudList = new List<SolicitudViewModel>();

            if (stuff.Count > 0)
            {
                for (var i = 0; i < stuff.Count; i++)
                {
                    var pr = new SolicitudViewModel();

                    // Si stuff[i]["nombre"] no es nulo hacer la conversión
                    // La variable dentro del stuff hace referencia a la clase del webservice
                    pr.id = stuff[i]["id"] != null ? Convert.ToInt32(stuff[i]["id"].ToString()) : 0;
                    pr.prestacion = stuff[i]["descripcionPrestacion"] != null ? stuff[i]["descripcionPrestacion"].ToString() : string.Empty;
                    pr.isapre = stuff[i]["isapre"] != null ? stuff[i]["isapre"].ToString() : string.Empty;
                    pr.prestador = stuff[i]["nombrePrestador"] != null ? stuff[i]["nombrePrestador"].ToString() : string.Empty;
                    pr.afiliado = stuff[i]["rutNombreAfiliado"] != null ? stuff[i]["rutNombreAfiliado"].ToString() : string.Empty;
                    pr.estado = stuff[i]["estado"] != null ? stuff[i]["estado"].ToString() : string.Empty;

                    solicitudList.Add(pr);
                }
            }

            return solicitudList;
        }

        public List<Restriccion> GetRestricciones(string codplan, string isapre)
        {

            // Obtiene el link más los parametros
            var parametros = string.Format("/GetRestricciones/{0}/{1}", codplan, isapre);
            JArray stuff = Utils.getServiceRest(urlrest, parametros, usuario, contrasena);

            var restList = new List<Restriccion>();

            if (stuff.Count > 0)
            {
                for (var i = 0; i < stuff.Count; i++)
                {
                    var re = new Restriccion();

                    // Si stuff[i]["nombre"] no es nulo hacer la conversión
                    // La variable dentro del stuff hace referencia a la clase del webservice

                    re.codplan = stuff[i]["codplan"] != null ? stuff[i]["codplan"].ToString() : string.Empty;
                    re.idprestacion = stuff[i]["idprestacion"] != null ? Convert.ToInt32(stuff[i]["idprestacion"].ToString()) : 0;
                    re.isapre = stuff[i]["isapre"] != null ? stuff[i]["isapre"].ToString() : string.Empty;

                    restList.Add(re);
                }
            }

            return restList;
        }

        public List<Prestacion> ListarPrestaciones()
        {

            // Obtiene el link más los parametros
            var parametros = string.Format("/ListarPrestaciones/");
            JArray stuff = Utils.getServiceRest(urlrest, parametros, usuario, contrasena);

            var restList = new List<Prestacion>();

            if (stuff.Count > 0)
            {
                for (var i = 0; i < stuff.Count; i++)
                {
                    var pr = new Prestacion();

                    // Si stuff[i]["nombre"] no es nulo hacer la conversión
                    // La variable dentro del stuff hace referencia a la clase del webservice
                    pr.idprestacion = stuff[i]["idprestacion"] != null ? Convert.ToInt32(stuff[i]["idprestacion"].ToString()) : 0;
                    pr.descripcion = stuff[i]["descripcion"] != null ? stuff[i]["descripcion"].ToString() : string.Empty;

                    restList.Add(pr);
                }
            }

            return restList;
        }

        public List<Medico> GetMedicos(int idprestador, int idprestacion, string isapre)
        {

            // Obtiene el link más los parametros
            var parametros = string.Format("/GetMedicos/{0}/{1}/{2}", idprestacion, idprestador, isapre);
            JArray stuff = Utils.getServiceRest(urlrest, parametros, usuario, contrasena);

            var restList = new List<Medico>();

            if (stuff.Count > 0)
            {
                for (var i = 0; i < stuff.Count; i++)
                {
                    var re = new Medico();

                    // Si stuff[i]["nombre"] no es nulo hacer la conversión
                    // La variable dentro del stuff hace referencia a la clase del webservice

                    re.rut = stuff[i]["rut"] != null ? stuff[i]["rut"].ToString() : string.Empty;
                    re.nombre = stuff[i]["nombre"] != null ? stuff[i]["nombre"].ToString() : string.Empty;

                    restList.Add(re);
                }
            }

            return restList;
        }
        #endregion

        #region Posts

        public bool PostTerminarVigencia(int codpaquete)
        {
            var parametros = string.Format("/PostTerminarVigenciaPrestacion/{0}", codpaquete);
            bool ok = Utils.postServiceRest(urlrest, parametros, usuario, contrasena);

            return ok;
        }
        public bool PostEliminarPrestador(int rut, string isapre)
        {
            var parametros = string.Format("/PostEliminarPrestador/{0}/{1}", isapre, rut);
            bool ok = Utils.postServiceRest(urlrest, parametros, usuario, contrasena);

            return ok;
        }

        public bool PostEditarPrestacion(int codpaqueteanterior, string isapre, int codpaquetenuevo, string descripcion)
        {
            var parametros = string.Format("/PostEditarPrestacion/{0}/{1}/{2}/{3}", codpaqueteanterior, codpaquetenuevo, isapre, descripcion);
            bool ok = Utils.postServiceRest(urlrest, parametros, usuario, contrasena);

            return ok;
        }

        public bool PostAgregarPrestacion(string isapre, int codpaquete, string descripcion)
        {
            var parametros = string.Format("/PostAgregarPrestacion/{0}/{1}/{2}", isapre, codpaquete, descripcion);
            bool ok = Utils.postServiceRest(urlrest, parametros, usuario, contrasena);

            return ok;
        }

        public bool PostAgregarRestriccionExcel(int idprestacion, string codplan, string isapre)
        {
            var parametros = string.Format("/PostAgregarRestriccionExcel/{0}/{1}/{2}", idprestacion, codplan, isapre);
            bool ok = Utils.postServiceRest(urlrest, parametros, usuario, contrasena);

            return ok;
        }

        public bool PostEliminarRestriccion(string codplan, string isapre)
        {
            var parametros = string.Format("/PostEliminarRestriccion/{0}/{1}", codplan, isapre);
            bool ok = Utils.postServiceRest(urlrest, parametros, usuario, contrasena);

            return ok;
        }

        public bool PostEliminarMedico(int rut)
        {
            var parametros = string.Format("/PostEliminarMedico/{0}/", rut);
            bool ok = Utils.postServiceRest(urlrest, parametros, usuario, contrasena);

            return ok;
        }

        #endregion

    }
}
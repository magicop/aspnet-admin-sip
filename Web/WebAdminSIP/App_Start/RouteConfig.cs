using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebAdminSIP
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            #region Prestacion
            routes.MapRoute(
                name: "PrestacionB",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Prestacion", action = "Banmedica", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "PrestacionVT",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Prestacion", action = "VidaTres", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "AgregarPrestacion",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Prestacion", action = "Agregar", id = UrlParameter.Optional }
            );
            #endregion


            #region Prestador
            routes.MapRoute(
                name: "PrestadorB",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Prestador", action = "Banmedica", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "PrestadorVT",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Prestador", action = "VidaTres", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "EliminarPrestador",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Prestador", action = "Eliminar", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "FormAgregarPrestador",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Prestador", action = "FormAgregar", id = UrlParameter.Optional }
            );

            #endregion

            #region Solicitud
            routes.MapRoute(
                name: "SolicitudFR",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Solicitud", action = "FormRut", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "SolicitudFI",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Solicitud", action = "FormId", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "SolicitudR",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Solicitud", action = "PorRut", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "SolicitudI",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Solicitud", action = "PorId", id = UrlParameter.Optional }
            );
            #endregion

            #region Restriccion
            routes.MapRoute(
                name: "RestriccionB",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Restriccion", action = "Banmedica", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "RestriccionVT",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Restriccion", action = "VidaTres", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "AgregarRestriccion",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Restriccion", action = "FormAgregar", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "AgregarRestriccion2",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Restriccion", action = "Agregar", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "AgregarRestriccionExcel",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Restriccion", action = "AgregarExcel", id = UrlParameter.Optional }
            );
            #endregion

            #region Staff
            routes.MapRoute(
                name: "FormAgregarMedico",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Staff", action = "FormAgregar", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "AgregarMedico",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Staff", action = "Agregar", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "EliminarMedico",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Staff", action = "Eliminar", id = UrlParameter.Optional }
            );
            #endregion

        }
    }
}

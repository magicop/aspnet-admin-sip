using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Sip.Filters
{
    public class SecureResourceAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var authorizeHeader = actionContext.Request.Headers.Authorization;
            if (authorizeHeader != null
                && authorizeHeader.Scheme.Equals("basic", StringComparison.OrdinalIgnoreCase)
                && String.IsNullOrEmpty(authorizeHeader.Parameter) == false)
            {
                var encoding = Encoding.GetEncoding("ISO-8859-1");
                var credintials = encoding.GetString(
                                   Convert.FromBase64String(authorizeHeader.Parameter));
                string username = credintials.Split(':')[0];
                string password = credintials.Split(':')[1];
                string roleOfUser = string.Empty;
                // ActivityBAL bal = new ActivityBAL();
                if (IsValid(username, password))
                {
                    var principal = new GenericPrincipal((new GenericIdentity(username)),
                                                                (new[] { roleOfUser }));
                    Thread.CurrentPrincipal = principal;
                    return;
                }
            }
            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);

            actionContext.Response.Content = new StringContent("Usuario o clave no válido");
        }

        private bool IsValid(string user, string pass)
        {
            string _user = ConfigurationManager.AppSettings["user"].ToString();
            string _pwd = ConfigurationManager.AppSettings["pwd"].ToString();

            if (user.Equals(_user) && pass.Equals(_pwd))
                return true;

            return false;


        }
    }
}
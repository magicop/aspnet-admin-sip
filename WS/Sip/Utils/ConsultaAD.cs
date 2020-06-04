using System;
using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;

namespace Sip.Utils
{
    public  class ConsultaAD
    {
        private DirectorySearcher _dirSearch;
        private const string FiltroPersonas = "(&(&(objectCategory=Person)(objectClass=User)){0})";

        public PropertyCollection ObtenerEmpleadoRun(string run)
        {
            return ObtenerEmpleadoFiltro(string.Format("(employeeID={0})", run));
        }    

        private PropertyCollection ObtenerEmpleadoFiltro(string filtro)
        {

            _dirSearch = new DirectorySearcher(new DirectoryEntry("LDAP://" + GetSystemDomain()))
            {
                SearchScope = SearchScope.Subtree,
                ServerTimeLimit = TimeSpan.FromSeconds(90),
                Sort = new SortOption("cn", SortDirection.Ascending)
            };

            _dirSearch.Filter = string.Format(FiltroPersonas, filtro);
            var userObject = _dirSearch.FindOne();
            return userObject != null ? userObject.GetDirectoryEntry().Properties : null;
        }

        private string GetSystemDomain()
        {
            try
            {
                return Domain.GetComputerDomain().ToString().ToLower();
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

    }
}
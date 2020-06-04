using Sip.Models.Entities;
using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Web;

namespace Sip.Models.Dto
{
    public class AfiliadoSip
    {
        public V_AFILIADOSIP Afiliado { get; set; }
        public ICollection<Beneficiario> Beneficiarios { get; set; } 

        public AfiliadoSip()
        {
            this.Afiliado = new V_AFILIADOSIP();
            this.Beneficiarios = new List<Beneficiario>();
        }
    }

    public class DatosSip
    {
        public int RunAfiliado {get;set;}
        public int RunBeneficiario {get;set;}
        public int PrestacionID{get;set;}
        public int PrestadorID{get;set;}
        public string Canal {get;set;}
        public string Isapre{get;set;}
        public int RunEjecutivo{get;set;}
        public string Agencia {get;set;}
        public string PlanSalud{get;set;}
        public string TramoSip { get; set; }
    }

    public class DtoPresupuestoSip
    {
        public Entities.PresupuestoSip Sip { get; set; }
        public ICollection<Entities.Prestador> Prestadores { get; set; }
    }

    public class Empleado
    {
        public Empleado() { }

        public Empleado(PropertyCollection infoUser)
        {
            if (infoUser == null) return;
            Usuario = infoUser.Contains("sAMAccountName") ? infoUser["sAMAccountName"].Value.ToString() : null;
            Nombre = infoUser.Contains("givenName") ? infoUser["givenName"].Value.ToString() : null;
            Apellidos = infoUser.Contains("sn") ? infoUser["sn"].Value.ToString() : null;
            Run = infoUser.Contains("employeeID") ? infoUser["employeeID"].Value.ToString() : null;
            Email = infoUser.Contains("mail") ? infoUser["mail"].Value.ToString() : null;
            Telefono = infoUser.Contains("telephoneNumber") ? infoUser["telephoneNumber"].Value.ToString() : null;
            Cargo = infoUser.Contains("title") ? infoUser["title"].Value.ToString() : null;
            Area = infoUser.Contains("department") ? infoUser["department"].Value.ToString() : null;
            Empresa = infoUser.Contains("company") ? infoUser["company"].Value.ToString() : null;
            MailPersonal = infoUser.Contains("otherMailbox") ? infoUser["otherMailbox"].Value.ToString() : null;
            Movil = infoUser.Contains("mobile") ? infoUser["mobile"].Value.ToString() : null;
        }
        public string Run { get; set; }
        public string Usuario { get; set; }
        public string Email { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }
        public string Cargo { get; set; }
        public string Area { get; set; }
        public string Empresa { get; set; }
        public string MailPersonal { get; set; }
        public string Movil { get; set; }
        public override string ToString()
        {
            return string.Format("Empleado: [Run: {0}, Usuario: {1}, Nombre: {2}, Email: {3}]", Run, Usuario, Nombre, Email);
        }
    }

}
﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sip.Models.Entities
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class SipEntities : DbContext
    {
        public SipEntities()
            : base("name=SipEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<V_AFILIADOSIP> V_AFILIADOSIP { get; set; }
        public virtual DbSet<MAIL_PRESTADOR_SIP> MAIL_PRESTADOR_SIP { get; set; }
    
        public virtual ObjectResult<Prestacion> PKG_SIPNET_OBTENER_PRESTACIONES(string pR_PLAN, string pR_ISAPRE)
        {
            var pR_PLANParameter = pR_PLAN != null ?
                new ObjectParameter("PR_PLAN", pR_PLAN) :
                new ObjectParameter("PR_PLAN", typeof(string));
    
            var pR_ISAPREParameter = pR_ISAPRE != null ?
                new ObjectParameter("PR_ISAPRE", pR_ISAPRE) :
                new ObjectParameter("PR_ISAPRE", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Prestacion>("PKG_SIPNET_OBTENER_PRESTACIONES", pR_PLANParameter, pR_ISAPREParameter);
        }
    
        public virtual ObjectResult<Prestador> PKG_SIPNET_OBTENER_PRESTADORES(string pR_PLAN, Nullable<decimal> pR_PRESSID, string pR_ISAPRE)
        {
            var pR_PLANParameter = pR_PLAN != null ?
                new ObjectParameter("PR_PLAN", pR_PLAN) :
                new ObjectParameter("PR_PLAN", typeof(string));
    
            var pR_PRESSIDParameter = pR_PRESSID.HasValue ?
                new ObjectParameter("PR_PRESSID", pR_PRESSID) :
                new ObjectParameter("PR_PRESSID", typeof(decimal));
    
            var pR_ISAPREParameter = pR_ISAPRE != null ?
                new ObjectParameter("PR_ISAPRE", pR_ISAPRE) :
                new ObjectParameter("PR_ISAPRE", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Prestador>("PKG_SIPNET_OBTENER_PRESTADORES", pR_PLANParameter, pR_PRESSIDParameter, pR_ISAPREParameter);
        }
    
        public virtual ObjectResult<Condicion> PKG_SIPNET_OBTENER_CONDICIONES(Nullable<decimal> pR_PRESSID, string pR_ISAPRE)
        {
            var pR_PRESSIDParameter = pR_PRESSID.HasValue ?
                new ObjectParameter("PR_PRESSID", pR_PRESSID) :
                new ObjectParameter("PR_PRESSID", typeof(decimal));
    
            var pR_ISAPREParameter = pR_ISAPRE != null ?
                new ObjectParameter("PR_ISAPRE", pR_ISAPRE) :
                new ObjectParameter("PR_ISAPRE", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Condicion>("PKG_SIPNET_OBTENER_CONDICIONES", pR_PRESSIDParameter, pR_ISAPREParameter);
        }
    
        public virtual int PKG_SIPNET_SP_GRABA_PREVIEW(Nullable<decimal> p_AFILRUT, Nullable<decimal> p_CARGRUT, Nullable<decimal> p_PRESSID, Nullable<decimal> p_PRESTID, string p_CANAL, string p_ISAPRE, Nullable<decimal> p_EJECRUT, string p_AGENCIA, string p_PLANSALUD, string p_TRAMO_SIP, ObjectParameter p_SOLID)
        {
            var p_AFILRUTParameter = p_AFILRUT.HasValue ?
                new ObjectParameter("P_AFILRUT", p_AFILRUT) :
                new ObjectParameter("P_AFILRUT", typeof(decimal));
    
            var p_CARGRUTParameter = p_CARGRUT.HasValue ?
                new ObjectParameter("P_CARGRUT", p_CARGRUT) :
                new ObjectParameter("P_CARGRUT", typeof(decimal));
    
            var p_PRESSIDParameter = p_PRESSID.HasValue ?
                new ObjectParameter("P_PRESSID", p_PRESSID) :
                new ObjectParameter("P_PRESSID", typeof(decimal));
    
            var p_PRESTIDParameter = p_PRESTID.HasValue ?
                new ObjectParameter("P_PRESTID", p_PRESTID) :
                new ObjectParameter("P_PRESTID", typeof(decimal));
    
            var p_CANALParameter = p_CANAL != null ?
                new ObjectParameter("P_CANAL", p_CANAL) :
                new ObjectParameter("P_CANAL", typeof(string));
    
            var p_ISAPREParameter = p_ISAPRE != null ?
                new ObjectParameter("P_ISAPRE", p_ISAPRE) :
                new ObjectParameter("P_ISAPRE", typeof(string));
    
            var p_EJECRUTParameter = p_EJECRUT.HasValue ?
                new ObjectParameter("P_EJECRUT", p_EJECRUT) :
                new ObjectParameter("P_EJECRUT", typeof(decimal));
    
            var p_AGENCIAParameter = p_AGENCIA != null ?
                new ObjectParameter("P_AGENCIA", p_AGENCIA) :
                new ObjectParameter("P_AGENCIA", typeof(string));
    
            var p_PLANSALUDParameter = p_PLANSALUD != null ?
                new ObjectParameter("P_PLANSALUD", p_PLANSALUD) :
                new ObjectParameter("P_PLANSALUD", typeof(string));
    
            var p_TRAMO_SIPParameter = p_TRAMO_SIP != null ?
                new ObjectParameter("P_TRAMO_SIP", p_TRAMO_SIP) :
                new ObjectParameter("P_TRAMO_SIP", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PKG_SIPNET_SP_GRABA_PREVIEW", p_AFILRUTParameter, p_CARGRUTParameter, p_PRESSIDParameter, p_PRESTIDParameter, p_CANALParameter, p_ISAPREParameter, p_EJECRUTParameter, p_AGENCIAParameter, p_PLANSALUDParameter, p_TRAMO_SIPParameter, p_SOLID);
        }
    
        public virtual int PKG_SIPNET_SP_GRABA_SOLICITUD(Nullable<decimal> p_AFILRUT, Nullable<decimal> p_CARGRUT, Nullable<decimal> p_PRESSID, Nullable<decimal> p_PRESTID, string p_CANAL, string p_ISAPRE, Nullable<decimal> p_EJECRUT, string p_AGENCIA, string p_PLANSALUD, string p_TRAMO_SIP, ObjectParameter p_SOLID)
        {
            var p_AFILRUTParameter = p_AFILRUT.HasValue ?
                new ObjectParameter("P_AFILRUT", p_AFILRUT) :
                new ObjectParameter("P_AFILRUT", typeof(decimal));
    
            var p_CARGRUTParameter = p_CARGRUT.HasValue ?
                new ObjectParameter("P_CARGRUT", p_CARGRUT) :
                new ObjectParameter("P_CARGRUT", typeof(decimal));
    
            var p_PRESSIDParameter = p_PRESSID.HasValue ?
                new ObjectParameter("P_PRESSID", p_PRESSID) :
                new ObjectParameter("P_PRESSID", typeof(decimal));
    
            var p_PRESTIDParameter = p_PRESTID.HasValue ?
                new ObjectParameter("P_PRESTID", p_PRESTID) :
                new ObjectParameter("P_PRESTID", typeof(decimal));
    
            var p_CANALParameter = p_CANAL != null ?
                new ObjectParameter("P_CANAL", p_CANAL) :
                new ObjectParameter("P_CANAL", typeof(string));
    
            var p_ISAPREParameter = p_ISAPRE != null ?
                new ObjectParameter("P_ISAPRE", p_ISAPRE) :
                new ObjectParameter("P_ISAPRE", typeof(string));
    
            var p_EJECRUTParameter = p_EJECRUT.HasValue ?
                new ObjectParameter("P_EJECRUT", p_EJECRUT) :
                new ObjectParameter("P_EJECRUT", typeof(decimal));
    
            var p_AGENCIAParameter = p_AGENCIA != null ?
                new ObjectParameter("P_AGENCIA", p_AGENCIA) :
                new ObjectParameter("P_AGENCIA", typeof(string));
    
            var p_PLANSALUDParameter = p_PLANSALUD != null ?
                new ObjectParameter("P_PLANSALUD", p_PLANSALUD) :
                new ObjectParameter("P_PLANSALUD", typeof(string));
    
            var p_TRAMO_SIPParameter = p_TRAMO_SIP != null ?
                new ObjectParameter("P_TRAMO_SIP", p_TRAMO_SIP) :
                new ObjectParameter("P_TRAMO_SIP", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PKG_SIPNET_SP_GRABA_SOLICITUD", p_AFILRUTParameter, p_CARGRUTParameter, p_PRESSIDParameter, p_PRESTIDParameter, p_CANALParameter, p_ISAPREParameter, p_EJECRUTParameter, p_AGENCIAParameter, p_PLANSALUDParameter, p_TRAMO_SIPParameter, p_SOLID);
        }
    
        public virtual ObjectResult<Sip> PKG_SIPNET_SP_OBTENER_SIP(Nullable<decimal> p_SOLID)
        {
            var p_SOLIDParameter = p_SOLID.HasValue ?
                new ObjectParameter("P_SOLID", p_SOLID) :
                new ObjectParameter("P_SOLID", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Sip>("PKG_SIPNET_SP_OBTENER_SIP", p_SOLIDParameter);
        }
    
        public virtual ObjectResult<PresupuestoSip> PKG_SIPNET_SP_OBTENER_PREVIEW(Nullable<decimal> p_SOLID)
        {
            var p_SOLIDParameter = p_SOLID.HasValue ?
                new ObjectParameter("P_SOLID", p_SOLID) :
                new ObjectParameter("P_SOLID", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PresupuestoSip>("PKG_SIPNET_SP_OBTENER_PREVIEW", p_SOLIDParameter);
        }
    
        public virtual ObjectResult<Beneficiario> PKG_SIPNET_OBTENER_BENEFICIARIOS(Nullable<decimal> pR_PRESSID, Nullable<decimal> pR_AFIL_NRUT, string pR_ISAP_CEMPRESA)
        {
            var pR_PRESSIDParameter = pR_PRESSID.HasValue ?
                new ObjectParameter("PR_PRESSID", pR_PRESSID) :
                new ObjectParameter("PR_PRESSID", typeof(decimal));
    
            var pR_AFIL_NRUTParameter = pR_AFIL_NRUT.HasValue ?
                new ObjectParameter("PR_AFIL_NRUT", pR_AFIL_NRUT) :
                new ObjectParameter("PR_AFIL_NRUT", typeof(decimal));
    
            var pR_ISAP_CEMPRESAParameter = pR_ISAP_CEMPRESA != null ?
                new ObjectParameter("PR_ISAP_CEMPRESA", pR_ISAP_CEMPRESA) :
                new ObjectParameter("PR_ISAP_CEMPRESA", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Beneficiario>("PKG_SIPNET_OBTENER_BENEFICIARIOS", pR_PRESSIDParameter, pR_AFIL_NRUTParameter, pR_ISAP_CEMPRESAParameter);
        }
    
        public virtual ObjectResult<Staff> PKG_SIPNET_OBTENER_STAFF(Nullable<decimal> pR_PRESTID, Nullable<decimal> pR_PRESSID, string pR_ISAPRE)
        {
            var pR_PRESTIDParameter = pR_PRESTID.HasValue ?
                new ObjectParameter("PR_PRESTID", pR_PRESTID) :
                new ObjectParameter("PR_PRESTID", typeof(decimal));
    
            var pR_PRESSIDParameter = pR_PRESSID.HasValue ?
                new ObjectParameter("PR_PRESSID", pR_PRESSID) :
                new ObjectParameter("PR_PRESSID", typeof(decimal));
    
            var pR_ISAPREParameter = pR_ISAPRE != null ?
                new ObjectParameter("PR_ISAPRE", pR_ISAPRE) :
                new ObjectParameter("PR_ISAPRE", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Staff>("PKG_SIPNET_OBTENER_STAFF", pR_PRESTIDParameter, pR_PRESSIDParameter, pR_ISAPREParameter);
        }
    }
}
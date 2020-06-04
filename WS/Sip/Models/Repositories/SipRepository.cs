using Sip.Exceptions;
using Sip.Models.Contracts;
using Sip.Models.Dto;
using Sip.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sip.Models.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public class SipRepository:ISipRepository
    {


        public V_AFILIADOSIP ObtenerDatosAfiliado(int rut)
        {
            try
            { 
                using (var context = new SipEntities())
                {
                    return context.V_AFILIADOSIP.FirstOrDefault(x => x.AFIL_NRUT == rut);
                }
           }
           catch(Exception ex)
            {
                throw new SipException(ex.Message);
            }
        }


        public ICollection<Entities.Prestacion> ObtenerPrestaciones(string plan, string isapre)
        {
            try 
            { 
                 using (var context = new SipEntities())
                 {
                     return context.PKG_SIPNET_OBTENER_PRESTACIONES(plan, 
                                                                 isapre).ToList();
                 }
            }
            catch(Exception ex)
            {
                throw new SipException(ex.Message);
            }
        }


        public ICollection<Entities.Prestador> ObtenerPrestadores(string plan, int prestacion, string isapre)
        {
            try
            { 
                using (var context = new SipEntities())
                {
                    return context.PKG_SIPNET_OBTENER_PRESTADORES(plan,
                                                               prestacion,
                                                               isapre).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new SipException(ex.Message);
            }

        }


        public ICollection<Beneficiario> ObtenerBeneficiarios(int prestacion, int rut, string isapre)
        {
            try
            { 
                using (var context = new SipEntities())
                {
                    return context.PKG_SIPNET_OBTENER_BENEFICIARIOS(prestacion,
                                                               rut,
                                                               isapre).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new SipException(ex.Message);
            }

        }


        public ICollection<Condicion> ObtenerCondicionesdeAcceso(int prestacion, string isapre)
        {
            try
            { 
                using (var context = new SipEntities())
                {
                    return context.PKG_SIPNET_OBTENER_CONDICIONES(prestacion,
                                                               isapre).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new SipException(ex.Message);
            }

        }

        public ICollection<Staff> ObtenerStaffMedico(int prestador, int prestacion, string isapre)
        {
            try
            {
                using (var context = new SipEntities())
                {
                    return context.PKG_SIPNET_OBTENER_STAFF(prestador,prestacion,isapre).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new SipException(ex.Message);
            }

        }


        public int CreaPresupuesto(DatosSip sip)
        {
            try
            {
                using (var context = new SipEntities())
                {

                    var outIdentificadorSip = new System.Data.Entity.Core.Objects.ObjectParameter("p_solid", typeof(string));

                    context.PKG_SIPNET_SP_GRABA_PREVIEW(sip.RunAfiliado,
                                                     sip.RunBeneficiario,
                                                     sip.PrestacionID,
                                                     sip.PrestadorID,
                                                     sip.Canal,
                                                     sip.Isapre,
                                                     sip.RunEjecutivo,
                                                     sip.Agencia,
                                                     sip.PlanSalud,
                                                     sip.TramoSip,
                                                     outIdentificadorSip);

                    return Convert.ToInt32(outIdentificadorSip.Value);
                }
            }catch(Exception ex)
            {
                throw new SipException(ex.Message);
            }
        }

        public int CreaSip(DatosSip sip)
        {
            try
            { 
                using (var context = new SipEntities())
                {

                    var outIdentificadorSip = new System.Data.Entity.Core.Objects.ObjectParameter("p_solid", typeof(string));

                    context.PKG_SIPNET_SP_GRABA_SOLICITUD(sip.RunAfiliado,
                                                     sip.RunBeneficiario,
                                                     sip.PrestacionID,
                                                     sip.PrestadorID,
                                                     sip.Canal,
                                                     sip.Isapre,
                                                     sip.RunEjecutivo,
                                                     sip.Agencia,
                                                     sip.PlanSalud,
                                                     sip.TramoSip,
                                                     outIdentificadorSip);

                    return Convert.ToInt32(outIdentificadorSip.Value);
                }
            }
            catch (Exception ex)
            {
                throw new SipException(ex.Message);
            }

        }

        public PresupuestoSip ObtenerPresupuesto(int id)
        {
            try
            {
                using (var context = new SipEntities())
                {
                    return context.PKG_SIPNET_SP_OBTENER_PREVIEW(id).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw new SipException(ex.Message);
            }

        }

        public Entities.Sip ObtenerSolicitud(int id)
        {
            try
            {
                using (var context = new SipEntities())
                {
                    return context.PKG_SIPNET_SP_OBTENER_SIP(id).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw new SipException(ex.Message);
            }

        }

        public IEnumerable<MAIL_PRESTADOR_SIP> ObtenerMailPrestador(int prestador, string isapre)
        {
            try
            {
                using (var context = new SipEntities())
                {
                    return context.MAIL_PRESTADOR_SIP.Where(x => x.PRESTSIP_ID == prestador && x.ISAP_CEMPRESA == isapre).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new SipException(ex.Message);
            }
        }

    }
}
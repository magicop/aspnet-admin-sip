using Sip.Models.Dto;
using Sip.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sip.Models.Contracts
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISipRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rut"></param>
        /// <returns></returns>
        V_AFILIADOSIP ObtenerDatosAfiliado(int rut);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="plan"></param>
        /// <param name="isapre"></param>
        /// <returns></returns>
        ICollection<Entities.Prestacion> ObtenerPrestaciones(string plan, string isapre);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="plan"></param>
        /// <param name="prestacion"></param>
        /// <param name="isapre"></param>
        /// <returns></returns>
        ICollection<Entities.Prestador> ObtenerPrestadores(string plan, int prestacion, string isapre);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="prestacion"></param>
        /// <param name="rut"></param>
        /// <param name="isapre"></param>
        /// <returns></returns>
        ICollection<Beneficiario> ObtenerBeneficiarios(int prestacion, int rut, string isapre);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="prestacion"></param>
        /// <param name="isapre"></param>
        /// <returns></returns>
        ICollection<Condicion> ObtenerCondicionesdeAcceso(int prestacion, string isapre);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="prestador"></param>
        /// <param name="prestacion"></param>
        /// <param name="isapre"></param>
        /// <returns></returns>
        ICollection<Staff> ObtenerStaffMedico(int prestador, int prestacion, string isapre);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sip"></param>
        /// <returns></returns>
        int CreaPresupuesto(DatosSip sip);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sip"></param>
        /// <returns></returns>
        int CreaSip(DatosSip sip);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        PresupuestoSip ObtenerPresupuesto(int id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Entities.Sip ObtenerSolicitud(int id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="prestador"></param>
        /// <param name="isapre"></param>
        /// <returns></returns>
        IEnumerable<MAIL_PRESTADOR_SIP> ObtenerMailPrestador(int prestador, string isapre);

    }
}

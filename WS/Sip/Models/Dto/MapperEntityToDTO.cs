using Sip.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sip.Models.Dto
{
    public class MapperEntityToDTO
    {
        public Prestacion ToDTO(ObtenerPrestacionesEntity entity)
        {
            Prestacion pr = new Prestacion();

            pr.codPaquete = Convert.ToInt32(entity.CODPAQUETE);
            pr.descripcion = entity.DESCRIPCION;
            pr.isapre = entity.ISAPRE;
            pr.estado = entity.ESTADO;
            pr.fechaInicio = entity.INICIOVIGENCIA;
            pr.fechaTermino = Convert.ToDateTime(entity.TERMINOVIGENCIA);

            return pr;

        }

        public Prestacion ToDTO(ListarPrestacionesEntity entity)
        {
            Prestacion pr = new Prestacion();

            pr.idprestacion = Convert.ToInt32(entity.IDPRESTACION);
            pr.descripcion = entity.DESCRIPCION;

            return pr;

        }

        public Prestador ToDTO(ObtenerPrestadoresEntity entity)
        {
            Prestador pr = new Prestador();

            pr.rut = Convert.ToInt32(entity.RUT);
            pr.rutInstitucion = Convert.ToInt32(entity.RUTINSTITUCION);
            pr.nombre = entity.NOMBRE;
            pr.isapre = entity.ISAPRE;
            pr.secuencia = Convert.ToInt32(entity.SECUENCIA);

            return pr;

        }

        public Solicitud ToDTO(ObtenerSolicitudesEntity entity)
        {
            Solicitud sol = new Solicitud();

            sol.id = Convert.ToInt32(entity.IDSOLICITUD);
            sol.descripcionPrestacion = entity.PRESTACION;
            sol.nombrePrestador = entity.PRESTADOR;
            sol.isapre = entity.ISAPRE;
            sol.rutNombreAfiliado = entity.NOMBREAFILIADO;
            sol.estado = entity.ESTADO;

            return sol;
        }

        public Medico ToDTO(ObtenerMedicoEntity entity)
        {
            Medico me = new Medico();

            me.nombre = entity.NOMBRE;
            me.rut = Convert.ToInt32(entity.RUT);

            return me;
        }

        public Restriccion ToDTO(ObtenerRestriccionesEntity entity)
        {
            Restriccion rest = new Restriccion();

            rest.codplan = entity.CODPLAN;
            rest.idprestacion = Convert.ToInt32(entity.IDPRESTACION);
            rest.isapre = entity.ISAPRE;

            return rest;
        }
    }
}
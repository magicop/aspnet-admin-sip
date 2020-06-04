using Sip.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sip.Models.Contracts
{
    public interface IAdminSipRepository
    {
        #region Obtener
        ICollection<Prestacion> obtenerPrestaciones(string isapre);

        ICollection<Prestador> obtenerPrestadores(string isapre);

        ICollection<Solicitud> obtenerSolicitudes(string accion, int var_aux);

        ICollection<Medico> obtenerMedicos(int idprestacion, int idprestador, string isapre);

        ICollection<Restriccion> obtenerRestricciones(string codplan, string isapre);

        ICollection<Prestacion> listarPrestaciones();
        #endregion

        #region Agregar
        bool agregarPrestacion(string isapre, int codpaquete, string descripcion);
        bool agregarPrestador(string isapre, int rut, string nombre,
            int rutinstitucion, int secuencia, string estado, DateTime fechaInicio, string observacion,
            string direccion, string telefono, string sitioweb);
        bool agregarMedico(int rut, string nombre, int idprest, int idpress, string isapre);
        bool agregarCondicionPrestacion(int idpress, string condicion, string funcion,
            string tipo, string estado, DateTime fechaInicio, string isapre);
        #endregion

        bool terminarVigenciaPrestacion(int codpaquete);

        bool eliminarPrestador(string isapre, int rut);

        bool editarPrestador(int codpaqueteanterior, string isapre, int codpaquetenuevo, string descripcion);

        bool agregarRestriccionExcel(int idprestacion, string codplan, string isapre);

        bool eliminarRestriccion(string codplan, string isapre);

        bool eliminarMedico(int rut);

    }
}
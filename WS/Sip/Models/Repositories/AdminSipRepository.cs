using Sip.Models.Dto;
using Sip.Models.Entities;
using Sip.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sip.Models.Repositories
{

    public class AdminSipRepository : IAdminSipRepository
    {

        #region Get
        public ICollection<Dto.Prestacion> obtenerPrestaciones(string isapre)
        {
            try
            {
                using (var context = new AdminSipEntities())
                {
                    var out_prsText = new System.Data.Entity.Core.Objects.ObjectParameter("except_text", typeof(string));

                    var prestacionesEntity = context.PKG_ADMINSIP2_OBTENERPRESTACIONES(isapre, out_prsText);

                    List<Dto.Prestacion> listPrestaciones = new List<Dto.Prestacion>();
                    MapperEntityToDTO mapper = new MapperEntityToDTO();

                    foreach (var item in prestacionesEntity)
                    {
                        listPrestaciones.Add(mapper.ToDTO(item));
                    }

                    return listPrestaciones;
                }
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }

        public ICollection<Dto.Prestador> obtenerPrestadores(string isapre)
        {
            try
            {
                using (var context = new AdminSipEntities())
                {
                    var out_prsText = new System.Data.Entity.Core.Objects.ObjectParameter("except_text", typeof(string));

                    var prestadoresEntity = context.PKG_ADMINSIP2_OBTENERPRESTADORES(isapre, out_prsText);

                    List<Dto.Prestador> listPrestadores = new List<Dto.Prestador>();
                    MapperEntityToDTO mapper = new MapperEntityToDTO();

                    foreach (var item in prestadoresEntity)
                    {
                        listPrestadores.Add(mapper.ToDTO(item));
                    }

                    return listPrestadores;
                }
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }

        public ICollection<Solicitud> obtenerSolicitudes(string accion, int var_aux)
        {
            try
            {
                using (var context = new AdminSipEntities())
                {
                    var out_prsText = new System.Data.Entity.Core.Objects.ObjectParameter("except_text", typeof(string));

                    var solicitudesEntity = context.PKG_ADMINSIP2_OBTENERSOLICITUDES(accion, var_aux, out_prsText);

                    List<Solicitud> listSolicitudes = new List<Solicitud>();
                    MapperEntityToDTO mapper = new MapperEntityToDTO();

                    foreach (var item in solicitudesEntity)
                    {
                        listSolicitudes.Add(mapper.ToDTO(item));
                    }

                    return listSolicitudes;
                }
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }
        public ICollection<Medico> obtenerMedicos(int idprestacion, int idprestador, string isapre)
        {
            try
            {
                using (var context = new AdminSipEntities())
                {
                    var out_prsText = new System.Data.Entity.Core.Objects.ObjectParameter("except_text", typeof(string));

                    var medicosEntity = context.PKG_ADMINSIP2_OBTENERMEDICOS(idprestacion, idprestador, isapre, out_prsText);

                    List<Medico> listMedicos = new List<Medico>();
                    MapperEntityToDTO mapper = new MapperEntityToDTO();

                    foreach (var item in medicosEntity)
                    {
                        listMedicos.Add(mapper.ToDTO(item));
                    }

                    return listMedicos;
                }
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }

        public ICollection<Restriccion> obtenerRestricciones(string codplan, string isapre)
        {
            try
            {
                using (var context = new AdminSipEntities())
                {
                    var out_prsText = new System.Data.Entity.Core.Objects.ObjectParameter("except_text", typeof(string));

                    var restriccionesEntity = context.PKG_ADMINSIP2_OBTENERRESTRICCIONES(codplan, isapre, out_prsText);


                    List<Restriccion> listRestricciones = new List<Restriccion>();
                    MapperEntityToDTO mapper = new MapperEntityToDTO();

                    foreach (var item in restriccionesEntity)
                    {
                        listRestricciones.Add(mapper.ToDTO(item));
                    }

                    return listRestricciones;
                }
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }

        public ICollection<Dto.Prestacion> listarPrestaciones()
        {
            try
            {
                using (var context = new AdminSipEntities())
                {
                    var out_prsText = new System.Data.Entity.Core.Objects.ObjectParameter("except_text", typeof(string));

                    var prEntity = context.PKG_ADMINSIP2_LISTARPRESTACIONES(out_prsText);


                    List<Dto.Prestacion> listPrestaciones = new List<Dto.Prestacion>();
                    MapperEntityToDTO mapper = new MapperEntityToDTO();

                    foreach (var item in prEntity)
                    {
                        listPrestaciones.Add(mapper.ToDTO(item));
                    }

                    return listPrestaciones;
                }
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        #region Post
        public bool agregarPrestacion(string isapre, int codpaquete, string descripcion)
        {
            try
            {
                using (var context = new AdminSipEntities())
                {
                    var out_prsText = new System.Data.Entity.Core.Objects.ObjectParameter("except_text", typeof(string));

                    var apEntity = context.PKG_ADMINSIP2_AGREGARPRESTACION(isapre, codpaquete, descripcion, out_prsText);

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }
        public bool agregarPrestador(string isapre, int rut, string nombre,
            int rutinstitucion, int secuencia, string estado, DateTime fechaInicio, string observacion,
            string direccion, string telefono, string sitioweb)
        {
            try
            {
                using (var context = new AdminSipEntities())
                {
                    var out_prsText = new System.Data.Entity.Core.Objects.ObjectParameter("except_text", typeof(string));

                    var apEntity = context.PKG_ADMINSIP2_AGREGARPRESTADOR(isapre, rut, nombre, rutinstitucion,
                        secuencia, estado, fechaInicio, observacion, direccion, telefono, sitioweb, out_prsText);

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }

        public bool agregarMedico(int rut, string nombre, int idprest, int idpress, string isapre)
        {
            try
            {
                using (var context = new AdminSipEntities())
                {
                    var out_prsText = new System.Data.Entity.Core.Objects.ObjectParameter("except_text", typeof(string));

                    var apEntity = context.PKG_ADMINSIP2_AGREGARMEDICO(rut, nombre, idprest, idpress, isapre, out_prsText);

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }
        public bool agregarCondicionPrestacion(int idpress, string condicion, string funcion,
            string tipo, string estado, DateTime fechaInicio, string isapre)
        {
            try
            {
                using (var context = new AdminSipEntities())
                {
                    var out_prsText = new System.Data.Entity.Core.Objects.ObjectParameter("except_text", typeof(string));

                    var apEntity = context.PKG_ADMINSIP2_AGREGARCONDICIONPRESTACION(idpress, condicion, funcion, tipo, estado, fechaInicio, isapre, out_prsText);

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }

        public bool terminarVigenciaPrestacion(int codpaquete)
        {
            try
            {
                using (var context = new AdminSipEntities())
                {
                    var out_prsText = new System.Data.Entity.Core.Objects.ObjectParameter("except_text", typeof(string));

                    var apEntity = context.PKG_ADMINSIP2_TERMINARVIGENCIAPRESTACION(codpaquete, out_prsText);

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }

        public bool eliminarPrestador(string isapre, int rut)
        {
            try
            {
                using (var context = new AdminSipEntities())
                {
                    var out_prsText = new System.Data.Entity.Core.Objects.ObjectParameter("except_text", typeof(string));

                    var apEntity = context.PKG_ADMINSIP2_ELIMINARPRESTADOR(rut, isapre, out_prsText);

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }

        public bool editarPrestador(int codpaqueteanterior, string isapre, int codpaquetenuevo, string descripcion)
        {
            try
            {
                using (var context = new AdminSipEntities())
                {
                    var out_prsText = new System.Data.Entity.Core.Objects.ObjectParameter("except_text", typeof(string));

                    var apEntity = context.PKG_ADMINSIP2_EDITARPRESTACION(codpaqueteanterior, isapre, codpaquetenuevo, descripcion, out_prsText);

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }

        public bool agregarRestriccionExcel(int idprestacion, string codplan, string isapre)
        {
            try
            {
                using (var context = new AdminSipEntities())
                {

                    var aux_isapre = "";

                    if (isapre == "banmedica" || isapre == "B")
                    {
                        aux_isapre = "B";
                    }
                    else if (isapre == "vidatres" || isapre == "T")
                    {
                        aux_isapre = "T";
                    }

                    var out_prsText = new System.Data.Entity.Core.Objects.ObjectParameter("except_text", typeof(string));

                    var excelEntity = context.PKG_ADMINSIP2_AGREGARRESTRICCIONEXCEL(idprestacion, codplan, aux_isapre, out_prsText);

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }

        public bool eliminarRestriccion(string codplan, string isapre)
        {
            try
            {
                using (var context = new AdminSipEntities())
                {

                    var out_prsText = new System.Data.Entity.Core.Objects.ObjectParameter("except_text", typeof(string));

                    var apEntity = context.PKG_ADMINSIP2_ELIMINARRESTRICCION(codplan, isapre, out_prsText);

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }

        public bool eliminarMedico(int rut)
        {
            try
            {
                using (var context = new AdminSipEntities())
                {

                    var out_prsText = new System.Data.Entity.Core.Objects.ObjectParameter("except_text", typeof(string));

                    var apEntity = context.PKG_ADMINSIP2_ELIMINARMEDICO(rut, out_prsText);

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }

        #endregion
    }
    
}
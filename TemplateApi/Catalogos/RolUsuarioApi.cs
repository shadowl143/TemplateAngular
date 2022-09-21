using AutoMapper;
using ContextoDB.Data;
using ContextoDB.Models.Catalogos;
using ContextoDB.ModelsVM;
using ContextoDB.ModelsVM.Catalogos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateApi.Catalogos
{
    public class RolUsuarioApi
    {

        private readonly IMapper map;
        private readonly Contexto dB;
        private readonly ILogger<RolUsuarioApi> log;

        public RolUsuarioApi(IMapper map, Contexto dB, ILogger<RolUsuarioApi> log)
        {
            this.map = map;
            this.dB = dB;
            this.log = log;
        }

        public async Task<RespuestaVM<List<RolUsuarioVM>>> GetIdUsuario(int idUsuario)
        {
            try
            {
                // primero necesitamos el id rol LEFT JOIN 
                var rolUsuario = this.dB.RolesUsuario.Where(e => e.RolId == idUsuario).ToList();
                var listado = await (from rol in this.dB.Roles
                                     join rolusuario in rolUsuario on rol.Id equals rolusuario.RolId into union
                                     from ruu in union.DefaultIfEmpty()
                                     select new RolUsuarioVM
                                     {
                                         RolId = rol.Id,
                                         RolNombre = rol.Nombre,
                                         Activo =ruu!=null?rol.Activo:false,
                                     }).ToListAsync();
                return new RespuestaVM<List<RolUsuarioVM>> { Mensaje = "Correcto", Exito = true, MensajeError = "", Model = listado };
            }
            catch (Exception ex)
            {
                this.log.LogCritical(ex, ex.Message);
                return new RespuestaVM<List<RolUsuarioVM>> { Exito = false, Mensaje = "", MensajeError = "Error al obtener datos", Model = null };
            }
        }

        public async Task<RespuestaVM<RolUsuarioVM>> SaveOrUpdate(RolUsuarioVM model)
        {
            try
            {
                var rolusuario = this.dB.RolesUsuario.Where(e => e.RolId == model.RolId && e.UsuarioId == model.UsuarioId).FirstOrDefault();
                if (rolusuario != null)
                {
                    rolusuario.Activo = model.Activo;
                }
                else
                {
                    var guardar = this.map.Map<RolUsuario>(model);
                    this.dB.RolesUsuario.Add(guardar);
                }
                await this.dB.SaveChangesAsync();
                return new RespuestaVM<RolUsuarioVM> { Exito = true, Mensaje = "Actualizado", MensajeError = "", Model = model };
            }
            catch (Exception ex)
            {
                this.log.LogCritical(ex, ex.Message);
                return new RespuestaVM<RolUsuarioVM> { Exito = false, Mensaje = "", MensajeError = "Error", Model = null };

            }
        }
    }
}

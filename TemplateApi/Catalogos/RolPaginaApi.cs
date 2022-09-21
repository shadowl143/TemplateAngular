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
using TemplateApi.Seguridad;

namespace TemplateApi.Catalogos
{
    public  class RolPaginaApi
    {
        private readonly IMapper map;
        private readonly Contexto dB;
        private readonly ILogger<RolPaginaApi> log;

        public RolPaginaApi(IMapper map, Contexto dB, ILogger<RolPaginaApi> log)
        {
            this.map = map;
            this.dB = dB;
            this.log = log;
        }

        public async Task<RespuestaVM<List<RolPaginaVM>>> GetIdRol(int idRol)
        {
            try
            {
                // primero necesitamos el id rol LEFT JOIN 
                var rolPagina = this.dB.RolesPagina.Where(e => e.RolId == idRol).ToList();
                var listado = await (from pagina in this.dB.Paginas
                                     join rolPaginas in rolPagina on pagina.Id equals rolPaginas.PaginaId into union
                                     from rpp in union.DefaultIfEmpty()
                                     select new RolPaginaVM
                                     {
                                         PaginaId = pagina.Id,
                                         RolId=idRol,
                                         RolNombre="",
                                         PaginaNombre=pagina.Nombre,
                                         Activo=rpp!=null?rpp.Activo:false,
                                     }).ToListAsync();
                return new RespuestaVM<List<RolPaginaVM>> {Mensaje="Correcto",Exito=true,MensajeError="",Model=listado };
            }
            catch (Exception ex)
            {
                this.log.LogCritical(ex, ex.Message);
                return new RespuestaVM<List<RolPaginaVM>> { Exito = false, Mensaje = "", MensajeError = "Error al obtener datos", Model = null };
            }
        }

        public async Task<RespuestaVM<RolPaginaVM>> SaveOrUpdate(RolPaginaVM model)
        {
            try
            {
                var rolpagina = this.dB.RolesPagina.Where(e => e.RolId == model.RolId && e.PaginaId == model.PaginaId).FirstOrDefault();
                if (rolpagina!=null)
                {
                    rolpagina.Activo =model.Activo;
                }
                else
                {
                    var guardar = this.map.Map<RolPagina>(model);
                    this.dB.RolesPagina.Add(guardar);
                }
                await this.dB.SaveChangesAsync();
                return new RespuestaVM<RolPaginaVM> { Exito = true, Mensaje = "Actualizado", MensajeError = "", Model = model };
            }
            catch (Exception ex)
            {
                this.log.LogCritical(ex, ex.Message);
                return new RespuestaVM<RolPaginaVM> { Exito = false, Mensaje = "", MensajeError = "Error", Model = null };

            }
        }

    }
}

using AutoMapper;
using ContextoDB.Data;
using ContextoDB.Models.Catalogos;
using ContextoDB.ModelsVM;
using ContextoDB.ModelsVM.Catalogos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OfficeOpenXml.FormulaParsing.Excel.Functions.RefAndLookup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateApi.Catalogos
{
    public  class RolApi
    {
        private readonly IMapper map;
        private readonly Contexto dB;
        private readonly ILogger<RolApi> log;

        public RolApi(IMapper map, Contexto dB, ILogger<RolApi> log)
        {
            this.map = map;
            this.dB = dB;
            this.log = log;
        }

        public async Task<RespuestaVM<List<RolVM>>> GetTodos()
        {
            try
            {
                var listado = this.map.Map<List<RolVM>>(await this.dB.Roles.ToListAsync());
                return new RespuestaVM<List<RolVM>> { Exito = true, Mensaje = "Se encontraron registros", MensajeError = "", Model = listado };
            }
            catch (Exception ex)
            {
                this.log.LogCritical(ex, ex.Message);
                return new RespuestaVM<List<RolVM>> { Exito = false, Mensaje = "", MensajeError = "Erro al obtener los datos del servidor" };
            }
        }

        public async Task<RespuestaVM<RolVM>> GetId(int id)
        {
            try
            {
                var listado = this.map.Map<RolVM>(await this.dB.Roles.FindAsync(id));
                return new RespuestaVM<RolVM> { Exito = true, Mensaje = "Se encontraron registros", MensajeError = "", Model = listado };
            }
            catch (Exception ex)
            {
                this.log.LogCritical(ex, ex.Message);
                return new RespuestaVM<RolVM> { Exito = false, Mensaje = "", MensajeError = "Erro al obtener los datos del servidor" };
            }
        }

        public async Task<RespuestaVM<RolVM>> Save(RolVM model)
        {
            try
            {
                //insert into 
                var modeloGuardar = map.Map<Rol>(model);
                this.dB.Roles.Add(modeloGuardar);
                await this.dB.SaveChangesAsync();
                return new RespuestaVM<RolVM> { Mensaje = "Guardado", MensajeError = "", Exito = true, Model = model };
            }
            catch (Exception ex)
            {
                this.log.LogCritical(ex, ex.Message);
                return new RespuestaVM<RolVM> { Exito = false, Mensaje = "", MensajeError = "Erro al obtener los datos del servidor" };
            }
        }

        public async Task<RespuestaVM<RolVM>> Update(int id, RolVM model)
        {
            try
            {
                // update Rol set ...  where .... 
                var datoCambiar = this.dB.Roles.Find(id);
                this.dB.Entry<Rol>(datoCambiar).CurrentValues.SetValues(model);
                await this.dB.SaveChangesAsync();
                return new RespuestaVM<RolVM> { Mensaje = "Guardado", MensajeError = "", Exito = true, Model = model };
            }
            catch (Exception ex)
            {
                this.log.LogCritical(ex, ex.Message);
                return new RespuestaVM<RolVM> { Exito = false, Mensaje = "", MensajeError = "Erro al obtener los datos del servidor" };
            }
        }

        public async Task<RespuestaVM<List<RolPaginaVM>>> GetRolPagina(int rolId)
        {
            try
            {

                var rolPagina = this.map.Map<List<RolPaginaVM>>(await this.dB.RolesPagina
                    .Include(e=>e.Pagina)
                    .Include(e=>e.Rol).Where(e => e.RolId == rolId).ToListAsync());
                var paginas = this.dB.Paginas.ToList();

                var listado = (from page in paginas
                               join rolPage in rolPagina on page.Id equals rolPage.PaginaId into agrp
                               from union in agrp.DefaultIfEmpty()
                               select new RolPaginaVM
                               {
                                   PaginaNombre =page.Nombre,
                                   Activo = union == null ? false : union.Activo,
                                   RolNombre = union == null ? "" : union.RolNombre,
                                   RolId = rolId,
                                   PaginaId=page.Id
                               }).ToList();
                return new RespuestaVM<List<RolPaginaVM>> { Mensaje = "Existo", MensajeError = "N/A", Exito = true, Model = listado };
            }
            catch (Exception ex)
            {
                this.log.LogCritical(ex, ex.Message);
                return new RespuestaVM<List<RolPaginaVM>> { Exito = false, Mensaje = "N/A", MensajeError = ex.Message, Model = new List<RolPaginaVM>() };
            }
        }

        public async Task<RespuestaVM<List<RolPaginaVM>>> AddUpdateRolUsuario(IList<RolPaginaVM> model)
        {
            try
            {
                foreach (var item in model)
                {
                    var existeRegistro = this.dB.RolesPagina.Where(e => e.RolId == item.RolId && e.PaginaId == item.PaginaId).FirstOrDefault();
                    if (existeRegistro != null)
                    {
                        existeRegistro.Activo = item.Activo;
                        await this.dB.SaveChangesAsync();
                    }
                    else
                    {
                        if (item.Activo)
                        {
                            this.dB.Add(new RolPagina { RolId = item.RolId, PaginaId = item.PaginaId, Activo = item.Activo });
                            await this.dB.SaveChangesAsync();
                        }
                        
                    }
                }

                return await this.GetRolPagina(model.First().RolId);
            }
            catch (Exception ex)
            {
                this.log.LogCritical(ex, ex.Message);
                return new RespuestaVM<List<RolPaginaVM>> { Exito = false, Mensaje = "N/A", MensajeError = ex.Message, Model = new List<RolPaginaVM>() };
            }

        }
    }
}

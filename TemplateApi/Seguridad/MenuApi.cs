using AutoMapper;
using ContextoDB.Data;
using ContextoDB.Models.Seguridad;
using ContextoDB.ModelsVM;
using ContextoDB.ModelsVM.Catalogos;
using ContextoDB.ModelsVM.Seguridad;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateApi.Seguridad
{
    public class MenuApi
    {
        private readonly IMapper map;
        private readonly Contexto dB;
        private readonly ILogger<MenuApi> log;

        public MenuApi(IMapper map, Contexto dB, ILogger<MenuApi> log)
        {
            this.map = map;
            this.dB = dB;
            this.log = log;
        }

        public async Task<RespuestaVM<List<MenuVM>>> GetTodos()
        {
            try
            {
                var listado = this.map.Map<List<MenuVM>>(await this.dB.Menus.ToListAsync());
                return new RespuestaVM<List<MenuVM>> { Exito = true, Mensaje = "Se encontraron registros", MensajeError = "", Model = listado };
            }
            catch (Exception ex)
            {
                this.log.LogCritical(ex, ex.Message);
                return new RespuestaVM<List<MenuVM>> { Exito = false, Mensaje = "", MensajeError = "Erro al obtener los datos del servidor" };
            }
        }

        public async Task<RespuestaVM<MenuVM>> GetId(int id)
        {
            try
            {
                var listado = this.map.Map<MenuVM>(await this.dB.Menus.FindAsync(id));
                return new RespuestaVM<MenuVM> { Exito = true, Mensaje = "Se encontraron registros", MensajeError = "", Model = listado };
            }
            catch (Exception ex)
            {
                this.log.LogCritical(ex, ex.Message);
                return new RespuestaVM<MenuVM> { Exito = false, Mensaje = "", MensajeError = "Erro al obtener los datos del servidor" };
            }
        }

        public async Task<RespuestaVM<MenuVM>> Save(MenuVM model)
        {
            try
            {
                //insert into 
                var modeloGuardar = map.Map<Menu>(model);
                this.dB.Menus.Add(modeloGuardar);
                await this.dB.SaveChangesAsync();
                return new RespuestaVM<MenuVM> { Mensaje = "Guardado", MensajeError = "", Exito = true, Model = model };
            }
            catch (Exception ex)
            {
                this.log.LogCritical(ex, ex.Message);
                return new RespuestaVM<MenuVM> { Exito = false, Mensaje = "", MensajeError = "Erro al obtener los datos del servidor" };
            }
        }

        public async Task<RespuestaVM<MenuVM>> Update(int id, MenuVM model)
        {
            try
            {
                // update Rol set ...  where .... 
                var datoCambiar = this.dB.Menus.Find(id);
                this.dB.Entry<Menu>(datoCambiar).CurrentValues.SetValues(model);
                await this.dB.SaveChangesAsync();
                return new RespuestaVM<MenuVM> { Mensaje = "Guardado", MensajeError = "", Exito = true, Model = model };
            }
            catch (Exception ex)
            {
                this.log.LogCritical(ex, ex.Message);
                return new RespuestaVM<MenuVM> { Exito = false, Mensaje = "", MensajeError = "Erro al obtener los datos del servidor" };
            }
        }
    }
}

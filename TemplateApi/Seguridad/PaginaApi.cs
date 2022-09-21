

namespace TemplateApi.Seguridad
{
    using AutoMapper;
    using ContextoDB.Data;
    using ContextoDB.Models.Seguridad;
    using ContextoDB.ModelsVM;
    using ContextoDB.ModelsVM.Seguridad;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    public class PaginaApi
    {

        private readonly IMapper map;
        private readonly Contexto dB;
        private readonly ILogger<PaginaApi> log;

        public PaginaApi(IMapper map, Contexto dB, ILogger<PaginaApi> log)
        {
            this.map = map;
            this.dB = dB;
            this.log = log;
        }

        public async Task<RespuestaVM<List<PaginaVM>>> GetTodos()
        {
            try
            {
                var listado = this.map.Map<List<PaginaVM>>(await this.dB.Paginas.Include(e=>e.Menu).ToListAsync());
                return new RespuestaVM<List<PaginaVM>> { Exito = true, Mensaje = "Se encontraron registros", MensajeError = "", Model = listado };
            }
            catch (Exception ex)
            {
                this.log.LogCritical(ex, ex.Message);
                return new RespuestaVM<List<PaginaVM>> { Exito = false, Mensaje = "", MensajeError = "Erro al obtener los datos del servidor" };
            }
        }

        public async Task<RespuestaVM<PaginaVM>> GetId(int id)
        {
            try
            {
                var listado = this.map.Map<PaginaVM>(await this.dB.Paginas.Include(e=>e.Menu).FirstOrDefaultAsync(e=>e.Id==id));
                return new RespuestaVM<PaginaVM> { Exito = true, Mensaje = "Se encontraron registros", MensajeError = "", Model = listado };
            }
            catch (Exception ex)
            {
                this.log.LogCritical(ex, ex.Message);
                return new RespuestaVM<PaginaVM> { Exito = false, Mensaje = "", MensajeError = "Erro al obtener los datos del servidor" };
            }
        }

        public async Task<RespuestaVM<PaginaVM>> Save(PaginaVM model)
        {
            try
            {
                //insert into 
                var modeloGuardar = map.Map<Pagina>(model);
                this.dB.Paginas.Add(modeloGuardar);
                await this.dB.SaveChangesAsync();
                return new RespuestaVM<PaginaVM> { Mensaje = "Guardado", MensajeError = "", Exito = true, Model = model };
            }
            catch (Exception ex)
            {
                this.log.LogCritical(ex, ex.Message);
                return new RespuestaVM<PaginaVM> { Exito = false, Mensaje = "", MensajeError = "Erro al obtener los datos del servidor" };
            }
        }

        public async Task<RespuestaVM<PaginaVM>> Update(int id, PaginaVM model)
        {
            try
            {
                // update Rol set ...  where .... 
                var datoCambiar = this.dB.Paginas.Find(id);
                this.dB.Entry<Pagina>(datoCambiar).CurrentValues.SetValues(model);
                await this.dB.SaveChangesAsync();
                return new RespuestaVM<PaginaVM> { Mensaje = "Guardado", MensajeError = "", Exito = true, Model = model };
            }
            catch (Exception ex)
            {
                this.log.LogCritical(ex, ex.Message);
                return new RespuestaVM<PaginaVM> { Exito = false, Mensaje = "", MensajeError = "Erro al obtener los datos del servidor" };
            }
        }
    }
}

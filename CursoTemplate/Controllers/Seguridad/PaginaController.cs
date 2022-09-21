namespace CursoTemplate.Controllers.Seguridad
{

    using ContextoDB.ModelsVM;
    using ContextoDB.ModelsVM.Seguridad;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using TemplateApi.Seguridad;

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PaginaController : ControllerBase
    {
        private readonly PaginaApi api;

        public PaginaController(PaginaApi api)
        {
            this.api = api;
        }

        [HttpGet]
        public async Task<RespuestaVM<List<PaginaVM>>> GetTodos()
        {
            return await api.GetTodos();
        }
        [HttpGet("{id}")]
        public async Task<RespuestaVM<PaginaVM>> GetId(int id)
        {
            return await api.GetId(id);
        }

        [HttpPost]
        public async Task<RespuestaVM<PaginaVM>> Post(PaginaVM model)
        {
            return await api.Save(model);
        }

        [HttpPut("{id}")]
        public async Task<RespuestaVM<PaginaVM>> Update(int id, PaginaVM model)
        {
            return await api.Update(id, model);
        }
    }
}

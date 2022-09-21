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
    public class MenuController : ControllerBase
    {
        private readonly MenuApi api;

        public MenuController(MenuApi api)
        {
            this.api = api;
        }

        [HttpGet]
        public async Task<RespuestaVM<List<MenuVM>>> GetTodos()
        {
            return await api.GetTodos();
        }
        [HttpGet("{id}")]
        public async Task<RespuestaVM<MenuVM>> GetId(int id)
        {
            return await api.GetId(id);
        }

        [HttpPost]
        public async Task<RespuestaVM<MenuVM>> Post(MenuVM model)
        {
            return await api.Save(model);
        }

        [HttpPut("{id}")]
        public async Task<RespuestaVM<MenuVM>> Update(int id, MenuVM model)
        {
            return await api.Update(id, model);
        }
    }
}

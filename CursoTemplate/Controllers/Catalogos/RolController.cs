namespace CursoTemplate.Controllers.Catalogos
{
    using ContextoDB.ModelsVM;
    using ContextoDB.ModelsVM.Catalogos;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using TemplateApi.Catalogos;

    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class RolController : ControllerBase
    {

        private readonly RolApi api;

        public RolController(RolApi api)
        {
            this.api = api;
        }

        [HttpGet]
        public async Task<RespuestaVM<List<RolVM>>> GetTodos()
        {
            return await api.GetTodos();
        }
        [HttpGet("{id}")]
        public async Task<RespuestaVM<RolVM>> GetId(int id)
        {
            return await api.GetId(id);
        }

        [HttpPost]
        public async Task<RespuestaVM<RolVM>> Post(RolVM model)
        {
            return await api.Save(model);
        }

        [HttpPut("{id}")]
        public async Task<RespuestaVM<RolVM>> Update(int id, RolVM model)
        {
            return await api.Update(id, model);
        }


        [HttpGet("GetRolPagina/{rolId}")]// api/usuario
        public async Task<RespuestaVM<List<RolPaginaVM>>> GetRolUsuario(int rolId)
        {
            return await api.GetRolPagina(rolId);
        }
        [HttpPost("AddUpdateRolPagina")]// api/usuario
        public async Task<RespuestaVM<List<RolPaginaVM>>> AddUpdateRolUsuario(List<RolPaginaVM> modelo)
        {
            return await api.AddUpdateRolUsuario(modelo);
        }
    }
}

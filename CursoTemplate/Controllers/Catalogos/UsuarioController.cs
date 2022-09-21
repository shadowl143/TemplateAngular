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
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioApi api;

        public UsuarioController(UsuarioApi api)
        {
            this.api = api;
        }

        [HttpGet]// api/usuario
        public async Task<RespuestaVM<List<UsuarioVM>>> GetTodos()
        {
            return await api.GetTodos();
        }
        [HttpGet("{id}")]//api/usuario/1
        public async Task<RespuestaVM<UsuarioVM>> GetId(int id)
        {
            return await api.GetId(id);
        }

        [HttpPost]
        public async Task<RespuestaVM<UsuarioVM>> Post(UsuarioVM model)
        {
            return await api.Save(model);
        }

        [HttpPut("{id}")]//api/usuario/1 el de aqui busca el dato por PUT
        public  async Task<RespuestaVM<UsuarioVM>> Update(int id,UsuarioVM model)
        {
           return await  api.Update(id, model);
        }

        [HttpGet("GetUsuarioRol/{usuarioId}")]// api/usuario
        public async Task<RespuestaVM<List<RolUsuarioVM>>> GetRolUsuario(int usuarioId)
        {
            return await api.GetRolUsuario(usuarioId);
        }
        [HttpPost("AddUpdateRolUsuario")]// api/usuario
        public async Task<RespuestaVM<List<RolUsuarioVM>>> AddUpdateRolUsuario(List<RolUsuarioVM> modelo)
        {
            return await api.AddUpdateRolUsuario(modelo);
        }
    }
}

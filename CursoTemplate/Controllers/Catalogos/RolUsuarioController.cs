
namespace CursoTemplate.Controllers.Catalogos
{
    using ContextoDB.ModelsVM;
    using ContextoDB.ModelsVM.Catalogos;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using TemplateApi.Catalogos;


    [Route("api/[controller]")]
   [ApiController]
    [Authorize]
    public class RolUsuarioController : ControllerBase
    {
        private readonly RolUsuarioApi api;

        public RolUsuarioController(RolUsuarioApi api)
        {
            this.api = api;
        }

        [HttpGet("{id}")]
        public async Task<RespuestaVM<List<RolUsuarioVM>>> GetIdRol(int idRol)
        {
            return await api.GetIdUsuario(idRol);
        }

        [HttpPost]
        public async Task<RespuestaVM<RolUsuarioVM>> Post(RolUsuarioVM model)
        {
            return await api.SaveOrUpdate(model);
        }
    }
}

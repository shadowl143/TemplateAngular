

namespace CursoTemplate.Controllers.Catalogos
{
    using ContextoDB.ModelsVM;
    using ContextoDB.ModelsVM.Catalogos;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using TemplateApi.Catalogos;

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RolPaginaController : ControllerBase
    {
        private readonly RolPaginaApi api;

        public RolPaginaController(RolPaginaApi api)
        {
            this.api = api;
        }

        [HttpGet("{id}")]
        public async Task<RespuestaVM<List<RolPaginaVM>>> GetIdRol(int idRol)
        {
            return await api.GetIdRol(idRol);
        }

        [HttpPost]
        public async Task<RespuestaVM<RolPaginaVM>> Post(RolPaginaVM model)
        {
            return await api.SaveOrUpdate(model);
        }

    }
}

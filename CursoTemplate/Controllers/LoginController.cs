using ContextoDB.ModelsVM;
using ContextoDB.ModelsVM.Catalogos;
using ContextoDB.ModelsVM.Seguridad;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TemplateApi.Seguridad;

namespace CursoTemplate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly LoginApi api;

        public LoginController(LoginApi api)
        {

            this.api = api;
        }

        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok("Hola mundo");
        }
        [HttpPost]
        public async Task<RespuestaVM<CredencialVM>> InicioSesion(LoginVM login)
        {
            return await this.api.Login(login);
        }
    }
}

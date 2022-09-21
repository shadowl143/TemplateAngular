using AutoMapper;
using ContextoDB.Data;
using ContextoDB.ModelsVM;
using ContextoDB.ModelsVM.Catalogos;
using ContextoDB.ModelsVM.Seguridad;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TemplateApi.Utilerias;

namespace TemplateApi.Seguridad
{
    public class LoginApi
    {
        private readonly Contexto db;
        private readonly ILogger<LoginApi> log;
        private readonly EncriptarPassword pass;
        private readonly IMapper map;
        private IConfiguration configuration;

        public LoginApi(Contexto db, ILogger<LoginApi> log, EncriptarPassword pass, IMapper map, IConfiguration configuration)
        {
            this.db = db;
            this.log = log;
            this.pass = pass;
            this.map = map;
            this.configuration = configuration;
        }


        public async Task<RespuestaVM<CredencialVM>> Login(LoginVM login)
        {
            try
            {

                //! si la condicion es true lo convierte en false y la condicion es verdad verdad
                // si el resultado es true la converte a false y la condicion es falsa  jlara Jlara
                var usuarioLoguedo = this.db.Usuarios.Where(e => e.NombreUsuario == login.Usuario).FirstOrDefault();
                if (usuarioLoguedo == null || !pass.DesEncriptador(usuarioLoguedo.Password).Equals(login.Contrasenia))
                {
                    return new RespuestaVM<CredencialVM>
                    {
                        Exito = true,
                        Mensaje = "Usuario y/o contrasenia incorrectos",
                        MensajeError = "N/a",
                        Model = null
                    };

                }
                var rolUsuario = await this.db.RolesUsuario.Where(e => e.UsuarioId == usuarioLoguedo.Id && e.Activo).ToListAsync();
                var rolPagina = await this.db.RolesPagina.Where(e => rolUsuario
                .Select(e => e.RolId)
                .Contains(e.RolId) && e.Activo).ToListAsync();  //contain sql= like 

                var paginas = this.map.Map<List<PaginaVM>>(await this.db.Paginas
                    .Where(e => rolPagina.Select(e => e.PaginaId).Contains(e.Id) && e.Activo).ToListAsync());

                var menus = this.map.Map<List<MenuVM>>(await this.db.Menus.Where(e => paginas.Select(e => e.MenuId).Contains(e.Id) && e.Activo ).ToListAsync());
                var crearToken = this.CrearToken(rolUsuario.Select(e => e.RolId).FirstOrDefault().ToString(), usuarioLoguedo.NombreUsuario);
                var token = new JwtSecurityTokenHandler().WriteToken(crearToken);
                var credencial = new CredencialVM
                {
                    NombreUsuario = usuarioLoguedo.NombreUsuario,
                    UsuarioId = usuarioLoguedo.Id,
                    RolId = rolUsuario.Select(e => e.RolId).ToList(),// no existe
                    Menus = menus,
                    Paginas = paginas,
                    Token = token,
                };

                return new RespuestaVM<CredencialVM> { Exito = true, Mensaje = "prueba", MensajeError = "N/a", Model = credencial };
            }
            catch (Exception ex)
            {
                this.log.LogCritical(ex, ex.Message);
                return new RespuestaVM<CredencialVM>
                {
                    Exito = false,
                    Mensaje = "",
                    MensajeError = "Error en el sevidor",
                    Model = null
                };

            }

        }

        public JwtSecurityToken CrearToken(string rol, string nombreusuario)
        {
            try
            {
                string validIssuer = configuration["ConfiguracionJWT:Issuer"];
                string audicen = configuration["ConfiguracionJWT:Audience"];
                SymmetricSecurityKey issuerSignKey = new SymmetricSecurityKey
                    (Encoding.UTF8.GetBytes(configuration["ConfiguracionJWT:Contrasenia"]));

                // la fecha de expiracion del token
                DateTime dtFechaExpiracion;
                DateTime hoy = DateTime.Now;
                dtFechaExpiracion = new DateTime(hoy.Year, hoy.Month, hoy.Day, 23, 59, 59, 999);

                //Agregar nuestro claim
                var claim = new[]
                {
                    new Claim("Roles",rol),
                    new Claim(JwtRegisteredClaimNames.UniqueName,nombreusuario),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())// Web movil esto nos sirve para que un deslogueo de diferentes dispositivos
                };
                return new JwtSecurityToken(
                    issuer: validIssuer,
                    audience: audicen,
                    claims: claim, expires: dtFechaExpiracion,
                    notBefore: hoy,
                    signingCredentials: new SigningCredentials(issuerSignKey, SecurityAlgorithms.HmacSha256)
                    );
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}

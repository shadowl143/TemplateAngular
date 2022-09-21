using AutoMapper;
using ContextoDB.Data;
using TemplateApi.Catalogos;
using TemplateApi.Seguridad;
using TemplateApi.Utilerias;

namespace CursoTemplate.Servicios
{
    // las clases scoped son las que viven dentro de un contexto 
    public static class LlamarClasesScope
    {

        public static void CrearClases(WebApplicationBuilder builder)
        {
            #region Utilerias
            builder.Services.AddScoped(prov => new MapperConfiguration
            (cfg => {
                cfg.AddProfile(new MapeoEntidades());
            }).CreateMapper());
            #endregion

            #region CatalogosApi
            builder.Services.AddScoped<RolApi>();
            builder.Services.AddScoped<RolPaginaApi>();
            builder.Services.AddScoped<RolUsuarioApi>();
            builder.Services.AddScoped<UsuarioApi>();
            #endregion

            #region SeguridadApi
            builder.Services.AddScoped<MenuApi>();
            builder.Services.AddScoped<PaginaApi>();
            builder.Services.AddScoped<LoginApi>();
            builder.Services.AddScoped<EncriptarPassword>();
            #endregion

        }

    }
}

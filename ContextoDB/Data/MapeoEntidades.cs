
namespace ContextoDB.Data
{
    using AutoMapper;
    using ContextoDB.Models.Catalogos;
    using ContextoDB.Models.Seguridad;
    using ContextoDB.ModelsVM.Catalogos;

    using ContextoDB.ModelsVM.Seguridad;

    public class MapeoEntidades:Profile
    {
        public MapeoEntidades()
        {
            #region Catalgos
            #region Rol
            CreateMap<Rol,RolVM>();
            CreateMap<RolVM, Rol>();
            #endregion

            #region RolPagina
            CreateMap<RolPagina, RolPaginaVM>()
                .ForMember(e=>e.PaginaNombre,mo=>mo.MapFrom(m=>m.Pagina.Nombre))
                .ForMember(e => e.RolNombre, mo => mo.MapFrom(m => m.Rol.Nombre)); ;
            CreateMap<RolPaginaVM, RolPagina>();
            #endregion

            #region RolUsuario
            CreateMap<RolUsuario, RolUsuarioVM>()
             .ForMember(e => e.NombreUsuario, mo => mo.MapFrom(m => m.Usuario.NombreUsuario))
             .ForMember(e => e.NombreCompleto, mo => mo.MapFrom(m =>string.Concat(m.Usuario.Nombre," ",m.Usuario.Apellido)))
             .ForMember(e => e.RolNombre, mo => mo.MapFrom(m => m.Rol.Nombre));
            #endregion

            #region Usuario
            CreateMap<Usuario, UsuarioVM>()
                .ForMember(e=>e.NombreCompleto, mo=>mo.MapFrom(e=>e.Nombre+" "+e.Apellido))
                .ForMember(e=>e.Password,mo=>mo.Ignore());
            CreateMap<UsuarioVM, Usuario>();
            #endregion

            #endregion

            #region Seguridad
            CreateMap<Pagina, PaginaVM>()
                .ForMember(e=>e.MenuNombre,mo=>mo.MapFrom(m=>m.Menu.Nombre));
            CreateMap<PaginaVM, Pagina>();

            CreateMap<MenuVM, Menu>();
            CreateMap<Menu, MenuVM>();
            #endregion
        }
    }
}

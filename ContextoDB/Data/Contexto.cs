

namespace ContextoDB.Data
{
    using ContextoDB.Models.Catalogos;
    using ContextoDB.Models.Seguridad;
    using Microsoft.EntityFrameworkCore;
    public class Contexto :DbContext
    {
        public Contexto(DbContextOptions option):base(option)
        {

        }

        #region Seguridad
        public DbSet<Pagina> Paginas { get; set; }
        public DbSet<Menu> Menus { get; set; }
        #endregion

        #region catalogos
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<RolPagina> RolesPagina { get; set; }
        public DbSet<RolUsuario> RolesUsuario { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);  
            builder.Entity<RolUsuario>().HasKey(x => new { x.UsuarioId, x.RolId }); // relación de muchos a muchos
            builder.Entity<RolPagina>().HasKey(x => new { x.RolId, x.PaginaId });
            InsertDatos.LlenarTablas(builder);
        }

    }
}


namespace ContextoDB.Data
{
    using ContextoDB.Models.Catalogos;
    using ContextoDB.Models.Seguridad;
    using Microsoft.EntityFrameworkCore;
    public static class InsertDatos
    {

        public static void LlenarTablas(ModelBuilder builder)
        {
            builder.Entity<Usuario>().HasData(LlenarTablaUsuario());
            builder.Entity<Rol>().HasData(LlenarTablaRoles());
            builder.Entity<Menu>().HasData(LlenarTablaMenu());
            builder.Entity<Pagina>().HasData(LLenarTablaPagina());
            builder.Entity<RolUsuario>().HasData(LlenarTablaRolUsuario());
            builder.Entity<RolPagina>().HasData(LlenarTablaRolPagina());
        }

        public static List<Usuario> LlenarTablaUsuario()
        {
            return new List<Usuario>()
            {
                new Usuario()
                {
                    Id =1,
                    Nombre="Julián",
                    Apellido="Lara",
                    Email="julian_lara@html.com",
                    NombreUsuario="Jlara",
                    Password=CifrarContrasenia("jlara"),
                    Activo=true,
                    FechaRegistro=DateTime.Now,
                },
            };
        }

        public static List<Rol> LlenarTablaRoles()
        {
            var roles = new List<Rol>();
            roles.Add(new Rol()
            {
                Nombre ="Admin",
                Clave="admin",
                Id=1,
                Activo=true
            });
            roles.Add(new Rol()
            {
                Nombre = "Usuario",
                Clave = "user",
                Id = 2,
                Activo = true
            });

            return roles;
        }

        public static List<Menu> LlenarTablaMenu()
        {
            var menus = new List<Menu>();
            menus.Add(new Menu()
            {
                Nombre = "Catalogo",
                Clave = "catalogo",
                Icono= "Menu",
                Id = 1,
                Activo = true
            });
            menus.Add(new Menu()
            {
                Nombre = "Seguridad",
                Clave = "seguridad",
                Icono = "Menu",
                Id = 2,
                Activo = true
            });

            return menus;
        }
        public static List<RolUsuario> LlenarTablaRolUsuario()
        {
            var roles = new List<RolUsuario>();
            roles.Add(new RolUsuario()
            {
                RolId = 1,
                UsuarioId=1
            });

            return roles;
        }
        public static List<Pagina> LLenarTablaPagina()
        {
            return new List<Pagina>()
            {
                new Pagina()
                {
                    Id =1,
                    Clave="usuario",
                    MenuId=1,
                    Nombre="Usuario",
                    Icon="person",
                    Activo=true,
                },
                new Pagina()
                {
                    Id =2,
                    Clave="rol",
                    Nombre="Rol",
                    MenuId=1,
                    Icon="badge",
                    Activo=true,
                },
                new Pagina()
                {
                    Id =3,
                    MenuId =2,
                    Clave="menu",

                    Nombre="Menu",
                    Icon="menu_book",
                    Activo=true,
                },
                new Pagina()
                {
                    Id =4,
                    MenuId =2,
                    Clave="pagina",
                    Nombre="Pagina",
                    Icon="description",
                    Activo=true,
                },
            };

        }
        public static List<RolPagina> LlenarTablaRolPagina()
        {
            var rolPaginas = new List<RolPagina>();
            rolPaginas.Add(new RolPagina()
            {
                RolId = 1,
                PaginaId = 1,
                 Activo = true,
            });
            rolPaginas.Add(new RolPagina()
            {
                RolId = 1,
                PaginaId = 2,
                Activo = true,
            });
            rolPaginas.Add(new RolPagina()
            {
                RolId = 1,
                PaginaId = 3,
                Activo = true,
            });
            rolPaginas.Add(new RolPagina()
            {
                RolId = 1,
                PaginaId = 4,
                Activo = true,
            });

            return rolPaginas;
        }
        public static string CifrarContrasenia(string cont)
        {
            string contra = string.Empty;
            byte[] encriptado= System.Text.Encoding.Unicode.GetBytes(cont);
            contra=Convert.ToBase64String(encriptado);
            return contra;
        }
    }
}

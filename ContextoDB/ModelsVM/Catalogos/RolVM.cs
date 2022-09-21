
namespace ContextoDB.ModelsVM.Catalogos
{
    public class RolVM
    {
        public int Id { get; set; }
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }


    }

    //public class Referencias
    //{
    //    public void IgualarEntidades(RolVM model)
    //    {
    //        RolVM rol = new RolVM();
    //        rol.Id = model.Id;
    //        rol.Clave = model.Clave;
    //        rol.Nombre = model.Nombre;   
    //        rol.Activo = model.Activo;  nombre= usuario.nombre +" "+usuario.apellido
    //    }
    //}
}

using AutoMapper;
using ContextoDB.Data;
using ContextoDB.Models.Catalogos;
using ContextoDB.ModelsVM;
using ContextoDB.ModelsVM.Catalogos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateApi.Catalogos
{
    public class UsuarioApi
    {

        // Rol,Menu
        private readonly IMapper map;
        private readonly Contexto dB;
        private readonly ILogger<UsuarioApi> log;

        public UsuarioApi(IMapper map,Contexto dB,ILogger<UsuarioApi> log)
        {
            this.map = map;
            this.dB = dB;
            this.log = log;
        }

        public async Task<RespuestaVM<List<UsuarioVM>>> GetTodos()
        {
            try
            {
                // select * from Usuarios
                var listado = this.map.Map<List<UsuarioVM>>(await this.dB.Usuarios.ToListAsync());
                
                return new RespuestaVM<List<UsuarioVM>> { Exito = true, Mensaje = "Se encontraron registros", MensajeError = "", Model = listado };
            }
            catch (Exception ex)
            {
                this.log.LogCritical(ex, ex.Message);
                return new RespuestaVM<List<UsuarioVM>> {Exito=false,Mensaje="",MensajeError="Erro al obtener los datos del servidor" };
            }
        }

        public async Task<RespuestaVM<UsuarioVM>> GetId(int id)
        {
            try
            {
                // select * from Usuarios where id=id
                var listado = this.map.Map<UsuarioVM>(await this.dB.Usuarios.FindAsync(id));
                return new RespuestaVM<UsuarioVM> { Exito = true, Mensaje = "Se encontraron registros", MensajeError = "", Model = listado };
            }
            catch (Exception ex)
            {
                this.log.LogCritical(ex, ex.Message);
                return new RespuestaVM<UsuarioVM> { Exito = false, Mensaje = "", MensajeError = "Erro al obtener los datos del servidor" };
            }
        }

        public async Task<RespuestaVM<UsuarioVM>> Save(UsuarioVM model)
        {
            try
            {
                //insert into 
                var modeloGuardar = map.Map<Usuario>(model);
                modeloGuardar.Password = CifrarContrasenia(model.Password);
                this.dB.Usuarios.Add(modeloGuardar);
                await this.dB.SaveChangesAsync();
                return new RespuestaVM<UsuarioVM> { Mensaje = "Guardado", MensajeError = "", Exito = true, Model = model };
            }
            catch (Exception ex)
            {
                this.log.LogCritical(ex, ex.Message);
                return new RespuestaVM<UsuarioVM> { Exito = false, Mensaje = "", MensajeError = "Error al obtener los datos del servidor" };
            }
        }

        public async Task<RespuestaVM<UsuarioVM>> Update(int id,UsuarioVM model)
        {
            try
            {
                // update Usuario set ...  where .... 
                var datoCambiar = this.dB.Usuarios.Find(id);
                if (!model.CambiarPass)
                {
                    model.Password = datoCambiar.Password;
                }else
                {
                    model.Password = CifrarContrasenia(model.Password);
                }

                this.dB.Entry<Usuario>(datoCambiar).CurrentValues.SetValues(model);
                await this.dB.SaveChangesAsync();
                return new RespuestaVM<UsuarioVM> { Mensaje = "Guardado", MensajeError = "", Exito = true, Model = model };
            }
            catch (Exception ex)
            {
                this.log.LogCritical(ex, ex.Message);
                return new RespuestaVM<UsuarioVM> { Exito = false, Mensaje = "", MensajeError = "Erro al obtener los datos del servidor" };
            }
        }

        public async Task<RespuestaVM<List<RolUsuarioVM>>> GetRolUsuario(int usuarioId)
        {
            try
            {

                var rolUsuario = this.map.Map<List<RolUsuarioVM>>( this.dB.RolesUsuario
                    .Include(e => e.Rol)
                    .Include(e => e.Usuario)
                    .Where(e => e.UsuarioId == usuarioId).ToList());
                var rol = this.dB.Roles.ToList();

                var listado = (from role in rol
                               join rolUser in rolUsuario on role.Id equals rolUser.RolId into agrp
                               from union in agrp.DefaultIfEmpty()
                               select new RolUsuarioVM
                               {
                                   NombreCompleto= union==null?"":union.NombreCompleto,
                                   Activo = union == null ? false: union.Activo,
                                   RolNombre=role.Nombre,
                                   RolId=role.Id,
                                   UsuarioId= usuarioId,
                                   NombreUsuario= union == null ? "" : union.NombreUsuario
                               }).ToList();


                return new RespuestaVM<List<RolUsuarioVM>> { Mensaje = "Existo", MensajeError = "N/A", Exito = true, Model = listado };
            }
            catch (Exception ex)
            {
                this.log.LogCritical(ex, ex.Message);
                return new RespuestaVM<List<RolUsuarioVM>> { Exito = false, Mensaje = "N/A", MensajeError = ex.Message, Model = new List<RolUsuarioVM>() };
            }
        }

        public async Task<RespuestaVM<List<RolUsuarioVM>>> AddUpdateRolUsuario(IList<RolUsuarioVM> model)
        {
            try
            {
                foreach (var item in model)
                {
                    var existeRegistro = this.dB.RolesUsuario.Where(e => e.UsuarioId == item.UsuarioId && e.RolId == item.RolId).FirstOrDefault();
                    if (existeRegistro != null)
                    {
                        existeRegistro.Activo = item.Activo;
                        await this.dB.SaveChangesAsync();
                    }
                    else
                    {
                        if (item.Activo)
                        {
                            this.dB.Add(new RolUsuario { RolId = item.RolId, UsuarioId = item.UsuarioId, Activo = item.Activo });
                            await this.dB.SaveChangesAsync();
                        }
                        
                    }
                }
                var listado = this.map.Map<List<RolUsuarioVM>>(await this.dB.RolesUsuario.Where(e => e.UsuarioId == model.First().UsuarioId).ToListAsync());
                return new RespuestaVM<List<RolUsuarioVM>> { Mensaje="Existo",MensajeError="N/A",Exito=true,Model=listado};
            }
            catch (Exception ex)
            {
                this.log.LogCritical(ex, ex.Message);
                return new RespuestaVM<List<RolUsuarioVM>> { Exito = false, Mensaje = "N/A", MensajeError = ex.Message, Model = new List<RolUsuarioVM>() };
            }

        }

        public static string CifrarContrasenia(string cont)
        {
            string contra = string.Empty;
            byte[] encriptado = System.Text.Encoding.Unicode.GetBytes(cont);
            contra = Convert.ToBase64String(encriptado);
            return contra;
        }
    }
}

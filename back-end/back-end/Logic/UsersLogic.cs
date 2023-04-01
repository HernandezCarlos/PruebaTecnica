using back_end.Data;
using back_end.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace back_end.Logic
{
    public class UsersLogic
    {
        public readonly DbPruebaContext _dbcontext;
        public UsersLogic(DbPruebaContext dbcontext) 
        {
            _dbcontext = dbcontext;
        }

        public async Task<IEnumerable<Usuario>> GetUsers()
        {
            try
            {
                return await _dbcontext.Usuarios.ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Usuario> GetUserById(int id)
        {
            try
            {
                var founderUser = await _dbcontext.Usuarios.FindAsync(id);
                var activity = new Actividad { IdUsuario = founderUser.IdUsuario, ActividadInfo = "Busqueda de Usuario" };
                await _dbcontext.Actividades.AddAsync(activity);
                _dbcontext.SaveChanges();
                return founderUser;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task CreateUser(Usuario usuario)
        {
            try
            {
                await _dbcontext.Usuarios.AddAsync(usuario);
                _dbcontext.SaveChanges();
                var activity = new Actividad { IdUsuario = usuario.IdUsuario, ActividadInfo = "Creación de Usuario" };
                await _dbcontext.Actividades.AddAsync(activity);
                _dbcontext.SaveChanges();
                return;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task UpdateUser(Usuario usuario)
        {

            try
            {
                Usuario foundedUser = await _dbcontext.Usuarios.FindAsync(usuario.IdUsuario);
                if(foundedUser != null)
                {
                    foundedUser.Nombre = usuario.Nombre;
                    foundedUser.Apellido = usuario.Apellido;
                    foundedUser.Correo = usuario.Correo;
                    foundedUser.Telefono = usuario.Telefono;
                    foundedUser.FechaNacimiento = usuario.FechaNacimiento;
                    foundedUser.PaisResidencia = usuario.PaisResidencia;
                    foundedUser.RecibirInformacion = usuario.RecibirInformacion;
                    _dbcontext.Update(foundedUser);
                    _dbcontext.SaveChanges();
                    var activity = new Actividad { IdUsuario = usuario.IdUsuario, ActividadInfo = "Actualización de Usuario" };
                    await _dbcontext.Actividades.AddAsync(activity);
                    _dbcontext.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task DeleteUser(long id)
        {
            try
            {
                Usuario foundedUser = await _dbcontext.Usuarios.FindAsync(id);
                _dbcontext.Remove(foundedUser);
                _dbcontext.SaveChanges();
                var activity = new Actividad { IdUsuario = id, ActividadInfo = "Eliminación de Usuario" };
                await _dbcontext.Actividades.AddAsync(activity);
                _dbcontext.SaveChanges();
            }

            catch (Exception)
            {

                throw;
            }
        }

    }
}

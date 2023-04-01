using back_end.Data;
using back_end.DTO;
using back_end.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace back_end.Logic
{
    public class ActivitiesLogic
    {
        public readonly DbPruebaContext _dbcontext;
        public ActivitiesLogic(DbPruebaContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<IEnumerable<ActivityDTO>> GetActivities()
        {
            try
            {
                var activities = await _dbcontext.Actividades.ToListAsync();
                var users = await _dbcontext.Usuarios.ToListAsync();
                var activityList = new List<ActivityDTO>();
                var orderActivities = activities.OrderByDescending( item => item.CreateDate).ThenByDescending(item => item.IdActividad).ToList();

                foreach (var activity in orderActivities)
                {
                   var foundedUser = users.Find( user => user.IdUsuario == activity.IdUsuario);
                   if (foundedUser != null) 
                   {
                       var newActivity = new ActivityDTO { Fecha = activity.CreateDate, Detalle = activity.ActividadInfo, NombreUsuario = $"{foundedUser.Nombre} {foundedUser.Apellido}" };
                       activityList.Add(newActivity);
                   }
              
                }

                return activityList;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}

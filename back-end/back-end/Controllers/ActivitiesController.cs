using back_end.Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace back_end.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {
        public readonly ActivitiesLogic _activitiesLogic;

        public ActivitiesController(ActivitiesLogic activitiesLogic)
        {

            _activitiesLogic = activitiesLogic;
        }

        [HttpGet]
        public async Task<IActionResult> GetActivities()
        {
            try
            {
                var respose = await _activitiesLogic.GetActivities();
                return Ok(respose);
            }
            catch (Exception)
            {

                return BadRequest(StatusCode(400));
            }
        }
    }
}

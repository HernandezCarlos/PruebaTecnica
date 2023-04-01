using back_end.Logic;
using back_end.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace back_end.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public readonly UsersLogic _usersLogic;

        public UsersController(UsersLogic usersLogic) { 

            _usersLogic = usersLogic;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var respose = await _usersLogic.GetUsers();
                return Ok(respose);
            }
            catch (Exception)
            {

                return BadRequest(StatusCode(400));
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            try
            {
                var respose = await _usersLogic.GetUserById(id);
                return Ok(respose);
            }
            catch (Exception)
            {

                return BadRequest(StatusCode(400));
            }
        }


        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] Usuario usuario)
        {
            try
            {
                await _usersLogic.CreateUser(usuario);
                return StatusCode(StatusCodes.Status201Created, new { message = "OK" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new { message = ex.Message });
            }
        }


        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] Usuario usuario)
        {
            try
            {
                await _usersLogic.UpdateUser(usuario);
                return StatusCode(StatusCodes.Status200OK, new { message = "OK" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(long id)
        {
            try
            {
                await _usersLogic.DeleteUser(id);
                return StatusCode(StatusCodes.Status200OK, new { message = "OK" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new { message = ex.Message });
            }
        }

    }
}

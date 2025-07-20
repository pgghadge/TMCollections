using Microsoft.AspNetCore.Mvc;
using TMCollections_Api.DTO.User;
using TMCollections_Api.Services_New.Interfaces;

namespace TMCollections_Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
       
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetById(Guid id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }


        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginUserDto dto)
        {
            var user = await _userService.LoginAsync(dto);
            if (user == null) return Unauthorized("Invalid credentials");
            return Ok(user);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserDto dto)
        {
            try
            {
                await _userService.RegisterAsync(dto);
                return Ok(new { message = "Registered successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, RegisterUserDto dto)
        {
            try
            {
                await _userService.UpdateAsync(id, dto);
                return Ok(new { message = "User updated" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
